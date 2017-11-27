using System;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO.Pipes;
using System.IO;

namespace ThunderCross
{
	class DLRequest
	{
		public string DefaultDM { get; set; }
		public string Url { get; set; }
		public string Filename { get; set; }
		public string ContentType { get; set; }
		public string ContentLength { get; set; }
		public string Cookie { get; set; }
		public string RequestType { get; set; }
		NamedPipeServerStream aPipeServer;
		public DLReply Process()
		{
			switch (RequestType)
			{
				case "Version":
					return new DLReply(DLAgent.Version);
				case "CheckDM":
					return new DLReply(DLAgent.CheckDM);
				case "Download":
					Application.EnableVisualStyles();
					return Ask();
				default:
					return new DLReply(DLAgent.Default);
			}
		}
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
							string command = "\"" + Application.ExecutablePath + "\"" + ' ' + "breaked" + ' ' + pipeName;
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
