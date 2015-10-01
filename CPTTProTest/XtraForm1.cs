using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Data;
using System.Runtime.InteropServices;
using System.Xml;

using Microsoft.Practices.EnterpriseLibrary.Configuration;

namespace CPTTProTest
{
	/// <summary>
	/// Summary description for XtraForm1.
	/// </summary>
	public class XtraForm1 : DevExpress.XtraEditors.XtraForm
	{
		private System.Windows.Forms.PrintDialog printDialog1;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private CPTTProTest.DataSet1 dataSet11;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public XtraForm1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new XtraForm1());
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(XtraForm1));
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
			this.dataSet11 = new CPTTProTest.DataSet1();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
			this.SuspendLayout();
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Location = new System.Drawing.Point(260, 17);
			this.printPreviewDialog1.MinimumSize = new System.Drawing.Size(375, 250);
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog1.Visible = false;
			// 
			// dataSet11
			// 
			this.dataSet11.DataSetName = "DataSet1";
			this.dataSet11.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "SMS_Register_Info", new System.Data.Common.DataColumnMapping[] {
																																																						   new System.Data.Common.DataColumnMapping("smsInfo_id", "smsInfo_id"),
																																																						   new System.Data.Common.DataColumnMapping("studInfo_stuid", "studInfo_stuid"),
																																																						   new System.Data.Common.DataColumnMapping("familial_name", "familial_name"),
																																																						   new System.Data.Common.DataColumnMapping("mobilePhone_number", "mobilePhone_number"),
																																																						   new System.Data.Common.DataColumnMapping("stu_grade", "stu_grade"),
																																																						   new System.Data.Common.DataColumnMapping("stu_class", "stu_class")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM SMS_Register_Info WHERE (smsInfo_id = @Original_smsInfo_id) AND (familial_name = @Original_familial_name) AND (mobilePhone_number = @Original_mobilePhone_number) AND (stu_class = @Original_stu_class) AND (stu_grade = @Original_stu_grade) AND (studInfo_stuid = @Original_studInfo_stuid)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_smsInfo_id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "smsInfo_id", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_familial_name", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "familial_name", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_mobilePhone_number", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "mobilePhone_number", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_stu_class", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "stu_class", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_stu_grade", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "stu_grade", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_studInfo_stuid", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "studInfo_stuid", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=YOUNG;packet size=4096;user id=ctpp;password=ctpp;data source=\"YAN" +
				"FASERVER\\CZSERVER\";persist security info=False;initial catalog=CTPPDB";
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO SMS_Register_Info(studInfo_stuid, familial_name, mobilePhone_number, stu_grade, stu_class) VALUES (@studInfo_stuid, @familial_name, @mobilePhone_number, @stu_grade, @stu_class); SELECT smsInfo_id, studInfo_stuid, familial_name, mobilePhone_number, stu_grade, stu_class FROM SMS_Register_Info WHERE (smsInfo_id = @@IDENTITY)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@studInfo_stuid", System.Data.SqlDbType.VarChar, 50, "studInfo_stuid"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@familial_name", System.Data.SqlDbType.VarChar, 10, "familial_name"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mobilePhone_number", System.Data.SqlDbType.VarChar, 15, "mobilePhone_number"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@stu_grade", System.Data.SqlDbType.SmallInt, 2, "stu_grade"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@stu_class", System.Data.SqlDbType.SmallInt, 2, "stu_class"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT smsInfo_id, studInfo_stuid, familial_name, mobilePhone_number, stu_grade, " +
				"stu_class FROM SMS_Register_Info";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE SMS_Register_Info SET studInfo_stuid = @studInfo_stuid, familial_name = @familial_name, mobilePhone_number = @mobilePhone_number, stu_grade = @stu_grade, stu_class = @stu_class WHERE (smsInfo_id = @Original_smsInfo_id) AND (familial_name = @Original_familial_name) AND (mobilePhone_number = @Original_mobilePhone_number) AND (stu_class = @Original_stu_class) AND (stu_grade = @Original_stu_grade) AND (studInfo_stuid = @Original_studInfo_stuid); SELECT smsInfo_id, studInfo_stuid, familial_name, mobilePhone_number, stu_grade, stu_class FROM SMS_Register_Info WHERE (smsInfo_id = @smsInfo_id)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@studInfo_stuid", System.Data.SqlDbType.VarChar, 50, "studInfo_stuid"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@familial_name", System.Data.SqlDbType.VarChar, 10, "familial_name"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mobilePhone_number", System.Data.SqlDbType.VarChar, 15, "mobilePhone_number"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@stu_grade", System.Data.SqlDbType.SmallInt, 2, "stu_grade"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@stu_class", System.Data.SqlDbType.SmallInt, 2, "stu_class"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_smsInfo_id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "smsInfo_id", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_familial_name", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "familial_name", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_mobilePhone_number", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "mobilePhone_number", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_stu_class", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "stu_class", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_stu_grade", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "stu_grade", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_studInfo_stuid", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "studInfo_stuid", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@smsInfo_id", System.Data.SqlDbType.Int, 4, "smsInfo_id"));
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(320, 360);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(312, 168);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(312, 232);
			this.label2.Name = "label2";
			this.label2.TabIndex = 2;
			this.label2.Text = "label1";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(304, 272);
			this.label3.Name = "label3";
			this.label3.TabIndex = 2;
			this.label3.Text = "label1";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(304, 312);
			this.label4.Name = "label4";
			this.label4.TabIndex = 2;
			this.label4.Text = "label1";
			// 
			// XtraForm1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(616, 421);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Name = "XtraForm1";
			this.Text = "XtraForm1";
			this.Load += new System.EventHandler(this.XtraForm1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void popupContainerEdit1_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
		{
//			string tt = string.Empty;
//			foreach(CheckedListBoxItem item in checkedListBoxControl1.CheckedItems)
//			{
//				if(item.CheckState == CheckState.Checked)
//					tt = tt + item.Value + ",";
//			}
//			e.Value = tt;
		}

		private void popupContainerEdit1_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
		{
		
		}

		private void simpleButton3_Click(object sender, System.EventArgs e)
		{
//			DataTable dt = new DataTable();
//			DataColumn c1 = new DataColumn("Test1",System.Type.GetType("System.String"));
//			DataColumn c2 = new DataColumn("Test2",System.Type.GetType("System.String"));
//
//			dt.Columns.Add(c1);
//			dt.Columns.Add(c2);
//
//			DataSet ds = new DataSet();
//			ds.Tables.Add(dt);
//
//			DataRow dr = ds.Tables[0].NewRow();
//
//			dr[0] = "A";
//			dr[1] = "B";
//
//			DataRow dr1 = ds.Tables[0].NewRow();
//
//			dr1[0] = "A";
//			dr1[1] = "C";
//
//			DataRow dr2 = ds.Tables[0].NewRow();
//
//			dr2[0] = "A";
//			dr2[1] = "D";
//
//			dt.Rows.Add(dr);
//			dt.Rows.Add(dr1);
//			dt.Rows.Add(dr2);
//
//			gridColumn1.FieldName = "Test1";
//			gridColumn2.FieldName = "Test2";
//			gridControl1.DataSource = ds.Tables[0];
//
//			gridView1.SetRowCellValue(0,gridView1.Columns[0],"1");
		}

		private void repositoryItemPopupContainerEdit1_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
		{
//			string tt = string.Empty;
//			foreach(CheckedListBoxItem item in checkedListBoxControl1.CheckedItems)
//			{
//				if(item.CheckState == CheckState.Checked)
//					tt = tt + item.Value + ",";
//			}
//			e.Value = tt;
		}

		private void simpleButton4_Click(object sender, System.EventArgs e)
		{
//			printDialog1.ShowDialog();
			printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
			
//			printDialog1.Document = printDocument1;
//			printDialog1.ShowDialog();
			pageSetupDialog1.Document = printDocument1;
			pageSetupDialog1.ShowDialog();

			printPreviewDialog1.Document = printDocument1;
			printPreviewDialog1.ShowDialog();
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			e.Graphics.DrawString("Test",new Font("Tahoma",100),Brushes.Green,e.MarginBounds.Left,e.MarginBounds.Top+20);
			e.Graphics.FillRectangle(Brushes.Red, 
				new Rectangle(500, 500, 500, 500));

		}

		private void XtraForm1_Load(object sender, System.EventArgs e)
		{
//			ArrayList ar = new ArrayList();
//			ar.Add(300);
//			ar.Add(1);
//			ar.Add(true);
//			ar.Add(DateTime.Now);
		
//			ConfigurationManager.WriteConfiguration("CustomizeSettings",ar);

			ArrayList ar = ConfigurationManager.GetConfiguration("CustomizeSettings") as ArrayList;

			label1.Text = (ar[0] as XmlNode[])[0].InnerText;
			label2.Text = (ar[0] as XmlNode[])[1].InnerText;
			label3.Text = (ar[1] as XmlNode[])[0].InnerText;
			label4.Text = (ar[1] as XmlNode[])[1].InnerText;

		}

		[StructLayout(LayoutKind.Sequential, Pack=1)]
			internal struct TokPriv1Luid
		{
			public int Count;
			public long Luid;
			public int Attr;
		}

		[DllImport("kernel32.dll", ExactSpelling=true) ]
		internal static extern IntPtr GetCurrentProcess();

		[DllImport("advapi32.dll", ExactSpelling=true, SetLastError=true) ]
		internal static extern bool OpenProcessToken( IntPtr h, int acc, ref IntPtr phtok );

		[DllImport("advapi32.dll", SetLastError=true) ]
		internal static extern bool LookupPrivilegeValue( string host, string name, ref long pluid );

		[DllImport("advapi32.dll", ExactSpelling=true, SetLastError=true) ]
		internal static extern bool AdjustTokenPrivileges( IntPtr htok, bool disall,
			ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen );

		[DllImport("user32.dll", ExactSpelling=true, SetLastError=true) ]
		internal static extern bool ExitWindowsEx( int flag, int rea );

		internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
		internal const int TOKEN_QUERY = 0x00000008;
		internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
		internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
		internal const int EWX_LOGOFF = 0x00000000;
		internal const int EWX_SHUTDOWN = 0x00000001;
		internal const int EWX_REBOOT = 0x00000002;
		internal const int EWX_FORCE = 0x00000004;
		internal const int EWX_POWEROFF = 0x00000008;
		internal const int EWX_FORCEIFHUNG = 0x00000010;

		private void DoExitWin( int flag )
		{
			bool ok;
			TokPriv1Luid tp;
			IntPtr hproc = GetCurrentProcess();
			IntPtr htok = IntPtr.Zero;
			ok = OpenProcessToken( hproc, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok );
			tp.Count = 1;
			tp.Luid = 0;
			tp.Attr = SE_PRIVILEGE_ENABLED;
			ok = LookupPrivilegeValue( null, SE_SHUTDOWN_NAME, ref tp.Luid );
			ok = AdjustTokenPrivileges( htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero );
			ok = ExitWindowsEx( flag|EWX_FORCE, 0 );
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
//			DoExitWin(EWX_SHUTDOWN);
		}

	}
}

