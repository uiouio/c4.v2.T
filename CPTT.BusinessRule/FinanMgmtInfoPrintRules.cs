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
	/// <summary>0
	/// FinanMgmtInfoPrintRules 的摘要说明。
	/// </summary>
	public class FinanMgmtInfoPrintRules
	{
		private Excel.Application m_objExcel = null;
		private Excel.Workbooks m_objBooks = null;
		private Excel._Workbook m_objBook = null;
		private Excel.Sheets m_objSheets = null;
		private Excel._Worksheet m_objSheet = null;
		private Excel.Range m_objRange = null;
		private object m_objOpt = System.Reflection.Missing.Value;
		private string excelPath = AppDomain.CurrentDomain.BaseDirectory;
		public FinanMgmtInfoPrintRules()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void FinanMgmtInfoPrint(DataSet dsFinanInfo,string savePath)
		{
			int rowStart = 6;
			try
			{
				m_objExcel = new Excel.Application(); 
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;				
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\FinanMgmtInfo.xls",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt); 

				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;
				m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
				m_objSheet.Copy(m_objSheet,m_objOpt);
				m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
				m_objSheet.Name = dsFinanInfo.Tables[0].Rows[0][2].ToString();
				for ( int finanRow = 0;finanRow < dsFinanInfo.Tables[0].Rows.Count; finanRow ++ )
				{
					if ( !dsFinanInfo.Tables[0].Rows[finanRow][2].ToString().Equals(m_objSheet.Name) )
					{
						SetJumpBoard(rowStart,dsFinanInfo.Tables[0].Rows[finanRow-1][2].ToString());
						m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(m_objSheets.Count);
						m_objSheet.Copy(m_objSheet,m_objOpt);
						m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(m_objSheets.Count-1);
						m_objSheet.Name = dsFinanInfo.Tables[0].Rows[finanRow][2].ToString();
						rowStart = 6;
					}
					for ( int column = 1;column < dsFinanInfo.Tables[0].Columns.Count; column ++)
					{
						switch ( column )
						{
							case 1:		m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart,column],m_objSheet.Cells[rowStart+1,column]);
								m_objRange.MergeCells = true;
								m_objRange.Value = dsFinanInfo.Tables[0].Rows[finanRow][column].ToString();
								m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
								m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
								break;
							case 3:	    m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart,column-1],m_objSheet.Cells[rowStart+1,column-1]);
								m_objRange.MergeCells = true;
								m_objRange.Value = dsFinanInfo.Tables[0].Rows[finanRow][column].ToString();
								m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
								m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
								break;
							case 4:		m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart,column-1],m_objSheet.Cells[rowStart+1,column-1]);
								m_objRange.MergeCells = true;
								m_objRange.Value = dsFinanInfo.Tables[0].Rows[finanRow][column].ToString();
								m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
								m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
								break;
							case 5:		m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart,column-1],m_objSheet.Cells[rowStart,column-1]);
								m_objRange.Value = dsFinanInfo.Tables[0].Rows[finanRow][column].ToString();
								m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
								break;
							case 6:		m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart,column-1],m_objSheet.Cells[rowStart,column-1]);
								m_objRange.Value = dsFinanInfo.Tables[0].Rows[finanRow][column].ToString();
								m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
								break;
							case 7:		m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart,column-1],m_objSheet.Cells[rowStart,column-1]);
								m_objRange.Value = dsFinanInfo.Tables[0].Rows[finanRow][column].ToString();
								m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
								break;
							case 8:		m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart+1,column-4],m_objSheet.Cells[rowStart+1,column-4]);
								m_objRange.Value = dsFinanInfo.Tables[0].Rows[finanRow][column].ToString();
								m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
								break;
							case 9:		m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart+1,column-4],m_objSheet.Cells[rowStart+1,column-4]);
								m_objRange.Value = dsFinanInfo.Tables[0].Rows[finanRow][column].ToString();
								m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
								break;
							case 10:	m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart+1,column-4],m_objSheet.Cells[rowStart+1,column-4]);
								m_objRange.Value = dsFinanInfo.Tables[0].Rows[finanRow][column].ToString();
								m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
								break;
							case 11:	m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart,column-4],m_objSheet.Cells[rowStart,column-4]);
								m_objRange.Value = dsFinanInfo.Tables[0].Rows[finanRow][column].ToString();
								m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
								break;
							case 12:	m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart+1,column-5],m_objSheet.Cells[rowStart+1,column-5]);
								m_objRange.Value = dsFinanInfo.Tables[0].Rows[finanRow][column].ToString();
								m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
								break;
							case 13:	m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart,column-5],m_objSheet.Cells[rowStart+1,column-5]);
								m_objRange.MergeCells = true;
								m_objRange.Value = dsFinanInfo.Tables[0].Rows[finanRow][column].ToString();
								m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
								m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
								break;
						}
					}
					rowStart += 2;
				}
				SetJumpBoard(rowStart,dsFinanInfo.Tables[0].Rows[dsFinanInfo.Tables[0].Rows.Count-1][2].ToString());
				m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(m_objSheets.Count);
				m_objSheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;

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

		private void SetJumpBoard(int rowStart,string getClassName)
		{
			rowStart += 1;
			m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart,1],m_objSheet.Cells[rowStart+1,1]);
			m_objRange.MergeCells = true;
			m_objRange.Value = "园所信息：";
			m_objRange.Font.Size = 10;
			m_objRange.Font.Bold = true;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart,2],m_objSheet.Cells[rowStart+1,3]);
			m_objRange.MergeCells = true;
			m_objRange.Value = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
			m_objRange.Font.Size = 10;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
			m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart+2,1],m_objSheet.Cells[rowStart+3,1]);
			m_objRange.MergeCells = true;
			m_objRange.Value = "统计班级：";
			m_objRange.Font.Size = 10;
			m_objRange.Font.Bold = true;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart+2,2],m_objSheet.Cells[rowStart+3,3]);
			m_objRange.MergeCells = true;
			m_objRange.Value = getClassName;
			m_objRange.Font.Size = 10;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
			m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart+4,1],m_objSheet.Cells[rowStart+5,1]);
			m_objRange.MergeCells = true;
			m_objRange.Value = "制表日期：";
			m_objRange.Font.Size = 10;
			m_objRange.Font.Bold = true;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowStart+4,2],m_objSheet.Cells[rowStart+5,3]);
			m_objRange.MergeCells = true;
			m_objRange.Value = DateTime.Now.ToString("yyyy-MM-dd");
			m_objRange.Font.Size = 10;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
			m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
		}

		public void FinanceStatPrint(DataTable data, string className, DateTime date, string savePath)
		{
			DataTable dtPresents = new FinanInfoDataAccess().GetStudentPresents(date, className);
			if (dtPresents == null || dtPresents.Rows.Count == 0)
			{
				throw new Exception("没有要使用的数据！");
			}
			else
			{

				data.Columns.AddRange(new DataColumn[]{ new DataColumn("小计", Type.GetType("System.Double")),
															new DataColumn("stuPresent", Type.GetType("System.String")),
															new DataColumn("stuAbsent", Type.GetType("System.String"))});
				if (dtPresents.Rows.Count != data.Rows.Count)
				{
					throw new Exception("检测到数据完整性错误，请尝试重新生成数据！");
				}
				else
				{
					for (int i = 0; i < dtPresents.Rows.Count; i++)
					{
						data.Rows[i]["小计"] = 0;
						data.Rows[i]["stuPresent"] = dtPresents.Rows[i]["times"];
						data.Rows[i]["stuAbsent"] = dtPresents.Rows[i]["times_abs"];
					}
				}

				m_objExcel = new Excel.Application(); 
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;	 			
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath + @"report\FinanceStat.xls",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt); 
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;
				m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
				object[,] objData = new object[data.Rows.Count + 1, data.Columns.Count + 4];
				for(int row = 0; row < data.Rows.Count; row++)
				{
					objData[row, 0] = row + 1;
					for (int column = 0; column < data.Columns.Count - 3; column++)
					{
						if (column <= 2)
						{
							objData[row, column + 1] = data.Rows[row][column];
						}
						else if(column == 3)
						{
							objData[row, column + 1] = data.Rows[row][data.Columns.Count - 2];
							objData[row, column + 2] = data.Rows[row][data.Columns.Count - 1];
							double temp = Convert.ToDouble(data.Rows[row][column]);
							objData[row, column + 3] = temp;
							objData[data.Rows.Count, column + 3] = temp + (objData[data.Rows.Count, column + 3] == null ? 0 : 
								Convert.ToDouble(objData[data.Rows.Count, column + 3]));
						}
						else if (column >= 4 && column < 7)
						{
							double temp = Convert.ToDouble(data.Rows[row][column]);
							objData[row, column + 3] = temp;
							objData[data.Rows.Count, column + 3] = temp + (objData[data.Rows.Count, column + 3] == null ? 0 : 
								Convert.ToDouble(objData[data.Rows.Count, column + 3]));
						}
						else if (column == 7)
						{
							double temp1 = Convert.ToDouble(data.Rows[row][column - 4]) + 
								Convert.ToDouble(data.Rows[row][column - 3]) + Convert.ToDouble(data.Rows[row][column - 2]) +
								Convert.ToDouble(data.Rows[row][column - 1]);
							objData[row, column + 3] = temp1;

							double temp2 = Convert.ToDouble(data.Rows[row][column]);
 							objData[row, column + 4] = temp2;
							
							objData[data.Rows.Count, column + 3] = temp1 + (objData[data.Rows.Count, column + 3] == null ? 0 :
								Convert.ToDouble(objData[data.Rows.Count, column + 3]));
							objData[data.Rows.Count, column + 4] = temp2 + (objData[data.Rows.Count, column + 4] == null ? 0 :
								Convert.ToDouble(objData[data.Rows.Count, column + 4]));
						}
						else
						{
							double temp = Convert.ToDouble(data.Rows[row][column]);
							objData[row, column + 4] = temp;
							objData[data.Rows.Count, column + 4] = temp + (objData[data.Rows.Count, column + 4] == null ? 0 :
								Convert.ToDouble(objData[data.Rows.Count, column + 4]));
						}
					}
				}
				m_objRange = m_objSheet.get_Range("A6", m_objOpt);
				m_objRange = m_objRange.get_Resize(data.Rows.Count + 1, data.Columns.Count + 1);
				m_objRange.Value = objData;
				m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
				m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
				m_objRange.WrapText = true;
				m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				m_objRange.Font.Size = 10;

				m_objRange = m_objSheet.get_Range("G3", m_objOpt);
				m_objRange.Value = "各项费用";
				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[3, 7], m_objSheet.Cells[4, data.Columns.Count]);
				m_objRange.Merge(m_objOpt);
				m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
				m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
				m_objRange.WrapText = true;
				m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				m_objRange.Font.Size = 12;

				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[3, data.Columns.Count + 1], m_objSheet.Cells[4, data.Columns.Count + 1]);
				m_objRange.Merge(m_objOpt);
				m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
				m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
				m_objRange.WrapText = true;
				m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;

				object[, ] objColumn = new object[1, data.Columns.Count - 5];
				for (int column = 3; column < data.Columns.Count - 3; column++ )
				{
					if (column < 7)
					{
						objColumn[0, column - 3] = data.Columns[column].ColumnName;
					}
					if (column == 7)
					{
						objColumn[0, column - 3] = data.Columns[data.Columns.Count - 3].ColumnName;
						objColumn[0, column - 2] = data.Columns[column].ColumnName;
					}
					else
					{
						objColumn[0, column - 2] = data.Columns[column].ColumnName;
					}
				}

				m_objRange = m_objSheet.get_Range("G5", m_objOpt);
				m_objRange = m_objRange.get_Resize(1, data.Columns.Count - 5);
				m_objRange.Value = objColumn;
				m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
				m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
				m_objRange.WrapText = true;
				m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				m_objRange.Font.Size = 10.5;

				for (int column = 5; column < data.Columns.Count - 3; column++)
				{
					m_objRange = m_objSheet.get_Range(m_objSheet.Cells[6, column + 2], m_objSheet.Cells[5 + data.Rows.Count, column + 2]);
					object i = m_objRange.Calculate();
					string s = "asf";
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
