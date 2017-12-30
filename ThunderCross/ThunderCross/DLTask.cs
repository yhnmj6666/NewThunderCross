using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThunderCross
{
	class DLTask
	{
		public DLRequest Request { get; set; }
		public DLAgent Agent { get; set; }
		public void Perform()
		{
			try
			{
				IDownloadManager dm = (IDownloadManager)Activator.CreateInstance(Type.GetType("ThunderCross.DM" + Agent.ToString()), true);
				dm.Url = Request.Url;
				dm.FileName = Request.Filename;
				dm.Cookie = Request.Cookie;
				if(Agent==DLAgent.Customized)
				{
					((DMCustomized)dm).ExecutablePath = Request.CustomizedDM[0].ExecutablePath;
					((DMCustomized)dm).Arguments = Request.CustomizedDM[0].Arguments;
				}
				dm.Fire();
			} catch (ArgumentNullException)
			{
				MessageBox.Show("Invalid Agent: " + Agent.ToString());
			}
		}
	}
}
