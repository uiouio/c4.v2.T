using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using DevExpress.XtraEditors;
using ZedGraph;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessRule
{
    using Excel = Microsoft.Office.Interop.Excel;
	/// <summary>
	/// StuMorningCheckInfoPrintRules 的摘要说明。
	/// </summary>
	public class StuMorningCheckInfoPrintRules
	{
		private DateTime getBegDate;
		private DateTime getEndDate;
		private Excel.Application m_objExcel = null;
		private Excel.Workbooks m_objBooks = null;
		private Excel._Workbook m_objBook = null;
		private Excel.Sheets m_objSheets = null;
		private Excel._Worksheet m_objSheet = null;
		private Excel.Range m_objRange = null;
		private Excel.Range m_objRangeDate = null;
		private object m_objOpt = System.Reflection.Missing.Value;
		private string excelPath = AppDomain.CurrentDomain.BaseDirectory;
		private ZedGraphControl zedGraph_StuBarPrint;
		private ZedGraphControl zedGraph_StuPiePrint;

		public StuMorningCheckInfoPrintRules()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DateTime BegDate
		{
			get { return this.getBegDate; }
			set { this.getBegDate = value; }
		}

		public DateTime EndDate
		{
			get { return this.getEndDate; }
			set { this.getEndDate = value; }
		}

		public void PrintMorningCheckInfo(DataSet dsMorningCheckInfo,string getBegDate,string getEndDate,string savePath)
		{
			try
			{	
				object[,] morningCheckInfoData = null;

				if ( dsMorningCheckInfo.Tables[0].Rows.Count > 0 )
				{
					morningCheckInfoData = new object[dsMorningCheckInfo.Tables[0].Rows.Count,5];
					for ( int i=0; i<dsMorningCheckInfo.Tables[0].Rows.Count; i++ )
					{
						morningCheckInfoData[i,0] = dsMorningCheckInfo.Tables[0].Rows[i][2];
						morningCheckInfoData[i,1] = dsMorningCheckInfo.Tables[0].Rows[i][0];
						morningCheckInfoData[i,2] = dsMorningCheckInfo.Tables[0].Rows[i][1];
						morningCheckInfoData[i,3] = dsMorningCheckInfo.Tables[0].Rows[i][3];
						morningCheckInfoData[i,4] = dsMorningCheckInfo.Tables[0].Rows[i][4];
					}

					m_objExcel = new Excel.Application();
					m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
					m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\MorningCheckInfo.xls",
						m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
						m_objOpt,m_objOpt,m_objOpt);

					m_objSheets = (Excel.Sheets)m_objBook.Sheets;
					m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));
					m_objRange = m_objSheet.get_Range("B3",m_objOpt);
					m_objRange = m_objRange.get_Resize(dsMorningCheckInfo.Tables[0].Rows.Count,5);

					m_objRange.Value = morningCheckInfoData;

					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.Font.Size = 9;

					m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsMorningCheckInfo.Tables[0].Rows.Count+4,2],m_objSheet.Cells[dsMorningCheckInfo.Tables[0].Rows.Count+4,2]);
					m_objRange.Value = "园所信息:";
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 12;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
					m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsMorningCheckInfo.Tables[0].Rows.Count+4,3],m_objSheet.Cells[dsMorningCheckInfo.Tables[0].Rows.Count+4,3]);
					m_objRange.Value = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
					m_objRange.Font.Size = 12;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
					m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsMorningCheckInfo.Tables[0].Rows.Count+5,2],m_objSheet.Cells[dsMorningCheckInfo.Tables[0].Rows.Count+5,2]);
					m_objRange.Value = "统计日期:";
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 12;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
					m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsMorningCheckInfo.Tables[0].Rows.Count+5,3],m_objSheet.Cells[dsMorningCheckInfo.Tables[0].Rows.Count+5,3]);
					m_objRange.Value = Convert.ToDateTime(getBegDate).ToString("yyyy.MM.dd")+" -- "+Convert.ToDateTime(getEndDate).ToString("yyyy.MM.dd");
					m_objRange.Font.Size = 12;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
					m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

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
			}
		}

		public void PrintBackCheckInfo(DataSet dsBackCheckInfo,string getBegDate,string getEndDate,string savePath)
		{
			try
			{
				object[,] backCheckInfoData;

				if ( dsBackCheckInfo.Tables[0].Rows.Count > 0 )
				{
					backCheckInfoData = new object[dsBackCheckInfo.Tables[0].Rows.Count,6];

					for ( int i=0; i<dsBackCheckInfo.Tables[0].Rows.Count; i++ )
					{
						backCheckInfoData[i,0] = dsBackCheckInfo.Tables[0].Rows[i][2];
						backCheckInfoData[i,1] = dsBackCheckInfo.Tables[0].Rows[i][0];
						backCheckInfoData[i,2] = dsBackCheckInfo.Tables[0].Rows[i][1];
						backCheckInfoData[i,3] = dsBackCheckInfo.Tables[0].Rows[i][3];
						backCheckInfoData[i,4] = dsBackCheckInfo.Tables[0].Rows[i][4];
						backCheckInfoData[i,5] = dsBackCheckInfo.Tables[0].Rows[i][5];
					}

					m_objExcel = new Excel.Application();
					m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
					m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\BackCheckInfo.xls",
						m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
						m_objOpt,m_objOpt,m_objOpt);

					m_objSheets = (Excel.Sheets)m_objBook.Sheets;
					m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));
					m_objRange = m_objSheet.get_Range("B3",m_objOpt);
					m_objRange = m_objRange.get_Resize(dsBackCheckInfo.Tables[0].Rows.Count,6);

					m_objRange.Value = backCheckInfoData;

					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					m_objRange.Font.Size = 9;

					m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsBackCheckInfo.Tables[0].Rows.Count+4,2],m_objSheet.Cells[dsBackCheckInfo.Tables[0].Rows.Count+4,2]);
					m_objRange.Value = "园所信息:";
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 12;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
					m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsBackCheckInfo.Tables[0].Rows.Count+4,3],m_objSheet.Cells[dsBackCheckInfo.Tables[0].Rows.Count+4,3]);
					m_objRange.Value = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
					m_objRange.Font.Size = 12;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
					m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsBackCheckInfo.Tables[0].Rows.Count+5,2],m_objSheet.Cells[dsBackCheckInfo.Tables[0].Rows.Count+5,2]);
					m_objRange.Value = "统计日期:";
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 12;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
					m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsBackCheckInfo.Tables[0].Rows.Count+5,3],m_objSheet.Cells[dsBackCheckInfo.Tables[0].Rows.Count+5,3]);
					m_objRange.Value = Convert.ToDateTime(getBegDate).ToString("yyyy.MM.dd")+" -- "+Convert.ToDateTime(getEndDate).ToString("yyyy.MM.dd");
					m_objRange.Font.Size = 12;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
					m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

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
			}
		}

		//建立晨检统计表
		public DataSet BuildMorningInfoStat(DateTime getBegDate,DateTime getEndDate,string getGrade,string getClass)
		{
			using ( MorningCheckPrintDataAccess morningCheckPrintDataAccess = new MorningCheckPrintDataAccess() )
			{
				try
				{
					DataSet buildMorningInfoStat = new RealtimeInfoDataAccess().setClassList("",getClass,getGrade);
					buildMorningInfoStat.Tables[0].Columns.AddRange(new DataColumn[]{new DataColumn("info_health"),new DataColumn("info_watch"),
																						new DataColumn("info_ill"),new DataColumn("info_shouldAtt"),
																						new DataColumn("info_haveAtt"),new DataColumn("info_absence"),
																						new DataColumn("info_attPer")});
					DataSet dsHealth = morningCheckPrintDataAccess.SetMorningCheckInfoStat(getBegDate,getEndDate,getGrade,getClass,0,0);
					DataSet dsWatch = morningCheckPrintDataAccess.SetMorningCheckInfoStat(getBegDate,getEndDate,getGrade,getClass,2,0);	
					DataSet dsIll = morningCheckPrintDataAccess.SetMorningCheckInfoStat(getBegDate,getEndDate,getGrade,getClass,3,0);
					DataSet dsAbsence = morningCheckPrintDataAccess.SetMorningCheckInfoStat(getBegDate,getEndDate,getGrade,getClass,-1,0);
					DataSet dsSum = morningCheckPrintDataAccess.SetMorningCheckInfoStat(getBegDate,getEndDate,getGrade,getClass,100,1);
					DataSet dsStuAmount = null;

					int healthNumbersAll = 0;
					int watchNumbersAll = 0;
					int illNumbersAll = 0;
					int absenceNumbersAll = 0;
					int sumNumbersAll = 0;
					int stuAmountAll = 0;

					for ( int row = 0; row < buildMorningInfoStat.Tables[0].Rows.Count; row ++ )
					{
					
						dsStuAmount = new RealtimeInfoDataAccess().setStuAmount(buildMorningInfoStat.Tables[0].Rows[row][2].ToString(),getEndDate);
						
						//健康人数统计
						if ( dsHealth.Tables[0].Rows.Count > 0 )
						{
							for ( int healthRow = 0; healthRow < dsHealth.Tables[0].Rows.Count; healthRow ++ )
							{
								if ( buildMorningInfoStat.Tables[0].Rows[row][2].ToString().Equals(dsHealth.Tables[0].Rows[healthRow][0].ToString()) )
								{
									buildMorningInfoStat.Tables[0].Rows[row][3] = dsHealth.Tables[0].Rows[healthRow][1].ToString()
										+ " (" +(Convert.ToDouble(dsHealth.Tables[0].Rows[healthRow][1])
										/(Convert.ToDouble(dsStuAmount.Tables[0].Rows[0][0])*SetAttendDays())).ToString("0.00%") + ")";

									healthNumbersAll += Convert.ToInt32(dsHealth.Tables[0].Rows[healthRow][1]);
									break;
								}
								else
								{
									if ( healthRow == dsHealth.Tables[0].Rows.Count - 1 )
										buildMorningInfoStat.Tables[0].Rows[row][3] = 0;
								}
							}
						}
						else
							buildMorningInfoStat.Tables[0].Rows[row][3] = 0;
					
						//观察人数统计
						if ( dsWatch.Tables[0].Rows.Count > 0 )
						{
							for ( int watchRow = 0; watchRow < dsWatch.Tables[0].Rows.Count; watchRow ++ )
							{
								if ( buildMorningInfoStat.Tables[0].Rows[row][2].ToString().Equals(dsWatch.Tables[0].Rows[watchRow][0].ToString()) )
								{
									buildMorningInfoStat.Tables[0].Rows[row][4] = dsWatch.Tables[0].Rows[watchRow][1].ToString()
										+ " (" +(Convert.ToDouble(dsWatch.Tables[0].Rows[watchRow][1])
										/(Convert.ToDouble(dsStuAmount.Tables[0].Rows[0][0])*SetAttendDays())).ToString("0.00%") + ")";

									watchNumbersAll += Convert.ToInt32(dsWatch.Tables[0].Rows[watchRow][1]);
									break;
								}
								else
								{
									if ( watchRow == dsWatch.Tables[0].Rows.Count - 1 )
										buildMorningInfoStat.Tables[0].Rows[row][4] = 0;
								}
							}
						}
						else
							buildMorningInfoStat.Tables[0].Rows[row][4] = 0;

						//服药人数统计
						if ( dsIll.Tables[0].Rows.Count > 0 )
						{
							for ( int illRow = 0; illRow < dsIll.Tables[0].Rows.Count; illRow ++ )
							{
								if ( buildMorningInfoStat.Tables[0].Rows[row][2].ToString().Equals(dsIll.Tables[0].Rows[illRow][0].ToString()) )
								{
									buildMorningInfoStat.Tables[0].Rows[row][5] = dsIll.Tables[0].Rows[illRow][1].ToString()
										+ " (" +(Convert.ToDouble(dsIll.Tables[0].Rows[illRow][1])
										/(Convert.ToDouble(dsStuAmount.Tables[0].Rows[0][0])*SetAttendDays())).ToString("0.00%") + ")";

									illNumbersAll += Convert.ToInt32(dsIll.Tables[0].Rows[illRow][1]);
									break;
								}
								else
								{
									if ( illRow == dsIll.Tables[0].Rows.Count - 1 )
										buildMorningInfoStat.Tables[0].Rows[row][5] = 0;
								}
							}
						}
						else
							buildMorningInfoStat.Tables[0].Rows[row][5] = 0;

						//应出勤人数
						if ( dsStuAmount.Tables[0].Rows.Count == 0 )
							buildMorningInfoStat.Tables[0].Rows[row][6] = 0;
						else
						{
							buildMorningInfoStat.Tables[0].Rows[row][6] = (Convert.ToInt32(dsStuAmount.Tables[0].Rows[0][0])*SetAttendDays()).ToString();
							stuAmountAll += Convert.ToInt32(dsStuAmount.Tables[0].Rows[0][0]) * SetAttendDays();
						}

						//缺席人数
						if ( dsAbsence.Tables[0].Rows.Count > 0 )
						{
							for ( int absenceRow = 0; absenceRow < dsAbsence.Tables[0].Rows.Count; absenceRow ++ )
							{
								if ( buildMorningInfoStat.Tables[0].Rows[row][2].ToString().Equals(dsAbsence.Tables[0].Rows[absenceRow][0].ToString()) )
								{
									int total = Convert.ToInt32(dsStuAmount.Tables[0].Rows[0][0]) * SetAttendDays();
									int health = 0;
									int ill = 0;
									int watch = 0;
									
									foreach(DataRow dr in dsHealth.Tables[0].Rows)
									{
										if (buildMorningInfoStat.Tables[0].Rows[row][2].ToString().Equals(dr[0].ToString()))
										{
											health = Convert.ToInt32(dr[1]);
										}
									}

									foreach(DataRow dr in dsIll.Tables[0].Rows)
									{
										if (buildMorningInfoStat.Tables[0].Rows[row][2].ToString().Equals(dr[0].ToString()))
										{
											ill = Convert.ToInt32(dr[1]);
										}
									}

									foreach(DataRow dr in dsWatch.Tables[0].Rows)
									{
										if (buildMorningInfoStat.Tables[0].Rows[row][2].ToString().Equals(dr[0].ToString()))
										{
											watch = Convert.ToInt32(dr[1]);
										}
									}

									int absence = total - health - watch - ill;

									absenceNumbersAll += absence;

//									double absence =  total -
//										(dsHealth.Tables[0].Rows.Count > 0 ? (dsHealth.Tables[0].Rows[absenceRow][1]) : 0) -
//										(dsIll.Tables[0].Rows.Count > 0 ? Convert.ToInt32(dsIll.Tables[0].Rows[absenceRow][1]) : 0) -
//										(dsWatch.Tables[0].Rows.Count > 0 ? Convert.ToInt32(dsWatch.Tables[absenceRow].Rows[0][1]) : 0);

									buildMorningInfoStat.Tables[0].Rows[row][8] = 
										string.Format("{0} ({1})", absence, ((double)absence / (double)total).ToString("0.00%"));

									//dsAbsence.Tables[0].Rows[absenceRow][1] = 
										


//									buildMorningInfoStat.Tables[0].Rows[row][8] = dsAbsence.Tables[0].Rows[absenceRow][1].ToString()
//										+ " (" +(Convert.ToDouble(dsAbsence.Tables[0].Rows[absenceRow][1])
//										/(Convert.ToDouble(dsStuAmount.Tables[0].Rows[0][0])*SetAttendDays())).ToString("0.00%") + ")";
									break;
								}
								else
								{
									if ( absenceRow == dsAbsence.Tables[0].Rows.Count - 1)
										buildMorningInfoStat.Tables[0].Rows[row][8] = 0;
								}
							}
						}
						else
							buildMorningInfoStat.Tables[0].Rows[row][8] = 0;

						//出勤率
						if ( dsSum.Tables[0].Rows.Count > 0 )
						{
							for ( int attRow = 0; attRow < dsSum.Tables[0].Rows.Count; attRow ++ )
							{
								if ( buildMorningInfoStat.Tables[0].Rows[row][2].ToString().Equals(dsSum.Tables[0].Rows[attRow][0].ToString()) )
								{
									buildMorningInfoStat.Tables[0].Rows[row][9] = 
										(Convert.ToDouble(dsSum.Tables[0].Rows[attRow][1])/(Convert.ToDouble(dsStuAmount.Tables[0].Rows[0][0])*SetAttendDays())).ToString("0.00%");

									buildMorningInfoStat.Tables[0].Rows[row][7] = Convert.ToInt32(dsSum.Tables[0].Rows[attRow][1]);

									sumNumbersAll += Convert.ToInt32(dsSum.Tables[0].Rows[attRow][1]);
									break; 
								}
								else
								{
									if ( attRow == dsSum.Tables[0].Rows.Count - 1 )
									{
										buildMorningInfoStat.Tables[0].Rows[row][9] = 0;
										buildMorningInfoStat.Tables[0].Rows[row][7] = 0;
									}
								}
							}
						}
						else
						{
							buildMorningInfoStat.Tables[0].Rows[row][9] = 0;
							buildMorningInfoStat.Tables[0].Rows[row][7] = 0;
						}

						//a
						if ( row == buildMorningInfoStat.Tables[0].Rows.Count - 1 )
						{
							DataRow newRow = buildMorningInfoStat.Tables[0].NewRow();
							
							newRow[1] = "[总计]";

							if ( stuAmountAll == 0 )
							{
								newRow[3] = 0;
								newRow[4] = 0;
								newRow[5] = 0;
								newRow[6] = 0;
								newRow[7] = 0;
								newRow[8] = 0;
								newRow[9] = 0;
							}
							else
							{
								newRow[3] = healthNumbersAll.ToString()
									+ " (" +((double)healthNumbersAll/(double)stuAmountAll).ToString("0.00%") + ")";
								newRow[4] = watchNumbersAll.ToString()
									+ " (" +((double)watchNumbersAll/(double)stuAmountAll).ToString("0.00%") + ")";
								newRow[5] = illNumbersAll.ToString()
									+ " (" +((double)illNumbersAll/(double)stuAmountAll).ToString("0.00%") + ")";
								newRow[6] = stuAmountAll;
								newRow[7] = sumNumbersAll;
								newRow[8] = absenceNumbersAll.ToString()
									+ " (" +((double)absenceNumbersAll/(double)stuAmountAll).ToString("0.00%") + ")";
								newRow[9] = ((double)sumNumbersAll/(double)stuAmountAll).ToString("0.00%");
							}

							buildMorningInfoStat.Tables[0].Rows.Add(newRow);
							break;
						}

					}
					return buildMorningInfoStat;
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public void Excel_InfoStat(string getGrade,string getClass,string savePath)
		{
			DataSet dsBuildStatInfo = BuildMorningInfoStat(BegDate,EndDate,getGrade,getClass);
			try
			{
				m_objExcel = new Excel.Application();
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\MorningStatInfo.xls",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt);

				m_objSheets = (Excel.Sheets)m_objBook.Sheets;
				m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));

				for ( int row = 0; row < dsBuildStatInfo.Tables[0].Rows.Count; row ++ )
				{
					m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+7,1],m_objSheet.Cells[row+7,1]);
					m_objRange.Value = dsBuildStatInfo.Tables[0].Rows[row][1].ToString();
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.Font.Size = 10;
					for (  int column = 3;column < dsBuildStatInfo.Tables[0].Columns.Count; column ++)
					{
						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+7,column-1],m_objSheet.Cells[row+7,column-1]);
						m_objRange.set_Item(1,1,dsBuildStatInfo.Tables[0].Rows[row][column].ToString());
						m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
						m_objRange.Font.Size = 10;
					}

					if ( row == dsBuildStatInfo.Tables[0].Rows.Count - 1 )
					{
						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+9,1],m_objSheet.Cells[row+9,1]);
						m_objRange.Value = "园所信息：";
						m_objRange.Font.Bold = true;
						m_objRange.Font.Size = 12;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+9,2],m_objSheet.Cells[row+9,2]);
						m_objRange.Value = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
						m_objRange.Font.Size = 12;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+10,1],m_objSheet.Cells[row+10,1]);
						m_objRange.Value = "起始日期：";
						m_objRange.Font.Bold = true;
						m_objRange.Font.Size = 12;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+10,2],m_objSheet.Cells[row+10,2]);
						m_objRange.Value = BegDate.ToString("yyyy-MM-dd");
						m_objRange.Font.Size = 12;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+11,1],m_objSheet.Cells[row+11,1]);
						m_objRange.Value = "截止日期：";
						m_objRange.Font.Bold = true;
						m_objRange.Font.Size = 12;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+11,2],m_objSheet.Cells[row+11,2]);
						m_objRange.Value = EndDate.ToString("yyyy-MM-dd");
						m_objRange.Font.Size = 12;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+12,1],m_objSheet.Cells[row+12,1]);
						m_objRange.Value = "制表日期：";
						m_objRange.Font.Bold = true;
						m_objRange.Font.Size = 12;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+12,2],m_objSheet.Cells[row+12,2]);
						m_objRange.Value = DateTime.Now.ToString("yyyy-MM-dd");
						m_objRange.Font.Size = 12;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;


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
			}
		}

		public Bitmap Bar_InfoStat(string getGrade,string getClass,GroupControl gControl)
		{
			DataSet dsBuildStatInfo = BuildMorningInfoStat(BegDate,EndDate,getGrade,getClass);
			DataSet dsClassInfo = new RealtimeInfoDataAccess().setClassList("",getClass,getGrade);
			int statMember = dsClassInfo.Tables[0].Rows.Count;
			if ( getClass.Equals("") )
			{
				try
				{
					zedGraph_StuBarPrint = new ZedGraphControl();
					gControl.Controls.Clear();
					gControl.Controls.Add(zedGraph_StuBarPrint);
					zedGraph_StuBarPrint.Dock = DockStyle.Fill;

					GraphPane myPane = zedGraph_StuBarPrint.GraphPane;

					// Create a new graph with the dimension of the groupcontrol
//					GraphPane myPane = new GraphPane( new Rectangle( 0, 0, gControl.Width, gControl.Height ),
//						new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
//						+ "晨检信息统计图", "统计日期: "
//						+ BegDate.ToString("yyyy.MM.dd") + " 至 " + EndDate.ToString("yyyy.MM.dd"), "晨检统计率" );
					myPane.Title = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
						+ "晨检信息统计图";

					myPane.XAxis.Title = "统计日期: "
						+ BegDate.ToString("yyyy.MM.dd") + " 至 " + EndDate.ToString("yyyy.MM.dd");

					myPane.YAxis.Title = "晨检统计率";

					myPane.FontSpec.IsBold = true;
					myPane.FontSpec.Size = 16;

					//build label shown below
					string[] classLabels = new string[statMember];
					for ( int classMember=0 ; classMember<statMember; classMember++ )
					{
						classLabels[classMember] = dsClassInfo.Tables[0].Rows[classMember][1].ToString();
					}

					//build health bar
					double[] healthBar = new double[statMember];
					for ( int healthMember=0 ; healthMember<statMember; healthMember++ )
					{
						if ( dsBuildStatInfo.Tables[0].Rows[healthMember][3].ToString().Equals("0") )
							healthBar[healthMember] = 0;
						else
						{
							string tempHealth = dsBuildStatInfo.Tables[0].Rows[healthMember][3].ToString();
							healthBar[healthMember] = Convert.ToDouble(tempHealth.Substring(tempHealth.IndexOf("(")+1,
								tempHealth.IndexOf("%")-tempHealth.IndexOf("(")-1));	
						}
					}

					//build ill Bar
					double[] illBar = new double[statMember];
					for ( int illMember=0; illMember<statMember; illMember++ )
					{
						if ( dsBuildStatInfo.Tables[0].Rows[illMember][5].ToString().Equals("0") )
							illBar[illMember] = 0;
						else
						{
							string tempIll = dsBuildStatInfo.Tables[0].Rows[illMember][5].ToString();
							illBar[illMember] = Convert.ToDouble(tempIll.Substring(tempIll.IndexOf("(")+1,
								tempIll.IndexOf("%")-tempIll.IndexOf("(")-1));
						}
					}

					//build wathc bar
					double[] watchBar = new double[statMember];
					for ( int watchMember=0; watchMember<statMember; watchMember++ )
					{
						if ( dsBuildStatInfo.Tables[0].Rows[watchMember][4].ToString().Equals("0") )
							watchBar[watchMember] = 0;
						else
						{
							string tempWatch = dsBuildStatInfo.Tables[0].Rows[watchMember][4].ToString();
							watchBar[watchMember] = Convert.ToDouble(tempWatch.Substring(tempWatch.IndexOf("(")+1,
								tempWatch.IndexOf("%")-tempWatch.IndexOf("(")-1));
						}
					}

					//build absence bar
					double[] absBar = new double[statMember];
					for ( int absMember=0; absMember<statMember; absMember++ )
					{
						if ( dsBuildStatInfo.Tables[0].Rows[absMember][8].ToString().Equals("0") )
							absBar[absMember] = 0;
						else
						{
							string tempAbs = dsBuildStatInfo.Tables[0].Rows[absMember][8].ToString();
							absBar[absMember] = Convert.ToDouble(tempAbs.Substring(tempAbs.IndexOf("(")+1,
								tempAbs.IndexOf("%")-tempAbs.IndexOf("(")-1));
						}
					}

					//build attend bar
					double[] attBar = new double[statMember];
					for ( int attMember=0 ;attMember<statMember; attMember++ )
					{
						if ( dsBuildStatInfo.Tables[0].Rows[attMember][9].ToString().Equals("0") )
							attBar[attMember] = 0;
						else
						{
							string tempAtt = dsBuildStatInfo.Tables[0].Rows[attMember][9].ToString();
							attBar[attMember] = Convert.ToDouble(tempAtt.Substring(tempAtt.IndexOf("(")+1,
								tempAtt.IndexOf("%")-tempAtt.IndexOf("(")-1));
						}
					}	

					if ( getGrade.Equals("") )
						myPane.BarType = BarType.PercentStack;

					// Generate a red bar with "健康" in the legend
					BarItem myBar = myPane.AddBar( "健康", null, healthBar, Color.Red);
					myBar.Bar.Fill = new Fill( Color.Red, Color.White,Color.Red );
			
					// Generate a blue bar with "服药" in the legend
					myBar = myPane.AddBar( "服药", null, illBar, Color.Blue );
					myBar.Bar.Fill = new Fill( Color.Blue, Color.White, Color.Blue );

					// Generate a green bar with "观察" in the legend
					myBar = myPane.AddBar( "观察", null, watchBar, Color.Green );
					myBar.Bar.Fill = new Fill( Color.Green, Color.White, Color.Green );

					// Generate a purple bar with "缺席" in the lengend
					myBar = myPane.AddBar("缺席",null,absBar,Color.Purple);
					myBar.Bar.Fill = new Fill(Color.Purple,Color.White,Color.Purple);

					//Generate a black line with "Curve 4" in the legend
					LineItem myCurve = myPane.AddCurve( "出勤率",
						null, attBar, Color.Black, SymbolType.Circle );
					myCurve.Line.Fill = new Fill( Color.White, Color.LightSkyBlue, -45F );

					//Fix up the curve attributes a little
					myCurve.Symbol.Size = 8.0F;
					myCurve.Symbol.Fill = new Fill( Color.White );
					myCurve.Line.Width = 2.0F;

					// Draw the X tics between the labels instead of at the labels
					myPane.XAxis.IsTicsBetweenLabels = true;

					// Set the XAxis labels
					myPane.XAxis.TextLabels = classLabels;

					myPane.XAxis.ScaleFontSpec.Size = 10;
					// Set the XAxis to Text type
					myPane.XAxis.Type = AxisType.Text;

					// Fill the Axis and Pane backgrounds
					myPane.AxisFill = new Fill( Color.Pink,
						Color.FromArgb( 255, 255, 166), 90F );
					myPane.PaneFill = new Fill( Color.Lavender );
    
					// Tell ZedGraph to refigure the
					// axes since the data have changed
//					myPane.AxisChange( gra );
//					myPane.Draw(gra);

//					myPane.ReSize(gra,new RectangleF(150, 300, 800,600));

					zedGraph_StuBarPrint.IsShowContextMenu = false;
					zedGraph_StuBarPrint.IsEnableZoom = false;
					zedGraph_StuBarPrint.AxisChange();

					return myPane.Image;
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}

			}
			else
			{
				try
				{
					string health = dsBuildStatInfo.Tables[0].Rows[0][3].ToString();
					string ill = dsBuildStatInfo.Tables[0].Rows[0][5].ToString();
					string watch = dsBuildStatInfo.Tables[0].Rows[0][4].ToString();
					string absence = dsBuildStatInfo.Tables[0].Rows[0][8].ToString();
					string attend = dsBuildStatInfo.Tables[0].Rows[0][9].ToString();

//					Graphics gra = gControl.CreateGraphics();
					// Create a new graph with the dimension of the groupcontrol
//					GraphPane myPane = new GraphPane( new Rectangle( 0, 0, gControl.Width, gControl.Height ),
//						new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
//						+ "晨检信息统计图", "统计日期: "
//						+ BegDate.ToString("yyyy.MM.dd") + " 至 " + EndDate.ToString("yyyy.MM.dd"), "晨检统计率" );
					zedGraph_StuBarPrint = new ZedGraphControl();
					gControl.Controls.Clear();
					gControl.Controls.Add(zedGraph_StuBarPrint);
					zedGraph_StuBarPrint.Dock = DockStyle.Fill;

					GraphPane myPane = zedGraph_StuBarPrint.GraphPane;

					myPane.Title = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
						+ "晨检信息统计图";

					myPane.XAxis.Title = "统计日期: "
						+ BegDate.ToString("yyyy.MM.dd") + " 至 " + EndDate.ToString("yyyy.MM.dd");

					myPane.YAxis.Title = "晨检统计率";

					myPane.FontSpec.IsBold = true;
					myPane.FontSpec.Size = 16;

					string[] statusLabels = { "健康","服药","观察","缺席","出勤率"};

					double[] statusBar = new double[5];

					if ( health.Equals("0") )
						statusBar[0] = 0;
					else
						statusBar[0] = Convert.ToDouble(health.Substring(health.IndexOf("(")+1,
								health.IndexOf("%")-health.IndexOf("(")-1));

					if ( ill.Equals("0") )
							statusBar[1] = 0;
					else
						statusBar[1] = Convert.ToDouble(ill.Substring(ill.IndexOf("(")+1,
								ill.IndexOf("%")-ill.IndexOf("(")-1));

					if ( watch.Equals("0") )
						statusBar[2] = 0;
					else
						statusBar[2] = Convert.ToDouble(watch.Substring(watch.IndexOf("(")+1,
							watch.IndexOf("%")-watch.IndexOf("(")-1));

					if ( absence.Equals("0") )
						statusBar[3] = 0;
					else
						statusBar[3] = Convert.ToDouble(absence.Substring(absence.IndexOf("(")+1,
						absence.IndexOf("%")-absence.IndexOf("(")-1));

					if ( attend.Equals("0") )
						statusBar[4] = 0;
					else
						statusBar[4] = Convert.ToDouble(attend.Substring(attend.IndexOf("(")+1,
							attend.IndexOf("%")-attend.IndexOf("(")-1));

					BarItem myBar = myPane.AddBar( dsBuildStatInfo.Tables[0].Rows[0]["info_className"].ToString(), null, statusBar, Color.Red);
					myBar.Bar.Fill = new Fill( Color.Red, Color.White,Color.Red );

			
					for ( int i=0; i<statusBar.Length; i++ )
					{
						// format the label string to have 1 decimal place
						string lab = statusBar[i].ToString( "0.00" );
						// create the text item (assumes the x axis is ordinal or text)
						// for negative bars, the label appears just above the zero value
						TextItem text = new TextItem( lab, (float) (i+1), (float) (statusBar[i] + 1 ) );
						// tell Zedgraph to use user scale units for locating the TextItem
						text.Location.CoordinateFrame = CoordType.AxisXYScale;
						// AlignH the left-center of the text to the specified point
						text.Location.AlignH = AlignH.Center;
						text.Location.AlignV = AlignV.Bottom;
						text.FontSpec.Border.IsVisible = false;
						text.FontSpec.Fill.IsVisible = false;
						// rotate the text 90 degrees
						text.FontSpec.Angle = 0;
						// add the TextItem to the list
						myPane.GraphItemList.Add( text );
					}

					myPane.XAxis.IsTicsBetweenLabels = true;

					// Set the XAxis labels
					myPane.XAxis.TextLabels = statusLabels;

					myPane.XAxis.ScaleFontSpec.Size = 12;
					// Set the XAxis to Text type
					myPane.XAxis.Type = AxisType.Text;

					// Fill the Axis and Pane backgrounds
					myPane.AxisFill = new Fill( Color.Pink,
						Color.FromArgb( 255, 255, 166), 90F );
					myPane.PaneFill = new Fill( Color.Lavender );
    
					// Tell ZedGraph to refigure the
					// axes since the data have changed
//					myPane.AxisChange( gra );
//					myPane.Draw(gra);

//					myPane.ReSize(gra,new RectangleF(1500, 300, 800,600));

					zedGraph_StuBarPrint.IsShowContextMenu = false;
					zedGraph_StuBarPrint.IsEnableZoom = false;
					zedGraph_StuBarPrint.AxisChange();

					return myPane.Image;

				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public Bitmap Pie_InfoStat(string getGrade,string getClass,GroupControl gControl)
		{
			using ( StudentAttendCalcDataAccess stuAttCalcDataAccess = new StudentAttendCalcDataAccess() )
			{
				try
				{
					stuAttCalcDataAccess.DoAttendCalcForClass(getGrade,getClass,BegDate.ToString("yyyy-MM-dd"),EndDate.ToString("yyyy-MM-dd"),"健康");
					double healthPer = (double)stuAttCalcDataAccess.StateAmount/((double)stuAttCalcDataAccess.StuAmount*SetAttendDays())*100;
					stuAttCalcDataAccess.DoAttendCalcForClass(getGrade,getClass,BegDate.ToString("yyyy-MM-dd"),EndDate.ToString("yyyy-MM-dd"),"服药");
					double illPer = (double)stuAttCalcDataAccess.StateAmount/((double)stuAttCalcDataAccess.StuAmount*SetAttendDays())*100;
					stuAttCalcDataAccess.DoAttendCalcForClass(getGrade,getClass,BegDate.ToString("yyyy-MM-dd"),EndDate.ToString("yyyy-MM-dd"),"观察");
					double watchPer = (double)stuAttCalcDataAccess.StateAmount/((double)stuAttCalcDataAccess.StuAmount*SetAttendDays())*100;
//					stuAttCalcDataAccess.DoAttendCalcForClass(getGrade,getClass,BegDate.ToString("yyyy-MM-dd"),EndDate.ToString("yyyy-MM-dd"),"缺席");
//					double absPer = (double)stuAttCalcDataAccess.StateAmount/((double)stuAttCalcDataAccess.StuAmount*SetAttendDays())*100;
					double absPer = 100-healthPer-illPer-watchPer;

//					Graphics gra = gControl.CreateGraphics();
//					GraphPane myPane = new GraphPane( new Rectangle( 0, 0, gControl.Width, gControl.Height ),
//						"11", "11", "11" );
					zedGraph_StuPiePrint = new ZedGraphControl();
					gControl.Controls.Clear();
					gControl.Controls.Add(zedGraph_StuPiePrint);
					zedGraph_StuPiePrint.Dock = DockStyle.Fill;
					
					GraphPane myPane = zedGraph_StuPiePrint.GraphPane;

					if ( getGrade.Equals("") )
						myPane.Title = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
							+ "全年级晨检信息统计图\n"+"统计日期: " + BegDate.ToString("yyyy.MM.dd") + " 至 "
							+ EndDate.ToString("yyyy.MM.dd");
					else if ( getClass.Equals("") )
						myPane.Title = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
							+ new StuInfoDataAccess().GetGradeList("",getGrade).Tables[0].Rows[0][1].ToString()
							+ "晨检信息统计图\n"+"统计日期: " + BegDate.ToString("yyyy.MM.dd") + " 至 "
							+ EndDate.ToString("yyyy.MM.dd");
					else
						myPane.Title = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
							+ new RealtimeInfoDataAccess().setClassList("",getClass,getGrade).Tables[0].Rows[0][1].ToString()
							+ "晨检信息统计图\n"+"统计日期: " + BegDate.ToString("yyyy.MM.dd") + " 至 "
							+ EndDate.ToString("yyyy.MM.dd");

					double[] statusVal = { healthPer, watchPer, absPer, illPer };
					string[] statusLabel = { "健康", "观察", "缺席", "服药"  };

					myPane.PaneFill = new Fill( Color.Cornsilk );
					myPane.AxisFill = new Fill( Color.Cornsilk );
					myPane.Legend.Position = LegendPos.Right ;
					myPane.Legend.FontSpec.Size = 14;

					PieItem [] slices = new PieItem[statusVal.Length] ;
					slices = myPane.AddPieSlices ( statusVal, statusLabel ) ;
					
					((PieItem)slices[0]).LabelType = PieLabelType.Percent ;
					((PieItem)slices[0]).LabelDetail.FontSpec.Size = 14;
					((PieItem)slices[1]).LabelType = PieLabelType.Percent ;
					((PieItem)slices[1]).LabelDetail.FontSpec.Size = 14;
					((PieItem)slices[2]).LabelType = PieLabelType.Percent ;
					((PieItem)slices[2]).LabelDetail.FontSpec.Size = 14;
					((PieItem)slices[3]).LabelType = PieLabelType.Percent ;
					((PieItem)slices[3]).LabelDetail.FontSpec.Size = 14;
					((PieItem)slices[1]).Displacement = .2 ;
					((PieItem)slices[2]).Displacement = .2 ;

					BoxItem box = new BoxItem( new RectangleF( 0F, 0F, 1F, 1F ),
						Color.Empty, Color.PeachPuff );
					box.Location.CoordinateFrame = CoordType.AxisFraction;
					box.Border.IsVisible = false;
					box.Location.AlignH = AlignH.Left;
					box.Location.AlignV = AlignV.Top;
					box.ZOrder = ZOrder.E_BehindAxis;

					myPane.GraphItemList.Add( box );
//					myPane.AxisChange(gra);
//					myPane.Draw(gra);

//					myPane.ReSize(gra,new RectangleF(150, 300, 800,600));

					zedGraph_StuPiePrint.IsShowContextMenu = false;
					zedGraph_StuPiePrint.IsEnableZoom = false;
					zedGraph_StuPiePrint.AxisChange();

					return myPane.Image;
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public void PrintKidStatInfo(string getGrade,string getClass,string getName,string getNumber,string savePath)
		{
			try
			{
				DataSet dsStuList_Stat = null;
				object[,] objData = null;
				DateTime getBegDate = BegDate;
				DateTime getEndDate = EndDate;
				string classInfo = string.Empty;

				using ( StudentCheckInfoDataAccess stuCheckInfoDataAccess = new StudentCheckInfoDataAccess() )
				{
					if ( getName.Equals("") && getNumber.Equals("") )
					{
						dsStuList_Stat = stuCheckInfoDataAccess.GetStuList_GradeClass(getGrade,getClass);
						classInfo = new ClassesDataAccess().GetClassInfo(Convert.ToInt32(getClass),Convert.ToInt32(getGrade)).Tables[0].Rows[0][1].ToString();
					}
					else
					{
						dsStuList_Stat = stuCheckInfoDataAccess.GetStuList_NameNumber(getName,getNumber);
						classInfo = dsStuList_Stat.Tables[0].Rows[0][2].ToString();
					}
				}

				if ( dsStuList_Stat.Tables[0].Rows.Count > 0 )
				{		
					objData = new object[dsStuList_Stat.Tables[0].Rows.Count,8];
					
					for ( int nameRow=0; nameRow<dsStuList_Stat.Tables[0].Rows.Count; nameRow++ )
					{
						DataSet dsStuCheckInfo_Stat = null;
						int times = 0;
								
						using ( StudentCheckInfoDataAccess stuCheckInfoDataAccess = new StudentCheckInfoDataAccess() )
						{
							dsStuCheckInfo_Stat = stuCheckInfoDataAccess.GetStuCheckInfo_Stat(dsStuList_Stat.Tables[0].Rows[nameRow][0].ToString(),getBegDate,getEndDate,ref times);

							objData[nameRow,0] = dsStuList_Stat.Tables[0].Rows[nameRow][1].ToString();
							objData[nameRow,1] = 0;
							objData[nameRow,2] = 0;
							objData[nameRow,3] = 0;
							objData[nameRow,6] = 0;

							int total = SetAttendDays();
							int health = 0;
							int ill = 0;
							int watch = 0;
							int absence = 0;

							DataRow[] drHealth = dsStuCheckInfo_Stat.Tables[0].Select("flow_stuFlowEnterState=0");
							if (drHealth.Length > 0)
							{
								health = Convert.ToInt32(drHealth[0]["stateCount"]);
							}
							
							DataRow[] drWatch = dsStuCheckInfo_Stat.Tables[0].Select("flow_stuFlowEnterState=2");
							if (drWatch.Length > 0)
							{
								watch = Convert.ToInt32(drWatch[0]["stateCount"]);
							}
							DataRow[] drIll = dsStuCheckInfo_Stat.Tables[0].Select("flow_stuFlowEnterState=3");
							if (drIll.Length > 0)
							{
								ill = Convert.ToInt32(drIll[0]["stateCount"]);
							}

							absence = total - health - watch - ill;
								
							objData[nameRow,1] = string.Format("{0} ({1})",
								health, ((double)health/(double)total).ToString("0.00%"));
						
							objData[nameRow,2] = string.Format("{0} ({1})",
								watch, ((double)watch/(double)total).ToString("0.00%"));

							objData[nameRow,3] = string.Format("{0} ({1})",
								ill, ((double)ill/(double)total).ToString("0.00%"));

							objData[nameRow,6] = string.Format("{0} ({1})",
								absence, ((double)absence/(double)total).ToString("0.00%"));


//							foreach ( DataRow stateRow in dsStuCheckInfo_Stat.Tables[0].Rows )
//							{
//								
//
//
//								if ( Convert.ToInt32(stateRow[1]) == 0 )
//								{
//									objData[nameRow,1] = stateRow[0].ToString()
//										+" ("+(Convert.ToDouble(stateRow[0])/(double)SetAttendDays()).ToString("0.00%")+")";
//									continue;
//								}
//			
//								else if ( Convert.ToInt32(stateRow[1]) == 2 )
//								{
//									objData[nameRow,2] = stateRow[0].ToString()
//										+" ("+(Convert.ToDouble(stateRow[0])/(double)SetAttendDays()).ToString("0.00%")+")";
//									continue;
//								}
//
//								else if ( Convert.ToInt32(stateRow[1]) == 3 )
//								{
//									objData[nameRow,3] = stateRow[0].ToString()
//										+" ("+(Convert.ToDouble(stateRow[0])/(double)SetAttendDays()).ToString("0.00%")+")";
//									continue;
//								}
//
//								else if ( Convert.ToInt32(stateRow[1]) == -1 )
//								{
////									int total = SetAttendDays();
////									int health = 
////
////									objData[nameRow,6] = stateRow[0].ToString()
////										+" ("+(Convert.ToDouble(stateRow[0])/(double)SetAttendDays()).ToString("0.00%")+")";
////									continue;
//
//									objData[nameRow,6] = stateRow[0].ToString()
//										+" ("+(Convert.ToDouble(stateRow[0])/(double)SetAttendDays()).ToString("0.00%")+")";
//									continue;
//								}
//									//晨检状态错误
//								else
//								{
//									Util.WriteLog("晨检状态错误！",Util.EXCEPTION_LOG_TITLE);
//									break;
//								}
//							}

							objData[nameRow,4] = SetAttendDays();
							objData[nameRow,5] = times;
							objData[nameRow,7] = (times/(double)SetAttendDays()).ToString("0.00%");
						}
					}

					m_objExcel = new Excel.Application();
					m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
					m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\MorningCheckInfoKidStat.xls",
						m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
						m_objOpt,m_objOpt,m_objOpt);
				
					m_objSheets = (Excel.Sheets)m_objBook.Sheets;	
					m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));

					m_objRange = m_objSheet.get_Range("A4",m_objOpt);
					m_objRange = m_objRange.get_Resize(dsStuList_Stat.Tables[0].Rows.Count,8);

					m_objRange.Value = objData;

					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					m_objRange.Font.Size = 10;

					WriteJumpboard(dsStuList_Stat.Tables[0].Rows.Count,classInfo);

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

		public void PrintKidDetailInfo(string getGrade,string getClass,string getName,string getNumber,string savePath)
		{
			try
			{
				DataSet dsStuList_Stat = null;
				DateTime getBegDate = BegDate;
				DateTime getEndDate = EndDate;
				int mbTwoDates = (getEndDate.Year-getBegDate.Year)*12 + (getEndDate.Month-getBegDate.Month);
				int monthes = (getEndDate.Year-getBegDate.Year)*12 + (getEndDate.Month-getBegDate.Month);
				string classInfo = string.Empty;

				using ( StudentCheckInfoDataAccess stuCheckInfoDataAccess = new StudentCheckInfoDataAccess() )
				{
					if ( getName.Equals("") && getNumber.Equals("") )
					{
						dsStuList_Stat = stuCheckInfoDataAccess.GetStuList_GradeClass(getGrade,getClass);
						classInfo = new ClassesDataAccess().GetClassInfo(Convert.ToInt32(getClass),Convert.ToInt32(getGrade)).Tables[0].Rows[0][1].ToString();
					}
					else
					{
						dsStuList_Stat = stuCheckInfoDataAccess.GetStuList_NameNumber(getName,getNumber);
						classInfo = dsStuList_Stat.Tables[0].Rows[0][2].ToString();
					}
				}

				if ( dsStuList_Stat.Tables[0].Rows.Count > 0 )
				{
					m_objExcel = new Excel.Application();
					m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
					m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\MorningCheckInfoKidDetail.xls",
						m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
						m_objOpt,m_objOpt,m_objOpt);
				
					m_objSheets = (Excel.Sheets)m_objBook.Sheets;						

					for ( int i=0; i<=monthes; i++ )
					{
						GetExcelEndDate(getBegDate,ref getEndDate);

						m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(i+1));

						if ( mbTwoDates >= 1 )
							m_objSheet.Copy(m_objOpt,m_objSheet);

						m_objRange = m_objSheet.get_Range("AE2",m_objOpt);
						m_objRange.Value = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
						m_objRange = m_objSheet.get_Range("AE3",m_objOpt);
						m_objRange.Value = classInfo;
						m_objRange = m_objSheet.get_Range("AE4",m_objOpt);
						m_objRange.Value = "'" + getBegDate.ToString("yyyy.MM");

						WriteMonth(getBegDate);

						for ( int nameRow=0; nameRow<dsStuList_Stat.Tables[0].Rows.Count; nameRow++ )
						{
							DataSet dsStuCheckInfo_Detail = null;
								
							using ( StudentCheckInfoDataAccess stuCheckInfoDataAccess = new StudentCheckInfoDataAccess() )
							{
								dsStuCheckInfo_Detail = stuCheckInfoDataAccess.GetStuCheckInfo_Detail(dsStuList_Stat.Tables[0].Rows[nameRow][0].ToString(),getBegDate,getEndDate);
								WriteExcelForDetail(getBegDate,getEndDate,dsStuCheckInfo_Detail,nameRow,
									dsStuList_Stat.Tables[0].Rows[nameRow][1].ToString());
							}
						}

						mbTwoDates--;
						getBegDate = getEndDate.AddDays(1);
						getEndDate = EndDate;
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

		private int SetAttendDays()
		{
			return new UtilDataAccess().GetAttendDays(BegDate, EndDate);

			/*
			string dateDiff = (EndDate.Date - BegDate.Date).ToString();
			DateTime initBegDate = BegDate;
			
			if( EndDate.Date == BegDate.Date )
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


		//获取每张EXCEL表的最后日期
		private void GetExcelEndDate(DateTime getBegDate,ref DateTime getEndDate)
		{
			if ( (getEndDate.Year-getBegDate.Year)*12 + (getEndDate.Month-getBegDate.Month) != 0 )
			{
				while ( getBegDate.AddDays(1).Month == getBegDate.Month )
				{
					getEndDate = getBegDate.AddDays(1);
					getBegDate = getBegDate.AddDays(1);
				}
			}
			else
				getEndDate = getEndDate;
		}

		//将学生每天出勤信息写入EXCEL
		private void WriteExcelForDetail(DateTime getBegDate,DateTime getEndDate,DataSet dsStuCheckInfo_Detail,int nameRow,string getName)
		{
			m_objRange = m_objSheet.get_Range(m_objSheet.Cells[2*nameRow+9,1],m_objSheet.Cells[2*nameRow+9,1]);
			m_objRange.Value = getName;
			m_objRange.Font.Size = 11;

			m_objRange = m_objSheet.get_Range("A"+(2*nameRow+9).ToString(),"AI"+(2*nameRow+10).ToString());
			m_objRange.WrapText = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			
			for ( int dateColumn=5; dateColumn<=35; dateColumn++ )
			{
				bool hasWrittenExcel = false;
				m_objRangeDate = m_objSheet.get_Range(m_objSheet.Cells[5,dateColumn],m_objSheet.Cells[5,dateColumn]);

				if ( getBegDate.Day == dateColumn-4 )
				{
					bool hasCheckInfo = new StudentCheckInfoDataAccess().HasCheckInfoOneDay(getBegDate); 

					if ( getBegDate.Day <= getEndDate.Day)
					{
						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[2*nameRow+9,dateColumn],m_objSheet.Cells[2*nameRow+9,dateColumn]);

						if ( dsStuCheckInfo_Detail.Tables[0].Rows.Count > 0 )
						{
							foreach ( DataRow detailRow in dsStuCheckInfo_Detail.Tables[0].Rows )
							{
								string dateIndexer = detailRow[1] is DBNull ? string.Empty : Convert.ToDateTime(detailRow[1]).ToString("yyyy-MM-dd");
								if (getBegDate.Date.ToString("yyyy-MM-dd").Equals(dateIndexer))
								{
									if (dateIndexer.Length == 0)
									{
										m_objRange.Value = "×";
										hasWrittenExcel = true;
										break;
									}
									else
									{
										if ( detailRow[2].ToString().Equals("健康") )
										{
											m_objRange.Value = "√";
										}
										else if ( detailRow[2].ToString().Equals("观察") )
										{
											m_objRange.Value = "○";
										}
										else
										{
											m_objRange.Value = "□";
										}

										hasWrittenExcel = true;
										break;
									}
								}
							}
						}

						if ( !hasWrittenExcel ) 
						{
							m_objRange.Value = "×";
						}

						if ( getBegDate.Month == 5 || getBegDate.Month == 10 )
						{
							if ( getBegDate.Day >= 1 && getBegDate.Day <= 3 )
							{
								if ( getBegDate.Day == Convert.ToInt32(m_objRangeDate.Value) )
								{
									m_objRange = m_objSheet.get_Range(m_objSheet.Cells[2*nameRow+9,dateColumn],m_objSheet.Cells[2*nameRow+9,dateColumn]);
									if (!hasCheckInfo)
									{
										m_objRange.Value = "△";
										getBegDate = getBegDate.AddDays(1);
										continue;
									}
								}
							}
						}
						if ( getBegDate.Month == 1 && getBegDate.Day == 1)
						{
							if ( getBegDate.Day == Convert.ToInt32(m_objRangeDate.Value) )
							{
								m_objRange = m_objSheet.get_Range(m_objSheet.Cells[2*nameRow+9,dateColumn],m_objSheet.Cells[2*nameRow+9,dateColumn]);
								if (!hasCheckInfo)
								{
									m_objRange.Value = "△";
									getBegDate = getBegDate.AddDays(1);
									continue;
								}
							}
						}

						if ( getBegDate.DayOfWeek.ToString().Equals("Saturday") || getBegDate.DayOfWeek.ToString().Equals("Sunday") )
						{
							if ( getBegDate.Day == Convert.ToInt32(m_objRangeDate.Value) )
							{
								m_objRange = m_objSheet.get_Range(m_objSheet.Cells[2*nameRow+9,dateColumn],m_objSheet.Cells[2*nameRow+9,dateColumn]);
								if (!hasCheckInfo)
								{
									m_objRange.Value = "△";
									getBegDate = getBegDate.AddDays(1);
									continue;
								}
							}
						}
					}
				
					getBegDate = getBegDate.AddDays(1);
				}
			}
		}
		
		private void WriteMonth(DateTime getDate)
		{
			switch ( getDate.Month )
			{
				case 1:		m_objSheet.Name = "一月份";
				break;

				case 2:		m_objSheet.Name = "二月份";
				break;
	
				case 3:		m_objSheet.Name = "三月份";
				break;
	
				case 4:		m_objSheet.Name = "四月份";
				break;
		
				case 5:		m_objSheet.Name = "五月份";
				break;
		
				case 6:		m_objSheet.Name = "六月份";
				break;
		
				case 7:		m_objSheet.Name = "七月份";
				break;
	
				case 8:		m_objSheet.Name = "八月份";
				break;
			
				case 9:		m_objSheet.Name = "九月份";
				break;
			
				case 10:    m_objSheet.Name = "十月份";
				break;
			
				case 11:	m_objSheet.Name = "十一月份";
				break;
		
				case 12:    m_objSheet.Name = "十二月份";
				break;
		
				default:	m_objSheet.Name = "NULL";
				break;

			}
		}


		private void WriteJumpboard(int row,string classInfo)
		{
			m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+5,1],m_objSheet.Cells[row+5,1]);
			m_objRange.Value = "园所信息:";
			m_objRange.Font.Bold = true;
			m_objRange.Font.Size = 12;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
			m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+5,2],m_objSheet.Cells[row+5,2]);
			m_objRange.Value = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
			m_objRange.Font.Size = 12;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
			m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+6,1],m_objSheet.Cells[row+6,1]);
			m_objRange.Value = "班级信息:";
			m_objRange.Font.Bold = true;
			m_objRange.Font.Size = 12;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
			m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+6,2],m_objSheet.Cells[row+6,2]);
			m_objRange.Value = classInfo;
			m_objRange.Font.Size = 12;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
			m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
		
			m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+7,1],m_objSheet.Cells[row+7,1]);
			m_objRange.Value = "统计日期:";
			m_objRange.Font.Bold = true;
			m_objRange.Font.Size = 12;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
			m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+7,2],m_objSheet.Cells[row+7,2]);
			m_objRange.Value = Convert.ToDateTime(getBegDate).ToString("yyyy.MM.dd")+" -- "+Convert.ToDateTime(getEndDate).ToString("yyyy.MM.dd");
			m_objRange.Font.Size = 12;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
			m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
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
