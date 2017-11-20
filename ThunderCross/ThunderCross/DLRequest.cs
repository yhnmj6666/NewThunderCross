using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO.Pipes;
using System.IO;
using System.Security.Principal;

namespace ThunderCross
{
	class DLRequest
	{
		public string Url { get; set; }
		public string Filename { get; set; }
		public string ContentType { get; set; }
		public string ContentLength { get; set; }
		public string DefaultDM { get; set; }
		NamedPipeServerStream aPipeServer;
		public DLReply Ask()
		{
			Filename = System.Net.WebUtility.UrlDecode(Filename);
			AskDL askDL = new AskDL(this);
			askDL.ShowDialog();
			if(askDL.DialogResult==DialogResult.OK)
			{
				switch(askDL.RetAgent)
				{
					case DLAgent.Default:
						break;
					case DLAgent.Thunder:
					case DLAgent.EagleGet:
						{
							string pipeName = Guid.NewGuid().ToString().Replace("-", string.Empty);

							PipeSecurity ps = new PipeSecurity();
							ps.AddAccessRule(new PipeAccessRule("Users", PipeAccessRights.FullControl, System.Security.AccessControl.AccessControlType.Allow));
							aPipeServer = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 10,
									PipeTransmissionMode.Message, PipeOptions.WriteThrough, 1024, 1024, ps);
							string command = "\"" + Application.ExecutablePath + "\"" + ' ' + "Breaked" + ' ' + pipeName;
							ProcessUtility.CreateProcessBreakFromJob(command);
							DLTask task = new DLTask { Request = this, Agent = askDL.RetAgent };
							string sTask = JsonConvert.SerializeObject(task);
							aPipeServer.WaitForConnection();
							BinaryWriter bw = new BinaryWriter(aPipeServer);
							bw.Write(sTask);
						}
						break;
					default:
						break;
				}
			}
			if (aPipeServer != null)
				aPipeServer.WaitForPipeDrain();
			return new DLReply(askDL.RetAgent);
		}
	}
}
