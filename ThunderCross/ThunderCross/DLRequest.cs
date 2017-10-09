using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Windows.Forms;

namespace ThunderCross
{
	class DLRequest
	{
		public string Url { get; set; }
		public void Ask()
		{
			AskDL askDL = new AskDL();
			askDL.ShowDialog();
			if(askDL.DialogResult==DialogResult.OK)
			{
				switch(askDL.RetAgent)
				{
					case DLAgent.Default:
						break;
					case DLAgent.Thunder:
						{
							DLTask task = new DLTask { Url = Url, Agent = askDL.RetAgent };
							string sTask = JsonConvert.SerializeObject(task);
							string command = "\"" + Application.ExecutablePath + "\"" + ' ' + "Breaked" + sTask;
							ProcessUtility.CreateProcessBreakFromJob(command);
						}
						break;
					default:
						break;
				}
			}
		}
	}
}
