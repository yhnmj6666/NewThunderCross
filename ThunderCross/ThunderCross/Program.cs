using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.IO.Pipes;
using Newtonsoft.Json;

namespace ThunderCross
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args[0] != "Breaked")
			{
				Application.EnableVisualStyles();
				Web_ext_Message msg = GetMsg();
				DLRequest req = msg.Dispatch();
				DLReply reply=req.Ask();
				SendMsg(reply);
			}
			else
			{
				NamedPipeClientStream aPipeClient = new NamedPipeClientStream(args[1]);
				BinaryReader br = new BinaryReader(aPipeClient);
				aPipeClient.Connect(5000);
				string sTask=br.ReadString();
				aPipeClient.Close();
				DLTask dt = JsonConvert.DeserializeObject<DLTask>(sTask);
				dt.Perform();
			}
		}

		static Web_ext_Message GetMsg()
		{
			BinaryReader br = new BinaryReader(Console.OpenStandardInput(),Encoding.UTF8);
			int datalen = br.ReadInt32();
			string dat = Encoding.UTF8.GetString(br.ReadBytes(datalen));
			return new Web_ext_Message(datalen, dat);
		}

		static void SendMsg(DLReply r)
		{
			BinaryWriter stdos = new BinaryWriter(Console.OpenStandardOutput(),Encoding.UTF8);
			stdos.Write(r.choice.Length+1);
			stdos.Write(r.choice);
		}
	}
}
