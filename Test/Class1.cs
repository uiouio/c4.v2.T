using System;
using System.Collections;
using AjaxPro;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Test
{
	/// <summary>
	/// Class1 ��ժҪ˵����
	/// </summary>
	class Class1
	{
		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			//
			//TODO: �ڴ˴���Ӵ���������Ӧ�ó���
			//


            var pattern = ".+(?<id>\\d+)����·";
            var reg = new Regex(pattern, RegexOptions.IgnoreCase);
            var d = reg.Match("5���ſڻ�8����·");

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
