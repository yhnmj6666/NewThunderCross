using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThunderAgentLib;

namespace ThunderCross
{
	class DMThunder
	{
		public string Url { get; set; }
		public DMThunder(string url)
		{
			Url = url;
		}
		public void Fire()
		{
			AgentClass agent = new AgentClass();
			agent.AddTask3(bstrUrl: Url);
			agent.CommitTasks4(1, 0);
		}
	}
}
