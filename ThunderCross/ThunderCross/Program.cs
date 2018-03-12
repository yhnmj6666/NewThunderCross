using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.IO.Pipes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Win32;


namespace ThunderCross
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			if (args.Length > 0)
			{
				switch(args[0].ToLower())
				{
					case "breaked":
						{
							NamedPipeClientStream aPipeClient = new NamedPipeClientStream(args[1]);
							BinaryReader br = new BinaryReader(aPipeClient);
							aPipeClient.Connect(5000);
							string sTask = br.ReadString();
							aPipeClient.Close();
							DLTask dt = JsonConvert.DeserializeObject<DLTask>(sTask);
							dt.Perform();
							break;
						}
					default:
						{
							Web_ext_Message msg = GetMsg();
							DLRequest req = msg.Dispatch();
							DLReply reply = req.Process();
							SendMsg(reply);
							break;
						}
				}
			}
			else
			{
				WelcomeDialog dialog = new WelcomeDialog();
				dialog.ShowDialog();
			}
		}

		private static Web_ext_Message GetMsg()
		{
			BinaryReader br = new BinaryReader(Console.OpenStandardInput(),Encoding.UTF8);
			int datalen = br.ReadInt32();
			string dat = Encoding.UTF8.GetString(br.ReadBytes(datalen));
			return new Web_ext_Message(datalen, dat);
		}

		private static void SendMsg(DLReply r)
		{
			BinaryWriter stdos = new BinaryWriter(Console.OpenStandardOutput(), Encoding.UTF8);
			string msg = JsonConvert.SerializeObject(r);
			stdos.Write(msg.Length);
			stdos.Write(msg.ToCharArray());
			stdos.Flush();
		}

	}
}
