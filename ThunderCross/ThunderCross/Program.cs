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
				Web_ext_Message msg = GetMsgAsync().Result;
				DLRequest req = msg.Dispatch();
				req.Ask();
			}
			else
			{
				MessageBox.Show("2333");
			}
		}

		static async Task<Web_ext_Message> GetMsgAsync()
		{
			var stdis = Console.OpenStandardInput();
			byte[] datas = new byte[1 * 1024 * 1024];
			int readC=await stdis.ReadAsync(datas, 0, datas.Length);
			int datalen = BitConverter.ToInt32(datas, 0);
			string dat = Encoding.UTF8.GetString(datas,4,datalen);
			return new Web_ext_Message(datalen,dat);
		}
	}
}
