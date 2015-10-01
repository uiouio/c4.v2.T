using System;
using System.Data;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Data.OleDb;
using CPTT.SystemFramework;
using CPTT.DataAccess;

namespace CPTT.BusinessRule
{
    using Excel = Microsoft.Office.Interop.Excel;
	/// <summary>
	/// OptionRules 的摘要说明。
	/// </summary>
	public class OptionRules
	{
		private Excel.Application m_objExcel = null;
		private Excel.Workbooks m_objBooks = null;
		private Excel._Workbook m_objBook = null;
		private Excel.Sheets m_objSheets = null;
		private Excel._Worksheet m_objSheet = null;
		private Excel.Range m_objRange = null;
		private object m_objOpt = System.Reflection.Missing.Value;
		private string excelPath = AppDomain.CurrentDomain.BaseDirectory;

		public OptionRules()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void CreateStudentBaseSimpleTable()
		{
			KillProcess();	

			try
			{	
				m_objExcel = new Excel.Application();                 
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;				
				m_objBook = (Excel._Workbook)(m_objBooks.Open(               //打开该文件
					excelPath+@"\report\ImportBaseTableForStudent(simple).xls",Type.Missing,Type.Missing,Type.Missing,
					Type.Missing,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing));	                         

				m_objExcel.Visible = true;

			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
			}
			finally
			{
				m_objSheet = null;
				m_objSheets = null;
				m_objBook = null;
				m_objBooks = null;
				m_objExcel = null;

				GC.Collect();
			}
		}

		public void ReadStuInfoXLS(ref DataSet dsStuInfoXls,string getPath,int classNumbers,ref Hashtable className)
		{
			OleDbDataAdapter myAdp = null;
			OleDbConnection oleConn = null;
			string[] sheetName = new string[classNumbers];
			DataTable[] stuInfoXlsTable = new DataTable[classNumbers];

			try
			{
				m_objExcel = new Excel.Application();                 
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;				
				m_objBook = (Excel._Workbook)(m_objBooks.Open(               //打开该文件
					getPath,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing));	                         
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;
		
				for ( int i=0; i<classNumbers; i++ )
				{
					m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(i+1));     //记录工作表名称
					sheetName[i] = m_objSheet.Name.Trim();
					className.Add(i,sheetName[i]);
				}
				m_objBooks.Close();

				oleConn = new OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;data source=" + getPath    //打开驱动器
					+ ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'");
				oleConn.Open();
				
				for ( int i=0; i<classNumbers; i++ )
				{
					stuInfoXlsTable[i] = new DataTable("Table"+i.ToString());
					myAdp = new OleDbDataAdapter("select * from ["+sheetName[i]+"$]", oleConn);	    //获取第一张工作表的内容
					myAdp.Fill(stuInfoXlsTable[i]);
					dsStuInfoXls.Tables.Add(stuInfoXlsTable[i]);
				}

				oleConn.Close();

				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
			}
			finally
			{
				m_objSheet = null;
				m_objSheets = null;
				m_objBook = null;
				m_objBooks = null;
				m_objExcel = null;

				GC.Collect();

				KillProcess();	
			}
		}

		public void ReadTeaInfoXLS(ref DataSet dsTeaInfoXls,string getPath)
		{
			OleDbDataAdapter myAdp = null;
			OleDbConnection oleConn = null;
			try
			{
				m_objExcel = new Excel.Application();                 
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;				
				m_objBook = (Excel._Workbook)(m_objBooks.Open(               //打开该文件
					getPath,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing));	                         
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;

				oleConn = new OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;data source=" + getPath    //打开驱动器
					+ ";Extended Properties=Excel 8.0");
				oleConn.Open();

				myAdp = new OleDbDataAdapter("select * from [Sheet1$]", oleConn);	    //获取第一张工作表的内容
				myAdp.Fill(dsTeaInfoXls);

				oleConn.Close();

				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
			}
			finally
			{
				m_objSheet = null;
				m_objSheets = null;
				m_objBook = null;
				m_objBooks = null;
				m_objExcel = null;

				GC.Collect();

				KillProcess();	
			}
		}

		public void WriteStuCardInfoXLS(DataSet dsStuInfo,string getPath)
		{
			KillProcess();	

			try
			{	
				m_objExcel = new Excel.Application();                 
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;				
				m_objBook = (Excel._Workbook)(m_objBooks.Open(               //打开该文件
					getPath,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing));	                         
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;

				m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

				object[,] objData = null;
			
				if ( dsStuInfo.Tables[0].Rows.Count > 0 )
				{
					objData = new object[dsStuInfo.Tables[0].Rows.Count,2];

					for ( int i=0; i<dsStuInfo.Tables[0].Rows.Count; i++ )
					{
						objData[i,0] = dsStuInfo.Tables[0].Rows[i][0].ToString();
						objData[i,1] = dsStuInfo.Tables[0].Rows[i][1].ToString();
					}
				}

				m_objRange = m_objSheet.get_Range("A2",m_objOpt);
				m_objRange = m_objRange.get_Resize(dsStuInfo.Tables[0].Rows.Count,2);
				m_objRange.Value = objData;

				m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
				m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
				m_objRange.Font.Size = 10;

				m_objExcel.Visible = true;

			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
			}
			finally
			{
				m_objSheet = null;
				m_objSheets = null;
				m_objBook = null;
				m_objBooks = null;
				m_objExcel = null;

				GC.Collect();
			}

		}

		public void ReadStuCardInfoXLS(ref DataSet dsReadStuCardInfo,string getPath)
		{
			OleDbDataAdapter myAdp = null;
			OleDbConnection oleConn = null;
			try
			{
				m_objExcel = new Excel.Application();                 
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;				
				m_objBook = (Excel._Workbook)(m_objBooks.Open(               //打开该文件
					getPath,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing));	                         
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;

				oleConn = new OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;data source=" + getPath    //打开驱动器
					+ ";Extended Properties=Excel 8.0");
				oleConn.Open();

				myAdp = new OleDbDataAdapter("select * from [Sheet1$]", oleConn);	    //获取第一张工作表的内容
				myAdp.Fill(dsReadStuCardInfo);

				oleConn.Close();

				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
			}
			finally
			{
				m_objSheet = null;
				m_objSheets = null;
				m_objBook = null;
				m_objBooks = null;
				m_objExcel = null;

				GC.Collect();

				KillProcess();	
			}
		}

		public void ReadUpdateGradeInfo(ref DataTable dtUpdateGradeInfo,string getPath)
		{
			OleDbDataAdapter myAdp = null;
			OleDbConnection oleConn = null;
			try
			{
				m_objExcel = new Excel.Application();                 
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;				
				m_objBook = (Excel._Workbook)(m_objBooks.Open(               //打开该文件
					getPath,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing,Type.Missing,Type.Missing,Type.Missing,
					Type.Missing));	                         
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;

				oleConn = new OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;data source=" + getPath    //打开驱动器
					+ ";Extended Properties=Excel 8.0");
				oleConn.Open();

				myAdp = new OleDbDataAdapter("select * from [年班升级$]", oleConn);	    //获取第一张工作表的内容
				myAdp.Fill(dtUpdateGradeInfo);

				oleConn.Close();

				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
			}
			finally
			{
				m_objSheet = null;
				m_objSheets = null;
				m_objBook = null;
				m_objBooks = null;
				m_objExcel = null;

				GC.Collect();

				KillProcess();	
			}
		}

		private void KillProcess()
		{
			string processName = "Excel";
			System.Diagnostics.Process myproc= new System.Diagnostics.Process();
			//得到所有打开的进程
			try
			{
				foreach (Process thisproc in Process.GetProcessesByName(processName)) 
				{
					if(!thisproc.CloseMainWindow())
					{
						thisproc.Kill();
					}
				}
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
			}
		}
	}
}
