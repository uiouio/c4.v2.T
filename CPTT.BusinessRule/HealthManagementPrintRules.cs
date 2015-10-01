using System;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CPTT.SystemFramework;
using CPTT.DataAccess;

namespace CPTT.BusinessRule
{
    using Excel = Microsoft.Office.Interop.Excel;
	/// <summary>
	/// HealthManagementPrintRules 的摘要说明。
	/// </summary>
	public class HealthManagementPrintRules
	{
		private Excel.Application m_objExcel = null;
		private Excel.Workbooks m_objBooks = null;
		private Excel._Workbook m_objBook = null;
		private Excel.Sheets m_objSheets = null;
		private Excel._Worksheet m_objSheet = null;
		private Excel.Range m_objRange = null;
		private Excel.Font m_objFont = null;
		private object m_objOpt = System.Reflection.Missing.Value;
		private string excelPath = AppDomain.CurrentDomain.BaseDirectory;
		private bool findSheet = false;
		private double getOverH;
		private double getSum;
		private double getOverW;
		public HealthManagementPrintRules()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

	
		public void PrintNchsHealthPersonal(string getOutputClass,string getOutputName,string getOutputNumber,DataSet dsHealthOutput,
			string getBegDate,string getEndDate,string savePath,string getTeacher)
		{
			try
			{
				m_objExcel = new Excel.Application(); 
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;				
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\NchsHealthOutputPersonal",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt); 

				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;

				for ( int sheetNumbers=1; sheetNumbers<dsHealthOutput.Tables[0].Rows.Count; sheetNumbers++ )
				{
					m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
					m_objSheet.Copy(Type.Missing,m_objSheet);
				}

				for ( int row=0; row<dsHealthOutput.Tables[0].Rows.Count; row++)
				{
					m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(row+1);
					m_objSheet.Name = dsHealthOutput.Tables[0].Rows[row]["info_stuName"].ToString()+
						"("+Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[row]["nchsanaly_checktime"]).Year.ToString()+
						"."+Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[row]["nchsanaly_checktime"]).Month.ToString()+")";

					m_objRange = m_objSheet.get_Range("E2",m_objOpt);
					m_objRange.Value = "  "+dsHealthOutput.Tables[0].Rows[row]["info_stuName"].ToString();

					m_objRange = m_objSheet.get_Range("G2",m_objOpt);
					m_objRange.Value = " "+dsHealthOutput.Tables[0].Rows[row]["info_stuGender"].ToString();

					m_objRange = m_objSheet.get_Range("I2",m_objOpt);
					m_objRange.Value = " "+Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[row]["info_stuBirthday"]).ToString("yyyy-MM-dd");
					
					m_objRange = m_objSheet.get_Range("B6",m_objOpt);
					
					string realAge = dsHealthOutput.Tables[0].Rows[row]["nchsanaly_realage"].ToString();

					if ( realAge.IndexOf(".") < 0 )
					{
						m_objRange.Value = realAge;
						m_objRange = m_objSheet.get_Range("C6",m_objOpt);
						m_objRange.Value = 0;
					}
					else
					{
						m_objRange.Value = realAge.Substring(0,realAge.IndexOf("."));
						m_objRange = m_objSheet.get_Range("C6",m_objOpt);
						m_objRange.Value = realAge.Substring(realAge.IndexOf(".")+1);
					}	

					double getHeight = Convert.ToDouble(dsHealthOutput.Tables[0].Rows[row]["nchsanaly_height"]);
					m_objRange = m_objSheet.get_Range("B7",m_objOpt);
					m_objRange.Value = getHeight;

					if ( dsHealthOutput.Tables[0].Rows[row]["nchsanaly_heightresult"].ToString().Equals("上") )
					{
						m_objRange = m_objSheet.get_Range("D7",m_objOpt);
						m_objRange.Value = "√";
					}
					else if ( dsHealthOutput.Tables[0].Rows[row]["nchsanaly_heightresult"].ToString().Equals("中上") )
					{
						m_objRange = m_objSheet.get_Range("E7",m_objOpt);
						m_objRange.Value = "√";
					}
					else if ( dsHealthOutput.Tables[0].Rows[row]["nchsanaly_heightresult"].ToString().Equals("中+") )
					{
						m_objRange = m_objSheet.get_Range("F7",m_objOpt);
						m_objRange.Value = "√";
					}
					else if ( dsHealthOutput.Tables[0].Rows[row]["nchsanaly_heightresult"].ToString().Equals("中-") )
					{
						m_objRange = m_objSheet.get_Range("H7",m_objOpt);
						m_objRange.Value = "√";
					}
					else if ( dsHealthOutput.Tables[0].Rows[row]["nchsanaly_heightresult"].ToString().Equals("中下") )
					{
						m_objRange = m_objSheet.get_Range("J7",m_objOpt);
						m_objRange.Value = "√";
					}
					else
					{
						m_objRange = m_objSheet.get_Range("L7",m_objOpt);
						m_objRange.Value = "√";
					}

					double getWeight = Convert.ToDouble(dsHealthOutput.Tables[0].Rows[row]["nchsanaly_weight"]);
					m_objRange = m_objSheet.get_Range("B8",m_objOpt);
					m_objRange.Value = getWeight;

					if ( dsHealthOutput.Tables[0].Rows[row]["nchsanaly_weightresult"].ToString().Equals("上") )
					{
						m_objRange = m_objSheet.get_Range("D8",m_objOpt);
						m_objRange.Value = "√";
					}
					else if ( dsHealthOutput.Tables[0].Rows[row]["nchsanaly_weightresult"].ToString().Equals("中上") )
					{
						m_objRange = m_objSheet.get_Range("E8",m_objOpt);
						m_objRange.Value = "√";
					}
					else if ( dsHealthOutput.Tables[0].Rows[row]["nchsanaly_weightresult"].ToString().Equals("中+") )
					{
						m_objRange = m_objSheet.get_Range("F8",m_objOpt);
						m_objRange.Value = "√";
					}
					else if ( dsHealthOutput.Tables[0].Rows[row]["nchsanaly_weightresult"].ToString().Equals("中-") )
					{
						m_objRange = m_objSheet.get_Range("H8",m_objOpt);
						m_objRange.Value = "√";
					}
					else if ( dsHealthOutput.Tables[0].Rows[row]["nchsanaly_weightresult"].ToString().Equals("中下") )
					{
						m_objRange = m_objSheet.get_Range("J8",m_objOpt);
						m_objRange.Value = "√";
					}
					else
					{
						m_objRange = m_objSheet.get_Range("L8",m_objOpt);
						m_objRange.Value = "√";
					}
					
					int getGender = dsHealthOutput.Tables[0].Rows[row]["info_stuGender"].ToString().Equals("男")?0:1;
					
					double ageHeightMiddleValue = Convert.ToDouble(new HealthManagementDataAccess().GetNchsAgeHeightMiddleValue(realAge,getGender).Rows[0]["nchs_middle"]);
					double ageWeightMiddleValue = Convert.ToDouble(new HealthManagementDataAccess().GetNchsAgeWeightMiddleValue(realAge,getGender).Rows[0]["nchs_middle"]);

					
					string rangeValue = string.Empty;

					if ( dsHealthOutput.Tables[0].Rows[row]["nchsanaly_underweight"].Equals("中度体重低下") || dsHealthOutput.Tables[0].Rows[row]["nchsanaly_underweight"].Equals("重度体重低下") )
					{
						m_objRange = m_objSheet.get_Range("C12",m_objOpt);

						rangeValue = Math.Abs((Convert.ToDouble(dsHealthOutput.Tables[0].Rows[row]["nchsanaly_weight"])-ageWeightMiddleValue)/ageWeightMiddleValue).ToString("0.0%")+",";
						m_objRange.Value = rangeValue;

						m_objRange = m_objSheet.get_Range("A14",m_objOpt);
						m_objRange.Value = "√";
					}

					if ( dsHealthOutput.Tables[0].Rows[row]["nchsanaly_stunting"].Equals("中度生长迟缓") || dsHealthOutput.Tables[0].Rows[row]["nchsanaly_stunting"].Equals("重度生长迟缓") ) 
					{
						m_objRange = m_objSheet.get_Range("C12",m_objOpt);

						rangeValue += Math.Abs((Convert.ToDouble(dsHealthOutput.Tables[0].Rows[row]["nchsanaly_height"])-ageHeightMiddleValue)/ageHeightMiddleValue).ToString("0.0%");
						m_objRange.Value = rangeValue;

						m_objRange = m_objSheet.get_Range("C14",m_objOpt);
						m_objRange.Value = "√";
					}
					else
					{
						if (rangeValue == string.Empty)
						{
							m_objRange = m_objSheet.get_Range("F11", m_objOpt);
							m_objRange.Value = "等";
							m_objRange = m_objSheet.get_Range("C12", m_objOpt);
							m_objRange.Value = ageWeightMiddleValue.ToString() + "," + ageHeightMiddleValue.ToString();
							m_objRange = m_objSheet.get_Range("E14",m_objOpt);
							m_objRange.Value = "√";
						}
						else
						{
							m_objRange = m_objSheet.get_Range("C12",m_objOpt);
							rangeValue.Replace(",","");
							m_objRange.Value = rangeValue;
						}
					}

					double heightWeightMiddleValue = Convert.ToDouble(new HealthManagementDataAccess().GetNchsHeightWeightMiddleValue(getHeight,getGender).Rows[0]["nchs_middle"]);

					if ( !dsHealthOutput.Tables[0].Rows[row]["nchsanaly_wasting"].ToString().Equals("正常") )
					{
						m_objRange = m_objSheet.get_Range("K11", m_objOpt);
						m_objRange.Value = "低于";
						m_objRange = m_objSheet.get_Range("H13",m_objOpt);
						m_objRange.Value = Math.Abs((getWeight - heightWeightMiddleValue)/heightWeightMiddleValue).ToString("0.0%");

						if ( dsHealthOutput.Tables[0].Rows[row]["nchsanaly_wasting"].ToString().Equals("中度消瘦") )
						{
							m_objRange = m_objSheet.get_Range("H15",m_objOpt);
							m_objRange.Value = "√";
						}
						else
						{
							m_objRange = m_objSheet.get_Range("G15",m_objOpt);
							m_objRange.Value = "√";
						}
					}
					else
					{
						if ( !dsHealthOutput.Tables[0].Rows[row]["nchsanaly_obesity"].ToString().Equals("正常") )
						{
							m_objRange = m_objSheet.get_Range("K11", m_objOpt);
							m_objRange.Value = "高于";
							m_objRange = m_objSheet.get_Range("H13",m_objOpt);
							m_objRange.Value = Math.Abs((getWeight - heightWeightMiddleValue)/heightWeightMiddleValue).ToString("0.0%");

							if ( dsHealthOutput.Tables[0].Rows[row]["nchsanaly_obesity"].ToString().Equals("轻度肥胖") )
							{
								m_objRange = m_objSheet.get_Range("I15",m_objOpt);
								m_objRange.Value = "√";
							}
							else if ( dsHealthOutput.Tables[0].Rows[row]["nchsanaly_obesity"].ToString().Equals("中度肥胖") )
							{
								m_objRange = m_objSheet.get_Range("J15",m_objOpt);
								m_objRange.Value = "√";
							}
							else
							{
								m_objRange = m_objSheet.get_Range("K15",m_objOpt);
								m_objRange.Value = "√";
							}
						}
						else
						{
							m_objRange = m_objSheet.get_Range("H13", m_objOpt);
							m_objRange.Value = heightWeightMiddleValue.ToString();
							m_objRange = m_objSheet.get_Range("L15", m_objOpt);
							m_objRange.Value = "√";
						}
					}

					m_objRange = m_objSheet.get_Range("H17",m_objOpt);
					m_objRange.Value = getTeacher;

					m_objRange = m_objSheet.get_Range("H19",m_objOpt);
					m_objRange.Value = DateTime.Now;

					m_objRange = m_objSheet.get_Range("H21", m_objOpt);
					m_objRange.Value = dsHealthOutput.Tables[0].Rows[row]["nchsanaly_checktime"].ToString();

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
	
		public void PrintNchsHealthSummary(bool printType1st,bool printType2nd,string getOutputGrade,
			string getOutputClass,string getOutputName,string getOutputNumber,DataSet dsHealthOutput,
			string getBegDate,string getEndDate,string savePath)
		{
			try
			{

				m_objExcel = new Excel.Application(); 
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;				
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\NchsHealthOutputSummary",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt); 

				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;

				if ( printType1st )
				{
					if ( !getOutputName.Equals("") || !getOutputNumber.Equals(""))
					{
						if ( dsHealthOutput.Tables[0].Rows.Count > 0 )
						{
							m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
							m_objSheets.Add(m_objSheet,Type.Missing,1,Type.Missing);
							m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
							m_objSheet.Name = dsHealthOutput.Tables[0].Rows[0]["info_className"].ToString();
							SetNchsTitle(printType1st);
							for ( int i=0; i<dsHealthOutput.Tables[0].Rows.Count; i++ )
							{
								for ( int j=2; j<dsHealthOutput.Tables[0].Columns.Count-1; j++ )
								{
									m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,j-1],m_objSheet.Cells[i+4,j-1]);
									m_objRange.NumberFormatLocal = "@";
									if ( j != 5 )
										m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
									else
										m_objRange.set_Item(1,1,Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[i][j]).ToString("yyyy-MM-dd"));
									m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
									m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
									m_objRange.Font.Size = 10;
								}
							}
							setJumpBoard(dsHealthOutput.Tables[0].Rows.Count,dsHealthOutput,dsHealthOutput.Tables[0].Rows.Count-1);
						}
					}
					else
					{
						if ( !getOutputGrade.Equals("") )
						{
							if ( getOutputClass.Equals("") )
							{
								int rowBeg = 4;
								for ( int i=0; i<dsHealthOutput.Tables[0].Rows.Count; i++ )
								{
									if ( !hasSheet(dsHealthOutput.Tables[0].Rows[i][1].ToString()) )
									{ 
										rowBeg = 4;
										m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
										m_objSheet.Name = dsHealthOutput.Tables[0].Rows[i][1].ToString();
										SetNchsTitle(printType1st);
										for ( int j=2; j<dsHealthOutput.Tables[0].Columns.Count-1; j++ )
										{
											m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowBeg,j-1],m_objSheet.Cells[rowBeg,j-1]);
											m_objRange.NumberFormatLocal = "@";
											if ( j != 5 )
												m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
											else
												m_objRange.set_Item(1,1,Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[i][j]).ToString("yyyy-MM-dd"));
											m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
											m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
											m_objRange.Font.Size = 10;
										}
										rowBeg++;
									}	
									else
									{
										m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
										for ( int j=2; j<dsHealthOutput.Tables[0].Columns.Count-1; j++ )
										{
											m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowBeg,j-1],m_objSheet.Cells[rowBeg,j-1]);
											m_objRange.NumberFormatLocal = "@";
											if ( j != 5 )
												m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
											else
												m_objRange.set_Item(1,1,Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[i][j]).ToString("yyyy-MM-dd"));
											m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
											m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
											m_objRange.Font.Size = 10;
										}
										rowBeg++;
									}
									if ( i < dsHealthOutput.Tables[0].Rows.Count - 1 ) 
									{
										if ( !dsHealthOutput.Tables[0].Rows[i][1].ToString().Equals(dsHealthOutput.Tables[0].Rows[i+1][1].ToString()))
											setJumpBoard(rowBeg-4,dsHealthOutput,i);
									}
									else
										setJumpBoard(rowBeg-4,dsHealthOutput,i);
								}
							}
							else
							{
								m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
								m_objSheets.Add(m_objSheet,Type.Missing,1,Type.Missing);
								m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
								m_objSheet.Name = dsHealthOutput.Tables[0].Rows[0][1].ToString();
								SetNchsTitle(printType1st);
				
								for ( int i=0; i<dsHealthOutput.Tables[0].Rows.Count; i++ )
								{
									for ( int j=2; j<dsHealthOutput.Tables[0].Columns.Count-1; j++ )
									{
										m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,j-1],m_objSheet.Cells[i+4,j-1]);
										m_objRange.NumberFormatLocal = "@";
										if ( j != 5 )
											m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
										else
											m_objRange.set_Item(1,1,Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[i][j]).ToString("yyyy-MM-dd"));
										m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
										m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
										m_objRange.Font.Size = 10;
									}
								}
								setJumpBoard(dsHealthOutput.Tables[0].Rows.Count,dsHealthOutput,dsHealthOutput.Tables[0].Rows.Count-1);
							}
						}
						else
						{
							int rowBeg = 4;
							for ( int i=0; i<dsHealthOutput.Tables[0].Rows.Count; i++ )
							{
								if ( !hasSheet(dsHealthOutput.Tables[0].Rows[i][1].ToString()) )
								{ 
									rowBeg = 4;
									m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
									m_objSheet.Name = dsHealthOutput.Tables[0].Rows[i][1].ToString();
									SetNchsTitle(printType1st);
									for ( int j=2; j<dsHealthOutput.Tables[0].Columns.Count-1; j++ )
									{
										m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowBeg,j-1],m_objSheet.Cells[rowBeg,j-1]);
										m_objRange.NumberFormatLocal = "@";
										if ( j != 5 )
											m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
										else
											m_objRange.set_Item(1,1,Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[i][j]).ToString("yyyy-MM-dd"));
										m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
										m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
										m_objRange.Font.Size = 10;
									}
									rowBeg++;
								}	
								else
								{
									m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
									for ( int j=2; j<dsHealthOutput.Tables[0].Columns.Count-1; j++ )
									{
										m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowBeg,j-1],m_objSheet.Cells[rowBeg,j-1]);
										m_objRange.NumberFormatLocal = "@";
										if ( j != 5 )
											m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
										else
											m_objRange.set_Item(1,1,Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[i][j]).ToString("yyyy-MM-dd"));
										m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
										m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
										m_objRange.Font.Size = 10;
									}
									rowBeg++;
								}
								if ( i < dsHealthOutput.Tables[0].Rows.Count - 1 ) 
								{
									if ( !dsHealthOutput.Tables[0].Rows[i][1].ToString().Equals(dsHealthOutput.Tables[0].Rows[i+1][1].ToString()))
										setJumpBoard(rowBeg-4,dsHealthOutput,i);
								}
								else
									setJumpBoard(rowBeg-4,dsHealthOutput,i);
							}
						}
					}
				}
				else
				{
					m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
					m_objSheets.Add(m_objSheet,Type.Missing,1,Type.Missing);
					m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
					m_objSheet.Name = "未划分班级";
					SetNchsTitle(printType1st);
					for ( int i=0; i<dsHealthOutput.Tables[0].Rows.Count; i++ )
					{
						for ( int j=2; j<dsHealthOutput.Tables[0].Columns.Count-1; j++ )
						{
							m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,j-1],m_objSheet.Cells[i+4,j-1]);
							m_objRange.NumberFormatLocal = "@";
							if ( j==2 )
								m_objRange.set_Item(1,1,"("+dsHealthOutput.Tables[0].Rows[i][j-1].ToString()+")"+
									dsHealthOutput.Tables[0].Rows[i][j].ToString());
							else
							{
								if ( j != 5 )
									m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
								else
									m_objRange.set_Item(1,1,Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[i][j]).ToString("yyyy-MM-dd"));
							}
							m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
							m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
							m_objRange.Font.Size = 10;
						}
					}
				}

				if ( printType2nd )
				{
					m_objSheet = (Excel._Worksheet)m_objSheets.get_Item("均值汇总");
					
					DataSet dsClass = new StuInfoDataAccess().GetClassList("","","");
					for ( int i=0; i<dsClass.Tables[0].Rows.Count; i++ )
					{
						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+6,1],m_objSheet.Cells[i+6,1]);
						m_objRange.Value = dsClass.Tables[0].Rows[i][1].ToString();
						m_objRange.RowHeight = 23.25;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
						m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
						m_objRange.Font.Size = 10;
					}

					m_objRange = m_objSheet.get_Range("A"+(dsClass.Tables[0].Rows.Count+6).ToString(),m_objOpt);
					m_objRange.Value = "合计";
					m_objRange.RowHeight = 23.25;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.Font.Size = 10;

					object[,]  objData = new object[dsClass.Tables[0].Rows.Count+1,31];

					int heightResult_1 = 0;
					int heightResult_2 = 0;
					int heightResult_3 = 0;
					int heightResult_4 = 0;
					int heightResult_5 = 0;
					int heightResult_6 = 0;
					int upMiddleHeightResult = 0;
					int weightResult_1 = 0;
					int weightResult_2 = 0;
					int weightResult_3 = 0;
					int weightResult_4 = 0;
					int weightResult_5 = 0;
					int weightResult_6 = 0;
					int upMiddleWeightResult = 0;

					int totalStudentNumbers = 0;
					int totalCheckNumbers = 0;
					int totalHeightResult_1 = 0;
					int totalHeightResult_2 = 0;
					int totalHeightResult_3 = 0;
					int totalHeightResult_4 = 0;
					int totalHeightResult_5 = 0;
					int totalHeightResult_6 = 0;
					int totalUpMiddleHeightResult = 0;
					int totalWeightResult_1 = 0;
					int totalWeightResult_2 = 0;
					int totalWeightResult_3 = 0;
					int totalWeightResult_4 = 0;
					int totalWeightResult_5 = 0;
					int totalWeightResult_6 = 0;
					int totalUpMiddleWeightResult = 0;

					for ( int row=0; row<dsClass.Tables[0].Rows.Count; row++ )
					{
						string getAddr = dsClass.Tables[0].Rows[row]["info_machineAddr"].ToString();

						DataSet dsStudentsOnSummary = new HealthManagementDataAccess().GetNchsStudentsOnSummary(getBegDate,getEndDate,getAddr);
						
						int studentNumbers = Convert.ToInt32(dsStudentsOnSummary.Tables[0].Rows[0][0]);
						totalStudentNumbers += studentNumbers;
						if ( studentNumbers == 0 ) 
						{
							for ( int column=0; column<=30; column++ )
							{
								objData[row,column] = 0;
							}

							continue;
						}

						objData[row,0] = studentNumbers;

						int checkNumbers = Convert.ToInt32(dsStudentsOnSummary.Tables[1].Rows[0][0]);
						totalCheckNumbers += checkNumbers;

						if ( checkNumbers == 0 )
						{
							for ( int column=1; column<=30; column++ )
							{
								objData[row,column] = 0;
							}
						}
						else
						{
							objData[row,1] = checkNumbers;
							objData[row,2] = ((double)checkNumbers/(double)studentNumbers*100).ToString("0.00");
						
							heightResult_1 = Convert.ToInt32(new HealthManagementDataAccess().GetNchsHeightOnSummary(getBegDate,getEndDate,"下",getAddr).Rows[0][0]);
							totalHeightResult_1 += heightResult_1;
							objData[row,3] = heightResult_1;
							objData[row,4] = ((double)heightResult_1/(double)checkNumbers*100).ToString("0.00");

							heightResult_2 = Convert.ToInt32(new HealthManagementDataAccess().GetNchsHeightOnSummary(getBegDate,getEndDate,"中下",getAddr).Rows[0][0]);
							totalHeightResult_2 += heightResult_2;
							objData[row,5] = heightResult_2;
							objData[row,6] = ((double)heightResult_2/(double)checkNumbers*100).ToString("0.00");

							heightResult_3 = Convert.ToInt32(new HealthManagementDataAccess().GetNchsHeightOnSummary(getBegDate,getEndDate,"中-",getAddr).Rows[0][0]);
							totalHeightResult_3 += heightResult_3;
							objData[row,7] = heightResult_3;
							objData[row,8] = ((double)heightResult_3/(double)checkNumbers*100).ToString("0.00");

							heightResult_4 = Convert.ToInt32(new HealthManagementDataAccess().GetNchsHeightOnSummary(getBegDate,getEndDate,"中+",getAddr).Rows[0][0]);
							totalHeightResult_4 += heightResult_4;
							objData[row,9] = heightResult_4;
							objData[row,10] = ((double)heightResult_4/(double)checkNumbers*100).ToString("0.00");

							heightResult_5 = Convert.ToInt32(new HealthManagementDataAccess().GetNchsHeightOnSummary(getBegDate,getEndDate,"中上",getAddr).Rows[0][0]);
							totalHeightResult_5 += heightResult_5;
							objData[row,11] = heightResult_5;
							objData[row,12] = ((double)heightResult_5/(double)checkNumbers*100).ToString("0.00");

							heightResult_6 = Convert.ToInt32(new HealthManagementDataAccess().GetNchsHeightOnSummary(getBegDate,getEndDate,"上",getAddr).Rows[0][0]);
							totalHeightResult_6 += heightResult_6;
							objData[row,13] = heightResult_6;
							objData[row,14] = ((double)heightResult_6/(double)checkNumbers*100).ToString("0.00");

							upMiddleHeightResult = Convert.ToInt32(new HealthManagementDataAccess().GetNchsHeightUpMiddleOnSummary(getBegDate,getEndDate,getAddr).Rows[0][0]);
							totalUpMiddleHeightResult += upMiddleHeightResult;
							objData[row,15] = upMiddleHeightResult;
							objData[row,16] = ((double)upMiddleHeightResult/(double)checkNumbers*100).ToString("0.00");

							weightResult_1 = Convert.ToInt32(new HealthManagementDataAccess().GetNchsWeightOnSummary(getBegDate,getEndDate,"下",getAddr).Rows[0][0]);
							totalWeightResult_1 += weightResult_1;
							objData[row,17] = weightResult_1;
							objData[row,18] = ((double)weightResult_1/(double)checkNumbers*100).ToString("0.00");

							weightResult_2 = Convert.ToInt32(new HealthManagementDataAccess().GetNchsWeightOnSummary(getBegDate,getEndDate,"中下",getAddr).Rows[0][0]);
							totalWeightResult_2 += weightResult_2;
							objData[row,19] = weightResult_2;
							objData[row,20] = ((double)weightResult_2/(double)checkNumbers*100).ToString("0.00");

							weightResult_3 = Convert.ToInt32(new HealthManagementDataAccess().GetNchsWeightOnSummary(getBegDate,getEndDate,"中-",getAddr).Rows[0][0]);
							totalWeightResult_3 += weightResult_3;
							objData[row,21] = weightResult_3;
							objData[row,22] = ((double)weightResult_3/(double)checkNumbers*100).ToString("0.00");

							weightResult_4 = Convert.ToInt32(new HealthManagementDataAccess().GetNchsWeightOnSummary(getBegDate,getEndDate,"中+",getAddr).Rows[0][0]);
							totalWeightResult_4 += weightResult_4;
							objData[row,23] = weightResult_4;
							objData[row,24] = ((double)weightResult_4/(double)checkNumbers*100).ToString("0.00");

							weightResult_5 = Convert.ToInt32(new HealthManagementDataAccess().GetNchsWeightOnSummary(getBegDate,getEndDate,"中上",getAddr).Rows[0][0]);
							totalWeightResult_5 += weightResult_5;
							objData[row,25] = weightResult_5;
							objData[row,26] = ((double)weightResult_5/(double)checkNumbers*100).ToString("0.00");

							weightResult_6 = Convert.ToInt32(new HealthManagementDataAccess().GetNchsWeightOnSummary(getBegDate,getEndDate,"上",getAddr).Rows[0][0]);
							totalWeightResult_6 += weightResult_6;
							objData[row,27] = weightResult_6;
							objData[row,28] = ((double)weightResult_6/(double)checkNumbers*100).ToString("0.00");

							upMiddleWeightResult = Convert.ToInt32(new HealthManagementDataAccess().GetNchsWeightUpMiddleOnSummary(getBegDate,getEndDate,getAddr).Rows[0][0]);
							totalUpMiddleWeightResult += upMiddleHeightResult;
							objData[row,29] = upMiddleHeightResult;
							objData[row,30] = ((double)upMiddleWeightResult/(double)checkNumbers*100).ToString("0.00");
						}
					}

					if ( totalStudentNumbers !=0 && totalCheckNumbers != 0 )
					{
						objData[dsClass.Tables[0].Rows.Count,0] = totalStudentNumbers;
						objData[dsClass.Tables[0].Rows.Count,1] = totalCheckNumbers;
						objData[dsClass.Tables[0].Rows.Count,2] = ((double)totalCheckNumbers/(double)totalStudentNumbers*100).ToString("0.00");
						objData[dsClass.Tables[0].Rows.Count,3] = totalHeightResult_1;
						objData[dsClass.Tables[0].Rows.Count,4] = ((double)totalHeightResult_1/(double)totalCheckNumbers*100).ToString("0.00");
						objData[dsClass.Tables[0].Rows.Count,5] = totalHeightResult_2;
						objData[dsClass.Tables[0].Rows.Count,6] = ((double)totalHeightResult_2/(double)totalCheckNumbers*100).ToString("0.00"); 
						objData[dsClass.Tables[0].Rows.Count,7] = totalHeightResult_3;
						objData[dsClass.Tables[0].Rows.Count,8] = ((double)totalHeightResult_3/(double)totalCheckNumbers*100).ToString("0.00"); 
						objData[dsClass.Tables[0].Rows.Count,9] = totalHeightResult_4;
						objData[dsClass.Tables[0].Rows.Count,10] = ((double)totalHeightResult_4/(double)totalCheckNumbers*100).ToString("0.00"); 
						objData[dsClass.Tables[0].Rows.Count,11] = totalHeightResult_5;
						objData[dsClass.Tables[0].Rows.Count,12] = ((double)totalHeightResult_5/(double)totalCheckNumbers*100).ToString("0.00"); 
						objData[dsClass.Tables[0].Rows.Count,13] = totalHeightResult_6;
						objData[dsClass.Tables[0].Rows.Count,14] = ((double)totalHeightResult_6/(double)totalCheckNumbers*100).ToString("0.00"); 
						objData[dsClass.Tables[0].Rows.Count,15] = totalUpMiddleHeightResult;
						objData[dsClass.Tables[0].Rows.Count,16] = ((double)totalUpMiddleHeightResult/(double)totalCheckNumbers*100).ToString("0.00");
						objData[dsClass.Tables[0].Rows.Count,17] = totalWeightResult_1;
						objData[dsClass.Tables[0].Rows.Count,18] = ((double)totalWeightResult_1/(double)totalCheckNumbers*100).ToString("0.00"); 
						objData[dsClass.Tables[0].Rows.Count,19] = totalWeightResult_2;
						objData[dsClass.Tables[0].Rows.Count,20] = ((double)totalWeightResult_2/(double)totalCheckNumbers*100).ToString("0.00"); 
						objData[dsClass.Tables[0].Rows.Count,21] = totalWeightResult_3;
						objData[dsClass.Tables[0].Rows.Count,22] = ((double)totalWeightResult_3/(double)totalCheckNumbers*100).ToString("0.00"); 
						objData[dsClass.Tables[0].Rows.Count,23] = totalWeightResult_4;
						objData[dsClass.Tables[0].Rows.Count,24] = ((double)totalWeightResult_4/(double)totalCheckNumbers*100).ToString("0.00"); 
						objData[dsClass.Tables[0].Rows.Count,25] = totalWeightResult_5;
						objData[dsClass.Tables[0].Rows.Count,26] = ((double)totalWeightResult_5/(double)totalCheckNumbers*100).ToString("0.00"); 
						objData[dsClass.Tables[0].Rows.Count,27] = totalWeightResult_6;
						objData[dsClass.Tables[0].Rows.Count,28] = ((double)totalWeightResult_6/(double)totalCheckNumbers*100).ToString("0.00"); 
						objData[dsClass.Tables[0].Rows.Count,29] = totalUpMiddleWeightResult;
						objData[dsClass.Tables[0].Rows.Count,30] = ((double)totalUpMiddleWeightResult/(double)totalCheckNumbers*100).ToString("0.00");
					}	
					else objData = null;
					
					m_objRange = m_objSheet.get_Range("B6",m_objOpt);
					m_objRange = m_objRange.get_Resize(dsClass.Tables[0].Rows.Count+1,31);

					if ( objData != null ) m_objRange.Value = objData;
					else m_objRange.Value = 0;

					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.Font.Size = 10;
					m_objFont = m_objRange.Font;

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
																																			 

		//健康评测打印
		public void PrintHealth(bool printType1st,bool printType2nd,bool printType3rd,string getOutputGrade,
			string getOutputClass,string getOutputName,string getOutputNumber,DataSet dsHealthOutput,
			string getBegDate,string getEndDate,string savePath)
		{
			try
			{
				m_objExcel = new Excel.Application(); 
				m_objExcel.DisplayAlerts = false;
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;				
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\health.xls",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt); 
 
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;

				if ( printType1st )
				{
					if ( !getOutputName.Equals("") || !getOutputNumber.Equals(""))
					{
						if ( dsHealthOutput.Tables[0].Rows.Count > 0 )
						{
							m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
							m_objSheets.Add(m_objSheet,Type.Missing,1,Type.Missing);
							m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
							m_objSheet.Name = dsHealthOutput.Tables[0].Rows[0][1].ToString();
							setTitle(printType1st);
							for ( int i=0; i<dsHealthOutput.Tables[0].Rows.Count; i++ )
							{
								for ( int j=2; j<dsHealthOutput.Tables[0].Columns.Count; j++ )
								{
									if (j <= 12)
									{
										m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,j-1],m_objSheet.Cells[i+4,j-1]);
										m_objRange.NumberFormatLocal = "@";
										if ( j==2 )
											m_objRange.set_Item(1,1,"("+dsHealthOutput.Tables[0].Rows[i][j-2].ToString()+")"+
												dsHealthOutput.Tables[0].Rows[i][j].ToString());
										else
										{
											if ( j != 5 )
												m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
											else
												m_objRange.set_Item(1,1,Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[i][j]).ToString("yyyy-MM-dd"));
										}
									}
									else
									{
										if (j == 14)
										{
											m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,12],m_objSheet.Cells[i+4,12]);
											m_objRange.NumberFormatLocal = "@";
											m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
										}
										if (j == 17)
										{
											m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,13],m_objSheet.Cells[i+4,13]);
											m_objRange.NumberFormatLocal = "@";
											m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
										}
								
									}

									m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
									m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
								}
							}
							setJumpBoard(dsHealthOutput.Tables[0].Rows.Count,dsHealthOutput,dsHealthOutput.Tables[0].Rows.Count-1);
						}
					}
					else
					{
						if ( !getOutputGrade.Equals("") )
						{
							if ( getOutputClass.Equals("") )
							{
								int rowBeg = 4;
								for ( int i=0; i<dsHealthOutput.Tables[0].Rows.Count; i++ )
								{
									if ( !hasSheet(dsHealthOutput.Tables[0].Rows[i][1].ToString()) )
									{ 
										rowBeg = 4;
										m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
										m_objSheet.Name = dsHealthOutput.Tables[0].Rows[i][1].ToString();
										setTitle(printType1st);
										for ( int j=2; j<dsHealthOutput.Tables[0].Columns.Count; j++ )
										{
											if (j <= 12)
											{
												m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowBeg,j-1],m_objSheet.Cells[rowBeg,j-1]);
												//m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,j-1],m_objSheet.Cells[i+4,j-1]);
												m_objRange.NumberFormatLocal = "@";
												if ( j==2 )
													m_objRange.set_Item(1,1,"("+dsHealthOutput.Tables[0].Rows[i][j-2].ToString()+")"+
														dsHealthOutput.Tables[0].Rows[i][j].ToString());
												else
												{
													if ( j != 5 )
														m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
													else
														m_objRange.set_Item(1,1,Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[i][j]).ToString("yyyy-MM-dd"));
												}
											}
											else
											{
												if (j == 14)
												{
													m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowBeg,12],m_objSheet.Cells[rowBeg,12]);
													//m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,12],m_objSheet.Cells[i+4,12]);
													m_objRange.NumberFormatLocal = "@";
													m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
												}
												if (j == 17)
												{
													m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowBeg,13],m_objSheet.Cells[rowBeg,13]);
													//m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,13],m_objSheet.Cells[i+4,13]);
													m_objRange.NumberFormatLocal = "@";
													m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
												}
								
											}

											m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
											m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
										}
										rowBeg++;
									}	
									else
									{
										m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
										for ( int j=2; j<dsHealthOutput.Tables[0].Columns.Count; j++ )
										{
											if (j <= 12)
											{
												m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowBeg,j-1],m_objSheet.Cells[rowBeg,j-1]);
												//m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,j-1],m_objSheet.Cells[i+4,j-1]);
												m_objRange.NumberFormatLocal = "@";
												if ( j==2 )
													m_objRange.set_Item(1,1,"("+dsHealthOutput.Tables[0].Rows[i][j-2].ToString()+")"+
														dsHealthOutput.Tables[0].Rows[i][j].ToString());
												else
												{
													if ( j != 5 )
														m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
													else
														m_objRange.set_Item(1,1,Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[i][j]).ToString("yyyy-MM-dd"));
												}
											}
											else
											{
												if (j == 14)
												{
													m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowBeg,12],m_objSheet.Cells[rowBeg,12]);
													//m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,12],m_objSheet.Cells[i+4,12]);
													m_objRange.NumberFormatLocal = "@";
													m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
												}
												if (j == 17)
												{
													m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowBeg,13],m_objSheet.Cells[rowBeg,13]);
													//m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,13],m_objSheet.Cells[i+4,13]);
													m_objRange.NumberFormatLocal = "@";
													m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
												}
								
											}

											m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
											m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
										}
										rowBeg++;
									}
									if ( i < dsHealthOutput.Tables[0].Rows.Count - 1 ) 
									{
										if ( !dsHealthOutput.Tables[0].Rows[i][1].ToString().Equals(dsHealthOutput.Tables[0].Rows[i+1][1].ToString()))
											setJumpBoard(rowBeg-4,dsHealthOutput,i);
									}
									else
										setJumpBoard(rowBeg-4,dsHealthOutput,i);
								}
							}
							else
							{
								m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
								m_objSheets.Add(m_objSheet,Type.Missing,1,Type.Missing);
								m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
								m_objSheet.Name = dsHealthOutput.Tables[0].Rows[0][1].ToString();
								setTitle(printType1st);
				
								for ( int i=0; i<dsHealthOutput.Tables[0].Rows.Count; i++ )
								{
									for ( int j=2; j<dsHealthOutput.Tables[0].Columns.Count; j++ )
									{
										if (j <= 12)
										{
											m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,j-1],m_objSheet.Cells[i+4,j-1]);
											m_objRange.NumberFormatLocal = "@";
											if ( j==2 )
												m_objRange.set_Item(1,1,"("+dsHealthOutput.Tables[0].Rows[i][j-2].ToString()+")"+
													dsHealthOutput.Tables[0].Rows[i][j].ToString());
											else
											{
												if ( j != 5 )
													m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
												else
													m_objRange.set_Item(1,1,Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[i][j]).ToString("yyyy-MM-dd"));
											}
										}
										else
										{
											if (j == 14)
											{
												m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,12],m_objSheet.Cells[i+4,12]);
												m_objRange.NumberFormatLocal = "@";
												m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
											}
											if (j == 17)
											{
												m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,13],m_objSheet.Cells[i+4,13]);
												m_objRange.NumberFormatLocal = "@";
												m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
											}
								
										}

										m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
										m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
									}
								}
								setJumpBoard(dsHealthOutput.Tables[0].Rows.Count,dsHealthOutput,dsHealthOutput.Tables[0].Rows.Count-1);
							}
						}
						else
						{
							int rowBeg = 4;
							for ( int i=0; i<dsHealthOutput.Tables[0].Rows.Count; i++ )
							{
								if ( !hasSheet(dsHealthOutput.Tables[0].Rows[i][1].ToString()) )
								{ 
									rowBeg = 4;
									m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
									m_objSheet.Name = dsHealthOutput.Tables[0].Rows[i][1].ToString();
									setTitle(printType1st);
									for ( int j=2; j<dsHealthOutput.Tables[0].Columns.Count; j++ )
									{
										if (j <= 12)
										{
											m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowBeg,j-1],m_objSheet.Cells[rowBeg,j-1]);
											//m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,j-1],m_objSheet.Cells[i+4,j-1]);
											m_objRange.NumberFormatLocal = "@";
											if ( j==2 )
												m_objRange.set_Item(1,1,"("+dsHealthOutput.Tables[0].Rows[i][j-2].ToString()+")"+
													dsHealthOutput.Tables[0].Rows[i][j].ToString());
											else
											{
												if ( j != 5 )
													m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
												else
													m_objRange.set_Item(1,1,Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[i][j]).ToString("yyyy-MM-dd"));
											}
										}
										else
										{
											if (j == 14)
											{
												m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowBeg,12],m_objSheet.Cells[rowBeg,12]);
												//m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,12],m_objSheet.Cells[i+4,12]);
												m_objRange.NumberFormatLocal = "@";
												m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
											}
											if (j == 17)
											{
												m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowBeg,13],m_objSheet.Cells[rowBeg,13]);
												//m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,13],m_objSheet.Cells[i+4,13]);
												m_objRange.NumberFormatLocal = "@";
												m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
											}
								
										}

										m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
										m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
									}
									rowBeg++;
								}	
								else
								{
									m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
									for ( int j=2; j<dsHealthOutput.Tables[0].Columns.Count; j++ )
									{
										if (j <= 12)
										{
											m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowBeg,j-1],m_objSheet.Cells[rowBeg,j-1]);
											//m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,j-1],m_objSheet.Cells[i+4,j-1]);
											m_objRange.NumberFormatLocal = "@";
											if ( j==2 )
												m_objRange.set_Item(1,1,"("+dsHealthOutput.Tables[0].Rows[i][j-2].ToString()+")"+
													dsHealthOutput.Tables[0].Rows[i][j].ToString());
											else
											{
												if ( j != 5 )
													m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
												else
													m_objRange.set_Item(1,1,Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[i][j]).ToString("yyyy-MM-dd"));
											}
										}
										else
										{
											if (j == 14)
											{
												m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowBeg,12],m_objSheet.Cells[rowBeg,12]);
												//m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,12],m_objSheet.Cells[i+4,12]);
												m_objRange.NumberFormatLocal = "@";
												m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
											}
											if (j == 17)
											{
												m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rowBeg,13],m_objSheet.Cells[rowBeg,13]);
												//m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,13],m_objSheet.Cells[i+4,13]);
												m_objRange.NumberFormatLocal = "@";
												m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
											}
								
										}

										m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
										m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
									}
									rowBeg++;
								}
								if ( i < dsHealthOutput.Tables[0].Rows.Count - 1 ) 
								{
									if ( !dsHealthOutput.Tables[0].Rows[i][1].ToString().Equals(dsHealthOutput.Tables[0].Rows[i+1][1].ToString()))
										setJumpBoard(rowBeg-4,dsHealthOutput,i);
								}
								else
									setJumpBoard(rowBeg-4,dsHealthOutput,i);
							}
						}
					}
				}
				else
				{
					m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
					m_objSheets.Add(m_objSheet,Type.Missing,1,Type.Missing);
					m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
					m_objSheet.Name = "未划分班级";
					setTitle(printType1st);
					for ( int i=0; i<dsHealthOutput.Tables[0].Rows.Count; i++ )
					{
						for ( int j=2; j<dsHealthOutput.Tables[0].Columns.Count; j++ )
						{
							if (j <= 12)
							{
								m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,j-1],m_objSheet.Cells[i+4,j-1]);
								m_objRange.NumberFormatLocal = "@";
								if ( j==2 )
									m_objRange.set_Item(1,1,"("+dsHealthOutput.Tables[0].Rows[i][j-1].ToString()+")"+
										dsHealthOutput.Tables[0].Rows[i][j].ToString());
								else
								{
									if ( j != 5 )
										m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
									else
										m_objRange.set_Item(1,1,Convert.ToDateTime(dsHealthOutput.Tables[0].Rows[i][j]).ToString("yyyy-MM-dd"));
								}
							}
							else
							{
								if (j == 14)
								{
									m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,12],m_objSheet.Cells[i+4,12]);
									m_objRange.NumberFormatLocal = "@";
									m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
								}
								if (j == 17)
								{
									m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+4,13],m_objSheet.Cells[i+4,13]);
									m_objRange.NumberFormatLocal = "@";
									m_objRange.set_Item(1,1,dsHealthOutput.Tables[0].Rows[i][j].ToString());
								}
								
							}

							m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
							m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
						}
					}
				}

				DataView dv = dsHealthOutput.Tables[0].DefaultView;
				dv.RowFilter = "HealthAnaly_isFat = 1";
				if (dv.Count > 0)
				{
					m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(m_objSheets.Count);
					m_objSheets.Add(Type.Missing, m_objSheet, 1, Type.Missing);
					m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(m_objSheets.Count);
					m_objSheet.Name = "肥胖儿情况汇总表";
					m_objRange = m_objSheet.get_Range("D1",m_objOpt);
					m_objRange.Value = "           肥胖儿情况汇总表";
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 11;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

					m_objRange = m_objSheet.get_Range("A3",m_objOpt);
					m_objRange.Value = "班级";
					m_objRange.Font.Bold = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.RowHeight = 21.75;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range("B3",m_objOpt);
					m_objRange.Value = "姓名";
					m_objRange.Font.Bold = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range("C3",m_objOpt);
					m_objRange.Value = "性别";
					m_objRange.Font.Bold = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.ColumnWidth = 5;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			
					m_objRange = m_objSheet.get_Range("D3",m_objOpt);
					m_objRange.Value = "出生日期";
					m_objRange.ColumnWidth = 12;
					m_objRange.Font.Bold = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			
					m_objRange = m_objSheet.get_Range("E3",m_objOpt);
					m_objRange.Value = "体检日期";
					m_objRange.ColumnWidth = 12;
					m_objRange.Font.Bold = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			
					m_objRange = m_objSheet.get_Range("F3",m_objOpt);
					m_objRange.Value = "年龄";
					m_objRange.Font.Bold = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			
					m_objRange = m_objSheet.get_Range("G3",m_objOpt);
					m_objRange.Value = "身高";
					m_objRange.Font.Bold = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
	
					m_objRange = m_objSheet.get_Range("H3",m_objOpt);
					m_objRange.Value = "评价";
					m_objRange.Font.Bold = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range("I3",m_objOpt);
					m_objRange.Value = "体重";
					m_objRange.Font.Bold = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range("J3",m_objOpt);
					m_objRange.Value = "评价";
					m_objRange.Font.Bold = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range("K3",m_objOpt);
					m_objRange.Value = "身高测体重评价";
					m_objRange.Font.Bold = true;
					m_objRange.ColumnWidth = 12;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range("L3",m_objOpt);
					m_objRange.Value = "WHO肥胖 X值";
					m_objRange.Font.Bold = true;
					m_objRange.ColumnWidth = 12;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range("M3",m_objOpt);
					m_objRange.Font.Bold = true;
					m_objRange.Value = "肥胖度";
					m_objRange.ColumnWidth = 13;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range("N3",m_objOpt);
					m_objRange.Font.Bold = true;
					m_objRange.Value = "超重10-19.9%";
					m_objRange.ColumnWidth = 13;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range("O3",m_objOpt);
					m_objRange.Font.Bold = true;
					m_objRange.Value = "轻度肥胖20-29.9%";
					m_objRange.ColumnWidth = 13;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range("P3",m_objOpt);
					m_objRange.Font.Bold = true;
					m_objRange.Value = "中度肥胖30-49.9%";
					m_objRange.ColumnWidth = 13;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

					m_objRange = m_objSheet.get_Range("Q3",m_objOpt);
					m_objRange.Font.Bold = true;
					m_objRange.Value = "重度肥胖﹥50%";
					m_objRange.ColumnWidth = 13;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

					object[,] objData = new Object[dv.Count,17];

					for ( int i=0; i<dv.Count; i++ )
					{
						objData[i,0] = dv[i][1].ToString();
						objData[i,1] = dv[i][2].ToString();
						objData[i,2] = dv[i][3].ToString();
						objData[i,3] = Convert.ToDateTime(dv[i][5]).ToString("yyyy-MM-dd");
						objData[i,4] = Convert.ToDateTime(dv[i][4]).ToString("yyyy-MM-dd");
						objData[i,5] = "'" + dv[i][6].ToString();
						objData[i,6] = dv[i][7].ToString();
						objData[i,7] = dv[i][8].ToString();
						objData[i,8] = dv[i][9].ToString();
						objData[i,9] = dv[i][10].ToString();
						objData[i,10] = dv[i][14].ToString();
						objData[i,11] = dv[i][17].ToString();
//						objData[i,10] = dv[i][17].ToString();
//						objData[i,11] = dv[i][14].ToString();
						objData[i,12] = dv[i][16].ToString();
						int fatLevel = Convert.ToInt32(dv[i][18]);
						switch (fatLevel)
						{
							case 1 :objData[i,13] = "√";
								break;
							case 2 :objData[i,14] = "√";
								break;
							case 3 :objData[i,15] = "√";
								break;
							case 4 :objData[i,16] = "√";
								break;
							default:
								break;
						}
						
					}

					m_objRange = m_objSheet.get_Range("A4",m_objOpt);
					m_objRange = m_objRange.get_Resize(dv.Count,17);
					m_objRange.NumberFormatLocal = "@";

					m_objRange.Value = objData;

					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objFont = m_objRange.Font;
					m_objFont.Size = 9;

					m_objRange = m_objSheet.get_Range("A" + (4 + dv.Count).ToString(), m_objOpt);
					m_objRange.Value = "总计";
					m_objRange = m_objSheet.get_Range("A" + (4 + dv.Count).ToString(), "M" + (4 + dv.Count).ToString());
					m_objRange.Merge(m_objOpt);
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objFont = m_objRange.Font;
					m_objFont.Size = 9;


					m_objRange = m_objSheet.get_Range("N" + (4 + dv.Count).ToString(), m_objOpt);
					m_objRange.Value = dsHealthOutput.Tables[0].Select("HealthAnaly_FatLevel=1").Length;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objFont = m_objRange.Font;
					m_objFont.Size = 9;

					m_objRange = m_objSheet.get_Range("O" + (4 + dv.Count).ToString(), m_objOpt);
					m_objRange.Value = dsHealthOutput.Tables[0].Select("HealthAnaly_FatLevel=2").Length;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objFont = m_objRange.Font;
					m_objFont.Size = 9;

					m_objRange = m_objSheet.get_Range("P" + (4 + dv.Count).ToString(), m_objOpt);
					m_objRange.Value = dsHealthOutput.Tables[0].Select("HealthAnaly_FatLevel=3").Length;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objFont = m_objRange.Font;
					m_objFont.Size = 9;

					m_objRange = m_objSheet.get_Range("Q" + (4 + dv.Count).ToString(), m_objOpt);
					m_objRange.Value = dsHealthOutput.Tables[0].Select("HealthAnaly_FatLevel=4").Length;
					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objFont = m_objRange.Font;
					m_objFont.Size = 9;
				}

				if ( printType2nd )
				{
					m_objSheet = (Excel._Worksheet)m_objSheets.get_Item("均值汇总");
					DataSet dsClass = new StuInfoDataAccess().GetClassList("","","");
					for ( int i=0; i<dsClass.Tables[0].Rows.Count; i++ )
					{
						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[i+7,1],m_objSheet.Cells[i+7,1]);
						m_objRange.Value = dsClass.Tables[0].Rows[i][1].ToString();
						m_objRange.RowHeight = 25;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
						m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					}

					m_objRange = m_objSheet.get_Range("B7","O"+(dsClass.Tables[0].Rows.Count+7).ToString());   //初始化单元格内容
					m_objRange.Value = "0";
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;

					m_objRange = m_objSheet.get_Range("A"+(dsClass.Tables[0].Rows.Count+7).ToString(),m_objOpt);
					m_objRange.Value = "合计";
					m_objRange.RowHeight = 25;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;

					int heightCalcTotal = 0;
					int weightCalcTotal = 0;
					for ( int row=0; row<dsClass.Tables[0].Rows.Count; row++ )
					{
						int perRowHeightTotal = 0;
						int perRowWeightTotal = 0;
						for ( int column=2; column<=17; column++ )
						{
							m_objRange = m_objSheet.get_Range(m_objSheet.Cells[6,column],m_objSheet.Cells[6,column]);
							string getValue = m_objRange.Value.ToString();
							if ( column < 10 )
							{
								DataSet dsHeightAnalyStat = new HealthManagementDataAccess().GetHeightAnalyStat(getBegDate,getEndDate,getValue,dsClass.Tables[0].Rows[row][1].ToString());
								if ( dsHeightAnalyStat.Tables[0].Rows.Count != 0 )
								{
									perRowHeightTotal += Convert.ToInt32(dsHeightAnalyStat.Tables[0].Rows[0][0]);
									m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+7,column],m_objSheet.Cells[row+7,column]);
									m_objRange.Value = dsHeightAnalyStat.Tables[0].Rows[0][0].ToString();
									m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
									m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
									m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
									m_objRange.Columns.Font.Size = 12;
								}
								if (column == 9)
								{
									m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+7,column],m_objSheet.Cells[row+7,column]);
									m_objRange.Value = perRowHeightTotal.ToString();
									m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
									m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
									m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
									m_objRange.Columns.Font.Size = 12;
								}
								if ( row+1 == dsClass.Tables[0].Rows.Count )
								{
									if (column < 9)
									{
										DataSet dsHeightTotal = new HealthManagementDataAccess().GetHeightAnalyTotal(getBegDate,getEndDate,getValue);
										if ( dsHeightTotal.Tables[0].Rows.Count != 0 )
										{
											heightCalcTotal += Convert.ToInt32(dsHeightTotal.Tables[0].Rows[0][0]);
											m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsClass.Tables[0].Rows.Count+7,column],
												m_objSheet.Cells[dsClass.Tables[0].Rows.Count+7,column]);
											m_objRange.Value = dsHeightTotal.Tables[0].Rows[0][0].ToString();
											m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
											m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
											m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
											m_objRange.Columns.Font.Size = 12;
										}
									}
									else
									{	
										m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsClass.Tables[0].Rows.Count+7,column],
											m_objSheet.Cells[dsClass.Tables[0].Rows.Count+7,column]);
										m_objRange.Value = heightCalcTotal.ToString();
										m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
										m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
										m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
										m_objRange.Columns.Font.Size = 12;
									}
								}
							}
							else 
							{
								DataSet dsWeightStat = new HealthManagementDataAccess().GetWeightAnalyStat(getBegDate,getEndDate,getValue,dsClass.Tables[0].Rows[row][1].ToString());
								if ( dsWeightStat.Tables[0].Rows.Count != 0 )
								{		
									perRowWeightTotal += Convert.ToInt32(dsWeightStat.Tables[0].Rows[0][0]);
									m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+7,column],m_objSheet.Cells[row+7,column]);
									m_objRange.Value = dsWeightStat.Tables[0].Rows[0][0].ToString();
									m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
									m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
									m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
									m_objRange.Columns.Font.Size = 12;
								}
								if (column == 17)
								{
									m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+7,column],m_objSheet.Cells[row+7,column]);
									m_objRange.Value = perRowWeightTotal.ToString();
									m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
									m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
									m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
									m_objRange.Columns.Font.Size = 12;
								}
								if ( row+1 == dsClass.Tables[0].Rows.Count )
								{
									if (column < 17)
									{
										DataSet dsWeightTotal = new HealthManagementDataAccess().GetWeightAnalyTotal(getBegDate,getEndDate,getValue);
										if ( dsWeightTotal.Tables[0].Rows.Count != 0 )
										{
											weightCalcTotal += Convert.ToInt32(dsWeightTotal.Tables[0].Rows[0][0]);
											m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsClass.Tables[0].Rows.Count+7,column],
												m_objSheet.Cells[dsClass.Tables[0].Rows.Count+7,column]);
											m_objRange.Value = dsWeightTotal.Tables[0].Rows[0][0].ToString();
											m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
											m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
											m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
											m_objRange.Columns.Font.Size = 12;
										}
									}
									else
									{
										m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsClass.Tables[0].Rows.Count+7,column],
											m_objSheet.Cells[dsClass.Tables[0].Rows.Count+7,column]);
										m_objRange.Value = weightCalcTotal.ToString();
										m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
										m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
										m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
										m_objRange.Columns.Font.Size = 12;
									}
								}
							}
						}
					}

					m_objRange = m_objSheet.get_Range("K"+(dsClass.Tables[0].Rows.Count+9).ToString(),m_objOpt);
					m_objRange.Value = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()+" "+
											DateTime.Now.ToString("yyyy.MM");
					m_objRange.Font.Bold = true;
					m_objRange.Font.Size = 16;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
				}

				if ( printType3rd )
				{	
					m_objSheet = (Excel._Worksheet)m_objSheets.get_Item("超均值汇总");

					DataSet dsGrade = new StuInfoDataAccess().GetGradeList("","");
					DataTable dtFatStat = this.GetFatStat(getBegDate, getEndDate);
					for ( int i=0; i<dsGrade.Tables[0].Rows.Count; i++ )
					{
						int fatNumber = 0;
						string fatDesc = string.Empty;
						switch ( i )
						{
							case 0:
							{
								DataView dvFatStat = dtFatStat.DefaultView;
								dvFatStat.RowFilter = string.Format("info_gradeName = '{0}'", dsGrade.Tables[0].Rows[i][1].ToString());
								if (dvFatStat.Count > 0)
								{
									fatNumber = Convert.ToInt32(dvFatStat[0][1]);
									fatDesc = string.Format("(肥胖{0})", fatNumber);
								}
								m_objRange = m_objSheet.get_Range("B5",m_objOpt);
								m_objRange.Value = dsGrade.Tables[0].Rows[i][1].ToString() + fatDesc;
								m_objRange = m_objSheet.get_Range("B8",m_objOpt);
								m_objRange.Value = getAll(Convert.ToInt32(dsGrade.Tables[0].Rows[i][0]),getBegDate,getEndDate).ToString();
								m_objRange = m_objSheet.get_Range("C8",m_objOpt);
								m_objRange.Value = (getHOPer(Convert.ToInt32(dsGrade.Tables[0].Rows[i][0]),getBegDate,getEndDate) - fatNumber).ToString();
								m_objRange = m_objSheet.get_Range("D8",m_objOpt);
								m_objRange.Value = ((getOverH-fatNumber)/getSum).ToString();                     //身高评测
								m_objRange = m_objSheet.get_Range("E8",m_objOpt);
								m_objRange.Value = getWOPer(Convert.ToInt32(dsGrade.Tables[0].Rows[i][0]),getBegDate,getEndDate).ToString();
								m_objRange = m_objSheet.get_Range("F8",m_objOpt);
								m_objRange.Value = (getOverW/getSum).ToString();
							}
								
							break;

							case 1: 
							{
								DataView dvFatStat = dtFatStat.DefaultView;
								dvFatStat.RowFilter = string.Format("info_gradeName = '{0}'", dsGrade.Tables[0].Rows[i][1].ToString());
								if (dvFatStat.Count > 0)
								{
									fatNumber = Convert.ToInt32(dvFatStat[0][1]);
									fatDesc = string.Format("(肥胖{0})", fatNumber);
								}

								m_objRange = m_objSheet.get_Range("G5",m_objOpt);
								m_objRange.Value = dsGrade.Tables[0].Rows[i][1].ToString() + fatDesc;
								m_objRange = m_objSheet.get_Range("G8",m_objOpt);
								m_objRange.Value = getAll(Convert.ToInt32(dsGrade.Tables[0].Rows[i][0]),getBegDate,getEndDate).ToString();
								m_objRange = m_objSheet.get_Range("H8",m_objOpt);
								m_objRange.Value = (getHOPer(Convert.ToInt32(dsGrade.Tables[0].Rows[i][0]),getBegDate,getEndDate) - fatNumber).ToString();
								m_objRange = m_objSheet.get_Range("I8",m_objOpt);
								m_objRange.Value = ((getOverH-fatNumber)/getSum).ToString();                     //身高评测
								m_objRange = m_objSheet.get_Range("J8",m_objOpt);
								m_objRange.Value = getWOPer(Convert.ToInt32(dsGrade.Tables[0].Rows[i][0]),getBegDate,getEndDate).ToString();
								m_objRange = m_objSheet.get_Range("K8",m_objOpt);
								m_objRange.Value = (getOverW/getSum).ToString();
							}
							break;

							case 2: 
							{
								DataView dvFatStat = dtFatStat.DefaultView;
								dvFatStat.RowFilter = string.Format("info_gradeName = '{0}'", dsGrade.Tables[0].Rows[i][1].ToString());
								if (dvFatStat.Count > 0)
								{
									fatNumber = Convert.ToInt32(dvFatStat[0][1]);
									fatDesc = string.Format("(肥胖{0})", fatNumber);
								}

								m_objRange = m_objSheet.get_Range("B11",m_objOpt);
								m_objRange.Value = dsGrade.Tables[0].Rows[i][1].ToString() + fatDesc;
								m_objRange = m_objSheet.get_Range("B17",m_objOpt);
								m_objRange.Value = getAll(Convert.ToInt32(dsGrade.Tables[0].Rows[i][0]),getBegDate,getEndDate).ToString();
								m_objRange = m_objSheet.get_Range("C17",m_objOpt);
								m_objRange.Value = (getHOPer(Convert.ToInt32(dsGrade.Tables[0].Rows[i][0]),getBegDate,getEndDate) - fatNumber).ToString();
								m_objRange = m_objSheet.get_Range("D17",m_objOpt);
								m_objRange.Value = ((getOverH - fatNumber)/getSum).ToString();                     //身高评测
								m_objRange = m_objSheet.get_Range("E17",m_objOpt);
								m_objRange.Value = getWOPer(Convert.ToInt32(dsGrade.Tables[0].Rows[i][0]),getBegDate,getEndDate).ToString();
								m_objRange = m_objSheet.get_Range("F17",m_objOpt);
								m_objRange.Value = (getOverW/getSum).ToString();
							}

							break;

							case 3: 
							{
								DataView dvFatStat = dtFatStat.DefaultView;
								dvFatStat.RowFilter = string.Format("info_gradeName = '{0}'", dsGrade.Tables[0].Rows[i][1].ToString());
								if (dvFatStat.Count > 0)
								{
									fatNumber = Convert.ToInt32(dvFatStat[0][1]);
									fatDesc = string.Format("(肥胖{0})", fatNumber);
								}

								m_objRange = m_objSheet.get_Range("G11",m_objOpt);
								m_objRange.Value = dsGrade.Tables[0].Rows[i][1].ToString() + fatDesc;
								m_objRange = m_objSheet.get_Range("G17",m_objOpt);
								m_objRange.Value = getAll(Convert.ToInt32(dsGrade.Tables[0].Rows[i][0]),getBegDate,getEndDate).ToString();
								m_objRange = m_objSheet.get_Range("H17",m_objOpt);
								m_objRange.Value = (getHOPer(Convert.ToInt32(dsGrade.Tables[0].Rows[i][0]),getBegDate,getEndDate) - fatNumber).ToString();
								m_objRange = m_objSheet.get_Range("I17",m_objOpt);
								m_objRange.Value = ((getOverH - fatNumber)/getSum).ToString();                     //身高评测
								m_objRange = m_objSheet.get_Range("J17",m_objOpt);
								m_objRange.Value = getWOPer(Convert.ToInt32(dsGrade.Tables[0].Rows[i][0]),getBegDate,getEndDate).ToString();
								m_objRange = m_objSheet.get_Range("K17",m_objOpt);
								m_objRange.Value = (getOverW/getSum).ToString();
							}
							break;

							case 4: 
							{
								DataView dvFatStat = dtFatStat.DefaultView;
								dvFatStat.RowFilter = string.Format("info_gradeName = '{0}'", dsGrade.Tables[0].Rows[i][1].ToString());
								if (dvFatStat.Count > 0)
								{
									fatNumber = Convert.ToInt32(dvFatStat[0][1]);
									fatDesc = string.Format("(肥胖{0})", fatNumber);
								}

								m_objRange = m_objSheet.get_Range("B20",m_objOpt);
								m_objRange.Value = dsGrade.Tables[0].Rows[i][1].ToString() + fatDesc;
								m_objRange = m_objSheet.get_Range("B26",m_objOpt);
								m_objRange.Value = getAll(Convert.ToInt32(dsGrade.Tables[0].Rows[i][0]),getBegDate,getEndDate).ToString();
								m_objRange = m_objSheet.get_Range("C26",m_objOpt);
								m_objRange.Value = (getHOPer(Convert.ToInt32(dsGrade.Tables[0].Rows[i][0]),getBegDate,getEndDate) - fatNumber).ToString();
								m_objRange = m_objSheet.get_Range("D26",m_objOpt);
								m_objRange.Value = ((getOverH - fatNumber)/getSum).ToString();                     //身高评测
								m_objRange = m_objSheet.get_Range("E26",m_objOpt);
								m_objRange.Value = getWOPer(Convert.ToInt32(dsGrade.Tables[0].Rows[i][0]),getBegDate,getEndDate).ToString();
								m_objRange = m_objSheet.get_Range("F26",m_objOpt);
								m_objRange.Value = (getOverW/getSum).ToString();
							}
							break;
						}	
					}

					DataSet dsWhoTotal = new HealthManagementDataAccess().GetWhoTotal(getBegDate,getEndDate);
					m_objRange = m_objSheet.get_Range("A8",m_objOpt);
					m_objRange.Value = dsWhoTotal.Tables[0].Rows[0][0].ToString();
				
					m_objRange = m_objSheet.get_Range("H28",m_objOpt);
					m_objRange.Value = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()+" "+DateTime.Now.ToString("yyyy.MM");

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


		//全日观察打印
		public void PrintAbnormalRecord(DataSet dsDailyWatch,string savePath)
		{
			try
			{
				m_objExcel = new Excel.Application(); 
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;				
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\ObserveReport.xls",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt); 
 
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;
				m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

				object[,] objData = null;
				if ( dsDailyWatch.Tables[0].Rows.Count > 0 )
				{
					objData = new Object[dsDailyWatch.Tables[0].Rows.Count,8];

					for ( int i=0; i<dsDailyWatch.Tables[0].Rows.Count; i++ )
					{
						objData[i,0] = dsDailyWatch.Tables[0].Rows[i]["observetime"].ToString();
						objData[i,1] = dsDailyWatch.Tables[0].Rows[i]["stu_name"].ToString();
						objData[i,2] = "体温"+dsDailyWatch.Tables[0].Rows[i]["morningReg_heat"].ToString()+","
							+"精神"+dsDailyWatch.Tables[0].Rows[i]["morningReg_spirit"].ToString()+","
							+"口腔"+dsDailyWatch.Tables[0].Rows[i]["morningReg_mouth"].ToString()+","
							+"皮肤"+dsDailyWatch.Tables[0].Rows[i]["morningReg_skin"].ToString();
						objData[i,3] = dsDailyWatch.Tables[0].Rows[i]["morningReg_genearchTold"].ToString();
						objData[i,4] = dsDailyWatch.Tables[0].Rows[i]["morningReg_treat"].ToString();
						objData[i,5] = "一日活动"+dsDailyWatch.Tables[0].Rows[i]["dailyReg_movement"].ToString()+","
							+"精神"+dsDailyWatch.Tables[0].Rows[i]["dailyReg_spirit"].ToString()+","
							+"食欲"+dsDailyWatch.Tables[0].Rows[i]["dailyReg_appetite"].ToString()+","
							+"睡眠"+dsDailyWatch.Tables[0].Rows[i]["dailyReg_sleep"].ToString()+","
							+"大小便"+dsDailyWatch.Tables[0].Rows[i]["dailyReg_stool"].ToString()+","
							+"咳嗽"+dsDailyWatch.Tables[0].Rows[i]["dailyReg_cough"].ToString()+","
							+"其他情况："+dsDailyWatch.Tables[0].Rows[i]["dailyReg_else"].ToString();
						if ( Convert.ToBoolean(dsDailyWatch.Tables[0].Rows[i]["dailyReg_ctrlMoveTreat"]) )
						{
							objData[i,6] += "控制运动量,";
						}
						if ( Convert.ToBoolean(dsDailyWatch.Tables[0].Rows[i]["dailyReg_tendTreat"]) )
						{
							objData[i,6] += "注意生活护理,";
						}
						if ( Convert.ToBoolean(dsDailyWatch.Tables[0].Rows[i]["dailyReg_seafoodTreat"]) )
						{
							objData[i,6] += "忌海鲜,";
						}
						if ( Convert.ToBoolean(dsDailyWatch.Tables[0].Rows[i]["dailyReg_measureHeat"]) )
						{
							objData[i,6] += "按时测体温.";
						}
						objData[i,7] = dsDailyWatch.Tables[0].Rows[i]["dailyReg_teacherSign"].ToString();
					}

					m_objRange = m_objSheet.get_Range("A5",m_objOpt);
					m_objRange = m_objRange.get_Resize(dsDailyWatch.Tables[0].Rows.Count,8);
					m_objRange.Value = objData;

					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objFont = m_objRange.Font;
					m_objFont.Size = 9;

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


		//服药记录打印
		public void PrintDoseInfo(DataSet dsDoseInfo,string savePath)
		{
			try
			{
				m_objExcel = new Excel.Application(); 
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;				
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\DiagnosisReport.xls",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt); 

				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;
				m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

				object[,] objData = null;
				
				if ( dsDoseInfo.Tables[0].Rows.Count > 0 )
				{
					objData = new Object[dsDoseInfo.Tables[0].Rows.Count,8];

					for ( int i=0; i<dsDoseInfo.Tables[0].Rows.Count; i++ )
					{
						objData[i,0] = dsDoseInfo.Tables[0].Rows[i][6].ToString();
						objData[i,1] = dsDoseInfo.Tables[0].Rows[i][7].ToString();
						objData[i,2] = dsDoseInfo.Tables[0].Rows[i][8].ToString();
						objData[i,3] = dsDoseInfo.Tables[0].Rows[i][9].ToString();
						objData[i,4] = dsDoseInfo.Tables[0].Rows[i][2].ToString();
						objData[i,5] = dsDoseInfo.Tables[0].Rows[i][3].ToString();
						objData[i,6] = dsDoseInfo.Tables[0].Rows[i][4].ToString()
										+"      "+dsDoseInfo.Tables[0].Rows[i][10].ToString();
						objData[i,7] = dsDoseInfo.Tables[0].Rows[i][5].ToString();
							
					}

					m_objRange = m_objSheet.get_Range("A3",m_objOpt);
					m_objRange = m_objRange.get_Resize(dsDoseInfo.Tables[0].Rows.Count,8);

					for ( int i=2,m=1; i<=m_objRange.Rows.Count; i++,m++ )
					{
						if(objData[m,1].ToString().Equals(objData[m-1,1].ToString())&&
							objData[m,6].ToString().Substring(0,10).Equals(objData[m-1,6].ToString().Substring(0,10)))
						{
							string startAMergeAddress = "A"+((int)(i-1)).ToString();
							string endAMergeAddress = "A"+i.ToString();

							m_objRange.get_Range(startAMergeAddress,endAMergeAddress).Merge(m_objOpt);

							string startBMergeAddress = "B"+((int)(i-1)).ToString();
							string endBMergeAddress = "B"+i.ToString();

							m_objRange.get_Range(startBMergeAddress,endBMergeAddress).Merge(m_objOpt);

							string startCMergeAddress = "C"+((int)(i-1)).ToString();
							string endCMergeAddress = "C"+i.ToString();

							m_objRange.get_Range(startCMergeAddress,endCMergeAddress).Merge(m_objOpt);

							string startDMergeAddress = "D"+((int)(i-1)).ToString();
							string endDMergeAddress = "D"+i.ToString();

							m_objRange.get_Range(startDMergeAddress,endDMergeAddress).Merge(m_objOpt);
						}
					}

					m_objRange.Value = objData;

					m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.WrapText = true;
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objFont = m_objRange.Font;
					m_objFont.Size = 9;
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


		private void SetNchsTitle(bool printType1st)
		{
			m_objRange = m_objSheet.get_Range("D1",m_objOpt);
			m_objRange.Value = "           体格发育评定记录";
			m_objRange.Font.Bold = true;
			m_objRange.Font.Size = 20;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

			m_objRange = m_objSheet.get_Range("A3",m_objOpt);
			m_objRange.Value = "姓名";
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 30;
			m_objRange.Font.Size = 10;
			if(!printType1st)
				m_objRange.ColumnWidth = 11.5;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
		
			m_objRange = m_objSheet.get_Range("B3",m_objOpt);
			m_objRange.Value = "性别";
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 30;
			m_objRange.Font.Size = 10;
			m_objRange.ColumnWidth = 4;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			
			m_objRange = m_objSheet.get_Range("C3",m_objOpt);
			m_objRange.Value = "体检日期";
			m_objRange.ColumnWidth = 9;
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 15;
			m_objRange.Font.Size = 10;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			
			m_objRange = m_objSheet.get_Range("D3",m_objOpt);
			m_objRange.Value = "出生年月";
			m_objRange.ColumnWidth = 9;
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 30;
			m_objRange.Font.Size = 10;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			
			m_objRange = m_objSheet.get_Range("E3",m_objOpt);
			m_objRange.Value = "实足年龄";
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.ColumnWidth = 7.15;
			m_objRange.RowHeight = 30;
			m_objRange.Font.Size = 10;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			
			m_objRange = m_objSheet.get_Range("F3",m_objOpt);
			m_objRange.Value = "身高";
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.ColumnWidth = 6.25;
			m_objRange.RowHeight = 30;
			m_objRange.Font.Size = 10;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
	
			m_objRange = m_objSheet.get_Range("G3",m_objOpt);
			m_objRange.Value = "评价";
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.ColumnWidth = 5;
			m_objRange.RowHeight = 30;
			m_objRange.Font.Size = 10;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range("H3",m_objOpt);
			m_objRange.Value = "体重";
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.ColumnWidth = 6.25;
			m_objRange.RowHeight = 30;
			m_objRange.Font.Size = 10;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range("I3",m_objOpt);
			m_objRange.Value = "评价";
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.ColumnWidth = 5;
			m_objRange.RowHeight = 30;
			m_objRange.Font.Size = 10;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range("J3",m_objOpt);
			m_objRange.Value = "肥胖";
			m_objRange.Font.Bold = true;
			m_objRange.ColumnWidth = 12;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.ColumnWidth = 9;
			m_objRange.RowHeight = 30;
			m_objRange.Font.Size = 10;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range("K3",m_objOpt);
			m_objRange.Font.Bold = true;
			m_objRange.Value = "营养";
			m_objRange.ColumnWidth = 13;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.ColumnWidth = 9;
			m_objRange.RowHeight = 30;
			m_objRange.Font.Size = 10;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range("L3",m_objOpt);
			m_objRange.Font.Bold = true;
			m_objRange.Value = "体重低下";
			m_objRange.ColumnWidth = 13;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.ColumnWidth = 10.5;
			m_objRange.RowHeight = 30;
			m_objRange.Font.Size = 10;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range("M3",m_objOpt);
			m_objRange.Font.Bold = true;
			m_objRange.Value = "生长迟缓";
			m_objRange.ColumnWidth = 13;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.ColumnWidth = 10.5;
			m_objRange.RowHeight = 30;
			m_objRange.Font.Size = 10;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range("N3",m_objOpt);
			m_objRange.Font.Bold = true;
			m_objRange.Value = "消瘦";
			m_objRange.ColumnWidth = 10.5;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 30;
			m_objRange.Font.Size = 10;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
		}

		private void setTitle(bool printType1st)
		{
			m_objRange = m_objSheet.get_Range("D1",m_objOpt);
			m_objRange.Value = "           生长发育评定记录";
			m_objRange.Font.Bold = true;
			m_objRange.Font.Size = 20;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

			m_objRange = m_objSheet.get_Range("A3",m_objOpt);
			m_objRange.Value = "姓名";
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 30;
			if(!printType1st)
				m_objRange.ColumnWidth = 15;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
		
			m_objRange = m_objSheet.get_Range("B3",m_objOpt);
			m_objRange.Value = "性别";
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 30;
			m_objRange.ColumnWidth = 5;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			
			m_objRange = m_objSheet.get_Range("C3",m_objOpt);
			m_objRange.Value = "体检日期";
			m_objRange.ColumnWidth = 12;
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 15;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			
			m_objRange = m_objSheet.get_Range("D3",m_objOpt);
			m_objRange.Value = "出生年月";
			m_objRange.ColumnWidth = 12;
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 30;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			
			m_objRange = m_objSheet.get_Range("E3",m_objOpt);
			m_objRange.Value = "实足年龄";
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 30;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			
			m_objRange = m_objSheet.get_Range("F3",m_objOpt);
			m_objRange.Value = "身高";
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 30;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
	
			m_objRange = m_objSheet.get_Range("G3",m_objOpt);
			m_objRange.Value = "评价";
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 30;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range("H3",m_objOpt);
			m_objRange.Value = "体重";
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 30;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range("I3",m_objOpt);
			m_objRange.Value = "评价";
			m_objRange.Font.Bold = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 30;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range("J3",m_objOpt);
			m_objRange.Value = "肥胖";
			m_objRange.Font.Bold = true;
			m_objRange.ColumnWidth = 12;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 30;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range("K3",m_objOpt);
			m_objRange.Font.Bold = true;
			m_objRange.Value = "营养";
			m_objRange.ColumnWidth = 13;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 30;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range("L3",m_objOpt);
			m_objRange.Font.Bold = true;
			m_objRange.Value = "身高测体重评价";
			m_objRange.ColumnWidth = 16;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 30;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

			m_objRange = m_objSheet.get_Range("M3",m_objOpt);
			m_objRange.Font.Bold = true;
			m_objRange.Value = "WHO肥胖 X值";
			m_objRange.ColumnWidth = 16;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.RowHeight = 30;
			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
		}

		private void setJumpBoard(int getRowCount,DataSet dsHealthOutput,int getClassNameIndex)
		{
			m_objRange = m_objSheet.get_Range("A"+(getRowCount+5).ToString(),m_objOpt);
			m_objRange.Value = "园所:      "+new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
			m_objRange.Font.Bold = true;
			m_objRange.Font.Size = 11;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

			m_objRange = m_objSheet.get_Range("A"+(getRowCount+6).ToString(),m_objOpt);
			m_objRange.Value = "班级:      "+dsHealthOutput.Tables[0].Rows[getClassNameIndex][1].ToString();
			m_objRange.Font.Bold = true;
			m_objRange.Font.Size = 11;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

			m_objRange = m_objSheet.get_Range("A"+(getRowCount+7).ToString(),m_objOpt);
			m_objRange.Value = "统计日期:  "+DateTime.Now.ToString("yyyy.MM");
			m_objRange.Font.Bold = true;
			m_objRange.Font.Size = 11;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

		}

		private bool hasSheet(string getSheetName)
		{
			findSheet = false;
			for ( int i=1; i<=m_objSheets.Count; i++ )
			{
				m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(i);
				if ( getSheetName.Equals(m_objSheet.Name.ToString()) )
				{
					findSheet = true;
					break;
				}
			}
			if ( !findSheet )
			{
				m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
				m_objSheets.Add(m_objSheet,Type.Missing,1,Type.Missing);
				return false;
			}
			else
				return true;
		}

		private double getHOPer(int getGrade,string getBegDate,string getEndDate)
		{
			try
			{
				getOverH = Convert.ToInt32(new HealthManagementDataAccess().GetHeightOver(getBegDate,getEndDate,getGrade).Tables[0].Rows[0][0]);
				return getOverH;
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				return 0;
			}
		}

		private double getWOPer(int getGrade,string getBegDate,string getEndDate)
		{
			try
			{
				getOverW = Convert.ToInt32(new HealthManagementDataAccess().GetWeightOver(getBegDate,getEndDate,getGrade).Tables[0].Rows[0][0]);
				return getOverW;
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				return 0;
			}
		}

		private double getAll(int getGrade,string getBegDate,string getEndDate)
		{
			try
			{
				getSum = Convert.ToInt32(new HealthManagementDataAccess().GetHealthAll(getBegDate,getEndDate,getGrade).Tables[0].Rows[0][0]);
				return getSum;
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				return 0;
			}
		}

		private DataTable GetFatStat(string beginDate, string endDate)
		{
			try
			{
				return new HealthManagementDataAccess().GetFatStat(beginDate, endDate).Tables[0];
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
				return null;
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
