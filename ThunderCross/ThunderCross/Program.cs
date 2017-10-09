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
				System.Threading.Thread.Sleep(100);
				Web_ext_Message msg = GetMsg();
				DLRequest req = msg.Dispatch();
//				MessageBox.Show("");
				req.Ask();
				//BinaryWriter stdos = new BinaryWriter(Console.OpenStandardOutput());
				//stdos.Write(10);
				//stdos.Write(@"""success""");
			}
			else
			{
				MessageBox.Show("2333");
				//AgentClass agent = new AgentClass();
				//agent.AddTask3(bstrUrl: "https://www.baidu.com/index.html");
				//agent.CommitTasks4(1, 0);
			}
		}

		static Web_ext_Message GetMsg()
		{
			var stdis = Console.OpenStandardInput();
			byte[] datas = new byte[1 * 1024 * 1024];
			stdis.Read(datas, 0, datas.Length);
			int datalen = BitConverter.ToInt32(datas, 0);
			string dat = Encoding.UTF8.GetString(datas,4,datalen);
			return new Web_ext_Message(datalen,dat);
		}
	}
}
