using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CPTT.BusinessFacade;

namespace CPTT.WinUI
{
	/// <summary>
	/// Summary description for RestoreForm.
	/// </summary>
	public class RestoreForm : DevExpress.XtraEditors.XtraForm
	{
		private DevExpress.XtraEditors.SimpleButton btnRestore;
		private System.Windows.Forms.OpenFileDialog openFileDialog_restore;
		private System.Windows.Forms.TextBox tbxRestoreFileRoot;
		private DevExpress.XtraEditors.SimpleButton btnRestoreFileRoot;
		private OptionSystem optionSystem;
		private Login login;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RestoreForm(Login login)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			optionSystem = new OptionSystem();
			this.login = login;

			Login.COM_PORT_IS_BUSY = true;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RestoreForm));
			this.btnRestore = new DevExpress.XtraEditors.SimpleButton();
			this.tbxRestoreFileRoot = new System.Windows.Forms.TextBox();
			this.btnRestoreFileRoot = new DevExpress.XtraEditors.SimpleButton();
			this.openFileDialog_restore = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// btnRestore
			// 
			this.btnRestore.Location = new System.Drawing.Point(184, 104);
			this.btnRestore.Name = "btnRestore";
			this.btnRestore.Size = new System.Drawing.Size(96, 23);
			this.btnRestore.TabIndex = 8;
			this.btnRestore.Text = "还原数据";
			this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
			// 
			// tbxRestoreFileRoot
			// 
			this.tbxRestoreFileRoot.Location = new System.Drawing.Point(144, 40);
			this.tbxRestoreFileRoot.Name = "tbxRestoreFileRoot";
			this.tbxRestoreFileRoot.ReadOnly = true;
			this.tbxRestoreFileRoot.Size = new System.Drawing.Size(288, 21);
			this.tbxRestoreFileRoot.TabIndex = 7;
			this.tbxRestoreFileRoot.Text = "";
			// 
			// btnRestoreFileRoot
			// 
			this.btnRestoreFileRoot.Location = new System.Drawing.Point(32, 40);
			this.btnRestoreFileRoot.Name = "btnRestoreFileRoot";
			this.btnRestoreFileRoot.Size = new System.Drawing.Size(96, 23);
			this.btnRestoreFileRoot.TabIndex = 6;
			this.btnRestoreFileRoot.Text = "备份文件路径";
			this.btnRestoreFileRoot.Click += new System.EventHandler(this.btnRestoreFileRoot_Click);
			// 
			// RestoreForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(456, 205);
			this.Controls.Add(this.btnRestore);
			this.Controls.Add(this.tbxRestoreFileRoot);
			this.Controls.Add(this.btnRestoreFileRoot);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "RestoreForm";
			this.Text = "数据还原";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.RestoreForm_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnRestore_Click(object sender, System.EventArgs e)
		{
			if (!tbxRestoreFileRoot.Text.Equals(string.Empty))
			{
				DialogResult messageResult = MessageBox.Show("您是否确定要还原数据库？","数据还原",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				if ( messageResult == DialogResult.Yes )
				{
					DialogResult messageResult2 = MessageBox.Show("在还原数据之前，请先关闭所有数据访问进程。您是否已经确认关闭？","数据还原",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if (messageResult2 == DialogResult.Yes)
					{
						if (!optionSystem.ExecuteKillSysdbProcesses())
						{
							MessageBox.Show("有其他进程正在访问数据库，还原操作失败！");
							return;
						}

						if (optionSystem.ExecuteRestoreFully(tbxRestoreFileRoot.Text.Trim()))
						{
							if (!optionSystem.ExecuteRestoreDiff(tbxRestoreFileRoot.Text.Trim())) MessageBox.Show("还原过程中出现未知错误，请重新软件(不要登陆)，并关闭所有数据访问线程后重试！");
							else
							{
								MessageBox.Show("已成功将数据库进行还原,软件即将关闭，请重新启动！");
								login.Close();
							}
						}
						else MessageBox.Show("还原过程中出现未知错误，请重新启动软件(不要登陆)，并关闭所有数据访问线程后重试！");
					}
				}
			}

			Login.COM_PORT_IS_BUSY = false;
			login.ResumeQueryThread();

			this.Close();
		}

		private void btnRestoreFileRoot_Click(object sender, System.EventArgs e)
		{
			openFileDialog_restore.Filter = "备份文件 (*.scb)|*.scb";

			if (openFileDialog_restore.ShowDialog() == DialogResult.OK)
			{
				tbxRestoreFileRoot.Text = openFileDialog_restore.FileName;
			}
		}

		private void RestoreForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Login.COM_PORT_IS_BUSY = false;
			login.ResumeQueryThread();
		}
	}
}

