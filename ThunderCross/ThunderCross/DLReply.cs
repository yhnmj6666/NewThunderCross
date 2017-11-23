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
				case DLAgent.Cancel:
					choice = @"""Canceled""";
					break;
				case DLAgent.Default:
					choice = @"""Default""";
					break;
				case DLAgent.EagleGet:
				case DLAgent.Thunder:
					choice = @"""External""";
					break;
				default:
					choice = @"""error!!!""";
					break;
			}
		}
	}
}
