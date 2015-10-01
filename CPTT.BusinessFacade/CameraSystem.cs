using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
    public class CameraSystem
    {
        public DataTable GetCameraInfo()
        {
            DataTable dt = null;
            try
            {
                dt = new CameraDataAccess().GetCameraInfo();
            }
            catch (Exception ex)
            {
                Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
            }
            return dt;
        }

        public void AddOrUpdateCamera(dynamic camera)
        {
            try
            {
                new CameraDataAccess().AddOrUpdateCamera(camera);
            }
            catch (Exception ex)
            {
                Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
            }
        }

        public void DeleteCamera(int idx)
        {
            try
            {
                new CameraDataAccess().DeleteCamera(idx);
            }
            catch (Exception ex)
            {
                Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
            }
        }

        public DataTable GetCheckInfo(int number, string name, string beginTime, string endTime, int checkType)
        {
            DataTable dt = null;
            try
            {
                dt = new CameraDataAccess().GetCheckInfo(number, name, beginTime, endTime, checkType);
            }
            catch (Exception ex)
            {
                Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
            }
            return dt;
        }
    }
}
