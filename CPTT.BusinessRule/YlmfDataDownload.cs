using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using chuangzhiapi;
using System.Net;
using System.IO;

namespace CPTT.BusinessRule
{
    public class YlmfDataDownload
    {
        //梦育学生信息下载
        public class StudentInfoDownload
        {
            public static IList<StudentInfo> GetDownloadData(string gardenID, int rev, out DownloadLog log)
            {
                log = null;
                var result = Student.GetStudentList(gardenID, rev);
                var list = new List<StudentInfo>();
                if (!string.IsNullOrEmpty(result))
                {
                    log = JsonConvert.DeserializeObject<DownloadLog>(result);
                    log.Raw = result;
                    if (log != null)
                    {
                        if (log.result != null && log.result.list != null)
                        {
                            foreach (var student in log.result.list)
                                list.Add(StudentInfo.CheckAndGet(student));
                        }
                    }
                }
                return list;
            }

            public class DownloadLog
            {
                public string message { get; set; }
                public int lastupttime { get; set; }
                public int code { get; set; }
                public Log result { get; set; }
                [JsonIgnore]
                public string Raw { get; set; }
            }

            public class Log
            {
                public IList<StudentInfo> list { get; set; }
            }

            public class StudentInfo
            {
                [JsonIgnore]
                public string id { get; set; } //学生服务器端id，客户端需要保留该id，然后根据该ID结合delflg属性在表中执行判断是需要对学生数据做添加，更新或删除操作
                public string name { get; set; } //学生姓名
                public int gender { get; set; } //学生性别 0女 1男
                public string brithday { get; set; } //学生生日
                public string classtype { get; set; } //班级类型（全托，日托）
                public int classid { get; set; } //所在班级服务器端id
                public string className { get; set; } //所在班级名称
                public int gradeid { get; set; } //所在年级服务器端id
                public string gradename { get; set; } //所在年级名称
                public string joinTime { get; set; } //入园时间
                public string studentNum { get; set; } //学生学号,支持签到机器手动输入学号刷卡功能
                public string studentId { get; set; } //学生编号，签到时候附加值，36位的随机码
                public string pinyin { get; set; } //学生姓名拼音
                public int delflg { get; set; } //0表示学生状态正常，1表示该学生被从系统中删除，0值需要执行添加或更新操作，1需要执行删除操作
                public string gradetype { get; set; }
                public IList<StudentCard> cardList { get; set; }

                [JsonIgnore]
                public DateTime ValidBirthday
                {
                    get;
                    set;
                }

                [JsonIgnore]
                public string ValidGender
                {
                    get;
                    set;
                }

                [JsonIgnore]
                public string ValidEnterType
                {
                    get;
                    set;
                }

                [JsonIgnore]
                public DateTime ValidEnterDate
                {
                    get;
                    set;
                }

                [JsonIgnore]
                public byte HasLeftSchool
                {
                    get;
                    set;
                }

                [JsonIgnore]
                public int ValidStudentNumber
                {
                    get;
                    set;
                }

                [JsonIgnore]
                public bool IsValid
                {
                    get;
                    set;
                }

                public static StudentInfo CheckAndGet(StudentInfo student)
                {
                    DateTime birthday = DateTime.Now;
                    student.id = Guid.NewGuid().ToString();
                    if (string.IsNullOrEmpty(student.gradename))
                        return student;
                    if (string.IsNullOrEmpty(student.className))
                        return student;
                    if (string.IsNullOrEmpty(student.name))
                        return student;
                    if (student.gradeid < 1 || student.gradeid >= 9)
                        return student;
                    if (student.classid < 1 || student.classid > 9)
                        return student;
                    int number = 0;
                    if (!int.TryParse(student.studentNum, out number))
                        return student;
                    if (number < 1101 || number > 8999)
                        return student;
                    student.ValidStudentNumber = number;
                    if (string.IsNullOrEmpty(student.gradetype))
                        return student;
                    if (!student.gradetype.Equals("小班") &&
                        !student.gradetype.Equals("中班") &&
                        !student.gradetype.Equals("大班") &&
                        !student.gradetype.Equals("特色班") &&
                        !student.gradetype.Equals("托班"))
                        return student;

                    if (DateTime.TryParse(student.brithday, out birthday))
                    {
                        student.ValidBirthday = birthday;
                    }
                    student.ValidGender = student.gender == 0 ? "女" : "男";
                    if (!student.classtype.Equals("全托") && !student.classtype.Equals("日托"))
                        student.ValidEnterType = "日托";
                    else
                        student.ValidEnterType = student.classtype;
                    DateTime enterDate = DateTime.Now;
                    if (DateTime.TryParse(student.joinTime, out enterDate))
                    {
                        student.ValidEnterDate = enterDate;
                    }
                    student.HasLeftSchool = student.delflg == 0 ? (byte)0 : (byte)1;
                    student.IsValid = true;
                    return student;
                }
            }

            public class StudentCard
            {
                public string cardNum { get; set; } // 卡号
                public string owner { get; set; } // 拥有人
                public int delflg { get; set; } // 0表示学生拥有卡号，1表示该卡号不再属于该学生，0删除学生所有的卡信息，1更新或新增用户的卡信息
            }
        }

        //学生签到信息
        public class StudentSignInInfoDownload
        {
            public static IList<StudentSignInInfo> GetDownloadData(string gardenID, int rev, out DownloadLog log)
            {
                log = null;
                var result = chuangzhiapi.model.SyncSingin.SyncSinginOper(gardenID, rev);
                var list = new List<StudentSignInInfo>();
                if (!string.IsNullOrEmpty(result))
                {
                    log = JsonConvert.DeserializeObject<DownloadLog>(result);
                    log.Raw = result;
                    if (log != null)
                    {
                        if (log.result != null && log.result.list != null)
                        {
                            foreach (var signIn in log.result.list)
                            {
                                var @checked = StudentSignInInfo.CheckAndGet(signIn);
                                if (@checked.IsValid)
                                    list.Add(@checked);
                            }
                        }
                    }
                }
                return list;
            }

            public class DownloadLog
            {
                public string message { get; set; }
                public int lastupttime { get; set; }
                public Log result { get; set; }
                [JsonIgnore]
                public string Raw { get; set; }
            }

            public class Log
            {
                public IList<StudentSignInInfo> list { get; set; }
            }

            public class StudentSignInInfo
            {
                public string dayValStr { get; set; }
                public string singinTime { get; set; }
                public string singoutTime { get; set; }
                public string studentNum { get; set; }
                public string type { get; set; }

                [JsonIgnore]
                public DateTime Time { get; set; }
                [JsonIgnore]
                public int ValidStudentNumber { get; set; }
                [JsonIgnore]
                public byte Status { get; set; }
                [JsonIgnore]
                public bool IsValid
                {
                    get;
                    set;
                }

                public static StudentSignInInfo CheckAndGet(StudentSignInInfo signIn)
                {
                    int number = 0;
                    if (!int.TryParse(signIn.studentNum, out number))
                        return signIn;
                    if (number < 1101 || number > 8999)
                        return signIn;
                    signIn.ValidStudentNumber = number;
                    DateTime time;
                    if (string.IsNullOrEmpty(signIn.singinTime))
                        return signIn;
                    if (string.IsNullOrEmpty(signIn.singoutTime))
                    {
                        if (DateTime.TryParse(signIn.singinTime, out time))
                        {
                            signIn.Time = time;
                            signIn.Status = 0;
                        }
                        else
                            return signIn;
                    }
                    else
                    {
                        if (DateTime.TryParse(signIn.singoutTime, out time))
                        {
                            signIn.Time = time;
                            signIn.Status = 1;
                        }
                        else
                            return signIn;
                    }
                    signIn.IsValid = true;
                    return signIn;
                }
            }

        }

        //梦育教师信息下载
        public class TeacherInfoDownload
        {
            public static IList<TeacherInfo> GetDownloadData(string gardenID, int rev, out DownloadLog log)
            {
                log = null;
                var result = chuangzhiapi.model.Teacher.GetTeacherList(gardenID, rev);
                var list = new List<TeacherInfo>();
                if (!string.IsNullOrEmpty(result))
                {
                    log = JsonConvert.DeserializeObject<DownloadLog>(result);
                    log.Raw = result;
                    if (log != null)
                    {
                        if (log.result != null && log.result.list != null)
                        {
                            foreach (var teacher in log.result.list)
                            {
                                var @checked = TeacherInfo.CheckAndGet(teacher);
                                if (@checked.IsValid)
                                    list.Add(@checked);
                            }
                        }
                    }
                }
                return list;
            }

            public class DownloadLog
            {
                public string message { get; set; }
                public int lastupttime { get; set; }
                public Log result { get; set; }
                [JsonIgnore]
                public string Raw { get; set; }
            }

            public class Log
            {
                public IList<TeacherInfo> list { get; set; }
            }

            public class TeacherInfo
            {
                private string _id;
                [JsonIgnore]
                public string id
                {
                    get { return Guid.NewGuid().ToString(); }
                    set { }
                }
                public string name { get; set; } //教师姓名
                public int gender { get; set; } //教师性别 0女 1男
                public string teacherNum { get; set; } //教师工号

                [JsonIgnore]
                public bool IsValid
                {
                    get;
                    set;
                }

                public static TeacherInfo CheckAndGet(TeacherInfo teacher)
                {
                    if (string.IsNullOrEmpty(teacher.id))
                        return teacher;
                    if (string.IsNullOrEmpty(teacher.name))
                        return teacher;
                    int number = 0;
                    if (!int.TryParse(teacher.teacherNum, out number))
                        return teacher;
                    if (number % 100 > 70)
                        return teacher;

                    teacher.IsValid = true;
                    return teacher;
                }
            }
        }

        public class GrowUpReportDownload
        {
            public static DownloadLog GetDownloadData(string gardenID, string className, int rev)
            {
                DownloadLog log = null;
                var rq = WebRequest.Create("http://cz.aixyh.com/chuangzhi/api/ReportAction_getCPList") as HttpWebRequest;
                rq.Method = "POST";
                rq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
                rq.ContentType = "application/x-www-form-urlencoded";
                var data = Encoding.UTF8.GetBytes(string.Format("gardenID={0}&className={1}&lastupttime={2}", gardenID, className, rev));
                using (var rqStream = rq.GetRequestStream())
                {
                    rqStream.Write(data, 0, data.Length);
                }
                using (var rs = rq.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(rs.GetResponseStream()))
                    {
                        var content = reader.ReadToEnd();
                        log = JsonConvert.DeserializeObject<DownloadLog>(content);
                        log.Raw = content;
                        if (log.result != null)
                            log.lastupttime = log.result.lastupttime;
                    }
                }

                return log;
            }

            public class DownloadLog
            {
                public string message { get; set; }
                public int lastupttime { get; set; }
                public int code { get; set; }
                public Log result { get; set; }
                [JsonIgnore]
                public string Raw { get; set; }
            }

            public class Log
            {
                public int lastupttime { get; set; }
                public string className { get; set; }
                public IList<CheckReport> list { get; set; }
            }

            public class CheckReport
            {
                public string id { get; set; }
                public int studentNum { get; set; }
                public IList<ReportHistory> reportList { get; set; }
            }

            public class ReportHistory
            {
                public string name { get; set; }
                public IList<ReportItem> reportDetail { get; set; }
                public string time { get; set; }
                public int type { get; set; }
            }

            public class ReportItem
            {
                public string category { get; set; }
                [JsonProperty("contnet")]
                public string content { get; set; }
                public string item { get; set; }
                public string picUrl { get; set; }
            }
        }

        public class GrowUpCheckReportDownload
        {
            public static DownloadLog GetDownloadData(string gardenID, string className, int rev)
            {
                DownloadLog log = null;
                var rq = WebRequest.Create("http://cz.aixyh.com/chuangzhi/api/ReportAction_getTyList") as HttpWebRequest;
                rq.Method = "POST";
                rq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
                rq.ContentType = "application/x-www-form-urlencoded";
                var data = Encoding.UTF8.GetBytes(string.Format("gardenID={0}&className={1}&lastupttime={2}", gardenID, className, rev));
                using (var rqStream = rq.GetRequestStream())
                {
                    rqStream.Write(data, 0, data.Length);
                }
                using (var rs = rq.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(rs.GetResponseStream()))
                    {
                        var content = reader.ReadToEnd();
                        log = JsonConvert.DeserializeObject<DownloadLog>(content);
                        log.Raw = content;
                        if (log.result != null)
                            log.lastupttime = log.result.lastupttime;
                    }
                }

                return log;
            }

            public class DownloadLog
            {
                public string message { get; set; }
                public int lastupttime { get; set; }
                public int code { get; set; }
                public Log result { get; set; }
                [JsonIgnore]
                public string Raw { get; set; }
            }

            public class Log
            {
                public int lastupttime { get; set; }
                public string className { get; set; }
                public IList<CheckReport> list { get; set; }
            }

            public class CheckReport
            {
                public string id { get; set; }
                public int studentNum { get; set; }
                public IList<ReportHistory> reportList { get; set; }
            }

            public class ReportHistory
            {
                public string name { get; set; }
                public IList<ReportItem> reportDetail { get; set; }
                public string time { get; set; }
                public int type { get; set; }
            }

            public class ReportItem
            {
                public int resultType { get; set; }
                public int type { get; set; }
            }
        }
    }
}
