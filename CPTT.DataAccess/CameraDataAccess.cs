using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CPTT.DataAccess
{
    public class CameraDataAccess
    {
        public DataTable GetCameraInfo()
        {
            DataTable dt = null;
            var database = DatabaseFactory.CreateDatabase();
            using (var wrapper = database.GetSqlStringCommandWrapper(@"
SELECT idx, cameraName, CAST(machineNo AS VARCHAR) + '号门口机' AS machineName, '不在监控' AS [state], cameraAddr, cameraStream, cameraEncoding, credentials, '' AS op1, '' AS op2 
FROM CameraInfo ORDER BY machineNo"))
            {
                var ds = database.ExecuteDataSet(wrapper);
                if (ds.Tables.Count >= 1)
                    dt = ds.Tables[0];
                return dt;
            }
        }

        public void AddOrUpdateCamera(dynamic camera)
        {
            var database = DatabaseFactory.CreateDatabase();
            using (var wrapper = database.GetSqlStringCommandWrapper(@"
IF NOT EXISTS(SELECT * FROM CameraInfo WHERE idx = @idx)
BEGIN
	INSERT INTO CameraInfo
	VALUES(@machineNo, @cameraName, @cameraAddr, @cameraStream, @cameraEncoding, @credentials)
END
ELSE
BEGIN
	UPDATE CameraInfo
	SET machineNo = @machineNo, cameraName = @cameraName, cameraAddr = @cameraAddr, cameraStream = @cameraStream, cameraEncoding = @cameraEncoding, credentials = @credentials
	WHERE idx = @idx
END"))
            {
                wrapper.AddInParameter("@idx", DbType.Int32, camera.idx);
                wrapper.AddInParameter("@machineNo", DbType.Int32, camera.MachineNo);
                wrapper.AddInParameter("@cameraName", DbType.String, camera.Name);
                wrapper.AddInParameter("@cameraAddr", DbType.String, camera.Addr);
                wrapper.AddInParameter("@cameraStream", DbType.String, camera.Stream);
                wrapper.AddInParameter("@cameraEncoding", DbType.String, camera.Encoding);
                wrapper.AddInParameter("@credentials", DbType.String, camera.Credentials);
                database.ExecuteNonQuery(wrapper);
            }
        }

        public void DeleteCamera(int idx)
        {
            var database = DatabaseFactory.CreateDatabase();
            using (var wrapper = database.GetSqlStringCommandWrapper(@"DELETE FROM CameraInfo WHERE idx = @idx"))
            {
                wrapper.AddInParameter("@idx", DbType.Int32, idx);
                database.ExecuteNonQuery(wrapper);
            }
        }

        public DataTable GetCheckInfo(int number, string name, string beginTime, string endTime, int checkType)
        {
            DataTable dt = null;
            var database = DatabaseFactory.CreateDatabase();
            using (var wrapper = database.GetSqlStringCommandWrapper(string.Format(@"IF {0} = 0
BEGIN
	SELECT flow_stuFlowEnterDate, flow_stuEnterFromMachine 
	FROM Student_DataFlow INNER JOIN Student_BasicInfo ON flow_stuBasicID = info_stuID
	WHERE flow_stuFlowEnterDate BETWEEN @beginTime AND @endTime AND (info_stuNumber = @number OR info_stuName = @name)
END
ELSE
BEGIN
	SELECT flow_stuFlowBackDate, flow_stuBackFromMachine 
	FROM Student_DataFlow INNER JOIN Student_BasicInfo ON flow_stuBasicID = info_stuID
	WHERE flow_stuFlowBackDate BETWEEN @beginTime AND @endTime AND (info_stuNumber = @number OR info_stuName = @name)
END", checkType)))
            {
                wrapper.AddInParameter("@number", DbType.Int32, number);
                wrapper.AddInParameter("@name", DbType.String, name);
                wrapper.AddInParameter("@beginTime", DbType.String, beginTime);
                wrapper.AddInParameter("@endTime", DbType.String, endTime);
                var ds = database.ExecuteDataSet(wrapper);
                if (ds.Tables.Count > 0)
                    dt = ds.Tables[0];
                return dt;
            }
        }
    }
}
