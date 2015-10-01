using System;
using System.Data;
using CPTT.SystemFramework;
using CPTT.DataAccess;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace CPTT.BusinessRule
{
    using Excel = Microsoft.Office.Interop.Excel;
	/// <summary>
	/// TeaDutyRule 的摘要说明。
	/// </summary>
	public class TeaDutyRule
	{
		public TeaDutyRule()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void ImportTeaDutyNormalReports(DataSet teaDutyInfo,string savePath,DateTime getBegDate,DateTime getEndDate)
		{
			object[,] objData;

			string excelTempFilePath = AppDomain.CurrentDomain.BaseDirectory;

			Excel.Application m_objExcel = null;
			Excel.Workbooks m_objBooks = null;
			Excel._Workbook m_objBook = null;
			Excel.Sheets m_objSheets = null;
			Excel._Worksheet m_objSheet = null;
			Excel.Range m_objRange = null;
			Excel.Font m_objFont = null;
			System.Reflection.Missing m_objOpt = System.Reflection.Missing.Value;

			try
			{
				if ( teaDutyInfo.Tables[0].Rows.Count > 0 )
				{
					objData = new Object[teaDutyInfo.Tables[0].Rows.Count,6];

					for( int i=0; i<teaDutyInfo.Tables[0].Rows.Count; i++ )
					{
						objData[i,0] = teaDutyInfo.Tables[0].Rows[i][3].ToString();
						objData[i,1] = teaDutyInfo.Tables[0].Rows[i][2].ToString();
						objData[i,2] = teaDutyInfo.Tables[0].Rows[i][0].ToString();
						objData[i,3] = teaDutyInfo.Tables[0].Rows[i][1].ToString();
						objData[i,4] = teaDutyInfo.Tables[0].Rows[i][4].ToString();
						objData[i,5] = teaDutyInfo.Tables[0].Rows[i][5].ToString();
					}

					m_objExcel = new Excel.Application();
					m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
					m_objBook = (Excel._Workbook)m_objBooks.Open(excelTempFilePath+@"report\TeacherDutyNormal.xls",
						m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
						m_objOpt,m_objOpt,m_objOpt);

					m_objSheets = (Excel.Sheets)m_objBook.Sheets;
					m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));
					m_objRange = m_objSheet.get_Range("A3",m_objOpt);
					m_objRange = m_objRange.get_Resize(teaDutyInfo.Tables[0].Rows.Count,6);

					m_objRange.Value = objData;

					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					m_objFont = m_objRange.Font;
					m_objFont.Size = 9;

					m_objRange = m_objSheet.get_Range("A"+(teaDutyInfo.Tables[0].Rows.Count+4).ToString(),m_objOpt);
					m_objRange.Value = "园所:      "+new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 12;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("A"+(teaDutyInfo.Tables[0].Rows.Count+5).ToString(),m_objOpt);
					m_objRange.Value = "统计日期:  "+getBegDate.ToString("yyyy.MM.dd")+"-"+getEndDate.ToString("yyyy.MM.dd");
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 12;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objBook.SaveAs(savePath, m_objOpt, m_objOpt,
						m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
						m_objOpt, m_objOpt, m_objOpt, m_objOpt);
					m_objBook.Close(false, m_objOpt, m_objOpt);
					m_objExcel.Quit();

					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objFont);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
				}
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
			}
			finally
			{
				m_objFont = null;
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

		public void ImportTeaDutyDetailsReports(DataSet teaDutyInfo,string savePath,DateTime getBegDate,DateTime getEndDate)
		{
			object[,] objData;
			
			string excelTempFilePath = AppDomain.CurrentDomain.BaseDirectory;

			Excel.Application m_objExcel = null;
			Excel.Workbooks m_objBooks = null;
			Excel._Workbook m_objBook = null;
			Excel.Sheets m_objSheets = null;
			Excel._Worksheet m_objSheet = null;
			Excel.Range m_objRange = null;
			Excel.Font m_objFont = null;
			System.Reflection.Missing m_objOpt = System.Reflection.Missing.Value;

			try
			{
				if ( teaDutyInfo.Tables[0].Rows.Count > 0 )
				{
					objData = new Object[teaDutyInfo.Tables[0].Rows.Count,13];

					for(int i=0;i<teaDutyInfo.Tables[0].Rows.Count;i++)
					{
						objData[i,0] = teaDutyInfo.Tables[0].Rows[i][0].ToString();
						objData[i,1] = teaDutyInfo.Tables[0].Rows[i][1].ToString();
						objData[i,2] = teaDutyInfo.Tables[0].Rows[i][2].ToString();
						objData[i,3] = teaDutyInfo.Tables[0].Rows[i][3].ToString();
						objData[i,4] = teaDutyInfo.Tables[0].Rows[i][4].ToString();
						objData[i,5] = teaDutyInfo.Tables[0].Rows[i][5].ToString();
						objData[i,6] = teaDutyInfo.Tables[0].Rows[i][6].ToString();
						objData[i,7] = teaDutyInfo.Tables[0].Rows[i][7].ToString();
						objData[i,8] = teaDutyInfo.Tables[0].Rows[i][8].ToString();
						objData[i,9] = teaDutyInfo.Tables[0].Rows[i][9].ToString();
						objData[i,10] = teaDutyInfo.Tables[0].Rows[i][10].ToString();
						objData[i,11] = teaDutyInfo.Tables[0].Rows[i][11].ToString();
						objData[i,12] = teaDutyInfo.Tables[0].Rows[i][12].ToString();
					}

					m_objExcel = new Excel.Application();
					m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
					m_objBook = (Excel._Workbook)m_objBooks.Open(excelTempFilePath+@"report\TeacherDutyDetails.xls",
						m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
						m_objOpt,m_objOpt,m_objOpt);

					m_objSheets = (Excel.Sheets)m_objBook.Sheets;
					m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));
					m_objRange = m_objSheet.get_Range("A3",m_objOpt);
					m_objRange = m_objRange.get_Resize(teaDutyInfo.Tables[0].Rows.Count,13);

					m_objRange.Value = objData;

					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					m_objFont = m_objRange.Font;
					m_objFont.Size = 9;

					m_objRange = m_objSheet.get_Range("A"+(teaDutyInfo.Tables[0].Rows.Count+4).ToString(),m_objOpt);
					m_objRange.Value = "园所:      "+new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 12;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("A"+(teaDutyInfo.Tables[0].Rows.Count+5).ToString(),m_objOpt);
					m_objRange.Value = "统计日期:  "+getBegDate.ToString("yyyy.MM.dd")+"-"+getEndDate.ToString("yyyy.MM.dd");
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 12;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objBook.SaveAs(savePath, m_objOpt, m_objOpt,
						m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
						m_objOpt, m_objOpt, m_objOpt, m_objOpt);
					m_objBook.Close(false, m_objOpt, m_objOpt);
					m_objExcel.Quit();

					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objFont);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
				}
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
			}
			finally
			{
				m_objFont = null;
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

		public void ImportTeaDutySummaryReports(DataSet teaDutyInfo,string savePath,DateTime getBegDate,DateTime getEndDate)
		{
			object[,] objData;
			
			string excelTempFilePath = AppDomain.CurrentDomain.BaseDirectory;

			Excel.Application m_objExcel = null;
			Excel.Workbooks m_objBooks = null;
			Excel._Workbook m_objBook = null;
			Excel.Sheets m_objSheets = null;
			Excel._Worksheet m_objSheet = null;
			Excel.Range m_objRange = null;
			Excel.Font m_objFont = null;
			System.Reflection.Missing m_objOpt = System.Reflection.Missing.Value;

			try
			{
				if ( teaDutyInfo.Tables[0].Rows.Count > 0 )
				{
					objData = new Object[teaDutyInfo.Tables[0].Rows.Count,8];

					for( int i=0; i<teaDutyInfo.Tables[0].Rows.Count; i++ )
					{
						objData[i,0] = teaDutyInfo.Tables[0].Rows[i][0].ToString();
						objData[i,1] = teaDutyInfo.Tables[0].Rows[i][1].ToString();
						objData[i,2] = teaDutyInfo.Tables[0].Rows[i][2].ToString();
						objData[i,3] = teaDutyInfo.Tables[0].Rows[i][3].ToString();
						objData[i,4] = teaDutyInfo.Tables[0].Rows[i][4].ToString();
						objData[i,5] = teaDutyInfo.Tables[0].Rows[i][5].ToString();
						objData[i,6] = teaDutyInfo.Tables[0].Rows[i][6].ToString();
						objData[i,7] = teaDutyInfo.Tables[0].Rows[i][7].ToString();
					}

					m_objExcel = new Excel.Application();
					m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
					m_objBook = (Excel._Workbook)m_objBooks.Open(excelTempFilePath+@"report\TeacherDutySummary.xls",
						m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
						m_objOpt,m_objOpt,m_objOpt);

					m_objSheets = (Excel.Sheets)m_objBook.Sheets;
					m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));
					m_objRange = m_objSheet.get_Range("A3",m_objOpt);
					m_objRange = m_objRange.get_Resize(teaDutyInfo.Tables[0].Rows.Count,8);

					m_objRange.Value = objData;

					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					m_objFont = m_objRange.Font;
					m_objFont.Size = 9;

					m_objRange = m_objSheet.get_Range("A"+(teaDutyInfo.Tables[0].Rows.Count+4).ToString(),m_objOpt);
					m_objRange.Value = "园所:      "+new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 12;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("A"+(teaDutyInfo.Tables[0].Rows.Count+5).ToString(),m_objOpt);
					m_objRange.Value = "统计日期:  "+getBegDate.ToString("yyyy.MM.dd")+"-"+getEndDate.ToString("yyyy.MM.dd");
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 12;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objBook.SaveAs(savePath, m_objOpt, m_objOpt,
						m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
						m_objOpt, m_objOpt, m_objOpt, m_objOpt);
					m_objBook.Close(false, m_objOpt, m_objOpt);
					m_objExcel.Quit();

					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objFont);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
				}
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
			}
			finally
			{
				m_objFont = null;
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

		public void ImportTeaOutDetailsReports(DataSet teaOutInfo,string savePath,DateTime getBegDate,DateTime getEndDate)
		{
			object[,] objData;
			
			string excelTempFilePath = AppDomain.CurrentDomain.BaseDirectory;

			Excel.Application m_objExcel = null;
			Excel.Workbooks m_objBooks = null;
			Excel._Workbook m_objBook = null;
			Excel.Sheets m_objSheets = null;
			Excel._Worksheet m_objSheet = null;
			Excel.Range m_objRange = null;
			Excel.Font m_objFont = null;
			System.Reflection.Missing m_objOpt = System.Reflection.Missing.Value;

			try
			{
				if ( teaOutInfo.Tables[0].Rows.Count > 0 )
				{
					objData = new Object[teaOutInfo.Tables[0].Rows.Count,8];

					for(int i=0;i<teaOutInfo.Tables[0].Rows.Count;i++)
					{
						objData[i,0] = teaOutInfo.Tables[0].Rows[i][0].ToString();
						objData[i,1] = teaOutInfo.Tables[0].Rows[i][1].ToString();
						objData[i,2] = teaOutInfo.Tables[0].Rows[i][2].ToString();
						objData[i,3] = teaOutInfo.Tables[0].Rows[i][3].ToString();
						objData[i,4] = teaOutInfo.Tables[0].Rows[i][4].ToString();
						objData[i,5] = teaOutInfo.Tables[0].Rows[i][5].ToString();
						objData[i,6] = teaOutInfo.Tables[0].Rows[i][6].ToString();
						objData[i,7] = teaOutInfo.Tables[0].Rows[i][7].ToString();
					}

					m_objExcel = new Excel.Application();
					m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
					m_objBook = (Excel._Workbook)m_objBooks.Open(excelTempFilePath+@"report\TeacherOutDetails.xls",
						m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
						m_objOpt,m_objOpt,m_objOpt);

					m_objSheets = (Excel.Sheets)m_objBook.Sheets;
					m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));
					m_objRange = m_objSheet.get_Range("A3",m_objOpt);
					m_objRange = m_objRange.get_Resize(teaOutInfo.Tables[0].Rows.Count,8);

					m_objRange.Value = objData;

					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					m_objFont = m_objRange.Font;
					m_objFont.Size = 9;

					m_objRange = m_objSheet.get_Range("A"+(teaOutInfo.Tables[0].Rows.Count+4).ToString(),m_objOpt);
					m_objRange.Value = "园所:      "+new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 12;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("A"+(teaOutInfo.Tables[0].Rows.Count+5).ToString(),m_objOpt);
					m_objRange.Value = "统计日期:  "+getBegDate.ToString("yyyy.MM.dd")+"-"+getEndDate.ToString("yyyy.MM.dd");
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 12;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objBook.SaveAs(savePath, m_objOpt, m_objOpt,
						m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
						m_objOpt, m_objOpt, m_objOpt, m_objOpt);
					m_objBook.Close(false, m_objOpt, m_objOpt);
					m_objExcel.Quit();

					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objFont);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
				}
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
			}
			finally
			{
				m_objFont = null;
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

		public void ExportTeacherAllReports(string path, DateTime startDate, DateTime endDate)
		{

			string excelTempFilePath = AppDomain.CurrentDomain.BaseDirectory;

			Excel.Application m_objExcel = null;
			Excel.Workbooks m_objBooks = null;
			Excel._Workbook m_objBook = null;
			Excel.Sheets m_objSheets = null;
			Excel._Worksheet m_objSheet = null;
			Excel.Range m_objRange = null;
			Excel.Font m_objFont = null;
			System.Reflection.Missing m_objOpt = System.Reflection.Missing.Value;

			try
			{
				m_objExcel = new Excel.Application();
				m_objExcel.DisplayAlerts = false;
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelTempFilePath+@"report\TeacherDutyAll.xls",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt);

				ExportAllNormal(startDate, endDate,m_objBook,m_objSheets,m_objSheet,m_objRange,m_objFont,m_objOpt);
				ExportStat(startDate, endDate,m_objBook,m_objSheets,m_objSheet,m_objRange,m_objFont,m_objOpt);
				ExportSingleStat(startDate, endDate,m_objBook,m_objSheets,m_objSheet,m_objRange,m_objFont,m_objOpt);
				ExportSingle(startDate, endDate,m_objBook,m_objSheets,m_objSheet,m_objRange,m_objFont,m_objOpt);

				m_objBook.SaveAs(path, m_objOpt, m_objOpt,
					m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
					m_objOpt, m_objOpt, m_objOpt, m_objOpt);
				m_objBook.Close(false, m_objOpt, m_objOpt);
				m_objExcel.Quit();

				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objFont);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
			}
			finally
			{
				m_objFont = null;
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

		#region 生成教师所有普通报表
		private void ExportAllNormal(
			DateTime startDate, 
			DateTime endDate,
			Excel._Workbook m_objBook, 
			Excel.Sheets m_objSheets, 
			Excel._Worksheet m_objSheet, 
			Excel.Range m_objRange,
			Excel.Font m_objFont,
			System.Reflection.Missing m_objOpt)
		{
			object[,] objData;
			using(DataTable dt = new DutyInfoDA().GetTeaDutyNormal(string.Empty,string.Empty,string.Empty,string.Empty,startDate,endDate,100).Tables[0])
			{
				if ( dt != null && dt.Rows.Count > 0 )
				{
					objData = new Object[dt.Rows.Count,6];

					for( int i=0; i<dt.Rows.Count; i++ )
					{
						objData[i,0] = dt.Rows[i][3].ToString();
						objData[i,1] = dt.Rows[i][2].ToString();
						objData[i,2] = dt.Rows[i][0].ToString();
						objData[i,3] = dt.Rows[i][1].ToString();
						objData[i,4] = dt.Rows[i][4].ToString();
						objData[i,5] = dt.Rows[i][5].ToString();
					}
					
					m_objSheets = (Excel.Sheets)m_objBook.Sheets;
					m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));
					m_objRange = m_objSheet.get_Range("A3",m_objOpt);
					m_objRange = m_objRange.get_Resize(dt.Rows.Count,6);

					m_objRange.Value = objData;

					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					m_objFont = m_objRange.Font;
					m_objFont.Size = 9;

					m_objRange = m_objSheet.get_Range("A"+(dt.Rows.Count+4).ToString(),m_objOpt);
					m_objRange.Value = "园所:";
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("B"+(dt.Rows.Count+4).ToString(),m_objOpt);
					m_objRange.Value = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("A"+(dt.Rows.Count+5).ToString(),m_objOpt);
					m_objRange.Value = "统计开始日期:";
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("B"+(dt.Rows.Count+5).ToString(),m_objOpt);
					m_objRange.Value = startDate.ToString("yyyy.MM.dd");
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("A"+(dt.Rows.Count+6).ToString(),m_objOpt);
					m_objRange.Value = "统计结束日期:";
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("B"+(dt.Rows.Count+6).ToString(),m_objOpt);
					m_objRange.Value = endDate.ToString("yyyy.MM.dd");
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
				}
			}
		}


		private void ExportStat(
			DateTime startDate, 
			DateTime endDate,
			Excel._Workbook m_objBook, 
			Excel.Sheets m_objSheets, 
			Excel._Worksheet m_objSheet, 
			Excel.Range m_objRange,
			Excel.Font m_objFont,
			System.Reflection.Missing m_objOpt)
		{
			object[,] objData;
			using(DataTable dt = new DutyInfoDA().GetTeacherStatByDuty(startDate, endDate))
			{
				if (dt != null && dt.Rows.Count > 0 )
				{
					objData = new Object[dt.Rows.Count + 1,5];
					
					double totalAttendCount = 0;
					double totalShouldAttendCount = 0;
					double totalAbsenceCount = 0;
					int days = SetAttendDays(startDate, endDate);
					for( int i=0; i<dt.Rows.Count; i++ )
					{
						double attendCount = Convert.ToInt32(dt.Rows[i][2]);
						double shouldAttendCount = Convert.ToInt32(dt.Rows[i][1]) * days;
						double absenceCount = shouldAttendCount - attendCount;
						objData[i, 0] = dt.Rows[i][0].ToString();
						objData[i, 1] = shouldAttendCount;
						objData[i, 2] = attendCount;
						objData[i, 3] = absenceCount < 0 ? 0 : absenceCount;
						objData[i, 4] = shouldAttendCount == 0 ? attendCount.ToString("0.00%") : (attendCount / shouldAttendCount).ToString("0.00%");
						totalAbsenceCount += absenceCount;
						totalAttendCount += attendCount;
						totalShouldAttendCount += shouldAttendCount;
					}
				
					objData[dt.Rows.Count, 0] = "[总计]";
					objData[dt.Rows.Count, 1] = totalShouldAttendCount;
					objData[dt.Rows.Count, 2] = totalAttendCount;
					objData[dt.Rows.Count, 3] = totalAbsenceCount < 0 ? 0 : totalAbsenceCount;
					objData[dt.Rows.Count, 4] = totalShouldAttendCount == 0 ? totalAttendCount.ToString("0.00%") : (totalAttendCount / totalShouldAttendCount).ToString("0.00%");

					m_objSheets = (Excel.Sheets)m_objBook.Sheets;
					m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(2));
					m_objRange = m_objSheet.get_Range("A3",m_objOpt);
					m_objRange = m_objRange.get_Resize(dt.Rows.Count+1,5);

					m_objRange.Value = objData;

					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					m_objFont = m_objRange.Font;
					m_objFont.Size = 9;

					m_objRange = m_objSheet.get_Range("A"+(dt.Rows.Count+5).ToString(),m_objOpt);
					m_objRange.Value = "园所:";
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("B"+(dt.Rows.Count+5).ToString(),m_objOpt);
					m_objRange.Value = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("A"+(dt.Rows.Count+6).ToString(),m_objOpt);
					m_objRange.Value = "统计开始日期:";
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("B"+(dt.Rows.Count+6).ToString(),m_objOpt);
					m_objRange.Value = startDate.ToString("yyyy.MM.dd");
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("A"+(dt.Rows.Count+7).ToString(),m_objOpt);
					m_objRange.Value = "统计结束日期:";
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("B"+(dt.Rows.Count+7).ToString(),m_objOpt);
					m_objRange.Value = endDate.ToString("yyyy.MM.dd");
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
				}
			}
		}


		private void ExportSingleStat(
			DateTime startDate, 
			DateTime endDate,
			Excel._Workbook m_objBook, 
			Excel.Sheets m_objSheets, 
			Excel._Worksheet m_objSheet, 
			Excel.Range m_objRange,
			Excel.Font m_objFont,
			System.Reflection.Missing m_objOpt)
		{
			object[,] objData;
			using(DataTable dt = new DutyInfoDA().GetTeacherStatSingle(startDate, endDate))
			{
				if (dt != null && dt.Rows.Count > 0 )
				{
					objData = new Object[dt.Rows.Count + 1,6];
					int days = SetAttendDays(startDate, endDate);
					for( int i=0; i<dt.Rows.Count; i++ )
					{
						double attendCount = Convert.ToInt32(dt.Rows[i][2]);
						double shouldAttendCount = days;
						double absenceCount = shouldAttendCount - attendCount;
						objData[i, 0] = dt.Rows[i][0].ToString();
						objData[i, 1] = dt.Rows[i][1].ToString();
						objData[i, 2] = shouldAttendCount;
						objData[i, 3] = attendCount;
						objData[i, 4] = absenceCount < 0 ? 0 : absenceCount ;
						objData[i, 5] = shouldAttendCount == 0 ? attendCount.ToString("0.00%") : (attendCount / shouldAttendCount).ToString("0.00%");
					}

					m_objSheets = (Excel.Sheets)m_objBook.Sheets;
					m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(3));
					m_objRange = m_objSheet.get_Range("A3",m_objOpt);
					m_objRange = m_objRange.get_Resize(dt.Rows.Count,6);

					m_objRange.Value = objData;

					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					m_objFont = m_objRange.Font;
					m_objFont.Size = 9;

					m_objRange = m_objSheet.get_Range("A"+(dt.Rows.Count+4).ToString(),m_objOpt);
					m_objRange.Value = "园所:";
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("B"+(dt.Rows.Count+4).ToString(),m_objOpt);
					m_objRange.Value = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("A"+(dt.Rows.Count+5).ToString(),m_objOpt);
					m_objRange.Value = "统计开始日期:";
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("B"+(dt.Rows.Count+5).ToString(),m_objOpt);
					m_objRange.Value = startDate.ToString("yyyy.MM.dd");
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("A"+(dt.Rows.Count+6).ToString(),m_objOpt);
					m_objRange.Value = "统计结束日期:";
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("B"+(dt.Rows.Count+6).ToString(),m_objOpt);
					m_objRange.Value = endDate.ToString("yyyy.MM.dd");
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 9;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
				}
			}
		}


		private void ExportSingle(
			DateTime startDate, 
			DateTime endDate,
			Excel._Workbook m_objBook, 
			Excel.Sheets m_objSheets, 
			Excel._Worksheet m_objSheet, 
			Excel.Range m_objRange,
			Excel.Font m_objFont,
			System.Reflection.Missing m_objOpt)
		{
			using (DataTable dt = new DutyInfoDA().GetTeaDutyNormal(string.Empty, string.Empty, string.Empty, string.Empty, startDate, endDate, 100).Tables[0])
			{
				if (dt != null && dt.Rows.Count > 0)
				{
					DataView dv = dt.DefaultView;
					using (DataTable dtBaseInfo = new TeacherBaseDataAccess().GetTcBaseInfo(string.Empty, string.Empty, string.Empty, string.Empty).Tables[0])
					{
						object[, ] objData = null;
						foreach(DataRow dr in dtBaseInfo.Rows)
						{
							dv.RowFilter = "T_Number = " + dr[1].ToString();
							objData = new object[dv.Count, 6];
							if (dv.Count > 0)
							{
								for (int i = 0; i < dv.Count; i++)
								{
									objData[i,0] = dv[i][3].ToString();
									objData[i,1] = dv[i][2].ToString();
									objData[i,2] = dv[i][0].ToString();
									objData[i,3] = dv[i][1].ToString();
									objData[i,4] = dv[i][4].ToString();
									objData[i,5] = dv[i][5].ToString();
								}
							
								m_objSheets = (Excel.Sheets)m_objBook.Sheets;
								m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(4));
								m_objSheet.Copy(Type.Missing, m_objSheet);
								m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(5));
								m_objSheet.Name = objData[0, 0].ToString() + string.Format("({0})", objData[0, 1]);
								m_objRange = m_objSheet.get_Range("A3",m_objOpt);
								m_objRange = m_objRange.get_Resize(dv.Count, 6);
								m_objRange.Value = objData;

								m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
								m_objRange.WrapText = true;
								m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
								m_objFont = m_objRange.Font;
								m_objFont.Size = 9;

								m_objRange = m_objSheet.get_Range("A"+(dv.Count+4).ToString(),m_objOpt);
								m_objRange.Value = "园所:";
								m_objRange.Font.Bold = true;
								m_objRange.Font.Size = 9;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

								m_objRange = m_objSheet.get_Range("B"+(dv.Count+4).ToString(),m_objOpt);
								m_objRange.Value = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
								m_objRange.Font.Bold = true;
								m_objRange.Font.Size = 9;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

								m_objRange = m_objSheet.get_Range("A"+(dv.Count+5).ToString(),m_objOpt);
								m_objRange.Value = "统计开始日期:";
								m_objRange.Font.Bold = true;
								m_objRange.Font.Size = 9;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

								m_objRange = m_objSheet.get_Range("B"+(dv.Count+5).ToString(),m_objOpt);
								m_objRange.Value = startDate.ToString("yyyy.MM.dd");
								m_objRange.Font.Bold = true;
								m_objRange.Font.Size = 9;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

								m_objRange = m_objSheet.get_Range("A"+(dv.Count+6).ToString(),m_objOpt);
								m_objRange.Value = "统计结束日期:";
								m_objRange.Font.Bold = true;
								m_objRange.Font.Size = 9;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

								m_objRange = m_objSheet.get_Range("B"+(dv.Count+6).ToString(),m_objOpt);
								m_objRange.Value = endDate.ToString("yyyy.MM.dd");
								m_objRange.Font.Bold = true;
								m_objRange.Font.Size = 9;
								m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
							}
						}
					}
					m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(4));
					m_objSheet.Delete();
				}
			}
		}

		#endregion

		private int SetAttendDays(DateTime startDate, DateTime endDate)
		{
			return new UtilDataAccess().GetAttendDays(startDate, endDate);

			/*
			string dateDiff = (endDate.Date - startDate.Date).ToString();
			DateTime initBegDate = startDate;
			
			if( endDate.Date == startDate.Date )
				return 1;
			else
			{
				//休息日
				int restingDays = 0;

				//当月日数
				int dayNumbers = Convert.ToInt32(dateDiff.Substring(0,dateDiff.IndexOf(".",0)))+1;

				for ( int i=0; i<dayNumbers; i++ )
				{
					//五一和十一
					if (initBegDate.AddDays(i).Month == 10)
					{
						for( int dayOfMonth = 1;dayOfMonth <= 3;dayOfMonth ++ )
						{
							if ( initBegDate.AddDays(i).Day == dayOfMonth )
								restingDays ++;
						}
					}

					//元旦
					if ((initBegDate.AddDays(i).Month == 1 || initBegDate.AddDays(i).Month == 5) && initBegDate.AddDays(i).Day == 1)
						restingDays ++;

					//双修日
					if ( initBegDate.AddDays(i).DayOfWeek.ToString().Equals("Saturday") || 
						initBegDate.AddDays(i).DayOfWeek.ToString().Equals("Sunday") )
						restingDays ++;
				}
				return dayNumbers - restingDays;
			}
			*/
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
