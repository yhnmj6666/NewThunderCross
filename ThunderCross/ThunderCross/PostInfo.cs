using System.Collections.Generic;
using System.Linq;

namespace ThunderCross
{
	public class PostInfo
	{
		public Dictionary<string,string> Data { get; set; }
		public string ContentType { get; set; }
		public int ContentLength { get; set; }

		public override string ToString()
		{
			return Data==null?string.Empty:string.Join("&", Data.Select(item => string.Format("{0}={1}", item.Key, System.Net.WebUtility.UrlEncode(item.Value))));
		}
	}
}