using System;
using System.Data;
using CPTT.SystemFramework;
using CPTT.DataAccess;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// HealthManagementRules 的摘要说明。
	/// </summary>
	public class HealthManagementRules
	{
		private int getMonth;
		private string getShowAge = string.Empty;
		private string getHeightAnaly = string.Empty;
		private string getWeightAnaly = string.Empty;
		private string getHeightWeightAnaly = string.Empty;
		private string getWHO = string.Empty;
		private string getWHOPer = string.Empty;
		private string getX = string.Empty;
		private string getNut = string.Empty;
		private string getRtnMsg = string.Empty;
		private string getInnerMsg = string.Empty;
		private string getNchsHeight = string.Empty;
		private string getNchsWeight = string.Empty;
		private string getNchsObesity = string.Empty;
		private string getNchsUnderWeight = string.Empty;
		private string getNchsStunting = string.Empty;
		private string getNchsWasting = string.Empty;
		private HealthMgmt healthMgmt;
		public HealthManagementRules()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			healthMgmt = new HealthMgmt();
		}

		public void DoNchsHealthAnalysis(DateTime getDate,DateTime getBirth,string getHeight,string getWeight,bool getGender)
		{
			if ( !getHeight.ToString().Equals("") && !getWeight.ToString().Equals("") )
			{
				try
				{
					double varHeight = Convert.ToDouble(getHeight.Trim());
					double varWeight = Convert.ToDouble(getWeight.Trim());

					ElmClear();

					if ( !(getRtnMsg = SetAge(getDate,getBirth)).Equals("ok")) return;
				
					if ( !(getRtnMsg = SetNchsHeightElm(varHeight,getGender)).Equals("ok") ) return;

					if ( !(getRtnMsg = SetNchsWeightElm(varWeight,getGender)).Equals("ok") ) return;

					SetNchsObesityElm(varWeight,varHeight,getGender);

					SetNchsNutElm(varWeight,getGender);

					SetNchsUnderWeightElm(varWeight,getGender);

					SetNchsStuntingElm(varHeight,getGender);

					SetNchsWastingElm(varWeight,varHeight,getGender);

					getRtnMsg = "ok";
					
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					getRtnMsg =  "请先确定在条件处已经输入规范数值";
				}
			}
			else
				getRtnMsg =  "请先确定在条件处已经输入规范数值";
		}

		public void DoHealthAnalysis(DateTime getDate,DateTime getBirth,string getHeight,string getWeight,bool isCityStd,bool getGender)
		{
			if ( !getHeight.ToString().Equals("") && !getWeight.ToString().Equals("") )
			{
				try
				{
					double valHeight = Convert.ToDouble(getHeight.Trim());
					double valWeight = Convert.ToDouble(getWeight.Trim());
					ElmClear();
					while ( true )
					{
						getRtnMsg = SetAge(getDate,getBirth);
						if ( !getRtnMsg.Equals("ok") )
							break;

						getRtnMsg = SetHeightElm(valHeight,isCityStd,getGender);
						if ( !getRtnMsg.Equals("ok") )
							break;

						getRtnMsg = SetWeightElm(valWeight,isCityStd,getGender);
						if ( !getRtnMsg.Equals("ok") )
							break;

						SetHeightWeightElm(valHeight, valWeight, getGender);

						getRtnMsg = SetWHO(valHeight,valWeight,getGender);
						if ( !getRtnMsg.Equals("ok") )
							break;
						
						if ( !getRtnMsg.Equals("ok") )
							break;

						SetNut(valHeight,valWeight,getGender);
						getRtnMsg = GetInnerMsg();
						if ( !getRtnMsg.Equals("ok") )
							break;
						getRtnMsg = "ok";

						break;
					}
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					getRtnMsg =  "请先确定在条件处已经输入规范数值";
				}
			}
			else
				getRtnMsg =  "请先确定在条件处已经输入规范数值";
		}

		private string SetAge(DateTime getDate,DateTime getBirth)
		{
			int stuYear = Convert.ToInt32(getBirth.Date.ToString("yyyy"));
			int stuMonth = Convert.ToInt32(getBirth.Date.ToString("MM"));
			int stuDay = Convert.ToInt32(getBirth.Date.ToString("dd"));
			int curYear = Convert.ToInt32(getDate.Date.ToString("yyyy"));
			int curMonth = Convert.ToInt32(getDate.Date.ToString("MM"));
			int curDay = Convert.ToInt32(getDate.Date.ToString("dd"));

			if ( stuYear < curYear )
			{
				if ( stuMonth < curMonth )
				{
					if ( stuDay <= curDay )
					{
						getMonth = (curYear - stuYear) * 12 + (curMonth - stuMonth);
						SetShowAge("   " + (curYear - stuYear).ToString() + "." + (curMonth - stuMonth).ToString());
						return "ok";
					}
					else 
					{
						getMonth = (curYear - stuYear) * 12 + (curMonth - stuMonth - 1);
						SetShowAge("   " + (curYear - stuYear).ToString() + "." + (curMonth - stuMonth - 1).ToString());
						return "ok";
					}
				}
				else if ( stuMonth == curMonth )
				{
					if ( stuDay <= curDay )
					{
						getMonth = (curYear - stuYear) * 12 + (curMonth - stuMonth);
						SetShowAge("   " + (curYear - stuYear).ToString() + "." + (curMonth - stuMonth).ToString());
						return "ok";
					}
					else 
					{
						getMonth = (curYear - stuYear) * 12 + (curMonth - stuMonth -1 );
						SetShowAge("   " + (curYear - stuYear - 1).ToString() + "." + (curMonth - stuMonth + 11).ToString());
						return "ok";
					}
				}
				else
				{
					if ( stuDay <= curDay )
					{
						getMonth = (curYear - stuYear) * 12 + (curMonth - stuMonth);
						SetShowAge("   " + (curYear - stuYear - 1).ToString() + "." + (curMonth - stuMonth + 12).ToString());
						return "ok";
					}
					else
					{
						getMonth = (curYear - stuYear) * 12 + (curMonth - stuMonth - 1);
						SetShowAge("   " + (curYear - stuYear - 1).ToString() + "." + (curMonth - stuMonth + 11).ToString());
						return "ok";
					}
				}
			}
			else if ( stuYear == curYear )
			{
				if ( stuMonth < curMonth )
				{
					if ( stuDay <= curDay )
					{
						getMonth = curMonth - stuMonth;
						SetShowAge("   0." + (curMonth - stuMonth).ToString());
						return "ok";
					}
					else
					{
						getMonth = curMonth - stuMonth - 1;
						SetShowAge("   0." + (curMonth - stuMonth - 1).ToString());
						return "ok";
					}
				}
				else if ( stuMonth == curMonth )
				{
					if ( stuDay <= curDay )
					{
						getMonth = curMonth - stuMonth;
						SetShowAge("   0." + (curMonth - stuMonth).ToString());
						return "ok";
					}
					else
					{
						SetShowAge("-1");
						return string.Empty;
					}
				}
				else
				{
					SetShowAge("-1");
					return string.Empty;
				}
			}
			else
			{
				SetShowAge("-1");
				return string.Empty;
			}

		}

		private string SetNchsHeightElm(double getHeight,bool getGender)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					if ( Convert.ToDouble(GetShowAge().Trim()) < 7 )        //如果年龄大于7岁，不作判断
					{
						if ( Convert.ToDouble(GetShowAge().Trim()) >= 0 )
						{
							DataTable dtNchsAgeHeightCutOffPoint = healthManagementDataAccess.GetNchsAgeHeightCutOffPoint(getMonth,getGender);

							if ( dtNchsAgeHeightCutOffPoint != null )
							{
								if ( dtNchsAgeHeightCutOffPoint.Rows.Count > 0 )
								{
									if ( getHeight <= Convert.ToDouble(dtNchsAgeHeightCutOffPoint.Rows[0]["nchs_-2S.D"])) getNchsHeight = "下";
									else if ( getHeight > Convert.ToDouble(dtNchsAgeHeightCutOffPoint.Rows[0]["nchs_-2S.D"])
										&& getHeight <= Convert.ToDouble(dtNchsAgeHeightCutOffPoint.Rows[0]["nchs_-1S.D"]) ) getNchsHeight = "中下";
									else if ( getHeight > Convert.ToDouble(dtNchsAgeHeightCutOffPoint.Rows[0]["nchs_-1S.D"])
										&& getHeight < Convert.ToDouble(dtNchsAgeHeightCutOffPoint.Rows[0]["nchs_middle"]) ) getNchsHeight = "中-";
									else if ( getHeight == Convert.ToDouble(dtNchsAgeHeightCutOffPoint.Rows[0]["nchs_middle"]) ) getNchsHeight = "中";
									else if ( getHeight > Convert.ToDouble(dtNchsAgeHeightCutOffPoint.Rows[0]["nchs_middle"])
										&& getHeight < Convert.ToDouble(dtNchsAgeHeightCutOffPoint.Rows[0]["nchs_+1S.D"]) ) getNchsHeight = "中+";
									else if ( getHeight >= Convert.ToDouble(dtNchsAgeHeightCutOffPoint.Rows[0]["nchs_+1S.D"])
										&& getHeight < Convert.ToDouble(dtNchsAgeHeightCutOffPoint.Rows[0]["nchs_+2S.D"]) ) getNchsHeight = "中上";
									else getNchsHeight = "上";

									return "ok";
								}
								else 
								{
									ElmClear();
									return"身高不在评测范围内！";
								}

							}
							else
							{
								ElmClear();
								return "网络错误，请检查！";
							}
						}
						else
						{
							ElmClear();
							return "出生日不允许大于统计日期!";
						}
					}
					else
					{
						ElmClear();
						return "该幼儿年龄大于7岁已超出评测范围！";
					}
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return "系统出错，请检查网络或重启后重试！！";
				}
			}
		}

		private string SetHeightElm(double getHeight,bool isCityStd,bool getGender)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					if ( Convert.ToDouble(GetShowAge().Trim()) < 7 )        //如果年龄大于7岁，不作判断
					{
						if ( Convert.ToDouble(GetShowAge().Trim()) >= 0 )
						{
							if ( getHeight <= 135 && getHeight >= 46 )
							{
								DataSet dsHeightAnaly = healthManagementDataAccess.GetHeightAnaly(getMonth,getGender,isCityStd);

								if ( getHeight < Convert.ToDouble(dsHeightAnaly.Tables[0].Rows[0][1]) )
									getHeightAnaly = "   <p3";
								else if ( getHeight >= Convert.ToDouble(dsHeightAnaly.Tables[0].Rows[0][1]) && getHeight < Convert.ToDouble(dsHeightAnaly.Tables[0].Rows[0][2]) )
									getHeightAnaly = "  p3-10";
								else if ( getHeight >= Convert.ToDouble(dsHeightAnaly.Tables[0].Rows[0][2]) && getHeight < Convert.ToDouble(dsHeightAnaly.Tables[0].Rows[0][3]) )
									getHeightAnaly = "  p10-20";
								else if ( getHeight >= Convert.ToDouble(dsHeightAnaly.Tables[0].Rows[0][3]) && getHeight < Convert.ToDouble(dsHeightAnaly.Tables[0].Rows[0][4]) )
									getHeightAnaly = "  p20-50";
								else if ( getHeight >= Convert.ToDouble(dsHeightAnaly.Tables[0].Rows[0][4]) && getHeight < Convert.ToDouble(dsHeightAnaly.Tables[0].Rows[0][5]) )
									getHeightAnaly = "  p50-80";
								else if ( getHeight >= Convert.ToDouble(dsHeightAnaly.Tables[0].Rows[0][5]) && getHeight < Convert.ToDouble(dsHeightAnaly.Tables[0].Rows[0][6]) )
									getHeightAnaly = "  p80-97";
								else
									getHeightAnaly = "   >p97";

								return "ok";
							}
							else
							{
								ElmClear();
								return "该小朋友身高与实际年龄不符，请确认是否输入有误！";
							}
						}
						else
						{
							ElmClear();
							return "出生日不允许大于统计日期!";
						}
					}
					else
					{
						ElmClear();
						return "该幼儿年龄大于7岁已超出评测范围！";
					}
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return "系统出错，请检查网络或重启后重试！！";
				}
			}

		}

		private string SetNchsWeightElm(double getWeight,bool getGender)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					if ( Convert.ToDouble(GetShowAge().Trim()) < 7 )
					{
						if ( Convert.ToDouble(GetShowAge().Trim()) >= 0 )
						{
							DataTable dtNchsAgeWeightCutOffPoint = healthManagementDataAccess.GetNchsAgeWeightCutOffPoint(getMonth,getGender);

							if ( dtNchsAgeWeightCutOffPoint != null )
							{
								if ( dtNchsAgeWeightCutOffPoint.Rows.Count > 0 )
								{
									if ( getWeight <= Convert.ToDouble(dtNchsAgeWeightCutOffPoint.Rows[0]["nchs_-2S.D"])) getNchsWeight = "下";
									else if ( getWeight > Convert.ToDouble(dtNchsAgeWeightCutOffPoint.Rows[0]["nchs_-2S.D"])
										&& getWeight <= Convert.ToDouble(dtNchsAgeWeightCutOffPoint.Rows[0]["nchs_-1S.D"]) ) getNchsWeight = "中下";
									else if ( getWeight > Convert.ToDouble(dtNchsAgeWeightCutOffPoint.Rows[0]["nchs_-1S.D"])
										&& getWeight < Convert.ToDouble(dtNchsAgeWeightCutOffPoint.Rows[0]["nchs_middle"]) ) getNchsWeight = "中-";
									else if ( getWeight == Convert.ToDouble(dtNchsAgeWeightCutOffPoint.Rows[0]["nchs_middle"]) ) getNchsWeight = "中";
									else if ( getWeight > Convert.ToDouble(dtNchsAgeWeightCutOffPoint.Rows[0]["nchs_middle"])
										&& getWeight < Convert.ToDouble(dtNchsAgeWeightCutOffPoint.Rows[0]["nchs_+1S.D"]) ) getNchsWeight = "中+";
									else if ( getWeight >= Convert.ToDouble(dtNchsAgeWeightCutOffPoint.Rows[0]["nchs_+1S.D"])
										&& getWeight < Convert.ToDouble(dtNchsAgeWeightCutOffPoint.Rows[0]["nchs_+2S.D"]) ) getNchsWeight = "中上";
									else getNchsWeight = "上";

									return "ok";
								}
								else 
								{
									ElmClear();
									return "体重不在评测试范围！";
								}
							}
							else
							{
								ElmClear();
								return "网络错误，请检查！";
							}
						}
						else
						{
							ElmClear();
							return "出生日不允许大于统计日期!";
						}
					}
					else
					{
						ElmClear();
						return "该幼儿年龄大于7岁已超出评测范围！";
					}
				}
				catch(Exception ex)
				{
					ElmClear();
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return "系统出错，请检查网络或重启后重试！！";
				}
			}
		}

		private string SetWeightElm(double getWeight,bool isCityStd,bool getGender)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					if ( Convert.ToDouble(GetShowAge().Trim()) < 7 )
					{
						if ( Convert.ToDouble(GetShowAge().Trim()) >= 0 )
						{
							if ( getWeight <= 45 && getWeight >= 2.5 )
							{
								DataSet dsWeightAnaly = healthManagementDataAccess.GetWeightAnaly(getMonth,getGender,isCityStd);
								
								if ( getWeight < Convert.ToDouble(dsWeightAnaly.Tables[0].Rows[0][1]) )
									getWeightAnaly = "   <p3";
								else if ( getWeight >= Convert.ToDouble(dsWeightAnaly.Tables[0].Rows[0][1]) && getWeight < Convert.ToDouble(dsWeightAnaly.Tables[0].Rows[0][2]) )
									getWeightAnaly = "  p3-10";
								else if ( getWeight >= Convert.ToDouble(dsWeightAnaly.Tables[0].Rows[0][2]) && getWeight < Convert.ToDouble(dsWeightAnaly.Tables[0].Rows[0][3]) )
									getWeightAnaly = "  p10-20";
								else if ( getWeight >= Convert.ToDouble(dsWeightAnaly.Tables[0].Rows[0][3]) && getWeight < Convert.ToDouble(dsWeightAnaly.Tables[0].Rows[0][4]) )
									getWeightAnaly = "  p20-50";
								else if ( getWeight >= Convert.ToDouble(dsWeightAnaly.Tables[0].Rows[0][4]) && getWeight < Convert.ToDouble(dsWeightAnaly.Tables[0].Rows[0][5]) )
									getWeightAnaly = "  p50-80";
								else if ( getWeight >= Convert.ToDouble(dsWeightAnaly.Tables[0].Rows[0][5]) && getWeight < Convert.ToDouble(dsWeightAnaly.Tables[0].Rows[0][6]) )
									getWeightAnaly = "  p80-97";
								else
									getWeightAnaly = "   >p97";

								return "ok";
							}
							else
							{
								ElmClear();
								return "该小朋友体重与实际年龄不符，请确认是否输入有误！";
							}
						}
						else
						{
							ElmClear();
							return "出生日不允许大于统计日期!";
						}
					}
					else
					{
						ElmClear();
						return "该幼儿年龄大于7岁已超出评测范围！";
					}
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return "系统出错，请检查网络或重启后重试！！";
				}
			}
		}

		private void SetNchsObesityElm(double getWeight,double getHeight,bool getGender )
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					if ( Convert.ToDouble(GetShowAge().Trim()) < 7 )
					{
						if ( Convert.ToDouble(GetShowAge().Trim()) >= 0 )
						{
							if ( getHeight <= 135.5 && getHeight >= 70 )
							{
								DataTable dtNchsHeightWeightCutOffPoint = healthManagementDataAccess.GetNchsHeightWeightCutOffPoint(getHeight,getGender);

								if ( dtNchsHeightWeightCutOffPoint != null )
								{
									if ( dtNchsHeightWeightCutOffPoint.Rows.Count > 0 )
									{
										double perObesity = (getWeight - Convert.ToDouble(dtNchsHeightWeightCutOffPoint.Rows[0]["nchs_middle"]))/
											Convert.ToDouble(dtNchsHeightWeightCutOffPoint.Rows[0]["nchs_middle"]);

										if ( perObesity < 0.2 ) getNchsObesity = "正常";
										else if ( perObesity >= 0.2 && perObesity < 0.3 ) getNchsObesity = "轻度肥胖";
										else if ( perObesity >= 0.3 && perObesity < 0.5 ) getNchsObesity = "中度肥胖";
										else getNchsObesity = "重度肥胖";
									}
									else getNchsObesity = string.Empty;
								}
								else getNchsObesity = string.Empty;
							}
							else getNchsObesity = string.Empty;
						}
						else ElmClear();
					}
					else ElmClear();
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					SetInnerMsg("系统出错，请检查网络或重启后重试！！");
				}
			}
		}

//		private void SetWHO(double getHeight,double getWeight, bool getGender)
//		{
//			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
//			{
//				try
//				{
//					 if ( Convert.ToDouble(GetShowAge().Trim()) < 7 )
//					 {
//						if ( Convert.ToDouble(GetShowAge().Trim()) >= 0 )
//						{
//							if ( getHeight <= 135 )
//							{
//								DataSet dsWhoAnaly = healthManagementDataAccess.GetWhoAnaly(getHeight,getGender);
//								if ( dsWhoAnaly.Tables[0].Rows.Count > 0 )
//								{
//									for (int i=2; i<5; i++ )
//									{
//										if ( getWeight < Convert.ToDouble(dsWhoAnaly.Tables[0].Rows[0][2]))
//										{
//											getWHO = "  正常";
//											SetInnerMsg("ok");
//											break;
//										}
//										else if( getWeight >= Convert.ToDouble(dsWhoAnaly.Tables[0].Rows[0][i]) && getWeight < Convert.ToDouble(dsWhoAnaly.Tables[0].Rows[0][i+1]) )
//										{
//											switch(i)
//											{
//												case 2: getWHO = "  超重";
//													SetInnerMsg("ok");
//													break;
//
//												case 3: getWHO = " 轻度肥胖";
//													SetInnerMsg("ok");
//													break;
//
//												case 4: getWHO = " 中度肥胖";
//													SetInnerMsg("ok");
//													break;
//
//											}
//											break;
//										}
//										else
//										{
//											if ( getWeight >= Convert.ToDouble(dsWhoAnaly.Tables[0].Rows[0][5]) )
//											{
//												getWHO = "重度肥胖";
//												SetInnerMsg("ok");
//												break;
//											}
//										}
//									}
//								}
//							}
//							else
//							{
//								getWHO = "";
//								SetInnerMsg("身高不在肥胖儿评测范围内！");
//							}
//						}
//						else
//						{
//							ElmClear();
//							SetInnerMsg("出生日不允许大于统计日期!");
//						}
//					}
//					else
//					{
//						ElmClear();
//						SetInnerMsg("该幼儿年龄大于7岁已超出评测范围！");
//					}
//
//				}
//				catch(Exception e)
//				{
//					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
//					SetInnerMsg("系统出错，请检查网络或重启后重试！！");
//				}
//			}
//		}

		private void SetHeightWeightElm(double getHeight, double getWeight, bool getGender)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					if ( Convert.ToDouble(GetShowAge().Trim()) < 7 )
					{
						if ( Convert.ToDouble(GetShowAge().Trim()) >= 0 )
						{
							if (getHeight <= 135 && getHeight >= 48)
							{
								DataSet dsHeightWeightAnaly = healthManagementDataAccess.GetHeightWeightAnaly((int)getHeight,getGender);

								if ( getWeight < Convert.ToDouble(dsHeightWeightAnaly.Tables[0].Rows[0][1]) )
									getHeightWeightAnaly = "   <p3";
								else if ( getWeight >= Convert.ToDouble(dsHeightWeightAnaly.Tables[0].Rows[0][1]) && getWeight < Convert.ToDouble(dsHeightWeightAnaly.Tables[0].Rows[0][2]) )
									getHeightWeightAnaly = "  p3-10";
								else if ( getWeight >= Convert.ToDouble(dsHeightWeightAnaly.Tables[0].Rows[0][2]) && getWeight < Convert.ToDouble(dsHeightWeightAnaly.Tables[0].Rows[0][3]) )
									getHeightWeightAnaly = "  p10-20";
								else if ( getWeight >= Convert.ToDouble(dsHeightWeightAnaly.Tables[0].Rows[0][3]) && getWeight < Convert.ToDouble(dsHeightWeightAnaly.Tables[0].Rows[0][4]) )
									getHeightWeightAnaly = "  p20-50";
								else if ( getWeight >= Convert.ToDouble(dsHeightWeightAnaly.Tables[0].Rows[0][4]) && getWeight < Convert.ToDouble(dsHeightWeightAnaly.Tables[0].Rows[0][5]) )
									getHeightWeightAnaly = "  p50-80";
								else if ( getWeight >= Convert.ToDouble(dsHeightWeightAnaly.Tables[0].Rows[0][5]) && getWeight < Convert.ToDouble(dsHeightWeightAnaly.Tables[0].Rows[0][6]) )
									getHeightWeightAnaly = "  p80-97";
								else
									getHeightWeightAnaly = "   >p97";
							}
						}
					}

				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		private string SetWHO(double getHeight,double getWeight, bool getGender)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					if ( Convert.ToDouble(GetShowAge().Trim()) < 7 )
					{
						if ( Convert.ToDouble(GetShowAge().Trim()) >= 0 )
						{
							if (getHeight <= 135 && getHeight >= 78)
							{
								DataSet dsWhoAnaly = healthManagementDataAccess.GetWhoAnaly((int)getHeight,getGender);

								if ( getWeight < Convert.ToDouble(dsWhoAnaly.Tables[0].Rows[0][2]) )
									getWHO = "  正常";
								else if ( getWeight >= Convert.ToDouble(dsWhoAnaly.Tables[0].Rows[0][2]) && getWeight < Convert.ToDouble(dsWhoAnaly.Tables[0].Rows[0][3]) )
									getWHO = "  超重";
								else if ( getWeight >= Convert.ToDouble(dsWhoAnaly.Tables[0].Rows[0][3]) && getWeight < Convert.ToDouble(dsWhoAnaly.Tables[0].Rows[0][4]) )
									getWHO = " 轻度肥胖";
								else if ( getWeight >= Convert.ToDouble(dsWhoAnaly.Tables[0].Rows[0][4]) && getWeight < Convert.ToDouble(dsWhoAnaly.Tables[0].Rows[0][5]) )
									getWHO = " 中度肥胖";
								else
									getWHO = " 重度肥胖";

								getX = Convert.ToDouble(dsWhoAnaly.Tables[0].Rows[0][1]).ToString();

								if (getWHO.Trim() != "正常")
								{
									double whoPer = (double)(getWeight - Convert.ToDouble(dsWhoAnaly.Tables[0].Rows[0][1])) / Convert.ToDouble(dsWhoAnaly.Tables[0].Rows[0][1]) * 100;
									whoPer = Math.Round(whoPer, 2);
									getWHOPer = whoPer.ToString() + "%";
									//getX = Convert.ToDouble(dsWhoAnaly.Tables[0].Rows[0][1]).ToString();
								}

								return "ok";
							}
							else
							{
								getWHO = "";
								return "身高不在肥胖儿评测范围内！";
							}
						}
						else
						{
							ElmClear();
							return "出生日不允许大于统计日期!";
						}
					}
					else
					{
						ElmClear();
						return "该幼儿年龄大于7岁已超出评测范围！";
					}

				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return "系统出错，请检查网络或重启后重试！！";
				}
			}
		}

		private void SetNchsNutElm(double getWeight,bool getGender)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					if ( Convert.ToDouble(GetShowAge().Trim()) < 7 )
					{
						if ( Convert.ToDouble(GetShowAge().Trim()) >= 0 )
						{
							DataTable dtNchsAgeWeightCutOffPoint = healthManagementDataAccess.GetNchsAgeWeightCutOffPoint(getMonth,getGender);
							
							if ( dtNchsAgeWeightCutOffPoint != null )
							{
								if ( dtNchsAgeWeightCutOffPoint.Rows.Count > 0 )
								{
									double perNut = (getWeight - Convert.ToDouble(dtNchsAgeWeightCutOffPoint.Rows[0]["nchs_middle"]))/
										Convert.ToDouble(dtNchsAgeWeightCutOffPoint.Rows[0]["nchs_middle"]);

									if ( perNut <= -0.15 ) getNut = "营养不良";
									else getNut = "营养正常";					  
								}
								else getNut = string.Empty;
							}
							else getNut = string.Empty;
						}
						else ElmClear();
					}
					else ElmClear();
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		private void SetNut(double getHeight,double getWeight,bool getGender)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					if ( Convert.ToDouble(GetShowAge().Trim()) < 7 )
					{
						if ( Convert.ToDouble(GetShowAge().Trim()) >= 0 )
						{
							DataSet dsNutAnaly = healthManagementDataAccess.GetNutAnaly(getHeight,getGender);
							if ( dsNutAnaly.Tables[0].Rows.Count > 0 )
							{
								if ( GetWeightAnaly().Trim().Equals("p3-10"))
								{
									if ( getWeight < Convert.ToDouble(dsNutAnaly.Tables[0].Rows[0][1]) )
									{
										getNut = "轻度营养不良";
										SetInnerMsg("ok");
									}
									else
									{
										getNut = " 营养正常";
										SetInnerMsg("ok");
									}
								}

								else if ( GetWeightAnaly().Trim().Equals("<p3") )
								{
									if ( getWeight < Convert.ToDouble(dsNutAnaly.Tables[0].Rows[0][1]) )
									{
										getNut = "轻度营养不良";
										SetInnerMsg("ok");
									}
									if ( getWeight < Convert.ToDouble(dsNutAnaly.Tables[0].Rows[0][0]) )
									{
										getNut = "中度营养不良";
										SetInnerMsg("ok");
									}
				
								}
								else
								{
									getNut = "  营养正常";
									SetInnerMsg("ok");
								}
							}
						}
						else
						{
							ElmClear();
							SetInnerMsg("出生日不允许大于统计日期!");
						}
					}
					else
					{
						ElmClear();
						SetInnerMsg("该幼儿年龄大于7岁已超出评测范围！");

					}
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					SetInnerMsg("系统出错，请检查网络或重启后重试！！");
				}
			}
		}

		private void SetNchsUnderWeightElm(double getWeight,bool getGender)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					if ( Convert.ToDouble(GetShowAge().Trim()) < 7 )
					{
						if ( Convert.ToDouble(GetShowAge().Trim()) >= 0 )
						{
							DataTable dtNchsAgeWeightCutOffPoint = healthManagementDataAccess.GetNchsAgeWeightCutOffPoint(getMonth,getGender);

							if ( dtNchsAgeWeightCutOffPoint != null )
							{
								if ( dtNchsAgeWeightCutOffPoint.Rows.Count > 0 )
								{
									if ( getWeight >= Convert.ToDouble(dtNchsAgeWeightCutOffPoint.Rows[0]["nchs_-3S.D"]) &&
										getWeight < Convert.ToDouble(dtNchsAgeWeightCutOffPoint.Rows[0]["nchs_-2S.D"]) ) getNchsUnderWeight = "中度体重低下";
									else if ( getWeight < Convert.ToDouble(dtNchsAgeWeightCutOffPoint.Rows[0]["nchs_-3S.D"]) ) getNchsUnderWeight = "重度体重低下";
									else getNchsUnderWeight = "正常";
								}
								else getNchsUnderWeight = string.Empty;
							}
							else getNchsUnderWeight = string.Empty;
						}
						else ElmClear();
					}
					else ElmClear();
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		private void SetNchsStuntingElm(double getHeight,bool getGender)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					if ( Convert.ToDouble(GetShowAge().Trim()) < 7 )
					{
						if ( Convert.ToDouble(GetShowAge().Trim()) >= 0 )
						{
							DataTable dtNchsAgeHeightCutOffPoint = healthManagementDataAccess.GetNchsAgeHeightCutOffPoint(getMonth,getGender);
							
							if ( dtNchsAgeHeightCutOffPoint != null )
							{
								if ( dtNchsAgeHeightCutOffPoint.Rows.Count > 0 )
								{
									if ( getHeight >= Convert.ToDouble(dtNchsAgeHeightCutOffPoint.Rows[0]["nchs_-3S.D"]) &&
										getHeight < Convert.ToDouble(dtNchsAgeHeightCutOffPoint.Rows[0]["nchs_-2S.D"]) ) getNchsStunting = "中度生长迟缓";
									else if ( getHeight < Convert.ToDouble(dtNchsAgeHeightCutOffPoint.Rows[0]["nchs_-3S.D"])) getNchsStunting = "重度生长迟缓";
									else getNchsStunting = "正常";
								}
								else getNchsStunting = string.Empty;
							}
							else getNchsStunting = string.Empty;
						}
						else ElmClear();
					}
					else ElmClear();
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		private void SetNchsWastingElm(double getWeight,double getHeight,bool getGender)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					if ( Convert.ToDouble(GetShowAge().Trim()) < 7 )
					{
						if ( Convert.ToDouble(GetShowAge().Trim()) >= 0 )
						{
							DataTable dtNcshHeightWeightCutOffPoint = healthManagementDataAccess.GetNchsHeightWeightCutOffPoint(getHeight,getGender);

							if ( dtNcshHeightWeightCutOffPoint != null )
							{
								if ( dtNcshHeightWeightCutOffPoint.Rows.Count > 0 )
								{
									if ( getWeight >= Convert.ToDouble(dtNcshHeightWeightCutOffPoint.Rows[0]["nchs_-3S.D"]) &&
										getWeight < Convert.ToDouble(dtNcshHeightWeightCutOffPoint.Rows[0]["nchs_-2S.D"]) ) getNchsWasting = "中度消瘦";
									else if ( getWeight < Convert.ToDouble(dtNcshHeightWeightCutOffPoint.Rows[0]["nchs_-3S.D"]) ) getNchsWasting = "重度消瘦";
									else getNchsWasting = "正常";
								}
								else getNchsWasting = string.Empty;
							}
							else getNchsWasting = string.Empty;
						}
						else ElmClear();
					}
					else ElmClear();
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		private void SetShowAge(string getAge)
		{
			this.getShowAge = getAge;
		}

		public string GetShowAge()
		{
			return getShowAge;
		}

		public string GetHeightAnaly()
		{
			return getHeightAnaly;
		}

		public string GetHeightWeightAnaly()
		{
			return getHeightWeightAnaly;
		}

		public string GetNchsHeight()
		{
			return getNchsHeight;
		}

		public string GetWeightAnaly()
		{
			return getWeightAnaly;
		}

		public string GetNchsWeight()
		{
			return getNchsWeight;
		}

		public string GetWHO()
		{
			return getWHO;
		}

		public string GetWHOPer()
		{
			return getWHOPer;
		}

		public string GetX()
		{
			return getX;
		}

		public string GetNchsObesity()
		{
			return getNchsObesity;
		}

		public string GetNut()
		{
			return getNut;
		}

		public string GetNchsUnderWeight()
		{
			return getNchsUnderWeight;
		}

		public string GetNchsStunting()
		{
			return getNchsStunting;
		}

		public string GetNchsWasting()
		{
			return getNchsWasting;
		}

		private void SetRtnMsg(string getRtnMsg)
		{
			this.getRtnMsg = getRtnMsg;
		}

		public string GetRtnMsg()
		{
			return getRtnMsg;
		}

		private void SetInnerMsg(string getInnerMsg)
		{
			this.getInnerMsg = getInnerMsg;
		}

		private string GetInnerMsg()
		{
			return getInnerMsg;
		}

		private void ElmClear()
		{
			getShowAge = string.Empty;
			getHeightAnaly = string.Empty;
			getWeightAnaly = string.Empty;
			getWHO = string.Empty;
			getNut = string.Empty;
			getNchsHeight = string.Empty;
			getNchsWeight = string.Empty;
			getNchsObesity = string.Empty;
			getNchsUnderWeight = string.Empty;
			getNchsStunting = string.Empty;
			getNchsWasting = string.Empty;
		}
	}
}
