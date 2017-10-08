using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
				BinaryWriter stdos = new BinaryWriter(Console.OpenStandardOutput());
				stdos.Write(10);
				stdos.Write(@"""success""");
			}
			else
			{
				//AgentClass agent = new AgentClass();
				//agent.AddTask3(bstrUrl: "https://www.baidu.com/index.html");
				//agent.CommitTasks4(1, 0);
			}
		}

		static Web_ext_Message GetMsg()
		{
			int datalen = Console.Read();
			if (datalen == -1)//EOF in console
				return null;
			byte[] buf = new byte[datalen];
			var stdis = Console.OpenStandardInput();
			stdis.Read(buf, 0, datalen);
			string dat = Encoding.UTF8.GetString(buf);
			return new Web_ext_Message(datalen,dat);
		}
	}
}
