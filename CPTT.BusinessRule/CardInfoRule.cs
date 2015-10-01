using System;
using System.Data;
using System.IO;
using System.Collections;
using CPTT.SystemFramework;
using CPTT.DataAccess;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace CPTT.BusinessRule
{
    using Excel = Microsoft.Office.Interop.Excel;
	/// <summary>
	/// CardInfoRule 的摘要说明。
	/// </summary>
	public class CardInfoRule
	{
		private Excel.Application m_objExcel = null;
		private Excel.Workbooks m_objBooks = null;
		private Excel._Workbook m_objBook = null;
		private Excel.Sheets m_objSheets = null;
		private	Excel._Worksheet m_objSheet = null;
		private	Excel.Range m_objRange = null;
		private Excel.Font m_objFont = null;
		System.Reflection.Missing m_objOpt = System.Reflection.Missing.Value;
		public CardInfoRule()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public int InsertCardInfo(CardInfo card)
		{
			using(CardInfoDA cardInfoDA = new CardInfoDA())
			{
				return cardInfoDA.InsertCardInfo(card);
			}
		}

//		public void WriteCardInfoExcel(DataSet dsCardInfo,string savePath)
//		{
//			try
//			{
//				System.Reflection.Missing m_objOpt = System.Reflection.Missing.Value;
//
//				object[,] objData;
//
//				if ( dsCardInfo.Tables[0] != null )
//				{
//					objData = new object[dsCardInfo.Tables[0].Rows.Count+1,1];
//					objData[0,0] = "导出的卡号";
//
//					for( int i=1; i<=dsCardInfo.Tables[0].Rows.Count; i++ )
//						objData[i,0] = dsCardInfo.Tables[0].Rows[i-1]["info_stuCardNumber"];
//
//					m_objExcel = new Excel.Application();
//					m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
//					m_objBook = (Excel._Workbook)m_objBooks.Add(true);
//
//					m_objSheets = (Excel.Sheets)m_objBook.Sheets;
//					m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));
//
//					m_objRange = m_objSheet.get_Range("A1",m_objOpt);
//					m_objRange = m_objRange.get_Resize(dsCardInfo.Tables[0].Rows.Count+1,1);
//					m_objRange.Value = objData;
//
//					m_objBook.SaveAs(savePath, m_objOpt, m_objOpt,
//						m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
//						m_objOpt, m_objOpt, m_objOpt, m_objOpt);
//					m_objBook.Close(false, m_objOpt, m_objOpt);
//					m_objExcel.Quit();
//
//					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
//					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
//					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
//					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
//					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
//					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
//				}
//			}
//			catch(Exception ex)
//			{
//				Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
//			}
//			finally
//			{
//				m_objFont = null;
//				m_objRange = null;
//				m_objSheet = null;
//				m_objSheets = null;
//				m_objBook = null;
//				m_objBooks = null;
//				m_objExcel = null;
//
//				GC.Collect();
//			}
//
//		}

		public void WriteCardInfoExcel(DataSet dsCardInfo,string savePath)
		{
			try
			{
				m_objExcel = new Excel.Application(); 
				m_objExcel.DisplayAlerts = false;
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;				
				m_objBook = (Excel._Workbook)m_objBooks.Add(true);
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;

				m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
				object[,] objData = null;
				int index = 0;

				if (dsCardInfo.Tables[0].Rows.Count > 0)
				{
					objData = new object[dsCardInfo.Tables[0].Rows.Count + 1, dsCardInfo.Tables[0].Columns.Count + 2];
					objData[0,0] = "年级";
					objData[0,1] = "班级";
					objData[0,2] = "学号";
					objData[0,3] = "卡号";
					objData[0,4] = "操作";
					objData[0,5] = "统计";

					for (int row = 0; row < dsCardInfo.Tables[0].Rows.Count; row++)
					{
						objData[row + 1, 0] = dsCardInfo.Tables[0].Rows[row][0];
						objData[row + 1, 1] = dsCardInfo.Tables[0].Rows[row][1];
						objData[row + 1, 2] = dsCardInfo.Tables[0].Rows[row][2];
						objData[row + 1, 3] = dsCardInfo.Tables[0].Rows[row][3];
					}

					foreach(DataRow row in dsCardInfo.Tables[2].Rows)
					{
						objData[index + 1, 5] = row[1];
						index += Convert.ToInt32(row[1]);
					}

					m_objRange = m_objSheet.get_Range("A1",m_objOpt);
					m_objRange = m_objRange.get_Resize(dsCardInfo.Tables[0].Rows.Count + 4,6);
					m_objRange.Value = objData;
					m_objRange.Font.Size = 8;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;	

					RowMerge("A", dsCardInfo.Tables[1]);
					RowMerge("B", dsCardInfo.Tables[2]);
					RowMerge("C", dsCardInfo.Tables[3]);
					RowMerge("F", dsCardInfo.Tables[2]);

					m_objRange = m_objSheet.get_Range("A" + (dsCardInfo.Tables[0].Rows.Count + 2).ToString(),
						"A" + (dsCardInfo.Tables[0].Rows.Count + 2).ToString());
					m_objRange.Value = "空卡";
					m_objRange = m_objSheet.get_Range("B" + (dsCardInfo.Tables[0].Rows.Count + 2).ToString(),
						"B" + (dsCardInfo.Tables[0].Rows.Count + 2).ToString());
					m_objRange.Value = GetCardEncryptedNumber() - Convert.ToInt32(dsCardInfo.Tables[4].Rows[0][0]) 
						- Convert.ToInt32(dsCardInfo.Tables[5].Rows[0][0]);
					m_objRange = m_objSheet.get_Range("A" + (dsCardInfo.Tables[0].Rows.Count + 3).ToString(),
						"A" + (dsCardInfo.Tables[0].Rows.Count + 3).ToString());
					m_objRange.Value = "学生卡";
					m_objRange = m_objSheet.get_Range("B" + (dsCardInfo.Tables[0].Rows.Count + 3).ToString(),
						"B" + (dsCardInfo.Tables[0].Rows.Count + 3).ToString());
					m_objRange.Value = dsCardInfo.Tables[4].Rows[0][0];
					m_objRange = m_objSheet.get_Range("A" + (dsCardInfo.Tables[0].Rows.Count + 4).ToString(),
						"A" + (dsCardInfo.Tables[0].Rows.Count + 4).ToString());
					m_objRange.Value = "教师卡";
					m_objRange = m_objSheet.get_Range("B" + (dsCardInfo.Tables[0].Rows.Count + 4).ToString(),
						"B" + (dsCardInfo.Tables[0].Rows.Count + 4).ToString());
					m_objRange.Value = dsCardInfo.Tables[5].Rows[0][0];

					m_objRange.get_Range("B" + (dsCardInfo.Tables[0].Rows.Count + 2).ToString(),
						"F" + (dsCardInfo.Tables[0].Rows.Count + 2).ToString()).Merge(m_objOpt);

					m_objBook.SaveAs(savePath, m_objOpt, m_objOpt,
						m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
						m_objOpt, m_objOpt, m_objOpt, m_objOpt);
					m_objBook.Close(false, m_objOpt, m_objOpt);
					m_objExcel.Quit();
	
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (m_objRange != null)
				{
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
					m_objRange = null;
				}
				if (m_objSheet != null)
				{
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
					m_objSheet = null;
				}
				if (m_objSheets != null)
				{
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
					m_objSheets = null;
				}
				if (m_objBook != null)
				{
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
					m_objBook = null;
				}
				if (m_objBooks != null)
				{
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
					m_objBooks = null;
				}
				if(m_objExcel != null)
				{
					System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
					m_objExcel = null;
				}

				GC.Collect();

				KillProcess();
			}
		}

		private int GetCardEncryptedNumber()
		{
			FileStream fi = null;
			StreamReader sr = null;
			ArrayList cardEncrypted = new ArrayList();

			try
			{
				string directory = AppDomain.CurrentDomain.BaseDirectory;
				string filePath = directory + @"\encry.bin";
				if (File.Exists(filePath))
				{
					fi = new FileStream(filePath, FileMode.Open, FileAccess.Read);
					sr = new StreamReader(fi);
					while (true)
					{
						string card = sr.ReadLine();
						
						if (card != null)
						{
							cardEncrypted.Add(card);
						}
						else
						{
							break;
						}
					}
				}

				return cardEncrypted.Count;
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
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

		private void RowMerge(string column, DataTable dt)
		{
			int index = 0;

			foreach (DataRow row in dt.Rows)
			{
				m_objRange.get_Range(column + (index + 2).ToString(),column + (index + Convert.ToInt32(row[1]) + 1).ToString()).Merge(m_objOpt);
				index += Convert.ToInt32(row[1]);
			}
		}

		public void ImportCardExcelFile(string id,string name,string grade,
			string atClass,bool isStu,string savePath)
		{
			if(grade.Equals("全部"))
			{
				grade = string.Empty;
			}

			if(atClass.Equals("全部"))
			{
				atClass = string.Empty;
			}

			DataSet cardInfo;
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
				if(isStu)
				{
					using(CardInfoDA cardInfoDA = new CardInfoDA())
					{
						cardInfo = cardInfoDA.GetStuCardNumberForExcel(id,name,grade,atClass);
					}

					if(cardInfo.Tables[0].Rows.Count>0)
					{
						objData = new Object[cardInfo.Tables[0].Rows.Count,7];

						for(int i=0;i<cardInfo.Tables[0].Rows.Count;i++)
						{
							objData[i,0] = cardInfo.Tables[0].Rows[i][0].ToString();
							objData[i,1] = cardInfo.Tables[0].Rows[i][1].ToString();
							objData[i,2] = cardInfo.Tables[0].Rows[i][2].ToString();
							objData[i,3] = cardInfo.Tables[0].Rows[i][3].ToString();
							objData[i,4] = cardInfo.Tables[0].Rows[i][4].ToString();
							objData[i,5] = cardInfo.Tables[0].Rows[i][5].ToString();
							objData[i,6] = cardInfo.Tables[0].Rows[i][6].ToString();			
						}

						m_objExcel = new Excel.Application();
						m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
						m_objBook = (Excel._Workbook)m_objBooks.Open(excelTempFilePath+@"report\StudentCardInfo.xls",
							m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
							m_objOpt,m_objOpt,m_objOpt);

						m_objSheets = (Excel.Sheets)m_objBook.Sheets;
						m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));
						m_objRange = m_objSheet.get_Range("A3",m_objOpt);
						m_objRange = m_objRange.get_Resize(cardInfo.Tables[0].Rows.Count,7);

						m_objRange.Value = objData;

						m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
						m_objRange.WrapText = true;
						m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
						m_objFont = m_objRange.Font;
						m_objFont.Size = 9;

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
				else
				{
					using(CardInfoDA cardInfoDA = new CardInfoDA())
					{
						cardInfo = cardInfoDA.GetTeaCardNumberForExcel(id,name,grade,atClass);
					}

					if(cardInfo.Tables[0].Rows.Count>0)
					{
						objData = new Object[cardInfo.Tables[0].Rows.Count,6];

						for(int i=0;i<cardInfo.Tables[0].Rows.Count;i++)
						{
							objData[i,0] = cardInfo.Tables[0].Rows[i][0].ToString();
							objData[i,1] = cardInfo.Tables[0].Rows[i][1].ToString();
							objData[i,2] = cardInfo.Tables[0].Rows[i][2].ToString();
							objData[i,3] = cardInfo.Tables[0].Rows[i][3].ToString();
							objData[i,4] = cardInfo.Tables[0].Rows[i][4].ToString();
							objData[i,5] = cardInfo.Tables[0].Rows[i][5].ToString();			
						}

						m_objExcel = new Excel.Application();
						m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
						m_objBook = (Excel._Workbook)m_objBooks.Open(excelTempFilePath+@"report\TeacherCardInfo.xls",
							m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
							m_objOpt,m_objOpt,m_objOpt);

						m_objSheets = (Excel.Sheets)m_objBook.Sheets;
						m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));
						m_objRange = m_objSheet.get_Range("A3",m_objOpt);
						m_objRange = m_objRange.get_Resize(cardInfo.Tables[0].Rows.Count,6);

						m_objRange.Value = objData;

						m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
						m_objRange.WrapText = true;
						m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
						m_objFont = m_objRange.Font;
						m_objFont.Size = 9;

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
			}
		}

		protected virtual void KillProcess()
		{
			string processName = "Excel";
			System.Diagnostics.Process myproc = new System.Diagnostics.Process();
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
				throw ex;
			}
		}
	}
}
