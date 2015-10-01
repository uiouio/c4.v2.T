using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CPTT.DataAccess
{
    public class GrowUpReportDataAccess
    {
        public ReportHierarchy GetGrowUpReports(DateTime[] dates)
        {
            var db = DatabaseFactory.CreateDatabase();

            var dateWhere = string.Empty;
            foreach (var date in dates)
                dateWhere += string.Format(" DATEDIFF(mm, recordTime, '{0}') = 0 OR", date.ToString("yyyy-MM-dd"));
            dateWhere = dateWhere.TrimEnd(new char[] { 'O', 'R' });


            DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(@"
SELECT gradeName, className, stuNumber, recorderName, [type], recordTime, category, item, content, picUrl, stuName, rawUrl
FROM GrowUpReportHistory INNER JOIN GrowUpReportDetail ON idx = reportHistoryID WHERE " + dateWhere + 
"ORDER BY stuNumber, category, recordTime");
            var reader = db.ExecuteReader(dbCommandWrapper);
            var hierarchy = ReportHierarchy.Create();
            while (reader.Read())
            {
                hierarchy.AddReport(new Report
                {
                    GradeName = reader.GetString(0),
                    ClassName = reader.GetString(1),
                    StuNumber = reader.GetInt32(2),
                    RecorderName = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                    EditBy = reader.GetInt32(4) == 2 ? EditBy.Parent : EditBy.Teacher,
                    Date = new DateTime(reader.GetDateTime(5).Year, reader.GetDateTime(5).Month, 1),
                    Category = reader.GetString(6),
                    Item = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                    Content = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                    PicUrl = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                    StuName = reader.GetString(10),
                    RawUrl = reader.IsDBNull(11) ? string.Empty : reader.GetString(11)
                });
            }
            return hierarchy;
        }

        public ReportHierarchy GetGrowUpReports(DateTime date)
        {
            var db = DatabaseFactory.CreateDatabase();
            DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(@"
SELECT gradeName, className, stuNumber, recorderName, [type], recordTime, category, item, content, picUrl, stuName
FROM GrowUpReportHistory INNER JOIN GrowUpReportDetail ON idx = reportHistoryID WHERE DATEDIFF(mm, @date, recordTime) = 0
ORDER BY stuNumber, category, recordTime");
            dbCommandWrapper.AddInParameter("@date", DbType.DateTime, date);
            var reader = db.ExecuteReader(dbCommandWrapper);
            var hierarchy = ReportHierarchy.Create();
            while (reader.Read())
            {
                hierarchy.AddReport(new Report
                {
                    GradeName = reader.GetString(0),
                    ClassName = reader.GetString(1),
                    StuNumber = reader.GetInt32(2),
                    RecorderName = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                    EditBy = reader.GetInt32(4) == 2 ? EditBy.Parent : EditBy.Teacher,
                    Date = new DateTime(reader.GetDateTime(5).Year, reader.GetDateTime(5).Month, 1),
                    Category = reader.GetString(6),
                    Item = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                    Content = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                    PicUrl = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                    StuName = reader.GetString(10)
                });
            }
            return hierarchy;
        }

        public CheckReportHierarchy GetGrowUpCheckReports(string[] classNames, DateTime date)
        {
            var hierarchy = CheckReportHierarchy.Create();
            foreach(var className in classNames)
            {
                var db = DatabaseFactory.CreateDatabase();
                using (var dbCommandWrapper = db.GetSqlStringCommandWrapper(
@"SELECT info_stuName, info_stuNumber, info_className, info_gradeName FROM Student_BasicInfo INNER JOIN Class_Info ON info_stuClass = info_classNumber AND info_stuGrade = info_gradeNumber INNER JOIN Grade_Info g ON g.info_gradeNumber = info_stuGrade WHERE info_className = @className AND info_stuHasLeftSchool = 0"))
                {
                    dbCommandWrapper.AddInParameter("@className", DbType.String, className);
                    var reader = db.ExecuteReader(dbCommandWrapper);
                    while (reader.Read())
                    {
                        for (var d = date; d < date.AddMonths(1); d = d.AddDays(1))
                        {
                            hierarchy.Add(new CheckInData
                            {
                                ClassName = reader.GetString(2),
                                Date = d,
                                Name = reader.GetString(0),
                                No = reader.GetInt32(1),
                                GradeName = reader.GetString(3)
                            });
                        }
                    }
                }

                using (var dbCommandWrapper = db.GetSqlStringCommandWrapper(@"
    SELECT * FROM
(
SELECT MAX(info_className) info_className, MAX(info_stuName) info_stuName, MAX(info_stuNumber) info_stuNumber, MAX(flow_stuFlowEnterState) flow_stuFlowEnterState, MAX(flow_curRecTime) flow_curRecTime,  MAX(info_gradeName) info_gradeName
FROM Student_BasicInfo INNER JOIN Class_Info ON info_stuClass = info_classNumber AND info_stuGrade = info_gradeNumber INNER JOIN Grade_Info g ON info_stuGrade = g.info_gradeNumber INNER JOIN Student_DataFlow ON info_stuID = flow_stuBasicID
WHERE DATEDIFF(mm, @date, flow_curRecTime) = 0 AND info_className = @className AND flow_stuFlowEnterState in (-1, 0, 2, 3)  AND info_stuHasLeftSchool = 0
GROUP BY CONVERT(char(10), flow_curRecTime, 120), info_className, info_stuNumber
) AS A
ORDER BY flow_curRecTime, info_stuNumber
"))
                {
                    dbCommandWrapper.AddInParameter("@date", DbType.DateTime, date);
                    dbCommandWrapper.AddInParameter("@className", DbType.String, className);
                    var reader = db.ExecuteReader(dbCommandWrapper);

                    while (reader.Read())
                    {
                        hierarchy.Add(new CheckInData
                        {
                            ClassName = reader.GetString(0),
                            Date = reader.GetDateTime(4),
                            Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            No = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            State = reader.GetInt16(3).ToString(),
                            GradeName = reader.GetString(5)
                        });
                    }
                }

                using (var dbCommandWrapper = db.GetSqlStringCommandWrapper(@"
    SELECT className, stuName, stuNumber, resultType, [type], recordTime, gradeName FROM [dbo].[GrowUpCheckReportHistory] INNER JOIN [dbo].[GrowUpCheckReportDetail] ON idx = reportHistoryID
    WHERE className = @className AND DATEDIFF(mm, recordTime, @date) = 0
    ORDER BY recordTime, stuNumber"))
                {
                    dbCommandWrapper.AddInParameter("@date", DbType.DateTime, date);
                    dbCommandWrapper.AddInParameter("@className", DbType.String, className);
                    var reader = db.ExecuteReader(dbCommandWrapper);

                    while (reader.Read())
                    {
                        hierarchy.Add(new ActivityData
                        {
                            ClassName = reader.GetString(0),
                            Date = reader.GetDateTime(5),
                            Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            No = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            ResultType = reader.GetInt32(3),
                            Type = reader.GetInt32(4),
                            GradeName = reader.GetString(6)
                        });
                    }
                }
            }
        
            return hierarchy;
        }

        public string GetGradeRemark(string gradeName)
        {
            var db = DatabaseFactory.CreateDatabase();
            DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(@"
SELECT info_gradeRemark FROM Grade_Info WHERE info_gradeName = @gradeName");
            dbCommandWrapper.AddInParameter("@gradeName", DbType.String, gradeName);
            var obj = db.ExecuteScalar(dbCommandWrapper);
            return obj.ToString();
        }

        public Tuple<int, int> GetGradeAndClassCount()
        {
            var db = DatabaseFactory.CreateDatabase();
            using (var dbCommandWrapper = db.GetSqlStringCommandWrapper(
@"
DECLARE @gradeCount INT
DECLARE @classCount INT
SELECT @gradeCount = COUNT(1) FROM Grade_Info WHERE info_gradeNumber > 0
SELECT @classCount = COUNT(1) FROM Class_Info WHERE info_gradeNumber > 0
SELECT @gradeCount , @classCount
"))
            {
                Tuple<int, int> tuple = new Tuple<int, int>(0, 0);
                var reader = db.ExecuteReader(dbCommandWrapper);
                while (reader.Read())
                {
                    tuple = new Tuple<int, int>(reader.GetInt32(0), reader.GetInt32(1));
                }
                return tuple;
            }
        }

        public class ReportHierarchy
        {
            private ReportGroupByGradeName root = new ReportGroupByGradeName();
            public static ReportHierarchy Create()
            {
                return new ReportHierarchy();
            }

            public int ReportCount 
            {
                get { return root.ReportCount; }
            }

            public ReportGroupByGradeName Root
            {
                get { return root; }
            }

            public void AddReport(Report report)
            {
                root.AddReport(report);
            }
        }

        public class ReportGroupByGradeName
        {
            private Dictionary<string, ReportGroupByClassName> groupByGrade = new Dictionary<string, ReportGroupByClassName>();
            public int ReportCount
            {
                get
                {
                    return groupByGrade.Values.Sum(v => v.ReportCount);
                }
            }

            public void AddReport(Report report)
            {
                ReportGroupByClassName reports = null;
                if (!groupByGrade.TryGetValue(report.GradeName, out reports))
                {
                    reports = new ReportGroupByClassName();
                    groupByGrade[report.GradeName] = reports;
                }
                reports.AddReport(report);
            }

            public IEnumerable<KeyValuePair<string, ReportGroupByClassName>> GetCollection()
            {
                return groupByGrade;
            }
        }

        public class ReportGroupByClassName
        {
            private Dictionary<string, ReportGroupByStudent> groupByClassName = new Dictionary<string, ReportGroupByStudent>();
            private Dictionary<string, ReportGroupByCategory> groupByClassNameStats = new Dictionary<string, ReportGroupByCategory>();

            public int ReportCount
            {
                get
                {
                    return groupByClassName.Values.Sum(v => v.ReportCount);
                }
            }

            public void AddReport(Report report)
            {
                ReportGroupByStudent reports = null;
                ReportGroupByCategory reportStats = null;
                if (!groupByClassName.TryGetValue(report.ClassName, out reports))
                {
                    reports = new ReportGroupByStudent();
                    groupByClassName[report.ClassName] = reports;
                }
                if (!groupByClassNameStats.TryGetValue(report.ClassName, out reportStats))
                {
                    reportStats = new ReportGroupByCategory();
                    groupByClassNameStats[report.ClassName] = reportStats;
                }
                reportStats.AddReport(report);
                reports.AddReport(report);
            }

            public int GetStudentCount(string className)
            {
                ReportGroupByStudent groupByStudent = null;
                int count = 0;
                if (groupByClassName.TryGetValue(className, out groupByStudent))
                {
                    count = groupByStudent.GetCollection().Count();
                }
                return count;
            }

            public IEnumerable<KeyValuePair<string, ReportGroupByStudent>> GetCollection()
            {
                return groupByClassName;
            }

            public IEnumerable<KeyValuePair<string, ReportGroupByCategory>> GetStatsCollection()
            {
                return groupByClassNameStats;
            }
        }

        public class ReportGroupByStudent
        {
            private Dictionary<int, KeyValuePair<string, ReportGroupByCategory>> groupByStudent = new Dictionary<int, KeyValuePair<string, ReportGroupByCategory>>();
           
            public int ReportCount { get { return groupByStudent.Values.Sum(v => v.Value.ReportCount); } }

            public void AddReport(Report report)
            {
                KeyValuePair<string, ReportGroupByCategory> reports = default(KeyValuePair<string, ReportGroupByCategory>);
                if (!groupByStudent.TryGetValue(report.StuNumber, out reports))
                {
                    reports = new KeyValuePair<string, ReportGroupByCategory>(report.StuName, new ReportGroupByCategory());
                    groupByStudent[report.StuNumber] = reports;
                }
                reports.Value.AddReport(report);
            }

            public IEnumerable<KeyValuePair<int, KeyValuePair<string, ReportGroupByCategory>>> GetCollection()
            {
                return groupByStudent;
            }
        }

        public class ReportGroupByCategory
        {
            private Dictionary<string, ReportGroupByDate> reportGroupByCategory = new Dictionary<string, ReportGroupByDate>();
            public int ReportCount { get { return reportGroupByCategory.Values.Sum(v => v.ReportCount); } }
            public void AddReport(Report report)
            {
                ReportGroupByDate reports = null;
                if (!reportGroupByCategory.TryGetValue(report.Category, out reports))
                {
                    reports = new ReportGroupByDate();
                    reportGroupByCategory[report.Category] = reports;
                }
                reports.AddReport(report);
            }

            public IEnumerable<KeyValuePair<string, ReportGroupByDate>> GetCollection()
            {
                return reportGroupByCategory;
            }
        }

        public class ReportGroupByDate
        {
            private Dictionary<string, Report> reports = new Dictionary<string, Report>();
            private Dictionary<string, StatsReport> statsReports = new Dictionary<string, StatsReport>();

            public int ReportCount { get { return reports.Count; } }

            public void AddReport(Report report)
            {
                var dateKey = report.Date.ToString("yyyy-MM");
                reports[dateKey] = report;
                StatsReport statsReport = null;
                if (!statsReports.TryGetValue(dateKey, out statsReport))
                {
                    statsReport = new StatsReport();;
                    statsReports[dateKey] = statsReport;
                }
                var items = report.Item;
                if (!string.IsNullOrEmpty(items))
                {
                    foreach (var split in items.Split(')'))
                    {
                        switch (split + ")")
                        {
                            case "(1)": statsReport.IncreateItem1();
                                break;
                            case "(2)": statsReport.IncreateItem2();
                                break;
                            case "(3)": statsReport.IncreateItem3();
                                break;
                            case "(4)": statsReport.IncreateItem4();
                                break;
                            case "(5)": statsReport.IncreateItem5();
                                break;
                            case "(6)": statsReport.IncreateItem6();
                                break;
                            default: break;
                        }
                    }
                }
            }

            public IEnumerable<Report> GetAllReports()
            {
                return reports.Values;
            }

            public IEnumerable<KeyValuePair<string, StatsReport>> GetStatsCollection()
            {
                return statsReports;
            }
        }

        public class StatsReport 
        {
            private string item1;
            private string item2;
            private string item3;
            private string item4;
            private string item5;
            private string item6;

            private int item1Count;
            private int item2Count;
            private int item3Count;
            private int item4Count;
            private int item5Count;
            private int item6Count;

            public void IncreateItem1()
            {
                item1 = "(1)";
                item1Count++;
            }
            public void IncreateItem2()
            {
                item2 = "(2)";
                item2Count++;
            }
            public void IncreateItem3()
            {
                item3 = "(3)";
                item3Count++;
            }
            public void IncreateItem4()
            {
                item4 = "(4)";
                item4Count++;
            }
            public void IncreateItem5()
            {
                item5 = "(5)";
                item5Count++;
            }
            public void IncreateItem6()
            {
                item6 = "(6)";
                item6Count++;
            }

            public string Item1 { get { return item1; } }
            public string Item2 { get { return item2; } }
            public string Item3 { get { return item3; } }
            public string Item4 { get { return item4; } }
            public string Item5 { get { return item5; } }
            public string Item6 { get { return item6; } }

            public int Item1Count { get { return item1Count; } }
            public int Item2Count { get { return item2Count; } }
            public int Item3Count { get { return item3Count; } }
            public int Item4Count { get { return item4Count; } }
            public int Item5Count { get { return item5Count; } }
            public int Item6Count { get { return item6Count; } }
        }

        public class Report
        {
            public string GradeName { get; set; }
            public string ClassName { get; set; }
            public int StuNumber { get; set; }
            public string StuName { get; set; }
            public string RecorderName { get; set; }
            public string Category { get; set; }
            public string Item { get; set; }
            public string Content { get; set; }
            public string PicUrl { get; set; }
            public string RawUrl { get; set; }
            public EditBy EditBy { get; set; }
            public DateTime Date { get; set; }
        }

        public enum EditBy
        {
            Teacher,
            Parent
        }

        public class CheckReportHierarchy
        {
            private CheckReportGroupByGradeName root = new CheckReportGroupByGradeName();
            public static CheckReportHierarchy Create()
            {
                return new CheckReportHierarchy();
            }

            public CheckReportGroupByGradeName Root
            {
                get { return root; }
            }

            public void Add(ReportData data)
            {
                root.Add(data);
            }
        }

        public class CheckReportGroupByGradeName
        {
            private Dictionary<string, CheckReportGroupByClassName> groupByGradeName = new Dictionary<string, CheckReportGroupByClassName>();
            public void Add(ReportData data)
            {
                CheckReportGroupByClassName reports = null;
                if (!groupByGradeName.TryGetValue(data.GradeName, out reports))
                {
                    reports = new CheckReportGroupByClassName();
                    groupByGradeName[data.GradeName] = reports;
                }
                reports.Add(data);
            }

            public IEnumerable<KeyValuePair<string, CheckReportGroupByClassName>> GetCollection()
            {
                return groupByGradeName;
            }
        }

        public class CheckReportGroupByClassName
        {
            private Dictionary<string, CheckReportGroupByStudent> groupByClassName = new Dictionary<string, CheckReportGroupByStudent>();
            public void Add(ReportData data)
            {
                CheckReportGroupByStudent reports = null;
                if (!groupByClassName.TryGetValue(data.ClassName, out reports))
                {
                    reports = new CheckReportGroupByStudent();
                    groupByClassName[data.ClassName] = reports;
                }
                reports.Add(data);
            }

            public IEnumerable<KeyValuePair<string, CheckReportGroupByStudent>> GetCollection()
            {
                return groupByClassName;
            }
        }

        public class CheckReportGroupByStudent
        {
            private Dictionary<int, KeyValuePair<string, CheckReportGroupByDate>> groupByStudent = new Dictionary<int, KeyValuePair<string, CheckReportGroupByDate>>();
            public void Add(ReportData data)
            {
                KeyValuePair<string, CheckReportGroupByDate> reports = default(KeyValuePair<string, CheckReportGroupByDate>);
                if (!groupByStudent.TryGetValue(data.No, out reports))
                {
                    reports = new KeyValuePair<string, CheckReportGroupByDate>(data.Name, new CheckReportGroupByDate());
                    groupByStudent[data.No] = reports;
                }
                reports.Value.Add(data);
            }

            public IEnumerable<KeyValuePair<int, KeyValuePair<string, CheckReportGroupByDate>>> GetCollection()
            {
                return groupByStudent;
            }
        }

        public class CheckReportGroupByDate
        {
            private Dictionary<string, CheckReport> reports = new Dictionary<string, CheckReport>();
            public void Add(ReportData data)
            {
                CheckReport report = null;
                if (!reports.TryGetValue(data.Date.ToString("yyyy-MM-dd"), out report))
                {
                    report = new CheckReport();
                    reports[data.Date.ToString("yyyy-MM-dd")] = report;
                }

                var tmp = data as ActivityData;
                if (tmp != null)
                {
                    var val = string.Format("{0}_{1}", tmp.Type, tmp.ResultType);
                    report.Increment(val);
                    switch (tmp.Type)
                    {
                        case 1: report.State2 = val;
                            break;
                        case 2: report.State3 = val;
                            break;
                        case 3: report.State4 = val;
                            break;
                        case 4: report.State5 = val;
                            break;
                        case 5: report.State6 = val;
                            break;
                        case 6: report.State7 = val;
                            break;
                    }
                }
                else
                {
                    var tmp2 = data as CheckInData;
                    report.State1 = tmp2.State;
                    report.Increment(tmp2.State);
                }
                report.Date = data.Date.ToString("yyyy/MM/dd");
                report.Name = data.Name;
                report.No = data.No;
            }

            public IEnumerable<CheckReport> GetAllReports()
            {
                return reports.Values;
            }
        }

        public class CheckReport
        {
            private Dictionary<string, int> stats = new Dictionary<string, int>();

            public string GradeName { get; set; }
            public string ClassName { get; set; }
            public string Date { get; set; }
            public string Name { get; set; }
            public int No { get; set; }
            public string State1 { get; set; }
            public string State2 { get; set; }
            public string State3 { get; set; }
            public string State4 { get; set; }
            public string State5 { get; set; }
            public string State6 { get; set; }
            public string State7 { get; set; }

            public void Increment(string state)
            {
                if (!string.IsNullOrEmpty(state))
                {
                    int count = 0;
                    stats.TryGetValue(state, out count);
                    count++;
                    stats[state] = count;
                }
            }

            public int GetCount(string state)
            {
                int count = 0;
                stats.TryGetValue(state, out count);
                return count;
            }
        }

        public class ReportData 
        {
            public int No { get; set; }
            public string GradeName { get; set; }
            public string ClassName { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
        }

        private class CheckInData : ReportData
        {
            public string State { get; set; }
        }

        private class ActivityData : ReportData
        {
            public int ResultType { get; set; }
            public int Type { get; set; }
        }
    }
}
