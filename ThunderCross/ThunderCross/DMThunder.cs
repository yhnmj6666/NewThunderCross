using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThunderAgentLib;

namespace ThunderCross
{
	class DMThunder : IDownloadManager
	{
		public string Url { get; set; }
		public string FileName { get; set; }
		public string Refer { get; set; }
		public string Cookie { get; set; }
		public DMThunder()	{ }
		public void Fire()
		{
			AgentClass agent = new AgentClass();
			agent.AddTask3(bstrUrl: Url,
				bstrFileName: FileName);
			agent.CommitTasks4(1, 0);
		}
		public bool Valid()
		{
			return true;
		}
	}
}
