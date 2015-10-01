using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using CPTT.SystemFramework;
using Microsoft.Practices.EnterpriseLibrary.Configuration;

namespace CPTT.WinUI
{
	/// <summary>
	/// Summary description for AboutForm.
	/// </summary>
	public class AboutForm : DevExpress.XtraEditors.XtraForm
	{
		private System.ComponentModel.IContainer components;
		internal const string USERSTYLEPROFILE_CONFIG_NAME = "UserStyleProfile";
		private System.Windows.Forms.Timer fadeTimer;
		private UserStyle userStyle;
		private System.Windows.Forms.Label label1;
		public bool formShowing = true;

		#region 加载窗体风格
		//根据配置文件加载窗体风格
		private void loadUserStyleProfile()
		{
			try
			{
				userStyle = ConfigurationManager.GetConfiguration(USERSTYLEPROFILE_CONFIG_NAME) as UserStyle;
				string windowsStyle = userStyle.StyleName;
				string windowsSkin = userStyle.SkinName;

				if(windowsStyle.Equals("Default"))
				{
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetDefaultStyle();
				}
				else if(windowsStyle.Equals("WindowsXP"))
				{
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetWindowsXPStyle();
				}
				else if(windowsStyle.Equals("OfficeXP"))
				{
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetOffice2003Style();
				}
				else if(windowsStyle.Equals("Office2000"))
				{
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetDefaultStyle();
				}
				else if(windowsStyle.Equals("Office2003"))
				{
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetOffice2003Style();
				}
				else if(windowsStyle.Equals("Skin"))
				{
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(windowsSkin);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"系统信息",MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}
		#endregion

		public AboutForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			loadUserStyleProfile();

			this.Opacity = 0.0;
			Activate();
			Refresh();
			fadeTimer.Start();
			Refresh();
		}

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AboutForm));
			this.fadeTimer = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// fadeTimer
			// 
			this.fadeTimer.Tick += new System.EventHandler(this.fadeTimer_Tick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(320, 72);
			this.label1.TabIndex = 0;
			this.label1.Text = "创智智能晨检网络管理系统"+SystemFramework.Util.PROJECT_VERSION + SystemFramework.Util.UseVersion + Environment.NewLine;
			this.label1.Text += "创智智能晨检网络管理系统数据库版本" + new CPTT.BusinessFacade.UtilSystem().GetDBVersion();
			// 
			// AboutForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(426, 135);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.Text = "关于 创智智能晨检网络管理系统";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.AboutForm_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		private void fadeTimer_Tick(object sender, System.EventArgs e)
		{
			if(formShowing)
			{
				double d = 1000.0 / fadeTimer.Interval / 100.0;
				if (Opacity + d >= 1.0)
				{
					Opacity = 1.0;
					fadeTimer.Stop();
				}
				else
				{
					Opacity += d;
				}
			}
			else
			{
				double d = 1000.0 / fadeTimer.Interval / 100.0;
				if (Opacity - d <= 0.0)
				{
					Opacity = 0.0;
					fadeTimer.Stop();

					this.Close();
				}
				else
				{
					Opacity -= d;
				}
			}
		}

		private void AboutForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(Opacity != 0)
			{
				e.Cancel = true;
				this.formShowing = false;
				fadeTimer.Start();
			}
		}
	}
}

