using System;
using System.Data;
using RexDataProtector;
using CPTT.SystemFramework;
using CPTT.DataAccess;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Drawing;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// UtilSystem 的摘要说明。
	/// </summary>
	public class UtilSystem
	{

		public UtilSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public int GetMaxClients()
		{
			using ( UtilDataAccess utilDataAccess = new UtilDataAccess() )
			{
				try
				{
					string encryptMaxClients = utilDataAccess.GetMaxClients();

					string maxClients = new DataProtector().InitInfoDecryp(encryptMaxClients);

					int retValue = Convert.ToInt32(maxClients.Substring(0,maxClients.IndexOf("#")));
					
					return retValue;

				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public int GetCurrentClients()
		{
			using ( UtilDataAccess utilDataAccess = new UtilDataAccess() )
			{
				try
				{
					return utilDataAccess.GetCurrentClients();
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public bool IsSessionClient(string role)
		{
			using ( UtilDataAccess utilDataAccess = new UtilDataAccess() )
			{
				try
				{
					return utilDataAccess.IsSessionClient(role,Util.MacAddress);
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return false;
				}
			}
		}

		public int UpdateSessionClient(string role)
		{
			using ( UtilDataAccess utilDataAccess = new UtilDataAccess() )
			{
				try
				{
					return utilDataAccess.UpdateSessionClient(role,Util.MacAddress);
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public int InsertSessionClient(string role)
		{
			using ( UtilDataAccess utilDataAccess = new UtilDataAccess() )
			{
				try
				{
					return utilDataAccess.InsertSessionClient(role,Util.IPAddress,Util.MacAddress);
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public DataTable GetSessionDetails()
		{
			using ( UtilDataAccess utilDataAccess = new UtilDataAccess() )
			{
				try
				{
					return utilDataAccess.GetSessionDetails();
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public int DeleteSessionClient(string macAddr)
		{
			using ( UtilDataAccess utilDataAccess = new UtilDataAccess() )
			{
				try
				{
					return utilDataAccess.DeleteSessionClient(macAddr);
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public string GetDBVersion()
		{
			using (UtilDataAccess utilDataAccess = new UtilDataAccess())
			{
				try
				{
					return utilDataAccess.GetDbVersion();
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
					return string.Empty;
				}
			}
		}

		public DataSet GetUploadData()
		{
			using (UtilDataAccess utilDataAccess = new UtilDataAccess())
			{
				try
				{
					DateTime begTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
					DateTime endTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
					return utilDataAccess.GetUploadData(begTime, endTime);
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

        public DataTable GetUploadDataForYlm()
        {
            using (UtilDataAccess utilDataAccess = new UtilDataAccess())
            {
                try
                {
                    DateTime begTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
                    DateTime endTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                    return utilDataAccess.GetUploadDataForYlm(begTime, endTime).Tables[0];
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
                    return null;
                }
            }
        }

        public DataTable GetUploadDataForYlm_teacher()
        {
            using (UtilDataAccess utilDataAccess = new UtilDataAccess())
            {
                try
                {
                    DateTime begTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
                    DateTime endTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                    return utilDataAccess.GetUploadDataForYlm_teacher(begTime, endTime).Tables[0];
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
                    return null;
                }
            }
        }

		public DataTable GetUploadDataForXDD()
		{
			using (UtilDataAccess utilDataAccess = new UtilDataAccess())
			{
				try
				{
					DateTime begTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
					DateTime endTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
					return utilDataAccess.GetUploadDataForXDD(begTime, endTime).Tables[0];
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetUploadInfoForXDD()
		{
			using (UtilDataAccess utilDataAccess = new UtilDataAccess())
			{
				try
				{
					return utilDataAccess.GetUploadInfoForXDD();
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public void UpdateUploadState(string studentId)
		{
			using (UtilDataAccess utilDataAccess = new UtilDataAccess())
			{
				try
				{
					utilDataAccess.UpdateUploadState(studentId);
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

        public Tuple<int, int, int, int, int, string> GetDownloadRevAndID()
        {
            using (UtilDataAccess utilDataAccess = new UtilDataAccess())
            {
                try
                {
                    return utilDataAccess.GetDownloadRevAndID();
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
                    return new Tuple<int, int, int, int, int, string>(0, 0, 0, 0, 0, string.Empty);
                }
            }
        }

        public int GetDownloadRev(string tag, int type)
        {
            using (UtilDataAccess utilDataAccess = new UtilDataAccess())
            {
                try
                {
                    return utilDataAccess.GetDownloadRev(tag, type);
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
                    return 0;
                }
            }
        }

        public bool InsertDownloadStudentInfo(string id, int grade, string gardeName, string gradeRemark, int @class, string className, string name, int number, DateTime birthday, string gender, string type, DateTime enterDate, byte hasLeftSchool)
        {
            using (UtilDataAccess utilDataAccess = new UtilDataAccess())
            {
                try
                {
                    return utilDataAccess.InsertDownloadStudentInfo(id, grade, gardeName, gradeRemark, @class, className, name, number, birthday, gender, type, enterDate, hasLeftSchool) >= 1;
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
                    return false;
                }
            }
        }

        public void InsertDefaultDeptAndDuty()
        {
            using (UtilDataAccess utilDataAccess = new UtilDataAccess())
            {
                try
                {
                    utilDataAccess.InsertDefaultDeptAndDuty();
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
                }
            }
        }

        public bool InsertDownloadTeacherInfo(string id, string dept, string duty, string name, int number, string gender)
        {
            using (UtilDataAccess utilDataAccess = new UtilDataAccess())
            {
                try
                {
                    return utilDataAccess.InsertDownloadTeacherInfo(id, dept, duty, name, number, gender) >= 1;
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
                    return false;
                }
            }
        }

        public void InsertDownloadLog(int rev, string data, int succCount, int totalCount, int type, string tag = "")
        {
            using (UtilDataAccess utilDataAccess = new UtilDataAccess())
            {
                try
                {
                    utilDataAccess.InsertDownloadLog(rev, data, succCount, totalCount, type, tag);
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
                }
            }
        }

        public void InsertDownloadCard(string stuID, string number, string owner)
        {
            using (UtilDataAccess utilDataAccess = new UtilDataAccess())
            {
                try
                {
                    utilDataAccess.InsertDownloadCard(stuID, number, owner);
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
                }
            }
        }

        public bool InsertSignIn(int number, DateTime time, byte state)
        {
            var result = false;
            using (UtilDataAccess utilDataAccess = new UtilDataAccess())
            {
                try
                {
                    result = utilDataAccess.InsertSignIn(number, time, state) >= 1;
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
                }
                return result;
            }
        }

        public void InsertGrowUpReportHistory(string gradeName, string className, string referrerID, int stuNumber, string recorderName, int type, string date, out int reportID)
        {
            reportID = 0;
            using (UtilDataAccess utilDataAccess = new UtilDataAccess())
            {
                try
                {
                    utilDataAccess.InsertGrowUpReportHistory(gradeName, className, referrerID, stuNumber, recorderName, type, date, out reportID);
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
                }
            }
        }

        public void InsertGrowUpReportDetail(int reportHistoryID, int stuNumber, string category, string item, string content, string picUrl, string dateStr)
        {
            using (UtilDataAccess utilDataAccess = new UtilDataAccess())
            {
                try
                {
                    var rawUrl = picUrl;
                    var date = DateTime.Parse(dateStr.Trim() + "-1");
                    var dir = AppDomain.CurrentDomain.BaseDirectory + string.Format("img\\{0}\\", date.ToString("yyyy"));
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    if (!string.IsNullOrEmpty(picUrl))
                    {
                        try
                        {
                            var imgFileName = new Util.HexStringConverter().ToString(
                                MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(string.Format("{0}{1}{2}{3}", date, stuNumber, category, picUrl))));
                            imgFileName += ".jpg";
                            try
                            {
                                if (!File.Exists(dir + imgFileName))
                                {
                                    var buffer = new WebClient().DownloadData(picUrl);
                                    using (var stream = new MemoryStream(buffer))
                                    {
                                        using (var img = Image.FromStream(stream))
                                        {
                                            img.Save(dir + imgFileName);
                                        }
                                    }
                                }
                            }
                            finally
                            {
                                picUrl = string.Format("\\img\\{0}\\", date.ToString("yyyy")) + imgFileName;
                            }
                        }
                        catch (Exception ex)
                        {
                            Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
                        }
                    }

                    utilDataAccess.InsertGrowUpReportDetail(reportHistoryID, category, item, content, picUrl, rawUrl);
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
                }
            }
        }

        public void InsertGrowUpCheckReportHistory(int stuNumber, string referrerID, string dateStr, out int reportID)
        {
            reportID = 0;
            using (UtilDataAccess utilDataAccess = new UtilDataAccess())
            {
                try
                {
                    DateTime date = DateTime.MinValue;
                    if (DateTime.TryParse(dateStr, out date))
                        utilDataAccess.InsertGrowUpCheckReportHistory(stuNumber, referrerID, date, out reportID);
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
                }
            }
        }

        public void InsertGrowUpCheckReportDetail(int reportHistoryID, int resultType, int type)
        {
            using (UtilDataAccess utilDataAccess = new UtilDataAccess())
            {
                try
                {
                    utilDataAccess.InsertGrowUpCheckReportDetail(reportHistoryID, resultType, type);
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
                }
            }
        }


		public bool CheckHasAssignedUniqueGardenID()
		{
			return new UtilDataAccess().HasAssignedUniqueGardenID();
		}

		public void AddUniqueGardenStatus(string gardenName)
		{
			string gardenID = Guid.NewGuid().ToString();
			new UtilDataAccess().AddUniqueStatus(gardenName, gardenID);
		}
	}
}
