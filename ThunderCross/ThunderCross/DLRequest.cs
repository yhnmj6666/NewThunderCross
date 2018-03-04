using System;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO.Pipes;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ThunderCross
{
	class DLRequest
	{
		public string RequestType { get; set; }	
		public string DefaultDM { get; set; }
		public string Action { get; set; }
		public DMCustomized[] CustomizedDM { get; set; }

		public string Url { get; set; }
		public string Filename { get; set; }
		public string FileExtension { get; set; } //current unused
		public string ContentLength { get; set; }
		public string ContentType { get; set; }
		public string Cookie { get; set; }
		public string Refer { get; set; }
		public HttpMethod Method { get; set; }
		public PostInfo PostData { get; set; } 

		public bool ShowCenter { get; set; }
		NamedPipeServerStream aPipeServer;

		private void TryPatchBaiduFileName()
		{
			byte[] b = Encoding.Unicode.GetBytes(Filename);
			List<byte> _b = new List<byte>();
			try
			{
				for (int i = 0; i < b.Length; i += 2)
				{
					if (b[i + 1] != 0x00)
						return;
					else
						_b.Add(b[i]);
				}
			} catch (OverflowException) { return; }
			Filename = Encoding.UTF8.GetString(_b.ToArray());
		}
		private void ChainStart(DLAgent agent)
		{
			string pipeName = Guid.NewGuid().ToString().Replace("-", string.Empty);

			PipeSecurity ps = new PipeSecurity();
			ps.AddAccessRule(new PipeAccessRule("Users", PipeAccessRights.FullControl, System.Security.AccessControl.AccessControlType.Allow));
			aPipeServer = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 10,
					PipeTransmissionMode.Message, PipeOptions.WriteThrough, 1024, 1024, ps);
			string command = "\"" + Application.ExecutablePath + "\"" + ' ' + "breaked" + ' ' + pipeName;
			ProcessUtility.CreateProcessBreakFromJob(command);
			DLTask task = new DLTask { Request = this, Agent = agent };
			string sTask = JsonConvert.SerializeObject(task);
			aPipeServer.WaitForConnection();
			BinaryWriter bw = new BinaryWriter(aPipeServer);
			bw.Write(sTask);
			if (aPipeServer != null)
				aPipeServer.WaitForPipeDrain();
		}
		public DLReply Process()
		{
			switch (RequestType)
			{
				case "Version":
					return new DLReply(DLAgent.Version);
				case "CheckDM":
					return new DLReply(DLAgent.CheckDM);
				case "SelectDM":
					return new DLReply(DLAgent.SelectDM);
				case "Download":
					{
						if (Action == "External")
						{
							ChainStart((DLAgent)Enum.Parse(typeof(DLAgent), DefaultDM));
							return new DLReply((DLAgent)Enum.Parse(typeof(DLAgent), DefaultDM));
						}
						else if (Action == "Default")
							return new DLReply(DLAgent.Default);
						else
						{
							return Ask();
						}
					}
				default:
					return new DLReply(DLAgent.Default);
			}
		}
		public DLReply Ask()
		{
			Filename = System.Net.WebUtility.UrlDecode(Filename);
			TryPatchBaiduFileName();
			ContentType = ContentType.Split(';')[0];
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
					case DLAgent.Idm:
					case DLAgent.Customized:
						{
							ChainStart(askDL.RetAgent);
						}
						break;
					default:
						break;
				}
			}
			DLReply reply= new DLReply(askDL.RetAgent, askDL.SaveDownload, askDL.SavedHost);
			return reply;
		}
	}

	public enum HttpMethod
	{
		GET,
		POST
	}
}
