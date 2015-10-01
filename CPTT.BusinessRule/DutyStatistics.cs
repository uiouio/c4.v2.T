using System;
using System.Data;
using CPTT.DataAccess;


namespace CPTT.BusinessRule
{
	/// <summary>
	/// DutyStatistics 的摘要说明。
	/// </summary>
	public class DutyStatistics
	{
		public DutyStatistics()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public int[] TeaDutyStatistics(DateTime getBegDate,DateTime getEndDate,string getDept,string getDuty,string getName,string getNumber,ref int getShouldAttendTimes)
		{
			string[] getStatistics = new string[6];
			DateTime firDateThisWeek;
			DateTime today = DateTime.Now.Date;
//			int getShouldAttendTimes = 0;
			
			if ( today.DayOfWeek.ToString().Equals("Sunday") )
				firDateThisWeek = today.AddDays(-6);
			else
				firDateThisWeek = today.AddDays(-(Convert.ToInt32(today.DayOfWeek.ToString("d"))-1));

			using ( DutyInfoDA dutyInfo = new DutyInfoDA() )
			{
				getShouldAttendTimes += dutyInfo.CalcTeaDutyInfo(getBegDate.AddDays(7),getEndDate.AddDays(7),getDept,getDuty,getName,getNumber,false);

//				if ( getBegDate == today )
//				{
//					getShouldAttendTimes += dutyInfo.CalcTeaDutyInfo(today,today,getDept,getDuty,getName,getNumber,true);
//				}
//
//				else if ( getEndDate == firDateThisWeek )
//				{
//					getShouldAttendTimes += dutyInfo.CalcTeaDutyInfo(getEndDate,getEndDate,getDept,getDuty,getName,getNumber,true);
//				}
 
				if ( getBegDate < firDateThisWeek && getEndDate <= today && getEndDate >= firDateThisWeek )
				{
					getShouldAttendTimes += dutyInfo.CalcTeaDutyInfo(firDateThisWeek,getEndDate,getDept,getDuty,getName,getNumber,true);
				}

				else if ( getBegDate >= firDateThisWeek && getEndDate <= today )
				{
					getShouldAttendTimes += dutyInfo.CalcTeaDutyInfo(getBegDate,getEndDate,getDept,getDuty,getName,getNumber,true);
				}

				else if ( getBegDate >= firDateThisWeek && getEndDate > today && getBegDate <= today)
				{
					getShouldAttendTimes += dutyInfo.CalcTeaDutyInfo(getBegDate,today,getDept,getDuty,getName,getNumber,true);
				}

				else if ( getBegDate < firDateThisWeek && getEndDate > today )
				{
					getShouldAttendTimes += dutyInfo.CalcTeaDutyInfo(firDateThisWeek,today,getDept,getDuty,getName,getNumber,true);
				}

//				if ( getShouldAttendTimes == 0 )
//				{
//					for ( int i=0; i<=5; i++ )
//						getStatistics[i] = "0";
//				}
//				else
//				{
				int[] getValue = dutyInfo.TeaDutyReport(getBegDate,getEndDate,getDept,getDuty,getName,getNumber);
//					getStatistics[0] = "   " + getValue[0].ToString() + "  (" + ((float)getValue[0]/(float)getShouldAttendTimes).ToString("0.00%") + ")";
//					getStatistics[1] = "   " + getValue[1].ToString() + "  (" + ((float)getValue[1]/(float)getShouldAttendTimes).ToString("0.00%") + ")";
//					getStatistics[2] = "   " + (getShouldAttendTimes-getValue[2]).ToString() + "  (" + (1-(float)getValue[2]/(float)getShouldAttendTimes).ToString("0.00%") + ")";
//					getStatistics[3] = "   " + getValue[2].ToString() + "  (" + ((float)getValue[2]/(float)getShouldAttendTimes).ToString("0.00%") + " )";
//					getStatistics[4] = "\t" + getShouldAttendTimes.ToString();
//					getStatistics[5] = "\t" + getValue[3].ToString();
//				}

				return getValue;
			}                 

		}
	}
}
