using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderCross
{
	class Web_ext_Message
	{
		public readonly int dataLength;
		public readonly string data;
		public Web_ext_Message(int len, string dat)
		{
			dataLength = len;
			data = dat;
		}
		public Web_ext_Message(string dat)
		{
			dataLength = dat.Length;
			data = dat;
		}
	}
}
