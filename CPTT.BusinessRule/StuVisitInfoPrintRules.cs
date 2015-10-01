using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using CPTT.DataAccess;
using CPTT.SystemFramework;
namespace CPTT.BusinessRule
{
    using Excel = Microsoft.Office.Interop.Excel;
	/// <summary>
	/// StuVisitInfoPrintRules 的摘要说明。
	/// </summary>
	public class StuVisitInfoPrintRules
	{
		private Excel.Application m_objExcel = null;
		private Excel.Workbooks m_objBooks = null;
		private Excel._Workbook m_objBook = null;
		private Excel.Sheets m_objSheets = null;
		private Excel._Worksheet m_objSheet = null;
		private Excel.Range m_objRange = null;
		private object m_objOpt = System.Reflection.Missing.Value;
		private string excelPath = AppDomain.CurrentDomain.BaseDirectory;
		private string path;
		private string destPath;
		public StuVisitInfoPrintRules()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void VisitInfoPrint(DataSet dsAbsDetailInfo,DateTime getBegDate,DateTime getEndDate,string savePath)
		{
			try
			{
				m_objExcel = new Excel.Application(); 
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;		
		
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\VisitInfo.xls",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt); 
 
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;
				m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
				
				for ( int row = 0; row < dsAbsDetailInfo.Tables[0].Rows.Count; row ++ )
				{
					for( int column = 1 ;column < dsAbsDetailInfo.Tables[0].Columns.Count-2; column ++)
					{
						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+6,column+1],m_objSheet.Cells[row+6,column+1]);
						m_objRange.Value = dsAbsDetailInfo.Tables[0].Rows[row][column].ToString();
						m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
					}

					if ( row == dsAbsDetailInfo.Tables[0].Rows.Count - 1 )
					{
						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+8,2],m_objSheet.Cells[row+8,3]);
						m_objRange.MergeCells = true;
						m_objRange.Value = "园所信息：";
						m_objRange.Font.Bold = true;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
						
						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+8,4],m_objSheet.Cells[row+8,4]);
						m_objRange.Value = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+9,2],m_objSheet.Cells[row+9,3]);
						m_objRange.MergeCells = true;
						m_objRange.Value = "统计启始时间：";
						m_objRange.Font.Bold = true;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+9,4],m_objSheet.Cells[row+9,4]);
						m_objRange.Value = getBegDate;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+10,2],m_objSheet.Cells[row+10,3]);
						m_objRange.MergeCells = true;
						m_objRange.Value = "统计截止时间：";
						m_objRange.Font.Bold = true;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+10,4],m_objSheet.Cells[row+10,4]);
						m_objRange.Value = getEndDate;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


					}
				}

				m_objBook.SaveAs(savePath, m_objOpt, m_objOpt,
					m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
					m_objOpt, m_objOpt, m_objOpt, m_objOpt);
				m_objBook.Close(false, m_objOpt, m_objOpt);
				m_objExcel.Quit();

				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
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
				m_objRange = null;
				m_objSheet = null;
				m_objSheets = null;
				m_objBook = null;
				m_objBooks = null;
				m_objExcel = null;

				GC.Collect();

				KillProcess();
			}

		}

		public void SetPath(string getPath,string getDestPath)
		{
			this.path = getPath;
			this.destPath = getDestPath;
		}

		private string GetPath()
		{
			return path;
		}

		private string GetDestPath()
		{
			return destPath;
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
