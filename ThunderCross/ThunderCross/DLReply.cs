using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderCross
{
	class DLReply
	{
		public readonly string choice;

		public DLReply(DLAgent a)
		{
			switch(a)
			{
				case DLAgent.Default:
					choice = @"""Default""";
					break;
				case DLAgent.Thunder:
					choice = @"""External""";
					break;
				default:
					choice = @"""error""";
					break;
			}
		}
	}
}
