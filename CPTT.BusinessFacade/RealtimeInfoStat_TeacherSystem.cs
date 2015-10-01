using System;
using System.Data;
using CPTT.DataAccess;
using CPTT.BusinessRule;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// RealtimeInfoStat_TeacherSystem 的摘要说明。
	/// </summary>
	public class RealtimeInfoStat_TeacherSystem
	{

		public RealtimeInfoStat_TeacherSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataSet GetRealtimeInfoStat_Teacher(string getDept,string getState)
		{
			if ( getState.Equals("上班情况") )
				return new RealtimeInfoStat_TeacherRules().BuildRealtimeMorningInfo(getDept);
			else
				return new RealtimeInfoStat_TeacherRules().BuildRealtimeBackInfo(getDept);
		}

		public DataSet GetTeaDept()
		{
			using ( RealtimeInfo_TeacherDataAccess realTimeInfo_TeacherDataAccess = new RealtimeInfo_TeacherDataAccess() )
			{
				try
				{
					return realTimeInfo_TeacherDataAccess.GetTeaDeptInfo("");
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

	}
}
