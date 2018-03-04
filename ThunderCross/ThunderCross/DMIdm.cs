using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDManLib;
using System.Windows.Forms;

namespace ThunderCross
{
	class DMIdm : IDownloadManager
	{
		public string Url { get; set; }
		public string FileName { get; set; }
		public string Refer { get; set; }
		public string Cookie { get; set; }
		public HttpMethod Method { get; set; }
		public PostInfo PostData { get; set; }

		public void Fire()
		{
			CIDMLinkTransmitterClass cIDM;
			try
			{
				cIDM = new CIDMLinkTransmitterClass();
				cIDM.SendLinkToIDM(Url, Refer, Cookie, PostData.ToString(), null, null, null, FileName, 0);
			} catch (Exception e)
			{
				ErrorDialog.Report(Strings.Call_Thunder_Error_Agent + "\n" + e.Message + "\n" + e.StackTrace);
				return;
			}
		}

		public bool Valid()
		{
			try
			{
				CIDMLinkTransmitterClass cIDM = new CIDMLinkTransmitterClass();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}
	}
}
