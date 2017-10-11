using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using ThunderAgentLib;

namespace ThunderCross
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args[0] != "Breaked")
			{
				Web_ext_Message msg = GetMsg();
				DLRequest req = msg.Dispatch();
				DLReply reply=req.Ask();
				SendMsg(reply);
			}
			else
			{
				MessageBox.Show("2333");
			}
		}

		static Web_ext_Message GetMsg()
		{//maybe can change to binary reader?
			BinaryReader br = new BinaryReader(Console.OpenStandardInput(),Encoding.UTF8);
			int datalen = br.ReadInt32();
			string dat = Encoding.UTF8.GetString(br.ReadBytes(datalen));
			return new Web_ext_Message(datalen, dat);
			//var stdis = Console.OpenStandardInput();
			//byte[] datas = new byte[1 * 1024 * 1024];
			//int readC=await stdis.ReadAsync(datas, 0, datas.Length);
			//int datalen = BitConverter.ToInt32(datas, 0);
			//string dat = Encoding.UTF8.GetString(datas,4,datalen);
			//return new Web_ext_Message(datalen,dat);
		}

		static void SendMsg(DLReply r)
		{
			BinaryWriter stdos = new BinaryWriter(Console.OpenStandardOutput(),Encoding.UTF8);
			stdos.Write(r.choice.Length+1);
			stdos.Write(r.choice);
		}
	}
}
