using System;
using System.Data;
using CPTT.DataAccess;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// RealtimeInfoRules 的摘要说明。
	/// </summary>
	public class RealtimeInfoRules
	{
		public RealtimeInfoRules()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataSet BuildRealtimeMorningInfo(DateTime getDate,string getGrade,string getClass)
		{
			using ( RealtimeInfoDataAccess realTimeInfoDataAccess = new RealtimeInfoDataAccess() )
			{
				DataSet buildRealtimeMorning = realTimeInfoDataAccess.setClassList("",getClass,getGrade);
				buildRealtimeMorning.Tables[0].Columns.AddRange(new DataColumn[]{new DataColumn("info_health"),new DataColumn("info_watch"),
																			 new DataColumn("info_ill"),new DataColumn("info_shouldAtt"),
																			 new DataColumn("info_haveAtt"),new DataColumn("info_absence"),
																			 new DataColumn("info_attPer")});
				DataSet dsHealth = realTimeInfoDataAccess.setRealtime(getDate,getGrade,getClass,0,0);
				DataSet dsWatch = realTimeInfoDataAccess.setRealtime(getDate,getGrade,getClass,2,0);	
				DataSet dsIll = realTimeInfoDataAccess.setRealtime(getDate,getGrade,getClass,3,0);
				DataSet dsAbsence = realTimeInfoDataAccess.setRealtime(getDate,getGrade,getClass,-1,0);
				DataSet dsSum = realTimeInfoDataAccess.setRealtime(getDate,getGrade,getClass,100,1);
				DataSet dsStuAmount = null;

				int healthNumbersAll = 0;
				int watchNumbersAll = 0;
				int illNumbersAll = 0;
				int absenceNumbersAll = 0;
				int sumNumbersAll = 0;
				int stuAmountAll = 0;

				for ( int row = 0; row < buildRealtimeMorning.Tables[0].Rows.Count; row ++ )
				{
					
					dsStuAmount = realTimeInfoDataAccess.setStuAmount(buildRealtimeMorning.Tables[0].Rows[row][2].ToString(),getDate);
						
					//健康人数统计
					if ( dsHealth.Tables[0].Rows.Count > 0 )
					{
						for ( int healthRow = 0; healthRow < dsHealth.Tables[0].Rows.Count; healthRow ++ )
						{
							if ( buildRealtimeMorning.Tables[0].Rows[row][2].ToString().Equals(dsHealth.Tables[0].Rows[healthRow][0].ToString()) )
							{
								buildRealtimeMorning.Tables[0].Rows[row][3] = dsHealth.Tables[0].Rows[healthRow][1].ToString()
									+ " (" +(Convert.ToDouble(dsHealth.Tables[0].Rows[healthRow][1])
									/Convert.ToDouble(dsStuAmount.Tables[0].Rows[0][0])).ToString("0.00%") + ")";

								healthNumbersAll += Convert.ToInt32(dsHealth.Tables[0].Rows[healthRow][1]);
								break;
							}
							else
							{
								if ( healthRow == dsHealth.Tables[0].Rows.Count - 1 )
									buildRealtimeMorning.Tables[0].Rows[row][3] = 0;
							}
						}
					}
					else
						buildRealtimeMorning.Tables[0].Rows[row][3] = 0;
					
					//观察人数统计
					if ( dsWatch.Tables[0].Rows.Count > 0 )
					{
						for ( int watchRow = 0; watchRow < dsWatch.Tables[0].Rows.Count; watchRow ++ )
						{
							if ( buildRealtimeMorning.Tables[0].Rows[row][2].ToString().Equals(dsWatch.Tables[0].Rows[watchRow][0].ToString()) )
							{
								buildRealtimeMorning.Tables[0].Rows[row][4] = dsWatch.Tables[0].Rows[watchRow][1].ToString()
									+ " (" +(Convert.ToDouble(dsWatch.Tables[0].Rows[watchRow][1])
									/Convert.ToDouble(dsStuAmount.Tables[0].Rows[0][0])).ToString("0.00%") + ")";

								watchNumbersAll += Convert.ToInt32(dsWatch.Tables[0].Rows[watchRow][1]);
								break;
							}
							else
							{
								if ( watchRow == dsWatch.Tables[0].Rows.Count - 1 )
									buildRealtimeMorning.Tables[0].Rows[row][4] = 0;
							}
						}
					}
					else
						buildRealtimeMorning.Tables[0].Rows[row][4] = 0;

					//服药人数统计
					if ( dsIll.Tables[0].Rows.Count > 0 )
					{
						for ( int illRow = 0; illRow < dsIll.Tables[0].Rows.Count; illRow ++ )
						{
							if ( buildRealtimeMorning.Tables[0].Rows[row][2].ToString().Equals(dsIll.Tables[0].Rows[illRow][0].ToString()) )
							{
								buildRealtimeMorning.Tables[0].Rows[row][5] = dsIll.Tables[0].Rows[illRow][1].ToString()
									+ " (" +(Convert.ToDouble(dsIll.Tables[0].Rows[illRow][1])
									/Convert.ToDouble(dsStuAmount.Tables[0].Rows[0][0])).ToString("0.00%") + ")";

								illNumbersAll += Convert.ToInt32(dsIll.Tables[0].Rows[illRow][1]);
								break;
							}
							else
							{
								if ( illRow == dsIll.Tables[0].Rows.Count - 1 )
									buildRealtimeMorning.Tables[0].Rows[row][5] = 0;
							}
						}
					}
					else
						buildRealtimeMorning.Tables[0].Rows[row][5] = 0;

					//应出勤人数
					if ( dsStuAmount.Tables[0].Rows.Count == 0 )
						buildRealtimeMorning.Tables[0].Rows[row][6] = 0;
					else
					{
						buildRealtimeMorning.Tables[0].Rows[row][6] = dsStuAmount.Tables[0].Rows[0][0].ToString();
						stuAmountAll += Convert.ToInt32(dsStuAmount.Tables[0].Rows[0][0]);
					}


					//缺席人数
					if ( dsAbsence.Tables[0].Rows.Count > 0 )
					{
						for ( int absenceRow = 0; absenceRow < dsAbsence.Tables[0].Rows.Count; absenceRow ++ )
						{
							if ( buildRealtimeMorning.Tables[0].Rows[row][2].ToString().Equals(dsAbsence.Tables[0].Rows[absenceRow][0].ToString()) )
							{
								buildRealtimeMorning.Tables[0].Rows[row][8] = dsAbsence.Tables[0].Rows[absenceRow][1].ToString()
									+ " (" +(Convert.ToDouble(dsAbsence.Tables[0].Rows[absenceRow][1])
									/Convert.ToDouble(dsStuAmount.Tables[0].Rows[0][0])).ToString("0.00%") + ")";

								absenceNumbersAll += Convert.ToInt32(dsAbsence.Tables[0].Rows[absenceRow][1]);
								break;
							}
							else
							{
								if ( absenceRow == dsAbsence.Tables[0].Rows.Count - 1)
									buildRealtimeMorning.Tables[0].Rows[row][8] = 0;
							}
						}
					}
					else
						buildRealtimeMorning.Tables[0].Rows[row][8] = 0;

					//出勤率
					if ( dsSum.Tables[0].Rows.Count > 0 )
					{
						for ( int attRow = 0; attRow < dsSum.Tables[0].Rows.Count; attRow ++ )
						{
							if ( buildRealtimeMorning.Tables[0].Rows[row][2].ToString().Equals(dsSum.Tables[0].Rows[attRow][0].ToString()) )
							{
								buildRealtimeMorning.Tables[0].Rows[row][9] = 
									(Convert.ToDouble(dsSum.Tables[0].Rows[attRow][1])/Convert.ToDouble(dsStuAmount.Tables[0].Rows[0][0])).ToString("0.00%");
								buildRealtimeMorning.Tables[0].Rows[row][7] = Convert.ToInt32(dsSum.Tables[0].Rows[attRow][1]);

								sumNumbersAll += Convert.ToInt32(dsSum.Tables[0].Rows[attRow][1]);
								break; 
							}
							else
							{
								if ( attRow == dsSum.Tables[0].Rows.Count - 1 )
								{
									buildRealtimeMorning.Tables[0].Rows[row][9] = 0;
									buildRealtimeMorning.Tables[0].Rows[row][7] = 0;
								}
							}
						}
					}
					else
					{
						buildRealtimeMorning.Tables[0].Rows[row][9] = 0;
						buildRealtimeMorning.Tables[0].Rows[row][7] = 0;
					}

					if ( row == buildRealtimeMorning.Tables[0].Rows.Count - 1 )
					{
						DataRow newRow = buildRealtimeMorning.Tables[0].NewRow();
							
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

						buildRealtimeMorning.Tables[0].Rows.Add(newRow);
						break;
					}
				}
				return buildRealtimeMorning;
			}
		}

		public DataSet BuildRealtimeBackInfo(DateTime getDate,string getGrade,string getClass)
		{
			using ( RealtimeInfoDataAccess realTimeInfoDataAccess = new RealtimeInfoDataAccess() )
			{
				DataSet buildRealtimeBack = realTimeInfoDataAccess.setClassList("",getClass,getGrade);
				buildRealtimeBack.Tables[0].Columns.AddRange(new DataColumn[]{new DataColumn("info_hasGone"),
																			new DataColumn("info_shouldGo"),new DataColumn("info_notGone"),
																			new DataColumn("info_goPer")});
				DataSet dsHasGone = realTimeInfoDataAccess.setRealtime(getDate,getGrade,getClass,1,0);
				DataSet dsShouldGo = realTimeInfoDataAccess.setRealtime(getDate,getGrade,getClass,100,1);
				DataSet dsNotGone = realTimeInfoDataAccess.setRealtime(getDate,getGrade,getClass,-2,0);

				int hasGoneAll = 0;
				int shouldGoAll = 0;
				int hasNotGoneAll = 0;
				
				for ( int row = 0;row < buildRealtimeBack.Tables[0].Rows.Count; row ++ )
				{
					if ( dsHasGone.Tables[0].Rows.Count > 0 )
					{
						for ( int hasGoneRow = 0;hasGoneRow < dsHasGone.Tables[0].Rows.Count; hasGoneRow ++ )
						{
							if ( buildRealtimeBack.Tables[0].Rows[row][2].ToString().Equals(dsHasGone.Tables[0].Rows[hasGoneRow][0].ToString()) )
							{
								buildRealtimeBack.Tables[0].Rows[row][3] = dsHasGone.Tables[0].Rows[hasGoneRow][1];

								hasGoneAll += Convert.ToInt32(dsHasGone.Tables[0].Rows[hasGoneRow][1]);
								break;
							}
							else
							{
								if ( hasGoneRow == dsHasGone.Tables[0].Rows.Count - 1)
									buildRealtimeBack.Tables[0].Rows[row][3] = 0;
							}
						}
					}
					else
						buildRealtimeBack.Tables[0].Rows[row][3] = 0;

					if ( dsShouldGo.Tables[0].Rows.Count > 0 )
					{
						for ( int shouldGoRow = 0;shouldGoRow < dsShouldGo.Tables[0].Rows.Count; shouldGoRow ++ )
						{
							if ( buildRealtimeBack.Tables[0].Rows[row][2].ToString().Equals(dsShouldGo.Tables[0].Rows[shouldGoRow][0].ToString()) )
							{
								buildRealtimeBack.Tables[0].Rows[row][4] = dsShouldGo.Tables[0].Rows[shouldGoRow][1];

								shouldGoAll += Convert.ToInt32(dsShouldGo.Tables[0].Rows[shouldGoRow][1]);
								break;
							}
							else
							{
								if ( shouldGoRow == dsShouldGo.Tables[0].Rows.Count - 1 )
									buildRealtimeBack.Tables[0].Rows[row][4] = 0;
							}
						}
					}
					else
						buildRealtimeBack.Tables[0].Rows[row][4] = 0;

					if ( dsNotGone.Tables[0].Rows.Count > 0 )
					{
						for ( int notGoneRow = 0; notGoneRow < dsNotGone.Tables[0].Rows.Count; notGoneRow ++ )
						{
							if ( buildRealtimeBack.Tables[0].Rows[row][2].ToString().Equals(dsNotGone.Tables[0].Rows[notGoneRow][0].ToString()) )
							{
								buildRealtimeBack.Tables[0].Rows[row][5] = dsNotGone.Tables[0].Rows[notGoneRow][1];

								hasNotGoneAll += Convert.ToInt32(dsNotGone.Tables[0].Rows[notGoneRow][1]);
								break;
							}
							else
							{
								if ( notGoneRow == dsNotGone.Tables[0].Rows.Count - 1 )
									buildRealtimeBack.Tables[0].Rows[row][5] = 0;
							}
						}
					}
					else
						buildRealtimeBack.Tables[0].Rows[row][5] = 0;

					if ( Convert.ToInt32(buildRealtimeBack.Tables[0].Rows[row][4]) != 0)
						buildRealtimeBack.Tables[0].Rows[row][6] = (Convert.ToDouble(buildRealtimeBack.Tables[0].Rows[row][3])
							/Convert.ToDouble(buildRealtimeBack.Tables[0].Rows[row][4])).ToString("0.00%");
					else
						buildRealtimeBack.Tables[0].Rows[row][6] = "0";

					if ( row == buildRealtimeBack.Tables[0].Rows.Count - 1 )
					{
						DataRow newRow = buildRealtimeBack.Tables[0].NewRow();

						newRow[1] = "[总计]";

						if ( shouldGoAll == 0 )
						{
							newRow[3] = 0;
							newRow[4] = 0;
							newRow[5] = 0;
							newRow[6] = 0;
						}
						else
						{
							newRow[3] = hasGoneAll;
							newRow[4] = shouldGoAll;
							newRow[5] = hasNotGoneAll;
							newRow[6] = ((double)hasGoneAll/(double)shouldGoAll).ToString("0.00%");
						}

						buildRealtimeBack.Tables[0].Rows.Add(newRow);
						break;
					}
				}
				return buildRealtimeBack;
			}	
		}
	}
}
