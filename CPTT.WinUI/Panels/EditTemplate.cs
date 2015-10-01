using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using CPTT.BusinessFacade;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for EditTemplate.
	/// </summary>
	public class EditTemplate : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.Utils.Frames.NotePanel notePanel_DutyDetailsTitle;
		private DevExpress.XtraEditors.SimpleButton simpleButton_EditTemp;
		private DevExpress.XtraEditors.SimpleButton simpleButton_DeleteTemp;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.Utils.Frames.NotePanel notePanel_SendTo;
		private DevExpress.Utils.Frames.NotePanel notePanel1;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.TextEdit textEdit1;
		private DevExpress.XtraEditors.MemoEdit memoEdit1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DataSet SMSTemp;


		public EditTemplate()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			SMSTemp = new SMSInfoSystem().GetAllSMSTemp();
			gridControl1.DataSource = SMSTemp.Tables[0];
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.notePanel_DutyDetailsTitle = new DevExpress.Utils.Frames.NotePanel();
			this.simpleButton_EditTemp = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_DeleteTemp = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
			this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_SendTo = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel1 = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// notePanel_DutyDetailsTitle
			// 
			this.notePanel_DutyDetailsTitle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_DutyDetailsTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_DutyDetailsTitle.ForeColor = System.Drawing.Color.Gray;
			this.notePanel_DutyDetailsTitle.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_DutyDetailsTitle.Location = new System.Drawing.Point(0, 0);
			this.notePanel_DutyDetailsTitle.MaxRows = 5;
			this.notePanel_DutyDetailsTitle.Name = "notePanel_DutyDetailsTitle";
			this.notePanel_DutyDetailsTitle.ParentAutoHeight = true;
			this.notePanel_DutyDetailsTitle.Size = new System.Drawing.Size(584, 23);
			this.notePanel_DutyDetailsTitle.TabIndex = 13;
			this.notePanel_DutyDetailsTitle.TabStop = false;
			this.notePanel_DutyDetailsTitle.Text = "编辑模板";
			// 
			// simpleButton_EditTemp
			// 
			this.simpleButton_EditTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_EditTemp.Location = new System.Drawing.Point(384, 120);
			this.simpleButton_EditTemp.Name = "simpleButton_EditTemp";
			this.simpleButton_EditTemp.Size = new System.Drawing.Size(72, 24);
			this.simpleButton_EditTemp.TabIndex = 18;
			this.simpleButton_EditTemp.Text = "保存";
			this.simpleButton_EditTemp.Click += new System.EventHandler(this.simpleButton_EditTemp_Click);
			// 
			// simpleButton_DeleteTemp
			// 
			this.simpleButton_DeleteTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_DeleteTemp.Location = new System.Drawing.Point(384, 24);
			this.simpleButton_DeleteTemp.Name = "simpleButton_DeleteTemp";
			this.simpleButton_DeleteTemp.Size = new System.Drawing.Size(72, 24);
			this.simpleButton_DeleteTemp.TabIndex = 18;
			this.simpleButton_DeleteTemp.Text = "删除";
			this.simpleButton_DeleteTemp.Click += new System.EventHandler(this.simpleButton_DeleteTemp_Click);
			// 
			// groupControl1
			// 
			this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.DarkOrange;
			this.groupControl1.AppearanceCaption.Options.UseFont = true;
			this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
			this.groupControl1.Controls.Add(this.memoEdit1);
			this.groupControl1.Controls.Add(this.textEdit1);
			this.groupControl1.Controls.Add(this.notePanel_SendTo);
			this.groupControl1.Controls.Add(this.notePanel1);
			this.groupControl1.Controls.Add(this.simpleButton_EditTemp);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl1.Location = new System.Drawing.Point(0, 23);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(584, 153);
			this.groupControl1.TabIndex = 19;
			this.groupControl1.Text = "添加模板";
			// 
			// memoEdit1
			// 
			this.memoEdit1.EditValue = "";
			this.memoEdit1.Location = new System.Drawing.Point(144, 64);
			this.memoEdit1.Name = "memoEdit1";
			this.memoEdit1.Size = new System.Drawing.Size(200, 56);
			this.memoEdit1.TabIndex = 20;
			this.memoEdit1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.memoEdit1_KeyPress);
			// 
			// textEdit1
			// 
			this.textEdit1.EditValue = "";
			this.textEdit1.Location = new System.Drawing.Point(144, 32);
			this.textEdit1.Name = "textEdit1";
			this.textEdit1.Size = new System.Drawing.Size(96, 23);
			this.textEdit1.TabIndex = 19;
			// 
			// notePanel_SendTo
			// 
			this.notePanel_SendTo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_SendTo.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_SendTo.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_SendTo.ForeColor = System.Drawing.Color.Black;
			this.notePanel_SendTo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_SendTo.Location = new System.Drawing.Point(48, 32);
			this.notePanel_SendTo.MaxRows = 5;
			this.notePanel_SendTo.Name = "notePanel_SendTo";
			this.notePanel_SendTo.ParentAutoHeight = true;
			this.notePanel_SendTo.Size = new System.Drawing.Size(80, 22);
			this.notePanel_SendTo.TabIndex = 6;
			this.notePanel_SendTo.TabStop = false;
			this.notePanel_SendTo.Text = "模板名称";
			// 
			// notePanel1
			// 
			this.notePanel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel1.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel1.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel1.ForeColor = System.Drawing.Color.Black;
			this.notePanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel1.Location = new System.Drawing.Point(48, 64);
			this.notePanel1.MaxRows = 5;
			this.notePanel1.Name = "notePanel1";
			this.notePanel1.ParentAutoHeight = true;
			this.notePanel1.Size = new System.Drawing.Size(80, 22);
			this.notePanel1.TabIndex = 6;
			this.notePanel1.TabStop = false;
			this.notePanel1.Text = "模板内容";
			// 
			// groupControl2
			// 
			this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.DarkOrange;
			this.groupControl2.AppearanceCaption.Options.UseFont = true;
			this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
			this.groupControl2.Controls.Add(this.gridControl1);
			this.groupControl2.Controls.Add(this.simpleButton_DeleteTemp);
			this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl2.Location = new System.Drawing.Point(0, 176);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(584, 312);
			this.groupControl2.TabIndex = 20;
			this.groupControl2.Text = "删除模板";
			// 
			// gridControl1
			// 
			this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(3, 61);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(578, 248);
			this.gridControl1.TabIndex = 0;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowGroup = false;
			this.gridView1.OptionsView.ShowFilterPanel = false;
			this.gridView1.OptionsView.ShowFooter = true;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "模板名称";
			this.gridColumn1.FieldName = "templet_name";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "模板内容";
			this.gridColumn2.FieldName = "templet_content";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "gridColumn3";
			this.gridColumn3.FieldName = "templet_id";
			this.gridColumn3.Name = "gridColumn3";
			// 
			// EditTemplate
			// 
			this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Appearance.Options.UseBackColor = true;
			this.Controls.Add(this.groupControl2);
			this.Controls.Add(this.groupControl1);
			this.Controls.Add(this.notePanel_DutyDetailsTitle);
			this.Name = "EditTemplate";
			this.Size = new System.Drawing.Size(584, 488);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region add template
		private void simpleButton_EditTemp_Click(object sender, System.EventArgs e)
		{
			string name = textEdit1.Text.Trim();
			string content = memoEdit1.Text.Trim();
			
			if(name==string.Empty||content==string.Empty)
			{
				MessageBox.Show("模板名称跟内容必须填写.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			int flag = new SMSInfoSystem().InsertSMSTemplate(name,content);

			if(flag == -1)
			{
				MessageBox.Show("模板名称已存在,请更换后重试.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else if(flag > 0 )
			{
				SMSTemp = new SMSInfoSystem().GetAllSMSTemp();
				gridControl1.DataSource = SMSTemp.Tables[0];
				textEdit1.Text = string.Empty;
				memoEdit1.Text = string.Empty;

				MessageBox.Show("模板保存成功.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		#endregion

		#region delete template
		private void simpleButton_DeleteTemp_Click(object sender, System.EventArgs e)
		{
			if(gridView1.RowCount == 0)
			{
				MessageBox.Show("请先选择要删除的模板.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			int tempID = Convert.ToInt32(gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["templet_id"]);

			if(new SMSInfoSystem().DeleteSMSTemp(tempID)>0)
			{
				gridView1.DeleteRow(gridView1.GetSelectedRows()[0]);
				MessageBox.Show("模板删除成功.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("模板删除失败,请重试.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		#endregion

		private void memoEdit1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(memoEdit1.Text.Trim().Length>70)
			{
				MessageBox.Show("发送内容不能超过70个字.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				e.Handled = true;
			}
		}
	}
}

