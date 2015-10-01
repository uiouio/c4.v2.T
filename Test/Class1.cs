using System;
using System.Collections;
using AjaxPro;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Test
{
	/// <summary>
	/// Class1 的摘要说明。
	/// </summary>
	class Class1
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			//
			//TODO: 在此处添加代码以启动应用程序
			//


            var pattern = ".+(?<id>\\d+)号线路";
            var reg = new Regex(pattern, RegexOptions.IgnoreCase);
            var d = reg.Match("5号门口机8号线路");

			byte[] hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("abcdefg"));
			StringBuilder sb = new StringBuilder();
			foreach(byte b in hash)
			{
				sb.Append(b.ToString("x2"));
			}

			string f = string.Empty;
			
		}
	}

}
