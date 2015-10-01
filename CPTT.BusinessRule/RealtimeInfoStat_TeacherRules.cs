using System;
using System.Data;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// RealtimeInfoStat_TeacherRules 的摘要说明。
	/// </summary>
	public class RealtimeInfoStat_TeacherRules
	{
		public RealtimeInfoStat_TeacherRules()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataSet BuildRealtimeMorningInfo(string getDept)
		{
			using ( RealtimeInfo_TeacherDataAccess realTimeInfo_TeacherDataAccess = new RealtimeInfo_TeacherDataAccess() )
			{
				try
				{
					DataSet buildRealtimeTeacher = realTimeInfo_TeacherDataAccess.GetTeaDeptInfo(getDept);
					DataSet dsDutyID = realTimeInfo_TeacherDataAccess.GetDutyID(DateTime.Now.ToString("HH:mm:ss"));

					int teaAttNumbersInDutyAll = 0;
					int teaAttOnTimeNumbersInDutyAll = 0;
					int teaAttNotOnTimNumbersInDutyAll = 0;

					buildRealtimeTeacher.Tables[0].Columns.AddRange(new DataColumn[]{new DataColumn("info_onTime"),new DataColumn("info_notOnTime"),
																						new DataColumn("info_shouldAtt"),new DataColumn("info_haveAtt"),
																						new DataColumn("info_absence"),new DataColumn("info_attPer")});
					for ( int row=0; row<buildRealtimeTeacher.Tables[0].Rows.Count; row++ )
					{
						int teaAttNumbersInDuty = 0;
						int teaAttOnTimeNumbersInDuty = 0;
						int teaAttNotOnTimeNumbersInDuty = 0;
						
						if (dsDutyID.Tables[0] != null && dsDutyID.Tables[0].Rows.Count > 0)
						{
							foreach ( DataRow dutyRow in dsDutyID.Tables[0].Rows )
							{
								teaAttNumbersInDuty += realTimeInfo_TeacherDataAccess.GetTeaNumbers(DateTime.Now.DayOfWeek.ToString(),dutyRow[0].ToString(),buildRealtimeTeacher.Tables[0].Rows[row][0].ToString());
								realTimeInfo_TeacherDataAccess.GetTeaWorkingNumbers(dutyRow[0].ToString(),ref teaAttOnTimeNumbersInDuty,ref teaAttNotOnTimeNumbersInDuty,buildRealtimeTeacher.Tables[0].Rows[row][0].ToString(),DateTime.Now.Date);
							}

							int noDutyTotal = 0;
							int noDutyAttend = 0;	
							int noDutyLeave = 0;

							realTimeInfo_TeacherDataAccess.GetTeacherRealTimeInfoWithNoDuty(buildRealtimeTeacher.Tables[0].Rows[row][0].ToString(),DateTime.Now.DayOfWeek.ToString(), ref noDutyTotal, ref noDutyAttend,ref noDutyLeave);


//							buildRealtimeTeacher.Tables[0].Rows[row][1] = attend; //准时
//							buildRealtimeTeacher.Tables[0].Rows[row][2] = 0; //迟到
//							buildRealtimeTeacher.Tables[0].Rows[row][3] = total; //应到
//							buildRealtimeTeacher.Tables[0].Rows[row][4] = attend; //实到
//							buildRealtimeTeacher.Tables[0].Rows[row][5] = total - attend; //缺席
//							buildRealtimeTeacher.Tables[0].Rows[row][6] = total == 0 ? "0.00%" : ((double)attend/(double)total).ToString("0.00%"); //出勤率

							teaAttNumbersInDuty += noDutyTotal;
							teaAttOnTimeNumbersInDuty += noDutyAttend;


							buildRealtimeTeacher.Tables[0].Rows[row][1] = teaAttOnTimeNumbersInDuty+" ("+((double)teaAttOnTimeNumbersInDuty/(double)teaAttNumbersInDuty).ToString("0.00%")+")";
							buildRealtimeTeacher.Tables[0].Rows[row][2] = teaAttNotOnTimeNumbersInDuty+" ("+((double)teaAttNotOnTimeNumbersInDuty/(double)teaAttNumbersInDuty).ToString("0.00%")+")";
							buildRealtimeTeacher.Tables[0].Rows[row][3] = teaAttNumbersInDuty;
							buildRealtimeTeacher.Tables[0].Rows[row][4] = (teaAttOnTimeNumbersInDuty+teaAttNotOnTimeNumbersInDuty);
							buildRealtimeTeacher.Tables[0].Rows[row][5] = (teaAttNumbersInDuty-teaAttOnTimeNumbersInDuty-teaAttNotOnTimeNumbersInDuty)+ " ("
								+(1-((double)teaAttOnTimeNumbersInDuty+(double)teaAttNotOnTimeNumbersInDuty)/teaAttNumbersInDuty).ToString("0.00%")+")";
							buildRealtimeTeacher.Tables[0].Rows[row][6] = (((double)teaAttOnTimeNumbersInDuty+(double)teaAttNotOnTimeNumbersInDuty)/teaAttNumbersInDuty).ToString("0.00%");


							buildRealtimeTeacher.Tables[0].Rows[row][1] = buildRealtimeTeacher.Tables[0].Rows[row][1].ToString().Replace("(非数字)", string.Empty);
							buildRealtimeTeacher.Tables[0].Rows[row][2] = buildRealtimeTeacher.Tables[0].Rows[row][2].ToString().Replace("(非数字)", string.Empty);
							buildRealtimeTeacher.Tables[0].Rows[row][3] = buildRealtimeTeacher.Tables[0].Rows[row][3].ToString().Replace("(非数字)", string.Empty);
							buildRealtimeTeacher.Tables[0].Rows[row][4] = buildRealtimeTeacher.Tables[0].Rows[row][4].ToString().Replace("(非数字)", string.Empty);
							buildRealtimeTeacher.Tables[0].Rows[row][5] = buildRealtimeTeacher.Tables[0].Rows[row][5].ToString().Replace("(非数字)", string.Empty);
							buildRealtimeTeacher.Tables[0].Rows[row][6] = buildRealtimeTeacher.Tables[0].Rows[row][6].ToString().Replace("非数字", "0.00%");

							teaAttNumbersInDutyAll += teaAttNumbersInDuty;
							teaAttOnTimeNumbersInDutyAll += teaAttOnTimeNumbersInDuty;
							teaAttNotOnTimNumbersInDutyAll += teaAttNotOnTimeNumbersInDuty;
						}
						else
						{
							int noDutyTotal = 0;
							int noDutyAttend = 0;
							int noDutyLeave = 0;
							realTimeInfo_TeacherDataAccess.GetTeacherRealTimeInfoWithNoDuty(buildRealtimeTeacher.Tables[0].Rows[row][0].ToString(),DateTime.Now.DayOfWeek.ToString(), ref noDutyTotal, ref noDutyAttend, ref noDutyLeave);
							buildRealtimeTeacher.Tables[0].Rows[row][1] = noDutyAttend; //准时
							buildRealtimeTeacher.Tables[0].Rows[row][2] = 0; //迟到
							buildRealtimeTeacher.Tables[0].Rows[row][3] = noDutyTotal; //应到
							buildRealtimeTeacher.Tables[0].Rows[row][4] = noDutyAttend; //实到
							buildRealtimeTeacher.Tables[0].Rows[row][5] = noDutyTotal - noDutyAttend; //缺席
							buildRealtimeTeacher.Tables[0].Rows[row][6] = noDutyTotal == 0 ? "0.00%" : ((double)noDutyAttend/(double)noDutyTotal).ToString("0.00%"); //出勤率

							teaAttNumbersInDutyAll += noDutyTotal;
							teaAttOnTimeNumbersInDutyAll += noDutyAttend;
							teaAttNotOnTimNumbersInDutyAll = 0;
						}

						if ( row == buildRealtimeTeacher.Tables[0].Rows.Count - 1 )
						{
							DataRow newRow = buildRealtimeTeacher.Tables[0].NewRow();

							newRow[0] = "[总计]";

							if ( teaAttNumbersInDutyAll == 0 )
							{
								newRow[1] = "--";
								newRow[2] = "--";
								newRow[3] = "--";
								newRow[4] = "--";
								newRow[5] = "--";
								newRow[6] = "--";
							}
							else
							{
								newRow[1] = teaAttOnTimeNumbersInDutyAll+" ("+((double)teaAttOnTimeNumbersInDutyAll/(double)teaAttNumbersInDutyAll).ToString("0.00%")+")";
								newRow[2] = teaAttNotOnTimNumbersInDutyAll+" ("+((double)teaAttNotOnTimNumbersInDutyAll/(double)teaAttNumbersInDutyAll).ToString("0.00%")+")";
								newRow[3] = teaAttNumbersInDutyAll;
								newRow[4] = (teaAttOnTimeNumbersInDutyAll+teaAttNotOnTimNumbersInDutyAll);
								newRow[5] = (teaAttNumbersInDutyAll-teaAttOnTimeNumbersInDutyAll-teaAttNotOnTimNumbersInDutyAll)+ " ("
									+(1-((double)teaAttOnTimeNumbersInDutyAll+(double)teaAttNotOnTimNumbersInDutyAll)/teaAttNumbersInDutyAll).ToString("0.00%")+")";
								newRow[6] = (((double)teaAttOnTimeNumbersInDutyAll+(double)teaAttNotOnTimNumbersInDutyAll)/teaAttNumbersInDutyAll).ToString("0.00%");

								newRow[1] = newRow[1].ToString().Replace("(非数字)", string.Empty);
								newRow[2] = newRow[2].ToString().Replace("(非数字)", string.Empty);
								newRow[3] = newRow[3].ToString().Replace("(非数字)", string.Empty);
								newRow[4] = newRow[4].ToString().Replace("(非数字)", string.Empty);
								newRow[5] = newRow[5].ToString().Replace("(非数字)", string.Empty);
								newRow[6] = newRow[6].ToString().Replace("非数字", "0.00%");
							}

							buildRealtimeTeacher.Tables[0].Rows.Add(newRow);
							break;
 						}
					}

					return buildRealtimeTeacher;
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet BuildRealtimeBackInfo(string getDept)
		{
			using ( RealtimeInfo_TeacherDataAccess realTimeInfo_TeacherDataAccess = new RealtimeInfo_TeacherDataAccess() )
			{
				try
				{
					DataSet buildRealtimeTeacher = realTimeInfo_TeacherDataAccess.GetTeaDeptInfo(getDept);
					DataSet dsDutyID = realTimeInfo_TeacherDataAccess.GetDutyID(DateTime.Now.ToString("HH:mm:ss"));

					int teaShouldLeaveAll = 0;
					int teaLeaveOnTimeNumbersInDutyAll = 0;
					int teaLeaveNotOnTimeNumbersInDutyAll = 0;
			
					buildRealtimeTeacher.Tables[0].Columns.AddRange(new DataColumn[]{new DataColumn("info_leaveOnTime"),new DataColumn("info_leaveNotOnTime"),
																						new DataColumn("info_shouldLeave"),new DataColumn("info_remain"),
																						new DataColumn("info_leavePer")});
					for ( int row=0; row<buildRealtimeTeacher.Tables[0].Rows.Count; row++ )
					{
//						int teaAttNumbersInDuty = 0;
						int teaAttOnTimeNumbersInDuty = 0;
						int teaAttNotOnTimeNumbersInDuty = 0;
						int teaLeaveOnTimeNumbersInDuty = 0;
						int teaLeaveNotOnTimeNumbersInDuty = 0;
						int teaShouldLeaveInDuty = 0;
			
						if ( dsDutyID.Tables[0].Rows.Count > 0 )
						{
							foreach ( DataRow dutyRow in dsDutyID.Tables[0].Rows )
							{
//								teaAttNumbersInDuty += realTimeInfo_TeacherDataAccess.GetTeaNumbers(DateTime.Now.DayOfWeek.ToString(),dutyRow[0].ToString(),buildRealtimeTeacher.Tables[0].Rows[row][0].ToString());
								realTimeInfo_TeacherDataAccess.GetTeaWorkingNumbers(dutyRow[0].ToString(),ref teaAttOnTimeNumbersInDuty,ref teaAttNotOnTimeNumbersInDuty,buildRealtimeTeacher.Tables[0].Rows[row][0].ToString(),DateTime.Now.Date);
								realTimeInfo_TeacherDataAccess.GetTeaLeaveNumbers(dutyRow[0].ToString(),ref teaLeaveOnTimeNumbersInDuty,ref teaLeaveNotOnTimeNumbersInDuty,buildRealtimeTeacher.Tables[0].Rows[row][0].ToString(),DateTime.Now.Date);
							}

							teaShouldLeaveInDuty = teaAttOnTimeNumbersInDuty + teaAttNotOnTimeNumbersInDuty;

							int noDutyTotal = 0;
							int noDutyAttend = 0;
							int noDutyLeave = 0;

							realTimeInfo_TeacherDataAccess.GetTeacherRealTimeInfoWithNoDuty(buildRealtimeTeacher.Tables[0].Rows[row][0].ToString(),DateTime.Now.DayOfWeek.ToString(), ref noDutyTotal, ref noDutyAttend,ref noDutyLeave);

//								buildRealtimeTeacher.Tables[0].Rows[row][1] = leave;   //离开
//								buildRealtimeTeacher.Tables[0].Rows[row][2] = 0;   //早退
//								buildRealtimeTeacher.Tables[0].Rows[row][3] = attend;   //应离开
//								buildRealtimeTeacher.Tables[0].Rows[row][4] = attend - leave;   //剩余
//								buildRealtimeTeacher.Tables[0].Rows[row][5] = attend == 0 ? "0.00%" : ((double)leave/(double)leave).ToString("0.00%");   //离开率

							teaLeaveOnTimeNumbersInDuty += noDutyLeave;
							teaShouldLeaveInDuty += noDutyAttend;

							buildRealtimeTeacher.Tables[0].Rows[row][1] = teaLeaveOnTimeNumbersInDuty+" ("+((double)teaLeaveOnTimeNumbersInDuty/(double)teaShouldLeaveInDuty).ToString("0.00%")+")";
							buildRealtimeTeacher.Tables[0].Rows[row][2] = teaLeaveNotOnTimeNumbersInDuty+" ("+((double)teaLeaveNotOnTimeNumbersInDuty/(double)teaShouldLeaveInDuty).ToString("0.00%")+")";
							buildRealtimeTeacher.Tables[0].Rows[row][3] = teaShouldLeaveInDuty;   //teaAttNumbersInDuty;
							buildRealtimeTeacher.Tables[0].Rows[row][4] = (teaShouldLeaveInDuty - teaLeaveOnTimeNumbersInDuty - teaLeaveNotOnTimeNumbersInDuty)+ " ("
								+(1-((double)teaLeaveOnTimeNumbersInDuty+(double)teaLeaveNotOnTimeNumbersInDuty)/(double)teaShouldLeaveInDuty).ToString("0.00%")+")";
							buildRealtimeTeacher.Tables[0].Rows[row][5] = (((double)teaLeaveOnTimeNumbersInDuty + (double)teaLeaveNotOnTimeNumbersInDuty)/(double)teaShouldLeaveInDuty).ToString("0.00%");

							buildRealtimeTeacher.Tables[0].Rows[row][1] = buildRealtimeTeacher.Tables[0].Rows[row][1].ToString().Replace("(非数字)", string.Empty);
							buildRealtimeTeacher.Tables[0].Rows[row][2] = buildRealtimeTeacher.Tables[0].Rows[row][2].ToString().Replace("(非数字)", string.Empty);
							buildRealtimeTeacher.Tables[0].Rows[row][3] = buildRealtimeTeacher.Tables[0].Rows[row][3].ToString().Replace("(非数字)", string.Empty);
							buildRealtimeTeacher.Tables[0].Rows[row][4] = buildRealtimeTeacher.Tables[0].Rows[row][4].ToString().Replace("(非数字)", string.Empty);
							buildRealtimeTeacher.Tables[0].Rows[row][5] = buildRealtimeTeacher.Tables[0].Rows[row][5].ToString().Replace("非数字", "0.00%");

							teaShouldLeaveAll += teaShouldLeaveInDuty;
							teaLeaveOnTimeNumbersInDutyAll += teaLeaveOnTimeNumbersInDuty;
							teaLeaveNotOnTimeNumbersInDutyAll += teaLeaveNotOnTimeNumbersInDuty;
						}
						else
						{
							int noDutyTotal = 0;
							int noDutyAttend = 0;
							int noDutyLeave = 0;

							realTimeInfo_TeacherDataAccess.GetTeacherRealTimeInfoWithNoDuty(buildRealtimeTeacher.Tables[0].Rows[row][0].ToString(),DateTime.Now.DayOfWeek.ToString(), ref noDutyTotal, ref noDutyAttend,ref noDutyLeave);
							buildRealtimeTeacher.Tables[0].Rows[row][1] = noDutyLeave;   //离开
							buildRealtimeTeacher.Tables[0].Rows[row][2] = 0;   //早退
							buildRealtimeTeacher.Tables[0].Rows[row][3] = noDutyAttend;   //应离开
							buildRealtimeTeacher.Tables[0].Rows[row][4] = noDutyAttend - noDutyLeave;   //剩余
							buildRealtimeTeacher.Tables[0].Rows[row][5] = noDutyAttend == 0 ? "100%" : ((double)noDutyLeave/(double)noDutyAttend).ToString("0.00%");   //离开率

							teaLeaveOnTimeNumbersInDutyAll += noDutyLeave;
							teaLeaveNotOnTimeNumbersInDutyAll = 0;
							teaShouldLeaveAll += noDutyAttend;
						}

						if ( row == buildRealtimeTeacher.Tables[0].Rows.Count - 1 )
						{
							DataRow newRow = buildRealtimeTeacher.Tables[0].NewRow();

							newRow[0] = "[总计]";

							if ( teaShouldLeaveAll == 0 )
							{
								newRow[1] = 0;
								newRow[2] = 0;
								newRow[3] = 0;
								newRow[4] = 0;
								newRow[5] = 0;
							}
							else
							{
								newRow[1] = teaLeaveOnTimeNumbersInDutyAll+" ("+((double)teaLeaveOnTimeNumbersInDutyAll/(double)teaShouldLeaveAll).ToString("0.00%")+")";
								newRow[2] = teaLeaveNotOnTimeNumbersInDutyAll+" ("+((double)teaLeaveNotOnTimeNumbersInDutyAll/(double)teaShouldLeaveAll).ToString("0.00%")+")";
								newRow[3] = teaShouldLeaveAll;
								newRow[4] = (teaShouldLeaveAll - teaLeaveOnTimeNumbersInDutyAll - teaLeaveNotOnTimeNumbersInDutyAll)+ " ("
									+(1-((double)teaLeaveOnTimeNumbersInDutyAll+(double)teaLeaveNotOnTimeNumbersInDutyAll)/(double)teaShouldLeaveAll).ToString("0.00%")+")";
								newRow[5] = (((double)teaLeaveOnTimeNumbersInDutyAll+(double)teaLeaveNotOnTimeNumbersInDutyAll)/(double)teaShouldLeaveAll).ToString("0.00%");

								newRow[1] = newRow[1].ToString().Replace("(非数字)", string.Empty);
								newRow[2] = newRow[2].ToString().Replace("(非数字)", string.Empty);
								newRow[3] = newRow[3].ToString().Replace("(非数字)", string.Empty);
								newRow[4] = newRow[4].ToString().Replace("(非数字)", string.Empty);
								newRow[5] = newRow[5].ToString().Replace("非数字", "0.00%");
							}

							buildRealtimeTeacher.Tables[0].Rows.Add(newRow);
							break;
						}
					}

					return buildRealtimeTeacher;
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
