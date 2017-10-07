using System;
using System.Collections.Generic;
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
			AgentClass agent = new AgentClass();
			agent.AddTask3(bstrUrl: "https://www.baidu.com/index.html");
			agent.CommitTasks4(1,1);
		}

		Web_ext_Message GetMsg()
		{
			int datalen = Console.Read();
			if (datalen == -1)//EOF in console
				return null;
			byte[] buf = new byte[datalen];
			var stdis = Console.OpenStandardInput();
			stdis.Read(buf, (int)stdis.Position, datalen);
			string dat = Encoding.UTF8.GetString(buf);
			return new Web_ext_Message(datalen,dat);
		}
	}
}
