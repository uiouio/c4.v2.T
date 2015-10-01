
#define CardValidCheck2
//#undef CardValidCheck2

#define CardValidCheck
//#undef CardValidCheck

#define CardValidCheck3
//#undef CardValidCheck3



using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using CPTT.SystemFramework;
using CPTT.BusinessFacade;
using System.Threading;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for CardManagement.
	/// </summary>
	public class CardManagement : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
		private DevExpress.XtraEditors.GroupControl groupControl_Send_MyCardRec;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_MyCardRec;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card1stMadeDate;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card1stHolder;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card1stNumber;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Send_TeaCard;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Send_StuCard;
		private DevExpress.XtraTab.XtraTabControl xtraTabControl_CardMgmt;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_CardSent;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_CardLogout;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Logout_CardSearch;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Logout_TeaCard;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Logout_StuCard;
		private DevExpress.XtraEditors.GroupControl groupControl_Logout_MyCardRec;
		private DevExpress.XtraEditors.DataNavigator dataNavigator_CardSent;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_IDQuery;
		private DevExpress.XtraEditors.GroupControl groupControl_IDQueryFastSer;
		private DevExpress.XtraEditors.GroupControl groupControl_IDQueryTimeAndCardNumber;
		private DevExpress.XtraEditors.TextEdit textEdit_IDQueryCardNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_IDQueryCardNumber;
		private DevExpress.XtraEditors.DateEdit dateEdit_IDQueryEndTime;
		private DevExpress.Utils.Frames.NotePanel notePanel_IDQueryBegTime;
		private DevExpress.Utils.Frames.NotePanel notePanel_IDQueryEndTime;
		private DevExpress.XtraEditors.DateEdit dateEdit_IDQueryBegTime;
		private DevExpress.XtraEditors.GroupControl groupControl_IDQueryNumberAndName;
		private DevExpress.XtraEditors.TextEdit textEdit_IDQueryStuName;
		private DevExpress.XtraEditors.TextEdit textEdit_IDQueryStuNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_IDQueryStuNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_IDQueryStuName;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_IDQueryStuClass;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_IDQueryStuGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_IDQueryStuGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_IDQueryStuClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_IDQueryGradeAndClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_IDQueryTimeAndCardNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_IDQueryNumberAndName;
		private DevExpress.Utils.Frames.NotePanel notePanel1_IDQueryFastSer;
		private DevExpress.XtraGrid.GridControl gridControl_IDQueryView;
		private DevExpress.XtraEditors.SimpleButton simpleButton_IDQueryPrint;
		private DevExpress.XtraEditors.SimpleButton simpleButton_IDQueryStuCard;
		private DevExpress.XtraEditors.SimpleButton simpleButton_IDQueryTeaCard;
		private DevExpress.XtraEditors.SimpleButton simpleButton_IDQuerySearch;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_BatchSend;
		private DevExpress.XtraEditors.GroupControl groupControl_BatchSendView;
		private DevExpress.XtraGrid.GridControl gridControl_BatchSendView;
		private DevExpress.XtraEditors.GroupControl groupControl_BatchSendButtonGroup;
		private DevExpress.Utils.Frames.NotePanel notePanel_BatchSendButtonGroup;
		private DevExpress.XtraEditors.SimpleButton simpleButton_BatchSendStuCard;
		private DevExpress.XtraEditors.SimpleButton simpleButton_BatchSendTeaCard;
		private DevExpress.XtraEditors.SimpleButton simpleButton_BatchSendStop;
		private DevExpress.XtraEditors.SimpleButton simpleButton_BatchSendCheck;
		private DevExpress.XtraEditors.GroupControl groupControl_BatchSendSerCond;
		private DevExpress.Utils.Frames.NotePanel notePanel_BatchSendClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_BatchSendGrade;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_BatchSendGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_BatchSendSerCond;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_BatchSendClass;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_DataSynchAndReceive;
		private DevExpress.XtraEditors.GroupControl groupControl_DeviceView;
		private DevExpress.XtraGrid.GridControl gridControl_DeviceView;
		private DevExpress.XtraEditors.GroupControl groupControl_DataSynchReceiDesk;
		private DevExpress.Utils.Frames.NotePanel notePanel_DataSynchReceiDesk;
		private DevExpress.XtraEditors.SimpleButton simpleButton_GetMobile;
		private DevExpress.XtraEditors.SimpleButton simpleButton_FastDataReceive;
		private DevExpress.XtraEditors.SimpleButton simpleButton_StopDataReceive;
		private DevExpress.XtraEditors.PanelControl panelControl_StuField;
		private DevExpress.XtraEditors.PanelControl panelControl_TeaField;
		private DevExpress.XtraEditors.GroupControl groupControl_IDQueryTeaNumberAndName;
		private DevExpress.Utils.Frames.NotePanel notePanel_IDQueryTeaName;
		private DevExpress.XtraEditors.TextEdit textEdit_IDQueryTeaName;
		private DevExpress.XtraEditors.TextEdit textEdit_IDQueryTeaNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_IDQueryTeaNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_IDQueryTeaTimeAndCardNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_IDQueryTeaNumberAndName;
		private DevExpress.XtraEditors.GroupControl groupControl_IDQueryGradeAndClass;
		private DevExpress.XtraEditors.PanelControl panelControl3;
		private DevExpress.XtraEditors.GroupControl groupControl_Logout_StuCardMgmt;
		private DevExpress.XtraEditors.TextEdit textEdit_Logout_StuName;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Logout_StuClass;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Logout_StuGrade;
		private DevExpress.XtraEditors.TextEdit textEdit_Logout_StuNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_Logout_StuNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_Logout_StuClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_Logout_StuGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_Logout_StuCardSerCond;
		private DevExpress.Utils.Frames.NotePanel notePanel_Logout_StuName;
		private DevExpress.XtraEditors.GroupControl groupControl_Logout_TeaCardMgmt;
		private DevExpress.Utils.Frames.NotePanel notePanel_Logout_TeaCardSerCond;
		private DevExpress.XtraGrid.GridControl gridControl_Logout_CardInfo;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraEditors.PanelControl panelControl4;
		private DevExpress.XtraEditors.GroupControl groupControl_Send_CardInfo;
		private DevExpress.XtraGrid.GridControl gridControl_Send_CardInfo;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.GroupControl groupControl_Send_TeaCardMgmt;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_TeaCardSerCond;
		private DevExpress.XtraEditors.GroupControl groupControl_Send_StuCardMgmt;
		private DevExpress.XtraEditors.TextEdit textEdit_Send_StuName;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Send_StuClass;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Send_StuGrade;
		private DevExpress.XtraEditors.TextEdit textEdit_Send_StuNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_StuNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_StuClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_StuGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_StuCardSerCond;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_StuName;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private System.ComponentModel.IContainer components;

		private DataSet CardInfo;
		private DataSet BatchCardInfo;
		private DataSet LeaveCardInfo;

		private DataView CardView;
		private DataView BatchCardView;
		private DataView LeaveCardView;

		private DevExpress.Utils.Frames.NotePanel notePanel1;
		private DevExpress.Utils.Frames.NotePanel notePanel4;
		private DevExpress.Utils.Frames.NotePanel notePanel5;
		private DevExpress.XtraEditors.TextEdit textEdit_SendCardStuNumber;
		private DevExpress.XtraEditors.TextEdit textEdit_SendCardStuName;

		private GetStuInfoByCondition getStuInfoByCondition;
		private string getGradeNumberFromCombo = "0";
		//		private string getClassNumberFromCombo = "0";
		private DevExpress.XtraEditors.ComboBoxEdit combo_SendCardGrade;
		private DevExpress.XtraEditors.ComboBoxEdit combo_SendCardClass;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_TeaName;
		private DevExpress.Utils.Frames.NotePanel notePanel19;
		private DevExpress.Utils.Frames.NotePanel notePanel20;
		private DevExpress.XtraEditors.TextEdit textEdit_Send_TeaName;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_TeaNumber;
		private DevExpress.XtraEditors.TextEdit textEdit_Send_TeaNumber;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Send_TeaGrade;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Send_TeaClass;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;

		private bool searchStu = true;
		private bool batchSearchStu = true;
		private bool leaveSearchStu = true;

		private Login LoginForm;
		private System.Timers.Timer Timer_SendCardOverTime;
		private DevExpress.XtraEditors.DateEdit SendCard1Date;
		private DevExpress.XtraEditors.TextEdit SendCard1Holder;
		private DevExpress.XtraEditors.TextEdit SendCard1Number;
		private DevExpress.XtraEditors.TextEdit SendCard2Number;
		private DevExpress.XtraEditors.DateEdit SendCard2Date;
		private DevExpress.XtraEditors.DateEdit SendCard3Date;
		private DevExpress.XtraEditors.TextEdit SendCard3Number;
		private DevExpress.XtraEditors.DateEdit SendCard4Date;
		private DevExpress.XtraEditors.TextEdit SendCard4Number;
		private DevExpress.XtraEditors.TextEdit SendCard5Number;
		private DevExpress.XtraEditors.DateEdit SendCard5Date;
		private DevExpress.XtraEditors.CheckEdit removeCard1;
		private DevExpress.XtraEditors.CheckEdit removeCard2;
		private DevExpress.XtraEditors.CheckEdit removeCard3;
		private DevExpress.XtraEditors.CheckEdit removeCard4;
		private DevExpress.XtraEditors.CheckEdit removeCard5;
		private DevExpress.XtraEditors.GroupControl groupControl1;

		private int reTryTime = 0;
		private DevExpress.XtraEditors.TextEdit SendCard2Holder;
		private DevExpress.XtraEditors.TextEdit SendCard3Holder;
		private DevExpress.XtraEditors.TextEdit SendCard4Holder;
		private DevExpress.XtraEditors.TextEdit SendCard5Holder;
		private DataSet cardDetails;

		private bool isSendCard;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private bool isBatchSendCard;
		private DevExpress.XtraEditors.TextEdit textEdit1;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit2;
		private DevExpress.XtraEditors.TextEdit textEdit2;
		private DevExpress.Utils.Frames.NotePanel notePanel9;
		private DevExpress.Utils.Frames.NotePanel notePanel10;
		private DevExpress.Utils.Frames.NotePanel notePanel11;
		private DevExpress.Utils.Frames.NotePanel notePanel12;
		private DevExpress.XtraEditors.DataNavigator dataNavigator_CardLogout;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraEditors.TextEdit textEdit3;
		private System.Timers.Timer Timer_ValidateCardOverTime;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private System.Timers.Timer Timer_LeaveTime;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_ImportExcel;
		private DevExpress.Utils.Frames.NotePanel notePanel14;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit3;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Date;
		private System.Timers.Timer timer_SychnDate;
		private ArrayList cardsHasSend;
		private System.Windows.Forms.HelpProvider helpProvider_Help;
		private bool isTimeSynSucceed = true;
		private bool isCardSendSucceed = true;
		private bool isCardLogOutSucceed = true;
		private bool isLeaveSchoolSucceed = true;

		private const int myBirthday = 821012;
		private DevExpress.XtraEditors.SimpleButton simpleButton_LoadEncryFile;
		private System.Windows.Forms.OpenFileDialog openFileDialog_LoadEncryFile;
		private int cardTrace;

		private const char SPECIAL = '';

		private MessageForm msgForm = new MessageForm();
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card1stRemove;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card5thRemove;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card4thDate;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card5thDate;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card4thHolder;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card4thNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card1stDate;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card4thRemove;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card3rdRemove;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card5thNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card5thHolder;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card2ndNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card2ndHolder;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card2ndDate;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card2ndRemove;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card3rdNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card3rdHolder;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Card3rdDate;
		private System.Windows.Forms.Label lblMark1;
		private System.Windows.Forms.Label lblMark2;
		private System.Windows.Forms.Label lblMark3;
		private System.Windows.Forms.Label lblMark4;
		private System.Windows.Forms.Label lblMark5;

		public Login login;

        private SynchronizationContext current;

		public CardManagement()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			helpProvider_Help.HelpNamespace = Path.GetDirectoryName(Application.ExecutablePath)
				+ CPTT.SystemFramework.Util.HELP_FILE_NAME;

			getStuInfoByCondition = new GetStuInfoByCondition();

			dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = false;
			dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = false;

			Timer_SendCardOverTime.Interval = CPTT.SystemFramework.Util.SEND_CARD_TIMER_OVERTIME;
			Timer_ValidateCardOverTime.Interval = 10*1000;
			Timer_LeaveTime.Interval = 6000;
			timer_SychnDate.Interval = CPTT.SystemFramework.Util.SEND_CARD_TIMER_OVERTIME;

			cardsHasSend = new ArrayList();

			if(!Thread.CurrentPrincipal.IsInRole("Ô°³¤")
				&&!Thread.CurrentPrincipal.IsInRole("±£½¡")
				&&Thread.CurrentPrincipal.Identity.Name.ToLower()!="admin")
			{
				xtraTabPage_CardLogout.PageVisible = false;
				xtraTabPage_DataSynchAndReceive.PageVisible = false;
				simpleButton2.Visible = false;
				simpleButton_BatchSendStop.Visible = false;
				groupControl2.Visible = false;

				dataNavigator_CardSent.Buttons.EndEdit.Visible = false;
				dataNavigator_CardSent.Buttons.CustomButtons[0].Visible = false;
				dataNavigator_CardSent.Buttons.CustomButtons[1].Visible = false;
			}

			simpleButton_Send_StuCard_Click(null, null);
			simpleButton_BatchSendStuCard_Click(null, null);
			simpleButton_Logout_StuCard_Click(null, null);
			simpleButton_GetMobile_Click(null, null);

            current = SynchronizationContext.Current;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardManagement));
            this.xtraTabControl_CardMgmt = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage_CardSent = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl_Send_CardInfo = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Send_CardInfo = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl_Send_TeaCardMgmt = new DevExpress.XtraEditors.GroupControl();
            this.comboBoxEdit_Send_TeaGrade = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit_Send_TeaName = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_Send_TeaCardSerCond = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Send_TeaName = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Send_TeaNumber = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_Send_TeaNumber = new DevExpress.XtraEditors.TextEdit();
            this.notePanel19 = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel20 = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_Send_TeaClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl_Send_StuCardMgmt = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_Send_StuName = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEdit_Send_StuClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit_Send_StuGrade = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit_Send_StuNumber = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_Send_StuNumber = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Send_StuClass = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Send_StuGrade = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Send_StuCardSerCond = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Send_StuName = new DevExpress.Utils.Frames.NotePanel();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_LoadEncryFile = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Send_TeaCard = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Send_StuCard = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl_Send_MyCardRec = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblMark1 = new System.Windows.Forms.Label();
            this.notePanel_Send_Card1stRemove = new DevExpress.Utils.Frames.NotePanel();
            this.SendCard1Date = new DevExpress.XtraEditors.DateEdit();
            this.notePanel_Send_Card5thRemove = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Send_Card4thDate = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Send_Card5thDate = new DevExpress.Utils.Frames.NotePanel();
            this.SendCard4Holder = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_Send_Card1stHolder = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Send_Card1stNumber = new DevExpress.Utils.Frames.NotePanel();
            this.SendCard1Holder = new DevExpress.XtraEditors.TextEdit();
            this.SendCard1Number = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_Send_Card4thHolder = new DevExpress.Utils.Frames.NotePanel();
            this.SendCard4Number = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_Send_Card4thNumber = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Send_Card1stDate = new DevExpress.Utils.Frames.NotePanel();
            this.SendCard4Date = new DevExpress.XtraEditors.DateEdit();
            this.notePanel_Send_Card4thRemove = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Send_Card3rdRemove = new DevExpress.Utils.Frames.NotePanel();
            this.removeCard5 = new DevExpress.XtraEditors.CheckEdit();
            this.SendCard5Date = new DevExpress.XtraEditors.DateEdit();
            this.notePanel_Send_Card5thNumber = new DevExpress.Utils.Frames.NotePanel();
            this.SendCard5Number = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_Send_Card5thHolder = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Send_Card2ndNumber = new DevExpress.Utils.Frames.NotePanel();
            this.SendCard5Holder = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_Send_Card2ndHolder = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Send_Card2ndDate = new DevExpress.Utils.Frames.NotePanel();
            this.SendCard2Date = new DevExpress.XtraEditors.DateEdit();
            this.SendCard2Number = new DevExpress.XtraEditors.TextEdit();
            this.removeCard1 = new DevExpress.XtraEditors.CheckEdit();
            this.removeCard3 = new DevExpress.XtraEditors.CheckEdit();
            this.SendCard2Holder = new DevExpress.XtraEditors.TextEdit();
            this.removeCard2 = new DevExpress.XtraEditors.CheckEdit();
            this.notePanel_Send_Card2ndRemove = new DevExpress.Utils.Frames.NotePanel();
            this.removeCard4 = new DevExpress.XtraEditors.CheckEdit();
            this.SendCard3Date = new DevExpress.XtraEditors.DateEdit();
            this.notePanel_Send_Card3rdNumber = new DevExpress.Utils.Frames.NotePanel();
            this.SendCard3Number = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_Send_Card3rdHolder = new DevExpress.Utils.Frames.NotePanel();
            this.SendCard3Holder = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_Send_Card3rdDate = new DevExpress.Utils.Frames.NotePanel();
            this.lblMark2 = new System.Windows.Forms.Label();
            this.lblMark3 = new System.Windows.Forms.Label();
            this.lblMark4 = new System.Windows.Forms.Label();
            this.lblMark5 = new System.Windows.Forms.Label();
            this.combo_SendCardGrade = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dataNavigator_CardSent = new DevExpress.XtraEditors.DataNavigator();
            this.notePanel_Send_MyCardRec = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Send_Card1stMadeDate = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel1 = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel4 = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel5 = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_SendCardStuNumber = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_SendCardStuName = new DevExpress.XtraEditors.TextEdit();
            this.combo_SendCardClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.xtraTabPage_BatchSend = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl_BatchSendView = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_BatchSendView = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton_Logout_CardSearch = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_BatchSendCheck = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl_BatchSendSerCond = new DevExpress.XtraEditors.GroupControl();
            this.notePanel_BatchSendSerCond = new DevExpress.Utils.Frames.NotePanel();
            this.simpleButton_BatchSendStuCard = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_BatchSendTeaCard = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_BatchSendStop = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl_BatchSendButtonGroup = new DevExpress.XtraEditors.GroupControl();
            this.notePanel_BatchSendButtonGroup = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_BatchSendClass = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_BatchSendGrade = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_BatchSendGrade = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_BatchSendClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel14 = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit3 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.xtraTabPage_CardLogout = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.dataNavigator_CardLogout = new DevExpress.XtraEditors.DataNavigator();
            this.groupControl_Logout_TeaCardMgmt = new DevExpress.XtraEditors.GroupControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.notePanel9 = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel10 = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel11 = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel12 = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Logout_TeaCardSerCond = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl_Logout_StuCardMgmt = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_Logout_StuName = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEdit_Logout_StuClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit_Logout_StuGrade = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit_Logout_StuNumber = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_Logout_StuNumber = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Logout_StuClass = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Logout_StuGrade = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Logout_StuCardSerCond = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Logout_StuName = new DevExpress.Utils.Frames.NotePanel();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_Logout_StuCard = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Logout_TeaCard = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl_Logout_MyCardRec = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Logout_CardInfo = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage_IDQuery = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl_IDQueryFastSer = new DevExpress.XtraEditors.GroupControl();
            this.groupControl_IDQueryTeaNumberAndName = new DevExpress.XtraEditors.GroupControl();
            this.notePanel_IDQueryTeaName = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_IDQueryTeaName = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_IDQueryTeaNumber = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_IDQueryTeaNumber = new DevExpress.Utils.Frames.NotePanel();
            this.panelControl_TeaField = new DevExpress.XtraEditors.PanelControl();
            this.notePanel_IDQueryTeaTimeAndCardNumber = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_IDQueryTeaNumberAndName = new DevExpress.Utils.Frames.NotePanel();
            this.panelControl_StuField = new DevExpress.XtraEditors.PanelControl();
            this.notePanel_IDQueryNumberAndName = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_IDQueryTimeAndCardNumber = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_IDQueryGradeAndClass = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl_IDQueryTimeAndCardNumber = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_IDQueryCardNumber = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_IDQueryCardNumber = new DevExpress.Utils.Frames.NotePanel();
            this.dateEdit_IDQueryEndTime = new DevExpress.XtraEditors.DateEdit();
            this.notePanel_IDQueryBegTime = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_IDQueryEndTime = new DevExpress.Utils.Frames.NotePanel();
            this.dateEdit_IDQueryBegTime = new DevExpress.XtraEditors.DateEdit();
            this.groupControl_IDQueryNumberAndName = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_IDQueryStuName = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_IDQueryStuNumber = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_IDQueryStuNumber = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_IDQueryStuName = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl_IDQueryGradeAndClass = new DevExpress.XtraEditors.GroupControl();
            this.comboBoxEdit_IDQueryStuClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit_IDQueryStuGrade = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_IDQueryStuGrade = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_IDQueryStuClass = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel1_IDQueryFastSer = new DevExpress.Utils.Frames.NotePanel();
            this.gridControl_IDQueryView = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_IDQueryPrint = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_IDQueryStuCard = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_IDQueryTeaCard = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_IDQuerySearch = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage_DataSynchAndReceive = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl_DeviceView = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_DeviceView = new DevExpress.XtraGrid.GridControl();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl_DataSynchReceiDesk = new DevExpress.XtraEditors.GroupControl();
            this.notePanel_DataSynchReceiDesk = new DevExpress.Utils.Frames.NotePanel();
            this.simpleButton_Date = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_GetMobile = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_FastDataReceive = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_StopDataReceive = new DevExpress.XtraEditors.SimpleButton();
            this.Timer_SendCardOverTime = new System.Timers.Timer();
            this.Timer_ValidateCardOverTime = new System.Timers.Timer();
            this.Timer_LeaveTime = new System.Timers.Timer();
            this.saveFileDialog_ImportExcel = new System.Windows.Forms.SaveFileDialog();
            this.timer_SychnDate = new System.Timers.Timer();
            this.helpProvider_Help = new System.Windows.Forms.HelpProvider();
            this.openFileDialog_LoadEncryFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_CardMgmt)).BeginInit();
            this.xtraTabControl_CardMgmt.SuspendLayout();
            this.xtraTabPage_CardSent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Send_CardInfo)).BeginInit();
            this.groupControl_Send_CardInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Send_CardInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Send_TeaCardMgmt)).BeginInit();
            this.groupControl_Send_TeaCardMgmt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_TeaGrade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_TeaName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_TeaNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_TeaClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Send_StuCardMgmt)).BeginInit();
            this.groupControl_Send_StuCardMgmt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_StuName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_StuClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_StuGrade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_StuNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Send_MyCardRec)).BeginInit();
            this.groupControl_Send_MyCardRec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard1Date.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard1Date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard4Holder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard1Holder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard1Number.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard4Number.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard4Date.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard4Date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeCard5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard5Date.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard5Date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard5Number.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard5Holder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard2Date.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard2Date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard2Number.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeCard1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeCard3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard2Holder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeCard2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeCard4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard3Date.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard3Date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard3Number.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard3Holder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_SendCardGrade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_SendCardStuNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_SendCardStuName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_SendCardClass.Properties)).BeginInit();
            this.xtraTabPage_BatchSend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_BatchSendView)).BeginInit();
            this.groupControl_BatchSendView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BatchSendView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_BatchSendSerCond)).BeginInit();
            this.groupControl_BatchSendSerCond.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_BatchSendButtonGroup)).BeginInit();
            this.groupControl_BatchSendButtonGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_BatchSendGrade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_BatchSendClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit3.Properties)).BeginInit();
            this.xtraTabPage_CardLogout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Logout_TeaCardMgmt)).BeginInit();
            this.groupControl_Logout_TeaCardMgmt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Logout_StuCardMgmt)).BeginInit();
            this.groupControl_Logout_StuCardMgmt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Logout_StuName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Logout_StuClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Logout_StuGrade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Logout_StuNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Logout_MyCardRec)).BeginInit();
            this.groupControl_Logout_MyCardRec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Logout_CardInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.xtraTabPage_IDQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_IDQueryFastSer)).BeginInit();
            this.groupControl_IDQueryFastSer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_IDQueryTeaNumberAndName)).BeginInit();
            this.groupControl_IDQueryTeaNumberAndName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_IDQueryTeaName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_IDQueryTeaNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_TeaField)).BeginInit();
            this.panelControl_TeaField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_StuField)).BeginInit();
            this.panelControl_StuField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_IDQueryTimeAndCardNumber)).BeginInit();
            this.groupControl_IDQueryTimeAndCardNumber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_IDQueryCardNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_IDQueryEndTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_IDQueryEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_IDQueryBegTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_IDQueryBegTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_IDQueryNumberAndName)).BeginInit();
            this.groupControl_IDQueryNumberAndName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_IDQueryStuName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_IDQueryStuNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_IDQueryGradeAndClass)).BeginInit();
            this.groupControl_IDQueryGradeAndClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_IDQueryStuClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_IDQueryStuGrade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_IDQueryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.xtraTabPage_DataSynchAndReceive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_DeviceView)).BeginInit();
            this.groupControl_DeviceView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DeviceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_DataSynchReceiDesk)).BeginInit();
            this.groupControl_DataSynchReceiDesk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Timer_SendCardOverTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Timer_ValidateCardOverTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Timer_LeaveTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer_SychnDate)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl_CardMgmt
            // 
            this.xtraTabControl_CardMgmt.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DarkOrange;
            this.xtraTabControl_CardMgmt.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.xtraTabControl_CardMgmt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpProvider_Help.SetHelpKeyword(this.xtraTabControl_CardMgmt, "ÅúÁ¿·¢¿¨");
            this.helpProvider_Help.SetHelpNavigator(this.xtraTabControl_CardMgmt, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.xtraTabControl_CardMgmt.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl_CardMgmt.Name = "xtraTabControl_CardMgmt";
            this.xtraTabControl_CardMgmt.SelectedTabPage = this.xtraTabPage_CardSent;
            this.helpProvider_Help.SetShowHelp(this.xtraTabControl_CardMgmt, false);
            this.xtraTabControl_CardMgmt.Size = new System.Drawing.Size(772, 540);
            this.xtraTabControl_CardMgmt.TabIndex = 0;
            this.xtraTabControl_CardMgmt.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage_CardSent,
            this.xtraTabPage_BatchSend,
            this.xtraTabPage_CardLogout,
            this.xtraTabPage_IDQuery,
            this.xtraTabPage_DataSynchAndReceive});
            // 
            // xtraTabPage_CardSent
            // 
            this.xtraTabPage_CardSent.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_CardSent.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_CardSent.Controls.Add(this.splitContainerControl1);
            this.helpProvider_Help.SetHelpKeyword(this.xtraTabPage_CardSent, "ÖÆ¿¨ÓëÏú¿¨");
            this.helpProvider_Help.SetHelpNavigator(this.xtraTabPage_CardSent, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.xtraTabPage_CardSent.Name = "xtraTabPage_CardSent";
            this.helpProvider_Help.SetShowHelp(this.xtraTabPage_CardSent, true);
            this.xtraTabPage_CardSent.Size = new System.Drawing.Size(766, 511);
            this.xtraTabPage_CardSent.Text = "ÖÆ¿¨ÓëÏú¿¨";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl_Send_CardInfo);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl_Send_TeaCardMgmt);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl_Send_StuCardMgmt);
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl4);
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl_Send_MyCardRec);
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(766, 511);
            this.splitContainerControl1.SplitterPosition = 295;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl_Send_CardInfo
            // 
            this.groupControl_Send_CardInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_Send_CardInfo.AppearanceCaption.Options.UseFont = true;
            this.groupControl_Send_CardInfo.Controls.Add(this.gridControl_Send_CardInfo);
            this.groupControl_Send_CardInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl_Send_CardInfo.Location = new System.Drawing.Point(0, 272);
            this.groupControl_Send_CardInfo.Name = "groupControl_Send_CardInfo";
            this.groupControl_Send_CardInfo.Size = new System.Drawing.Size(295, 239);
            this.groupControl_Send_CardInfo.TabIndex = 20;
            this.groupControl_Send_CardInfo.Text = "³Ö¿¨ÐÅÏ¢";
            // 
            // gridControl_Send_CardInfo
            // 
            this.gridControl_Send_CardInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Send_CardInfo.Location = new System.Drawing.Point(2, 22);
            this.gridControl_Send_CardInfo.MainView = this.gridView1;
            this.gridControl_Send_CardInfo.Name = "gridControl_Send_CardInfo";
            this.gridControl_Send_CardInfo.Size = new System.Drawing.Size(291, 215);
            this.gridControl_Send_CardInfo.TabIndex = 0;
            this.gridControl_Send_CardInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView1.GridControl = this.gridControl_Send_CardInfo;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // groupControl_Send_TeaCardMgmt
            // 
            this.groupControl_Send_TeaCardMgmt.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_Send_TeaCardMgmt.AppearanceCaption.Options.UseFont = true;
            this.groupControl_Send_TeaCardMgmt.Controls.Add(this.comboBoxEdit_Send_TeaGrade);
            this.groupControl_Send_TeaCardMgmt.Controls.Add(this.textEdit_Send_TeaName);
            this.groupControl_Send_TeaCardMgmt.Controls.Add(this.notePanel_Send_TeaCardSerCond);
            this.groupControl_Send_TeaCardMgmt.Controls.Add(this.notePanel_Send_TeaName);
            this.groupControl_Send_TeaCardMgmt.Controls.Add(this.notePanel_Send_TeaNumber);
            this.groupControl_Send_TeaCardMgmt.Controls.Add(this.textEdit_Send_TeaNumber);
            this.groupControl_Send_TeaCardMgmt.Controls.Add(this.notePanel19);
            this.groupControl_Send_TeaCardMgmt.Controls.Add(this.notePanel20);
            this.groupControl_Send_TeaCardMgmt.Controls.Add(this.comboBoxEdit_Send_TeaClass);
            this.groupControl_Send_TeaCardMgmt.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl_Send_TeaCardMgmt.Location = new System.Drawing.Point(0, 160);
            this.groupControl_Send_TeaCardMgmt.Name = "groupControl_Send_TeaCardMgmt";
            this.groupControl_Send_TeaCardMgmt.Size = new System.Drawing.Size(295, 112);
            this.groupControl_Send_TeaCardMgmt.TabIndex = 19;
            this.groupControl_Send_TeaCardMgmt.Text = "½ÌÊ¦·¢¿¨¹ÜÀí";
            this.groupControl_Send_TeaCardMgmt.Visible = false;
            // 
            // comboBoxEdit_Send_TeaGrade
            // 
            this.comboBoxEdit_Send_TeaGrade.EditValue = "È«²¿";
            this.comboBoxEdit_Send_TeaGrade.Location = new System.Drawing.Point(216, 48);
            this.comboBoxEdit_Send_TeaGrade.Name = "comboBoxEdit_Send_TeaGrade";
            this.comboBoxEdit_Send_TeaGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_Send_TeaGrade.Properties.Items.AddRange(new object[] {
            "È«²¿"});
            this.comboBoxEdit_Send_TeaGrade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_Send_TeaGrade.Size = new System.Drawing.Size(64, 20);
            this.comboBoxEdit_Send_TeaGrade.TabIndex = 32;
            this.comboBoxEdit_Send_TeaGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Send_TeaGrade_SelectedIndexChanged);
            // 
            // textEdit_Send_TeaName
            // 
            this.textEdit_Send_TeaName.EditValue = "";
            this.textEdit_Send_TeaName.Location = new System.Drawing.Point(80, 48);
            this.textEdit_Send_TeaName.Name = "textEdit_Send_TeaName";
            this.textEdit_Send_TeaName.Size = new System.Drawing.Size(56, 20);
            this.textEdit_Send_TeaName.TabIndex = 31;
            this.textEdit_Send_TeaName.EditValueChanged += new System.EventHandler(this.textEdit_Send_TeaName_EditValueChanged);
            // 
            // notePanel_Send_TeaCardSerCond
            // 
            this.notePanel_Send_TeaCardSerCond.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel_Send_TeaCardSerCond.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel_Send_TeaCardSerCond.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel_Send_TeaCardSerCond.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_TeaCardSerCond.Location = new System.Drawing.Point(2, 22);
            this.notePanel_Send_TeaCardSerCond.MaxRows = 5;
            this.notePanel_Send_TeaCardSerCond.Name = "notePanel_Send_TeaCardSerCond";
            this.notePanel_Send_TeaCardSerCond.ParentAutoHeight = true;
            this.notePanel_Send_TeaCardSerCond.Size = new System.Drawing.Size(291, 23);
            this.notePanel_Send_TeaCardSerCond.TabIndex = 24;
            this.notePanel_Send_TeaCardSerCond.TabStop = false;
            this.notePanel_Send_TeaCardSerCond.Text = "ÄúÒª¼ìË÷µÄÌõ¼þ£¿";
            // 
            // notePanel_Send_TeaName
            // 
            this.notePanel_Send_TeaName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_TeaName.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_TeaName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_TeaName.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_TeaName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_TeaName.Location = new System.Drawing.Point(8, 48);
            this.notePanel_Send_TeaName.MaxRows = 5;
            this.notePanel_Send_TeaName.Name = "notePanel_Send_TeaName";
            this.notePanel_Send_TeaName.ParentAutoHeight = true;
            this.notePanel_Send_TeaName.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Send_TeaName.TabIndex = 30;
            this.notePanel_Send_TeaName.TabStop = false;
            this.notePanel_Send_TeaName.Text = "ÐÕ  Ãû:";
            // 
            // notePanel_Send_TeaNumber
            // 
            this.notePanel_Send_TeaNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_TeaNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_TeaNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_TeaNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_TeaNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_TeaNumber.Location = new System.Drawing.Point(8, 80);
            this.notePanel_Send_TeaNumber.MaxRows = 5;
            this.notePanel_Send_TeaNumber.Name = "notePanel_Send_TeaNumber";
            this.notePanel_Send_TeaNumber.ParentAutoHeight = true;
            this.notePanel_Send_TeaNumber.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Send_TeaNumber.TabIndex = 30;
            this.notePanel_Send_TeaNumber.TabStop = false;
            this.notePanel_Send_TeaNumber.Text = "¹¤  ºÅ:";
            // 
            // textEdit_Send_TeaNumber
            // 
            this.textEdit_Send_TeaNumber.EditValue = "";
            this.textEdit_Send_TeaNumber.Location = new System.Drawing.Point(80, 80);
            this.textEdit_Send_TeaNumber.Name = "textEdit_Send_TeaNumber";
            this.textEdit_Send_TeaNumber.Properties.Mask.EditMask = "d4";
            this.textEdit_Send_TeaNumber.Size = new System.Drawing.Size(56, 20);
            this.textEdit_Send_TeaNumber.TabIndex = 31;
            this.textEdit_Send_TeaNumber.EditValueChanged += new System.EventHandler(this.textEdit_Send_TeaNumber_EditValueChanged);
            // 
            // notePanel19
            // 
            this.notePanel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel19.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel19.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel19.ForeColor = System.Drawing.Color.Black;
            this.notePanel19.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel19.Location = new System.Drawing.Point(144, 48);
            this.notePanel19.MaxRows = 5;
            this.notePanel19.Name = "notePanel19";
            this.notePanel19.ParentAutoHeight = true;
            this.notePanel19.Size = new System.Drawing.Size(64, 22);
            this.notePanel19.TabIndex = 30;
            this.notePanel19.TabStop = false;
            this.notePanel19.Text = "²¿  ÃÅ:";
            // 
            // notePanel20
            // 
            this.notePanel20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel20.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel20.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel20.ForeColor = System.Drawing.Color.Black;
            this.notePanel20.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel20.Location = new System.Drawing.Point(144, 80);
            this.notePanel20.MaxRows = 5;
            this.notePanel20.Name = "notePanel20";
            this.notePanel20.ParentAutoHeight = true;
            this.notePanel20.Size = new System.Drawing.Size(64, 22);
            this.notePanel20.TabIndex = 30;
            this.notePanel20.TabStop = false;
            this.notePanel20.Text = "¸Ú  Î»:";
            // 
            // comboBoxEdit_Send_TeaClass
            // 
            this.comboBoxEdit_Send_TeaClass.EditValue = "È«²¿";
            this.comboBoxEdit_Send_TeaClass.Location = new System.Drawing.Point(216, 80);
            this.comboBoxEdit_Send_TeaClass.Name = "comboBoxEdit_Send_TeaClass";
            this.comboBoxEdit_Send_TeaClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_Send_TeaClass.Properties.Items.AddRange(new object[] {
            "È«²¿"});
            this.comboBoxEdit_Send_TeaClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_Send_TeaClass.Size = new System.Drawing.Size(64, 20);
            this.comboBoxEdit_Send_TeaClass.TabIndex = 32;
            this.comboBoxEdit_Send_TeaClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Send_TeaClass_SelectedIndexChanged);
            // 
            // groupControl_Send_StuCardMgmt
            // 
            this.groupControl_Send_StuCardMgmt.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_Send_StuCardMgmt.Appearance.Options.UseFont = true;
            this.groupControl_Send_StuCardMgmt.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_Send_StuCardMgmt.AppearanceCaption.Options.UseFont = true;
            this.groupControl_Send_StuCardMgmt.Controls.Add(this.textEdit_Send_StuName);
            this.groupControl_Send_StuCardMgmt.Controls.Add(this.comboBoxEdit_Send_StuClass);
            this.groupControl_Send_StuCardMgmt.Controls.Add(this.comboBoxEdit_Send_StuGrade);
            this.groupControl_Send_StuCardMgmt.Controls.Add(this.textEdit_Send_StuNumber);
            this.groupControl_Send_StuCardMgmt.Controls.Add(this.notePanel_Send_StuNumber);
            this.groupControl_Send_StuCardMgmt.Controls.Add(this.notePanel_Send_StuClass);
            this.groupControl_Send_StuCardMgmt.Controls.Add(this.notePanel_Send_StuGrade);
            this.groupControl_Send_StuCardMgmt.Controls.Add(this.notePanel_Send_StuCardSerCond);
            this.groupControl_Send_StuCardMgmt.Controls.Add(this.notePanel_Send_StuName);
            this.groupControl_Send_StuCardMgmt.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl_Send_StuCardMgmt.Location = new System.Drawing.Point(0, 40);
            this.groupControl_Send_StuCardMgmt.Name = "groupControl_Send_StuCardMgmt";
            this.groupControl_Send_StuCardMgmt.Size = new System.Drawing.Size(295, 120);
            this.groupControl_Send_StuCardMgmt.TabIndex = 18;
            this.groupControl_Send_StuCardMgmt.Text = "Ñ§Éú·¢¿¨¹ÜÀí";
            // 
            // textEdit_Send_StuName
            // 
            this.textEdit_Send_StuName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit_Send_StuName.EditValue = "";
            this.textEdit_Send_StuName.Location = new System.Drawing.Point(86, 48);
            this.textEdit_Send_StuName.Name = "textEdit_Send_StuName";
            this.textEdit_Send_StuName.Size = new System.Drawing.Size(56, 20);
            this.textEdit_Send_StuName.TabIndex = 32;
            this.textEdit_Send_StuName.EditValueChanged += new System.EventHandler(this.textEdit_Send_StuName_EditValueChanged);
            // 
            // comboBoxEdit_Send_StuClass
            // 
            this.comboBoxEdit_Send_StuClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEdit_Send_StuClass.EditValue = "È«²¿";
            this.comboBoxEdit_Send_StuClass.Location = new System.Drawing.Point(222, 80);
            this.comboBoxEdit_Send_StuClass.Name = "comboBoxEdit_Send_StuClass";
            this.comboBoxEdit_Send_StuClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_Send_StuClass.Properties.Items.AddRange(new object[] {
            "È«²¿"});
            this.comboBoxEdit_Send_StuClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_Send_StuClass.Size = new System.Drawing.Size(64, 20);
            this.comboBoxEdit_Send_StuClass.TabIndex = 31;
            this.comboBoxEdit_Send_StuClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Send_StuClass_SelectedIndexChanged);
            // 
            // comboBoxEdit_Send_StuGrade
            // 
            this.comboBoxEdit_Send_StuGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEdit_Send_StuGrade.EditValue = "È«²¿";
            this.comboBoxEdit_Send_StuGrade.Location = new System.Drawing.Point(222, 48);
            this.comboBoxEdit_Send_StuGrade.Name = "comboBoxEdit_Send_StuGrade";
            this.comboBoxEdit_Send_StuGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_Send_StuGrade.Properties.Items.AddRange(new object[] {
            "È«²¿"});
            this.comboBoxEdit_Send_StuGrade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_Send_StuGrade.Size = new System.Drawing.Size(64, 20);
            this.comboBoxEdit_Send_StuGrade.TabIndex = 30;
            this.comboBoxEdit_Send_StuGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Send_StuGrade_SelectedIndexChanged);
            // 
            // textEdit_Send_StuNumber
            // 
            this.textEdit_Send_StuNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit_Send_StuNumber.EditValue = "";
            this.textEdit_Send_StuNumber.Location = new System.Drawing.Point(86, 80);
            this.textEdit_Send_StuNumber.Name = "textEdit_Send_StuNumber";
            this.textEdit_Send_StuNumber.Size = new System.Drawing.Size(56, 20);
            this.textEdit_Send_StuNumber.TabIndex = 29;
            this.textEdit_Send_StuNumber.EditValueChanged += new System.EventHandler(this.textEdit_Send_StuNumber_EditValueChanged);
            // 
            // notePanel_Send_StuNumber
            // 
            this.notePanel_Send_StuNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notePanel_Send_StuNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_StuNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_StuNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_StuNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_StuNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_StuNumber.Location = new System.Drawing.Point(14, 80);
            this.notePanel_Send_StuNumber.MaxRows = 5;
            this.notePanel_Send_StuNumber.Name = "notePanel_Send_StuNumber";
            this.notePanel_Send_StuNumber.ParentAutoHeight = true;
            this.notePanel_Send_StuNumber.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Send_StuNumber.TabIndex = 27;
            this.notePanel_Send_StuNumber.TabStop = false;
            this.notePanel_Send_StuNumber.Text = "Ñ§  ºÅ:";
            // 
            // notePanel_Send_StuClass
            // 
            this.notePanel_Send_StuClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notePanel_Send_StuClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_StuClass.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_StuClass.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_StuClass.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_StuClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_StuClass.Location = new System.Drawing.Point(150, 80);
            this.notePanel_Send_StuClass.MaxRows = 5;
            this.notePanel_Send_StuClass.Name = "notePanel_Send_StuClass";
            this.notePanel_Send_StuClass.ParentAutoHeight = true;
            this.notePanel_Send_StuClass.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Send_StuClass.TabIndex = 26;
            this.notePanel_Send_StuClass.TabStop = false;
            this.notePanel_Send_StuClass.Text = "°à  ¼¶:";
            // 
            // notePanel_Send_StuGrade
            // 
            this.notePanel_Send_StuGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notePanel_Send_StuGrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_StuGrade.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_StuGrade.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_StuGrade.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_StuGrade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_StuGrade.Location = new System.Drawing.Point(150, 48);
            this.notePanel_Send_StuGrade.MaxRows = 5;
            this.notePanel_Send_StuGrade.Name = "notePanel_Send_StuGrade";
            this.notePanel_Send_StuGrade.ParentAutoHeight = true;
            this.notePanel_Send_StuGrade.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Send_StuGrade.TabIndex = 25;
            this.notePanel_Send_StuGrade.TabStop = false;
            this.notePanel_Send_StuGrade.Text = "Äê  ¼¶:";
            // 
            // notePanel_Send_StuCardSerCond
            // 
            this.notePanel_Send_StuCardSerCond.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel_Send_StuCardSerCond.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel_Send_StuCardSerCond.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel_Send_StuCardSerCond.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_StuCardSerCond.Location = new System.Drawing.Point(2, 22);
            this.notePanel_Send_StuCardSerCond.MaxRows = 5;
            this.notePanel_Send_StuCardSerCond.Name = "notePanel_Send_StuCardSerCond";
            this.notePanel_Send_StuCardSerCond.ParentAutoHeight = true;
            this.notePanel_Send_StuCardSerCond.Size = new System.Drawing.Size(291, 23);
            this.notePanel_Send_StuCardSerCond.TabIndex = 23;
            this.notePanel_Send_StuCardSerCond.TabStop = false;
            this.notePanel_Send_StuCardSerCond.Text = "ÄúÒª¼ìË÷µÄÌõ¼þ£¿";
            // 
            // notePanel_Send_StuName
            // 
            this.notePanel_Send_StuName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notePanel_Send_StuName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_StuName.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_StuName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_StuName.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_StuName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_StuName.Location = new System.Drawing.Point(14, 48);
            this.notePanel_Send_StuName.MaxRows = 5;
            this.notePanel_Send_StuName.Name = "notePanel_Send_StuName";
            this.notePanel_Send_StuName.ParentAutoHeight = true;
            this.notePanel_Send_StuName.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Send_StuName.TabIndex = 11;
            this.notePanel_Send_StuName.TabStop = false;
            this.notePanel_Send_StuName.Text = "ÐÕ  Ãû:";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.simpleButton_LoadEncryFile);
            this.panelControl4.Controls.Add(this.simpleButton_Send_TeaCard);
            this.panelControl4.Controls.Add(this.simpleButton_Send_StuCard);
            this.panelControl4.Controls.Add(this.simpleButton1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(295, 40);
            this.panelControl4.TabIndex = 8;
            // 
            // simpleButton_LoadEncryFile
            // 
            this.simpleButton_LoadEncryFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_LoadEncryFile.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_LoadEncryFile.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_LoadEncryFile.Appearance.Options.UseFont = true;
            this.simpleButton_LoadEncryFile.Appearance.Options.UseForeColor = true;
            this.simpleButton_LoadEncryFile.Location = new System.Drawing.Point(214, 8);
            this.simpleButton_LoadEncryFile.Name = "simpleButton_LoadEncryFile";
            this.simpleButton_LoadEncryFile.Size = new System.Drawing.Size(72, 26);
            this.simpleButton_LoadEncryFile.TabIndex = 7;
            this.simpleButton_LoadEncryFile.Tag = 4;
            this.simpleButton_LoadEncryFile.Text = "µ¼Èë¿¨ÎÄ¼þ";
            this.simpleButton_LoadEncryFile.Click += new System.EventHandler(this.simpleButton_LoadEncryFile_Click);
            // 
            // simpleButton_Send_TeaCard
            // 
            this.simpleButton_Send_TeaCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_Send_TeaCard.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_Send_TeaCard.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_Send_TeaCard.Appearance.Options.UseFont = true;
            this.simpleButton_Send_TeaCard.Appearance.Options.UseForeColor = true;
            this.simpleButton_Send_TeaCard.Location = new System.Drawing.Point(78, 8);
            this.simpleButton_Send_TeaCard.Name = "simpleButton_Send_TeaCard";
            this.simpleButton_Send_TeaCard.Size = new System.Drawing.Size(57, 26);
            this.simpleButton_Send_TeaCard.TabIndex = 6;
            this.simpleButton_Send_TeaCard.Tag = 4;
            this.simpleButton_Send_TeaCard.Text = "½ÌÊ¦¿¨";
            this.simpleButton_Send_TeaCard.Click += new System.EventHandler(this.simpleButton_Send_TeaCard_Click);
            // 
            // simpleButton_Send_StuCard
            // 
            this.simpleButton_Send_StuCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_Send_StuCard.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_Send_StuCard.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_Send_StuCard.Appearance.Options.UseFont = true;
            this.simpleButton_Send_StuCard.Appearance.Options.UseForeColor = true;
            this.simpleButton_Send_StuCard.Location = new System.Drawing.Point(14, 8);
            this.simpleButton_Send_StuCard.Name = "simpleButton_Send_StuCard";
            this.simpleButton_Send_StuCard.Size = new System.Drawing.Size(57, 26);
            this.simpleButton_Send_StuCard.TabIndex = 5;
            this.simpleButton_Send_StuCard.Tag = 4;
            this.simpleButton_Send_StuCard.Text = "Ñ§Éú¿¨";
            this.simpleButton_Send_StuCard.Click += new System.EventHandler(this.simpleButton_Send_StuCard_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(142, 8);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(64, 26);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Tag = 4;
            this.simpleButton1.Text = "µ¼³öExcel";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // groupControl_Send_MyCardRec
            // 
            this.groupControl_Send_MyCardRec.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_Send_MyCardRec.AppearanceCaption.Options.UseFont = true;
            this.groupControl_Send_MyCardRec.Controls.Add(this.groupControl1);
            this.groupControl_Send_MyCardRec.Controls.Add(this.combo_SendCardGrade);
            this.groupControl_Send_MyCardRec.Controls.Add(this.dataNavigator_CardSent);
            this.groupControl_Send_MyCardRec.Controls.Add(this.notePanel_Send_MyCardRec);
            this.groupControl_Send_MyCardRec.Controls.Add(this.notePanel_Send_Card1stMadeDate);
            this.groupControl_Send_MyCardRec.Controls.Add(this.notePanel1);
            this.groupControl_Send_MyCardRec.Controls.Add(this.notePanel4);
            this.groupControl_Send_MyCardRec.Controls.Add(this.notePanel5);
            this.groupControl_Send_MyCardRec.Controls.Add(this.textEdit_SendCardStuNumber);
            this.groupControl_Send_MyCardRec.Controls.Add(this.textEdit_SendCardStuName);
            this.groupControl_Send_MyCardRec.Controls.Add(this.combo_SendCardClass);
            this.groupControl_Send_MyCardRec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl_Send_MyCardRec.Location = new System.Drawing.Point(0, 0);
            this.groupControl_Send_MyCardRec.Name = "groupControl_Send_MyCardRec";
            this.groupControl_Send_MyCardRec.Size = new System.Drawing.Size(466, 511);
            this.groupControl_Send_MyCardRec.TabIndex = 26;
            this.groupControl_Send_MyCardRec.Text = "ÎÒµÄ¿¨¼ÇÂ¼";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblMark1);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card1stRemove);
            this.groupControl1.Controls.Add(this.SendCard1Date);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card5thRemove);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card4thDate);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card5thDate);
            this.groupControl1.Controls.Add(this.SendCard4Holder);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card1stHolder);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card1stNumber);
            this.groupControl1.Controls.Add(this.SendCard1Holder);
            this.groupControl1.Controls.Add(this.SendCard1Number);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card4thHolder);
            this.groupControl1.Controls.Add(this.SendCard4Number);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card4thNumber);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card1stDate);
            this.groupControl1.Controls.Add(this.SendCard4Date);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card4thRemove);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card3rdRemove);
            this.groupControl1.Controls.Add(this.removeCard5);
            this.groupControl1.Controls.Add(this.SendCard5Date);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card5thNumber);
            this.groupControl1.Controls.Add(this.SendCard5Number);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card5thHolder);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card2ndNumber);
            this.groupControl1.Controls.Add(this.SendCard5Holder);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card2ndHolder);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card2ndDate);
            this.groupControl1.Controls.Add(this.SendCard2Date);
            this.groupControl1.Controls.Add(this.SendCard2Number);
            this.groupControl1.Controls.Add(this.removeCard1);
            this.groupControl1.Controls.Add(this.removeCard3);
            this.groupControl1.Controls.Add(this.SendCard2Holder);
            this.groupControl1.Controls.Add(this.removeCard2);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card2ndRemove);
            this.groupControl1.Controls.Add(this.removeCard4);
            this.groupControl1.Controls.Add(this.SendCard3Date);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card3rdNumber);
            this.groupControl1.Controls.Add(this.SendCard3Number);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card3rdHolder);
            this.groupControl1.Controls.Add(this.SendCard3Holder);
            this.groupControl1.Controls.Add(this.notePanel_Send_Card3rdDate);
            this.groupControl1.Controls.Add(this.lblMark2);
            this.groupControl1.Controls.Add(this.lblMark3);
            this.groupControl1.Controls.Add(this.lblMark4);
            this.groupControl1.Controls.Add(this.lblMark5);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(2, 101);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(462, 368);
            this.groupControl1.TabIndex = 65;
            this.groupControl1.Text = "¿¨ÐÅÏ¢";
            // 
            // lblMark1
            // 
            this.lblMark1.BackColor = System.Drawing.Color.Transparent;
            this.lblMark1.ForeColor = System.Drawing.Color.Red;
            this.lblMark1.Location = new System.Drawing.Point(24, 32);
            this.lblMark1.Name = "lblMark1";
            this.lblMark1.Size = new System.Drawing.Size(8, 16);
            this.lblMark1.TabIndex = 80;
            this.lblMark1.Text = "*";
            // 
            // notePanel_Send_Card1stRemove
            // 
            this.notePanel_Send_Card1stRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card1stRemove.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card1stRemove.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card1stRemove.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card1stRemove.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card1stRemove.Location = new System.Drawing.Point(240, 60);
            this.notePanel_Send_Card1stRemove.MaxRows = 5;
            this.notePanel_Send_Card1stRemove.Name = "notePanel_Send_Card1stRemove";
            this.notePanel_Send_Card1stRemove.ParentAutoHeight = true;
            this.notePanel_Send_Card1stRemove.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card1stRemove.TabIndex = 28;
            this.notePanel_Send_Card1stRemove.TabStop = false;
            this.notePanel_Send_Card1stRemove.Text = "ÊÇ·ñÏú¿¨";
            // 
            // SendCard1Date
            // 
            this.SendCard1Date.EditValue = new System.DateTime(2005, 11, 2, 0, 0, 0, 0);
            this.SendCard1Date.Location = new System.Drawing.Point(120, 60);
            this.SendCard1Date.Name = "SendCard1Date";
            this.SendCard1Date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SendCard1Date.Properties.ReadOnly = true;
            this.SendCard1Date.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SendCard1Date.Size = new System.Drawing.Size(96, 20);
            this.SendCard1Date.TabIndex = 61;
            // 
            // notePanel_Send_Card5thRemove
            // 
            this.notePanel_Send_Card5thRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card5thRemove.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card5thRemove.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card5thRemove.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card5thRemove.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card5thRemove.Location = new System.Drawing.Point(240, 300);
            this.notePanel_Send_Card5thRemove.MaxRows = 5;
            this.notePanel_Send_Card5thRemove.Name = "notePanel_Send_Card5thRemove";
            this.notePanel_Send_Card5thRemove.ParentAutoHeight = true;
            this.notePanel_Send_Card5thRemove.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card5thRemove.TabIndex = 28;
            this.notePanel_Send_Card5thRemove.TabStop = false;
            this.notePanel_Send_Card5thRemove.Text = "ÊÇ·ñÏú¿¨";
            // 
            // notePanel_Send_Card4thDate
            // 
            this.notePanel_Send_Card4thDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card4thDate.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card4thDate.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card4thDate.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card4thDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card4thDate.Location = new System.Drawing.Point(40, 240);
            this.notePanel_Send_Card4thDate.MaxRows = 5;
            this.notePanel_Send_Card4thDate.Name = "notePanel_Send_Card4thDate";
            this.notePanel_Send_Card4thDate.ParentAutoHeight = true;
            this.notePanel_Send_Card4thDate.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card4thDate.TabIndex = 28;
            this.notePanel_Send_Card4thDate.TabStop = false;
            this.notePanel_Send_Card4thDate.Text = "·¢¿¨ÈÕÆÚ";
            // 
            // notePanel_Send_Card5thDate
            // 
            this.notePanel_Send_Card5thDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card5thDate.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card5thDate.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card5thDate.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card5thDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card5thDate.Location = new System.Drawing.Point(40, 300);
            this.notePanel_Send_Card5thDate.MaxRows = 5;
            this.notePanel_Send_Card5thDate.Name = "notePanel_Send_Card5thDate";
            this.notePanel_Send_Card5thDate.ParentAutoHeight = true;
            this.notePanel_Send_Card5thDate.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card5thDate.TabIndex = 28;
            this.notePanel_Send_Card5thDate.TabStop = false;
            this.notePanel_Send_Card5thDate.Text = "·¢¿¨ÈÕÆÚ";
            // 
            // SendCard4Holder
            // 
            this.SendCard4Holder.EditValue = "ËÄºÅ¿¨";
            this.SendCard4Holder.Location = new System.Drawing.Point(320, 210);
            this.SendCard4Holder.Name = "SendCard4Holder";
            this.SendCard4Holder.Size = new System.Drawing.Size(96, 20);
            this.SendCard4Holder.TabIndex = 27;
            // 
            // notePanel_Send_Card1stHolder
            // 
            this.notePanel_Send_Card1stHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card1stHolder.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card1stHolder.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card1stHolder.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card1stHolder.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card1stHolder.Location = new System.Drawing.Point(240, 30);
            this.notePanel_Send_Card1stHolder.MaxRows = 5;
            this.notePanel_Send_Card1stHolder.Name = "notePanel_Send_Card1stHolder";
            this.notePanel_Send_Card1stHolder.ParentAutoHeight = true;
            this.notePanel_Send_Card1stHolder.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card1stHolder.TabIndex = 28;
            this.notePanel_Send_Card1stHolder.TabStop = false;
            this.notePanel_Send_Card1stHolder.Text = "³Ö¿¨ÓÃ»§";
            // 
            // notePanel_Send_Card1stNumber
            // 
            this.notePanel_Send_Card1stNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card1stNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card1stNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card1stNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card1stNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card1stNumber.Location = new System.Drawing.Point(40, 30);
            this.notePanel_Send_Card1stNumber.MaxRows = 5;
            this.notePanel_Send_Card1stNumber.Name = "notePanel_Send_Card1stNumber";
            this.notePanel_Send_Card1stNumber.ParentAutoHeight = true;
            this.notePanel_Send_Card1stNumber.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card1stNumber.TabIndex = 14;
            this.notePanel_Send_Card1stNumber.TabStop = false;
            this.notePanel_Send_Card1stNumber.Text = "¿¨1ºÅÂë";
            // 
            // SendCard1Holder
            // 
            this.SendCard1Holder.EditValue = "Ò»ºÅ¿¨";
            this.SendCard1Holder.Location = new System.Drawing.Point(320, 30);
            this.SendCard1Holder.Name = "SendCard1Holder";
            this.SendCard1Holder.Size = new System.Drawing.Size(96, 20);
            this.SendCard1Holder.TabIndex = 27;
            // 
            // SendCard1Number
            // 
            this.SendCard1Number.EditValue = "";
            this.SendCard1Number.Location = new System.Drawing.Point(120, 30);
            this.SendCard1Number.Name = "SendCard1Number";
            this.SendCard1Number.Properties.Mask.SaveLiteral = false;
            this.SendCard1Number.Properties.Mask.ShowPlaceHolders = false;
            this.SendCard1Number.Size = new System.Drawing.Size(96, 20);
            this.SendCard1Number.TabIndex = 27;
            this.SendCard1Number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendCard1Number_KeyPress);
            // 
            // notePanel_Send_Card4thHolder
            // 
            this.notePanel_Send_Card4thHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card4thHolder.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card4thHolder.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card4thHolder.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card4thHolder.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card4thHolder.Location = new System.Drawing.Point(240, 210);
            this.notePanel_Send_Card4thHolder.MaxRows = 5;
            this.notePanel_Send_Card4thHolder.Name = "notePanel_Send_Card4thHolder";
            this.notePanel_Send_Card4thHolder.ParentAutoHeight = true;
            this.notePanel_Send_Card4thHolder.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card4thHolder.TabIndex = 28;
            this.notePanel_Send_Card4thHolder.TabStop = false;
            this.notePanel_Send_Card4thHolder.Text = "³Ö¿¨ÓÃ»§";
            // 
            // SendCard4Number
            // 
            this.SendCard4Number.EditValue = "";
            this.SendCard4Number.Location = new System.Drawing.Point(120, 210);
            this.SendCard4Number.Name = "SendCard4Number";
            this.SendCard4Number.Size = new System.Drawing.Size(96, 20);
            this.SendCard4Number.TabIndex = 27;
            this.SendCard4Number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendCard4Number_KeyPress);
            // 
            // notePanel_Send_Card4thNumber
            // 
            this.notePanel_Send_Card4thNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card4thNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card4thNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card4thNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card4thNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card4thNumber.Location = new System.Drawing.Point(40, 210);
            this.notePanel_Send_Card4thNumber.MaxRows = 5;
            this.notePanel_Send_Card4thNumber.Name = "notePanel_Send_Card4thNumber";
            this.notePanel_Send_Card4thNumber.ParentAutoHeight = true;
            this.notePanel_Send_Card4thNumber.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card4thNumber.TabIndex = 14;
            this.notePanel_Send_Card4thNumber.TabStop = false;
            this.notePanel_Send_Card4thNumber.Text = "¿¨4ºÅÂë";
            // 
            // notePanel_Send_Card1stDate
            // 
            this.notePanel_Send_Card1stDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card1stDate.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card1stDate.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card1stDate.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card1stDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card1stDate.Location = new System.Drawing.Point(40, 60);
            this.notePanel_Send_Card1stDate.MaxRows = 5;
            this.notePanel_Send_Card1stDate.Name = "notePanel_Send_Card1stDate";
            this.notePanel_Send_Card1stDate.ParentAutoHeight = true;
            this.notePanel_Send_Card1stDate.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card1stDate.TabIndex = 28;
            this.notePanel_Send_Card1stDate.TabStop = false;
            this.notePanel_Send_Card1stDate.Text = "·¢¿¨ÈÕÆÚ";
            // 
            // SendCard4Date
            // 
            this.SendCard4Date.EditValue = new System.DateTime(2005, 11, 2, 0, 0, 0, 0);
            this.SendCard4Date.Location = new System.Drawing.Point(120, 240);
            this.SendCard4Date.Name = "SendCard4Date";
            this.SendCard4Date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SendCard4Date.Properties.ReadOnly = true;
            this.SendCard4Date.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SendCard4Date.Size = new System.Drawing.Size(96, 20);
            this.SendCard4Date.TabIndex = 61;
            // 
            // notePanel_Send_Card4thRemove
            // 
            this.notePanel_Send_Card4thRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card4thRemove.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card4thRemove.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card4thRemove.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card4thRemove.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card4thRemove.Location = new System.Drawing.Point(240, 240);
            this.notePanel_Send_Card4thRemove.MaxRows = 5;
            this.notePanel_Send_Card4thRemove.Name = "notePanel_Send_Card4thRemove";
            this.notePanel_Send_Card4thRemove.ParentAutoHeight = true;
            this.notePanel_Send_Card4thRemove.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card4thRemove.TabIndex = 28;
            this.notePanel_Send_Card4thRemove.TabStop = false;
            this.notePanel_Send_Card4thRemove.Text = "ÊÇ·ñÏú¿¨";
            // 
            // notePanel_Send_Card3rdRemove
            // 
            this.notePanel_Send_Card3rdRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card3rdRemove.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card3rdRemove.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card3rdRemove.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card3rdRemove.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card3rdRemove.Location = new System.Drawing.Point(240, 180);
            this.notePanel_Send_Card3rdRemove.MaxRows = 5;
            this.notePanel_Send_Card3rdRemove.Name = "notePanel_Send_Card3rdRemove";
            this.notePanel_Send_Card3rdRemove.ParentAutoHeight = true;
            this.notePanel_Send_Card3rdRemove.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card3rdRemove.TabIndex = 28;
            this.notePanel_Send_Card3rdRemove.TabStop = false;
            this.notePanel_Send_Card3rdRemove.Text = "ÊÇ·ñÏú¿¨";
            // 
            // removeCard5
            // 
            this.removeCard5.Location = new System.Drawing.Point(320, 300);
            this.removeCard5.Name = "removeCard5";
            this.removeCard5.Properties.Caption = "×¢Ïú´Ë¿¨";
            this.removeCard5.Size = new System.Drawing.Size(75, 19);
            this.removeCard5.TabIndex = 64;
            // 
            // SendCard5Date
            // 
            this.SendCard5Date.EditValue = new System.DateTime(2005, 11, 2, 0, 0, 0, 0);
            this.SendCard5Date.Location = new System.Drawing.Point(120, 300);
            this.SendCard5Date.Name = "SendCard5Date";
            this.SendCard5Date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SendCard5Date.Properties.ReadOnly = true;
            this.SendCard5Date.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SendCard5Date.Size = new System.Drawing.Size(96, 20);
            this.SendCard5Date.TabIndex = 61;
            // 
            // notePanel_Send_Card5thNumber
            // 
            this.notePanel_Send_Card5thNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card5thNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card5thNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card5thNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card5thNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card5thNumber.Location = new System.Drawing.Point(40, 270);
            this.notePanel_Send_Card5thNumber.MaxRows = 5;
            this.notePanel_Send_Card5thNumber.Name = "notePanel_Send_Card5thNumber";
            this.notePanel_Send_Card5thNumber.ParentAutoHeight = true;
            this.notePanel_Send_Card5thNumber.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card5thNumber.TabIndex = 14;
            this.notePanel_Send_Card5thNumber.TabStop = false;
            this.notePanel_Send_Card5thNumber.Text = "¿¨5ºÅÂë";
            // 
            // SendCard5Number
            // 
            this.SendCard5Number.EditValue = "";
            this.SendCard5Number.Location = new System.Drawing.Point(120, 270);
            this.SendCard5Number.Name = "SendCard5Number";
            this.SendCard5Number.Size = new System.Drawing.Size(96, 20);
            this.SendCard5Number.TabIndex = 27;
            this.SendCard5Number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendCard5Number_KeyPress);
            // 
            // notePanel_Send_Card5thHolder
            // 
            this.notePanel_Send_Card5thHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card5thHolder.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card5thHolder.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card5thHolder.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card5thHolder.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card5thHolder.Location = new System.Drawing.Point(240, 270);
            this.notePanel_Send_Card5thHolder.MaxRows = 5;
            this.notePanel_Send_Card5thHolder.Name = "notePanel_Send_Card5thHolder";
            this.notePanel_Send_Card5thHolder.ParentAutoHeight = true;
            this.notePanel_Send_Card5thHolder.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card5thHolder.TabIndex = 28;
            this.notePanel_Send_Card5thHolder.TabStop = false;
            this.notePanel_Send_Card5thHolder.Text = "³Ö¿¨ÓÃ»§";
            // 
            // notePanel_Send_Card2ndNumber
            // 
            this.notePanel_Send_Card2ndNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card2ndNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card2ndNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card2ndNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card2ndNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card2ndNumber.Location = new System.Drawing.Point(40, 90);
            this.notePanel_Send_Card2ndNumber.MaxRows = 5;
            this.notePanel_Send_Card2ndNumber.Name = "notePanel_Send_Card2ndNumber";
            this.notePanel_Send_Card2ndNumber.ParentAutoHeight = true;
            this.notePanel_Send_Card2ndNumber.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card2ndNumber.TabIndex = 14;
            this.notePanel_Send_Card2ndNumber.TabStop = false;
            this.notePanel_Send_Card2ndNumber.Text = "¿¨2ºÅÂë";
            // 
            // SendCard5Holder
            // 
            this.SendCard5Holder.EditValue = "ÎåºÅ¿¨";
            this.SendCard5Holder.Location = new System.Drawing.Point(320, 270);
            this.SendCard5Holder.Name = "SendCard5Holder";
            this.SendCard5Holder.Size = new System.Drawing.Size(96, 20);
            this.SendCard5Holder.TabIndex = 27;
            // 
            // notePanel_Send_Card2ndHolder
            // 
            this.notePanel_Send_Card2ndHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card2ndHolder.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card2ndHolder.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card2ndHolder.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card2ndHolder.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card2ndHolder.Location = new System.Drawing.Point(240, 90);
            this.notePanel_Send_Card2ndHolder.MaxRows = 5;
            this.notePanel_Send_Card2ndHolder.Name = "notePanel_Send_Card2ndHolder";
            this.notePanel_Send_Card2ndHolder.ParentAutoHeight = true;
            this.notePanel_Send_Card2ndHolder.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card2ndHolder.TabIndex = 28;
            this.notePanel_Send_Card2ndHolder.TabStop = false;
            this.notePanel_Send_Card2ndHolder.Text = "³Ö¿¨ÓÃ»§";
            // 
            // notePanel_Send_Card2ndDate
            // 
            this.notePanel_Send_Card2ndDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card2ndDate.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card2ndDate.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card2ndDate.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card2ndDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card2ndDate.Location = new System.Drawing.Point(40, 120);
            this.notePanel_Send_Card2ndDate.MaxRows = 5;
            this.notePanel_Send_Card2ndDate.Name = "notePanel_Send_Card2ndDate";
            this.notePanel_Send_Card2ndDate.ParentAutoHeight = true;
            this.notePanel_Send_Card2ndDate.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card2ndDate.TabIndex = 28;
            this.notePanel_Send_Card2ndDate.TabStop = false;
            this.notePanel_Send_Card2ndDate.Text = "·¢¿¨ÈÕÆÚ";
            // 
            // SendCard2Date
            // 
            this.SendCard2Date.EditValue = new System.DateTime(2005, 11, 2, 0, 0, 0, 0);
            this.SendCard2Date.Location = new System.Drawing.Point(120, 120);
            this.SendCard2Date.Name = "SendCard2Date";
            this.SendCard2Date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SendCard2Date.Properties.ReadOnly = true;
            this.SendCard2Date.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SendCard2Date.Size = new System.Drawing.Size(96, 20);
            this.SendCard2Date.TabIndex = 61;
            // 
            // SendCard2Number
            // 
            this.SendCard2Number.EditValue = "";
            this.SendCard2Number.Location = new System.Drawing.Point(120, 90);
            this.SendCard2Number.Name = "SendCard2Number";
            this.SendCard2Number.Size = new System.Drawing.Size(96, 20);
            this.SendCard2Number.TabIndex = 27;
            this.SendCard2Number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendCard2Number_KeyPress);
            // 
            // removeCard1
            // 
            this.removeCard1.Location = new System.Drawing.Point(320, 60);
            this.removeCard1.Name = "removeCard1";
            this.removeCard1.Properties.Caption = "×¢Ïú´Ë¿¨";
            this.removeCard1.Size = new System.Drawing.Size(75, 19);
            this.removeCard1.TabIndex = 64;
            // 
            // removeCard3
            // 
            this.removeCard3.Location = new System.Drawing.Point(320, 180);
            this.removeCard3.Name = "removeCard3";
            this.removeCard3.Properties.Caption = "×¢Ïú´Ë¿¨";
            this.removeCard3.Size = new System.Drawing.Size(75, 19);
            this.removeCard3.TabIndex = 64;
            // 
            // SendCard2Holder
            // 
            this.SendCard2Holder.EditValue = "¶þºÅ¿¨";
            this.SendCard2Holder.Location = new System.Drawing.Point(320, 90);
            this.SendCard2Holder.Name = "SendCard2Holder";
            this.SendCard2Holder.Size = new System.Drawing.Size(96, 20);
            this.SendCard2Holder.TabIndex = 27;
            // 
            // removeCard2
            // 
            this.removeCard2.Location = new System.Drawing.Point(320, 120);
            this.removeCard2.Name = "removeCard2";
            this.removeCard2.Properties.Caption = "×¢Ïú´Ë¿¨";
            this.removeCard2.Size = new System.Drawing.Size(75, 19);
            this.removeCard2.TabIndex = 64;
            // 
            // notePanel_Send_Card2ndRemove
            // 
            this.notePanel_Send_Card2ndRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card2ndRemove.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card2ndRemove.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card2ndRemove.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card2ndRemove.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card2ndRemove.Location = new System.Drawing.Point(240, 120);
            this.notePanel_Send_Card2ndRemove.MaxRows = 5;
            this.notePanel_Send_Card2ndRemove.Name = "notePanel_Send_Card2ndRemove";
            this.notePanel_Send_Card2ndRemove.ParentAutoHeight = true;
            this.notePanel_Send_Card2ndRemove.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card2ndRemove.TabIndex = 28;
            this.notePanel_Send_Card2ndRemove.TabStop = false;
            this.notePanel_Send_Card2ndRemove.Text = "ÊÇ·ñÏú¿¨";
            // 
            // removeCard4
            // 
            this.removeCard4.Location = new System.Drawing.Point(320, 240);
            this.removeCard4.Name = "removeCard4";
            this.removeCard4.Properties.Caption = "×¢Ïú´Ë¿¨";
            this.removeCard4.Size = new System.Drawing.Size(75, 19);
            this.removeCard4.TabIndex = 64;
            // 
            // SendCard3Date
            // 
            this.SendCard3Date.EditValue = new System.DateTime(2005, 11, 2, 0, 0, 0, 0);
            this.SendCard3Date.Location = new System.Drawing.Point(120, 180);
            this.SendCard3Date.Name = "SendCard3Date";
            this.SendCard3Date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SendCard3Date.Properties.ReadOnly = true;
            this.SendCard3Date.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SendCard3Date.Size = new System.Drawing.Size(96, 20);
            this.SendCard3Date.TabIndex = 61;
            // 
            // notePanel_Send_Card3rdNumber
            // 
            this.notePanel_Send_Card3rdNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card3rdNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card3rdNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card3rdNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card3rdNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card3rdNumber.Location = new System.Drawing.Point(40, 150);
            this.notePanel_Send_Card3rdNumber.MaxRows = 5;
            this.notePanel_Send_Card3rdNumber.Name = "notePanel_Send_Card3rdNumber";
            this.notePanel_Send_Card3rdNumber.ParentAutoHeight = true;
            this.notePanel_Send_Card3rdNumber.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card3rdNumber.TabIndex = 14;
            this.notePanel_Send_Card3rdNumber.TabStop = false;
            this.notePanel_Send_Card3rdNumber.Text = "¿¨3ºÅÂë";
            // 
            // SendCard3Number
            // 
            this.SendCard3Number.EditValue = "";
            this.SendCard3Number.Location = new System.Drawing.Point(120, 150);
            this.SendCard3Number.Name = "SendCard3Number";
            this.SendCard3Number.Size = new System.Drawing.Size(96, 20);
            this.SendCard3Number.TabIndex = 27;
            this.SendCard3Number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendCard3Number_KeyPress);
            // 
            // notePanel_Send_Card3rdHolder
            // 
            this.notePanel_Send_Card3rdHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card3rdHolder.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card3rdHolder.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card3rdHolder.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card3rdHolder.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card3rdHolder.Location = new System.Drawing.Point(240, 150);
            this.notePanel_Send_Card3rdHolder.MaxRows = 5;
            this.notePanel_Send_Card3rdHolder.Name = "notePanel_Send_Card3rdHolder";
            this.notePanel_Send_Card3rdHolder.ParentAutoHeight = true;
            this.notePanel_Send_Card3rdHolder.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card3rdHolder.TabIndex = 28;
            this.notePanel_Send_Card3rdHolder.TabStop = false;
            this.notePanel_Send_Card3rdHolder.Text = "³Ö¿¨ÓÃ»§";
            // 
            // SendCard3Holder
            // 
            this.SendCard3Holder.EditValue = "ÈýºÅ¿¨";
            this.SendCard3Holder.Location = new System.Drawing.Point(320, 150);
            this.SendCard3Holder.Name = "SendCard3Holder";
            this.SendCard3Holder.Size = new System.Drawing.Size(96, 20);
            this.SendCard3Holder.TabIndex = 27;
            // 
            // notePanel_Send_Card3rdDate
            // 
            this.notePanel_Send_Card3rdDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card3rdDate.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card3rdDate.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card3rdDate.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card3rdDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card3rdDate.Location = new System.Drawing.Point(40, 180);
            this.notePanel_Send_Card3rdDate.MaxRows = 5;
            this.notePanel_Send_Card3rdDate.Name = "notePanel_Send_Card3rdDate";
            this.notePanel_Send_Card3rdDate.ParentAutoHeight = true;
            this.notePanel_Send_Card3rdDate.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card3rdDate.TabIndex = 28;
            this.notePanel_Send_Card3rdDate.TabStop = false;
            this.notePanel_Send_Card3rdDate.Text = "·¢¿¨ÈÕÆÚ";
            // 
            // lblMark2
            // 
            this.lblMark2.BackColor = System.Drawing.Color.Transparent;
            this.lblMark2.ForeColor = System.Drawing.Color.Red;
            this.lblMark2.Location = new System.Drawing.Point(24, 96);
            this.lblMark2.Name = "lblMark2";
            this.lblMark2.Size = new System.Drawing.Size(8, 16);
            this.lblMark2.TabIndex = 80;
            this.lblMark2.Text = "*";
            // 
            // lblMark3
            // 
            this.lblMark3.BackColor = System.Drawing.Color.Transparent;
            this.lblMark3.ForeColor = System.Drawing.Color.Red;
            this.lblMark3.Location = new System.Drawing.Point(24, 152);
            this.lblMark3.Name = "lblMark3";
            this.lblMark3.Size = new System.Drawing.Size(8, 16);
            this.lblMark3.TabIndex = 80;
            this.lblMark3.Text = "*";
            // 
            // lblMark4
            // 
            this.lblMark4.BackColor = System.Drawing.Color.Transparent;
            this.lblMark4.ForeColor = System.Drawing.Color.Red;
            this.lblMark4.Location = new System.Drawing.Point(24, 216);
            this.lblMark4.Name = "lblMark4";
            this.lblMark4.Size = new System.Drawing.Size(8, 16);
            this.lblMark4.TabIndex = 80;
            this.lblMark4.Text = "*";
            // 
            // lblMark5
            // 
            this.lblMark5.BackColor = System.Drawing.Color.Transparent;
            this.lblMark5.ForeColor = System.Drawing.Color.Red;
            this.lblMark5.Location = new System.Drawing.Point(24, 272);
            this.lblMark5.Name = "lblMark5";
            this.lblMark5.Size = new System.Drawing.Size(8, 16);
            this.lblMark5.TabIndex = 80;
            this.lblMark5.Text = "*";
            // 
            // combo_SendCardGrade
            // 
            this.combo_SendCardGrade.EditValue = "È«²¿";
            this.combo_SendCardGrade.Location = new System.Drawing.Point(120, 104);
            this.combo_SendCardGrade.Name = "combo_SendCardGrade";
            this.combo_SendCardGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_SendCardGrade.Properties.Items.AddRange(new object[] {
            "È«²¿"});
            this.combo_SendCardGrade.Properties.ReadOnly = true;
            this.combo_SendCardGrade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.combo_SendCardGrade.Size = new System.Drawing.Size(96, 20);
            this.combo_SendCardGrade.TabIndex = 63;
            this.combo_SendCardGrade.SelectedIndexChanged += new System.EventHandler(this.combo_SendCardGrade_SelectedIndexChanged);
            // 
            // dataNavigator_CardSent
            // 
            this.dataNavigator_CardSent.Buttons.Append.Hint = "Ìí¼ÓÐÂ¿¨";
            this.dataNavigator_CardSent.Buttons.Append.Visible = false;
            this.dataNavigator_CardSent.Buttons.CancelEdit.Hint = "È¡Ïû±à¼­";
            this.dataNavigator_CardSent.Buttons.CancelEdit.Visible = false;
            this.dataNavigator_CardSent.Buttons.EnabledAutoRepeat = false;
            this.dataNavigator_CardSent.Buttons.EndEdit.Hint = "±£´æ¿¨ÐÅÏ¢";
            this.dataNavigator_CardSent.Buttons.First.Hint = "µÚÒ»Ìõ¼ÇÂ¼";
            this.dataNavigator_CardSent.Buttons.Last.Hint = "×îºóÒ»Ìõ¼ÇÂ¼";
            this.dataNavigator_CardSent.Buttons.Next.Hint = "ÏÂÒ»Ìõ¼ÇÂ¼";
            this.dataNavigator_CardSent.Buttons.NextPage.Hint = "ÏÂÒ»Ò³¼ÇÂ¼";
            this.dataNavigator_CardSent.Buttons.Prev.Hint = "Ç°Ò»Ìõ¼ÇÂ¼";
            this.dataNavigator_CardSent.Buttons.PrevPage.Hint = "Ç°Ò»Ò³¼ÇÂ¼";
            this.dataNavigator_CardSent.Buttons.Remove.Hint = "É¾³ý¿¨¼ÇÂ¼";
            this.dataNavigator_CardSent.Buttons.Remove.Visible = false;
            this.dataNavigator_CardSent.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 6, true, true, "·¢¿¨", "0"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 10, true, true, "Ïú¿¨", "1")});
            this.dataNavigator_CardSent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigator_CardSent.Location = new System.Drawing.Point(2, 469);
            this.dataNavigator_CardSent.Name = "dataNavigator_CardSent";
            this.dataNavigator_CardSent.ShowToolTips = true;
            this.dataNavigator_CardSent.Size = new System.Drawing.Size(462, 40);
            this.dataNavigator_CardSent.TabIndex = 57;
            this.dataNavigator_CardSent.Text = "dataNavigator1";
            this.dataNavigator_CardSent.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.End;
            this.dataNavigator_CardSent.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dataNavigator_CardSent_ButtonClick);
            // 
            // notePanel_Send_MyCardRec
            // 
            this.notePanel_Send_MyCardRec.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel_Send_MyCardRec.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel_Send_MyCardRec.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel_Send_MyCardRec.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_MyCardRec.Location = new System.Drawing.Point(2, 22);
            this.notePanel_Send_MyCardRec.MaxRows = 5;
            this.notePanel_Send_MyCardRec.Name = "notePanel_Send_MyCardRec";
            this.notePanel_Send_MyCardRec.ParentAutoHeight = true;
            this.notePanel_Send_MyCardRec.Size = new System.Drawing.Size(462, 23);
            this.notePanel_Send_MyCardRec.TabIndex = 56;
            this.notePanel_Send_MyCardRec.TabStop = false;
            this.notePanel_Send_MyCardRec.Text = "¿¨ÐÅÏ¢¹ÜÀí";
            // 
            // notePanel_Send_Card1stMadeDate
            // 
            this.notePanel_Send_Card1stMadeDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Send_Card1stMadeDate.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Send_Card1stMadeDate.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Send_Card1stMadeDate.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Send_Card1stMadeDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_Card1stMadeDate.Location = new System.Drawing.Point(40, 72);
            this.notePanel_Send_Card1stMadeDate.MaxRows = 5;
            this.notePanel_Send_Card1stMadeDate.Name = "notePanel_Send_Card1stMadeDate";
            this.notePanel_Send_Card1stMadeDate.ParentAutoHeight = true;
            this.notePanel_Send_Card1stMadeDate.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Send_Card1stMadeDate.TabIndex = 30;
            this.notePanel_Send_Card1stMadeDate.TabStop = false;
            this.notePanel_Send_Card1stMadeDate.Text = " ÐÕ  Ãû:";
            // 
            // notePanel1
            // 
            this.notePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel1.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel1.ForeColor = System.Drawing.Color.Black;
            this.notePanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel1.Location = new System.Drawing.Point(40, 104);
            this.notePanel1.MaxRows = 5;
            this.notePanel1.Name = "notePanel1";
            this.notePanel1.ParentAutoHeight = true;
            this.notePanel1.Size = new System.Drawing.Size(72, 22);
            this.notePanel1.TabIndex = 30;
            this.notePanel1.TabStop = false;
            this.notePanel1.Text = " Äê  ¼¶:";
            // 
            // notePanel4
            // 
            this.notePanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel4.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel4.ForeColor = System.Drawing.Color.Black;
            this.notePanel4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel4.Location = new System.Drawing.Point(240, 72);
            this.notePanel4.MaxRows = 5;
            this.notePanel4.Name = "notePanel4";
            this.notePanel4.ParentAutoHeight = true;
            this.notePanel4.Size = new System.Drawing.Size(72, 22);
            this.notePanel4.TabIndex = 30;
            this.notePanel4.TabStop = false;
            this.notePanel4.Text = " Ñ§  ºÅ:";
            // 
            // notePanel5
            // 
            this.notePanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel5.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel5.ForeColor = System.Drawing.Color.Black;
            this.notePanel5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel5.Location = new System.Drawing.Point(240, 104);
            this.notePanel5.MaxRows = 5;
            this.notePanel5.Name = "notePanel5";
            this.notePanel5.ParentAutoHeight = true;
            this.notePanel5.Size = new System.Drawing.Size(72, 22);
            this.notePanel5.TabIndex = 30;
            this.notePanel5.TabStop = false;
            this.notePanel5.Text = " °à  ¼¶:";
            // 
            // textEdit_SendCardStuNumber
            // 
            this.textEdit_SendCardStuNumber.EditValue = "";
            this.textEdit_SendCardStuNumber.Location = new System.Drawing.Point(320, 72);
            this.textEdit_SendCardStuNumber.Name = "textEdit_SendCardStuNumber";
            this.textEdit_SendCardStuNumber.Properties.Mask.EditMask = "d4";
            this.textEdit_SendCardStuNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit_SendCardStuNumber.Properties.ReadOnly = true;
            this.textEdit_SendCardStuNumber.Size = new System.Drawing.Size(96, 20);
            this.textEdit_SendCardStuNumber.TabIndex = 27;
            // 
            // textEdit_SendCardStuName
            // 
            this.textEdit_SendCardStuName.EditValue = "";
            this.textEdit_SendCardStuName.Location = new System.Drawing.Point(120, 72);
            this.textEdit_SendCardStuName.Name = "textEdit_SendCardStuName";
            this.textEdit_SendCardStuName.Properties.ReadOnly = true;
            this.textEdit_SendCardStuName.Size = new System.Drawing.Size(96, 20);
            this.textEdit_SendCardStuName.TabIndex = 27;
            // 
            // combo_SendCardClass
            // 
            this.combo_SendCardClass.EditValue = "È«²¿";
            this.combo_SendCardClass.Location = new System.Drawing.Point(320, 104);
            this.combo_SendCardClass.Name = "combo_SendCardClass";
            this.combo_SendCardClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_SendCardClass.Properties.Items.AddRange(new object[] {
            "È«²¿"});
            this.combo_SendCardClass.Properties.ReadOnly = true;
            this.combo_SendCardClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.combo_SendCardClass.Size = new System.Drawing.Size(96, 20);
            this.combo_SendCardClass.TabIndex = 63;
            // 
            // xtraTabPage_BatchSend
            // 
            this.xtraTabPage_BatchSend.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_BatchSend.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_BatchSend.Controls.Add(this.groupControl_BatchSendView);
            this.xtraTabPage_BatchSend.Controls.Add(this.panelControl1);
            this.helpProvider_Help.SetHelpKeyword(this.xtraTabPage_BatchSend, "ÅúÁ¿·¢¿¨");
            this.helpProvider_Help.SetHelpNavigator(this.xtraTabPage_BatchSend, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.xtraTabPage_BatchSend.Name = "xtraTabPage_BatchSend";
            this.helpProvider_Help.SetShowHelp(this.xtraTabPage_BatchSend, true);
            this.xtraTabPage_BatchSend.Size = new System.Drawing.Size(766, 511);
            this.xtraTabPage_BatchSend.Text = "ÅúÁ¿·¢¿¨";
            // 
            // groupControl_BatchSendView
            // 
            this.groupControl_BatchSendView.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_BatchSendView.AppearanceCaption.Options.UseFont = true;
            this.groupControl_BatchSendView.Controls.Add(this.gridControl_BatchSendView);
            this.groupControl_BatchSendView.Controls.Add(this.simpleButton_Logout_CardSearch);
            this.groupControl_BatchSendView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl_BatchSendView.Location = new System.Drawing.Point(176, 0);
            this.groupControl_BatchSendView.Name = "groupControl_BatchSendView";
            this.groupControl_BatchSendView.Size = new System.Drawing.Size(590, 511);
            this.groupControl_BatchSendView.TabIndex = 14;
            this.groupControl_BatchSendView.Text = "´ý·¢¿¨ä¯ÀÀ";
            // 
            // gridControl_BatchSendView
            // 
            this.gridControl_BatchSendView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_BatchSendView.Location = new System.Drawing.Point(2, 22);
            this.gridControl_BatchSendView.MainView = this.gridView3;
            this.gridControl_BatchSendView.Name = "gridControl_BatchSendView";
            this.gridControl_BatchSendView.Size = new System.Drawing.Size(586, 487);
            this.gridControl_BatchSendView.TabIndex = 0;
            this.gridControl_BatchSendView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.gridView3.GridControl = this.gridControl_BatchSendView;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsCustomization.AllowFilter = false;
            this.gridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView3.OptionsView.ShowFooter = true;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 5;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 6;
            // 
            // simpleButton_Logout_CardSearch
            // 
            this.simpleButton_Logout_CardSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_Logout_CardSearch.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_Logout_CardSearch.Appearance.Options.UseFont = true;
            this.simpleButton_Logout_CardSearch.Appearance.Options.UseForeColor = true;
            this.simpleButton_Logout_CardSearch.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_Logout_CardSearch.Image")));
            this.simpleButton_Logout_CardSearch.Location = new System.Drawing.Point(16, 24);
            this.simpleButton_Logout_CardSearch.Name = "simpleButton_Logout_CardSearch";
            this.simpleButton_Logout_CardSearch.Size = new System.Drawing.Size(88, 26);
            this.simpleButton_Logout_CardSearch.TabIndex = 9;
            this.simpleButton_Logout_CardSearch.Tag = 4;
            this.simpleButton_Logout_CardSearch.Text = "²é  Ñ¯";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.panelControl1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.groupControl_BatchSendSerCond);
            this.panelControl1.Controls.Add(this.groupControl_BatchSendButtonGroup);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(176, 511);
            this.panelControl1.TabIndex = 13;
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.textEdit3);
            this.groupControl2.Controls.Add(this.simpleButton_BatchSendCheck);
            this.groupControl2.Location = new System.Drawing.Point(3, 408);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(170, 100);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "¿¨¼ìÑé";
            // 
            // textEdit3
            // 
            this.textEdit3.EditValue = "";
            this.textEdit3.Location = new System.Drawing.Point(28, 32);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new System.Drawing.Size(114, 20);
            this.textEdit3.TabIndex = 10;
            // 
            // simpleButton_BatchSendCheck
            // 
            this.simpleButton_BatchSendCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_BatchSendCheck.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_BatchSendCheck.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_BatchSendCheck.Appearance.Options.UseFont = true;
            this.simpleButton_BatchSendCheck.Appearance.Options.UseForeColor = true;
            this.simpleButton_BatchSendCheck.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_BatchSendCheck.Image")));
            this.simpleButton_BatchSendCheck.Location = new System.Drawing.Point(28, 64);
            this.simpleButton_BatchSendCheck.Name = "simpleButton_BatchSendCheck";
            this.simpleButton_BatchSendCheck.Size = new System.Drawing.Size(114, 26);
            this.simpleButton_BatchSendCheck.TabIndex = 9;
            this.simpleButton_BatchSendCheck.Tag = 4;
            this.simpleButton_BatchSendCheck.Text = "Ð£   Ñé";
            this.simpleButton_BatchSendCheck.Click += new System.EventHandler(this.simpleButton_BatchSendCheck_Click);
            // 
            // groupControl_BatchSendSerCond
            // 
            this.groupControl_BatchSendSerCond.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl_BatchSendSerCond.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_BatchSendSerCond.Appearance.Options.UseBackColor = true;
            this.groupControl_BatchSendSerCond.Appearance.Options.UseFont = true;
            this.groupControl_BatchSendSerCond.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_BatchSendSerCond.AppearanceCaption.Options.UseFont = true;
            this.groupControl_BatchSendSerCond.Controls.Add(this.notePanel_BatchSendSerCond);
            this.groupControl_BatchSendSerCond.Controls.Add(this.simpleButton_BatchSendStuCard);
            this.groupControl_BatchSendSerCond.Controls.Add(this.simpleButton_BatchSendTeaCard);
            this.groupControl_BatchSendSerCond.Controls.Add(this.simpleButton_BatchSendStop);
            this.groupControl_BatchSendSerCond.Controls.Add(this.simpleButton2);
            this.groupControl_BatchSendSerCond.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl_BatchSendSerCond.Location = new System.Drawing.Point(2, 2);
            this.groupControl_BatchSendSerCond.Name = "groupControl_BatchSendSerCond";
            this.groupControl_BatchSendSerCond.Size = new System.Drawing.Size(172, 221);
            this.groupControl_BatchSendSerCond.TabIndex = 1;
            this.groupControl_BatchSendSerCond.Text = "ÅúÁ¿·¢¿¨²Ù×÷Ì¨";
            // 
            // notePanel_BatchSendSerCond
            // 
            this.notePanel_BatchSendSerCond.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel_BatchSendSerCond.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel_BatchSendSerCond.ForeColor = System.Drawing.Color.Gray;
            this.notePanel_BatchSendSerCond.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BatchSendSerCond.Location = new System.Drawing.Point(2, 22);
            this.notePanel_BatchSendSerCond.MaxRows = 5;
            this.notePanel_BatchSendSerCond.Name = "notePanel_BatchSendSerCond";
            this.notePanel_BatchSendSerCond.ParentAutoHeight = true;
            this.notePanel_BatchSendSerCond.Size = new System.Drawing.Size(168, 23);
            this.notePanel_BatchSendSerCond.TabIndex = 25;
            this.notePanel_BatchSendSerCond.TabStop = false;
            this.notePanel_BatchSendSerCond.Text = "ÄúÒªÍê³ÉÊ²Ã´£¿";
            // 
            // simpleButton_BatchSendStuCard
            // 
            this.simpleButton_BatchSendStuCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_BatchSendStuCard.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_BatchSendStuCard.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_BatchSendStuCard.Appearance.Options.UseFont = true;
            this.simpleButton_BatchSendStuCard.Appearance.Options.UseForeColor = true;
            this.simpleButton_BatchSendStuCard.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_BatchSendStuCard.Image")));
            this.simpleButton_BatchSendStuCard.Location = new System.Drawing.Point(28, 57);
            this.simpleButton_BatchSendStuCard.Name = "simpleButton_BatchSendStuCard";
            this.simpleButton_BatchSendStuCard.Size = new System.Drawing.Size(116, 26);
            this.simpleButton_BatchSendStuCard.TabIndex = 7;
            this.simpleButton_BatchSendStuCard.Tag = 4;
            this.simpleButton_BatchSendStuCard.Text = "Ñ§Éú¿¨";
            this.simpleButton_BatchSendStuCard.Click += new System.EventHandler(this.simpleButton_BatchSendStuCard_Click);
            // 
            // simpleButton_BatchSendTeaCard
            // 
            this.simpleButton_BatchSendTeaCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_BatchSendTeaCard.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_BatchSendTeaCard.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_BatchSendTeaCard.Appearance.Options.UseFont = true;
            this.simpleButton_BatchSendTeaCard.Appearance.Options.UseForeColor = true;
            this.simpleButton_BatchSendTeaCard.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_BatchSendTeaCard.Image")));
            this.simpleButton_BatchSendTeaCard.Location = new System.Drawing.Point(28, 89);
            this.simpleButton_BatchSendTeaCard.Name = "simpleButton_BatchSendTeaCard";
            this.simpleButton_BatchSendTeaCard.Size = new System.Drawing.Size(116, 26);
            this.simpleButton_BatchSendTeaCard.TabIndex = 8;
            this.simpleButton_BatchSendTeaCard.Tag = 4;
            this.simpleButton_BatchSendTeaCard.Text = "½ÌÊ¦¿¨";
            this.simpleButton_BatchSendTeaCard.Click += new System.EventHandler(this.simpleButton_BatchSendTeaCard_Click);
            // 
            // simpleButton_BatchSendStop
            // 
            this.simpleButton_BatchSendStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_BatchSendStop.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_BatchSendStop.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_BatchSendStop.Appearance.Options.UseFont = true;
            this.simpleButton_BatchSendStop.Appearance.Options.UseForeColor = true;
            this.simpleButton_BatchSendStop.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_BatchSendStop.Image")));
            this.simpleButton_BatchSendStop.Location = new System.Drawing.Point(28, 176);
            this.simpleButton_BatchSendStop.Name = "simpleButton_BatchSendStop";
            this.simpleButton_BatchSendStop.Size = new System.Drawing.Size(116, 26);
            this.simpleButton_BatchSendStop.TabIndex = 11;
            this.simpleButton_BatchSendStop.Tag = 4;
            this.simpleButton_BatchSendStop.Text = "ÔÝ   Í£";
            this.simpleButton_BatchSendStop.Click += new System.EventHandler(this.simpleButton_BatchSendStop_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(28, 144);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(116, 26);
            this.simpleButton2.TabIndex = 10;
            this.simpleButton2.Tag = 4;
            this.simpleButton2.Text = "·¢   ¿¨";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // groupControl_BatchSendButtonGroup
            // 
            this.groupControl_BatchSendButtonGroup.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl_BatchSendButtonGroup.Appearance.Options.UseBackColor = true;
            this.groupControl_BatchSendButtonGroup.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_BatchSendButtonGroup.AppearanceCaption.Options.UseFont = true;
            this.groupControl_BatchSendButtonGroup.Controls.Add(this.notePanel_BatchSendButtonGroup);
            this.groupControl_BatchSendButtonGroup.Controls.Add(this.notePanel_BatchSendClass);
            this.groupControl_BatchSendButtonGroup.Controls.Add(this.comboBoxEdit_BatchSendGrade);
            this.groupControl_BatchSendButtonGroup.Controls.Add(this.notePanel_BatchSendGrade);
            this.groupControl_BatchSendButtonGroup.Controls.Add(this.comboBoxEdit_BatchSendClass);
            this.groupControl_BatchSendButtonGroup.Controls.Add(this.notePanel14);
            this.groupControl_BatchSendButtonGroup.Controls.Add(this.comboBoxEdit3);
            this.groupControl_BatchSendButtonGroup.Location = new System.Drawing.Point(3, 232);
            this.groupControl_BatchSendButtonGroup.Name = "groupControl_BatchSendButtonGroup";
            this.groupControl_BatchSendButtonGroup.Size = new System.Drawing.Size(170, 176);
            this.groupControl_BatchSendButtonGroup.TabIndex = 2;
            this.groupControl_BatchSendButtonGroup.Text = "Ö¸¶¨ËÑË÷µÄ¶ÔÏó";
            // 
            // notePanel_BatchSendButtonGroup
            // 
            this.notePanel_BatchSendButtonGroup.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel_BatchSendButtonGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel_BatchSendButtonGroup.ForeColor = System.Drawing.Color.Gray;
            this.notePanel_BatchSendButtonGroup.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BatchSendButtonGroup.Location = new System.Drawing.Point(2, 22);
            this.notePanel_BatchSendButtonGroup.MaxRows = 5;
            this.notePanel_BatchSendButtonGroup.Name = "notePanel_BatchSendButtonGroup";
            this.notePanel_BatchSendButtonGroup.ParentAutoHeight = true;
            this.notePanel_BatchSendButtonGroup.Size = new System.Drawing.Size(166, 23);
            this.notePanel_BatchSendButtonGroup.TabIndex = 24;
            this.notePanel_BatchSendButtonGroup.TabStop = false;
            this.notePanel_BatchSendButtonGroup.Text = "ÄúÒª¼ìË÷Ê²Ã´£¿";
            // 
            // notePanel_BatchSendClass
            // 
            this.notePanel_BatchSendClass.BackColor = System.Drawing.Color.LightGray;
            this.notePanel_BatchSendClass.BackColor2 = System.Drawing.Color.Gray;
            this.notePanel_BatchSendClass.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BatchSendClass.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BatchSendClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BatchSendClass.Location = new System.Drawing.Point(8, 96);
            this.notePanel_BatchSendClass.MaxRows = 5;
            this.notePanel_BatchSendClass.Name = "notePanel_BatchSendClass";
            this.notePanel_BatchSendClass.ParentAutoHeight = true;
            this.notePanel_BatchSendClass.Size = new System.Drawing.Size(64, 22);
            this.notePanel_BatchSendClass.TabIndex = 36;
            this.notePanel_BatchSendClass.TabStop = false;
            this.notePanel_BatchSendClass.Text = "°à  ¼¶:";
            // 
            // comboBoxEdit_BatchSendGrade
            // 
            this.comboBoxEdit_BatchSendGrade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEdit_BatchSendGrade.EditValue = "È«²¿";
            this.comboBoxEdit_BatchSendGrade.Location = new System.Drawing.Point(80, 56);
            this.comboBoxEdit_BatchSendGrade.Name = "comboBoxEdit_BatchSendGrade";
            this.comboBoxEdit_BatchSendGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_BatchSendGrade.Properties.Items.AddRange(new object[] {
            "È«²¿"});
            this.comboBoxEdit_BatchSendGrade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_BatchSendGrade.Size = new System.Drawing.Size(82, 23);
            this.comboBoxEdit_BatchSendGrade.TabIndex = 34;
            this.comboBoxEdit_BatchSendGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_BatchSendGrade_SelectedIndexChanged);
            // 
            // notePanel_BatchSendGrade
            // 
            this.notePanel_BatchSendGrade.BackColor = System.Drawing.Color.LightGray;
            this.notePanel_BatchSendGrade.BackColor2 = System.Drawing.Color.Gray;
            this.notePanel_BatchSendGrade.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BatchSendGrade.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BatchSendGrade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BatchSendGrade.Location = new System.Drawing.Point(8, 56);
            this.notePanel_BatchSendGrade.MaxRows = 5;
            this.notePanel_BatchSendGrade.Name = "notePanel_BatchSendGrade";
            this.notePanel_BatchSendGrade.ParentAutoHeight = true;
            this.notePanel_BatchSendGrade.Size = new System.Drawing.Size(64, 22);
            this.notePanel_BatchSendGrade.TabIndex = 35;
            this.notePanel_BatchSendGrade.TabStop = false;
            this.notePanel_BatchSendGrade.Text = "Äê  ¼¶:";
            // 
            // comboBoxEdit_BatchSendClass
            // 
            this.comboBoxEdit_BatchSendClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEdit_BatchSendClass.EditValue = "È«²¿";
            this.comboBoxEdit_BatchSendClass.Location = new System.Drawing.Point(80, 96);
            this.comboBoxEdit_BatchSendClass.Name = "comboBoxEdit_BatchSendClass";
            this.comboBoxEdit_BatchSendClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_BatchSendClass.Properties.Items.AddRange(new object[] {
            "È«²¿"});
            this.comboBoxEdit_BatchSendClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_BatchSendClass.Size = new System.Drawing.Size(82, 23);
            this.comboBoxEdit_BatchSendClass.TabIndex = 35;
            this.comboBoxEdit_BatchSendClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_BatchSendClass_SelectedIndexChanged);
            // 
            // notePanel14
            // 
            this.notePanel14.BackColor = System.Drawing.Color.LightGray;
            this.notePanel14.BackColor2 = System.Drawing.Color.Gray;
            this.notePanel14.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel14.ForeColor = System.Drawing.Color.Black;
            this.notePanel14.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel14.Location = new System.Drawing.Point(8, 136);
            this.notePanel14.MaxRows = 5;
            this.notePanel14.Name = "notePanel14";
            this.notePanel14.ParentAutoHeight = true;
            this.notePanel14.Size = new System.Drawing.Size(64, 22);
            this.notePanel14.TabIndex = 36;
            this.notePanel14.TabStop = false;
            this.notePanel14.Text = "¿¨×´Ì¬:";
            // 
            // comboBoxEdit3
            // 
            this.comboBoxEdit3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEdit3.EditValue = "È«²¿";
            this.comboBoxEdit3.Location = new System.Drawing.Point(80, 136);
            this.comboBoxEdit3.Name = "comboBoxEdit3";
            this.comboBoxEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit3.Properties.Items.AddRange(new object[] {
            "È«²¿",
            "´ý·¢¿¨",
            "ÒÑ·¢¿¨",
            "ÔÝÎÞ¿¨"});
            this.comboBoxEdit3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit3.Size = new System.Drawing.Size(82, 23);
            this.comboBoxEdit3.TabIndex = 35;
            this.comboBoxEdit3.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit3_SelectedIndexChanged);
            // 
            // xtraTabPage_CardLogout
            // 
            this.xtraTabPage_CardLogout.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_CardLogout.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_CardLogout.Controls.Add(this.splitContainerControl2);
            this.helpProvider_Help.SetHelpKeyword(this.xtraTabPage_CardLogout, "ÍËÑ§ÓëÀëÖ°");
            this.helpProvider_Help.SetHelpNavigator(this.xtraTabPage_CardLogout, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.helpProvider_Help.SetHelpString(this.xtraTabPage_CardLogout, "");
            this.xtraTabPage_CardLogout.Name = "xtraTabPage_CardLogout";
            this.helpProvider_Help.SetShowHelp(this.xtraTabPage_CardLogout, true);
            this.xtraTabPage_CardLogout.Size = new System.Drawing.Size(766, 511);
            this.xtraTabPage_CardLogout.Text = "ÍËÑ§ÓëÀëÖ°";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.dataNavigator_CardLogout);
            this.splitContainerControl2.Panel1.Controls.Add(this.groupControl_Logout_TeaCardMgmt);
            this.splitContainerControl2.Panel1.Controls.Add(this.groupControl_Logout_StuCardMgmt);
            this.splitContainerControl2.Panel1.Controls.Add(this.panelControl3);
            this.splitContainerControl2.Panel1.Text = "splitContainerControl2_Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.groupControl_Logout_MyCardRec);
            this.splitContainerControl2.Panel2.Text = "splitContainerControl2_Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(766, 511);
            this.splitContainerControl2.SplitterPosition = 319;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // dataNavigator_CardLogout
            // 
            this.dataNavigator_CardLogout.Buttons.Append.Visible = false;
            this.dataNavigator_CardLogout.Buttons.CancelEdit.Hint = "ÍËÑ§&ÀëÖ°";
            this.dataNavigator_CardLogout.Buttons.EndEdit.Visible = false;
            this.dataNavigator_CardLogout.Buttons.First.Hint = "µÚÒ»Ìõ¼ÇÂ¼";
            this.dataNavigator_CardLogout.Buttons.Last.Hint = "×îºóÒ»Ìõ¼ÇÂ¼";
            this.dataNavigator_CardLogout.Buttons.Next.Hint = "ÏÂÒ»Ìõ¼ÇÂ¼";
            this.dataNavigator_CardLogout.Buttons.NextPage.Hint = "ÏÂÒ»Ò³¼ÇÂ¼";
            this.dataNavigator_CardLogout.Buttons.Prev.Hint = "Ç°Ò»Ìõ¼ÇÂ¼";
            this.dataNavigator_CardLogout.Buttons.PrevPage.Hint = "ÉÏÒ»Ò³¼ÇÂ¼";
            this.dataNavigator_CardLogout.Buttons.Remove.Visible = false;
            this.dataNavigator_CardLogout.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataNavigator_CardLogout.Location = new System.Drawing.Point(0, 312);
            this.dataNavigator_CardLogout.Name = "dataNavigator_CardLogout";
            this.dataNavigator_CardLogout.ShowToolTips = true;
            this.dataNavigator_CardLogout.Size = new System.Drawing.Size(319, 40);
            this.dataNavigator_CardLogout.TabIndex = 63;
            this.dataNavigator_CardLogout.Text = "dataNavigator2";
            this.dataNavigator_CardLogout.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.End;
            this.dataNavigator_CardLogout.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dataNavigator_CardLogout_ButtonClick);
            // 
            // groupControl_Logout_TeaCardMgmt
            // 
            this.groupControl_Logout_TeaCardMgmt.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_Logout_TeaCardMgmt.AppearanceCaption.Options.UseFont = true;
            this.groupControl_Logout_TeaCardMgmt.Controls.Add(this.textEdit1);
            this.groupControl_Logout_TeaCardMgmt.Controls.Add(this.comboBoxEdit1);
            this.groupControl_Logout_TeaCardMgmt.Controls.Add(this.comboBoxEdit2);
            this.groupControl_Logout_TeaCardMgmt.Controls.Add(this.textEdit2);
            this.groupControl_Logout_TeaCardMgmt.Controls.Add(this.notePanel9);
            this.groupControl_Logout_TeaCardMgmt.Controls.Add(this.notePanel10);
            this.groupControl_Logout_TeaCardMgmt.Controls.Add(this.notePanel11);
            this.groupControl_Logout_TeaCardMgmt.Controls.Add(this.notePanel12);
            this.groupControl_Logout_TeaCardMgmt.Controls.Add(this.notePanel_Logout_TeaCardSerCond);
            this.groupControl_Logout_TeaCardMgmt.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl_Logout_TeaCardMgmt.Location = new System.Drawing.Point(0, 176);
            this.groupControl_Logout_TeaCardMgmt.Name = "groupControl_Logout_TeaCardMgmt";
            this.groupControl_Logout_TeaCardMgmt.Size = new System.Drawing.Size(319, 136);
            this.groupControl_Logout_TeaCardMgmt.TabIndex = 16;
            this.groupControl_Logout_TeaCardMgmt.Text = "½ÌÊ¦ÀëÖ°¹ÜÀí";
            this.groupControl_Logout_TeaCardMgmt.Visible = false;
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "";
            this.textEdit1.Location = new System.Drawing.Point(80, 64);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(64, 20);
            this.textEdit1.TabIndex = 40;
            this.textEdit1.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.EditValue = "È«²¿";
            this.comboBoxEdit1.Location = new System.Drawing.Point(224, 96);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "È«²¿"});
            this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new System.Drawing.Size(79, 20);
            this.comboBoxEdit1.TabIndex = 39;
            this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // comboBoxEdit2
            // 
            this.comboBoxEdit2.EditValue = "È«²¿";
            this.comboBoxEdit2.Location = new System.Drawing.Point(224, 64);
            this.comboBoxEdit2.Name = "comboBoxEdit2";
            this.comboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit2.Properties.Items.AddRange(new object[] {
            "È«²¿"});
            this.comboBoxEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit2.Size = new System.Drawing.Size(78, 20);
            this.comboBoxEdit2.TabIndex = 38;
            this.comboBoxEdit2.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit2_SelectedIndexChanged);
            // 
            // textEdit2
            // 
            this.textEdit2.EditValue = "";
            this.textEdit2.Location = new System.Drawing.Point(80, 96);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Mask.EditMask = "d";
            this.textEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit2.Properties.MaxLength = 4;
            this.textEdit2.Size = new System.Drawing.Size(64, 20);
            this.textEdit2.TabIndex = 37;
            this.textEdit2.EditValueChanged += new System.EventHandler(this.textEdit2_EditValueChanged);
            // 
            // notePanel9
            // 
            this.notePanel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel9.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel9.ForeColor = System.Drawing.Color.Black;
            this.notePanel9.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel9.Location = new System.Drawing.Point(8, 96);
            this.notePanel9.MaxRows = 5;
            this.notePanel9.Name = "notePanel9";
            this.notePanel9.ParentAutoHeight = true;
            this.notePanel9.Size = new System.Drawing.Size(64, 22);
            this.notePanel9.TabIndex = 36;
            this.notePanel9.TabStop = false;
            this.notePanel9.Text = "¹¤  ºÅ:";
            // 
            // notePanel10
            // 
            this.notePanel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel10.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel10.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel10.ForeColor = System.Drawing.Color.Black;
            this.notePanel10.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel10.Location = new System.Drawing.Point(152, 96);
            this.notePanel10.MaxRows = 5;
            this.notePanel10.Name = "notePanel10";
            this.notePanel10.ParentAutoHeight = true;
            this.notePanel10.Size = new System.Drawing.Size(64, 22);
            this.notePanel10.TabIndex = 35;
            this.notePanel10.TabStop = false;
            this.notePanel10.Text = "²¿  ÃÅ:";
            // 
            // notePanel11
            // 
            this.notePanel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel11.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel11.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel11.ForeColor = System.Drawing.Color.Black;
            this.notePanel11.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel11.Location = new System.Drawing.Point(152, 64);
            this.notePanel11.MaxRows = 5;
            this.notePanel11.Name = "notePanel11";
            this.notePanel11.ParentAutoHeight = true;
            this.notePanel11.Size = new System.Drawing.Size(64, 22);
            this.notePanel11.TabIndex = 34;
            this.notePanel11.TabStop = false;
            this.notePanel11.Text = "¸Ú  Î»:";
            // 
            // notePanel12
            // 
            this.notePanel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel12.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel12.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel12.ForeColor = System.Drawing.Color.Black;
            this.notePanel12.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel12.Location = new System.Drawing.Point(8, 64);
            this.notePanel12.MaxRows = 5;
            this.notePanel12.Name = "notePanel12";
            this.notePanel12.ParentAutoHeight = true;
            this.notePanel12.Size = new System.Drawing.Size(64, 22);
            this.notePanel12.TabIndex = 33;
            this.notePanel12.TabStop = false;
            this.notePanel12.Text = "ÐÕ  Ãû:";
            // 
            // notePanel_Logout_TeaCardSerCond
            // 
            this.notePanel_Logout_TeaCardSerCond.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel_Logout_TeaCardSerCond.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel_Logout_TeaCardSerCond.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel_Logout_TeaCardSerCond.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Logout_TeaCardSerCond.Location = new System.Drawing.Point(2, 22);
            this.notePanel_Logout_TeaCardSerCond.MaxRows = 5;
            this.notePanel_Logout_TeaCardSerCond.Name = "notePanel_Logout_TeaCardSerCond";
            this.notePanel_Logout_TeaCardSerCond.ParentAutoHeight = true;
            this.notePanel_Logout_TeaCardSerCond.Size = new System.Drawing.Size(315, 23);
            this.notePanel_Logout_TeaCardSerCond.TabIndex = 24;
            this.notePanel_Logout_TeaCardSerCond.TabStop = false;
            this.notePanel_Logout_TeaCardSerCond.Text = "ÄúÒª¼ìË÷µÄÌõ¼þ£¿";
            // 
            // groupControl_Logout_StuCardMgmt
            // 
            this.groupControl_Logout_StuCardMgmt.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_Logout_StuCardMgmt.Appearance.Options.UseFont = true;
            this.groupControl_Logout_StuCardMgmt.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_Logout_StuCardMgmt.AppearanceCaption.Options.UseFont = true;
            this.groupControl_Logout_StuCardMgmt.Controls.Add(this.textEdit_Logout_StuName);
            this.groupControl_Logout_StuCardMgmt.Controls.Add(this.comboBoxEdit_Logout_StuClass);
            this.groupControl_Logout_StuCardMgmt.Controls.Add(this.comboBoxEdit_Logout_StuGrade);
            this.groupControl_Logout_StuCardMgmt.Controls.Add(this.textEdit_Logout_StuNumber);
            this.groupControl_Logout_StuCardMgmt.Controls.Add(this.notePanel_Logout_StuNumber);
            this.groupControl_Logout_StuCardMgmt.Controls.Add(this.notePanel_Logout_StuClass);
            this.groupControl_Logout_StuCardMgmt.Controls.Add(this.notePanel_Logout_StuGrade);
            this.groupControl_Logout_StuCardMgmt.Controls.Add(this.notePanel_Logout_StuCardSerCond);
            this.groupControl_Logout_StuCardMgmt.Controls.Add(this.notePanel_Logout_StuName);
            this.groupControl_Logout_StuCardMgmt.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl_Logout_StuCardMgmt.Location = new System.Drawing.Point(0, 40);
            this.groupControl_Logout_StuCardMgmt.Name = "groupControl_Logout_StuCardMgmt";
            this.groupControl_Logout_StuCardMgmt.Size = new System.Drawing.Size(319, 136);
            this.groupControl_Logout_StuCardMgmt.TabIndex = 15;
            this.groupControl_Logout_StuCardMgmt.Text = "Ñ§ÉúÍËÑ§¹ÜÀí";
            // 
            // textEdit_Logout_StuName
            // 
            this.textEdit_Logout_StuName.EditValue = "";
            this.textEdit_Logout_StuName.Location = new System.Drawing.Point(80, 64);
            this.textEdit_Logout_StuName.Name = "textEdit_Logout_StuName";
            this.textEdit_Logout_StuName.Size = new System.Drawing.Size(64, 20);
            this.textEdit_Logout_StuName.TabIndex = 32;
            this.textEdit_Logout_StuName.EditValueChanged += new System.EventHandler(this.textEdit_Logout_StuName_EditValueChanged);
            // 
            // comboBoxEdit_Logout_StuClass
            // 
            this.comboBoxEdit_Logout_StuClass.EditValue = "È«²¿";
            this.comboBoxEdit_Logout_StuClass.Location = new System.Drawing.Point(224, 96);
            this.comboBoxEdit_Logout_StuClass.Name = "comboBoxEdit_Logout_StuClass";
            this.comboBoxEdit_Logout_StuClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_Logout_StuClass.Properties.Items.AddRange(new object[] {
            "È«²¿"});
            this.comboBoxEdit_Logout_StuClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_Logout_StuClass.Size = new System.Drawing.Size(79, 20);
            this.comboBoxEdit_Logout_StuClass.TabIndex = 31;
            this.comboBoxEdit_Logout_StuClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Logout_StuClass_SelectedIndexChanged);
            // 
            // comboBoxEdit_Logout_StuGrade
            // 
            this.comboBoxEdit_Logout_StuGrade.EditValue = "È«²¿";
            this.comboBoxEdit_Logout_StuGrade.Location = new System.Drawing.Point(224, 64);
            this.comboBoxEdit_Logout_StuGrade.Name = "comboBoxEdit_Logout_StuGrade";
            this.comboBoxEdit_Logout_StuGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_Logout_StuGrade.Properties.Items.AddRange(new object[] {
            "È«²¿"});
            this.comboBoxEdit_Logout_StuGrade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_Logout_StuGrade.Size = new System.Drawing.Size(78, 20);
            this.comboBoxEdit_Logout_StuGrade.TabIndex = 30;
            this.comboBoxEdit_Logout_StuGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Logout_StuGrade_SelectedIndexChanged);
            // 
            // textEdit_Logout_StuNumber
            // 
            this.textEdit_Logout_StuNumber.EditValue = "";
            this.textEdit_Logout_StuNumber.Location = new System.Drawing.Point(80, 96);
            this.textEdit_Logout_StuNumber.Name = "textEdit_Logout_StuNumber";
            this.textEdit_Logout_StuNumber.Properties.MaxLength = 4;
            this.textEdit_Logout_StuNumber.Size = new System.Drawing.Size(64, 20);
            this.textEdit_Logout_StuNumber.TabIndex = 29;
            this.textEdit_Logout_StuNumber.EditValueChanged += new System.EventHandler(this.textEdit_Logout_StuNumber_EditValueChanged);
            // 
            // notePanel_Logout_StuNumber
            // 
            this.notePanel_Logout_StuNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Logout_StuNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Logout_StuNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Logout_StuNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Logout_StuNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Logout_StuNumber.Location = new System.Drawing.Point(8, 96);
            this.notePanel_Logout_StuNumber.MaxRows = 5;
            this.notePanel_Logout_StuNumber.Name = "notePanel_Logout_StuNumber";
            this.notePanel_Logout_StuNumber.ParentAutoHeight = true;
            this.notePanel_Logout_StuNumber.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Logout_StuNumber.TabIndex = 27;
            this.notePanel_Logout_StuNumber.TabStop = false;
            this.notePanel_Logout_StuNumber.Text = "Ñ§  ºÅ:";
            // 
            // notePanel_Logout_StuClass
            // 
            this.notePanel_Logout_StuClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Logout_StuClass.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Logout_StuClass.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Logout_StuClass.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Logout_StuClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Logout_StuClass.Location = new System.Drawing.Point(152, 96);
            this.notePanel_Logout_StuClass.MaxRows = 5;
            this.notePanel_Logout_StuClass.Name = "notePanel_Logout_StuClass";
            this.notePanel_Logout_StuClass.ParentAutoHeight = true;
            this.notePanel_Logout_StuClass.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Logout_StuClass.TabIndex = 26;
            this.notePanel_Logout_StuClass.TabStop = false;
            this.notePanel_Logout_StuClass.Text = "°à  ¼¶:";
            // 
            // notePanel_Logout_StuGrade
            // 
            this.notePanel_Logout_StuGrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Logout_StuGrade.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Logout_StuGrade.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Logout_StuGrade.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Logout_StuGrade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Logout_StuGrade.Location = new System.Drawing.Point(152, 64);
            this.notePanel_Logout_StuGrade.MaxRows = 5;
            this.notePanel_Logout_StuGrade.Name = "notePanel_Logout_StuGrade";
            this.notePanel_Logout_StuGrade.ParentAutoHeight = true;
            this.notePanel_Logout_StuGrade.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Logout_StuGrade.TabIndex = 25;
            this.notePanel_Logout_StuGrade.TabStop = false;
            this.notePanel_Logout_StuGrade.Text = "Äê  ¼¶:";
            // 
            // notePanel_Logout_StuCardSerCond
            // 
            this.notePanel_Logout_StuCardSerCond.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel_Logout_StuCardSerCond.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel_Logout_StuCardSerCond.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel_Logout_StuCardSerCond.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Logout_StuCardSerCond.Location = new System.Drawing.Point(2, 22);
            this.notePanel_Logout_StuCardSerCond.MaxRows = 5;
            this.notePanel_Logout_StuCardSerCond.Name = "notePanel_Logout_StuCardSerCond";
            this.notePanel_Logout_StuCardSerCond.ParentAutoHeight = true;
            this.notePanel_Logout_StuCardSerCond.Size = new System.Drawing.Size(315, 23);
            this.notePanel_Logout_StuCardSerCond.TabIndex = 23;
            this.notePanel_Logout_StuCardSerCond.TabStop = false;
            this.notePanel_Logout_StuCardSerCond.Text = "ÄúÒª¼ìË÷µÄÌõ¼þ£¿";
            // 
            // notePanel_Logout_StuName
            // 
            this.notePanel_Logout_StuName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Logout_StuName.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Logout_StuName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Logout_StuName.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Logout_StuName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Logout_StuName.Location = new System.Drawing.Point(8, 64);
            this.notePanel_Logout_StuName.MaxRows = 5;
            this.notePanel_Logout_StuName.Name = "notePanel_Logout_StuName";
            this.notePanel_Logout_StuName.ParentAutoHeight = true;
            this.notePanel_Logout_StuName.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Logout_StuName.TabIndex = 11;
            this.notePanel_Logout_StuName.TabStop = false;
            this.notePanel_Logout_StuName.Text = "ÐÕ  Ãû:";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.simpleButton_Logout_StuCard);
            this.panelControl3.Controls.Add(this.simpleButton_Logout_TeaCard);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(319, 40);
            this.panelControl3.TabIndex = 14;
            // 
            // simpleButton_Logout_StuCard
            // 
            this.simpleButton_Logout_StuCard.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_Logout_StuCard.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_Logout_StuCard.Appearance.Options.UseFont = true;
            this.simpleButton_Logout_StuCard.Appearance.Options.UseForeColor = true;
            this.simpleButton_Logout_StuCard.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_Logout_StuCard.Image")));
            this.simpleButton_Logout_StuCard.Location = new System.Drawing.Point(56, 8);
            this.simpleButton_Logout_StuCard.Name = "simpleButton_Logout_StuCard";
            this.simpleButton_Logout_StuCard.Size = new System.Drawing.Size(88, 26);
            this.simpleButton_Logout_StuCard.TabIndex = 6;
            this.simpleButton_Logout_StuCard.Tag = 4;
            this.simpleButton_Logout_StuCard.Text = "Ñ§Éú¿¨";
            this.simpleButton_Logout_StuCard.Click += new System.EventHandler(this.simpleButton_Logout_StuCard_Click);
            // 
            // simpleButton_Logout_TeaCard
            // 
            this.simpleButton_Logout_TeaCard.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_Logout_TeaCard.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_Logout_TeaCard.Appearance.Options.UseFont = true;
            this.simpleButton_Logout_TeaCard.Appearance.Options.UseForeColor = true;
            this.simpleButton_Logout_TeaCard.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_Logout_TeaCard.Image")));
            this.simpleButton_Logout_TeaCard.Location = new System.Drawing.Point(168, 8);
            this.simpleButton_Logout_TeaCard.Name = "simpleButton_Logout_TeaCard";
            this.simpleButton_Logout_TeaCard.Size = new System.Drawing.Size(88, 26);
            this.simpleButton_Logout_TeaCard.TabIndex = 8;
            this.simpleButton_Logout_TeaCard.Tag = 4;
            this.simpleButton_Logout_TeaCard.Text = "½ÌÊ¦¿¨";
            this.simpleButton_Logout_TeaCard.Click += new System.EventHandler(this.simpleButton_Logout_TeaCard_Click);
            // 
            // groupControl_Logout_MyCardRec
            // 
            this.groupControl_Logout_MyCardRec.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_Logout_MyCardRec.AppearanceCaption.Options.UseFont = true;
            this.groupControl_Logout_MyCardRec.Controls.Add(this.gridControl_Logout_CardInfo);
            this.groupControl_Logout_MyCardRec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl_Logout_MyCardRec.Location = new System.Drawing.Point(0, 0);
            this.groupControl_Logout_MyCardRec.Name = "groupControl_Logout_MyCardRec";
            this.groupControl_Logout_MyCardRec.Size = new System.Drawing.Size(442, 511);
            this.groupControl_Logout_MyCardRec.TabIndex = 27;
            this.groupControl_Logout_MyCardRec.Text = "¼ìË÷½á¹û";
            // 
            // gridControl_Logout_CardInfo
            // 
            this.gridControl_Logout_CardInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Logout_CardInfo.Location = new System.Drawing.Point(2, 22);
            this.gridControl_Logout_CardInfo.MainView = this.gridView2;
            this.gridControl_Logout_CardInfo.Name = "gridControl_Logout_CardInfo";
            this.gridControl_Logout_CardInfo.Size = new System.Drawing.Size(438, 487);
            this.gridControl_Logout_CardInfo.TabIndex = 0;
            this.gridControl_Logout_CardInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20});
            this.gridView2.GridControl = this.gridControl_Logout_CardInfo;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowGroup = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 0;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 1;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 2;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 3;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 4;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 5;
            // 
            // xtraTabPage_IDQuery
            // 
            this.xtraTabPage_IDQuery.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_IDQuery.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_IDQuery.Controls.Add(this.splitContainerControl3);
            this.xtraTabPage_IDQuery.Name = "xtraTabPage_IDQuery";
            this.xtraTabPage_IDQuery.PageVisible = false;
            this.xtraTabPage_IDQuery.Size = new System.Drawing.Size(766, 511);
            this.xtraTabPage_IDQuery.Text = "ID¿¨²éÑ¯";
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.Controls.Add(this.groupControl_IDQueryFastSer);
            this.splitContainerControl3.Panel1.Text = "splitContainerControl3_Panel1";
            this.splitContainerControl3.Panel2.Controls.Add(this.gridControl_IDQueryView);
            this.splitContainerControl3.Panel2.Controls.Add(this.panelControl2);
            this.splitContainerControl3.Panel2.Text = "splitContainerControl3_Panel2";
            this.splitContainerControl3.Size = new System.Drawing.Size(766, 511);
            this.splitContainerControl3.SplitterPosition = 223;
            this.splitContainerControl3.TabIndex = 0;
            this.splitContainerControl3.Text = "splitContainerControl3";
            // 
            // groupControl_IDQueryFastSer
            // 
            this.groupControl_IDQueryFastSer.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_IDQueryFastSer.AppearanceCaption.Options.UseFont = true;
            this.groupControl_IDQueryFastSer.Controls.Add(this.groupControl_IDQueryTeaNumberAndName);
            this.groupControl_IDQueryFastSer.Controls.Add(this.panelControl_TeaField);
            this.groupControl_IDQueryFastSer.Controls.Add(this.panelControl_StuField);
            this.groupControl_IDQueryFastSer.Controls.Add(this.groupControl_IDQueryTimeAndCardNumber);
            this.groupControl_IDQueryFastSer.Controls.Add(this.groupControl_IDQueryNumberAndName);
            this.groupControl_IDQueryFastSer.Controls.Add(this.groupControl_IDQueryGradeAndClass);
            this.groupControl_IDQueryFastSer.Controls.Add(this.notePanel1_IDQueryFastSer);
            this.groupControl_IDQueryFastSer.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl_IDQueryFastSer.Location = new System.Drawing.Point(0, 0);
            this.groupControl_IDQueryFastSer.Name = "groupControl_IDQueryFastSer";
            this.groupControl_IDQueryFastSer.Size = new System.Drawing.Size(223, 288);
            this.groupControl_IDQueryFastSer.TabIndex = 10;
            this.groupControl_IDQueryFastSer.Text = "¿ìËÙËÑË÷";
            // 
            // groupControl_IDQueryTeaNumberAndName
            // 
            this.groupControl_IDQueryTeaNumberAndName.Controls.Add(this.notePanel_IDQueryTeaName);
            this.groupControl_IDQueryTeaNumberAndName.Controls.Add(this.textEdit_IDQueryTeaName);
            this.groupControl_IDQueryTeaNumberAndName.Controls.Add(this.textEdit_IDQueryTeaNumber);
            this.groupControl_IDQueryTeaNumberAndName.Controls.Add(this.notePanel_IDQueryTeaNumber);
            this.groupControl_IDQueryTeaNumberAndName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl_IDQueryTeaNumberAndName.Location = new System.Drawing.Point(2, -194);
            this.groupControl_IDQueryTeaNumberAndName.Name = "groupControl_IDQueryTeaNumberAndName";
            this.groupControl_IDQueryTeaNumberAndName.Size = new System.Drawing.Size(219, 120);
            this.groupControl_IDQueryTeaNumberAndName.TabIndex = 25;
            this.groupControl_IDQueryTeaNumberAndName.Text = "Ö¸¶¨ËÑË÷½ÌÊ¦µÄ¹¤ºÅºÍÐÕÃû";
            this.groupControl_IDQueryTeaNumberAndName.Visible = false;
            // 
            // notePanel_IDQueryTeaName
            // 
            this.notePanel_IDQueryTeaName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_IDQueryTeaName.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_IDQueryTeaName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_IDQueryTeaName.ForeColor = System.Drawing.Color.Black;
            this.notePanel_IDQueryTeaName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_IDQueryTeaName.Location = new System.Drawing.Point(16, 72);
            this.notePanel_IDQueryTeaName.MaxRows = 5;
            this.notePanel_IDQueryTeaName.Name = "notePanel_IDQueryTeaName";
            this.notePanel_IDQueryTeaName.ParentAutoHeight = true;
            this.notePanel_IDQueryTeaName.Size = new System.Drawing.Size(64, 22);
            this.notePanel_IDQueryTeaName.TabIndex = 14;
            this.notePanel_IDQueryTeaName.TabStop = false;
            this.notePanel_IDQueryTeaName.Text = "ÐÕ   Ãû:";
            // 
            // textEdit_IDQueryTeaName
            // 
            this.textEdit_IDQueryTeaName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit_IDQueryTeaName.EditValue = "";
            this.textEdit_IDQueryTeaName.Location = new System.Drawing.Point(88, 72);
            this.textEdit_IDQueryTeaName.Name = "textEdit_IDQueryTeaName";
            this.textEdit_IDQueryTeaName.Size = new System.Drawing.Size(225, 20);
            this.textEdit_IDQueryTeaName.TabIndex = 13;
            // 
            // textEdit_IDQueryTeaNumber
            // 
            this.textEdit_IDQueryTeaNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit_IDQueryTeaNumber.EditValue = "";
            this.textEdit_IDQueryTeaNumber.Location = new System.Drawing.Point(88, 32);
            this.textEdit_IDQueryTeaNumber.Name = "textEdit_IDQueryTeaNumber";
            this.textEdit_IDQueryTeaNumber.Size = new System.Drawing.Size(225, 20);
            this.textEdit_IDQueryTeaNumber.TabIndex = 12;
            // 
            // notePanel_IDQueryTeaNumber
            // 
            this.notePanel_IDQueryTeaNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_IDQueryTeaNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_IDQueryTeaNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_IDQueryTeaNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_IDQueryTeaNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_IDQueryTeaNumber.Location = new System.Drawing.Point(16, 32);
            this.notePanel_IDQueryTeaNumber.MaxRows = 5;
            this.notePanel_IDQueryTeaNumber.Name = "notePanel_IDQueryTeaNumber";
            this.notePanel_IDQueryTeaNumber.ParentAutoHeight = true;
            this.notePanel_IDQueryTeaNumber.Size = new System.Drawing.Size(64, 22);
            this.notePanel_IDQueryTeaNumber.TabIndex = 11;
            this.notePanel_IDQueryTeaNumber.TabStop = false;
            this.notePanel_IDQueryTeaNumber.Text = "¹¤  ºÅ:";
            // 
            // panelControl_TeaField
            // 
            this.panelControl_TeaField.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl_TeaField.Appearance.Options.UseBackColor = true;
            this.panelControl_TeaField.Controls.Add(this.notePanel_IDQueryTeaTimeAndCardNumber);
            this.panelControl_TeaField.Controls.Add(this.notePanel_IDQueryTeaNumberAndName);
            this.panelControl_TeaField.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl_TeaField.Location = new System.Drawing.Point(2, 131);
            this.panelControl_TeaField.Name = "panelControl_TeaField";
            this.panelControl_TeaField.Size = new System.Drawing.Size(219, 72);
            this.panelControl_TeaField.TabIndex = 24;
            this.panelControl_TeaField.Visible = false;
            // 
            // notePanel_IDQueryTeaTimeAndCardNumber
            // 
            this.notePanel_IDQueryTeaTimeAndCardNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notePanel_IDQueryTeaTimeAndCardNumber.BackColor = System.Drawing.Color.Yellow;
            this.notePanel_IDQueryTeaTimeAndCardNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_IDQueryTeaTimeAndCardNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_IDQueryTeaTimeAndCardNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_IDQueryTeaTimeAndCardNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_IDQueryTeaTimeAndCardNumber.Location = new System.Drawing.Point(16, 34);
            this.notePanel_IDQueryTeaTimeAndCardNumber.MaxRows = 5;
            this.notePanel_IDQueryTeaTimeAndCardNumber.Name = "notePanel_IDQueryTeaTimeAndCardNumber";
            this.notePanel_IDQueryTeaTimeAndCardNumber.ParentAutoHeight = true;
            this.notePanel_IDQueryTeaTimeAndCardNumber.Size = new System.Drawing.Size(225, 22);
            this.notePanel_IDQueryTeaTimeAndCardNumber.TabIndex = 19;
            this.notePanel_IDQueryTeaTimeAndCardNumber.TabStop = false;
            this.notePanel_IDQueryTeaTimeAndCardNumber.Text = "Ê±¼äºÍ¿¨ºÅ:";
            this.notePanel_IDQueryTeaTimeAndCardNumber.Click += new System.EventHandler(this.notePanel_IDQueryTeaTimeAndCardNumber_Click);
            // 
            // notePanel_IDQueryTeaNumberAndName
            // 
            this.notePanel_IDQueryTeaNumberAndName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notePanel_IDQueryTeaNumberAndName.BackColor = System.Drawing.Color.Yellow;
            this.notePanel_IDQueryTeaNumberAndName.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_IDQueryTeaNumberAndName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_IDQueryTeaNumberAndName.ForeColor = System.Drawing.Color.Black;
            this.notePanel_IDQueryTeaNumberAndName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_IDQueryTeaNumberAndName.Location = new System.Drawing.Point(16, 8);
            this.notePanel_IDQueryTeaNumberAndName.MaxRows = 5;
            this.notePanel_IDQueryTeaNumberAndName.Name = "notePanel_IDQueryTeaNumberAndName";
            this.notePanel_IDQueryTeaNumberAndName.ParentAutoHeight = true;
            this.notePanel_IDQueryTeaNumberAndName.Size = new System.Drawing.Size(225, 22);
            this.notePanel_IDQueryTeaNumberAndName.TabIndex = 18;
            this.notePanel_IDQueryTeaNumberAndName.TabStop = false;
            this.notePanel_IDQueryTeaNumberAndName.Text = "¹¤ºÅºÍÐÕÃû:";
            this.notePanel_IDQueryTeaNumberAndName.Click += new System.EventHandler(this.notePanel_IDQueryTeaNumberAndName_Click);
            // 
            // panelControl_StuField
            // 
            this.panelControl_StuField.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl_StuField.Appearance.Options.UseBackColor = true;
            this.panelControl_StuField.Controls.Add(this.notePanel_IDQueryNumberAndName);
            this.panelControl_StuField.Controls.Add(this.notePanel_IDQueryTimeAndCardNumber);
            this.panelControl_StuField.Controls.Add(this.notePanel_IDQueryGradeAndClass);
            this.panelControl_StuField.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl_StuField.Location = new System.Drawing.Point(2, 45);
            this.panelControl_StuField.Name = "panelControl_StuField";
            this.panelControl_StuField.Size = new System.Drawing.Size(219, 86);
            this.panelControl_StuField.TabIndex = 23;
            // 
            // notePanel_IDQueryNumberAndName
            // 
            this.notePanel_IDQueryNumberAndName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notePanel_IDQueryNumberAndName.BackColor = System.Drawing.Color.LightGray;
            this.notePanel_IDQueryNumberAndName.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_IDQueryNumberAndName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_IDQueryNumberAndName.ForeColor = System.Drawing.Color.Black;
            this.notePanel_IDQueryNumberAndName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_IDQueryNumberAndName.Location = new System.Drawing.Point(16, 34);
            this.notePanel_IDQueryNumberAndName.MaxRows = 5;
            this.notePanel_IDQueryNumberAndName.Name = "notePanel_IDQueryNumberAndName";
            this.notePanel_IDQueryNumberAndName.ParentAutoHeight = true;
            this.notePanel_IDQueryNumberAndName.Size = new System.Drawing.Size(225, 22);
            this.notePanel_IDQueryNumberAndName.TabIndex = 17;
            this.notePanel_IDQueryNumberAndName.TabStop = false;
            this.notePanel_IDQueryNumberAndName.Text = "Ñ§ºÅºÍÐÕÃû:";
            this.notePanel_IDQueryNumberAndName.Click += new System.EventHandler(this.notePanel_IDQueryNumberAndName_Click);
            // 
            // notePanel_IDQueryTimeAndCardNumber
            // 
            this.notePanel_IDQueryTimeAndCardNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notePanel_IDQueryTimeAndCardNumber.BackColor = System.Drawing.Color.LightGray;
            this.notePanel_IDQueryTimeAndCardNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_IDQueryTimeAndCardNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_IDQueryTimeAndCardNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_IDQueryTimeAndCardNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_IDQueryTimeAndCardNumber.Location = new System.Drawing.Point(16, 58);
            this.notePanel_IDQueryTimeAndCardNumber.MaxRows = 5;
            this.notePanel_IDQueryTimeAndCardNumber.Name = "notePanel_IDQueryTimeAndCardNumber";
            this.notePanel_IDQueryTimeAndCardNumber.ParentAutoHeight = true;
            this.notePanel_IDQueryTimeAndCardNumber.Size = new System.Drawing.Size(225, 22);
            this.notePanel_IDQueryTimeAndCardNumber.TabIndex = 18;
            this.notePanel_IDQueryTimeAndCardNumber.TabStop = false;
            this.notePanel_IDQueryTimeAndCardNumber.Text = "Ê±¼äºÍ¿¨ºÅ:";
            this.notePanel_IDQueryTimeAndCardNumber.Click += new System.EventHandler(this.notePanel_IDQueryTimeAndCardNumber_Click);
            // 
            // notePanel_IDQueryGradeAndClass
            // 
            this.notePanel_IDQueryGradeAndClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notePanel_IDQueryGradeAndClass.BackColor = System.Drawing.Color.LightGray;
            this.notePanel_IDQueryGradeAndClass.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_IDQueryGradeAndClass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notePanel_IDQueryGradeAndClass.ForeColor = System.Drawing.Color.Black;
            this.notePanel_IDQueryGradeAndClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_IDQueryGradeAndClass.Location = new System.Drawing.Point(16, 8);
            this.notePanel_IDQueryGradeAndClass.MaxRows = 5;
            this.notePanel_IDQueryGradeAndClass.Name = "notePanel_IDQueryGradeAndClass";
            this.notePanel_IDQueryGradeAndClass.ParentAutoHeight = true;
            this.notePanel_IDQueryGradeAndClass.Size = new System.Drawing.Size(225, 22);
            this.notePanel_IDQueryGradeAndClass.TabIndex = 19;
            this.notePanel_IDQueryGradeAndClass.TabStop = false;
            this.notePanel_IDQueryGradeAndClass.Text = "Äê¼¶ºÍ°à¼¶:";
            this.notePanel_IDQueryGradeAndClass.Click += new System.EventHandler(this.notePanel_IDQueryGradeAndClass_Click);
            // 
            // groupControl_IDQueryTimeAndCardNumber
            // 
            this.groupControl_IDQueryTimeAndCardNumber.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_IDQueryTimeAndCardNumber.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.groupControl_IDQueryTimeAndCardNumber.AppearanceCaption.Options.UseFont = true;
            this.groupControl_IDQueryTimeAndCardNumber.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl_IDQueryTimeAndCardNumber.Controls.Add(this.textEdit_IDQueryCardNumber);
            this.groupControl_IDQueryTimeAndCardNumber.Controls.Add(this.notePanel_IDQueryCardNumber);
            this.groupControl_IDQueryTimeAndCardNumber.Controls.Add(this.dateEdit_IDQueryEndTime);
            this.groupControl_IDQueryTimeAndCardNumber.Controls.Add(this.notePanel_IDQueryBegTime);
            this.groupControl_IDQueryTimeAndCardNumber.Controls.Add(this.notePanel_IDQueryEndTime);
            this.groupControl_IDQueryTimeAndCardNumber.Controls.Add(this.dateEdit_IDQueryBegTime);
            this.groupControl_IDQueryTimeAndCardNumber.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl_IDQueryTimeAndCardNumber.Location = new System.Drawing.Point(2, -74);
            this.groupControl_IDQueryTimeAndCardNumber.Name = "groupControl_IDQueryTimeAndCardNumber";
            this.groupControl_IDQueryTimeAndCardNumber.Size = new System.Drawing.Size(219, 120);
            this.groupControl_IDQueryTimeAndCardNumber.TabIndex = 22;
            this.groupControl_IDQueryTimeAndCardNumber.Text = "Ö¸¶¨·¢¿¨µÄÆðÖ¹Ê±¼äºÍ¿¨ºÅ";
            this.groupControl_IDQueryTimeAndCardNumber.Visible = false;
            // 
            // textEdit_IDQueryCardNumber
            // 
            this.textEdit_IDQueryCardNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit_IDQueryCardNumber.EditValue = "";
            this.textEdit_IDQueryCardNumber.Location = new System.Drawing.Point(104, 88);
            this.textEdit_IDQueryCardNumber.Name = "textEdit_IDQueryCardNumber";
            this.textEdit_IDQueryCardNumber.Size = new System.Drawing.Size(225, 20);
            this.textEdit_IDQueryCardNumber.TabIndex = 18;
            // 
            // notePanel_IDQueryCardNumber
            // 
            this.notePanel_IDQueryCardNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_IDQueryCardNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_IDQueryCardNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_IDQueryCardNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_IDQueryCardNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_IDQueryCardNumber.Location = new System.Drawing.Point(16, 88);
            this.notePanel_IDQueryCardNumber.MaxRows = 5;
            this.notePanel_IDQueryCardNumber.Name = "notePanel_IDQueryCardNumber";
            this.notePanel_IDQueryCardNumber.ParentAutoHeight = true;
            this.notePanel_IDQueryCardNumber.Size = new System.Drawing.Size(80, 22);
            this.notePanel_IDQueryCardNumber.TabIndex = 17;
            this.notePanel_IDQueryCardNumber.TabStop = false;
            this.notePanel_IDQueryCardNumber.Text = "¿¨   ºÅ:";
            // 
            // dateEdit_IDQueryEndTime
            // 
            this.dateEdit_IDQueryEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEdit_IDQueryEndTime.EditValue = new System.DateTime(2005, 9, 9, 0, 0, 0, 0);
            this.dateEdit_IDQueryEndTime.Location = new System.Drawing.Point(104, 56);
            this.dateEdit_IDQueryEndTime.Name = "dateEdit_IDQueryEndTime";
            this.dateEdit_IDQueryEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_IDQueryEndTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_IDQueryEndTime.Size = new System.Drawing.Size(225, 20);
            this.dateEdit_IDQueryEndTime.TabIndex = 16;
            // 
            // notePanel_IDQueryBegTime
            // 
            this.notePanel_IDQueryBegTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_IDQueryBegTime.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_IDQueryBegTime.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_IDQueryBegTime.ForeColor = System.Drawing.Color.Black;
            this.notePanel_IDQueryBegTime.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_IDQueryBegTime.Location = new System.Drawing.Point(16, 24);
            this.notePanel_IDQueryBegTime.MaxRows = 5;
            this.notePanel_IDQueryBegTime.Name = "notePanel_IDQueryBegTime";
            this.notePanel_IDQueryBegTime.ParentAutoHeight = true;
            this.notePanel_IDQueryBegTime.Size = new System.Drawing.Size(80, 22);
            this.notePanel_IDQueryBegTime.TabIndex = 14;
            this.notePanel_IDQueryBegTime.TabStop = false;
            this.notePanel_IDQueryBegTime.Text = "ÆðÊ¼Ê±¼ä";
            // 
            // notePanel_IDQueryEndTime
            // 
            this.notePanel_IDQueryEndTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_IDQueryEndTime.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_IDQueryEndTime.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_IDQueryEndTime.ForeColor = System.Drawing.Color.Black;
            this.notePanel_IDQueryEndTime.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_IDQueryEndTime.Location = new System.Drawing.Point(16, 56);
            this.notePanel_IDQueryEndTime.MaxRows = 5;
            this.notePanel_IDQueryEndTime.Name = "notePanel_IDQueryEndTime";
            this.notePanel_IDQueryEndTime.ParentAutoHeight = true;
            this.notePanel_IDQueryEndTime.Size = new System.Drawing.Size(80, 22);
            this.notePanel_IDQueryEndTime.TabIndex = 13;
            this.notePanel_IDQueryEndTime.TabStop = false;
            this.notePanel_IDQueryEndTime.Text = "½áÊøÊ±¼ä";
            // 
            // dateEdit_IDQueryBegTime
            // 
            this.dateEdit_IDQueryBegTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEdit_IDQueryBegTime.EditValue = new System.DateTime(2005, 9, 9, 0, 0, 0, 0);
            this.dateEdit_IDQueryBegTime.Location = new System.Drawing.Point(104, 24);
            this.dateEdit_IDQueryBegTime.Name = "dateEdit_IDQueryBegTime";
            this.dateEdit_IDQueryBegTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_IDQueryBegTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_IDQueryBegTime.Size = new System.Drawing.Size(225, 20);
            this.dateEdit_IDQueryBegTime.TabIndex = 15;
            // 
            // groupControl_IDQueryNumberAndName
            // 
            this.groupControl_IDQueryNumberAndName.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_IDQueryNumberAndName.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.groupControl_IDQueryNumberAndName.AppearanceCaption.Options.UseFont = true;
            this.groupControl_IDQueryNumberAndName.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl_IDQueryNumberAndName.Controls.Add(this.textEdit_IDQueryStuName);
            this.groupControl_IDQueryNumberAndName.Controls.Add(this.textEdit_IDQueryStuNumber);
            this.groupControl_IDQueryNumberAndName.Controls.Add(this.notePanel_IDQueryStuNumber);
            this.groupControl_IDQueryNumberAndName.Controls.Add(this.notePanel_IDQueryStuName);
            this.groupControl_IDQueryNumberAndName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl_IDQueryNumberAndName.Location = new System.Drawing.Point(2, 46);
            this.groupControl_IDQueryNumberAndName.Name = "groupControl_IDQueryNumberAndName";
            this.groupControl_IDQueryNumberAndName.Size = new System.Drawing.Size(219, 120);
            this.groupControl_IDQueryNumberAndName.TabIndex = 21;
            this.groupControl_IDQueryNumberAndName.Text = "Ö¸¶¨ËÑË÷µÄÓ×¶ùÑ§ºÅºÍÐÕÃû";
            this.groupControl_IDQueryNumberAndName.Visible = false;
            // 
            // textEdit_IDQueryStuName
            // 
            this.textEdit_IDQueryStuName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit_IDQueryStuName.EditValue = "";
            this.textEdit_IDQueryStuName.Location = new System.Drawing.Point(96, 72);
            this.textEdit_IDQueryStuName.Name = "textEdit_IDQueryStuName";
            this.textEdit_IDQueryStuName.Size = new System.Drawing.Size(225, 20);
            this.textEdit_IDQueryStuName.TabIndex = 12;
            // 
            // textEdit_IDQueryStuNumber
            // 
            this.textEdit_IDQueryStuNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit_IDQueryStuNumber.EditValue = "";
            this.textEdit_IDQueryStuNumber.Location = new System.Drawing.Point(96, 32);
            this.textEdit_IDQueryStuNumber.Name = "textEdit_IDQueryStuNumber";
            this.textEdit_IDQueryStuNumber.Size = new System.Drawing.Size(225, 20);
            this.textEdit_IDQueryStuNumber.TabIndex = 11;
            // 
            // notePanel_IDQueryStuNumber
            // 
            this.notePanel_IDQueryStuNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_IDQueryStuNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_IDQueryStuNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_IDQueryStuNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_IDQueryStuNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_IDQueryStuNumber.Location = new System.Drawing.Point(16, 32);
            this.notePanel_IDQueryStuNumber.MaxRows = 5;
            this.notePanel_IDQueryStuNumber.Name = "notePanel_IDQueryStuNumber";
            this.notePanel_IDQueryStuNumber.ParentAutoHeight = true;
            this.notePanel_IDQueryStuNumber.Size = new System.Drawing.Size(64, 22);
            this.notePanel_IDQueryStuNumber.TabIndex = 10;
            this.notePanel_IDQueryStuNumber.TabStop = false;
            this.notePanel_IDQueryStuNumber.Text = "Ñ§  ºÅ:";
            // 
            // notePanel_IDQueryStuName
            // 
            this.notePanel_IDQueryStuName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_IDQueryStuName.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_IDQueryStuName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_IDQueryStuName.ForeColor = System.Drawing.Color.Black;
            this.notePanel_IDQueryStuName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_IDQueryStuName.Location = new System.Drawing.Point(16, 72);
            this.notePanel_IDQueryStuName.MaxRows = 5;
            this.notePanel_IDQueryStuName.Name = "notePanel_IDQueryStuName";
            this.notePanel_IDQueryStuName.ParentAutoHeight = true;
            this.notePanel_IDQueryStuName.Size = new System.Drawing.Size(64, 22);
            this.notePanel_IDQueryStuName.TabIndex = 9;
            this.notePanel_IDQueryStuName.TabStop = false;
            this.notePanel_IDQueryStuName.Text = "ÐÕ  Ãû:";
            // 
            // groupControl_IDQueryGradeAndClass
            // 
            this.groupControl_IDQueryGradeAndClass.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_IDQueryGradeAndClass.AppearanceCaption.Options.UseFont = true;
            this.groupControl_IDQueryGradeAndClass.Controls.Add(this.comboBoxEdit_IDQueryStuClass);
            this.groupControl_IDQueryGradeAndClass.Controls.Add(this.comboBoxEdit_IDQueryStuGrade);
            this.groupControl_IDQueryGradeAndClass.Controls.Add(this.notePanel_IDQueryStuGrade);
            this.groupControl_IDQueryGradeAndClass.Controls.Add(this.notePanel_IDQueryStuClass);
            this.groupControl_IDQueryGradeAndClass.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl_IDQueryGradeAndClass.Location = new System.Drawing.Point(2, 166);
            this.groupControl_IDQueryGradeAndClass.Name = "groupControl_IDQueryGradeAndClass";
            this.groupControl_IDQueryGradeAndClass.Size = new System.Drawing.Size(219, 120);
            this.groupControl_IDQueryGradeAndClass.TabIndex = 20;
            this.groupControl_IDQueryGradeAndClass.Text = "Ö¸¶¨ËÑË÷Ó×¶ùµÄÄê¼¶ºÍ°à¼¶";
            this.groupControl_IDQueryGradeAndClass.Visible = false;
            // 
            // comboBoxEdit_IDQueryStuClass
            // 
            this.comboBoxEdit_IDQueryStuClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEdit_IDQueryStuClass.EditValue = "";
            this.comboBoxEdit_IDQueryStuClass.Location = new System.Drawing.Point(96, 72);
            this.comboBoxEdit_IDQueryStuClass.Name = "comboBoxEdit_IDQueryStuClass";
            this.comboBoxEdit_IDQueryStuClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_IDQueryStuClass.Size = new System.Drawing.Size(225, 20);
            this.comboBoxEdit_IDQueryStuClass.TabIndex = 18;
            // 
            // comboBoxEdit_IDQueryStuGrade
            // 
            this.comboBoxEdit_IDQueryStuGrade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEdit_IDQueryStuGrade.EditValue = "";
            this.comboBoxEdit_IDQueryStuGrade.Location = new System.Drawing.Point(96, 32);
            this.comboBoxEdit_IDQueryStuGrade.Name = "comboBoxEdit_IDQueryStuGrade";
            this.comboBoxEdit_IDQueryStuGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_IDQueryStuGrade.Size = new System.Drawing.Size(225, 20);
            this.comboBoxEdit_IDQueryStuGrade.TabIndex = 17;
            // 
            // notePanel_IDQueryStuGrade
            // 
            this.notePanel_IDQueryStuGrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_IDQueryStuGrade.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_IDQueryStuGrade.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_IDQueryStuGrade.ForeColor = System.Drawing.Color.Black;
            this.notePanel_IDQueryStuGrade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_IDQueryStuGrade.Location = new System.Drawing.Point(16, 32);
            this.notePanel_IDQueryStuGrade.MaxRows = 5;
            this.notePanel_IDQueryStuGrade.Name = "notePanel_IDQueryStuGrade";
            this.notePanel_IDQueryStuGrade.ParentAutoHeight = true;
            this.notePanel_IDQueryStuGrade.Size = new System.Drawing.Size(64, 22);
            this.notePanel_IDQueryStuGrade.TabIndex = 4;
            this.notePanel_IDQueryStuGrade.TabStop = false;
            this.notePanel_IDQueryStuGrade.Text = "Äê  ¼¶:";
            // 
            // notePanel_IDQueryStuClass
            // 
            this.notePanel_IDQueryStuClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_IDQueryStuClass.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_IDQueryStuClass.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_IDQueryStuClass.ForeColor = System.Drawing.Color.Black;
            this.notePanel_IDQueryStuClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_IDQueryStuClass.Location = new System.Drawing.Point(16, 72);
            this.notePanel_IDQueryStuClass.MaxRows = 5;
            this.notePanel_IDQueryStuClass.Name = "notePanel_IDQueryStuClass";
            this.notePanel_IDQueryStuClass.ParentAutoHeight = true;
            this.notePanel_IDQueryStuClass.Size = new System.Drawing.Size(64, 22);
            this.notePanel_IDQueryStuClass.TabIndex = 16;
            this.notePanel_IDQueryStuClass.TabStop = false;
            this.notePanel_IDQueryStuClass.Text = "°à  ¼¶:";
            // 
            // notePanel1_IDQueryFastSer
            // 
            this.notePanel1_IDQueryFastSer.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel1_IDQueryFastSer.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel1_IDQueryFastSer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notePanel1_IDQueryFastSer.ForeColor = System.Drawing.Color.Gray;
            this.notePanel1_IDQueryFastSer.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel1_IDQueryFastSer.Location = new System.Drawing.Point(2, 22);
            this.notePanel1_IDQueryFastSer.MaxRows = 5;
            this.notePanel1_IDQueryFastSer.Name = "notePanel1_IDQueryFastSer";
            this.notePanel1_IDQueryFastSer.ParentAutoHeight = true;
            this.notePanel1_IDQueryFastSer.Size = new System.Drawing.Size(219, 23);
            this.notePanel1_IDQueryFastSer.TabIndex = 5;
            this.notePanel1_IDQueryFastSer.TabStop = false;
            this.notePanel1_IDQueryFastSer.Text = "ÄúÒªËÑË÷µÄÌõ¼þ£¿";
            // 
            // gridControl_IDQueryView
            // 
            this.gridControl_IDQueryView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_IDQueryView.Location = new System.Drawing.Point(0, 40);
            this.gridControl_IDQueryView.MainView = this.gridView4;
            this.gridControl_IDQueryView.Name = "gridControl_IDQueryView";
            this.gridControl_IDQueryView.Size = new System.Drawing.Size(538, 471);
            this.gridControl_IDQueryView.TabIndex = 1;
            this.gridControl_IDQueryView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.gridControl_IDQueryView;
            this.gridView4.Name = "gridView4";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl2.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.panelControl2.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.simpleButton_IDQueryPrint);
            this.panelControl2.Controls.Add(this.simpleButton_IDQueryStuCard);
            this.panelControl2.Controls.Add(this.simpleButton_IDQueryTeaCard);
            this.panelControl2.Controls.Add(this.simpleButton_IDQuerySearch);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(538, 40);
            this.panelControl2.TabIndex = 0;
            // 
            // simpleButton_IDQueryPrint
            // 
            this.simpleButton_IDQueryPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_IDQueryPrint.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_IDQueryPrint.Appearance.Options.UseFont = true;
            this.simpleButton_IDQueryPrint.Appearance.Options.UseForeColor = true;
            this.simpleButton_IDQueryPrint.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_IDQueryPrint.Image")));
            this.simpleButton_IDQueryPrint.Location = new System.Drawing.Point(320, 7);
            this.simpleButton_IDQueryPrint.Name = "simpleButton_IDQueryPrint";
            this.simpleButton_IDQueryPrint.Size = new System.Drawing.Size(91, 26);
            this.simpleButton_IDQueryPrint.TabIndex = 10;
            this.simpleButton_IDQueryPrint.Tag = 4;
            this.simpleButton_IDQueryPrint.Text = "´ò   Ó¡";
            // 
            // simpleButton_IDQueryStuCard
            // 
            this.simpleButton_IDQueryStuCard.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_IDQueryStuCard.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_IDQueryStuCard.Appearance.Options.UseFont = true;
            this.simpleButton_IDQueryStuCard.Appearance.Options.UseForeColor = true;
            this.simpleButton_IDQueryStuCard.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_IDQueryStuCard.Image")));
            this.simpleButton_IDQueryStuCard.Location = new System.Drawing.Point(8, 8);
            this.simpleButton_IDQueryStuCard.Name = "simpleButton_IDQueryStuCard";
            this.simpleButton_IDQueryStuCard.Size = new System.Drawing.Size(91, 26);
            this.simpleButton_IDQueryStuCard.TabIndex = 8;
            this.simpleButton_IDQueryStuCard.Tag = 4;
            this.simpleButton_IDQueryStuCard.Text = "Ñ§Éú¿¨";
            this.simpleButton_IDQueryStuCard.Click += new System.EventHandler(this.simpleButton_IDQueryStuCard_Click);
            // 
            // simpleButton_IDQueryTeaCard
            // 
            this.simpleButton_IDQueryTeaCard.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_IDQueryTeaCard.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_IDQueryTeaCard.Appearance.Options.UseFont = true;
            this.simpleButton_IDQueryTeaCard.Appearance.Options.UseForeColor = true;
            this.simpleButton_IDQueryTeaCard.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_IDQueryTeaCard.Image")));
            this.simpleButton_IDQueryTeaCard.Location = new System.Drawing.Point(112, 8);
            this.simpleButton_IDQueryTeaCard.Name = "simpleButton_IDQueryTeaCard";
            this.simpleButton_IDQueryTeaCard.Size = new System.Drawing.Size(91, 26);
            this.simpleButton_IDQueryTeaCard.TabIndex = 9;
            this.simpleButton_IDQueryTeaCard.Tag = 4;
            this.simpleButton_IDQueryTeaCard.Text = "½ÌÊ¦¿¨";
            this.simpleButton_IDQueryTeaCard.Click += new System.EventHandler(this.simpleButton_IDQueryTeaCard_Click);
            // 
            // simpleButton_IDQuerySearch
            // 
            this.simpleButton_IDQuerySearch.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_IDQuerySearch.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_IDQuerySearch.Appearance.Options.UseFont = true;
            this.simpleButton_IDQuerySearch.Appearance.Options.UseForeColor = true;
            this.simpleButton_IDQuerySearch.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_IDQuerySearch.Image")));
            this.simpleButton_IDQuerySearch.Location = new System.Drawing.Point(216, 8);
            this.simpleButton_IDQuerySearch.Name = "simpleButton_IDQuerySearch";
            this.simpleButton_IDQuerySearch.Size = new System.Drawing.Size(91, 26);
            this.simpleButton_IDQuerySearch.TabIndex = 9;
            this.simpleButton_IDQuerySearch.Tag = 4;
            this.simpleButton_IDQuerySearch.Text = "²é   Ñ¯";
            // 
            // xtraTabPage_DataSynchAndReceive
            // 
            this.xtraTabPage_DataSynchAndReceive.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_DataSynchAndReceive.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_DataSynchAndReceive.Controls.Add(this.groupControl_DeviceView);
            this.xtraTabPage_DataSynchAndReceive.Controls.Add(this.groupControl_DataSynchReceiDesk);
            this.helpProvider_Help.SetHelpKeyword(this.xtraTabPage_DataSynchAndReceive, "Ê±¼äÍ¬²½ÓëÊý¾Ý½ÓÊÕ");
            this.helpProvider_Help.SetHelpNavigator(this.xtraTabPage_DataSynchAndReceive, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.xtraTabPage_DataSynchAndReceive.Name = "xtraTabPage_DataSynchAndReceive";
            this.helpProvider_Help.SetShowHelp(this.xtraTabPage_DataSynchAndReceive, true);
            this.xtraTabPage_DataSynchAndReceive.Size = new System.Drawing.Size(766, 511);
            this.xtraTabPage_DataSynchAndReceive.Text = "Ê±¼äÍ¬²½ÓëÊý¾Ý½ÓÊÕ";
            // 
            // groupControl_DeviceView
            // 
            this.groupControl_DeviceView.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_DeviceView.AppearanceCaption.Options.UseFont = true;
            this.groupControl_DeviceView.Controls.Add(this.gridControl_DeviceView);
            this.groupControl_DeviceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl_DeviceView.Location = new System.Drawing.Point(168, 0);
            this.groupControl_DeviceView.Name = "groupControl_DeviceView";
            this.groupControl_DeviceView.Size = new System.Drawing.Size(598, 511);
            this.groupControl_DeviceView.TabIndex = 4;
            this.groupControl_DeviceView.Text = "Éè±¸ä¯ÀÀ";
            // 
            // gridControl_DeviceView
            // 
            this.gridControl_DeviceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_DeviceView.Location = new System.Drawing.Point(2, 22);
            this.gridControl_DeviceView.MainView = this.gridView5;
            this.gridControl_DeviceView.Name = "gridControl_DeviceView";
            this.gridControl_DeviceView.Size = new System.Drawing.Size(594, 487);
            this.gridControl_DeviceView.TabIndex = 0;
            this.gridControl_DeviceView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView5});
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn21,
            this.gridColumn22});
            this.gridView5.GridControl = this.gridControl_DeviceView;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsBehavior.Editable = false;
            this.gridView5.OptionsCustomization.AllowFilter = false;
            this.gridView5.OptionsCustomization.AllowGroup = false;
            this.gridView5.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView5.OptionsView.ShowFooter = true;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "ÃÅ¿Ú»úµØÖ·";
            this.gridColumn21.FieldName = "machine_address";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 0;
            this.gridColumn21.Width = 102;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "ÃÅ¿Ú»úÈÝÁ¿";
            this.gridColumn22.FieldName = "machine_volumn";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 1;
            this.gridColumn22.Width = 475;
            // 
            // groupControl_DataSynchReceiDesk
            // 
            this.groupControl_DataSynchReceiDesk.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.groupControl_DataSynchReceiDesk.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.groupControl_DataSynchReceiDesk.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.groupControl_DataSynchReceiDesk.Appearance.Options.UseBackColor = true;
            this.groupControl_DataSynchReceiDesk.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_DataSynchReceiDesk.AppearanceCaption.Options.UseFont = true;
            this.groupControl_DataSynchReceiDesk.Controls.Add(this.notePanel_DataSynchReceiDesk);
            this.groupControl_DataSynchReceiDesk.Controls.Add(this.simpleButton_Date);
            this.groupControl_DataSynchReceiDesk.Controls.Add(this.simpleButton_GetMobile);
            this.groupControl_DataSynchReceiDesk.Controls.Add(this.simpleButton_FastDataReceive);
            this.groupControl_DataSynchReceiDesk.Controls.Add(this.simpleButton_StopDataReceive);
            this.groupControl_DataSynchReceiDesk.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl_DataSynchReceiDesk.Location = new System.Drawing.Point(0, 0);
            this.groupControl_DataSynchReceiDesk.Name = "groupControl_DataSynchReceiDesk";
            this.groupControl_DataSynchReceiDesk.Size = new System.Drawing.Size(168, 511);
            this.groupControl_DataSynchReceiDesk.TabIndex = 3;
            this.groupControl_DataSynchReceiDesk.Text = "Êý¾Ý¿ØÖÆÌ¨";
            this.groupControl_DataSynchReceiDesk.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl_DataSynchReceiDesk_Paint);
            // 
            // notePanel_DataSynchReceiDesk
            // 
            this.notePanel_DataSynchReceiDesk.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel_DataSynchReceiDesk.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel_DataSynchReceiDesk.ForeColor = System.Drawing.Color.Gray;
            this.notePanel_DataSynchReceiDesk.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_DataSynchReceiDesk.Location = new System.Drawing.Point(2, 22);
            this.notePanel_DataSynchReceiDesk.MaxRows = 5;
            this.notePanel_DataSynchReceiDesk.Name = "notePanel_DataSynchReceiDesk";
            this.notePanel_DataSynchReceiDesk.ParentAutoHeight = true;
            this.notePanel_DataSynchReceiDesk.Size = new System.Drawing.Size(164, 23);
            this.notePanel_DataSynchReceiDesk.TabIndex = 24;
            this.notePanel_DataSynchReceiDesk.TabStop = false;
            this.notePanel_DataSynchReceiDesk.Text = "ÄúÒªÍê³ÉÊ²Ã´£¿";
            // 
            // simpleButton_Date
            // 
            this.simpleButton_Date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_Date.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_Date.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_Date.Appearance.Options.UseFont = true;
            this.simpleButton_Date.Appearance.Options.UseForeColor = true;
            this.simpleButton_Date.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_Date.Image")));
            this.simpleButton_Date.Location = new System.Drawing.Point(10, 182);
            this.simpleButton_Date.Name = "simpleButton_Date";
            this.simpleButton_Date.Size = new System.Drawing.Size(148, 26);
            this.simpleButton_Date.TabIndex = 8;
            this.simpleButton_Date.Tag = 4;
            this.simpleButton_Date.Text = "Ê±¼äÍ¬²½";
            this.simpleButton_Date.Click += new System.EventHandler(this.simpleButton_Date_Click);
            // 
            // simpleButton_GetMobile
            // 
            this.simpleButton_GetMobile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_GetMobile.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_GetMobile.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_GetMobile.Appearance.Options.UseFont = true;
            this.simpleButton_GetMobile.Appearance.Options.UseForeColor = true;
            this.simpleButton_GetMobile.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_GetMobile.Image")));
            this.simpleButton_GetMobile.Location = new System.Drawing.Point(10, 56);
            this.simpleButton_GetMobile.Name = "simpleButton_GetMobile";
            this.simpleButton_GetMobile.Size = new System.Drawing.Size(148, 26);
            this.simpleButton_GetMobile.TabIndex = 12;
            this.simpleButton_GetMobile.Tag = 4;
            this.simpleButton_GetMobile.Text = "²éÑ¯/Ñ¡Ôñ³µÔØ»ú";
            this.simpleButton_GetMobile.Click += new System.EventHandler(this.simpleButton_GetMobile_Click);
            // 
            // simpleButton_FastDataReceive
            // 
            this.simpleButton_FastDataReceive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_FastDataReceive.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_FastDataReceive.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_FastDataReceive.Appearance.Options.UseFont = true;
            this.simpleButton_FastDataReceive.Appearance.Options.UseForeColor = true;
            this.simpleButton_FastDataReceive.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_FastDataReceive.Image")));
            this.simpleButton_FastDataReceive.Location = new System.Drawing.Point(10, 98);
            this.simpleButton_FastDataReceive.Name = "simpleButton_FastDataReceive";
            this.simpleButton_FastDataReceive.Size = new System.Drawing.Size(148, 26);
            this.simpleButton_FastDataReceive.TabIndex = 10;
            this.simpleButton_FastDataReceive.Tag = 4;
            this.simpleButton_FastDataReceive.Text = "¿ìËÙÊý¾Ý½ÓÊÕ";
            this.simpleButton_FastDataReceive.Click += new System.EventHandler(this.simpleButton_FastDataReceive_Click);
            // 
            // simpleButton_StopDataReceive
            // 
            this.simpleButton_StopDataReceive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_StopDataReceive.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_StopDataReceive.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_StopDataReceive.Appearance.Options.UseFont = true;
            this.simpleButton_StopDataReceive.Appearance.Options.UseForeColor = true;
            this.simpleButton_StopDataReceive.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_StopDataReceive.Image")));
            this.simpleButton_StopDataReceive.Location = new System.Drawing.Point(10, 140);
            this.simpleButton_StopDataReceive.Name = "simpleButton_StopDataReceive";
            this.simpleButton_StopDataReceive.Size = new System.Drawing.Size(148, 26);
            this.simpleButton_StopDataReceive.TabIndex = 11;
            this.simpleButton_StopDataReceive.Tag = 4;
            this.simpleButton_StopDataReceive.Text = "Í£Ö¹Êý¾Ý½ÓÊÕ";
            this.simpleButton_StopDataReceive.Click += new System.EventHandler(this.simpleButton_StopDataReceive_Click);
            // 
            // Timer_SendCardOverTime
            // 
            this.Timer_SendCardOverTime.SynchronizingObject = this;
            this.Timer_SendCardOverTime.Elapsed += new System.Timers.ElapsedEventHandler(this.Timer_SendCardOverTime_Elapsed);
            // 
            // Timer_ValidateCardOverTime
            // 
            this.Timer_ValidateCardOverTime.SynchronizingObject = this;
            this.Timer_ValidateCardOverTime.Elapsed += new System.Timers.ElapsedEventHandler(this.Timer_ValidateCardOverTime_Elapsed);
            // 
            // Timer_LeaveTime
            // 
            this.Timer_LeaveTime.SynchronizingObject = this;
            this.Timer_LeaveTime.Elapsed += new System.Timers.ElapsedEventHandler(this.Timer_LeaveTime_Elapsed);
            // 
            // timer_SychnDate
            // 
            this.timer_SychnDate.SynchronizingObject = this;
            this.timer_SychnDate.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_SychnDate_Elapsed);
            // 
            // CardManagement
            // 
            this.Controls.Add(this.xtraTabControl_CardMgmt);
            this.helpProvider_Help.SetHelpKeyword(this, "");
            this.Name = "CardManagement";
            this.helpProvider_Help.SetShowHelp(this, false);
            this.Size = new System.Drawing.Size(772, 540);
            this.Load += new System.EventHandler(this.CardManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_CardMgmt)).EndInit();
            this.xtraTabControl_CardMgmt.ResumeLayout(false);
            this.xtraTabPage_CardSent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Send_CardInfo)).EndInit();
            this.groupControl_Send_CardInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Send_CardInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Send_TeaCardMgmt)).EndInit();
            this.groupControl_Send_TeaCardMgmt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_TeaGrade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_TeaName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_TeaNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_TeaClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Send_StuCardMgmt)).EndInit();
            this.groupControl_Send_StuCardMgmt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_StuName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_StuClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_StuGrade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_StuNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Send_MyCardRec)).EndInit();
            this.groupControl_Send_MyCardRec.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SendCard1Date.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard1Date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard4Holder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard1Holder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard1Number.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard4Number.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard4Date.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard4Date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeCard5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard5Date.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard5Date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard5Number.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard5Holder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard2Date.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard2Date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard2Number.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeCard1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeCard3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard2Holder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeCard2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeCard4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard3Date.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard3Date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard3Number.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCard3Holder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_SendCardGrade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_SendCardStuNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_SendCardStuName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_SendCardClass.Properties)).EndInit();
            this.xtraTabPage_BatchSend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_BatchSendView)).EndInit();
            this.groupControl_BatchSendView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BatchSendView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_BatchSendSerCond)).EndInit();
            this.groupControl_BatchSendSerCond.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_BatchSendButtonGroup)).EndInit();
            this.groupControl_BatchSendButtonGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_BatchSendGrade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_BatchSendClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit3.Properties)).EndInit();
            this.xtraTabPage_CardLogout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Logout_TeaCardMgmt)).EndInit();
            this.groupControl_Logout_TeaCardMgmt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Logout_StuCardMgmt)).EndInit();
            this.groupControl_Logout_StuCardMgmt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Logout_StuName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Logout_StuClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Logout_StuGrade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Logout_StuNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Logout_MyCardRec)).EndInit();
            this.groupControl_Logout_MyCardRec.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Logout_CardInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.xtraTabPage_IDQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_IDQueryFastSer)).EndInit();
            this.groupControl_IDQueryFastSer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_IDQueryTeaNumberAndName)).EndInit();
            this.groupControl_IDQueryTeaNumberAndName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_IDQueryTeaName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_IDQueryTeaNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_TeaField)).EndInit();
            this.panelControl_TeaField.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_StuField)).EndInit();
            this.panelControl_StuField.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_IDQueryTimeAndCardNumber)).EndInit();
            this.groupControl_IDQueryTimeAndCardNumber.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_IDQueryCardNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_IDQueryEndTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_IDQueryEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_IDQueryBegTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_IDQueryBegTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_IDQueryNumberAndName)).EndInit();
            this.groupControl_IDQueryNumberAndName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_IDQueryStuName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_IDQueryStuNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_IDQueryGradeAndClass)).EndInit();
            this.groupControl_IDQueryGradeAndClass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_IDQueryStuClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_IDQueryStuGrade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_IDQueryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.xtraTabPage_DataSynchAndReceive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_DeviceView)).EndInit();
            this.groupControl_DeviceView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DeviceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_DataSynchReceiDesk)).EndInit();
            this.groupControl_DataSynchReceiDesk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Timer_SendCardOverTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Timer_ValidateCardOverTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Timer_LeaveTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer_SychnDate)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region ¸ü»»²éÑ¯Ãæ°å
		//Ñ§Éú·¢¿¨
		private void simpleButton_Send_StuCard_Click(object sender, System.EventArgs e)
		{
			notePanel4.Text = " Ñ§  ºÅ:";
			notePanel1.Text = " Äê  ¼¶:";
			notePanel5.Text = " °à  ¼¶:";

			textEdit_Send_StuName.Text = string.Empty;
			textEdit_Send_StuNumber.Text = string.Empty;
			dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
			dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;

			GradeInfoBinding();

			if(!searchStu)
			{
				searchStu = true;
			}

			SendCardControlClearBinding();

			CardInfo = new CardInfoSystem().GetStuCardInfoList();//Ñ§Éú¿¨
			CardView = CardInfo.Tables[0].DefaultView;

			StuSendCardControlBinding();
			gridControl_Send_CardInfo.DataSource = CardView;
			dataNavigator_CardSent.DataSource = CardView;

			if(gridView1.RowCount>0)
			{
				string selectedStuID = (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_stuID"]).ToString();
				cardDetails = new CardInfoSystem().GetStuCardByID(selectedStuID);
				DisplayCardInfo(cardDetails);
			}

			groupControl_Send_StuCardMgmt.Visible = true;
			groupControl_Send_TeaCardMgmt.Visible = false;
		}

		//½ÌÊ¦·¢¿¨
		private void simpleButton_Send_TeaCard_Click(object sender, System.EventArgs e)
		{	
			notePanel4.Text = " ¹¤  ºÅ:";
			notePanel1.Text = " ²¿  ÃÅ:";
			notePanel5.Text = " Ö°  Îñ:";
			textEdit_Send_TeaName.Text = string.Empty;
			textEdit_Send_TeaNumber.Text = string.Empty;
			dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
			dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;

			GradeInfoBinding();

			if(searchStu)
			{
				searchStu = false;
			}

			SendCardControlClearBinding();

			CardInfo = new CardInfoSystem().GetTeaCardInfoList();//½ÌÊ¦¿¨
			CardView = CardInfo.Tables[0].DefaultView;

			TeaSendCardControlBingding();
			gridControl_Send_CardInfo.DataSource = CardView;
			dataNavigator_CardSent.DataSource = CardView;

			if(gridView1.RowCount>0)
			{
				string selectedStuID = (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["T_ID"]).ToString();
				cardDetails = new CardInfoSystem().GetTeaCardByID(selectedStuID);
				DisplayCardInfo(cardDetails);
			}

			groupControl_Send_StuCardMgmt.Visible = false;
			groupControl_Send_TeaCardMgmt.Visible = true;
		}

		//Ñ§ÉúÍËÑ§
		private void simpleButton_Logout_StuCard_Click(object sender, System.EventArgs e)
		{
			textEdit_Logout_StuName.Text = string.Empty;
			textEdit_Logout_StuNumber.Text = string.Empty;

			LogoutCardGradeInfoBinding();

			if(!leaveSearchStu)
			{
				leaveSearchStu = true;
			}

			LeaveCardInfo = new CardInfoSystem().GetStuCardInfoList();//Ñ§Éú
			LeaveCardView = LeaveCardInfo.Tables[0].DefaultView;

			StuLeaveControlBinding();

			gridControl_Logout_CardInfo.DataSource = LeaveCardView;
			dataNavigator_CardLogout.DataSource = LeaveCardView;

			groupControl_Logout_StuCardMgmt.Visible = true;
			groupControl_Logout_TeaCardMgmt.Visible = false;
		}

		//½ÌÊ¦ÍËÐÝ
		private void simpleButton_Logout_TeaCard_Click(object sender, System.EventArgs e)
		{
			textEdit1.Text = string.Empty;
			textEdit2.Text=  string.Empty;
			
			LogoutCardGradeInfoBinding();

			if(leaveSearchStu)
			{
				leaveSearchStu = false;
			}

			LeaveCardInfo = new CardInfoSystem().GetTeaCardInfoList();//½ÌÊ¦
			LeaveCardView = LeaveCardInfo.Tables[0].DefaultView;

			TeaLeaveControlBinding();

			gridControl_Logout_CardInfo.DataSource = LeaveCardView;
			dataNavigator_CardLogout.DataSource = LeaveCardView;

			groupControl_Logout_TeaCardMgmt.Visible = true;
			groupControl_Logout_StuCardMgmt.Visible = false;
		}

		private void simpleButton_IDQueryStuCard_Click(object sender, System.EventArgs e)
		{
			panelControl_StuField.Visible = true;
			panelControl_TeaField.Visible = false;
			GroupPanelClear();
		}

		private void simpleButton_IDQueryTeaCard_Click(object sender, System.EventArgs e)
		{
			panelControl_TeaField.Visible = true;
			panelControl_StuField.Visible = false;
			GroupPanelClear();
		}

		private void notePanel_IDQueryGradeAndClass_Click(object sender, System.EventArgs e)
		{
			groupControl_IDQueryGradeAndClass.Visible  = true;
			groupControl_IDQueryNumberAndName.Visible = false;
			groupControl_IDQueryTeaNumberAndName.Visible = false;
			groupControl_IDQueryTimeAndCardNumber.Visible = false;
		}

		private void notePanel_IDQueryNumberAndName_Click(object sender, System.EventArgs e)
		{
			groupControl_IDQueryNumberAndName.Visible = true;
			groupControl_IDQueryGradeAndClass.Visible  = false;
			groupControl_IDQueryTeaNumberAndName.Visible = false;
			groupControl_IDQueryTimeAndCardNumber.Visible = false;
		}

		private void notePanel_IDQueryTimeAndCardNumber_Click(object sender, System.EventArgs e)
		{
			groupControl_IDQueryTimeAndCardNumber.Visible = true;
			groupControl_IDQueryNumberAndName.Visible = false;
			groupControl_IDQueryGradeAndClass.Visible  = false;
			groupControl_IDQueryTeaNumberAndName.Visible = false;
		}

		private void notePanel_IDQueryTeaNumberAndName_Click(object sender, System.EventArgs e)
		{
			groupControl_IDQueryTeaNumberAndName.Visible = true;
			groupControl_IDQueryTimeAndCardNumber.Visible = false;
			groupControl_IDQueryNumberAndName.Visible = false;
			groupControl_IDQueryGradeAndClass.Visible  = false;
		}

		private void notePanel_IDQueryTeaTimeAndCardNumber_Click(object sender, System.EventArgs e)
		{
			groupControl_IDQueryTimeAndCardNumber.Visible = true;
			groupControl_IDQueryNumberAndName.Visible = false;
			groupControl_IDQueryGradeAndClass.Visible  = false;
			groupControl_IDQueryTeaNumberAndName.Visible = false;
		}

		private void GroupPanelClear()
		{
			groupControl_IDQueryNumberAndName.Visible = false;
			groupControl_IDQueryTeaNumberAndName.Visible = false;
			groupControl_IDQueryTimeAndCardNumber.Visible = false;
			groupControl_IDQueryGradeAndClass.Visible = false;
		}
		#endregion

		#region ³õÊ¼ÐÅÏ¢¼ÓÔØ
		private void CardManagement_Load(object sender, System.EventArgs e)
		{
			this.LoginForm = (Login)(this.ParentForm.Owner);

			LoginForm.SendCardSuccessed += new CPTT.WinUI.Login.SendCardSuccessedHandler(loginForm_SendCardSuccessed);
			LoginForm.SendCardFailed += new CPTT.WinUI.Login.SendCardFailedHandler(LoginForm_SendCardFailed);
			LoginForm.ValidateCardInfoReturn += new CPTT.WinUI.Login.ValidateCardInfoReturnHandler(LoginForm_ValidateCardInfoReturn);
			LoginForm.LogtouCardSuccessed += new CPTT.WinUI.Login.LogoutCardSuccessedHandler(LoginForm_LogtouCardSuccessed);
			LoginForm.SynchTimeSuccessed += new CPTT.WinUI.Login.SynchTimeSuccessedHandler(LoginForm_SynchTimeSuccessed);
			LoginForm.SendUserNameSucceed += new CPTT.WinUI.Login.SendUserNameSuccessHandler(LoginForm_SendUserNameSucceed);

			#region ¼ÓÔØ¿¨°æ±¾ÐÅÏ¢
			InitCardPanel();
			#endregion

		}
		#endregion

		#region ÏÔÊ¾¿¨ÐÅÏ¢
		private void DisplayCardInfo(DataSet cardDetails)
		{
			int cardVersion = SystemFramework.Util.CardVersion;

			if(searchStu)
			{
				//initial the control value
				SendCard1Number.Text = string.Empty;
				notePanel_Send_Card1stHolder.Visible = true;
				SendCard1Holder.Visible = true;
				SendCard1Holder.Text = "Ò»ºÅ¿¨";
				SendCard1Date.DateTime = DateTime.Now;
				SendCard1Number.Enabled = true;
				removeCard1.Checked = false;

				SendCard2Number.Text = string.Empty;
				//notePanel3.Visible =   true;
				notePanel_Send_Card2ndNumber.Visible = cardVersion >= 2;
				SendCard2Holder.Visible = true;
				SendCard2Holder.Text = "¶þºÅ¿¨";
				SendCard2Date.DateTime = DateTime.Now;
				SendCard2Number.Enabled = true;
				removeCard2.Checked = false;

				SendCard3Number.Text = string.Empty;
				//notePanel18.Visible = true;
				notePanel_Send_Card3rdNumber.Visible = cardVersion >= 3;
				SendCard3Holder.Visible = true;
				SendCard3Holder.Text = "ÈýºÅ¿¨";
				SendCard3Date.DateTime = DateTime.Now;
				SendCard3Number.Enabled = true;
				removeCard3.Checked = false;

				SendCard4Number.Text = string.Empty;
				//notePanel23.Visible = true;
				notePanel_Send_Card4thNumber.Visible = cardVersion >= 4;
				SendCard4Holder.Visible = true;
				SendCard4Holder.Text = "ËÄºÅ¿¨";
				SendCard4Date.DateTime = DateTime.Now;
				SendCard4Number.Enabled = true;
				removeCard4.Checked = false;

				SendCard5Number.Text = string.Empty;
				//notePanel26.Visible = true;
				notePanel_Send_Card5thNumber.Visible = cardVersion >= 5;
				SendCard5Holder.Visible = true;
				SendCard5Holder.Text = "ÎåºÅ¿¨";
				SendCard5Date.DateTime = DateTime.Now;
				SendCard5Number.Enabled = true;
				removeCard5.Checked = false;

				if(cardDetails.Tables[0].Rows.Count>0)
				{
					foreach(DataRow row in cardDetails.Tables[0].Rows)
					{
						Int16 cardSeq = Convert.ToInt16(row["info_stuCardSeq"]);
					
						switch(cardSeq)
						{
							case 1:
								SendCard1Number.Text = row["info_stuCardNumber"].ToString();
								SendCard1Holder.Text = "Ò»ºÅ¿¨";
								SendCard1Date.DateTime = Convert.ToDateTime(row["info_stuCardSendDate"]);
								removeCard1.Enabled = true;
								SendCard1Number.Enabled = false;
								break;
							case 2:
								SendCard2Number.Text = row["info_stuCardNumber"].ToString();
								SendCard2Holder.Text = "¶þºÅ¿¨";
								SendCard2Date.DateTime = Convert.ToDateTime(row["info_stuCardSendDate"]);
								removeCard2.Enabled = true;
								SendCard2Number.Enabled = false;
								break;
							case 3:
								SendCard3Number.Text = row["info_stuCardNumber"].ToString();
								SendCard3Holder.Text = "ÈýºÅ¿¨";
								SendCard3Date.DateTime = Convert.ToDateTime(row["info_stuCardSendDate"]);
								removeCard3.Enabled = true;
								SendCard3Number.Enabled = false;
								break;
							case 4:
								SendCard4Number.Text = row["info_stuCardNumber"].ToString();
								SendCard4Holder.Text = "ËÄºÅ¿¨";
								SendCard4Date.DateTime = Convert.ToDateTime(row["info_stuCardSendDate"]);
								removeCard4.Enabled = true;
								SendCard4Number.Enabled = false;
								break;
							case 5:
								SendCard5Number.Text = row["info_stuCardNumber"].ToString();
								SendCard5Holder.Text = "ÎåºÅ¿¨";
								SendCard5Date.DateTime = Convert.ToDateTime(row["info_stuCardSendDate"]);
								removeCard5.Enabled = true;
								SendCard5Number.Enabled = false;
								break;

						}
					}

					InitCardPanel();
				}
				else
				{
					SendCard1Number.Text = string.Empty;
					notePanel_Send_Card1stHolder.Visible = true;
					SendCard1Holder.Visible = true;
					SendCard1Holder.Text = "Ò»ºÅ¿¨";
					SendCard3Date.DateTime = DateTime.Now;
					removeCard1.Enabled = false;

					SendCard2Number.Text = string.Empty;
					//notePanel3.Visible = true;
					notePanel_Send_Card2ndNumber.Visible = cardVersion >= 2;
					SendCard2Holder.Visible = true;
					SendCard2Holder.Text = "¶þºÅ¿¨";
					SendCard3Date.DateTime = DateTime.Now;
					removeCard2.Enabled = false;

					SendCard3Number.Text = string.Empty;
					//notePanel18.Visible = true;
					notePanel_Send_Card3rdNumber.Visible = cardVersion >= 3;
					SendCard3Holder.Visible = true;
					SendCard3Holder.Text = "ÈýºÅ¿¨";
					SendCard3Date.DateTime = DateTime.Now;
					removeCard3.Enabled = false;

					SendCard4Number.Text = string.Empty;
					//notePanel23.Visible = true;
					notePanel_Send_Card4thNumber.Visible = cardVersion >= 4;
					SendCard4Holder.Visible = true;
					SendCard4Holder.Text = "ËÄºÅ¿¨";
					SendCard3Date.DateTime = DateTime.Now;
					removeCard4.Enabled = false;

					SendCard5Number.Text = string.Empty;
					//notePanel26.Visible = true;
					notePanel_Send_Card5thNumber.Visible = cardVersion >= 5;
					SendCard5Holder.Visible = true;
					SendCard5Holder.Text = "ÎåºÅ¿¨";
					SendCard3Date.DateTime = DateTime.Now;
					removeCard5.Enabled = false;

					InitCardPanel();
				}


			}
			else
			{
				SendCard1Number.Text = string.Empty;
				notePanel_Send_Card1stHolder.Visible = false;
				SendCard1Holder.Visible = false;
				SendCard1Date.DateTime = DateTime.Now;
				SendCard1Number.Enabled = true;
				removeCard1.Checked = false;

				SendCard2Number.Text = string.Empty;
				//notePanel3.Visible = false;
				notePanel_Send_Card2ndHolder.Visible = false;
				SendCard2Holder.Visible = false;
				SendCard2Holder.Text = string.Empty;
				SendCard2Date.DateTime = DateTime.Now;
				SendCard2Number.Enabled = true;
				removeCard2.Checked = false;

				SendCard3Number.Text = string.Empty;
				//notePanel18.Visible = false;
				notePanel_Send_Card3rdHolder.Visible = false;
				SendCard3Holder.Visible = false;
				SendCard3Holder.Text = string.Empty;
				SendCard3Date.DateTime = DateTime.Now;
				SendCard3Number.Enabled = true;
				removeCard3.Checked = false;

				SendCard4Number.Text = string.Empty;
				//notePanel23.Visible = false;
				notePanel_Send_Card4thHolder.Visible = false;
				SendCard4Holder.Visible = false;
				SendCard4Holder.Text = string.Empty;
				SendCard4Date.DateTime = DateTime.Now;
				SendCard4Number.Enabled = true;
				removeCard4.Checked = false;

				SendCard5Number.Text = string.Empty;
				//notePanel26.Visible = false;
				notePanel_Send_Card5thHolder.Visible = false;
				SendCard5Holder.Visible = false;
				SendCard5Holder.Text = string.Empty;
				SendCard5Date.DateTime = DateTime.Now;
				SendCard5Number.Enabled = true;
				removeCard5.Checked = false;

				if(cardDetails.Tables[0].Rows.Count>0)
				{
					foreach(DataRow row in cardDetails.Tables[0].Rows)
					{
						Int16 cardSeq = Convert.ToInt16(row["info_teaCardSeq"]);
					
						switch(cardSeq)
						{
							case 1:
								SendCard1Number.Text = row["info_teaCardNumber"].ToString();
								SendCard1Date.DateTime = Convert.ToDateTime(row["info_teaCardSendDate"]);
								removeCard1.Enabled = true;
								SendCard1Number.Enabled = false;
								break;
							case 2:
								SendCard2Number.Text = row["info_teaCardNumber"].ToString();
								SendCard2Date.DateTime = Convert.ToDateTime(row["info_teaCardSendDate"]);
								removeCard2.Enabled = true;
								SendCard2Number.Enabled = false;
								break;
							case 3:
								SendCard3Number.Text = row["info_teaCardNumber"].ToString();
								SendCard3Date.DateTime = Convert.ToDateTime(row["info_teaCardSendDate"]);
								removeCard3.Enabled = true;
								SendCard3Number.Enabled = false;
								break;
							case 4:
								SendCard4Number.Text = row["info_teaCardNumber"].ToString();
								SendCard4Date.DateTime = Convert.ToDateTime(row["info_teaCardSendDate"]);
								removeCard4.Enabled = true;
								SendCard4Number.Enabled = false;
								break;
							case 5:
								SendCard5Number.Text = row["info_teaCardNumber"].ToString();
								SendCard5Date.DateTime = Convert.ToDateTime(row["info_teaCardSendDate"]);
								removeCard5.Enabled = true;
								SendCard5Number.Enabled = false;
								break;

						}
					}
				}
				else
				{
					SendCard1Number.Text = string.Empty;
					SendCard3Date.DateTime = DateTime.Now;
					removeCard1.Enabled = false;

					SendCard2Number.Text = string.Empty;
					SendCard3Date.DateTime = DateTime.Now;
					removeCard2.Enabled = false;

					SendCard3Number.Text = string.Empty;
					SendCard3Date.DateTime = DateTime.Now;
					removeCard3.Enabled = false;

					SendCard4Number.Text = string.Empty;
					SendCard3Date.DateTime = DateTime.Now;
					removeCard4.Enabled = false;

					SendCard5Number.Text = string.Empty;
					SendCard3Date.DateTime = DateTime.Now;
					removeCard5.Enabled = false;
				}
			}
		}
		#endregion

		#region ·¢¿¨Êý¾Ý°ó¶¨
		private void StuSendCardControlBinding()
		{	
//			gridView1.Columns.Clear();

			gridColumn1.Caption = "Ñ§ºÅ";
			gridColumn1.FieldName = "info_stuNumber";
			gridColumn2.Caption = "ÐÕÃû";
			gridColumn2.FieldName = "info_stuName";
			gridColumn3.Caption = "Äê¼¶";
			gridColumn3.FieldName = "info_gradeName";
			gridColumn4.Caption = "°à¼¶";
			gridColumn4.FieldName = "info_className";
			gridColumn5.Caption = "ÐÔ±ð";
			gridColumn5.FieldName = "info_stuGender";
			gridColumn6.Caption = "Ñ§ÉúID";
			gridColumn6.FieldName = "info_stuID";
			gridColumn6.Visible = false;

			textEdit_SendCardStuName.DataBindings.Add("EditValue",CardView,"info_stuName");
			combo_SendCardGrade.DataBindings.Add("EditValue",CardView,"info_gradeName");
			textEdit_SendCardStuNumber.DataBindings.Add("EditValue",CardView,"info_stuNumber");
			combo_SendCardClass.DataBindings.Add("EditValue",CardView,"info_className");
		}

		private void TeaSendCardControlBingding()
		{
//			gridView1.Columns.Clear();

			gridColumn1.Caption = "¹¤ºÅ";
			gridColumn1.FieldName = "T_Number";
			gridColumn2.Caption = "ÐÕÃû";
			gridColumn2.FieldName = "T_Name";
			gridColumn3.Caption = "²¿ÃÅ";
			gridColumn3.FieldName = "T_Depart";
			gridColumn4.Caption = "¸ÚÎ»";
			gridColumn4.FieldName = "T_Duty";
			gridColumn5.Caption = "ÐÔ±ð";
			gridColumn5.FieldName = "T_Sex";
			gridColumn6.Caption = "½ÌÊ¦ID";
			gridColumn6.FieldName = "T_ID";
			gridColumn6.Visible = false;

			textEdit_SendCardStuName.DataBindings.Add("EditValue",CardView,"T_Name");
			combo_SendCardGrade.DataBindings.Add("EditValue",CardView,"T_Depart");
			textEdit_SendCardStuNumber.DataBindings.Add("EditValue",CardView,"T_Number");
			combo_SendCardClass.DataBindings.Add("EditValue",CardView,"T_Duty");
		}

		private void SendCardControlClearBinding()
		{
			textEdit_SendCardStuName.DataBindings.Clear();
			combo_SendCardGrade.DataBindings.Clear();
			textEdit_SendCardStuNumber.DataBindings.Clear();
			combo_SendCardClass.DataBindings.Clear();
		}

		private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			string selectedStuID = string.Empty;
			if(gridView1.RowCount==0)
				return;

			if(searchStu)
			{
				selectedStuID = (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_stuID"]).ToString();
				cardDetails = new CardInfoSystem().GetStuCardByID(selectedStuID);
			}
			else
			{
				selectedStuID = (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["T_ID"]).ToString();
				cardDetails = new CardInfoSystem().GetTeaCardByID(selectedStuID);
			}
			DisplayCardInfo(cardDetails);
		}

		#endregion

		#region ÍËÑ§Êý¾Ý°ó¶¨
		private void StuLeaveControlBinding()
		{	
//			gridView1.Columns.Clear();

			gridColumn15.Caption = "Ñ§ºÅ";
			gridColumn15.FieldName = "info_stuNumber";
			gridColumn16.Caption = "ÐÕÃû";
			gridColumn16.FieldName = "info_stuName";
			gridColumn17.Caption = "Äê¼¶";
			gridColumn17.FieldName = "info_gradeName";
			gridColumn18.Caption = "°à¼¶";
			gridColumn18.FieldName = "info_className";
			gridColumn19.Caption = "ÐÔ±ð";
			gridColumn19.FieldName = "info_stuGender";
			gridColumn20.Caption = "Ñ§ÉúID";
			gridColumn20.FieldName = "info_stuID";
			gridColumn20.Visible = false;
		}

		private void TeaLeaveControlBinding()
		{
//			gridView1.Columns.Clear();

			gridColumn15.Caption = "¹¤ºÅ";
			gridColumn15.FieldName = "T_Number";
			gridColumn16.Caption = "ÐÕÃû";
			gridColumn16.FieldName = "T_Name";
			gridColumn17.Caption = "²¿ÃÅ";
			gridColumn17.FieldName = "T_Depart";
			gridColumn18.Caption = "¸ÚÎ»";
			gridColumn18.FieldName = "T_Duty";
			gridColumn19.Caption = "ÐÔ±ð";
			gridColumn19.FieldName = "T_Sex";
			gridColumn20.Caption = "½ÌÊ¦ID";
			gridColumn20.FieldName = "T_ID";
			gridColumn20.Visible = false;
		}
		#endregion

		#region comboBoxÄê¼¶°à¼¶°ó¶¨&¹ýÂËCardView
		private void GradeInfoBinding()
		{
			comboBoxEdit_Send_StuGrade.Properties.Items.Clear();
			comboBoxEdit_Send_TeaGrade.Properties.Items.Clear();
			combo_SendCardGrade.Properties.Items.Clear();

			comboBoxEdit_Send_StuGrade.Properties.Items.AddRange(new object[]{"È«²¿"});
			comboBoxEdit_Send_TeaGrade.Properties.Items.AddRange(new object[]{"È«²¿"});
			combo_SendCardGrade.Properties.Items.AddRange(new object[]{"È«²¿"});

			comboBoxEdit_Send_StuGrade.SelectedItem = "È«²¿";
			comboBoxEdit_Send_TeaGrade.SelectedItem = "È«²¿";
			combo_SendCardGrade.SelectedItem = "È«²¿";

			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_Send_StuGrade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
				comboBoxEdit_Send_TeaGrade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
				combo_SendCardGrade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}
		}

		private void BatchSendCardGradeInfoBinding()
		{
			comboBoxEdit_BatchSendGrade.Properties.Items.Clear();
			comboBoxEdit_BatchSendGrade.Properties.Items.AddRange(new object[]{"È«²¿"});
			comboBoxEdit_BatchSendGrade.SelectedItem = "È«²¿";

			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_BatchSendGrade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}
		}

		private void comboBoxEdit_BatchSendGrade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_BatchSendClass.Properties.Items.Clear();
			comboBoxEdit_BatchSendClass.Properties.Items.AddRange(new object[]{"È«²¿"});
			comboBoxEdit_BatchSendClass.SelectedItem = "È«²¿";
			if(getStuInfoByCondition.getGradeInfo(comboBoxEdit_BatchSendGrade.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
			{
				//¸ù¾ÝÄê¼¶Ñ¡Ôñ»ñÈ¡Äê¼¶±àºÅ
				getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_BatchSendGrade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_BatchSendClass.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}

			string rowFilter = string.Empty;

			if(batchSearchStu)
			{
				if(comboBoxEdit_BatchSendGrade.SelectedItem.ToString().Equals("È«²¿"))
				{
					rowFilter = rowFilter + "info_gradeName like '%'";
				}
				else
				{
					rowFilter = rowFilter + "info_gradeName like '%"+
						comboBoxEdit_BatchSendGrade.SelectedItem.ToString()+"%'";
				}

				if(comboBoxEdit_BatchSendClass.SelectedItem.ToString().Equals("È«²¿"))
				{
					rowFilter = rowFilter + " and info_className like '%'";
				}
				else
				{
					rowFilter = rowFilter + " and info_className like '%"+
						comboBoxEdit_BatchSendClass.SelectedItem.ToString()+"%'";
				}

				if(comboBoxEdit3.SelectedItem.ToString().EndsWith("È«²¿"))
				{
					BatchCardInfo = new CardInfoSystem().GetBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter;
				}
				else if(comboBoxEdit3.SelectedItem.ToString().EndsWith("´ý·¢¿¨"))
				{
					BatchCardInfo = new CardInfoSystem().GetBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter + " and info_stuCardState = 1";
				}
				else if(comboBoxEdit3.SelectedItem.ToString().EndsWith("ÒÑ·¢¿¨"))
				{
					BatchCardInfo = new CardInfoSystem().GetBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter + " and info_stuCardState = 0";
				}
				else
				{
					BatchCardInfo = new CardInfoSystem().GetNoCardStudents();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
				}	
			}
			else
			{
				if(comboBoxEdit_BatchSendGrade.SelectedItem.ToString().Equals("È«²¿"))
				{
					rowFilter = rowFilter + "T_Depart like '%'";
				}
				else
				{
					rowFilter = rowFilter + "T_Depart like '%"+
						comboBoxEdit_BatchSendGrade.SelectedItem.ToString()+"%'";
				}

				if(comboBoxEdit_BatchSendClass.SelectedItem.ToString().Equals("È«²¿"))
				{
					rowFilter = rowFilter + " and T_Duty like '%'";
				}
				else
				{
					rowFilter = rowFilter + " and T_Duty like '%"+
						comboBoxEdit_BatchSendClass.SelectedItem.ToString()+"%'";
				}

				if(comboBoxEdit3.SelectedItem.ToString().EndsWith("È«²¿"))
				{
					BatchCardInfo = new CardInfoSystem().GetTeaBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter;
				}
				else if(comboBoxEdit3.SelectedItem.ToString().EndsWith("´ý·¢¿¨"))
				{
					BatchCardInfo = new CardInfoSystem().GetTeaBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter + " and info_teaCardState = 1";
				}
				else if(comboBoxEdit3.SelectedItem.ToString().EndsWith("ÒÑ·¢¿¨"))
				{
					BatchCardInfo = new CardInfoSystem().GetTeaBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter + " and info_teaCardState = 0";
				}
				else
				{
					BatchCardInfo = new CardInfoSystem().GetNoCardTeachers();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
				}
			}

			BatchCardView.RowFilter = rowFilter;
			gridControl_BatchSendView.DataSource = BatchCardView;
		}

		private void comboBoxEdit_BatchSendClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string rowFilter = string.Empty;

			if(batchSearchStu)
			{
				if(comboBoxEdit_BatchSendGrade.SelectedItem.ToString().Equals("È«²¿"))
				{
					rowFilter = rowFilter + "info_gradeName like '%'";
				}
				else
				{
					rowFilter = rowFilter + "info_gradeName like '%"+
						comboBoxEdit_BatchSendGrade.SelectedItem.ToString()+"%'";
				}

				if(comboBoxEdit_BatchSendClass.SelectedItem.ToString().Equals("È«²¿"))
				{
					rowFilter = rowFilter + " and info_className like '%'";
				}
				else
				{
					rowFilter = rowFilter + " and info_className like '%"+
						comboBoxEdit_BatchSendClass.SelectedItem.ToString()+"%'";
				}

				if(comboBoxEdit3.SelectedItem.ToString().EndsWith("È«²¿"))
				{
					BatchCardInfo = new CardInfoSystem().GetBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter;
				}
				else if(comboBoxEdit3.SelectedItem.ToString().EndsWith("´ý·¢¿¨"))
				{
					BatchCardInfo = new CardInfoSystem().GetBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter + " and info_stuCardState = 1";
				}
				else if(comboBoxEdit3.SelectedItem.ToString().EndsWith("ÒÑ·¢¿¨"))
				{
					BatchCardInfo = new CardInfoSystem().GetBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter + " and info_stuCardState = 0";
				}
				else
				{
					BatchCardInfo = new CardInfoSystem().GetNoCardStudents();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
				}	
			}
			else
			{
				if(comboBoxEdit_BatchSendGrade.SelectedItem.ToString().Equals("È«²¿"))
				{

					rowFilter = rowFilter + "T_Depart like '%'";
				}
				else
				{
					rowFilter = rowFilter + "T_Depart like '%"+
						comboBoxEdit_BatchSendGrade.SelectedItem.ToString()+"%'";
				}

				if(comboBoxEdit_BatchSendClass.SelectedItem.ToString().Equals("È«²¿"))
				{
					rowFilter = rowFilter + " and T_Duty like '%'";
				}
				else
				{
					rowFilter = rowFilter + " and T_Duty like '%"+
						comboBoxEdit_BatchSendClass.SelectedItem.ToString()+"%'";
				}

				if(comboBoxEdit3.SelectedItem.ToString().EndsWith("È«²¿"))
				{
					BatchCardInfo = new CardInfoSystem().GetTeaBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter;
				}
				else if(comboBoxEdit3.SelectedItem.ToString().EndsWith("´ý·¢¿¨"))
				{
					BatchCardInfo = new CardInfoSystem().GetTeaBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter + " and info_teaCardState = 1";
				}
				else if(comboBoxEdit3.SelectedItem.ToString().EndsWith("ÒÑ·¢¿¨"))
				{
					BatchCardInfo = new CardInfoSystem().GetTeaBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter + " and info_teaCardState = 0";
				}
				else
				{
					BatchCardInfo = new CardInfoSystem().GetNoCardTeachers();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
				}
			}

			BatchCardView.RowFilter = rowFilter;
			gridControl_BatchSendView.DataSource = BatchCardView;
		}

		private void comboBoxEdit3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string rowFilter = string.Empty;

			if(batchSearchStu)
			{
				if(comboBoxEdit_BatchSendGrade.SelectedItem.ToString().Equals("È«²¿"))
				{
					rowFilter = rowFilter + "info_gradeName like '%'";
				}
				else
				{
					rowFilter = rowFilter + "info_gradeName like '%"+
						comboBoxEdit_BatchSendGrade.SelectedItem.ToString()+"%'";
				}

				if(comboBoxEdit_BatchSendClass.SelectedItem.ToString().Equals("È«²¿"))
				{
					rowFilter = rowFilter + " and info_className like '%'";
				}
				else
				{
					rowFilter = rowFilter + " and info_className like '%"+
						comboBoxEdit_BatchSendClass.SelectedItem.ToString()+"%'";
				}

				if(comboBoxEdit3.SelectedItem.ToString().EndsWith("È«²¿"))
				{
					BatchCardInfo = new CardInfoSystem().GetBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter;
				}
				else if(comboBoxEdit3.SelectedItem.ToString().EndsWith("´ý·¢¿¨"))
				{
					BatchCardInfo = new CardInfoSystem().GetBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter + " and info_stuCardState = 1";
				}
				else if(comboBoxEdit3.SelectedItem.ToString().EndsWith("ÒÑ·¢¿¨"))
				{
					BatchCardInfo = new CardInfoSystem().GetBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter + " and info_stuCardState = 0";
				}
				else
				{
					BatchCardInfo = new CardInfoSystem().GetNoCardStudents();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
				}	
			}
			else
			{
				if(comboBoxEdit_BatchSendGrade.SelectedItem.ToString().Equals("È«²¿"))
				{
					rowFilter = rowFilter + "T_Depart like '%'";
				}
				else
				{
					rowFilter = rowFilter + "T_Depart like '%"+
						comboBoxEdit_BatchSendGrade.SelectedItem.ToString()+"%'";
				}

				if(comboBoxEdit_BatchSendClass.SelectedItem.ToString().Equals("È«²¿"))
				{
					rowFilter = rowFilter + " and T_Duty like '%'";
				}
				else
				{
					rowFilter = rowFilter + " and T_Duty like '%"+
						comboBoxEdit_BatchSendClass.SelectedItem.ToString()+"%'";
				}

				if(comboBoxEdit3.SelectedItem.ToString().EndsWith("È«²¿"))
				{
					BatchCardInfo = new CardInfoSystem().GetTeaBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter;
				}
				else if(comboBoxEdit3.SelectedItem.ToString().EndsWith("´ý·¢¿¨"))
				{
					BatchCardInfo = new CardInfoSystem().GetTeaBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter + " and info_teaCardState = 1";
				}
				else if(comboBoxEdit3.SelectedItem.ToString().EndsWith("ÒÑ·¢¿¨"))
				{
					BatchCardInfo = new CardInfoSystem().GetTeaBatchCardInfo();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
					rowFilter = rowFilter + " and info_teaCardState = 0";
				}
				else
				{
					BatchCardInfo = new CardInfoSystem().GetNoCardTeachers();
					BatchCardView = BatchCardInfo.Tables[0].DefaultView;
				}
			}

			BatchCardView.RowFilter = rowFilter;
			gridControl_BatchSendView.DataSource = BatchCardView;
		}

		private void comboBoxEdit_Send_StuGrade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_Send_StuClass.Properties.Items.Clear();
			comboBoxEdit_Send_StuClass.Properties.Items.AddRange(new object[]{"È«²¿"});
			comboBoxEdit_Send_StuClass.SelectedItem = "È«²¿";
			if(getStuInfoByCondition.getGradeInfo(comboBoxEdit_Send_StuGrade.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
			{
				//¸ù¾ÝÄê¼¶Ñ¡Ôñ»ñÈ¡Äê¼¶±àºÅ
				getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_Send_StuClass.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}

			//¸ù¾ÝÄê¼¶²éÑ¯ËùÑ¡ÐÅÏ¢
			if(!comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Equals("È«²¿"))
			{
				SelectStuCardInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_StuClass
					.SelectedItem.ToString().Trim());
			}
			else
			{
				SelectStuCardInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					string.Empty,comboBoxEdit_Send_StuClass.SelectedItem.ToString().Trim());
			}
		}

		//¸ù¾Ý°à¼¶²éÑ¯ËùÑ¡ÐÅÏ¢
		private void comboBoxEdit_Send_StuClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!comboBoxEdit_Send_StuClass.SelectedItem.ToString().Equals("È«²¿"))
			{
				SelectStuCardInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_StuClass
					.SelectedItem.ToString().Trim());
			}
			else
			{
				SelectStuCardInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Trim(),string.Empty);
			}
		}

		//¸ù¾ÝÐÕÃû²éÑ¯ËùÑ¡ÐÅÏ¢
		private void textEdit_Send_StuName_EditValueChanged(object sender, System.EventArgs e)
		{
			if(CardView!=null)
			{
				SelectStuCardInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_StuClass
					.SelectedItem.ToString().Trim());
			}
		}

		//¸ù¾ÝÑ§ºÅ²éÑ¯ËùÑ¡ÐÅÏ¢
		private void textEdit_Send_StuNumber_EditValueChanged(object sender, System.EventArgs e)
		{
			if(CardView!=null)
			{
				SelectStuCardInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_StuClass
					.SelectedItem.ToString().Trim());
			}
		}

		private void comboBoxEdit_Send_TeaGrade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_Send_TeaClass.Properties.Items.Clear();
			comboBoxEdit_Send_TeaClass.Properties.Items.AddRange(new object[]{"È«²¿"});
			comboBoxEdit_Send_TeaClass.SelectedItem = "È«²¿";
			if(getStuInfoByCondition.getGradeInfo(comboBoxEdit_Send_TeaGrade.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
			{
				//¸ù¾ÝÄê¼¶Ñ¡Ôñ»ñÈ¡Äê¼¶±àºÅ
				getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_Send_TeaGrade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_Send_TeaClass.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}

			//¸ù¾ÝÄê¼¶²éÑ¯ËùÑ¡ÐÅÏ¢
			if(!comboBoxEdit_Send_TeaGrade.SelectedItem.ToString().Equals("È«²¿"))
			{
				SelectTeaCardInfo(textEdit_Send_TeaName.Text.Trim(),textEdit_Send_TeaNumber.Text.Trim(),
					comboBoxEdit_Send_TeaGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_TeaClass
					.SelectedItem.ToString().Trim());
			}
			else
			{
				SelectTeaCardInfo(textEdit_Send_TeaName.Text.Trim(),textEdit_Send_TeaNumber.Text.Trim(),
					string.Empty,comboBoxEdit_Send_TeaClass.SelectedItem.ToString().Trim());
			}
		}

		private void comboBoxEdit_Send_TeaClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!comboBoxEdit_Send_TeaClass.SelectedItem.ToString().Equals("È«²¿"))
			{
				SelectTeaCardInfo(textEdit_Send_TeaName.Text.Trim(),textEdit_Send_TeaNumber.Text.Trim(),
					comboBoxEdit_Send_TeaGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_TeaClass
					.SelectedItem.ToString().Trim());
			}
			else
			{
				SelectTeaCardInfo(textEdit_Send_TeaName.Text.Trim(),textEdit_Send_TeaNumber.Text.Trim(),
					comboBoxEdit_Send_TeaGrade.SelectedItem.ToString().Trim(),string.Empty);
			}
		}

		private void textEdit_Send_TeaName_EditValueChanged(object sender, System.EventArgs e)
		{
			if(CardView!=null)
			{
				SelectTeaCardInfo(textEdit_Send_TeaName.Text.Trim(),textEdit_Send_TeaNumber.Text.Trim(),
					comboBoxEdit_Send_TeaGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_TeaClass
					.SelectedItem.ToString().Trim());
			}
		}

		private void textEdit_Send_TeaNumber_EditValueChanged(object sender, System.EventArgs e)
		{
			if(CardView!=null)
			{
				SelectTeaCardInfo(textEdit_Send_TeaName.Text.Trim(),textEdit_Send_TeaNumber.Text.Trim(),
					comboBoxEdit_Send_TeaGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_TeaClass
					.SelectedItem.ToString().Trim());
			}
		}

		//¹ýÂËDataView
		private void SelectStuCardInfo(string name,string id,string grade,string className)
		{
			string rowFilter = string.Empty;
			
			rowFilter = "info_stuName like '%"+name+"%'";

			if(grade.Equals("È«²¿"))
			{
				rowFilter = rowFilter + " and info_gradeName like '%'";
			}
			else
			{
				rowFilter = rowFilter + " and info_gradeName like '%"+
					grade+"%'";
			}

			if(className.Equals("È«²¿"))
			{
				rowFilter = rowFilter + " and info_className like '%'";
			}
			else
			{
				rowFilter = rowFilter + " and info_className like '%"+className+"%'";
			}

			if(id.Length==4)
			{
				rowFilter += "and info_stuNumber="+id; 
			}

			CardView.RowFilter = rowFilter;
			gridControl_Send_CardInfo.DataSource = CardView;
			dataNavigator_CardSent.DataSource = CardView;

			if(gridView1.RowCount==0)
				return;
			
			string selectedStuID = (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_stuID"]).ToString();
			cardDetails = new CardInfoSystem().GetStuCardByID(selectedStuID);
			DisplayCardInfo(cardDetails);
		}

		//¹ýÂËDataView
		private void SelectTeaCardInfo(string name,string id,string grade,string className)
		{
			string rowFilter = string.Empty;
			
			rowFilter = "T_Name like '%"+name+"%'";

			if(grade.Equals("È«²¿"))
			{
				rowFilter = rowFilter + " and T_Depart like '%'";
			}
			else
			{
				rowFilter = rowFilter + " and T_Depart like '%"+
					grade+"%'";
			}

			if(className.Equals("È«²¿"))
			{
				rowFilter = rowFilter + " and T_Duty like '%'";
			}
			else
			{
				rowFilter = rowFilter + " and T_Duty like '%"+className+"%'";
			}

			if(id.Length==4)
			{
				rowFilter += "and T_Number="+id; 
			}

			CardView.RowFilter = rowFilter;
			gridControl_Send_CardInfo.DataSource = CardView;
			dataNavigator_CardSent.DataSource = CardView;
			
			if(gridView1.RowCount==0)
				return;

			string selectedTeaID = (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["T_ID"]).ToString();
			cardDetails = new CardInfoSystem().GetTeaCardByID(selectedTeaID);
			DisplayCardInfo(cardDetails);
		}

		//ÍËÑ§DataView¹ýÂË
		private void SelectLeaveSchoolInfo(string name,string id,string grade,string className)
		{
			string rowFilter = string.Empty;

			if(leaveSearchStu)
			{
				rowFilter = "info_stuName like '%"+name+"%'";

				if(grade.Equals("È«²¿"))
				{
					rowFilter = rowFilter + " and info_gradeName like '%'";
				}
				else
				{
					rowFilter = rowFilter + " and info_gradeName like '%"+
						grade+"%'";
				}

				if(className.Equals("È«²¿"))
				{
					rowFilter = rowFilter + " and info_className like '%'";
				}
				else
				{
					rowFilter = rowFilter + " and info_className like '%"+className+"%'";
				}

				if(id.Length==4)
				{
					rowFilter += "and info_stuNumber="+id; 
				}

				LeaveCardView.RowFilter = rowFilter;
				gridControl_Logout_CardInfo.DataSource = LeaveCardView;
				dataNavigator_CardLogout.DataSource = LeaveCardView;
			}
			else
			{
				rowFilter = "T_Name like '%"+name+"%'";

				if(grade.Equals("È«²¿"))
				{
					rowFilter = rowFilter + " and T_Depart like '%'";
				}
				else
				{
					rowFilter = rowFilter + " and T_Depart like '%"+
						grade+"%'";
				}

				if(className.Equals("È«²¿"))
				{
					rowFilter = rowFilter + " and T_Duty like '%'";
				}
				else
				{
					rowFilter = rowFilter + " and T_Duty like '%"+className+"%'";
				}

				if(id.Length==4)
				{
					rowFilter += "and T_Number="+id; 
				}

				LeaveCardView.RowFilter = rowFilter;
				gridControl_Logout_CardInfo.DataSource = LeaveCardView;
				dataNavigator_CardLogout.DataSource = LeaveCardView;
			}
		}

		private void combo_SendCardGrade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			combo_SendCardClass.Properties.Items.Clear();
			combo_SendCardClass.Properties.Items.AddRange(new object[]{"È«²¿"});
			combo_SendCardClass.SelectedItem = "È«²¿";
			if(getStuInfoByCondition.getGradeInfo(combo_SendCardGrade.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
			{
				//¸ù¾ÝÄê¼¶Ñ¡Ôñ»ñÈ¡Äê¼¶±àºÅ
				getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					combo_SendCardGrade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getGradeNumberFromCombo).Tables[0].Rows)
				{
					combo_SendCardClass.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}
		}

		private void LogoutCardGradeInfoBinding()
		{
			comboBoxEdit_Logout_StuGrade.Properties.Items.Clear();
			comboBoxEdit2.Properties.Items.Clear();

			comboBoxEdit_Logout_StuGrade.Properties.Items.AddRange(new object[]{"È«²¿"});
			comboBoxEdit2.Properties.Items.AddRange(new object[]{"È«²¿"});

			comboBoxEdit_Logout_StuGrade.SelectedItem = "È«²¿";
			comboBoxEdit2.SelectedItem = "È«²¿";

			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_Logout_StuGrade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
				comboBoxEdit2.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}
		}

		//ÍËÑ§
		private void comboBoxEdit_Logout_StuGrade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_Logout_StuClass.Properties.Items.Clear();
			comboBoxEdit_Logout_StuClass.Properties.Items.AddRange(new object[]{"È«²¿"});
			comboBoxEdit_Logout_StuClass.SelectedItem = "È«²¿";
			if(getStuInfoByCondition.getGradeInfo(comboBoxEdit_Logout_StuGrade.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
			{
				//¸ù¾ÝÄê¼¶Ñ¡Ôñ»ñÈ¡Äê¼¶±àºÅ
				getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_Logout_StuGrade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_Logout_StuClass.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}

			//¸ù¾ÝÄê¼¶²éÑ¯ËùÑ¡ÐÅÏ¢
			if(!comboBoxEdit_Logout_StuGrade.SelectedItem.ToString().Equals("È«²¿"))
			{
				SelectLeaveSchoolInfo(textEdit_Logout_StuName.Text.Trim(),textEdit_Logout_StuNumber.Text.Trim(),
					comboBoxEdit_Logout_StuGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Logout_StuClass
					.SelectedItem.ToString().Trim());
			}
			else
			{
				SelectLeaveSchoolInfo(textEdit_Logout_StuName.Text.Trim(),textEdit_Logout_StuNumber.Text.Trim(),
					string.Empty,comboBoxEdit_Logout_StuClass.SelectedItem.ToString().Trim());
			}
		}

		private void textEdit_Logout_StuName_EditValueChanged(object sender, System.EventArgs e)
		{
			if(LeaveCardView!=null)
			{
				SelectLeaveSchoolInfo(textEdit_Logout_StuName.Text.Trim(),textEdit_Logout_StuNumber.Text.Trim(),
					comboBoxEdit_Logout_StuGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Logout_StuClass
					.SelectedItem.ToString().Trim());
			}
		}

		private void textEdit_Logout_StuNumber_EditValueChanged(object sender, System.EventArgs e)
		{
			if(LeaveCardView!=null)
			{
				SelectLeaveSchoolInfo(textEdit_Logout_StuName.Text.Trim(),textEdit_Logout_StuNumber.Text.Trim(),
					comboBoxEdit_Logout_StuGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Logout_StuClass
					.SelectedItem.ToString().Trim());
			}
		}

		private void comboBoxEdit_Logout_StuClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!comboBoxEdit_Logout_StuClass.SelectedItem.ToString().Equals("È«²¿"))
			{
				SelectLeaveSchoolInfo(textEdit_Logout_StuName.Text.Trim(),textEdit_Logout_StuNumber.Text.Trim(),
					comboBoxEdit_Logout_StuGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Logout_StuClass
					.SelectedItem.ToString().Trim());
			}
			else
			{
				SelectLeaveSchoolInfo(textEdit_Logout_StuName.Text.Trim(),textEdit_Logout_StuNumber.Text.Trim(),
					comboBoxEdit_Logout_StuGrade.SelectedItem.ToString().Trim(),string.Empty);
			}
		}

		private void comboBoxEdit2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit1.Properties.Items.Clear();
			comboBoxEdit1.Properties.Items.AddRange(new object[]{"È«²¿"});
			comboBoxEdit1.SelectedItem = "È«²¿";
			if(getStuInfoByCondition.getGradeInfo(comboBoxEdit2.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
			{
				//¸ù¾ÝÄê¼¶Ñ¡Ôñ»ñÈ¡Äê¼¶±àºÅ
				getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit2.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit1.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}

			//¸ù¾ÝÄê¼¶²éÑ¯ËùÑ¡ÐÅÏ¢
			if(!comboBoxEdit_Logout_StuGrade.SelectedItem.ToString().Equals("È«²¿"))
			{
				SelectLeaveSchoolInfo(textEdit1.Text.Trim(),textEdit2.Text.Trim(),
					comboBoxEdit2.SelectedItem.ToString().Trim(), comboBoxEdit1
					.SelectedItem.ToString().Trim());
			}
			else
			{
				SelectLeaveSchoolInfo(textEdit1.Text.Trim(),textEdit2.Text.Trim(),
					string.Empty,comboBoxEdit1.SelectedItem.ToString().Trim());
			}
		}

		private void comboBoxEdit1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!comboBoxEdit1.SelectedItem.ToString().Equals("È«²¿"))
			{
				SelectLeaveSchoolInfo(textEdit1.Text.Trim(),textEdit2.Text.Trim(),
					comboBoxEdit2.SelectedItem.ToString().Trim(), comboBoxEdit1
					.SelectedItem.ToString().Trim());
			}
			else
			{
				SelectLeaveSchoolInfo(textEdit1.Text.Trim(),textEdit2.Text.Trim(),
					comboBoxEdit2.SelectedItem.ToString().Trim(),string.Empty);
			}
		}

		private void textEdit1_EditValueChanged(object sender, System.EventArgs e)
		{
			if(LeaveCardView!=null)
			{
				SelectLeaveSchoolInfo(textEdit1.Text.Trim(),textEdit2.Text.Trim(),
					comboBoxEdit2.SelectedItem.ToString().Trim(), comboBoxEdit1
					.SelectedItem.ToString().Trim());
			}
		}

		private void textEdit2_EditValueChanged(object sender, System.EventArgs e)
		{
			if(LeaveCardView!=null)
			{
				SelectLeaveSchoolInfo(textEdit1.Text.Trim(),textEdit2.Text.Trim(),
					comboBoxEdit2.SelectedItem.ToString().Trim(), comboBoxEdit1
					.SelectedItem.ToString().Trim());
			}
		}
		#endregion

		#region ·¢¿¨
		//·¢¿¨
		private void SendCard(object state)
		{
            var context = state as SynchronizationContext;
			try
			{
				FileStream fileStream = null;
				StreamReader streamReader = null;

				DataSet machineAddrList = new MachineSystem().GetMachineAddrList();

				DataFrame sendCardFrame = new DataFrame();

				sendCardFrame.sym = new byte[]{(byte)'@',(byte)'@'};
				sendCardFrame.desAddr = 0;
				sendCardFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;

				if(!isBatchSendCard)//ÆÕÍ¨·¢¿¨
				{
					sendCardFrame.protocol = CPTT.SystemFramework.Util.SEND_CARD_TOKEN;

					sendCardFrame.comFrameLen = 30;
					sendCardFrame.frameData = new byte[22];
					string stuID = string.Empty;
					int stuNumber;
					string stuName = string.Empty;
					int month = 255;
					int day = 255;

					if(searchStu)
					{
						stuID = (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_stuID"]).ToString();
						stuNumber = Convert.ToInt32(gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_stuNumber"]);
						stuName = (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_stuName"]).ToString();
						if (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_stuBirthDay"] != null)
						{
							DateTime birthday = Convert.ToDateTime(gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_stuBirthDay"]);
							month = birthday.Month;
							day = birthday.Day;
						}
					}
					else
					{
						stuID = (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["T_ID"]).ToString();
						stuNumber = Convert.ToInt32(gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["T_Number"]);
						stuName = (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["T_Name"]).ToString();
					}

					sendCardFrame.frameData[0] = (byte)(stuNumber % 100);
				
					int tmp = stuNumber / 100;
					int stuClassNum = tmp / 10;
					stuClassNum <<= 4;
					stuClassNum += tmp % 10;

					sendCardFrame.frameData[1] = (byte)stuClassNum;
		
					int stuCardNumber = 0;
					if(!(SendCard1Number.Text.Trim().Equals(string.Empty)))
					{
#if CardValidCheck
						try
						{
							bool findCard = false;
							fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory+"encry.bin",FileMode.OpenOrCreate,FileAccess.Read);
							streamReader = new StreamReader(fileStream);
							long dataEncrypt = Convert.ToInt64(SendCard1Number.Text.Trim()) + myBirthday;
							StringBuilder enryString = new StringBuilder(dataEncrypt.ToString());
							for ( int i=0; i<enryString.Length; i++ )
							{
								char newChar = (char)(((int)enryString[i])+i*(i-1));
								enryString[i] = newChar;
							}
							while ( true )
							{
								string readStr = streamReader.ReadLine();
								if ( readStr != null )
								{
									if ( readStr.Equals(enryString.ToString()) )
									{
										findCard = true;
										break;
									}
								}
								else
								{
									if ( !findCard )
									{
										Timer_SendCardOverTime.Enabled = false;
										LoginForm.sendCardThread.Abort();
										throw new Exception();
									}
									else
										break;
								}
							}
						}
						catch
						{
							Login.COM_PORT_IS_BUSY = false;
							LoginForm.ResumeQueryThread();
							MessageBox.Show("´æÔÚ·Ç·¨¿¨ºÅ£¬·¢¿¨Ê§°Ü£¡");
							dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
							dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;
							return;
						}
						finally
						{
							fileStream.Close();
							streamReader.Close();
						}
#endif

						unchecked
						{
							stuCardNumber = (int)(Convert.ToInt64(SendCard1Number.Text.Trim()));
						}

						CPTT.SystemFramework.Util.FillCard(sendCardFrame,stuCardNumber,0);
					}

					if(!(SendCard2Number.Text.Trim().Equals(string.Empty)))
					{
#if CardValidCheck
						try
						{
							bool findCard = false;
							fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory+"encry.bin",FileMode.OpenOrCreate,FileAccess.Read);
							streamReader = new StreamReader(fileStream);
							long dataEncrypt = Convert.ToInt64(SendCard2Number.Text.Trim()) + myBirthday;
							StringBuilder enryString = new StringBuilder(dataEncrypt.ToString());
							for ( int i=0; i<enryString.Length; i++ )
							{
								char newChar = (char)(((int)enryString[i])+i*(i-1));
								enryString[i] = newChar;
							}
							while ( true )
							{
								string readStr = streamReader.ReadLine();
								if ( readStr != null )
								{
									if ( readStr.Equals(enryString.ToString()) )
									{
										findCard = true;
										break;
									}
								}
								else
								{
									if ( !findCard )
									{
										Timer_SendCardOverTime.Enabled = false;
										LoginForm.sendCardThread.Abort();
										throw new Exception();
									}
									else
										break;
								}
							}
						}
						catch(Exception ex)
						{
							Login.COM_PORT_IS_BUSY = false;
							LoginForm.ResumeQueryThread();
							MessageBox.Show("´æÔÚ·Ç·¨¿¨ºÅ£¬·¢¿¨Ê§°Ü£¡");
							dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
							dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;
							return;
						}
						finally
						{
							fileStream.Close();
							streamReader.Close();
						}
#endif

						unchecked
						{
							stuCardNumber = (int)(Convert.ToInt64(SendCard2Number.Text.Trim()));
						}

						CPTT.SystemFramework.Util.FillCard(sendCardFrame,stuCardNumber,4);
					}

					if(!(SendCard3Number.Text.Trim().Equals(string.Empty)))
					{
#if CardValidCheck
						try
						{
							bool findCard = false;
							fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory+"encry.bin",FileMode.OpenOrCreate,FileAccess.Read);
							streamReader = new StreamReader(fileStream);
							long dataEncrypt = Convert.ToInt64(SendCard3Number.Text.Trim()) + myBirthday;
							StringBuilder enryString = new StringBuilder(dataEncrypt.ToString());
							for ( int i=0; i<enryString.Length; i++ )
							{
								char newChar = (char)(((int)enryString[i])+i*(i-1));
								enryString[i] = newChar;
							}
							while ( true )
							{
								string readStr = streamReader.ReadLine();
								if ( readStr != null )
								{
									if ( readStr.Equals(enryString.ToString()) )
									{
										findCard = true;
										break;
									}
								}
								else
								{
									if ( !findCard )
									{
										Timer_SendCardOverTime.Enabled = false;
										LoginForm.sendCardThread.Abort();
										throw new Exception();
									}
									else
										break;
								}
							}
						}
						catch(Exception ex)
						{
							Login.COM_PORT_IS_BUSY = false;
							LoginForm.ResumeQueryThread();
							MessageBox.Show("´æÔÚ·Ç·¨¿¨ºÅ£¬·¢¿¨Ê§°Ü£¡");
							dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
							dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;
							return;
						}
						finally
						{
							fileStream.Close();
							streamReader.Close();
						}
#endif 

						unchecked
						{
							stuCardNumber =(int)(Convert.ToInt64(SendCard3Number.Text.Trim()));
						}

						CPTT.SystemFramework.Util.FillCard(sendCardFrame,stuCardNumber,8);
					}

					if(!(SendCard4Number.Text.Trim().Equals(string.Empty)))
					{
#if CardValidCheck
						try
						{
							bool findCard = false;
							fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory+"encry.bin",FileMode.OpenOrCreate,FileAccess.Read);
							streamReader = new StreamReader(fileStream);
							long dataEncrypt = Convert.ToInt64(SendCard4Number.Text.Trim()) + myBirthday;
							StringBuilder enryString = new StringBuilder(dataEncrypt.ToString());
							for ( int i=0; i<enryString.Length; i++ )
							{
								char newChar = (char)(((int)enryString[i])+i*(i-1));
								enryString[i] = newChar;
							}
							while ( true )
							{
								string readStr = streamReader.ReadLine();
								if ( readStr != null )
								{
									if ( readStr.Equals(enryString.ToString()) )
									{
										findCard = true;
										break;
									}
								}
								else
								{
									if ( !findCard )
									{
										Timer_SendCardOverTime.Enabled = false;
										LoginForm.sendCardThread.Abort();
										throw new Exception();
									}
									else
										break;
								}
							}
						}
						catch(Exception ex)
						{
							Login.COM_PORT_IS_BUSY = false;
							LoginForm.ResumeQueryThread();
							MessageBox.Show("´æÔÚ·Ç·¨¿¨ºÅ£¬·¢¿¨Ê§°Ü£¡");
							dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
							dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;
							return;
						}
						finally
						{
							fileStream.Close();
							streamReader.Close();
						}
#endif

						unchecked
						{
							stuCardNumber = (int)(Convert.ToInt64(SendCard4Number.Text.Trim()));
						}

						CPTT.SystemFramework.Util.FillCard(sendCardFrame,stuCardNumber,12);
					}

					if(!(SendCard5Number.Text.Trim().Equals(string.Empty)))
					{
#if CardValidCheck
						try
						{
							bool findCard = false;
							fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory+"encry.bin",FileMode.OpenOrCreate,FileAccess.Read);
							streamReader = new StreamReader(fileStream);
							long dataEncrypt = Convert.ToInt64(SendCard5Number.Text.Trim()) + myBirthday;
							StringBuilder enryString = new StringBuilder(dataEncrypt.ToString());
							for ( int i=0; i<enryString.Length; i++ )
							{
								char newChar = (char)(((int)enryString[i])+i*(i-1));
								enryString[i] = newChar;
							}
							while ( true )
							{
								string readStr = streamReader.ReadLine();
								if ( readStr != null )
								{
									if ( readStr.Equals(enryString.ToString()) )
									{
										findCard = true;
										break;
									}
								}
								else
								{
									if ( !findCard )
									{
										Timer_SendCardOverTime.Enabled = false;
										LoginForm.sendCardThread.Abort();
										throw new Exception();
									}
									else
										break;
								}
							}
						}
						catch(Exception ex)
						{
							Login.COM_PORT_IS_BUSY = false;
							LoginForm.ResumeQueryThread();
							MessageBox.Show("´æÔÚ·Ç·¨¿¨ºÅ£¬·¢¿¨Ê§°Ü£¡");
							dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
							dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;
							return;
						}
						finally
						{
							fileStream.Close();
							streamReader.Close();
						}
#endif

						unchecked
						{
							stuCardNumber = (int)(Convert.ToInt64(SendCard5Number.Text.Trim()));
						}

						CPTT.SystemFramework.Util.FillCard(sendCardFrame,stuCardNumber,16);
					}

					foreach(DataRow machineAddr in machineAddrList.Tables[0].Rows)
					{

						cardTrace = Convert.ToInt32(machineAddr["machine_address"]);

						sendCardFrame.desAddr = Convert.ToByte(machineAddr["machine_address"]);

						sendCardFrame.computeCheckSum();

						//Monitor.Enter(Login.handleComClass);
						Monitor.Enter(Login.syncRoot);
						try
						{
							Login.handleComClass.WriteSerialCmd(sendCardFrame.comFrameLen,sendCardFrame.frameToBytes());//·¢ËÍÎÊÑ¯Ö¡
						}
						finally
						{
                            Monitor.Exit(Login.syncRoot);
						}
						//Monitor.Exit(Login.handleComClass);

						Timer_SendCardOverTime.Enabled = true;
						
						LoginForm.sendCardThread.Suspend();

						SendUserName(Convert.ToByte(machineAddr["machine_address"]), (byte)(stuNumber % 100), (byte)stuClassNum, stuName, month, day);
					}

					Thread.Sleep(300);
					if (this.InvokeRequired)
					{
						this.Invoke(new getCardDetailsContextSyncDelegate(GetCardDetailsContextSyncDelegate), new object[]{stuID});
					}
					else
					{
						GetCardDetailsContextSyncDelegate(stuID);
					}

//					if(searchStu)
//					{
//						cardDetails = new CardInfoSystem().GetStuCardByID(stuID);
//					}
//					else
//					{
//						cardDetails = new CardInfoSystem().GetTeaCardByID(stuID);
//					}
//					DisplayCardInfo(cardDetails);
//
//					dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
//					dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;
				}
				else//ÅúÁ¿·¢¿¨
				{
					try
					{
						sendCardFrame.protocol = CPTT.SystemFramework.Util.BATCH_SEND_CARD_TOKEN;

						sendCardFrame.comFrameLen = 15;
						sendCardFrame.frameData = new byte[7];
						string stuID = string.Empty;
						int stuNumber = 0;
						string stuName = string.Empty;

						int month = 255;
						int day = 255;

                        //gridView3.Focus();

						while(gridView3.RowCount>0)
						{
							isCardSendSucceed = true;

							
							if(batchSearchStu)
							{
								stuID = (gridView3.GetDataRow(0)["info_stuID"]).ToString();
								stuNumber = Convert.ToInt32(gridView3.GetDataRow(0)["info_stuNumber"]);
								stuName = (gridView3.GetDataRow(0)["info_stuName"]).ToString();

								if (gridView3.GetDataRow(0)["info_stuBirthDay"] != null)
								{
									DateTime birthday = Convert.ToDateTime(gridView3.GetDataRow(0)["info_stuBirthDay"]);
									month = birthday.Month;
									day = birthday.Day;
								}

							}
							else
							{
								stuID = (gridView3.GetDataRow(0)["T_ID"]).ToString();
								stuNumber = Convert.ToInt32(gridView3.GetDataRow(0)["T_Number"]);
								stuName = (gridView3.GetDataRow(0)["T_Name"]).ToString();
							}

							sendCardFrame.frameData[0] = (byte)(stuNumber % 100);
			
							int tmp = stuNumber / 100;
							int stuClassNum = tmp / 10;
							stuClassNum <<= 4;
							stuClassNum += tmp % 10;

							sendCardFrame.frameData[1] = (byte)stuClassNum;

#if CardValidCheck3
							try
							{
								bool findCard = false;
								Int64 cardNumber = 0;

								if(batchSearchStu)
								{
									cardNumber = Convert.ToInt64(gridView3.GetDataRow(0)["info_stuCardNumber"]);
								}
								else
								{
									cardNumber = Convert.ToInt64(gridView3.GetDataRow(0)["info_teaCardNumber"]);
								}

								fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory+"encry.bin",FileMode.OpenOrCreate,FileAccess.Read);
								streamReader = new StreamReader(fileStream);
								long dataEncrypt = cardNumber + myBirthday;
								StringBuilder enryString = new StringBuilder(dataEncrypt.ToString());
								for ( int i=0; i<enryString.Length; i++ )
								{
									char newChar = (char)(((int)enryString[i])+i*(i-1));
									enryString[i] = newChar;
								}
								while ( true )
								{
									string readStr = streamReader.ReadLine();
									if ( readStr != null )
									{
										if ( readStr.Equals(enryString.ToString()) )
										{
											findCard = true;
											break;
										}
									}
									else
									{
										if ( !findCard )
										{
											Timer_SendCardOverTime.Enabled = false;
											LoginForm.sendCardThread.Abort();
											throw new Exception();
										}
										else
											break;
									}
								}
							}
							catch(Exception ex)
							{
								Login.COM_PORT_IS_BUSY = false;
								LoginForm.ResumeQueryThread();
								simpleButton2.Enabled = true;
								MessageBox.Show("´æÔÚ·Ç·¨¿¨ºÅ£¬·¢¿¨Ê§°Ü£¡");
								return;
							}
							finally
							{
								fileStream.Close();
								streamReader.Close();
							}
#endif

							int stuCardNumber = 0;

							unchecked
							{
								if(batchSearchStu)
								{
									stuCardNumber = (int)(Convert.ToInt64(gridView3.GetDataRow(0)["info_stuCardNumber"]));
								}
								else
								{
									stuCardNumber = (int)(Convert.ToInt64(gridView3.GetDataRow(0)["info_teaCardNumber"]));
								}
							}
				
							foreach(DataRow machineAddr in machineAddrList.Tables[0].Rows)
							{

								cardTrace = Convert.ToInt32(machineAddr["machine_address"]);
						

								sendCardFrame.desAddr =Convert.ToByte(machineAddr["machine_address"]);

								CPTT.SystemFramework.Util.FillCard(sendCardFrame,stuCardNumber,0);

								if(batchSearchStu)
								{
									sendCardFrame.frameData[6] = Convert.ToByte(gridView3.GetDataRow(0)["info_stuCardSeq"]);
								}
								else
								{
									sendCardFrame.frameData[6] = Convert.ToByte(gridView3.GetDataRow(0)["info_teaCardSeq"]);
								}

								sendCardFrame.computeCheckSum();	
								Monitor.Enter(Login.syncRoot);
								try
								{
									Login.handleComClass.WriteSerialCmd(sendCardFrame.comFrameLen,sendCardFrame.frameToBytes());//·¢ËÍÎÊÑ¯Ö¡
								}
								finally
								{
                                    Monitor.Exit(Login.syncRoot);
								}
								Timer_SendCardOverTime.Enabled = true;
								LoginForm.sendCardThread.Suspend();

								SendUserName(Convert.ToByte(machineAddr["machine_address"]), (byte)(stuNumber % 100), (byte)stuClassNum, stuName, month, day);
							}

							if ( isCardSendSucceed )
							{
								CardInfoSystem cardInfoSystem = new CardInfoSystem();
								if(batchSearchStu)
								{
									cardInfoSystem.UpdateCardState(gridView3.GetDataRow(0)["info_stuCardNumber"].ToString());
								}
								else
								{
									cardInfoSystem.UpdateTeaCardState(gridView3.GetDataRow(0)["info_teaCardNumber"].ToString());
								}

                                context.Send((_) => gridView3.DeleteRow(0), null);
							}
						}

                        context.Send((_) => simpleButton2.Enabled = true, null);
					}
					catch(ThreadAbortException taex)
					{
						if (taex.ExceptionState == null || taex.ExceptionState.GetType() != typeof(bool))
						{
							if ((LoginForm.sendCardThread.ThreadState & ThreadState.Aborted) == ThreadState.Aborted
								|| (LoginForm.sendCardThread.ThreadState & ThreadState.AbortRequested) == ThreadState.AbortRequested
								|| (LoginForm.sendCardThread.ThreadState & ThreadState.Stopped) == ThreadState.Stopped
								|| (LoginForm.sendCardThread.ThreadState & ThreadState.StopRequested) == ThreadState.StopRequested)
							{
								LoginForm.sendCardThread = new Thread(SendCard);
								LoginForm.sendCardThread.Start(SynchronizationContext.Current);
							}
							Thread.ResetAbort();
						}
						return;
					}
				}

				Login.COM_PORT_IS_BUSY = false;

				reTryTime = 0;

				//			LoginForm.ResumeThread();
				LoginForm.ResumeQueryThread();

				if ( isCardSendSucceed )
					MessageBox.Show("·¢¿¨³É¹¦!!","ÏµÍ³ÐÅÏ¢!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);

				try
				{
					LoginForm.sendCardThread.Abort();
				}
				catch
				{
					Thread.ResetAbort();
				}
			}
			catch(Exception ex)
			{
				CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
                MessageBox.Show("·¢¿¨ÖÐ¶Ï£¬µã»÷·¢¿¨ÖØÊÔ£¡");
			}
			finally
			{
                if (context != null)
                {
                    context.Send((_) =>
                    {
                        dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
                        dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;
                    }, null);
                }

				
				Login.COM_PORT_IS_BUSY = false;
				
				LoginForm.ResumeQueryThread();

                if (LoginForm.sendCardThread.IsAlive)
                {
                    try
                    {
                        LoginForm.sendCardThread.Abort();
                    }
                    catch (Exception)
                    {

                    }
                }

			}
		}

		private void LogoutCard()
		{
			try
			{
				dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = false;
				dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = false;

				string stuID = string.Empty;
				int stuNumber;

				if(searchStu)
				{
					stuID = (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_stuID"]).ToString();
					stuNumber = Convert.ToInt32(gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_stuNumber"]);
				}
				else
				{
					stuID = (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["T_ID"]).ToString();
					stuNumber = Convert.ToInt32(gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["T_Number"]);
				}

				DataSet machineAddrList = new MachineSystem().GetMachineAddrList();

				DataFrame sendCardFrame = new DataFrame();

				sendCardFrame.sym = new byte[]{(byte)'@',(byte)'@'};
				sendCardFrame.desAddr = 0;
				sendCardFrame.comFrameLen = 30;
				sendCardFrame.frameData = new byte[22];
				sendCardFrame.protocol = CPTT.SystemFramework.Util.SEND_CARD_SUCCESS_TOKEN;
				sendCardFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;

				sendCardFrame.frameData[0] = (byte)(stuNumber % 100);
				
				int tmp = stuNumber / 100;
				int stuClassNum = tmp / 10;
				stuClassNum <<= 4;
				stuClassNum += tmp % 10;

				sendCardFrame.frameData[1] = (byte)stuClassNum;
		
				int stuCardNumber = 0;
				ArrayList cardLogout = new ArrayList();
				if(!(SendCard1Number.Text.Trim().Equals(string.Empty)))
				{
					if(removeCard1.Checked)
					{
						CPTT.SystemFramework.Util.FillCard(sendCardFrame,0,0);
						cardLogout.Add(SendCard1Number.Text.Trim());
					}
					else
					{
						unchecked
						{
							stuCardNumber = (int)(Convert.ToInt64(SendCard1Number.Text.Trim()));
						}

						CPTT.SystemFramework.Util.FillCard(sendCardFrame,stuCardNumber,0);
					}
				}

				if(!(SendCard2Number.Text.Trim().Equals(string.Empty)))
				{
					if(removeCard2.Checked)
					{
						CPTT.SystemFramework.Util.FillCard(sendCardFrame,0,4);
						cardLogout.Add(SendCard2Number.Text.Trim());
					}
					else
					{
						unchecked
						{
							stuCardNumber = (int)(Convert.ToInt64(SendCard2Number.Text.Trim()));
						}

						CPTT.SystemFramework.Util.FillCard(sendCardFrame,stuCardNumber,4);
					}
				}

				if(!(SendCard3Number.Text.Trim().Equals(string.Empty)))
				{
					if(removeCard3.Checked)
					{
						CPTT.SystemFramework.Util.FillCard(sendCardFrame,0, 8);
						cardLogout.Add(SendCard3Number.Text.Trim());
					}
					else
					{
						unchecked
						{
							stuCardNumber =(int)(Convert.ToInt64(SendCard3Number.Text.Trim()));
						}

						CPTT.SystemFramework.Util.FillCard(sendCardFrame,stuCardNumber,8);
					}
				}

				if(!(SendCard4Number.Text.Trim().Equals(string.Empty)))
				{
					if(removeCard4.Checked)
					{
						CPTT.SystemFramework.Util.FillCard(sendCardFrame,0,12);
						cardLogout.Add(SendCard4Number.Text.Trim());
					}
					else
					{
						unchecked
						{
							stuCardNumber = (int)(Convert.ToInt64(SendCard4Number.Text.Trim()));
						}

						CPTT.SystemFramework.Util.FillCard(sendCardFrame,stuCardNumber,12);
					}
				}

				if(!(SendCard5Number.Text.Trim().Equals(string.Empty)))
				{
					if(removeCard5.Checked)
					{
						CPTT.SystemFramework.Util.FillCard(sendCardFrame,0,16);
						cardLogout.Add(SendCard5Number.Text.Trim());
					}
					else
					{
						unchecked
						{
							stuCardNumber = (int)(Convert.ToInt64(SendCard5Number.Text.Trim()));
						}

						CPTT.SystemFramework.Util.FillCard(sendCardFrame,stuCardNumber,16);
					}
				}

				foreach(DataRow machineAddr in machineAddrList.Tables[0].Rows)
				{
					cardTrace = Convert.ToInt32(machineAddr["machine_address"]);
					sendCardFrame.desAddr = Convert.ToByte(machineAddr["machine_address"]);

					sendCardFrame.computeCheckSum();

					//Monitor.Enter(Login.handleComClass);
					Monitor.Enter(Login.syncRoot);
					try
					{
						Login.handleComClass.WriteSerialCmd(sendCardFrame.comFrameLen,sendCardFrame.frameToBytes());//·¢ËÍÎÊÑ¯Ö¡
					}
					finally
					{
                        Monitor.Exit(Login.syncRoot);
					}

					Timer_SendCardOverTime.Enabled = true;
					LoginForm.sendCardThread.Suspend();
				}

				Thread.Sleep(300);
				Login.COM_PORT_IS_BUSY = false;

				if ( isCardLogOutSucceed )
				{
					if (this.InvokeRequired)
					{
						
						this.Invoke(new logoutCardContextSyncDelegate(LogoutCardContextSync), new object[]{cardLogout, stuID});
					}
					else
					{
						LogoutCardContextSync(cardLogout, stuID);
					}

					
			
					//			LoginForm.ResumeThread();
//					LoginForm.ResumeQueryThread();
//
//					dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
//					dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;

					MessageBox.Show("Ïú¿¨³É¹¦!!","ÏµÍ³ÐÅÏ¢!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);

					try
					{
						LoginForm.sendCardThread.Abort();
					}
					catch
					{
						Thread.ResetAbort();
					}
				}
			}
			catch(Exception ex)
			{
				CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
				MessageBox.Show("Ïú¿¨¿¨ÖÐ·¢Éú´íÎó,³öÏÖµÄÔ­Òò¿ÉÄÜÊÇÔÝÊ±ÎÞ·¨Á¬½ÓÔ¶³ÌÉè±¸£¬ÇëÖØÊÔ£¡");
			}
			finally
			{
				if(this.InvokeRequired)
				{
					this.Invoke(new enableCardButtonContextSyncDelegate(EnableCardButtonContextSyncDelegate));
				}
				else
				{
					EnableCardButtonContextSyncDelegate();
				}
			
				
				Login.COM_PORT_IS_BUSY = false;
				
				LoginForm.ResumeQueryThread();

				if ( LoginForm.sendCardThread.IsAlive ) LoginForm.sendCardThread.Abort();
			}
		}

		private delegate void logoutCardContextSyncDelegate(ArrayList cardLogout, string stuID);
		private delegate void enableCardButtonContextSyncDelegate();
		private delegate void getCardDetailsContextSyncDelegate(string stuID);
		private void LogoutCardContextSync(ArrayList cardLogout, string stuID)
		{
			dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
			dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;

			reTryTime = 0;

			CardInfoSystem cardInfoSystem = new CardInfoSystem();
			foreach(string logoutCard in cardLogout)
			{
				if(searchStu)
				{
					cardInfoSystem.DeleteCardInfo(logoutCard);
				}
				else
				{
					cardInfoSystem.DeleteTeaCardInfo(logoutCard);
				}
			}

			GetCardDetailsContextSyncDelegate(stuID);
		}

		private void EnableCardButtonContextSyncDelegate()
		{
			dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
			dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;
		}

		private void GetCardDetailsContextSyncDelegate(string stuID)
		{
			if(searchStu)
			{
				cardDetails = new CardInfoSystem().GetStuCardByID(stuID);
			}
			else
			{
				cardDetails = new CardInfoSystem().GetTeaCardByID(stuID);
			}
			DisplayCardInfo(cardDetails);
			EnableCardButtonContextSyncDelegate();
		}

		//¿¨²Ù×÷³É¹¦ºó´¥·¢Ê±¼ä
		private void loginForm_SendCardSuccessed()
		{
			Timer_SendCardOverTime.Enabled = false;

			CardInfoSystem cardInfoSystem = new CardInfoSystem();
			if(isBatchSendCard&&gridView3.RowCount>0)
			{
				if(batchSearchStu)
				{
					//cardInfoSystem.UpdateCardState(gridView3.GetDataRow(0)["info_stuCardNumber"].ToString());
				}
				else
				{
					cardInfoSystem.UpdateTeaCardState(gridView3.GetDataRow(0)["info_teaCardNumber"].ToString());
				}
			}
			
//			if(!isBatchSendCard&&isSendCard)
//			{
//				foreach(string cardNumber in cardsHasSend)
//				{
//					if(searchStu)
//					{
//						cardInfoSystem.UpdateCardState(cardNumber);
//					}
//					else
//					{
//						cardInfoSystem.UpdateTeaCardState(cardNumber);
//					}
//				}
//			}

			isCardLogOutSucceed = true;
			isCardSendSucceed = true;
			
			//Login.COM_PORT_IS_BUSY = false;
			try
			{
				LoginForm.sendCardThread.Resume();
			}
			catch{}
		}

		//¿¨²Ù×÷Ê§°Ü
		private void LoginForm_SendCardFailed()
		{
			Timer_SendCardOverTime.Enabled = false;

			try
			{		
				LoginForm.sendCardThread.Resume();
			}
			catch
			{
//				Login.COM_PORT_IS_BUSY = false;
				
			}
			finally
			{
				isCardSendSucceed = false;
				Login.COM_PORT_IS_BUSY = false;
				dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
				dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;
				simpleButton2.Enabled = true;

				LoginForm.ResumeQueryThread();
				LoginForm.sendCardThread.Abort(true);

				MessageBox.Show(string.Format("ÃÅ¿Ú»ú{0}µÄ¿¨²Ù×÷Ê§°Ü£¡",cardTrace),"ÏµÍ³ÐÅÏ¢!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}

//			LoginForm.ResumeThread();
//			LoginForm.ResumeQueryThread();
//			LoginForm.sendCardThread.Abort();
//			MessageBox.Show("¿¨²Ù×÷Ê§°Ü,ÇëÖØÊÔ!!","ÏµÍ³ÐÅÏ¢!",
//				MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		//¿¨²Ù×÷³¬Ê±
		private void Timer_SendCardOverTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			Timer_SendCardOverTime.Enabled = false;

			if(reTryTime<5)//ÖØÊÔ5´Î
			{
				try
				{
					
					LoginForm.sendCardThread.Abort();
				}
				catch(Exception ex)
				{
					
					if(isSendCard||isBatchSendCard)
					{
						LoginForm.sendCardThread = new Thread(SendCard);
					}
					else
					{
						LoginForm.sendCardThread = new Thread(new ThreadStart(LogoutCard));
					}
					LoginForm.sendCardThread.IsBackground = true;
					LoginForm.sendCardThread.Priority = ThreadPriority.Normal;
					LoginForm.sendCardThread.Start(SynchronizationContext.Current);
				}

				reTryTime ++;
				isCardSendSucceed = false;
				Thread.ResetAbort();
				//LoginForm.sendCardThread.Resume();
			}
			else
			{
				try
				{
					//					LoginForm.sendCardThread.Abort();
					
					LoginForm.sendCardThread.Resume();
				}
				catch
				{
					
				}
				finally
				{
					isCardSendSucceed = false;
					isCardLogOutSucceed = false;
					Login.COM_PORT_IS_BUSY = false;
					dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
					dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;
					simpleButton2.Enabled = true;
					reTryTime = 0;
					LoginForm.ResumeQueryThread();
					LoginForm.sendCardThread.Abort(true);
					
				
					MessageBox.Show(string.Format("ÃÅ¿Ú»ú{0}µÄ¿¨²Ù×÷Ê§°Ü£¡",cardTrace),"ÏµÍ³ÐÅÏ¢!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);
				}

//				reTryTime = 0;
//				LoginForm.ResumeQueryThread();
//				LoginForm.sendCardThread.Abort();
//				
//				MessageBox.Show(string.Format("ÃÅ¿Ú»ú{0}·¢¿¨Ê§°Ü£¡",cardTrace),"ÏµÍ³ÐÅÏ¢!",
//					MessageBoxButtons.OK,MessageBoxIcon.Information);

//				MessageBox.Show("¿¨²Ù×÷³¬Ê±,ÇëÖØÊÔ.","ÏµÍ³ÐÅÏ¢!",
//					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		#endregion

		#region ÖØÐ´Êý¾Ýµ¼º½À¸ÊÂ¼þ
		private void dataNavigator_CardSent_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
		{
			switch(e.Button.ButtonType)
			{
				case NavigatorButtonType.Next:
					e.Handled = false;
					break;
				case NavigatorButtonType.Prev:
					e.Handled = false;
					break;
				case NavigatorButtonType.NextPage:
					e.Handled = false;
					break;
				case NavigatorButtonType.PrevPage:
					e.Handled = false;
					break;
				case NavigatorButtonType.First:
					e.Handled = false;
					break;
				case NavigatorButtonType.Last:
					e.Handled = false;
					break;
				case NavigatorButtonType.EndEdit:
					e.Handled = true;
					if(!CardSave())
					{
						MessageBox.Show("·Ç·¨¿¨»ò¿¨ºÅÒÑ¾­´æÔÚ£¬²Ù×÷Ê§°Ü£¡");
						return;
					}
					break;
				case NavigatorButtonType.CancelEdit:
					break;
				case NavigatorButtonType.Custom:
					e.Handled = true;
					if(e.Button.Tag.ToString().Equals("0"))//·¢¿¨
					{
						isCardSendSucceed = true;
						if(!CardSave())
						{
							MessageBox.Show("¸Ã¿¨ºÅÒÑ¾­´æÔÚ£¬²Ù×÷Ê§°Ü£¡");
							return;
						}
//
//						if(SendCard1Number.Text.Trim().Equals(string.Empty)&&
//							SendCard2Number.Text.Trim().Equals(string.Empty)&&
//							SendCard3Number.Text.Trim().Equals(string.Empty)&&
//							SendCard4Number.Text.Trim().Equals(string.Empty)&&
//							SendCard5Number.Text.Trim().Equals(string.Empty))
//						{
//							MessageBox.Show("¿¨ºÅ²»ÄÜ¶¼Îª¿Õ!!","ÏµÍ³ÐÅÏ¢!",
//								MessageBoxButtons.OK,MessageBoxIcon.Information);
//
//							return;
//						}

						dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = false;
						dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = false;

						isSendCard = true;
						isBatchSendCard = false;
						Login.COM_PORT_IS_BUSY = true;
						
						LoginForm.SuspendAllThread();

						LoginForm.sendCardThread = new Thread(SendCard);
						LoginForm.sendCardThread.IsBackground = true;
						LoginForm.sendCardThread.Priority = ThreadPriority.Normal;
						LoginForm.sendCardThread.Start(SynchronizationContext.Current);
					}
					else if(e.Button.Tag.ToString().Equals("1"))//Ïú¿¨
					{
						isCardLogOutSucceed = false;

						if(!removeCard1.Checked&&!removeCard2.Checked&&
							!removeCard3.Checked&&!removeCard4.Checked&&
							!removeCard5.Checked)
						{
							MessageBox.Show("Ã»ÓÐÒªÏúµÄ¿¨!!","ÏµÍ³ÐÅÏ¢!",
								MessageBoxButtons.OK,MessageBoxIcon.Information);

							return;
						}

						isSendCard = false;
						isBatchSendCard = false;
						Login.COM_PORT_IS_BUSY = true;

						LoginForm.SuspendAllThread();

						LoginForm.sendCardThread = new Thread(new ThreadStart(LogoutCard));
						LoginForm.sendCardThread.IsBackground = true;
						LoginForm.sendCardThread.Priority = ThreadPriority.Normal;
						LoginForm.sendCardThread.Start();
					}
					break;
			}
		}
		#endregion

		#region ÖØÐ´ÍËÑ§Êý¾Ýµ¼º½À¸ÊÂ¼þ
		private void dataNavigator_CardLogout_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
		{
			switch(e.Button.ButtonType)
			{
				case NavigatorButtonType.Next:
					e.Handled = false;
					break;
				case NavigatorButtonType.Prev:
					e.Handled = false;
					break;
				case NavigatorButtonType.NextPage:
					e.Handled = false;
					break;
				case NavigatorButtonType.PrevPage:
					e.Handled = false;
					break;
				case NavigatorButtonType.First:
					e.Handled = false;
					break;
				case NavigatorButtonType.Last:
					e.Handled = false;
					break;
				case NavigatorButtonType.CancelEdit:
					e.Handled = true;
					isLeaveSchoolSucceed = true;
					if(gridView2.RowCount == 0)
						return;

					if(DialogResult.Yes == (MessageBox.Show("È·¶¨Òª¶ÔÑ¡ÖÐµÄÐÅÏ¢½øÐÐÍËÑ§»òÍËÐÝ´¦Àí?","ÏµÍ³ÌáÊ¾!",
						MessageBoxButtons.YesNo,MessageBoxIcon.Information)))
					{
						Login.COM_PORT_IS_BUSY = true;

						LoginForm.SuspendAllThread();
						LoginForm.leaveCardThread = new Thread(new ThreadStart(LeaveSchool));
						LoginForm.leaveCardThread.IsBackground = true;
						LoginForm.leaveCardThread.Priority = ThreadPriority.Normal;
						LoginForm.leaveCardThread.Start();

						
					}
					break;
			}
		}

		private void LeaveSchool()
		{
			dataNavigator_CardLogout.Buttons.CancelEdit.Enabled = false;
			int stuNumber;

			if(leaveSearchStu)
			{
				stuNumber = Convert.ToInt32(gridView2.GetDataRow(gridView2.GetSelectedRows()[0])["info_stuNumber"]);
			}
			else
			{
				stuNumber = Convert.ToInt32(gridView2.GetDataRow(gridView2.GetSelectedRows()[0])["T_Number"]);
			}

			DataSet machineAddrList = new MachineSystem().GetMachineAddrList();

			DataFrame sendCardFrame = new DataFrame();

			sendCardFrame.sym = new byte[]{(byte)'@',(byte)'@'};
			sendCardFrame.desAddr = 0;
			sendCardFrame.comFrameLen = 10;
			sendCardFrame.frameData = new byte[2];
			sendCardFrame.protocol = CPTT.SystemFramework.Util.LEAVE_SCHOOL_TOKEN;
			sendCardFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;

			sendCardFrame.frameData[0] = (byte)(stuNumber % 100);
			
			int tmp = stuNumber / 100;
			int stuClassNum = tmp / 10;
			stuClassNum <<= 4;
			stuClassNum += tmp % 10;

			sendCardFrame.frameData[1] = (byte)stuClassNum;

			foreach(DataRow machineAddr in machineAddrList.Tables[0].Rows)
			{
				sendCardFrame.desAddr = Convert.ToByte(machineAddr["machine_address"]);

				sendCardFrame.computeCheckSum();

				//Monitor.Enter(Login.handleComClass);
                Monitor.Enter(Login.syncRoot);
				try
				{
					Login.handleComClass.WriteSerialCmd(sendCardFrame.comFrameLen,sendCardFrame.frameToBytes());//·¢ËÍÍËÑ§Ö¡
				}
				finally
				{
                    Monitor.Exit(Login.syncRoot);
				}

				Timer_LeaveTime.Enabled = true;
				LoginForm.leaveCardThread.Suspend();
			}

			if ( isLeaveSchoolSucceed )
			{
				leaveCardTryTime = 0;
				dataNavigator_CardLogout.Buttons.CancelEdit.Enabled = true;
				Login.COM_PORT_IS_BUSY = false;

				CardInfoSystem cardInfoSystem = new CardInfoSystem();

				string stuID = string.Empty;

				if(leaveSearchStu)
				{
					stuID = (gridView2.GetDataRow(gridView2.GetSelectedRows()[0])["info_stuID"]).ToString();
					if(cardInfoSystem.StuLeaveSchool(stuID)>0)
					{
						gridView2.DeleteRow(gridView2.GetSelectedRows()[0]);
					}

					new CardInfoSystem().DeleteCardInfo(true,stuID);
				}
				else
				{
					stuID = (gridView2.GetDataRow(gridView2.GetSelectedRows()[0])["T_ID"]).ToString();
					if(cardInfoSystem.TeaLeaveSchool(stuID)>0)
					{
						gridView2.DeleteRow(gridView2.GetSelectedRows()[0]);
					}

					new CardInfoSystem().DeleteCardInfo(false,stuID);
				}
			
				//			LoginForm.ResumeThread();
				LoginForm.ResumeQueryThread();
				MessageBox.Show("²Ù×÷³É¹¦.","ÏµÍ³ÐÅÏ¢!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);

				LoginForm.leaveCardThread.Abort();
			}
		}

		private void LoginForm_LogtouCardSuccessed()
		{
			Timer_LeaveTime.Enabled = false;

			LoginForm.leaveCardThread.Resume();
		}

		private int leaveCardTryTime = 0;
		private void Timer_LeaveTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			Timer_LeaveTime.Enabled = false;

			if(leaveCardTryTime<5)//ÖØÊÔ5´Î
			{
				try
				{
					LoginForm.leaveCardThread.Abort();
				}
				catch
				{
					LoginForm.leaveCardThread = new Thread(new ThreadStart(LeaveSchool));
					LoginForm.leaveCardThread.IsBackground = true;
					LoginForm.leaveCardThread.Priority = ThreadPriority.Normal;
					LoginForm.leaveCardThread.Start();
				}

				leaveCardTryTime ++;
			}
			else
			{
				try
				{
					isLeaveSchoolSucceed = false;
					LoginForm.leaveCardThread.Resume();
				}
				catch
				{
					
				}
				finally
				{
					Login.COM_PORT_IS_BUSY = false;
					dataNavigator_CardLogout.Buttons.CancelEdit.Enabled = true;
				}

				leaveCardTryTime = 0;
//				LoginForm.ResumeThread();
				LoginForm.ResumeQueryThread();
				MessageBox.Show("¿¨²Ù×÷³¬Ê±,ÇëÖØÊÔ.","ÏµÍ³ÐÅÏ¢!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);

				LoginForm.leaveCardThread.Abort();
			}
		}
		#endregion

		#region ÅúÁ¿·¢¿¨
		private void simpleButton_BatchSendStuCard_Click(object sender, System.EventArgs e)
		{
			notePanel_BatchSendGrade.Text = "Äê  ¼¶:";
			notePanel_BatchSendClass.Text = "°à  ¼¶:";

			gridControl_BatchSendView.DataSource = null;

			BatchSendCardGradeInfoBinding();

			if(!batchSearchStu)
			{
				batchSearchStu = true;
			}

			if ( !comboBoxEdit3.SelectedItem.ToString().Equals("ÔÝÎÞ¿¨") )
			{
				BatchCardInfo = new CardInfoSystem().GetBatchCardInfo();//Ñ§Éú¿¨
			
			}
			else
			{	
				BatchCardInfo = new CardInfoSystem().GetNoCardStudents();
			}

			BatchCardView = BatchCardInfo.Tables[0].DefaultView;

			StuBatchSendCardBinding();
			gridControl_BatchSendView.DataSource = BatchCardView;
		}

		private void simpleButton_BatchSendTeaCard_Click(object sender, System.EventArgs e)
		{
			notePanel_BatchSendGrade.Text = "¸Ú  Î»:";
			notePanel_BatchSendClass.Text = "²¿  ÃÅ:";

			gridControl_BatchSendView.DataSource = null;

			BatchSendCardGradeInfoBinding();

			if(batchSearchStu)
			{
				batchSearchStu = false;
			}

			if ( !comboBoxEdit3.SelectedItem.ToString().Equals("ÔÝÎÞ¿¨") )
			{
				BatchCardInfo = new CardInfoSystem().GetTeaBatchCardInfo();//½ÌÊ¦¿¨
			
			}
			else
			{	
				BatchCardInfo = new CardInfoSystem().GetNoCardTeachers();
			}

			BatchCardView = BatchCardInfo.Tables[0].DefaultView;

			TeaBatchSendCardBinding();
			gridControl_BatchSendView.DataSource = BatchCardView;
		}

		private void StuBatchSendCardBinding()
		{
//			gridView3.Columns.Clear();

			gridColumn7.FieldName = "info_stuID";

			gridColumn8.Caption = "Ñ§ºÅ";
			gridColumn8.FieldName = "info_stuNumber";
			gridColumn9.Caption = "ÐÕÃû";
			gridColumn9.FieldName = "info_stuName";
			gridColumn10.Caption = "Äê¼¶";
			gridColumn10.FieldName = "info_gradeName";
			gridColumn11.Caption = "°à¼¶";
			gridColumn11.FieldName = "info_className";
			gridColumn12.Caption = "¿¨ºÅ";
			gridColumn12.FieldName = "info_stuCardNumber";
			gridColumn13.Caption = "³Ö¿¨ÈË";
			gridColumn13.FieldName = "info_stuCardHolder";
			gridColumn14.Caption = "¿¨ÐòºÅ";
			gridColumn14.FieldName = "info_stuCardSeq";
		}

		private void TeaBatchSendCardBinding()
		{
//			gridView3.Columns.Clear();

			gridColumn7.FieldName = "T_ID";

			gridColumn8.Caption = "¹¤ºÅ";
			gridColumn8.FieldName = "T_Number";
			gridColumn9.Caption = "ÐÕÃû";
			gridColumn9.FieldName = "T_Name";
			gridColumn10.Caption = "²¿ÃÅ";
			gridColumn10.FieldName = "T_Depart";
			gridColumn11.Caption = "¸ÚÎ»";
			gridColumn11.FieldName = "T_Duty";
			gridColumn12.Caption = "¿¨ºÅ";
			gridColumn12.FieldName = "info_teaCardNumber";
			gridColumn13.Caption = "³Ö¿¨ÈË";
			gridColumn13.Visible = false;
			gridColumn14.Caption = "¿¨ÐòºÅ";
			gridColumn14.FieldName = "info_teaCardSeq";
		}

		//µã»÷ÅúÁ¿·¢¿¨
		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			if(gridView3.RowCount == 0)
				return;

			simpleButton2.Enabled = false;
			isBatchSendCard = true;
			Login.COM_PORT_IS_BUSY = true;

			LoginForm.SuspendAllThread();
			LoginForm.sendCardThread = new Thread(SendCard);
			LoginForm.sendCardThread.IsBackground = true;
			LoginForm.sendCardThread.Priority = ThreadPriority.Normal;
            LoginForm.sendCardThread.Start(SynchronizationContext.Current);
		}

		//ÔÝÍ£ÅúÁ¿·¢¿¨
		private void simpleButton_BatchSendStop_Click(object sender, System.EventArgs e)
		{
			Timer_SendCardOverTime.Enabled = false;

			try
			{
                dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
                dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;
				LoginForm.sendCardThread.Abort();
			}
			catch
			{	
				LoginForm.sendCardThread.Resume();
				LoginForm.sendCardThread.Abort();
			}
			finally
			{
				Login.COM_PORT_IS_BUSY = false;
				simpleButton2.Enabled = true;
//				LoginForm.ResumeThread();
				LoginForm.ResumeQueryThread();
			}
		}

		#endregion

		#region validate card is exist
		private void SendCard1Number_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == 13)
			{
				string card1 = Convert.ToString(Convert.ToInt32(SendCard1Number.Text.Trim()));

				if(isCardExist(card1))
				{
					MessageBox.Show("¿¨ºÅ"+card1
						+"ÒÑ´æÔÚ!!","ÏµÍ³ÐÅÏ¢!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);

					SendCard1Number.Text = string.Empty;
				}
				else SendCard1Number.Text = card1;
			}
		}

		private void SendCard2Number_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == 13)
			{
				string card2 = Convert.ToString(Convert.ToInt32(SendCard2Number.Text.Trim()));

				if(isCardExist(card2))
				{
					MessageBox.Show("¿¨ºÅ"+card2
						+"ÒÑ´æÔÚ!!","ÏµÍ³ÐÅÏ¢!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);

					SendCard2Number.Text = string.Empty;
				}
				else SendCard2Number.Text = card2;
			}
		}

		private void SendCard3Number_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == 13)
			{
				string card3 = Convert.ToString(Convert.ToInt32(SendCard3Number.Text.Trim()));

				if(isCardExist(card3))
				{
					MessageBox.Show("¿¨ºÅ"+card3
						+"ÒÑ´æÔÚ!!","ÏµÍ³ÐÅÏ¢!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);

					SendCard3Number.Text = string.Empty;
				}
				else SendCard3Number.Text = card3;
			}
		}

		private void SendCard4Number_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == 13)
			{
				string card4 = Convert.ToString(Convert.ToInt32(SendCard4Number.Text.Trim()));

				if(isCardExist(card4))
				{
					MessageBox.Show("¿¨ºÅ"+card4
						+"ÒÑ´æÔÚ!!","ÏµÍ³ÐÅÏ¢!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);

					SendCard4Number.Text = string.Empty;
				}
				else SendCard4Number.Text = card4;
			}
		}

		private void SendCard5Number_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == 13)
			{
				string card5 = Convert.ToString(Convert.ToInt32(SendCard5Number.Text.Trim()));

				if(isCardExist(card5))
				{
					MessageBox.Show("¿¨ºÅ"+card5
						+"ÒÑ´æÔÚ!!","ÏµÍ³ÐÅÏ¢!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);

					SendCard5Number.Text = string.Empty;
				}
				else SendCard5Number.Text = card5;
			}
		}

		private bool isCardExist(string cardNumber)
		{
			int cardCount = new CardInfoSystem().GetCardCount(cardNumber);

			if(cardCount>0)
				return true;
			else
				return false;
		}

//		private void changeCardState(string cardNumber)
//		{
//
//		}
		#endregion

		#region ¼ìÑéID¿¨
		private void simpleButton_BatchSendCheck_Click(object sender, System.EventArgs e)
		{
			if(textEdit3.Text.Equals(string.Empty))
			{
				MessageBox.Show("ÇëÊäÈëÒª¼ìÑéµÄ¿¨ºÅ!!","ÏµÍ³ÐÅÏ¢!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				textEdit3.Focus();
				return;
			}

			string number = new CardInfoSystem().GetNumberByCard(textEdit3.Text.Trim().TrimStart('0'));
			if(number.Length == 0)
			{
				MessageBox.Show(textEdit3.Text+"²»ÊÇ±¾Ð£µÄ¿¨.","ÏµÍ³ÐÅÏ¢!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show(textEdit3.Text+"ÊÇ"+number.ToString()+"µÄ¿¨.","ÏµÍ³ÐÅÏ¢!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
//
//			Login.COM_PORT_IS_BUSY = true;
//
//			LoginForm.SuspendAllThread();
//			LoginForm.validateCardThread = new Thread(new ThreadStart(ValidateCard));
//			LoginForm.validateCardThread.IsBackground = true;
//			LoginForm.validateCardThread.Priority = ThreadPriority.Normal;
//			LoginForm.validateCardThread.Start();
		}

		private void ValidateCard()
		{
			simpleButton_BatchSendCheck.Enabled = false;

			DataSet machineAddrList = new MachineSystem().GetMachineAddrList();

			DataFrame sendCardFrame = new DataFrame();

			sendCardFrame.sym = new byte[]{(byte)'@',(byte)'@'};
			sendCardFrame.desAddr = 0;
			sendCardFrame.comFrameLen = 12;
			sendCardFrame.frameData = new byte[4];
			sendCardFrame.protocol = CPTT.SystemFramework.Util.VALIDATE_CARD_TOKEN;
			sendCardFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;

			sendCardFrame.desAddr = Convert.ToByte(machineAddrList.Tables[0].Rows[0]["machine_address"]);
			
			int stuCardNumber = 0;
			unchecked
			{
				stuCardNumber = (int)(Convert.ToInt64(textEdit3.Text.Trim()));
			}

			CPTT.SystemFramework.Util.FillCard(sendCardFrame,stuCardNumber,-2);
			
			sendCardFrame.computeCheckSum();

			//Monitor.Enter(Login.handleComClass);
            Monitor.Enter(Login.syncRoot);
			try
			{
				Login.handleComClass.WriteSerialCmd(sendCardFrame.comFrameLen,sendCardFrame.frameToBytes());//·¢ËÍÎÊÑ¯Ö¡
			}
			finally
			{
                Monitor.Exit(Login.syncRoot);
			}

			Timer_ValidateCardOverTime.Enabled = true;
			LoginForm.validateCardThread.Suspend();

			validateCardTryTime = 0;
			simpleButton_BatchSendCheck.Enabled = true;
			textEdit3.SelectAll();
			Login.COM_PORT_IS_BUSY = false;
//			LoginForm.ResumeThread();
			LoginForm.ResumeQueryThread();

			LoginForm.validateCardThread.Abort();
		}

		//¼ìÑé¿¨Êý¾Ý·µ»Ø
		private void LoginForm_ValidateCardInfoReturn(byte[] receiveData)
		{
			Timer_SendCardOverTime.Enabled = false;

			DataFrame validateInfo = DataFrame.convertToFrame(receiveData);

			Int16 studentNumber = (Int16)(((validateInfo.frameData[1]/16)*10 + (validateInfo.frameData[1]%16))*100  
				+ validateInfo.frameData[0]);

			if(studentNumber == 0)
			{
				MessageBox.Show(textEdit3.Text+"²»ÊÇ±¾Ð£µÄ¿¨.","ÏµÍ³ÐÅÏ¢!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show(textEdit3.Text+"ÊÇÑ§ºÅÎª"+studentNumber.ToString()+"µÄ¿¨.","ÏµÍ³ÐÅÏ¢!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}

			LoginForm.validateCardThread.Resume();
		}

		//Ð£Ñé¿¨³¬Ê±
		private int validateCardTryTime = 0;
		private void Timer_ValidateCardOverTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			Timer_ValidateCardOverTime.Enabled = false;

			if(validateCardTryTime<5)//ÖØÊÔ5´Î
			{
				try
				{
					LoginForm.validateCardThread.Abort();
				}
				catch
				{
					LoginForm.validateCardThread = new Thread(new ThreadStart(ValidateCard));
					LoginForm.validateCardThread.IsBackground = true;
					LoginForm.validateCardThread.Priority = ThreadPriority.Normal;
					LoginForm.validateCardThread.Start();
				}

				validateCardTryTime ++;
			}
			else
			{
				try
				{
					LoginForm.validateCardThread.Resume();
				}
				catch
				{}
				finally
				{
					Login.COM_PORT_IS_BUSY = false;
					simpleButton_BatchSendCheck.Enabled = true;
				}

				validateCardTryTime = 0;
//				LoginForm.ResumeThread();
				LoginForm.ResumeQueryThread();
				MessageBox.Show("¿¨¼ìÑé³¬Ê±,ÇëÖØÊÔ.","ÏµÍ³ÐÅÏ¢!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);

				LoginForm.validateCardThread.Abort();
			}
		}
		#endregion

		#region µ¼³öExcelÎÄ¼þ
		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
//			if(gridView1.RowCount==0)
//			{
//				MessageBox.Show("Ã»ÓÐÒªµ¼³öµÄÊý¾Ý!","ÏµÍ³ÐÅÏ¢!",
//					MessageBoxButtons.OK,MessageBoxIcon.Information);
//				return;
//			}
//
//			saveFileDialog_ImportExcel.Filter = "ExcelÎÄ¼þ|*.xls";
//
//			if(saveFileDialog_ImportExcel.ShowDialog()!=DialogResult.OK)
//				return;
//
//			string savePath = saveFileDialog_ImportExcel.FileName;
//			
//			string name = string.Empty;
//			string id = string.Empty;
//			string grade = string.Empty;
//			string atClass = string.Empty;
//
//			if(searchStu)
//			{
//				name = textEdit_Send_StuName.Text.Trim();
//				id = textEdit_Send_StuNumber.Text.Trim();
//				grade = comboBoxEdit_Send_StuGrade.SelectedItem.ToString();
//				atClass = comboBoxEdit_Send_StuClass.SelectedItem.ToString();
//
//				new CardInfoSystem().ImportCardExcelFile(name,id,grade,atClass,true,savePath);
//			}
//			else
//			{
//				name = textEdit_Send_TeaName.Text.Trim();
//				id = textEdit_Send_TeaNumber.Text.Trim();
//				grade = comboBoxEdit_Send_TeaGrade.SelectedItem.ToString();
//				atClass = comboBoxEdit_Send_TeaClass.SelectedItem.ToString();
//
//				new CardInfoSystem().ImportCardExcelFile(name,id,grade,atClass,false,savePath);
//			}
			try
			{
				saveFileDialog_ImportExcel.Filter = "ExcelÎÄ¼þ|*.xls";

				if(saveFileDialog_ImportExcel.ShowDialog()!=DialogResult.OK)
					return;

				string savePath = saveFileDialog_ImportExcel.FileName;

				new CardInfoSystem().WriteCardInfoExcel(savePath);

				MessageBox.Show("µ¼³ö³É¹¦£¡");
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}
		#endregion

		#region ÊÕÈ¡³µÔØ»úÊý¾Ý
		private void simpleButton_GetMobile_Click(object sender, System.EventArgs e)
		{
			DataSet machineAddrList = new MachineSystem().GetMachineAddrList();

			gridControl_DeviceView.DataSource = machineAddrList.Tables[0];
		}

		//¿ªÊ¼½ÓÊÜ³µÔØ»úÊý¾Ý
		private void simpleButton_FastDataReceive_Click(object sender, System.EventArgs e)
		{
			if(gridView5.SelectedRowsCount == 0 )
			{
				MessageBox.Show("ÇëÏÈÑ¡ÔñÒ»Ì¨Òª½ÓÊÜÊý¾ÝµÄ³µÔØ»ú!!","ÏµÍ³ÐÅÏ¢!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			Login.COM_PORT_IS_BUSY = true;
			
			LoginForm.SuspendAllThread();
			LoginForm.receiveFromCar = new Thread(new ThreadStart(SendQuery));
			LoginForm.receiveFromCar.IsBackground = true;
			LoginForm.receiveFromCar.Priority = ThreadPriority.Normal;
			LoginForm.receiveFromCar.Start();
		}

		//ÎÊÑ¯Ö¸Áî
		private void SendQuery()
		{
			simpleButton_FastDataReceive.Enabled = false;
			Thread.Sleep(CPTT.SystemFramework.Util.QUERY_TIMER_INTERVAL);

			while(true)
			{
				ControlFrame controlFrame = new ControlFrame();
				controlFrame.sym = new byte[]{(byte)'*',(byte)'*'};
				controlFrame.desAddr = Convert.ToByte(gridView5.GetDataRow(gridView5.GetSelectedRows()[0])["machine_address"]);
				controlFrame.srcAddr = 0;
				controlFrame.response = CPTT.SystemFramework.Util.QUERY_TOKEN;
				controlFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;
				controlFrame.computeCheckSum();

				//Monitor.Enter(Login.handleComClass);
                Monitor.Enter(Login.syncRoot);
				try
				{
					Login.handleComClass.WriteSerialCmd(CPTT.SystemFramework.Util.CONTROL_FRAME_LENGTH,controlFrame.convertToBytes());//·¢ËÍÎÊÑ¯Ö¡
				}
				finally
				{
                    Monitor.Exit(Login.syncRoot);
				}


				Thread.Sleep(CPTT.SystemFramework.Util.QUERY_TIMER_INTERVAL);
			}
		}

		//Í£Ö¹½ÓÊÜ³µÔØ»úÊý¾Ý
		private void simpleButton_StopDataReceive_Click(object sender, System.EventArgs e)
		{
			try
			{
				LoginForm.receiveFromCar.Suspend();
				LoginForm.receiveFromCar.Abort();
			}
			catch(ThreadAbortException ex)
			{
				CPTT.SystemFramework.Util.WriteLog(CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE,ex.Message);
			}
			finally
			{
				Login.COM_PORT_IS_BUSY = false;
				simpleButton_FastDataReceive.Enabled = true;
			}
		
//			LoginForm.ResumeThread();
			LoginForm.ResumeQueryThread();
			MessageBox.Show("³µÔØ»úÊý¾ÝÊÕÈ¡ÒÑÍ£Ö¹!!","ÏµÍ³ÐÅÏ¢!",
				MessageBoxButtons.OK,MessageBoxIcon.Information);	
		}
		#endregion

		#region Ê±¼äÍ¬²½
		private void simpleButton_Date_Click(object sender, System.EventArgs e)
		{
			if(gridView5.SelectedRowsCount == 0 )
			{
				MessageBox.Show("ÇëÏÈÑ¡ÔñÒ»Ì¨ÒªÍ¬²½Ê±¼äµÄ»úÆ÷!!","ÏµÍ³ÐÅÏ¢!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			Login.COM_PORT_IS_BUSY = true;
			isTimeSynSucceed = true;

			LoginForm.SuspendAllThread();
			Thread.Sleep(500);

			LoginForm.synchDateThread = new Thread(new ThreadStart(SynchDate));
			LoginForm.synchDateThread.IsBackground = true;
			LoginForm.synchDateThread.Priority = ThreadPriority.Normal;
			LoginForm.synchDateThread.Start();

			msgForm.StartPosition = FormStartPosition.CenterScreen;
			msgForm.ShowDialog();
		}

		private void SynchDate()
		{
			try
			{
                current.Send((_) => simpleButton_Date.Enabled = false, null);

				DataFrame controlFrame = new DataFrame();
				controlFrame.sym = new byte[]{(byte)'@',(byte)'@'};
				controlFrame.desAddr = Convert.ToByte(gridView5.GetDataRow(gridView5.GetSelectedRows()[0])["machine_address"]);
				controlFrame.comFrameLen = 15;
				controlFrame.srcAddr = 0;
				controlFrame.protocol = CPTT.SystemFramework.Util.TIME_SYNCH_TOKEN;
				controlFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;
				controlFrame.frameData = new byte[7];

				controlFrame.frameData[0] = Convert.ToByte(DateTime.Now.Year%100);
				controlFrame.frameData[1] = Convert.ToByte((byte)DateTime.Now.Month); 
				controlFrame.frameData[2] = Convert.ToByte((byte)DateTime.Now.Day);                            
				controlFrame.frameData[3] = Convert.ToByte((byte)(DateTime.Now.DayOfWeek+1));
				controlFrame.frameData[4] = Convert.ToByte((byte)DateTime.Now.Hour);
				controlFrame.frameData[5] = Convert.ToByte((byte)DateTime.Now.Minute);
				controlFrame.frameData[6] = Convert.ToByte((byte)DateTime.Now.Second);

				controlFrame.computeCheckSum();

				//Monitor.Enter(Login.handleComClass);
                Monitor.Enter(Login.syncRoot);
				try
				{
					Login.handleComClass.WriteSerialCmd(controlFrame.comFrameLen,controlFrame.frameToBytes());//·¢ËÍÎÊÑ¯Ö¡
				}
				finally
				{
                    Monitor.Exit(Login.syncRoot);
				}
				//			Login.handleComClass.WriteSerialCmd(15,new byte[]{(byte)'@',(byte)'@',1,15,0,4,0,
				//				06,10,5,1,22,22,22,236});
				//Monitor.Exit(Login.handleComClass);
		
				timer_SychnDate.Enabled = true;
				LoginForm.synchDateThread.Suspend();

				//			LoginForm.ResumeThread();

				timer_SychnDate.Enabled = false;
				Login.COM_PORT_IS_BUSY = false;

				LoginForm.ResumeQueryThread();

                current.Send((_) => msgForm.Close(), null);

				if ( isTimeSynSucceed )
					MessageBox.Show("Ê±¼äÍ¬²½³É¹¦.","ÏµÍ³ÐÅÏ¢!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);

                current.Send((_) => simpleButton_Date.Enabled = true, null);

				LoginForm.synchDateThread.Abort();
			}
			catch(Exception ex)
			{
				Login.COM_PORT_IS_BUSY = false;
				LoginForm.ResumeQueryThread();
				isTimeSynSucceed = false;

                current.Send((_) => msgForm.Close(), null);

				
				timer_SychnDate.Enabled = false;
			}
		}

		private int retrySynchTime = 0;
		private void timer_SychnDate_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			timer_SychnDate.Enabled = false;

			//retry three times
			if ( retrySynchTime < 3 )
			{
				try
				{
					LoginForm.synchDateThread.Abort();
				}
				catch
				{
					LoginForm.synchDateThread = new Thread(new ThreadStart(SynchDate));
					LoginForm.synchDateThread.IsBackground = true;
					LoginForm.synchDateThread.Priority = ThreadPriority.Normal;
					LoginForm.synchDateThread.Start();
				}

				retrySynchTime ++;
			}
			else
			{
				try
				{
					LoginForm.synchDateThread.Resume();
				}
				catch
				{}
				finally
				{
//					Login.COM_PORT_IS_BUSY = false;
//					simpleButton_Date.Enabled = true;
					Login.COM_PORT_IS_BUSY = false;
					LoginForm.ResumeQueryThread();
					isTimeSynSucceed = false;
					msgForm.Close();
					MessageBox.Show("Ê±¼äÍ¬²½Ê§°Ü!");
					timer_SychnDate.Enabled = false;
				}

				retrySynchTime = 0;
			}
		}

		private void LoginForm_SynchTimeSuccessed()
		{
//			Login.COM_PORT_IS_BUSY = false;
//			timer_SychnDate.Enabled = false;
//			retrySynchTime = 0;
//			simpleButton_Date.Enabled = true;

			isTimeSynSucceed = true;
			LoginForm.synchDateThread.Resume();
		}
		#endregion

		#region Ãæ°åÇÐ»»
		#endregion

		#region ±£´æ¿¨ÐÅÏ¢
		private bool CardSave()
		{
			FileStream fileStream = null;
			StreamReader streamReader = null;

			if(SendCard1Number.Text.Trim().Equals(string.Empty)&&
				SendCard2Number.Text.Trim().Equals(string.Empty)&&
				SendCard3Number.Text.Trim().Equals(string.Empty)&&
				SendCard4Number.Text.Trim().Equals(string.Empty)&&
				SendCard5Number.Text.Trim().Equals(string.Empty))
			{
				MessageBox.Show("¿¨ºÅ²»ÄÜ¶¼Îª¿Õ!!","ÏµÍ³ÐÅÏ¢!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);

				return false;
			}

			cardsHasSend.Clear();

			string stuID;
			string stuCardNumber = string.Empty;

			if(searchStu)
			{
				stuID = (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_stuID"]).ToString();
			}
			else
			{
				stuID = (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["T_ID"]).ToString();
			}

			bool cardIsNotSend = true;
			CardInfoSystem cardInfoSystem = new CardInfoSystem();

			if(!(SendCard1Number.Text.Trim().Equals(string.Empty)))
			{

#if CardValidCheck2
				try
				{
					bool findCard = false;
					fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory+"encry.bin",FileMode.OpenOrCreate,FileAccess.Read);
					streamReader = new StreamReader(fileStream);
					long dataEncrypt = Convert.ToInt64(SendCard1Number.Text.Trim()) + myBirthday;
					StringBuilder enryString = new StringBuilder(dataEncrypt.ToString());
					for ( int i=0; i<enryString.Length; i++ )
					{
						char newChar = (char)(((int)enryString[i])+i*(i-1));
						enryString[i] = newChar;
					}
					while ( true )
					{
						string readStr = streamReader.ReadLine();
						if ( readStr != null )
						{
							if ( readStr.Equals(enryString.ToString()) )
							{
								findCard = true;
								break;
							}
						}
						else
						{
							if ( !findCard )
							{
								MessageBox.Show("´æÔÚ·Ç·¨¿¨ºÅ£¬¿¨²Ù×÷Ê§°Ü£¡");
								return false;
							}
							else
								break;
						}
					}
				}
				catch(Exception ex)
				{	
					MessageBox.Show("¿¨ºÅÐÅÏ¢²»×¼È·£¬ÇëÖØÊÔ£¡");
					return false;
				}
				finally
				{
					dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
					dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;

					fileStream.Close();
					streamReader.Close();
				}
#endif
				if(searchStu)
				{
					if(SendCard1Holder.Text.Trim().Equals(string.Empty))
					{
						MessageBox.Show("¿¨1³Ö¿¨ÈË²»ÄÜ¶¼Îª¿Õ!!","ÏµÍ³ÐÅÏ¢!",
							MessageBoxButtons.OK,MessageBoxIcon.Information);
						return false;
					}
				}

				stuCardNumber = SendCard1Number.Text.Trim();


				SystemFramework.CardInfo sendCardInfo = new CardInfo();
				sendCardInfo.StuID = stuID;
				sendCardInfo.CardNumber = stuCardNumber;
				sendCardInfo.CardHolder = SendCard1Holder.Text.Trim();
				sendCardInfo.CardSendDate = DateTime.Now;
				sendCardInfo.CardSequence = 1;
				sendCardInfo.CardState = cardIsNotSend;

				if(searchStu)
				{
					int retValue = cardInfoSystem.InsertCardInfo(sendCardInfo);
					
					if (retValue == -2)
					{
						return false;
					}
				}
				else
				{
					int retValue = cardInfoSystem.InsertTeaCardInfo(sendCardInfo);

					if (retValue == -2)
					{
						return false;
					}
				}
				cardsHasSend.Add(stuCardNumber);
				SendCard1Number.Enabled = false;
			}

			if(!(SendCard2Number.Text.Trim().Equals(string.Empty)))
			{

#if CardValidCheck2
				try
				{
					bool findCard = false;
					fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory+"encry.bin",FileMode.OpenOrCreate,FileAccess.Read);
					streamReader = new StreamReader(fileStream);
					long dataEncrypt = Convert.ToInt64(SendCard2Number.Text.Trim()) + myBirthday;
					StringBuilder enryString = new StringBuilder(dataEncrypt.ToString());
					for ( int i=0; i<enryString.Length; i++ )
					{
						char newChar = (char)(((int)enryString[i])+i*(i-1));
						enryString[i] = newChar;
					}
					while ( true )
					{
						string readStr = streamReader.ReadLine();
						if ( readStr != null )
						{
							if ( readStr.Equals(enryString.ToString()) )
							{
								findCard = true;
								break;
							}
						}
						else
						{
							if ( !findCard )
							{
								MessageBox.Show("´æÔÚ·Ç·¨¿¨ºÅ£¬¿¨²Ù×÷Ê§°Ü£¡");
								return false;
							}
							else
								break;
						}
					}
				}
				catch(Exception ex)
				{	
					MessageBox.Show("¿¨ºÅÐÅÏ¢²»×¼È·£¬ÇëÖØÊÔ£¡");
					return false;
				}
				finally
				{
					dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
					dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;

					fileStream.Close();
					streamReader.Close();
				}
#endif
				if(searchStu)
				{
					if(SendCard2Holder.Text.Trim().Equals(string.Empty))
					{
						MessageBox.Show("¿¨2³Ö¿¨ÈË²»ÄÜ¶¼Îª¿Õ!!","ÏµÍ³ÐÅÏ¢!",
							MessageBoxButtons.OK,MessageBoxIcon.Information);
						return false;
					}
				}


				stuCardNumber = SendCard2Number.Text.Trim();

				SystemFramework.CardInfo sendCardInfo = new CardInfo();
				sendCardInfo.StuID = stuID;
				sendCardInfo.CardNumber = stuCardNumber;
				sendCardInfo.CardHolder = SendCard2Holder.Text.Trim();
				sendCardInfo.CardSendDate = DateTime.Now;
				sendCardInfo.CardSequence = 2;
				sendCardInfo.CardState = cardIsNotSend;

				if(searchStu)
				{
					int retValue = cardInfoSystem.InsertCardInfo(sendCardInfo);

					if (retValue == -2)
					{
						return false;
					}
				}
				else
				{
					int retValue = cardInfoSystem.InsertTeaCardInfo(sendCardInfo);

					if (retValue == -2)
					{
						return false;
					}
				}
				cardsHasSend.Add(stuCardNumber);
				SendCard2Number.Enabled = false;
			}

			if(!(SendCard3Number.Text.Trim().Equals(string.Empty)))
			{

#if CardValidCheck2
				try
				{
					bool findCard = false;
					fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory+"encry.bin",FileMode.OpenOrCreate,FileAccess.Read);
					streamReader = new StreamReader(fileStream);
					long dataEncrypt = Convert.ToInt64(SendCard3Number.Text.Trim()) + myBirthday;
					StringBuilder enryString = new StringBuilder(dataEncrypt.ToString());
					for ( int i=0; i<enryString.Length; i++ )
					{
						char newChar = (char)(((int)enryString[i])+i*(i-1));
						enryString[i] = newChar;
					}
					while ( true )
					{
						string readStr = streamReader.ReadLine();
						if ( readStr != null )
						{
							if ( readStr.Equals(enryString.ToString()) )
							{
								findCard = true;
								break;
							}
						}
						else
						{
							if ( !findCard )
							{
								MessageBox.Show("´æÔÚ·Ç·¨¿¨ºÅ£¬¿¨²Ù×÷Ê§°Ü£¡");
								return false;
							}
							else
								break;
						}
					}
				}
				catch(Exception ex)
				{	
					MessageBox.Show("¿¨ºÅÐÅÏ¢²»×¼È·£¬ÇëÖØÊÔ£¡");
					return false;
				}
				finally
				{
					dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
					dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;

					fileStream.Close();
					streamReader.Close();
				}
#endif
				if(searchStu)
				{
					if(SendCard3Holder.Text.Trim().Equals(string.Empty))
					{
						MessageBox.Show("¿¨3³Ö¿¨ÈË²»ÄÜ¶¼Îª¿Õ!!","ÏµÍ³ÐÅÏ¢!",
							MessageBoxButtons.OK,MessageBoxIcon.Information);
						return false;
					}
				}


				stuCardNumber = SendCard3Number.Text.Trim();

				SystemFramework.CardInfo sendCardInfo = new CardInfo();
				sendCardInfo.StuID = stuID;
				sendCardInfo.CardNumber = stuCardNumber;
				sendCardInfo.CardHolder = SendCard3Holder.Text.Trim();
				sendCardInfo.CardSendDate = DateTime.Now;
				sendCardInfo.CardSequence = 3;
				sendCardInfo.CardState = cardIsNotSend;

				if(searchStu)
				{
					int retValue = cardInfoSystem.InsertCardInfo(sendCardInfo);

					if (retValue == -2)
					{
						return false;
					}
				}
				else
				{
					int retValue = cardInfoSystem.InsertTeaCardInfo(sendCardInfo);

					if (retValue == -2)
					{
						return false;
					}
				}
				cardsHasSend.Add(stuCardNumber);
				SendCard3Number.Enabled = false;
			}

			if(!(SendCard4Number.Text.Trim().Equals(string.Empty)))
			{

#if CardValidCheck2
				try
				{
					bool findCard = false;
					fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory+"encry.bin",FileMode.OpenOrCreate,FileAccess.Read);
					streamReader = new StreamReader(fileStream);
					long dataEncrypt = Convert.ToInt64(SendCard4Number.Text.Trim()) + myBirthday;
					StringBuilder enryString = new StringBuilder(dataEncrypt.ToString());
					for ( int i=0; i<enryString.Length; i++ )
					{
						char newChar = (char)(((int)enryString[i])+i*(i-1));
						enryString[i] = newChar;
					}
					while ( true )
					{
						string readStr = streamReader.ReadLine();
						if ( readStr != null )
						{
							if ( readStr.Equals(enryString.ToString()) )
							{
								findCard = true;
								break;
							}
						}
						else
						{
							if ( !findCard )
							{
								MessageBox.Show("´æÔÚ·Ç·¨¿¨ºÅ£¬¿¨²Ù×÷Ê§°Ü£¡");
								return false;
							}
							else
								break;
						}
					}
				}
				catch(Exception ex)
				{	
					MessageBox.Show("¿¨ºÅÐÅÏ¢²»×¼È·£¬ÇëÖØÊÔ£¡");
					return false;
				}
				finally
				{
					dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
					dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;

					fileStream.Close();
					streamReader.Close();
				}
#endif
				if(searchStu)
				{
					if(SendCard4Holder.Text.Trim().Equals(string.Empty))
					{
						MessageBox.Show("¿¨4³Ö¿¨ÈË²»ÄÜ¶¼Îª¿Õ!!","ÏµÍ³ÐÅÏ¢!",
							MessageBoxButtons.OK,MessageBoxIcon.Information);
						return false;
					}
				}


				stuCardNumber = SendCard4Number.Text.Trim();

				SystemFramework.CardInfo sendCardInfo = new CardInfo();
				sendCardInfo.StuID = stuID;
				sendCardInfo.CardNumber = stuCardNumber;
				sendCardInfo.CardHolder = SendCard4Holder.Text.Trim();
				sendCardInfo.CardSendDate = DateTime.Now;
				sendCardInfo.CardSequence = 4;
				sendCardInfo.CardState = cardIsNotSend;

				if(searchStu)
				{
					int retValue = cardInfoSystem.InsertCardInfo(sendCardInfo);

					if (retValue == -2)
					{
						return false;
					}
				}
				else
				{
					int retValue = cardInfoSystem.InsertTeaCardInfo(sendCardInfo);

					if (retValue == -2)
					{
						return false;
					}
				}
				cardsHasSend.Add(stuCardNumber);
				SendCard4Number.Enabled = false;
			}

			if(!(SendCard5Number.Text.Trim().Equals(string.Empty)))
			{

#if CardValidCheck2
				try
				{
					bool findCard = false;
					fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory+"encry.bin",FileMode.OpenOrCreate,FileAccess.Read);
					streamReader = new StreamReader(fileStream);
					long dataEncrypt = Convert.ToInt64(SendCard5Number.Text.Trim()) + myBirthday;
					StringBuilder enryString = new StringBuilder(dataEncrypt.ToString());
					for ( int i=0; i<enryString.Length; i++ )
					{
						char newChar = (char)(((int)enryString[i])+i*(i-1));
						enryString[i] = newChar;
					}
					while ( true )
					{
						string readStr = streamReader.ReadLine();
						if ( readStr != null )
						{
							if ( readStr.Equals(enryString.ToString()) )
							{
								findCard = true;
								break;
							}
						}
						else
						{
							if ( !findCard )
							{
								MessageBox.Show("´æÔÚ·Ç·¨¿¨ºÅ£¬¿¨²Ù×÷Ê§°Ü£¡");
								return false;
							}
							else
								break;
						}
					}
				}
				catch(Exception ex)
				{	
					MessageBox.Show("¿¨ºÅÐÅÏ¢²»×¼È·£¬ÇëÖØÊÔ£¡");
					return false;
				}
				finally
				{
					dataNavigator_CardSent.Buttons.CustomButtons[0].Enabled = true;
					dataNavigator_CardSent.Buttons.CustomButtons[1].Enabled = true;

					fileStream.Close();
					streamReader.Close();
				}
#endif
				if(searchStu)
				{
					if(SendCard5Holder.Text.Trim().Equals(string.Empty))
					{
						MessageBox.Show("¿¨5³Ö¿¨ÈË²»ÄÜ¶¼Îª¿Õ!!","ÏµÍ³ÐÅÏ¢!",
							MessageBoxButtons.OK,MessageBoxIcon.Information);
						return false;
					}
				}


				stuCardNumber = SendCard5Number.Text.Trim();

				SystemFramework.CardInfo sendCardInfo = new CardInfo();
				sendCardInfo.StuID = stuID;
				sendCardInfo.CardNumber = stuCardNumber;
				sendCardInfo.CardHolder = SendCard5Holder.Text.Trim();
				sendCardInfo.CardSendDate = DateTime.Now;
				sendCardInfo.CardSequence = 5;
				sendCardInfo.CardState = cardIsNotSend;

				if(searchStu)
				{
					int retValue = cardInfoSystem.InsertCardInfo(sendCardInfo);

					if (retValue == -2)
					{
						return false;
					}
				}
				else
				{
					int retValue = cardInfoSystem.InsertTeaCardInfo(sendCardInfo);

					if (retValue == -2)
					{
						return false;
					}
				}
				cardsHasSend.Add(stuCardNumber);
				SendCard5Number.Enabled = false;
			}
			return true;
		}
		#endregion

		private void InitCardPanel()
		{
			int cardVersion = SystemFramework.Util.CardVersion;
			//¿¨1
			notePanel_Send_Card1stNumber.Visible = cardVersion >= 1;
			SendCard1Number.Visible = cardVersion >= 1;
			notePanel_Send_Card1stHolder.Visible = cardVersion >= 1;
			SendCard1Holder.Visible = cardVersion >= 1;
			notePanel_Send_Card1stDate.Visible = cardVersion >= 1;
			SendCard1Date.Visible = cardVersion >= 1;
			notePanel_Send_Card1stRemove.Visible = cardVersion >= 1;
			removeCard1.Visible = cardVersion >= 1;
			lblMark1.Visible = cardVersion >= 1;

			//¿¨2
			notePanel_Send_Card2ndNumber.Visible = cardVersion >= 2;
			SendCard2Number.Visible = cardVersion >= 2;
			notePanel_Send_Card2ndHolder.Visible = cardVersion >= 2;
			SendCard2Holder.Visible = cardVersion >= 2;
			notePanel_Send_Card2ndDate.Visible = cardVersion >= 2;
			SendCard2Date.Visible = cardVersion >= 2;
			notePanel_Send_Card2ndRemove.Visible = cardVersion >= 2;
			removeCard2.Visible = cardVersion >= 2;
			lblMark2.Visible = cardVersion >= 2;

			//¿¨3
			notePanel_Send_Card3rdNumber.Visible = cardVersion >= 3;
			SendCard3Number.Visible = cardVersion >= 3;
			notePanel_Send_Card3rdHolder.Visible = cardVersion >= 3;
			SendCard3Holder.Visible = cardVersion >= 3;
			notePanel_Send_Card3rdDate.Visible = cardVersion >= 3;
			SendCard3Date.Visible = cardVersion >= 3;
			notePanel_Send_Card3rdRemove.Visible = cardVersion >= 3;
			removeCard3.Visible = cardVersion >= 3;
			lblMark3.Visible = cardVersion >= 3;

			//¿¨4
			notePanel_Send_Card4thNumber.Visible = cardVersion >= 4;
			SendCard4Number.Visible = cardVersion >= 4;
			notePanel_Send_Card4thHolder.Visible = cardVersion >= 4;
			SendCard4Holder.Visible = cardVersion >= 4;
			notePanel_Send_Card4thDate.Visible = cardVersion >= 4;
			SendCard4Date.Visible = cardVersion >= 4;
			notePanel_Send_Card4thRemove.Visible = cardVersion >= 4;
			removeCard4.Visible = cardVersion >= 4;
			lblMark4.Visible = cardVersion >= 4;

			//¿¨5
			notePanel_Send_Card5thNumber.Visible = cardVersion >= 5;
			SendCard5Number.Visible = cardVersion >= 5;
			notePanel_Send_Card5thHolder.Visible = cardVersion >= 5;
			SendCard5Holder.Visible = cardVersion >= 5;
			notePanel_Send_Card5thDate.Visible = cardVersion >= 5;
			SendCard5Date.Visible = cardVersion >= 5;
			notePanel_Send_Card5thRemove.Visible = cardVersion >= 5;
			removeCard5.Visible = cardVersion >= 5;
			lblMark5.Visible = cardVersion >= 5;
		}

		private void simpleButton_LoadEncryFile_Click(object sender, System.EventArgs e)
		{
			if ( openFileDialog_LoadEncryFile.ShowDialog() == DialogResult.OK )
			{
				FileStream fi = null;
				StreamReader sr = null;
				StreamWriter sw = null;
				try
				{
					string sourceFilePath = openFileDialog_LoadEncryFile.FileName;
					string sourceFileName = Path.GetFileName(sourceFilePath);
					string destinationFilePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
					string destinationFileName = destinationFilePath + @"\encry.bin";

					if(sourceFileName.Equals("encry.bin"))
					{
						if (!File.Exists(destinationFileName))
						{
							File.Copy(sourceFilePath,destinationFileName,true);
							MessageBox.Show("µ¼Èë³É¹¦!","ÏµÍ³ÐÅÏ¢",MessageBoxButtons.OK,MessageBoxIcon.Information);
						}
						else
						{
							File.Copy(destinationFileName, destinationFilePath + @"\encry" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".bin");

							ArrayList encryptCard = new ArrayList();
							ArrayList addCard = new ArrayList();
							encryptCard.Clear();
							addCard.Clear();

							fi = new FileStream(destinationFileName, FileMode.Open, FileAccess.Read);
							sr = new StreamReader(fi);

							while (true)
							{
								string card = sr.ReadLine();

								if (card != null)
								{
									if (!encryptCard.Contains(card))
									{
										encryptCard.Add(card);
									}
								}
								else
								{
									break;
								}
							}

							sr.Close();
							fi.Close();

							fi = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read);
							sr = new StreamReader(fi);

							while (true)
							{
								string card = sr.ReadLine();

								if (card != null)
								{
									if (!addCard.Contains(card))
									{
										addCard.Add(card);
									}
								}
								else
								{
									break;
								}
							}

							sr.Close();
							fi.Close();

							if (encryptCard.Count != 0)
							{
								string pattern = @"[0-9]|[A-Za-z]";

								foreach(object o in addCard)
								{
									StringBuilder cardId = new StringBuilder(o.ToString());
									MatchCollection matches = Regex.Matches(cardId[2].ToString(), pattern);
									
									if (matches.Count > 0)
									{
										if (!encryptCard.Contains(cardId.ToString()))
										{
											encryptCard.Add(cardId.ToString());
										}
									}
									else
									{

										char oldChar = (char)(((int)cardId[2] + (int)SPECIAL) - 2);
										char newChar = (char)((int)oldChar + 2);
										cardId[2] = newChar;

										try
										{
											if (encryptCard.Contains(cardId.ToString()))
											{
												encryptCard.Remove(cardId.ToString());
											}
										}
										catch
										{
											MessageBox.Show("²»ÕýÈ·µÄ¿¨ºÅ£¬¸Ã¿¨ºÅ±»ÉáÆú£¡");
										}
									}
								}

								File.Delete(destinationFileName);
								fi = new FileStream(destinationFileName, FileMode.Create, FileAccess.Write);
								sw = new StreamWriter(fi);
								foreach (object o in encryptCard)
								{
									sw.WriteLine(o.ToString());
								}

								MessageBox.Show("µ¼Èë³É¹¦!","ÏµÍ³ÐÅÏ¢",MessageBoxButtons.OK,MessageBoxIcon.Information);
							}
							else
							{
								File.Copy(sourceFilePath,destinationFileName,true);
								MessageBox.Show("µ¼Èë³É¹¦!","ÏµÍ³ÐÅÏ¢",MessageBoxButtons.OK,MessageBoxIcon.Information);
							}
						}
					}
					else
					{
						MessageBox.Show("¿¨ºÅÎÄ¼þ·Ç·¨,ÏêÏ¸Çé¿öÇëÁªÏµÉÏº£´´ÖÇÓ×½ÌÍæ¾ß¿Æ¼¼ÓÐÏÞ¹«Ë¾",
							"ÏµÍ³ÐÅÏ¢",MessageBoxButtons.OK,MessageBoxIcon.Information);
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message,"³ö´íÁË!",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
				finally
				{
					if (sw != null)
					{
						sw.Close();
					}
					if (sr != null)
					{
						sr.Close();
					}
					if (fi != null)
					{
						fi.Close();
					}
				}
			}
		}

		private void groupControl_DataSynchReceiDesk_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}


		private void SendUserName(byte destAddr, byte stuNumber, byte stuClassNum, string stuName, int month, int day)
		{
			DataFrame data = new DataFrame();
			data.sym = new byte[]{(byte)'@',(byte)'@'};
			data.desAddr = destAddr;
			data.srcAddr = 0;
			data.protocol = CPTT.SystemFramework.Util.SEND_USERNAME_TOKEN;
			data.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;
			byte[] nameBytes = System.Text.Encoding.GetEncoding("gb2312").GetBytes(stuName);
			data.comFrameLen = Convert.ToByte(13 + nameBytes.Length);
			data.frameData = new byte[5 + nameBytes.Length];
			data.frameData[0] = stuNumber;
			data.frameData[1] = stuClassNum;
			for(int i = 0; i < nameBytes.Length; i++)
				data.frameData[2 + i] = nameBytes[i];
			data.frameData[data.frameData.Length - 3] = Convert.ToByte(month);
			data.frameData[data.frameData.Length - 2] = Convert.ToByte(day);
			data.frameData[data.frameData.Length - 1] = Convert.ToByte(nameBytes.Length + 2);
			data.computeCheckSum();

            Monitor.Enter(Login.syncRoot);
			try
			{
				Login.handleComClass.WriteSerialCmd(data.comFrameLen, data.frameToBytes());//·¢ËÍÎÊÑ¯Ö¡
			}
			finally
			{
                Monitor.Exit(Login.syncRoot);
			}

			Timer_SendCardOverTime.Enabled = true;
						
			LoginForm.sendCardThread.Suspend();
		}

		private void LoginForm_SendUserNameSucceed()
		{
			Timer_SendCardOverTime.Enabled = false;

			isCardLogOutSucceed = true;
			isCardSendSucceed = true;
			
			try
			{
				LoginForm.sendCardThread.Resume();
			}
			catch{}
		}
	}
}

