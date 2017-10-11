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
		NamedPipeServerStream aPipeServer;
		public DLReply Ask()
		{
			AskDL askDL = new AskDL();
			askDL.ShowDialog();
			if(askDL.DialogResult==DialogResult.OK)
			{
				switch(askDL.RetAgent)
				{
					case DLAgent.Default:
						break;
					case DLAgent.Thunder:
						{
							string pipeName = Guid.NewGuid().ToString().Replace("-", string.Empty);

							PipeSecurity ps = new PipeSecurity();
							ps.AddAccessRule(new PipeAccessRule("Users", PipeAccessRights.FullControl, System.Security.AccessControl.AccessControlType.Allow));
							aPipeServer = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 10,
									PipeTransmissionMode.Message, PipeOptions.WriteThrough, 1024, 1024, ps);
							string command = "\"" + Application.ExecutablePath + "\"" + ' ' + "Breaked" + ' ' + pipeName;
							ProcessUtility.CreateProcessBreakFromJob(command);
							DLTask task = new DLTask { Url = Url, Agent = askDL.RetAgent };
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
