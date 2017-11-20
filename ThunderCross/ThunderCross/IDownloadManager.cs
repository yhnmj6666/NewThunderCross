using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderCross
{
	interface IDownloadManager
	{
		string Url { get; set; }
		void Fire();
	}
}
