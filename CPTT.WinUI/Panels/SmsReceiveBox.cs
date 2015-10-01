using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;

using CPTT.BusinessFacade;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for SmsReceiveBox.
	/// </summary>
	public class SmsReceiveBox : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.Utils.Frames.NotePanel notePanel_DutyDetailsTitle;
		private DevExpress.XtraGrid.GridControl gridControl_ReceiveSms;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Sender;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Content;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Date;
		private DevExpress.XtraEditors.SimpleButton simpleButton_DeleteSms;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_SendPhoneNum;
		private System.Timers.Timer timer_ReceiveReply;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DataSet SMSReply;
		private DataView SMSReplyView;
		private int originalCount = 0;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private int currentCount = 0;

		public SmsReceiveBox()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			LoadReply();
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
			this.gridControl_ReceiveSms = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn_Sender = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_SendPhoneNum = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_Content = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_Date = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.simpleButton_DeleteSms = new DevExpress.XtraEditors.SimpleButton();
			this.timer_ReceiveReply = new System.Timers.Timer();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_ReceiveSms)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timer_ReceiveReply)).BeginInit();
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
			this.notePanel_DutyDetailsTitle.TabIndex = 12;
			this.notePanel_DutyDetailsTitle.TabStop = false;
			this.notePanel_DutyDetailsTitle.Text = "共70条短信";
			// 
			// gridControl_ReceiveSms
			// 
			this.gridControl_ReceiveSms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// gridControl_ReceiveSms.EmbeddedNavigator
			// 
			this.gridControl_ReceiveSms.EmbeddedNavigator.Name = "";
			this.gridControl_ReceiveSms.Location = new System.Drawing.Point(0, 64);
			this.gridControl_ReceiveSms.MainView = this.gridView2;
			this.gridControl_ReceiveSms.Name = "gridControl_ReceiveSms";
			this.gridControl_ReceiveSms.Size = new System.Drawing.Size(584, 424);
			this.gridControl_ReceiveSms.TabIndex = 13;
			this.gridControl_ReceiveSms.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												  this.gridView2,
																												  this.gridView1});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn_Sender,
																							 this.gridColumn_SendPhoneNum,
																							 this.gridColumn_Content,
																							 this.gridColumn_Date,
																							 this.gridColumn2});
			this.gridView2.GridControl = this.gridControl_ReceiveSms;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsCustomization.AllowGroup = false;
			this.gridView2.OptionsView.ShowFilterPanel = false;
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
			this.gridView1.GridControl = this.gridControl_ReceiveSms;
			this.gridView1.Name = "gridView1";
			// 
			// simpleButton_DeleteSms
			// 
			this.simpleButton_DeleteSms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_DeleteSms.Location = new System.Drawing.Point(504, 32);
			this.simpleButton_DeleteSms.Name = "simpleButton_DeleteSms";
			this.simpleButton_DeleteSms.Size = new System.Drawing.Size(72, 24);
			this.simpleButton_DeleteSms.TabIndex = 14;
			this.simpleButton_DeleteSms.Text = "删除";
			this.simpleButton_DeleteSms.Click += new System.EventHandler(this.simpleButton_DeleteSms_Click);
			// 
			// timer_ReceiveReply
			// 
			this.timer_ReceiveReply.Enabled = true;
			this.timer_ReceiveReply.Interval = 10000;
			this.timer_ReceiveReply.SynchronizingObject = this;
			this.timer_ReceiveReply.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_ReceiveReply_Elapsed);
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "回复来自";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 4;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "gridColumn2";
			this.gridColumn2.FieldName = "replyContent_id";
			this.gridColumn2.Name = "gridColumn2";
			// 
			// SmsReceiveBox
			// 
			this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Appearance.Options.UseBackColor = true;
			this.Controls.Add(this.simpleButton_DeleteSms);
			this.Controls.Add(this.gridControl_ReceiveSms);
			this.Controls.Add(this.notePanel_DutyDetailsTitle);
			this.Name = "SmsReceiveBox";
			this.Size = new System.Drawing.Size(584, 488);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_ReceiveSms)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timer_ReceiveReply)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		[DllImport("winmm.dll")]
		private static extern int PlaySound(string name,int hmod,int flag);

		private void LoadReply()
		{
			SMSReply = new SMSInfoSystem().GetAllSMSReply();
			SMSReplyView = SMSReply.Tables[0].DefaultView;
//			SMSReplyView.RowFilter = "replyContent_status=0";
			SMSReplyView.Sort = "replyContent_date desc";

			currentCount = SMSReplyView.Count;

			if(currentCount>originalCount)
			{
				PlaySound("msg.wav",0x0,0x20000);
				originalCount = currentCount;
			}

			gridControl_ReceiveSms.DataSource = SMSReplyView;
		}

		private void timer_ReceiveReply_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			LoadReply();
		}

		private void simpleButton_DeleteSms_Click(object sender, System.EventArgs e)
		{
			if(gridView2.RowCount==0)
			{
				MessageBox.Show("请先选择要删除的回复!","出错了!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			int replyID = Convert.ToInt32(gridView2.GetDataRow(gridView2.GetSelectedRows()[0])["replyContent_id"]);

			if(new SMSInfoSystem().DeleteSMSReply(replyID)>0)
			{
				gridView2.DeleteRow(gridView2.GetSelectedRows()[0]);
				MessageBox.Show("删除成功!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("删除失败!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
	}
}

