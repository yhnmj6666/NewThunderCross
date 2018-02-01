using System;
using System.Windows.Forms;
using ThunderAgentLib;

namespace ThunderCross
{
	class DMThunder : IDownloadManager
	{
		public string Url { get; set; }
		public string FileName { get; set; }
		public string Refer { get; set; }
		public string Cookie { get; set; }
		public HttpMethod Method { get; set; }
		public PostInfo PostData { get; set; }
		public DMThunder()	{ }
		public void Fire()
		{
			AgentClass agent;
			try
			{
				agent = new AgentClass();
			}
			catch (Exception e)
			{
				MessageBox.Show(Strings.Call_Thunder_Error_Agent + "\n" + e.Message + "\n" + e.StackTrace);
				return;
			}
			try
			{
				agent.AddTask3(bstrUrl: Url,
					bstrFileName: FileName,
					bstrCookie: Cookie,
					bstrReferUrl: Refer,
					bstrComments: PostData.ToString());
			}
			catch (Exception)
			{
				try
				{
					agent.AddTask(bstrUrl: Url,
				  bstrFileName: FileName,
				  bstrReferUrl: Refer,
				  bstrComments: PostData.ToString());
				}
				catch (Exception e)
				{
					MessageBox.Show(Strings.Call_Thunder_Error_Agent + "\n" + e.Message + "\n" + e.StackTrace);
					return;
				}
			}
			try
			{
				agent.CommitTasks4(1, 0);
			}
			catch (Exception)
			{
				try { agent.CommitTasks(); }
				catch (Exception e)
				{
					MessageBox.Show(Strings.Call_Thunder_Error_Agent + "\n" + e.Message + "\n" + e.StackTrace);
					return;
				}
			}
		}
		public bool Valid()
		{
			try
			{
				AgentClass agent = new AgentClass();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}
	}
}
