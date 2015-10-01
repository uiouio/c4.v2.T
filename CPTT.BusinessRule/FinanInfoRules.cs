using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// FinanInfoRules 的摘要说明。
	/// </summary>
	public class FinanInfoRules
	{
		private double getMessRestoreCharge;
		private double getAdmRestoreCharge;
		private double getModifyMessRestoreCharge;
		private double getModifyAdmRestoreCharge;
		public FinanInfoRules()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataSet GetContiAbsForMess(string getGrade,string getClass,
			string getName,string getNumber,DateTime balanceMonth,FinanInfo finanInfo)
		{
			using ( FinanInfoDataAccess finanInfoDataAccess = new FinanInfoDataAccess() )
			{
				try
				{
					DataSet dsFinanBuild = finanInfoDataAccess.SetFinanStuInfo(getGrade,getClass,getName,getNumber);
					DataSet dsAdmRestoreDays = finanInfoDataAccess.SetContiAbsForMess(true,getGrade,getClass,
						getName,getNumber,balanceMonth,finanInfo.GetMessRestoreDays);
					DataSet dsMessRestoreDays = finanInfoDataAccess.SetContiAbsForMess(false,getGrade,getClass,
						getName,getNumber,balanceMonth,finanInfo.GetMessRestoreDays);
					DataColumn needHandDaysColumn = new DataColumn("info_needHandDays");
					needHandDaysColumn.DataType = System.Type.GetType("System.Int32");
					dsFinanBuild.Tables[0].Columns.Add(needHandDaysColumn);
					DataColumn messStopDaysColumn = new DataColumn("info_messStopDays");
					messStopDaysColumn.DataType = System.Type.GetType("System.Int32");
					dsFinanBuild.Tables[0].Columns.Add(messStopDaysColumn);
					dsFinanBuild.Tables[0].Columns.AddRange(new DataColumn[]{
																				new DataColumn("info_admCharge"),new DataColumn("info_messCharge"),
																				new DataColumn("info_nightCharge"),new DataColumn("info_commCharge"),
																				new DataColumn("info_milkCharge"),new DataColumn("info_extraCharge"),
																				new DataColumn("info_admRestoreCharge"),new DataColumn("info_messRestoreCharge"),
																				new DataColumn("info_currency"),new DataColumn("info_remark")});
					for ( int finanRow = 0; finanRow < dsFinanBuild.Tables[0].Rows.Count; finanRow ++ )
					{
						//应交天数
						dsFinanBuild.Tables[0].Rows[finanRow][3] = GetWorkDays(balanceMonth);

						//停伙天数及退伙食费
						dsFinanBuild.Tables[0].Rows[finanRow][4] = 0;
						dsFinanBuild.Tables[0].Rows[finanRow][12] = "0.00￥";
						foreach(DataRow messRow in dsMessRestoreDays.Tables[0].Rows)
						{
							if ( dsFinanBuild.Tables[0].Rows[finanRow][0].ToString().Equals(messRow[0].ToString()) )
							{
								dsFinanBuild.Tables[0].Rows[finanRow][4] = messRow[1];
								dsFinanBuild.Tables[0].Rows[finanRow][12] = (finanInfo.GetMessCharge/GetWorkDays(balanceMonth)*
									Convert.ToDouble(messRow[1])).ToString("0.00")+"￥";
								getMessRestoreCharge = finanInfo.GetMessCharge/GetWorkDays(balanceMonth)*
									Convert.ToDouble(messRow[1]);
								break;
							}
							else
							{
								dsFinanBuild.Tables[0].Rows[finanRow][4] = 0;
								dsFinanBuild.Tables[0].Rows[finanRow][12] = "0.00￥";
								getMessRestoreCharge = 0;
							}
						}

						//管理费		
						dsFinanBuild.Tables[0].Rows[finanRow][5] = finanInfo.GetAdmCharge.ToString("0.00")+"￥";
						dsFinanBuild.Tables[0].Rows[finanRow][11] = "0.00￥";
						foreach(DataRow admRow in dsAdmRestoreDays.Tables[0].Rows)
						{
							if ( dsFinanBuild.Tables[0].Rows[finanRow][0].ToString().Equals(admRow[0].ToString()))
							{
								if ( Convert.ToInt32(admRow[1]) >= finanInfo.GetAdmRestoreDays )
								{
									dsFinanBuild.Tables[0].Rows[finanRow][11] = (finanInfo.GetAdmCharge/2).ToString("0.00")+"￥";
									getAdmRestoreCharge = finanInfo.GetAdmCharge/2;
									break;
								}
								else
								{
									dsFinanBuild.Tables[0].Rows[finanRow][11] = "0.00￥";
									getAdmRestoreCharge = 0;
								}
							}
//							else
//							{
//								dsFinanBuild.Tables[0].Rows[finanRow][5] = finanInfo.GetAdmCharge.ToString("0.00")+"￥";
//								dsFinanBuild.Tables[0].Rows[finanRow][11] = "0.00￥";
//								getAdmRestoreCharge = 0;
//							}
						}

						//伙食费
						dsFinanBuild.Tables[0].Rows[finanRow][6] = finanInfo.GetMessCharge.ToString("0.00")+"￥";
 
						//晚托费
						dsFinanBuild.Tables[0].Rows[finanRow][7] = finanInfo.GetNightCharge.ToString("0.00")+"￥";

						//代办费
						dsFinanBuild.Tables[0].Rows[finanRow][8] = finanInfo.GetCommCharge.ToString("0.00")+"￥";
						
						//牛奶费
						dsFinanBuild.Tables[0].Rows[finanRow][9] = finanInfo.GetMilkCharge.ToString("0.00")+"￥";

						//附加费
						dsFinanBuild.Tables[0].Rows[finanRow][10] = finanInfo.GetExtraCharge.ToString("0.00")+"￥";

						//实收金额
						dsFinanBuild.Tables[0].Rows[finanRow][13] = (finanInfo.GetMessCharge + finanInfo.GetAdmCharge +
							finanInfo.GetNightCharge + finanInfo.GetMilkCharge + finanInfo.GetCommCharge +finanInfo.GetExtraCharge - 
							getMessRestoreCharge - getAdmRestoreCharge).ToString("0.00")+"￥";

						//备注
						dsFinanBuild.Tables[0].Rows[finanRow][14] = finanInfo.GetRemark;
					}
					
					return dsFinanBuild;
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet ModifyFinanInfo(FinanInfo finanInfo,DataSet getDS,string getNumber,DateTime balanceMonth)
		{
			using ( FinanInfoDataAccess finanInfoDataAccess = new FinanInfoDataAccess() )
			{
				try
				{
					DataSet dsModifyMessInfo = finanInfoDataAccess.SetContiAbsForMess(false,"","","",getNumber,
						balanceMonth,finanInfo.GetMessRestoreDays);
					DataSet dsModifyAdmInfo = finanInfoDataAccess.SetContiAbsForMess(true,"","","",getNumber,
						balanceMonth,finanInfo.GetMessRestoreDays);
					foreach(DataRow modifyRow in getDS.Tables[0].Rows)
					{
						if ( modifyRow[0].ToString().Equals(getNumber) )
						{
							modifyRow[4] = 0;
							modifyRow[12] = "0.00￥";
							if ( dsModifyMessInfo.Tables[0].Rows.Count != 0)
							{
								modifyRow[4] = dsModifyAdmInfo.Tables[0].Rows[0][1];
								modifyRow[12] = (finanInfo.GetMessCharge/GetWorkDays(balanceMonth)*
									Convert.ToDouble(dsModifyAdmInfo.Tables[0].Rows[0][1])).ToString("0.00")+"￥";
								getModifyMessRestoreCharge = finanInfo.GetMessCharge/GetWorkDays(balanceMonth)*
									Convert.ToDouble(dsModifyAdmInfo.Tables[0].Rows[0][1]);
							}
							modifyRow[5] = finanInfo.GetAdmCharge.ToString("0.00")+"￥";
							modifyRow[11] = "0.00￥";
							if ( dsModifyAdmInfo.Tables[0].Rows.Count !=0 )
							{
								if ( Convert.ToInt32(dsModifyAdmInfo.Tables[0].Rows[0][1]) >= finanInfo.GetAdmRestoreDays )
								{
									modifyRow[11] = (finanInfo.GetAdmCharge/2).ToString("0.00")+"￥";
									getModifyAdmRestoreCharge = finanInfo.GetAdmCharge/2;
								}
							}
							modifyRow[6] = finanInfo.GetMessCharge.ToString("0.00")+"￥";
							modifyRow[7] = finanInfo.GetNightCharge.ToString("0.00")+"￥";
							modifyRow[8] = finanInfo.GetCommCharge.ToString("0.00")+"￥";
							modifyRow[9] = finanInfo.GetMilkCharge.ToString("0.00")+"￥";
							modifyRow[10] = finanInfo.GetExtraCharge.ToString("0.00")+"￥";
							modifyRow[13] = (finanInfo.GetMessCharge + finanInfo.GetAdmCharge +
								finanInfo.GetNightCharge + finanInfo.GetMilkCharge + finanInfo.GetCommCharge +finanInfo.GetExtraCharge - 
								getModifyMessRestoreCharge - getModifyAdmRestoreCharge).ToString("0.00")+"￥";
							modifyRow[14] = finanInfo.GetRemark;
						}
					}
					return getDS;
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public void DoInsertFinanInfo(DataSet dsFinanInfo,DateTime getDate,int getMessRestoreDays,int getAdmRestoreDays)
		{
			using ( FinanInfoDataAccess finanInfoDataAccess = new FinanInfoDataAccess() )
			{
				try
				{
					foreach(DataRow finanInfoRow in dsFinanInfo.Tables[0].Rows)
					{
						finanInfoDataAccess.InsertFinanInfo(finanInfoRow,getDate,getMessRestoreDays,getAdmRestoreDays);
					}
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		public void DoDeleteFinanInfo(DateTime getDate)
		{
			using ( FinanInfoDataAccess finanInfoDataAccess = new FinanInfoDataAccess() )
			{
				try
				{
					finanInfoDataAccess.DeleteFinanInfo(getDate);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		private int GetDaysInMonth(DateTime getDate)
		{
			int rtnDay = 1;
			if ( getDate.Year % 4 != 0 )
			{
				switch ( getDate.Month )
				{
					case 1: rtnDay = 31;
						break;
					case 2: rtnDay = 28;
						break;
					case 3: rtnDay = 31;
						break;
					case 4: rtnDay = 30;
						break;
					case 5: rtnDay = 31;
						break;
					case 6: rtnDay = 30;
						break;
					case 7: rtnDay = 31;
						break;
					case 8: rtnDay = 31;
						break;
					case 9: rtnDay = 30;
						break;
					case 10: rtnDay = 31;
						break;
					case 11: rtnDay = 30;
						break;
					case 12: rtnDay = 31;
						break;
				}
				return rtnDay;
			}
			else
			{
				switch ( getDate.Month )
				{
					case 1: rtnDay = 31;
						break;
					case 2: rtnDay = 29;
						break;
					case 3: rtnDay = 31;
						break;
					case 4: rtnDay = 30;
						break;
					case 5: rtnDay = 31;
						break;
					case 6: rtnDay = 30;
						break;
					case 7: rtnDay = 31;
						break;
					case 8: rtnDay = 31;
						break;
					case 9: rtnDay = 30;
						break;
					case 10: rtnDay = 31;
						break;
					case 11: rtnDay = 30;	
						break;
					case 12: rtnDay = 31;
						break;
				}
				return rtnDay;
			}
		}

		private int GetWorkDays(DateTime getDate)
		{
			DateTime initBegDate = new DateTime(getDate.Year,getDate.Month,1);
			//休息日
			int restingDays = 0;

			//当月日数
			int dayNumbers = GetDaysInMonth(getDate);

			for(int i=0;i<dayNumbers;i++)
			{
				//五一和十一
				if (initBegDate.AddDays(i).Month == 10)
				{
		
					if ( initBegDate.AddDays(i).Day <= 3)
						restingDays ++;
				}

				//元旦
				if ((initBegDate.AddDays(i).Month == 1 || initBegDate.AddDays(i).Month == 5) && initBegDate.AddDays(i).Day == 1)
					restingDays ++;

				//双修日
				if ( initBegDate.AddDays(i).DayOfWeek.ToString().Equals("Saturday") || 
					initBegDate.AddDays(i).DayOfWeek.ToString().Equals("Sunday") )
				{
					restingDays ++;
				}
			}

			return (dayNumbers - restingDays);
		}


		private DataTable BuildingFinanceStat(DataTable filterTemplateContents)
		{
			DataTable dtBuilded = new DataTable();
			dtBuilded.Columns.AddRange(new DataColumn[]{new DataColumn("学号", Type.GetType("System.Int32")),
				new DataColumn("姓名", Type.GetType("System.String")), new DataColumn("班级", Type.GetType("System.String"))});
			if (filterTemplateContents != null && filterTemplateContents.Rows.Count > 0)
			{
				foreach (DataRow dr in filterTemplateContents.Rows)
				{
					dtBuilded.Columns.Add(dr["name"].ToString(), Type.GetType("System.String"));
				}

				return dtBuilded;
			}
			else
			{
				return null;
			}
		}

		public DataTable FilterTemplateContents(string templateName, string grade, string className)
		{
			DataTable dtTemplateContents = new FinanInfoDataAccess().GetTemplateContents(templateName);
			if (dtTemplateContents != null && dtTemplateContents.Rows.Count > 0)
			{
				DataTable dtReBuilding = dtTemplateContents.Clone();

				foreach (DataRow dr in dtTemplateContents.Rows)
				{
					string name = dr["name"].ToString();
					DataRow newRow = dtReBuilding.NewRow();
					DataRow[] temp1 = dtTemplateContents.Select(string.Format("name='{0}'", name), "order asc");
					if (temp1.Length > 1)
					{
						if (dtReBuilding.Select(string.Format("name='{0}'", name)).Length == 0)
						{
							DataRow[] temp2 = dtTemplateContents.Select(string.Format("name='{0}' AND grade='{1}' AND (class = " +
								"'{2}' OR class = '不选择')", name, grade, className), "order asc");
							if (temp2.Length == 1)
							{
								newRow.ItemArray = temp2[0].ItemArray;
								dtReBuilding.Rows.Add(newRow);
							}
							else
							{
								DataRow[] temp3 = dtTemplateContents.Select(string.Format("name='{0}' AND grade='不选择'", name), "order asc");
								if (temp3.Length == 1)
								{
									newRow.ItemArray = temp3[0].ItemArray;
									dtReBuilding.Rows.Add(newRow);
								}
								else
								{
									newRow.ItemArray = dr.ItemArray;
									dtReBuilding.Rows.Add(newRow);
								}
							}
						}
					}
					else
					{
						newRow.ItemArray = dr.ItemArray;
						dtReBuilding.Rows.Add(newRow);
					}
				}

				return dtReBuilding;
			}
			else
			{
				return null;
			}
		}

		public DataTable MakingFinanceStat(string templateName, string grade, string className, DateTime date,
			out ArrayList list)
		{
			list = new ArrayList();
			try
			{
				using (DataTable dtStudentPresents = new FinanInfoDataAccess().GetStudentPresents(date, className))
				{
					if (dtStudentPresents != null && dtStudentPresents.Rows.Count > 0)
					{
						DataTable dtFilterTemplateContents = FilterTemplateContents(templateName, grade, className);
						DataTable dtBuilded = BuildingFinanceStat(dtFilterTemplateContents);

						foreach (DataRow dr in dtStudentPresents.Rows)
						{
							DataRow newRow = dtBuilded.NewRow();
							int index = 3;
							foreach(DataRow drContents in dtFilterTemplateContents.Rows)
							{
								TemplateContentsRecordSet contents = new TemplateContentsRecordSet(drContents["name"].ToString(),
									drContents["fullDays"].ToString(), drContents["fullDaysSpend"].ToString(),
									drContents["halfDaysSpend"].ToString(), drContents["perDaySpend"].ToString(),
									drContents["noSpendMonth"].ToString(), drContents["halfSpendMonth"].ToString(), 
									drContents["grade"].ToString(), drContents["class"].ToString());

								newRow[0] = dr["学号"];
								newRow[1] = dr["姓名"];
								newRow[2] = dr["班级"];

								if (contents.Grade == "不选择" ||
									Regex.Match(contents.Grade + contents.ClassName, string.Format("^{2}{0}|{2}{1}$", className, "不选择", grade)).Success)
								{
									if (!contents.FullDays.Equals("-"))
									{
										if (!contents.FullDaysSpend.Equals("-"))
										{
											int fullDays = Convert.ToInt32(contents.FullDays);
											int presentDays = Convert.ToInt32(dr["times"]);
											if (presentDays >= fullDays)
											{
												newRow[index] = contents.FullDaysSpend;
											}
											else
											{
												if (!contents.HalfDaysSpend.Equals("-"))
												{
													newRow[index] = contents.HalfDaysSpend;
												}
												else
												{
													if (!contents.PerDaySpend.Equals("-"))
													{
														double perDaySpend = Convert.ToDouble(contents.PerDaySpend);
														newRow[index] = Convert.ToInt32(dr["times"]) * perDaySpend;
													}
													else
													{
														newRow[index] = 0;
													}										
												}
											}
										}
										else
										{
											if (!contents.PerDaySpend.Equals("-"))
											{
												double perDaySpend = Convert.ToDouble(contents.PerDaySpend);
												newRow[index] = Convert.ToInt32(dr["times"]) * perDaySpend;
											}
											else
											{
												newRow[index] = 0;
											}
										}
									}
									else
									{
										if (!contents.PerDaySpend.Equals("-"))
										{
											double perDaySpend = Convert.ToDouble(contents.PerDaySpend);
											newRow[index] = Convert.ToInt32(dr["times"]) * perDaySpend;
										}
										else
										{
											newRow[index] = 0;
										}
									}

									if (!contents.NoSpendMonth.Equals("-"))
									{
										string month = date.Month.ToString();
										string pattern = string.Format(@"^{0}$", contents.NoSpendMonth.Replace(",", "|"));
										if (Convert.ToInt32(dr["times"]) == 0)
										{
											newRow[index] = Regex.Match(month, pattern).Success ? 0 : newRow[index];
										}
									}

									if (!contents.HalfSpendMonth.Equals("-"))
									{
										string month = date.Month.ToString();
										string pattern = string.Format(@"^{0}$", contents.HalfSpendMonth.Replace(",", "|"));
										newRow[index] = Regex.Match(month, pattern).Success ? 
											Convert.ToDouble(newRow[index]) / 2 : newRow[index];
									}
								}
								else
								{
									if (!list.Contains(contents.ColumnName))
									{
										list.Add(contents.ColumnName);
									}

									newRow[index] = 0;
								}

								index++;
							}

							dtBuilded.Rows.Add(newRow);
						}

						return dtBuilded;
					}
					else
					{
						return null;
					}
				}
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
				return null;
			}
		}

		private struct TemplateContentsRecordSet
		{
			private string _columnName;
			private string _fullDays;
			private string _fullDaysSpend;
			private string _halfDaysSpend;
			private string _perDaySpend;
			private string _noSpendMonth;
			private string _halfSpendMonth;
			private string _grade;
			private string _className;

			public TemplateContentsRecordSet(string columnName, string fullDays, string fullDaysSpend, string halfDaysSpend,
				string perDaySpend, string noSpendMonth, string halfSpendMonth, string grade, string className)
			{
				_columnName = columnName;
				_fullDays = fullDays;
				_fullDaysSpend = fullDaysSpend;
				_halfDaysSpend = halfDaysSpend;
				_perDaySpend = perDaySpend;
				_noSpendMonth = noSpendMonth;
				_halfSpendMonth = halfSpendMonth;
				_grade = grade;
				_className = className;
			}

			public string ColumnName
			{
				get
				{
					return _columnName;
				}
				set
				{
					_columnName = value;
				}
			}

			public string FullDays
			{
				get
				{
					return _fullDays;
				}
				set
				{
					_fullDays = value;
				}
			}

			public string FullDaysSpend
			{
				get
				{
					return _fullDaysSpend;
				}
				set
				{
					_fullDaysSpend = value;
				}
			}

			public string HalfDaysSpend
			{
				get
				{
					return _halfDaysSpend;
				}
				set
				{
					_halfDaysSpend = value;
				}
			}

			public string PerDaySpend
			{
				get
				{
					return _perDaySpend;
				}
				set
				{
					_perDaySpend = value;
				}
			}

			public string NoSpendMonth
			{
				get
				{
					return _noSpendMonth;
				}
				set
				{
					_noSpendMonth = value;
				}
			}

			public string HalfSpendMonth
			{
				get
				{
					return _halfSpendMonth;
				}
				set
				{
					_halfSpendMonth = value;
				}
			}

			public string Grade
			{
				get
				{
					return _grade;
				}
				set
				{
					_grade = value;
				}
			}

			public string ClassName
			{
				get
				{
					return _className;
				}
				set
				{
					_className = value;
				}
			}
		}
	}
}
