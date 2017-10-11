using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderCross
{
	class DLTask
	{
		public string Url { get; set; }
		public DLAgent Agent { get; set; }
		public void Perform()
		{
			switch(Agent)
			{
				case DLAgent.Thunder:
					{
						DMThunder dm = new DMThunder(Url);
						dm.Fire();
					}
					break;
			}
		}
	}
}
