//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

using System;
using System.Data;

using CPTT.SystemFramework;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CPTT.DataAccess
{
	/// <summary>
	/// StuCheckInfoDataAccess 的摘要说明。
	/// </summary>
	public class MorningCheckInfoDataAccess : IDisposable
	{
		private Database db = null;

		public MorningCheckInfoDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			db = DatabaseFactory.CreateDatabase();
		}

		public DataSet GetStuRealTimeWindowsInfo(out int sumTotal,DateTime currentDate)
		{
			DataSet allStuRealInfo = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetStuRealTimeWindowsInfo");
				dbCom.AddInParameter("@currentDate",DbType.DateTime,currentDate);
				dbCom.AddOutParameter("@sumTotal",DbType.Int32,4);

				allStuRealInfo = db.ExecuteDataSet(dbCom);

				sumTotal = Convert.ToInt32(dbCom.GetParameterValue("@sumTotal"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return allStuRealInfo;
		}

		public DataSet GetTeaRealTimeWindowsInfo(out int sumTotal,DateTime currentDate)
		{
			DataSet allTeaRealInfo = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetTeaRealTimeWindowsInfo");
				dbCom.AddInParameter("@currentDate",DbType.DateTime,currentDate);
				dbCom.AddOutParameter("@sumTotal",DbType.Int32,4);

				allTeaRealInfo = db.ExecuteDataSet(dbCom);

				sumTotal = Convert.ToInt32(dbCom.GetParameterValue("@sumTotal"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return allTeaRealInfo;
		}

		public DataSet GetTranRealTimeWindowsInfo(DateTime currentDate)
		{
			DataSet allTranRealInfo = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetTranRealTimeWindowsInfo");
				dbCom.AddInParameter("@currentDate",DbType.DateTime,currentDate);

				allTranRealInfo = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return allTranRealInfo;
		}

		//新协议
//		public int InsertMorningCheckInfo(DataFrame dataFrame)
//		{
//			int rowsAffected = 0;
//
//			try
//			{
//				if(dataFrame.frameData.Length == 13)//确认为晨检应答帧
//				{
//					Int16 classNumber = (Int16)(((dataFrame.frameData[1]/16)*10 + (dataFrame.frameData[1]%16))*100  
//						+ dataFrame.frameData[0]);//计算学号
//
//					int year = dataFrame.frameData[2] == 0 ? DateTime.Now.Year : 2000 + (Int16)dataFrame.frameData[2];
//					int month = dataFrame.frameData[3] == 0 ? DateTime.Now.Month : dataFrame.frameData[3];
//					int day = dataFrame.frameData[4] == 0 ? DateTime.Now.Day :dataFrame.frameData[4];
//					int hour = dataFrame.frameData[5] == 0 ? DateTime.Now.Hour : dataFrame.frameData[5];
//					int minute = dataFrame.frameData[6] == 0 ? DateTime.Now.Minute : dataFrame.frameData[6];
//					int second = dataFrame.frameData[7] == 0 ? DateTime.Now.Second : dataFrame.frameData[7];
//
//					DateTime checkTime = new DateTime(year, month, day, hour, minute, second);
//
//					bool isManual = false;
//
//					if(dataFrame.frameData[9] == 6)
//					{
//						isManual = true;
//					}
//
//					DBCommandWrapper dbcommandWrapper = db.GetStoredProcCommandWrapper("FillCheckInfo");
//
//					dbcommandWrapper.AddInParameter("@getStuNumber",DbType.Int16,classNumber);
//					dbcommandWrapper.AddInParameter("@getTime",DbType.DateTime,checkTime);
//					dbcommandWrapper.AddInParameter("@getState",DbType.Int16,Convert.ToInt16(dataFrame.frameData[11]));
//					dbcommandWrapper.AddInParameter("@getCardSeq",DbType.Int16,Convert.ToInt16(dataFrame.frameData[9]));
//					dbcommandWrapper.AddInParameter("@fromMachine",DbType.Int16,Convert.ToInt16(dataFrame.srcAddr));
//					dbcommandWrapper.AddInParameter("@isNightCheck",DbType.Boolean,Convert.ToBoolean(dataFrame.frameData[8]));
//					dbcommandWrapper.AddInParameter("@isManual",DbType.Boolean,isManual);
//					dbcommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
//
//					db.ExecuteNonQuery(dbcommandWrapper);
//
//					rowsAffected = Convert.ToInt32(dbcommandWrapper.GetParameterValue("@rowsAffected"));
//				}
//				else
//				{
//					throw new Exception("通讯帧出错");
//				}
//			}
//			catch(Exception ex)
//			{
//				throw ex;
//			}
//
//			return rowsAffected;
//		}

		public int InsertMorningCheckInfo(DataFrame dataFrame)
		{
			int rowsAffected = 0;

			try
			{
				if(dataFrame.frameData.Length == 11)//确认为晨检应答帧
				{
					Int16 classNumber = (Int16)(((dataFrame.frameData[1]/16)*10 + (dataFrame.frameData[1]%16))*100  
						+ dataFrame.frameData[0]);//计算学号

					DateTime checkTime = new DateTime(DateTime.Now.Year,DateTime.Now.Month,
						DateTime.Now.Day,dataFrame.frameData[2],dataFrame.frameData[3],
						dataFrame.frameData[4]);

					bool isManual = false;

					if(dataFrame.frameData[6]==6)
					{
						isManual = true;
					}

					CPTT.SystemFramework.Util.WriteLog(string.Format("number:{0},", classNumber),CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);

                    short state = Convert.ToInt16(dataFrame.frameData[8]);
                    if (state > 15)
                        return 0;

                    //FD 健康+警示
                    //FE 观察+警示
                    //FF 服药+警示
                    if (state == 253)
                    {
                        rowsAffected = DoInsertMorningCheckInfo(
                            classNumber,
                            checkTime,
                            0,
                            dataFrame.frameData[6],
                            dataFrame.srcAddr,
                            Convert.ToBoolean(dataFrame.frameData[5]),
                            isManual);
                        rowsAffected = DoInsertMorningCheckInfo(
                            classNumber,
                            checkTime,
                            4,
                            dataFrame.frameData[6],
                            dataFrame.srcAddr,
                            Convert.ToBoolean(dataFrame.frameData[5]),
                            isManual);
                    }
                    else if (state == 254)
                    {
                        rowsAffected = DoInsertMorningCheckInfo(
                            classNumber,
                            checkTime,
                            0,
                            dataFrame.frameData[6],
                            dataFrame.srcAddr,
                            Convert.ToBoolean(dataFrame.frameData[5]),
                            isManual);
                        rowsAffected = DoInsertMorningCheckInfo(
                            classNumber,
                            checkTime,
                            2,
                            dataFrame.frameData[6],
                            dataFrame.srcAddr,
                            Convert.ToBoolean(dataFrame.frameData[5]),
                            isManual);
                        rowsAffected = DoInsertMorningCheckInfo(
                            classNumber,
                            checkTime,
                            4,
                            dataFrame.frameData[6],
                            dataFrame.srcAddr,
                            Convert.ToBoolean(dataFrame.frameData[5]),
                            isManual);
                    }
                    else if (state == 255)
                    {
                        rowsAffected = DoInsertMorningCheckInfo(
                            classNumber,
                            checkTime,
                            0,
                            dataFrame.frameData[6],
                            dataFrame.srcAddr,
                            Convert.ToBoolean(dataFrame.frameData[5]),
                            isManual);
                        rowsAffected = DoInsertMorningCheckInfo(
                            classNumber,
                            checkTime,
                            3,
                            dataFrame.frameData[6],
                            dataFrame.srcAddr,
                            Convert.ToBoolean(dataFrame.frameData[5]),
                            isManual);
                        rowsAffected = DoInsertMorningCheckInfo(
                            classNumber,
                            checkTime,
                            4,
                            dataFrame.frameData[6],
                            dataFrame.srcAddr,
                            Convert.ToBoolean(dataFrame.frameData[5]),
                            isManual);
                    }
                    else
                    {
                        rowsAffected = DoInsertMorningCheckInfo(
                            classNumber,
                            checkTime,
                            state,
                            dataFrame.frameData[6],
                            dataFrame.srcAddr,
                            Convert.ToBoolean(dataFrame.frameData[5]),
                            isManual);
                    }
				}
				else
				{
					throw new Exception("通讯帧出错");
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

        private int DoInsertMorningCheckInfo(short stuNo, DateTime date, short state, short cardSeq, short machine, bool isNightCheck, bool isManual)
        {
            int rowsAffected = 0;
            DBCommandWrapper dbcommandWrapper = db.GetStoredProcCommandWrapper("FillCheckInfo");

            dbcommandWrapper.AddInParameter("@getStuNumber", DbType.Int16, stuNo);
            dbcommandWrapper.AddInParameter("@getTime", DbType.DateTime, date);
            dbcommandWrapper.AddInParameter("@getState", DbType.Int16, state);
            dbcommandWrapper.AddInParameter("@getCardSeq", DbType.Int16, cardSeq);
            dbcommandWrapper.AddInParameter("@fromMachine", DbType.Int16, machine);
            dbcommandWrapper.AddInParameter("@isNightCheck", DbType.Boolean, isNightCheck);
            dbcommandWrapper.AddInParameter("@isManual", DbType.Boolean, isManual);
            dbcommandWrapper.AddOutParameter("@rowsAffected", DbType.Int32, 4);

            db.ExecuteNonQuery(dbcommandWrapper);

            rowsAffected = Convert.ToInt32(dbcommandWrapper.GetParameterValue("@rowsAffected"));
            return rowsAffected;
        }

		#region IDisposable 成员

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true); 
		}

		protected virtual void Dispose(bool disposing)
		{
			if (! disposing)
				return; 

			if (db != null)
			{
				db = null;
			}
		}

		#endregion
	}
}
