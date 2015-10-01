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
	/// WinUIinstaller ��ժҪ˵����
	/// </summary>
	[RunInstaller(true)]
	public class WinUIinstaller : System.Configuration.Install.Installer
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WinUIinstaller()
		{
			// �õ����������������ġ�
			InitializeComponent();

			// TODO: �� InitializeComponent ���ú�����κγ�ʼ��
		}

		/// <summary> 
		/// ������������ʹ�õ���Դ��
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


		#region �����������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
