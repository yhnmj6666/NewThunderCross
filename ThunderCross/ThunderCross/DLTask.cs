using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderCross
{
	class DLTask
	{
		public DLRequest Request { get; set; }
		public DLAgent Agent { get; set; }
		public void Perform()
		{
			switch(Agent)
			{
				case DLAgent.Thunder:
					{
						DMThunder dm = new DMThunder(Request.Url);
						dm.Fire();
					}
					break;
				case DLAgent.EagleGet:
					{
						DMEagleGet dm = new DMEagleGet(Request.Url);
						dm.Fire();
					}
					break;
			}
		}
	}
}
