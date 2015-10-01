using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for SendedSmsBox.
	/// </summary>
	public class SendedSmsBox : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.Utils.Frames.NotePanel notePanel_DutyDetailsTitle;
		private DevExpress.XtraEditors.SimpleButton simpleButton_DeleteSms;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Sender;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_SendPhoneNum;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Content;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Date;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.GridControl gridControl_SendedSms;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SendedSmsBox()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

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
			this.simpleButton_DeleteSms = new DevExpress.XtraEditors.SimpleButton();
			this.gridControl_SendedSms = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn_Sender = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_SendPhoneNum = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_Content = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_Date = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_SendedSms)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
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
			this.notePanel_DutyDetailsTitle.Text = "共70条短信";
			// 
			// simpleButton_DeleteSms
			// 
			this.simpleButton_DeleteSms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_DeleteSms.Location = new System.Drawing.Point(504, 32);
			this.simpleButton_DeleteSms.Name = "simpleButton_DeleteSms";
			this.simpleButton_DeleteSms.Size = new System.Drawing.Size(72, 24);
			this.simpleButton_DeleteSms.TabIndex = 16;
			this.simpleButton_DeleteSms.Text = "删除";
			// 
			// gridControl_SendedSms
			// 
			this.gridControl_SendedSms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// gridControl_SendedSms.EmbeddedNavigator
			// 
			this.gridControl_SendedSms.EmbeddedNavigator.Name = "";
			this.gridControl_SendedSms.Location = new System.Drawing.Point(0, 64);
			this.gridControl_SendedSms.MainView = this.gridView2;
			this.gridControl_SendedSms.Name = "gridControl_SendedSms";
			this.gridControl_SendedSms.Size = new System.Drawing.Size(584, 424);
			this.gridControl_SendedSms.TabIndex = 15;
			this.gridControl_SendedSms.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												 this.gridView2,
																												 this.gridView1});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn_Sender,
																							 this.gridColumn_SendPhoneNum,
																							 this.gridColumn_Content,
																							 this.gridColumn_Date});
			this.gridView2.GridControl = this.gridControl_SendedSms;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsView.ShowFooter = true;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn_Sender
			// 
			this.gridColumn_Sender.Caption = "发送人";
			this.gridColumn_Sender.Name = "gridColumn_Sender";
			this.gridColumn_Sender.Visible = true;
			this.gridColumn_Sender.VisibleIndex = 0;
			// 
			// gridColumn_SendPhoneNum
			// 
			this.gridColumn_SendPhoneNum.Caption = "发送人手机号码";
			this.gridColumn_SendPhoneNum.Name = "gridColumn_SendPhoneNum";
			this.gridColumn_SendPhoneNum.Visible = true;
			this.gridColumn_SendPhoneNum.VisibleIndex = 1;
			// 
			// gridColumn_Content
			// 
			this.gridColumn_Content.Caption = "内容";
			this.gridColumn_Content.Name = "gridColumn_Content";
			this.gridColumn_Content.Visible = true;
			this.gridColumn_Content.VisibleIndex = 2;
			// 
			// gridColumn_Date
			// 
			this.gridColumn_Date.Caption = "发送日期";
			this.gridColumn_Date.Name = "gridColumn_Date";
			this.gridColumn_Date.Visible = true;
			this.gridColumn_Date.VisibleIndex = 3;
			// 
			// gridView1
			// 
			this.gridView1.GridControl = this.gridControl_SendedSms;
			this.gridView1.Name = "gridView1";
			// 
			// SendedSmsBox
			// 
			this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Appearance.Options.UseBackColor = true;
			this.Controls.Add(this.simpleButton_DeleteSms);
			this.Controls.Add(this.gridControl_SendedSms);
			this.Controls.Add(this.notePanel_DutyDetailsTitle);
			this.Name = "SendedSmsBox";
			this.Size = new System.Drawing.Size(584, 488);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_SendedSms)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}

