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
		public DMThunder() { }
		public void Fire()
		{
			AgentClass agent;
			try
			{
				agent = new AgentClass();
			}
			catch (Exception e)
			{
				ErrorDialog.Report(Strings.Call_Thunder_Error_Agent + "\n" + e.Message + "\n" + e.StackTrace);
				return;
			}
			try
			{
				Type type = typeof(AgentClass);
				var method = type.GetMethod("AddTask12");	//only on x86
				method.Invoke(agent, new object[] { Url, "", "", PostData.ToString(), Refer, "", -1, 0, -1, Cookie, "", "", 0u, "rightup" });
			}
			catch (Exception)
			{
				try
				{
					agent.AddTask5(bstrUrl: Url,
						bstrFileName: FileName == null ? FileName : "",
						bstrCookie: Cookie == null ? Cookie : "",
						bstrReferUrl: Refer == null ? Refer : "",
						bstrComments: PostData.ToString(),
						eCallType: _tag_Enum_CallType.ECT_Agent5);
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
					ErrorDialog.Report(Strings.Call_Thunder_Error_Agent + "\n" + e.Message + "\n" + e.StackTrace);
					return;
				}
			}
			}
			try
			{
				agent.CommitTasks4(1, 1);
			}
				catch (Exception e)
				{
				ErrorDialog.Report(Strings.Call_Thunder_Error_Agent + (Environment.Is64BitProcess?Strings.Recommand_32bit:"") + e.Message + "\n" + e.StackTrace);
					return;
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
