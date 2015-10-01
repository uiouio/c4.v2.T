using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using RexDataProtector;

namespace CPTT.WinUI
{
	/// <summary>
	/// WinUIinstaller 的摘要说明。
	/// </summary>
	[RunInstaller(true)]
	public class WinUIinstaller : System.Configuration.Install.Installer
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WinUIinstaller()
		{
			// 该调用是设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化
		}

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public override void Install(System.Collections.IDictionary stateServer)
		{
			try
			{
				FileInfo fi = new FileInfo(this.Context.Parameters["targetdir"]+"Version.config");
				XmlDocument myDoc = new XmlDocument();
				myDoc.Load(fi.FullName);

				XmlNodeList nodeList = myDoc.SelectSingleNode("configuration").ChildNodes;
				foreach (XmlNode node in nodeList)
				{
					XmlElement xm = (XmlElement)node;
					if (xm.Name == "version")
					{
						xm.InnerText = new DataProtector().InitInfoEncryp(this.Context.Parameters["version"]);
					}
				}

				myDoc.Save(fi.FullName);
			}
			catch
			{
				throw new Exception();
			}
		}


		#region 组件设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
