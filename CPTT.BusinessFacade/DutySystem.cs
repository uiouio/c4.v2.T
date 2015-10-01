using System;
using System.Data;
using CPTT.DataAccess;
using CPTT.BusinessRule;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// DutySystem 的摘要说明。
	/// </summary>
	public class DutySystem
	{
		public DutySystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataSet GetDutyInfoList()
		{
			DataSet dutyInfoList = null;

			using(DutyInfoDA dutyInfoDA = new DutyInfoDA())
			{
				dutyInfoList = dutyInfoDA.GetDutyInfoList();
			}

			return dutyInfoList;
		}

		public DataSet GetAllTeaDutyInfo()
		{
			DataSet allTeaDutyInfo = null;

			using(DutyInfoDA dutyInfoDA = new DutyInfoDA())
			{
				allTeaDutyInfo = dutyInfoDA.GetAllTeaDutyInfo();
			}

			return allTeaDutyInfo;
		}

		public DataSet GetTeaDutyDetails(string startTime,string endTime,string getDept,string getDuty,string getName,string getNumber)
		{
			DataSet allTeaDutyInfo = null;

			using(DutyInfoDA dutyInfoDA = new DutyInfoDA())
			{
				allTeaDutyInfo = dutyInfoDA.GetTeaDutyDetails(startTime,endTime,getDept,getDuty,getName,getNumber);
			}

			return allTeaDutyInfo;
		}

		public DataSet GetTeaDutyNormail(string getDept,string getDuty,string getName,string getNumber,DateTime getBegDate,DateTime getEndDate, int state)
		{
			DataSet teaDutyNormal = null;

			using ( DutyInfoDA dutyInfoDA = new DutyInfoDA() )
			{
				teaDutyNormal = dutyInfoDA.GetTeaDutyNormal(getDept,getDuty,getName,getNumber,getBegDate,getEndDate, state);
			}

			return teaDutyNormal;
		}

		public DataSet GetTeaOutDetails(DateTime startTime,DateTime endTime,string getDept,string getDuty,string getName,string getNumber)
		{
			DataSet allTeaOutInfo = null;

			using(DutyInfoDA dutyInfoDA = new DutyInfoDA())
			{
				allTeaOutInfo = dutyInfoDA.GetTeaOutDetails(startTime,endTime,getDept,getDuty,getName,getNumber);
			}

			return allTeaOutInfo;
		}

		public void UpdateTeaOndutyRemarks(int teaOndutyID,string remarks)
		{
			using(DutyInfoDA dutyInfoDA = new DutyInfoDA())
			{
				dutyInfoDA.UpdateTeaOndutyRemarks(teaOndutyID,remarks);
			}
		}

		public int UpdateDutyInfoList(DataSet dutyInfoList)
		{
			int rowsAffected = 0;

			using(DutyInfoDA dutyInfoDA = new DutyInfoDA())
			{
				rowsAffected = dutyInfoDA.UpdateDutyInfo(dutyInfoList);
			}

			return rowsAffected;
		}

		public void ExportTeacherAllReports(string path, DateTime startDate, DateTime endDate)
		{
			new TeaDutyRule().ExportTeacherAllReports(path, startDate, endDate);
		}

//		public float[] TeaDutyReport(string tID,string startTime,string endTime)
//		{
//			float[] reportResult = new float[4];
//
//			using(DutyInfoDA dutyInfoDA = new DutyInfoDA())
//			{
//				reportResult = dutyInfoDA.TeaDutyReport(tID,startTime,endTime);
//			}
//
//			return reportResult;
//		}

		public int UpdateTeaDutyDetail(string tID,string sundayDuty,
			string mondayDuty,string tuesdayDuty,string wednesdayDuty,
			string thursdayDuty,string fridayDuty,string saturdayDuty)
		{
			int rowsAffected = 0;

			using(DutyInfoDA dutyInfoDA = new DutyInfoDA())
			{
				rowsAffected = dutyInfoDA.UpdateTeaDutyDetail(tID,sundayDuty,
					mondayDuty,tuesdayDuty,wednesdayDuty,thursdayDuty,fridayDuty,
					saturdayDuty);
			}

			return rowsAffected;
		}

		public void ImportTeaDutyNormalReports(DataSet teaDutyInfo,string savePath,DateTime getBegDate,DateTime getEndDate)
		{
			new TeaDutyRule().ImportTeaDutyNormalReports(teaDutyInfo,savePath,getBegDate,getEndDate);
		}

		public void ImportTeaDutyDetailsReports(DataSet teaDutyInfo,string savePath,DateTime getBegDate,DateTime getEndDate)
		{
			new TeaDutyRule().ImportTeaDutyDetailsReports(teaDutyInfo,savePath,getBegDate,getEndDate);
		}

		public void ImportTeaDutySummaryReports(DataSet teaDutyInfo,string savePath,DateTime getBegDate,DateTime getEndDate)
		{
			new TeaDutyRule().ImportTeaDutySummaryReports(teaDutyInfo,savePath,getBegDate,getEndDate);
		}

		public void ImportTeaOutDetailsReports(DataSet teaOutInfo,string savePath,DateTime getBegDate,DateTime getEndDate)
		{
			new TeaDutyRule().ImportTeaOutDetailsReports(teaOutInfo,savePath,getBegDate,getEndDate);
		}

		public int UpdateDutyInfo(DateTime getHisDutyDate,bool isToLoadCurDuty)
		{
			using ( DutyInfoDA dutyInfo = new DutyInfoDA() )
			{
				return dutyInfo.UpdateDutyInfo(getHisDutyDate,isToLoadCurDuty);
			}
		}

		public string[] CalcTeaDutyInfo(DateTime getBegDate,DateTime getEndDate,string getDept,string getDuty,string getName,
			string getNumber)
		{
			int getShouldAttendTimes = 0;
			string[] getStat = new string[6];
			int[] getValue = new DutyStatistics().TeaDutyStatistics(getBegDate,getEndDate,getDept,getDuty,getName,getNumber,ref getShouldAttendTimes);

			if ( getShouldAttendTimes == 0 )
			{
				for ( int i=0; i<=5; i++ )
					getStat[i] = "\t" + "0";
			}
			else
			{
				getStat[0] = "   " + getValue[0].ToString() + "  (" + ((float)getValue[0]/(float)getShouldAttendTimes).ToString("0.00%") + ")";
				getStat[1] = "   " + getValue[1].ToString() + "  (" + ((float)getValue[1]/(float)getShouldAttendTimes).ToString("0.00%") + ")";
				getStat[2] = "   " + (string)(getShouldAttendTimes-getValue[2] < 0 ? "0(0.00%)" : (getShouldAttendTimes-getValue[2]).ToString() + "  (" + (1-(float)getValue[2]/(float)getShouldAttendTimes).ToString("0.00%") + ")");
				getStat[3] = "   " + (string)((float)getValue[2]/(float)getShouldAttendTimes > 1 ? getValue[2].ToString() + "(100%)" : getValue[2].ToString() + "  (" + ((float)getValue[2]/(float)getShouldAttendTimes).ToString("0.00%") + " )");
				getStat[4] = "           " + SetAttendDays(getBegDate, getEndDate).ToString(); //getShouldAttendTimes.ToString(); 不考虑多班次问题
				getStat[5] = "           " + getValue[3].ToString();
			}

			return getStat;
		}
		
		public double[] CalcTeaDutyInfoForGraphic(DateTime getBegDate,DateTime getEndDate,string getDept,string getDuty,string getName,
			string getNumber)
		{
			int getShouldAttendTimes = 0;
			double[] getStat = new double[6];
			int[] getValue = new DutyStatistics().TeaDutyStatistics(getBegDate,getEndDate,getDept,getDuty,getName,getNumber,ref getShouldAttendTimes);

			if ( getShouldAttendTimes == 0 )
			{
				for ( int i=0; i<=5; i++ )
					getStat[i] = 0;
			}
			else
			{
				getStat[0] = (float)getValue[0]/(float)getShouldAttendTimes;
				getStat[1] = (float)getValue[1]/(float)getShouldAttendTimes;
				getStat[2] = 1 - (float)getValue[2]/(float)getShouldAttendTimes;
				getStat[3] = (float)getValue[2]/(float)getShouldAttendTimes;
			}

			return getStat;
		}

		public int SaveCurDuty()
		{
			using ( DutyInfoDA dutyInfo = new DutyInfoDA() )
			{
				return dutyInfo.SaveCurDuty();
			}
		}

		public DataSet BuildDutySummary(DateTime getBegDate,DateTime getEndDate,string getDept,string getDuty,string getName,string getNumber)
		{
			using ( DutyInfoDA dutyInfo = new DutyInfoDA() )
			{
				
			
				DataSet buildDutySummary = dutyInfo.GetTeaListForDutySummary(getDept,getDuty,getName,getNumber);

				if ( buildDutySummary.Tables[0].Rows.Count > 0 )
				{
					buildDutySummary.Tables[0].Columns.AddRange(new DataColumn[]{new DataColumn("Late"),new DataColumn("OffTime"),
																					new DataColumn("Absence"),new DataColumn("Attend"),
																					new DataColumn("ShouldAttend"),new DataColumn("Out")});
					
					for ( int numberRow=0; numberRow<buildDutySummary.Tables[0].Rows.Count; numberRow++ )
					{
						int getShouldAttendTimes = 0;
						int[] getValue = new DutyStatistics().TeaDutyStatistics(getBegDate,getEndDate,"","","",buildDutySummary.Tables[0].Rows[numberRow][1].ToString(),ref getShouldAttendTimes);
						
						if ( getShouldAttendTimes != 0 )
						{
							buildDutySummary.Tables[0].Rows[numberRow]["Late"] = getValue[0].ToString() + " (" + ((float)getValue[0]/(float)getShouldAttendTimes).ToString("0.00%") + ")";
							buildDutySummary.Tables[0].Rows[numberRow]["OffTime"] = getValue[1].ToString() + "(" + ((float)getValue[1]/(float)getShouldAttendTimes).ToString("0.00%") + ")";
							buildDutySummary.Tables[0].Rows[numberRow]["Absence"] = getShouldAttendTimes-getValue[2] < 0 ? "0(0.00%)" : (getShouldAttendTimes-getValue[2]).ToString() + "(" + (1-(float)getValue[2]/(float)getShouldAttendTimes).ToString("0.00%") + ")";
							buildDutySummary.Tables[0].Rows[numberRow]["Attend"] = (float)getValue[2]/(float)getShouldAttendTimes > 1 ? getValue[2].ToString() + "(100%)" : getValue[2].ToString() + "(" + ((float)getValue[2]/(float)getShouldAttendTimes).ToString("0.00%") + ")";
							buildDutySummary.Tables[0].Rows[numberRow]["ShouldAttend"] =  SetAttendDays(getBegDate, getEndDate);//不考虑多班次问题
							buildDutySummary.Tables[0].Rows[numberRow]["Out"] = getValue[3];
						}
						else
						{
							buildDutySummary.Tables[0].Rows[numberRow]["Late"] = 0;
							buildDutySummary.Tables[0].Rows[numberRow]["OffTime"] = 0;
							buildDutySummary.Tables[0].Rows[numberRow]["Absence"] = 0;
							buildDutySummary.Tables[0].Rows[numberRow]["Attend"] = 0;
							buildDutySummary.Tables[0].Rows[numberRow]["ShouldAttend"] = 0;
							buildDutySummary.Tables[0].Rows[numberRow]["Out"] = 0;
						}
					}
				}

				return buildDutySummary;
			}
		}

		private int SetAttendDays(DateTime BegDate, DateTime EndDate)
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

					//5.1 元旦
					if ((initBegDate.AddDays(i).Month == 1 ||  initBegDate.AddDays(i).Month == 5) && initBegDate.AddDays(i).Day == 1)
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
	}
}
