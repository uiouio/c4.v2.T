using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CPTT.DataAccess
{
	/// <summary>
	/// UtilDataAccess 的摘要说明。
	/// </summary>
	public class UtilDataAccess:IDisposable
	{
		private Database db = null;
		private string sqlMaxClients = "SELECT session_MaxValues FROM Application_MaxSession WITH(NOLOCK)";
		private string sqlCurrentClients = "SELECT COUNT(*) FROM Application_SessionDetails WITH (NOLOCK)";
		private string sqlSessionClient = "SELECT * FROM Application_SessionDetails WITH (NOLOCK) WHERE session_LoginUser=";

		public UtilDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

			

			db = DatabaseFactory.CreateDatabase();
		}

		public string GetMaxClients()
		{
			string maxClients = string.Empty;

			DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(sqlMaxClients);
			IDataReader dataReader = db.ExecuteReader(dbCommandWrapper);

			if ( dataReader.Read() )
			{
				maxClients = dataReader.GetString(0);

				dataReader.Close();

				return maxClients;
			}
			else
			{
				dataReader.Close();
				return string.Empty;
			}
		}

		public int GetCurrentClients()
		{
			int currentClients = 0;

			DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(sqlCurrentClients);
			IDataReader dataReader = db.ExecuteReader(dbCommandWrapper);

			if ( dataReader.Read() )
			{
				currentClients = dataReader.GetInt32(0);

				dataReader.Close();

				return currentClients;
			}
			else
			{
				dataReader.Close();
				return -1;
			}
		}

		public bool IsSessionClient(string role,string macAddr)
		{
			sqlSessionClient += "'"+role+"' AND session_LoginMac = '"+macAddr+"'";

			DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(sqlSessionClient);
			IDataReader dataReader = db.ExecuteReader(dbCommandWrapper);

			if ( dataReader.Read() )
			{
				dataReader.Close();

				return true;
			}
			else 
			{
				dataReader.Close();

				return false;
			}
		}

		public int InsertSessionClient(string role,string ipAddr,string macAddr )
		{
			DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("InsertSessionClient");
			dbCommandWrapper.AddInParameter("@role",DbType.String,role);
			dbCommandWrapper.AddInParameter("@ipAddr",DbType.String,ipAddr);
			dbCommandWrapper.AddInParameter("@macAddr",DbType.String,macAddr);
			dbCommandWrapper.AddOutParameter("@retVal",DbType.Int32,4);
			db.ExecuteNonQuery(dbCommandWrapper);

			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@retVal"));
		}

		public int UpdateSessionClient(string role,string macAddr)
		{
			DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("UpdateSessionClient");
			dbCommandWrapper.AddInParameter("@role",DbType.String,role);
			dbCommandWrapper.AddInParameter("@macAddr",DbType.String,macAddr);
			dbCommandWrapper.AddOutParameter("@retVal",DbType.Int32,4);
			db.ExecuteNonQuery(dbCommandWrapper);

			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@retVal"));
		}

		public DataTable GetSessionDetails()
		{
			DBCommandWrapper dbCommandwrapper = db.GetStoredProcCommandWrapper("GetSessionDetails");

			return db.ExecuteDataSet(dbCommandwrapper).Tables[0];
		}

		public int DeleteSessionClient(string macAddr)
		{
			DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("DeleteSessionClient");
			dbCommandWrapper.AddInParameter("@macAddr",DbType.String,macAddr);
			dbCommandWrapper.AddOutParameter("@retVal",DbType.Int16,4);
			db.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@retVal"));
		}

		public DataSet GetUploadData(DateTime begTime, DateTime endTime)
		{
			DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetUploadData");
			dbCommandWrapper.AddInParameter("@begTime", DbType.String, begTime.ToString("yyyy-MM-dd HH:mm:ss"));
			dbCommandWrapper.AddInParameter("@endTime", DbType.String, endTime.ToString("yyyy-MM-dd HH:mm:ss"));
			return db.ExecuteDataSet(dbCommandWrapper);
		}

		public DataSet GetUploadDataForXDD(DateTime begTime, DateTime endTime)
		{
			DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetUploadDataForXDD");
			dbCommandWrapper.AddInParameter("@begTime", DbType.String, begTime.ToString("yyyy-MM-dd HH:mm:ss"));
			dbCommandWrapper.AddInParameter("@endTime", DbType.String, endTime.ToString("yyyy-MM-dd HH:mm:ss"));
			return db.ExecuteDataSet(dbCommandWrapper);
		}

		public DataSet GetUploadInfoForXDD()
		{
			DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetUploadInfoForXDD");
			return db.ExecuteDataSet(dbCommandWrapper);
		}

        public Tuple<int, int, int, int, int, string> GetDownloadRevAndID()
        {
            DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(
@"SELECT TOP 1 rev FROM DownloadLog WHERE [type] = 0 ORDER BY idx DESC;
SELECT TOP 1 rev FROM DownloadLog WHERE [type] = 1 ORDER BY idx DESC; 
SELECT TOP 1 rev FROM DownloadLog WHERE [type] = 2 ORDER BY idx DESC;
SELECT TOP 1 rev FROM DownloadLog WHERE [type] = 3 ORDER BY idx DESC;
SELECT TOP 1 rev FROM DownloadLog WHERE [type] = 4 ORDER BY idx DESC;
SELECT TOP 1 info_gardenID FROM Garden_info");
            var reader = db.ExecuteReader(dbCommandWrapper);
            int rev1 = 0;
            int rev2 = 0;
            int rev3 = 0;
            int rev4 = 0;
            int rev5 = 0;
            string gardenID = string.Empty;
            if (reader.Read())
            {
                rev1 = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            }
            if (reader.NextResult())
            {
                if (reader.Read())
                {
                    rev2 = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                }
            }
            if (reader.NextResult())
            {
                if (reader.Read())
                {
                    rev3 = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                }
            }
            if (reader.NextResult())
            {
                if (reader.Read())
                {
                    rev4 = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                }
            }
            if (reader.NextResult())
            {
                if (reader.Read())
                {
                    rev5 = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                }
            }
            if (reader.NextResult())
            {
                if (reader.Read())
                {
                    gardenID = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                }
            }

            return new Tuple<int, int, int, int, int, string>(rev1, rev2, rev3, rev4, rev5, gardenID);
        }

        public int GetDownloadRev(string tag, int type)
        {
            DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper("SELECT TOP 1 rev FROM DownloadLog WHERE [type] = @type and [tag] = @tag ORDER BY idx DESC;");
            dbCommandWrapper.AddInParameter("@type", DbType.Int32, type);
            dbCommandWrapper.AddInParameter("@tag", DbType.String, tag);
            var val = db.ExecuteScalar(dbCommandWrapper);
            if (val == null)
                return 0;
            else return Convert.ToInt32(val);
        }

        public int InsertDownloadStudentInfo(string id, int grade, string gardeName, string gradeRemark, int @class, string className, string name, int number, DateTime birthday, string gender, string type, DateTime enterDate, byte hasLeftSchool)
        {
            DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("InsertDownloadStudentInfo");
            dbCommandWrapper.AddInParameter("@getID", DbType.String, id);
            dbCommandWrapper.AddInParameter("@getGrade", DbType.Int32, grade);
            dbCommandWrapper.AddInParameter("@getGradeName", DbType.String, gardeName);
            dbCommandWrapper.AddInParameter("@getGradeRemark", DbType.String, gradeRemark);
            dbCommandWrapper.AddInParameter("@getClass", DbType.Int32, @class);
            dbCommandWrapper.AddInParameter("@getClassName", DbType.String, className);
            dbCommandWrapper.AddInParameter("@getName", DbType.String, name);
            dbCommandWrapper.AddInParameter("@getNumber", DbType.Int32, number);
            dbCommandWrapper.AddInParameter("@getBirthday", DbType.DateTime, birthday);
            dbCommandWrapper.AddInParameter("@getGender", DbType.String, gender);
            dbCommandWrapper.AddInParameter("@getType", DbType.String, type);
            dbCommandWrapper.AddInParameter("@getEnterDate", DbType.DateTime, enterDate);
            dbCommandWrapper.AddInParameter("@getLeftSchool", DbType.Byte, hasLeftSchool);
            dbCommandWrapper.AddOutParameter("@rowsAffected", DbType.Int32, 4);
            db.ExecuteNonQuery(dbCommandWrapper);
            var rowsAffected = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
            return rowsAffected;
        }

        public void InsertDefaultDeptAndDuty()
        {
            DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(@"
DECLARE @v INT
DECLARE @c INT
SELECT @v = info_gradeNumber FROM Grade_Info WHERE info_gradeName = '教务'
IF @v IS NULL
BEGIN
	SELECT @v = MIN(info_gradeNumber) FROM Grade_Info
	IF @v = 1
	BEGIN
		SET @v = -1
	END
	ELSE
	BEGIN
		SET @v = @v - 1
	END
	INSERT INTO Grade_info
	VALUES(@v, '教务','教务')
END

SELECT @c = info_classNumber FROM Class_info WHERE info_className = '教务'
IF @c IS NULL
BEGIN
	SELECT @c = MIN(info_classNumber) FROM Class_info
	IF @c = 1
	BEGIN
		SET @c = -1
	END
	ELSE
	BEGIN
		SET @c = @c - 1
	END
	INSERT INTO Class_info
	VALUES(@c, '教务',@v, -1, '教务')
END
");
            db.ExecuteNonQuery(dbCommandWrapper);
        }

        public int InsertDownloadTeacherInfo(string id, string dept, string duty, string name, int number, string gender)
        {
            DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(@"
IF NOT EXISTS(SELECT * FROM Teach_Base_Info WHERE T_Number = @number)
BEGIN
	INSERT INTO Teach_Base_Info(T_ID, T_Number, T_Name, T_Sex, T_Merrige, T_Addr, T_Career, T_Home_Tel, T_Phone, T_Work_Tel, T_Depart, T_Duty, T_Technical_Post, T_Level, T_Work_Time, T_Enter_Time, T_hasLeftSchool, T_Image)
	VALUES(@id, @number, @name, @gender, '否', NULL, '本科', NULL, NULL, '', @dept, @duty, '高级职称','一级教师', GETDATE(), GETDATE(), 0, NULL)

    IF NOT EXISTS(SELECT * FROM Users WHERE UserName = CAST(@number AS VARCHAR))
    BEGIN
	    INSERT INTO Users(UserName, [Password])
	    VALUES(CAST(@number AS VARCHAR), 0x7110EDA4D09E062AA5E4A390B0A572AC0D2C0220)
        INSERT INTO UserRoles
	    VALUES(@@IDENTITY, 5)
    END
END");
            dbCommandWrapper.AddInParameter("@id", DbType.String, id);
            dbCommandWrapper.AddInParameter("@number", DbType.Int32, number);
            dbCommandWrapper.AddInParameter("@name", DbType.String, name);
            dbCommandWrapper.AddInParameter("@gender", DbType.String, gender);
            dbCommandWrapper.AddInParameter("@dept", DbType.String, dept);
            dbCommandWrapper.AddInParameter("@duty", DbType.String, @duty);
            db.ExecuteNonQuery(dbCommandWrapper);
            return dbCommandWrapper.RowsAffected;
            //var rowsAffected = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
        }

        public void InsertDownloadLog(int rev, string data, int succCount, int totalCount, int type, string tag)
        {
            DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(@"
IF NOT EXISTS(SELECT * FROM DownloadLog WHERE rev >= @rev AND type = @type)
BEGIN
	INSERT INTO DownloadLog(rev, data, succCount, totalCount, [date], [type], [tag])
	VALUES(@rev, @data, @succCount, @totalCount, GETDATE(), @type, @tag)
END");
            dbCommandWrapper.AddInParameter("@rev", DbType.Int32, rev);
            dbCommandWrapper.AddInParameter("@data", DbType.String, data);
            dbCommandWrapper.AddInParameter("@succCount", DbType.Int32, succCount);
            dbCommandWrapper.AddInParameter("@totalCount", DbType.Int32, totalCount);
            dbCommandWrapper.AddInParameter("@type", DbType.Int32, type);
            dbCommandWrapper.AddInParameter("@tag", DbType.String, tag);
            db.ExecuteNonQuery(dbCommandWrapper);
        }

        public int InsertSignIn(int number, DateTime time, byte state)
        {
            DBCommandWrapper dbcommandWrapper = db.GetStoredProcCommandWrapper("FillCheckInfo");

            dbcommandWrapper.AddInParameter("@getStuNumber", DbType.Int16, number);
            dbcommandWrapper.AddInParameter("@getTime", DbType.DateTime, time);
            dbcommandWrapper.AddInParameter("@getState", DbType.Int16, state);
            dbcommandWrapper.AddInParameter("@getCardSeq", DbType.Int16, 1);
            dbcommandWrapper.AddInParameter("@fromMachine", DbType.Int16, 1);
            dbcommandWrapper.AddInParameter("@isNightCheck", DbType.Boolean, state);
            dbcommandWrapper.AddInParameter("@isManual", DbType.Boolean, 1);
            dbcommandWrapper.AddOutParameter("@rowsAffected", DbType.Int32, 4);

            db.ExecuteNonQuery(dbcommandWrapper);

            return Convert.ToInt32(dbcommandWrapper.GetParameterValue("@rowsAffected"));
        }

        public void InsertDownloadCard(string stuID, string number, string owner)
        {
            DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(string.Format("SELECT info_stuCardSeq FROM Student_CardInfo WHERE info_stuBasicID = '{0}' ORDER BY info_stuCardSeq", stuID));
            var reader = db.ExecuteReader(dbCommandWrapper);
            var list = new List<int>();
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    list.Add(reader.GetInt16(0));
                }
            }
            int seq = 1;
            if (list.Count < 5)
            {
                foreach (var val in list)
                {
                    if (val == seq)
                        seq++;
                    else
                    {
                        break;
                    }
                }
                dbCommandWrapper = db.GetStoredProcCommandWrapper("InsertDownloadCardInfo");
                dbCommandWrapper.AddInParameter("@stuID", DbType.String, stuID);
                dbCommandWrapper.AddInParameter("@number", DbType.String, number);
                dbCommandWrapper.AddInParameter("@owner", DbType.String, owner);
                dbCommandWrapper.AddInParameter("@seq", DbType.Int32, seq);
                db.ExecuteNonQuery(dbCommandWrapper);
            }
        }

        public void InsertGrowUpReportHistory(string gradeName, string className, string referrerID, int stuNumber, string recorderName, int type, string date, out int reportID)
        {
            reportID = 0;
            DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(
@"
DECLARE @stuName NVARCHAR(100)
SELECT @stuName = info_stuName FROM Student_BasicInfo WHERE info_stuNumber = @stuNumber AND info_stuHasLeftSchool = 0
IF @stuName IS NULL
    SET @stuName = @stuNumber

IF NOT EXISTS(SELECT * FROM GrowUpReportHistory WHERE stuNumber = @stuNumber AND DATEDIFF(mm, recordTime, @date) = 0)
BEGIN
INSERT INTO GrowUpReportHistory
VALUES(@gradeName, @className, @referrerID, @stuNumber, @stuName, @recorderName, @type, @date)
END
ELSE
BEGIN
UPDATE GrowUpReportHistory
SET gradeName = @gradeName, className = @className, referrerID = @referrerID, stuNumber = @stuNumber, recorderName = @recorderName, [type] = @type, stuName = @stuName
WHERE stuNumber = @stuNumber AND DATEDIFF(mm, recordTime, @date) = 0
END
SELECT MAX(idx) AS reportID FROM GrowUpReportHistory WHERE stuNumber = @stuNumber AND DATEDIFF(mm, recordTime, @date) = 0");
            DateTime recordTime = DateTime.MinValue;
            if (DateTime.TryParse(date.Trim() + "-1", out recordTime))
            {
                dbCommandWrapper.AddInParameter("@gradeName", DbType.String, gradeName);
                dbCommandWrapper.AddInParameter("@className", DbType.String, className);
                dbCommandWrapper.AddInParameter("@referrerID", DbType.String, referrerID);
                dbCommandWrapper.AddInParameter("@stuNumber", DbType.Int32, stuNumber);
                dbCommandWrapper.AddInParameter("@recorderName", DbType.String, recorderName);
                dbCommandWrapper.AddInParameter("@type", DbType.Int32, type);
                dbCommandWrapper.AddInParameter("@date", DbType.DateTime, recordTime);
                reportID = Convert.ToInt32(db.ExecuteDataSet(dbCommandWrapper).Tables[0].Rows[0][0]);
            }
        }

        public void InsertGrowUpReportDetail(int reportHistoryID, string category, string item, string content, string picUrl, string rawUrl)
        {
            DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(
@"
IF NOT EXISTS(SELECT * FROM GrowUpReportDetail WHERE reportHistoryID = @reportHistoryID AND category = @category AND item = @item)
BEGIN
	INSERT INTO GrowUpReportDetail
	VALUES(@reportHistoryID, @category, @item, @content, @picUrl, @rawUrl)
END
ELSE
BEGIN
	UPDATE GrowUpReportDetail
	SET content = @content, picUrl = @picUrl
	WHERE reportHistoryID = @reportHistoryID AND category = @category AND item = @item
END
");
            dbCommandWrapper.AddInParameter("@reportHistoryID", DbType.Int32, reportHistoryID);
            dbCommandWrapper.AddInParameter("@category", DbType.String, category);
            dbCommandWrapper.AddInParameter("@item", DbType.String, item);
            dbCommandWrapper.AddInParameter("@content", DbType.String, content);
            dbCommandWrapper.AddInParameter("@picUrl", DbType.String, picUrl);
            dbCommandWrapper.AddInParameter("@rawUrl", DbType.String, rawUrl);
            db.ExecuteNonQuery(dbCommandWrapper);
        }

        public void InsertGrowUpCheckReportHistory(int stuNumber, string referrerID, DateTime date, out int reportID)
        {
            reportID = 0;
            DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(
@"DECLARE @gradeName NVARCHAR(100)
DECLARE @className NVARCHAR(100)
DECLARE @stuName NVARCHAR(100)

IF NOT EXISTS(SELECT * FROM GrowUpCheckReportHistory WHERE stuNumber = @stuNumber AND DATEDIFF(dd, @date, recordTime) = 0)
BEGIN
    SELECT @gradeName = info_gradeName, @className = info_className, @stuName = info_stuName
    FROM Student_BasicInfo INNER JOIN Class_Info ON info_stuClass = info_classNumber AND info_stuGrade = info_gradeNumber INNER JOIN Grade_Info g ON info_stuGrade = g.info_gradeNumber
    WHERE info_stuNumber = @stuNumber AND info_stuHasLeftSchool = 0

    INSERT INTO GrowUpCheckReportHistory
    VALUES(@gradeName, @className, @referrerID, @stuNumber, @stuName, @date)
END

SELECT MAX(idx) AS reportID FROM GrowUpCheckReportHistory WHERE stuNumber = @stuNumber AND DATEDIFF(mm, recordTime, @date) = 0");
            dbCommandWrapper.AddInParameter("@referrerID", DbType.String, referrerID);
            dbCommandWrapper.AddInParameter("@stuNumber", DbType.Int32, stuNumber);
            dbCommandWrapper.AddInParameter("@date", DbType.DateTime, date);
            reportID = Convert.ToInt32(db.ExecuteDataSet(dbCommandWrapper).Tables[0].Rows[0][0]);
        }

        public void InsertGrowUpCheckReportDetail(int reportHistoryID, int resultType, int type)
        {
            DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(
@"
IF NOT EXISTS(SELECT * FROM GrowUpCheckReportDetail WHERE reportHistoryID = @reportHistoryID and type = @type)
BEGIN
	INSERT INTO GrowUpCheckReportDetail
	VALUES(@reportHistoryID, @resultType, @type)
END
ELSE
BEGIN
	UPDATE GrowUpCheckReportDetail
	SET resultType = @resultType
	WHERE reportHistoryID = @reportHistoryID AND type = @type
END
");
            dbCommandWrapper.AddInParameter("@reportHistoryID", DbType.Int32, reportHistoryID);
            dbCommandWrapper.AddInParameter("@resultType", DbType.Int32, resultType);
            dbCommandWrapper.AddInParameter("@type", DbType.Int32, type);
            db.ExecuteNonQuery(dbCommandWrapper);
        }

        public DataSet GetUploadDataForYlm(DateTime begTime, DateTime endTime)
        {
            DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(@"
SELECT info_gardenID AS gardenID, flow_stuBasicID AS stuID,info_machineAddr,flow_stuFlowEnterState,flow_stuFlowBackState,flow_stuFlowID as idx, flow_stuEnterCardNumber,flow_stuFlowEnterDate,efs.state_flowStateName,flow_stuModify,info_stuNumber,flow_stuFlowBackDate, flow_stuBackCardNumber
FROM dbo.Garden_Info, student_dataflow INNER JOIN student_basicinfo ON flow_stuBasicID = info_stuid INNER JOIN class_info ci ON CONVERT(CHAR(1), info_stugrade) + 
	CONVERT(CHAR(1), info_stuclass) = info_machineaddr INNER JOIN grade_info gi ON ci.info_gradeNumber = gi.info_gradeNumber
	INNER JOIN dbo.Student_FlowState efs ON flow_stuflowenterstate = efs.state_flowstate LEFT JOIN Student_FlowState bfs ON flow_stuflowbackstate = bfs.state_flowstate
WHERE flow_curRecTime BETWEEN @begTime AND @endTime AND flow_stuFlowEnterState in (0, 2, 3)");
            dbCommandWrapper.AddInParameter("@begTime", DbType.String, begTime.ToString("yyyy-MM-dd HH:mm:ss"));
            dbCommandWrapper.AddInParameter("@endTime", DbType.String, endTime.ToString("yyyy-MM-dd HH:mm:ss"));
            return db.ExecuteDataSet(dbCommandWrapper);
        }

        public DataSet GetUploadDataForYlm_teacher(DateTime begTime, DateTime endTime)
        {
            DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(@"
SELECT info_gardenID AS gardenID, teaflow_id AS idx, teaflow_cardnumber, teaflow_date, teaflow_state, T_Number FROM dbo.Garden_Info, teacher_flow INNER JOIN Teach_Base_Info ON teaflow_teaid=T_ID  WHERE teaflow_date BETWEEN @begTime AND @endTime");
            dbCommandWrapper.AddInParameter("@begTime", DbType.String, begTime.ToString("yyyy-MM-dd HH:mm:ss"));
            dbCommandWrapper.AddInParameter("@endTime", DbType.String, endTime.ToString("yyyy-MM-dd HH:mm:ss"));
            return db.ExecuteDataSet(dbCommandWrapper);
        } 

		public void UpdateUploadState(string studentId)
		{
			DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("UpdateUploadState");
			dbCommandWrapper.AddInParameter("@studentId", DbType.String, studentId);
			db.ExecuteNonQuery(dbCommandWrapper);
		}

		public string GetDbVersion()
		{
			DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetDbVersion");
			DataSet dsDbVersion = db.ExecuteDataSet(dbCommandWrapper);
			if (dsDbVersion.Tables[0] == null)
			{
				return "不是最新版本";
			}
			else
			{
				if (dsDbVersion.Tables[0].Rows.Count == 0)
				{
					return "不是最新版本";
				}
				else
				{
					return dsDbVersion.Tables[0].Rows[0]["db_version"].ToString();
				}
			}
		}

		public bool HasAssignedUniqueGardenID()
		{
			DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("CheckHasAssignedUniqueGardenID");
			dbCommandWrapper.AddOutParameter("@retval", DbType.Boolean, 1);
			db.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToBoolean(dbCommandWrapper.GetParameterValue("@retval"));
		}

		public void AddUniqueStatus(string gardenName, string gardenID)
		{
			DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("AddUniqueGardenStatus");
			dbCommandWrapper.AddInParameter("@gardenName", DbType.String, gardenName);
			dbCommandWrapper.AddInParameter("@gardenID", DbType.String, gardenID);
			db.ExecuteNonQuery(dbCommandWrapper);
		}

		public int GetAttendDays(DateTime beginDate, DateTime endDate)
		{
			DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetDays");
			dbCommandWrapper.AddInParameter("@beginDate", DbType.String, beginDate.ToString("yyyy-MM-dd 00:00:00"));
			dbCommandWrapper.AddInParameter("@endDate", DbType.String, endDate.ToString("yyyy-MM-dd 23:59:59"));
			return Convert.ToInt32(db.ExecuteScalar(dbCommandWrapper));
		}

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
	}
}
