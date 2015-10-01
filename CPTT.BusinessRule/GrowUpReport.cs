using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CPTT.DataAccess;
using System.Diagnostics;
using CPTT.SystemFramework;

namespace CPTT.BusinessRule
{
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Text.RegularExpressions;
    using System.Data;
    using System.Net;
    using System.Drawing;
    public class GrowUpReport
    {
        private Excel.Application m_objExcel = null;
        private Excel.Workbooks m_objBooks = null;
        private Excel._Workbook m_objBook = null;
        private Excel.Sheets m_objSheets = null;
        private Excel._Worksheet m_objSheet = null;
        private Excel.Range m_objRange = null;
        private object m_objOpt = System.Reflection.Missing.Value;
        private string excelPath = AppDomain.CurrentDomain.BaseDirectory;

        public Tuple<int, int> GetGradeAndClassCount()
        {
            try
            {
                return new GrowUpReportDataAccess().GetGradeAndClassCount();
            }
            catch (Exception ex)
            {
                Util.WriteLog(ex.ToString(), Util.EXCEPTION_LOG_TITLE);
            }
            return new Tuple<int, int>(0, 0);
        }

        public void GenerateReportsPersonByPerson(string gardenName, DateTime[] dates, Action notify)
        {
            KillProcess();

            var dir = excelPath + @"report\成长记录报表\" + dates[0].ToString("yyyy") + @"\班主任报表";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var hierarchy = new GrowUpReportDataAccess().GetGrowUpReports(dates);
            var reportTemplate = new ReportTemplate();
            try
            {
                foreach (var groupByGrade in hierarchy.Root.GetCollection())
                {
                    var gradeDir = string.Format(@"{0}\{1}个人汇总", dir, groupByGrade.Key);
                    if (!Directory.Exists(gradeDir))
                        Directory.CreateDirectory(gradeDir);

                    foreach (var groupByClass in groupByGrade.Value.GetCollection())
                    {
                        try
                        {
                            m_objExcel = new Excel.Application();
                            m_objExcel.DisplayAlerts = false;
                            m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
                            m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath + @"report\GrowUpReport1.xls",
                                m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt,
                                m_objOpt, m_objOpt, m_objOpt);
                            m_objSheets = (Excel.Sheets)m_objBook.Worksheets;
                            m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
                            
                            //生成年龄段表头
                            var kvp = reportTemplate.GetAgeDesc(groupByGrade.Key, "report1");
                            foreach (var pos in kvp.Value.Split(','))
                            {
                                m_objSheet.get_Range(pos).Value = kvp.Key;
                            }

                            DoGenerateReportsPersonByPerson(gardenName, groupByClass.Key, groupByClass.Value, m_objSheet, reportTemplate, dates[0], dates[dates.Length - 1]);

                            m_objBook.SaveAs(string.Format("{0}\\{1}.xls", gradeDir, groupByClass.Key), m_objOpt, m_objOpt,
                            m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
                            m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                            m_objBook.Close(false, m_objOpt, m_objOpt);
                            m_objExcel.Quit();

                            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);

                            notify();
                        }
                        catch (Exception ex)
                        {
                            Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
            }
            finally
            {
                m_objRange = null;
                m_objSheet = null;
                m_objSheets = null;
                m_objBook = null;
                m_objBooks = null;
                m_objExcel = null;

                GC.Collect();

                KillProcess();
            }
        }

        public void GenerateReportsByClass(string gardenName, DateTime[] dates, Action notify)
        {
            KillProcess();

            var dir = excelPath + @"report\成长记录报表\" + dates[0].ToString("yyyy") + @"\管理员报表";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            dir += @"\班级统计汇总";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            
            var reportTemplate = new ReportTemplate();
            //按月分组
            foreach(var date in dates)
            {
                var hierarchy = new GrowUpReportDataAccess().GetGrowUpReports(date);
                try
                {
                    foreach (var groupByGrade in hierarchy.Root.GetCollection())
                    {
                        Excel._Worksheet templateSheet = null;
                        m_objExcel = new Excel.Application();
                        m_objExcel.DisplayAlerts = false;
                        m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
                        m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath + @"report\GrowUpReport2.xls",
                            m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt,
                            m_objOpt, m_objOpt, m_objOpt);
                        foreach (var groupByClass in groupByGrade.Value.GetCollection())
                        {
                            try
                            {
                                m_objSheets = (Excel.Sheets)m_objBook.Worksheets;
                                templateSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
                                var lastSheet = m_objSheets.get_Item(m_objSheets.Count);
                                templateSheet.Copy(m_objOpt, lastSheet);
                                m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(m_objSheets.Count);
                                m_objSheet.Name = string.Format("{0}统计汇总", groupByClass.Key);
                                m_objRange = m_objSheet.get_Range("A1", m_objOpt);
                                m_objRange.Value = string.Format("{0}{1}统计表", gardenName, groupByClass.Key);

                                DoGenerateReportsByClass(groupByGrade.Key, groupByClass.Value, reportTemplate, date);
                            }
                            catch (Exception ex)
                            {
                                Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
                            }
                        }

                        templateSheet.Delete();

                        m_objBook.SaveAs(string.Format("{0}\\{1}统计汇总({2}).xls", dir, groupByGrade.Key, date.ToString("yyyy.MM")), m_objOpt, m_objOpt,
                            m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
                            m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                        m_objBook.Close(false, m_objOpt, m_objOpt);
                        m_objExcel.Quit();

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);

                        notify();
                    }
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
                }
                finally
                {
                    m_objRange = null;
                    m_objSheet = null;
                    m_objSheets = null;
                    m_objBook = null;
                    m_objBooks = null;
                    m_objExcel = null;

                    GC.Collect();

                    KillProcess();
                }
            }
        }

        public void GenerateReportsByGrade(string gardenName, DateTime[] dates, Action notify)
        {
            KillProcess();

            var dir = excelPath + @"report\成长记录报表\" + dates[0].ToString("yyyy") + @"\管理员报表";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            dir += @"\年级统计汇总";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var reportTemplate = new ReportTemplate();
            //按月分组
            foreach (var date in dates)
            {
                var hierarchy = new GrowUpReportDataAccess().GetGrowUpReports(date);
                try
                {
                    Excel._Worksheet templateSheet = null;
                    m_objExcel = new Excel.Application();
                    m_objExcel.DisplayAlerts = false;
                    m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
                    m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath + @"report\GrowUpReport2.xls",
                        m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt,
                        m_objOpt, m_objOpt, m_objOpt);

                    foreach (var groupByGrade in hierarchy.Root.GetCollection())
                    {
                        m_objSheets = (Excel.Sheets)m_objBook.Worksheets;
                        templateSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
                        var lastSheet = m_objSheets.get_Item(m_objSheets.Count);
                        templateSheet.Copy(m_objOpt, lastSheet);
                        m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(m_objSheets.Count);
                        m_objSheet.Name = string.Format("{0}部统计汇总", groupByGrade.Key);
                        m_objRange = m_objSheet.get_Range("A1", m_objOpt);
                        m_objRange.Value = string.Format("{0}{1}部统计表", gardenName, groupByGrade.Key);

                        int offset = 1;
                        foreach (var groupByClass in groupByGrade.Value.GetCollection())
                        {
                            try
                            {
                                if (offset >= 2)
                                    m_objSheet.get_Range((Excel.Range)m_objSheet.Cells[m_objRange.Row + 1, 1], (Excel.Range)m_objSheet.Cells[m_objRange.Row + 1, 1]).EntireRow.Insert(Excel.XlDirection.xlDown);
                                var itemCount = DoGenerateReportsByGrade(groupByClass.Key, groupByClass.Value, reportTemplate, date, offset);
                                m_objSheet.get_Range(string.Format("C{0}", 5 + offset)).Value = itemCount;
                                offset++;
                                //offset多加了一次，下面计算的时候，OFFSET都会减一
                                var ignorePos = reportTemplate.GetIgnorePos(groupByGrade.Key, ReportTemplate.IgnoreType.Ignore1);
                                if (!string.IsNullOrEmpty(ignorePos))
                                {
                                    var regex = new Regex(@"(?<col>\w+)(?<row>\d)");
                                    foreach (var split in ignorePos.Split(','))
                                    {
                                        var match = regex.Match(split);
                                        var column = match.Groups["col"].Value;
                                        var row = match.Groups["row"].Value;
                                        var range = m_objSheet.Range[string.Format("{0}6:{0}{1}", column, Convert.ToInt32(row) + offset)];
                                        range.Value = "/";
                                        range = m_objSheet.Range[string.Format("{0}5:{0}{1}", column, Convert.ToInt32(row) + offset)];
                                        range.Interior.ColorIndex = 27; //http://dmcritchie.mvps.org/excel/colors.htm
                                        range.EntireColumn.Hidden = true;
                                    }
                                }
                                m_objSheet.get_Range(string.Format("A{0}", 6 + offset)).Value = string.Format("统计日期：{0}", date.ToString("yyyy.MM"));
                            }
                            catch (Exception ex)
                            {
                                Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
                            }
                        }
                    }

                    templateSheet.Delete();

                    m_objBook.SaveAs(string.Format("{0}\\年级统计汇总({1}).xls", dir, date.ToString("yyyy.MM")), m_objOpt, m_objOpt,
                            m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
                            m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                    m_objBook.Close(false, m_objOpt, m_objOpt);
                    m_objExcel.Quit();

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);

                    notify();
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
                }
                finally
                {
                    m_objRange = null;
                    m_objSheet = null;
                    m_objSheets = null;
                    m_objBook = null;
                    m_objBooks = null;
                    m_objExcel = null;

                    GC.Collect();

                    KillProcess();
                }
            }
        }

        public void GenerateStatsReports(string gardenName, DateTime[] dates, Action notify)
        {
            KillProcess();

            var dir = excelPath + @"report\成长记录报表\" + dates[0].ToString("yyyy") + @"\管理员报表";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            dir += "\\年级汇总";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            
            var hierarchy = new GrowUpReportDataAccess().GetGrowUpReports(dates);
            var reportTemplate = new ReportTemplate();
            try
            {
                foreach (var groupByGrade in hierarchy.Root.GetCollection())
                {
                    Excel._Worksheet templateSheet = null;
                    m_objExcel = new Excel.Application();
                    m_objExcel.DisplayAlerts = false;
                    m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
                    m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath + @"report\GrowUpReport3.xls",
                        m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt,
                        m_objOpt, m_objOpt, m_objOpt);



                    foreach (var groupByClass in groupByGrade.Value.GetStatsCollection())
                    {
                        try
                        {

                            int studentCount = groupByGrade.Value.GetStudentCount(groupByClass.Key);

                            m_objSheets = (Excel.Sheets)m_objBook.Worksheets;
                            templateSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
                            var lastSheet = m_objSheets.get_Item(m_objSheets.Count);
                            templateSheet.Copy(m_objOpt, lastSheet);
                            m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(m_objSheets.Count);
                            m_objSheet.Name = string.Format("{0}汇总", groupByClass.Key);
                            m_objRange = m_objSheet.get_Range("A1", m_objOpt);
                            m_objRange.Value = string.Format("{0}（{1}{2}人）  “快乐成长”记录情况汇总（各项表现数量及所占比率）", gardenName, groupByClass.Key, studentCount);

                            //生成年龄段表头
                            var kvp = reportTemplate.GetAgeDesc(groupByGrade.Key, "report3");
                            foreach (var pos in kvp.Value.Split(','))
                            {
                                m_objSheet.get_Range(pos).Value = kvp.Key;
                            }

                            var ignorePos = reportTemplate.GetIgnorePos(groupByGrade.Key, ReportTemplate.IgnoreType.Ignore2);
                            if (!string.IsNullOrEmpty(ignorePos))
                            {
                                foreach (var split in ignorePos.Split(','))
                                {
                                    if (!string.IsNullOrEmpty(split))
                                    {
                                        var column = split[0].ToString();
                                        var row = split.Substring(1);
                                        var lastRange = m_objSheet.get_Range(string.Format("J{0}", row));
                                        var ignoreRange = m_objSheet.get_Range(split);
                                        ignoreRange.Interior.ColorIndex = lastRange.Interior.ColorIndex;
                                        ignoreRange.Value = lastRange.Value;
                                    }
                                }
                            }

                            DoGenerateStatsReports(gardenName, groupByGrade.Key, groupByClass.Key, studentCount, groupByClass.Value, reportTemplate);
                        }
                        catch (Exception ex)
                        {
                            Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
                        }
                    }

                    templateSheet.Delete();

                    m_objBook.SaveAs(string.Format("{0}\\{1}.xls", dir, groupByGrade.Key), m_objOpt, m_objOpt,
                            m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
                            m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                    m_objBook.Close(false, m_objOpt, m_objOpt);
                    m_objExcel.Quit();

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);

                    notify();
                }
            }
            catch (Exception ex)
            {
                Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
            }
            finally
            {
                m_objRange = null;
                m_objSheet = null;
                m_objSheets = null;
                m_objBook = null;
                m_objBooks = null;
                m_objExcel = null;

                GC.Collect();

                KillProcess();
            }
        }

        public void GenerateCheckReports(string gardenName, DateTime[] dates, Action notify)
        {
            var dt = new ClassesDataAccess().GetClassAndGrade();
            var rows = new DataRow[dt.Rows.Count];
            dt.Rows.CopyTo(rows, 0);

            foreach (var date in dates)
            {
                KillProcess();

                var dir = excelPath + @"report\成长记录报表\" + date.ToString("yyyy");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                var checkInDays = new UtilDataAccess().GetAttendDays(date, date.AddMonths(1).AddDays(-1));
                var hierarchy = new GrowUpReportDataAccess().GetGrowUpCheckReports(rows.Select(r => r["info_className"].ToString()).ToArray(), date);
                GenerateCheckReportsPersonByPerson(gardenName, hierarchy, checkInDays, date, dir, notify);
                GenerateCheckReportsClassByClass(gardenName, hierarchy, checkInDays, date, dir, notify);
                GenerateCheckReportsGradeByGrade(gardenName, hierarchy, checkInDays, date, dir, notify);
            }
        }

        public void GenerateCheckReportsPersonByPerson(string gardenName, GrowUpReportDataAccess.CheckReportHierarchy hierarchy, int checkInDays, DateTime date, string dir, Action notify)
        {
            var reportTemplate = new ReportTemplate();
            try
            {
                foreach (var groupByGrade in hierarchy.Root.GetCollection())
                {
                    var gradeDir = string.Format(@"{0}\班主任报表\{1}幼儿体验", dir, groupByGrade.Key);
                    if (!Directory.Exists(gradeDir))
                        Directory.CreateDirectory(gradeDir);

                    foreach (var groupByClass in groupByGrade.Value.GetCollection())
                    {
                        try
                        {
                            m_objExcel = new Excel.Application();
                            m_objExcel.DisplayAlerts = false;
                            m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
                            m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath + @"report\GrowUpReport4.xls",
                                m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt,
                                m_objOpt, m_objOpt, m_objOpt);
                            m_objSheets = (Excel.Sheets)m_objBook.Worksheets;
                            m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

                            DoGenerateCheckReportsPersonByPerson(gardenName, groupByClass.Key, groupByClass.Value, m_objSheet, reportTemplate, date, checkInDays);

                            m_objBook.SaveAs(string.Format("{0}\\{1}({2}).xls", gradeDir, groupByClass.Key, date.ToString("yyyy.MM.dd")), m_objOpt, m_objOpt,
                            m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
                            m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                            m_objBook.Close(false, m_objOpt, m_objOpt);
                            m_objExcel.Quit();

                            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);

                            notify();
                        }
                        catch (Exception ex)
                        {
                            Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
            }
            finally
            {
                m_objRange = null;
                m_objSheet = null;
                m_objSheets = null;
                m_objBook = null;
                m_objBooks = null;
                m_objExcel = null;

                GC.Collect();

                KillProcess();
            }
        }

        public void GenerateCheckReportsClassByClass(string gardenName, GrowUpReportDataAccess.CheckReportHierarchy hierarchy, int checkInDays, DateTime date, string dir, Action notify)
        {
            var reportTemplate = new ReportTemplate();
            var gradeDir = string.Format(@"{0}\管理员报表\幼儿体验汇总", dir);
            if (!Directory.Exists(gradeDir))
                Directory.CreateDirectory(gradeDir);
            try
            {
                foreach (var groupByGrade in hierarchy.Root.GetCollection())
                {
                    Excel._Worksheet templateSheet = null;
                    m_objExcel = new Excel.Application();
                    m_objExcel.DisplayAlerts = false;
                    m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
                    m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath + @"report\GrowUpReport5.xls",
                        m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt,
                        m_objOpt, m_objOpt, m_objOpt);
                    m_objSheets = (Excel.Sheets)m_objBook.Worksheets;
                    templateSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

                    foreach (var groupByClass in groupByGrade.Value.GetCollection())
                    {
                        try
                        {
                            var lastSheet = m_objSheets.get_Item(m_objSheets.Count);
                            templateSheet.Copy(m_objOpt, lastSheet);
                            m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(m_objSheets.Count);
                            m_objSheet.Name = groupByClass.Key;
                            m_objRange = m_objSheet.get_Range("A1", m_objOpt);
                            m_objRange.Value = string.Format("{0}{1}宝宝体验汇总表          （{2}）应出勤{3}天", gardenName, groupByClass.Key, date.ToString("yyyy-MM月"), checkInDays);

                            DoGenerateCheckReportsClassByClass(gardenName, groupByClass.Key, groupByClass.Value, m_objSheet, reportTemplate, date, checkInDays);
                        }
                        catch (Exception ex)
                        {
                            Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
                        }
                    }

                    templateSheet.Delete();

                    m_objBook.SaveAs(string.Format("{0}\\{1}({2}).xls", gradeDir, groupByGrade.Key, date.ToString("yyyy.MM.dd")), m_objOpt, m_objOpt,
                           m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
                           m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                    m_objBook.Close(false, m_objOpt, m_objOpt);
                    m_objExcel.Quit();

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);

                    notify();
                }
            }
            catch (Exception ex)
            {
                Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
            }
            finally
            {
                m_objRange = null;
                m_objSheet = null;
                m_objSheets = null;
                m_objBook = null;
                m_objBooks = null;
                m_objExcel = null;

                GC.Collect();

                KillProcess();
            }
        }

        public void GenerateCheckReportsGradeByGrade(string gardenName, GrowUpReportDataAccess.CheckReportHierarchy hierarchy, int checkInDays, DateTime date, string dir, Action notify)
        {
            var reportTemplate = new ReportTemplate();
            var gradeDir = string.Format(@"{0}\管理员报表\幼儿体验汇总", dir);
            if (!Directory.Exists(gradeDir))
                Directory.CreateDirectory(gradeDir);
            try
            {
                m_objExcel = new Excel.Application();
                m_objExcel.DisplayAlerts = false;
                m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
                m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath + @"report\GrowUpReport6.xls",
                    m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt,
                    m_objOpt, m_objOpt, m_objOpt);
                m_objSheets = (Excel.Sheets)m_objBook.Worksheets;
                m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
                m_objRange = m_objSheet.get_Range("A1", m_objOpt);
                m_objRange.Value = string.Format("{0}幼儿在园体验汇总表          （{1}） 应出勤{2}天", gardenName, date.ToString("yyyy-MM月"), checkInDays);

                checkInDays = checkInDays == 0 ? 1 : checkInDays;

                int offset = 1;
                int total1 = 0; int total2 = 0; int total3 = 0; int total4 = 0; int total5 = 0; int total6 = 0; int total7 = 0;
                int total8 = 0; int total9 = 0; int total10 = 0; int total11 = 0; int total12 = 0; int total13 = 0; int total14 = 0; 
                int total15 = 0; int total16 = 0; int total17 = 0; int total18 = 0; int total19 = 0; int total20 = 0;
                int total21 = 0; int total22 = 0; int totalStudentCount = 0;
                foreach (var groupByGrade in hierarchy.Root.GetCollection())
                {
                    foreach (var groupByClass in groupByGrade.Value.GetCollection())
                    {
                        try
                        {
                            
                            if (offset >= 2)
                            {
                                m_objSheet.get_Range((Excel.Range)m_objSheet.Cells[m_objRange.Row + 1, m_objRange.Column], (Excel.Range)m_objSheet.Cells[m_objRange.Row + 1, m_objRange.Column]).EntireRow.Insert(Excel.XlDirection.xlDown);
                            }
                            DoGenerateCheckReportsGradeByGrade(groupByClass.Key, groupByClass.Value, reportTemplate, checkInDays, offset,
                                ref total1, ref total2,ref total3, ref total4,ref total5, ref total6,ref total7, ref total8,ref total8, ref total10,ref total11, ref total12,
                                ref total13, ref total14,ref total15, ref total16,ref total17, ref total18,ref total19, ref total20,ref total21, ref total22, ref totalStudentCount);
                            offset++;
                        }
                        catch (Exception ex)
                        {
                            Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
                        }
                    }
                }

                offset = offset - 2;

                WriteCheckReportCell(reportTemplate, "s_total", totalStudentCount.ToString(), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "0_total", string.Format("{0}({1})", total1, (total1 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "3_total", string.Format("{0}({1})", total2, (total2 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "2_total", string.Format("{0}({1})", total3, (total3 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "-1_total", string.Format("{0}({1})", total4, ((checkInDays * totalStudentCount - total1 - total2 - total3) / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "1_1_total", string.Format("{0}({1})", total5, (total5 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "1_2_total", string.Format("{0}({1})", total6, (total6 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "1_3_total", string.Format("{0}({1})", total7, (total7 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "2_1_total", string.Format("{0}({1})", total8, (total8 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "2_2_total", string.Format("{0}({1})", total9, (total9 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "2_3_total", string.Format("{0}({1})", total10, (total10 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "3_1_total", string.Format("{0}({1})", total11, (total11 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "3_2_total", string.Format("{0}({1})", total12, (total12 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "3_3_total", string.Format("{0}({1})", total13, (total13 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "4_1_total", string.Format("{0}({1})", total14, (total14 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "4_2_total", string.Format("{0}({1})", total15, (total15 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "4_3_total", string.Format("{0}({1})", total16, (total16 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "5_1_total", string.Format("{0}({1})", total17, (total17 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "5_2_total", string.Format("{0}({1})", total18, (total18 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "5_3_total", string.Format("{0}({1})", total19, (total19 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "6_1_total", string.Format("{0}({1})", total20, (total20 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "6_2_total", string.Format("{0}({1})", total21, (total21 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "6_3_total", string.Format("{0}({1})", total22, (total22 / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);


                WriteCheckReportCell(reportTemplate, "0_all", string.Format("{0}({1})", total1 + total2 + total3, ((total1 + total2 + total3) / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "1_all", string.Format("{0}({1})", total4, ((checkInDays * totalStudentCount - total1 - total2 - total3) / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "2_all", string.Format("{0}({1})", total5 + total6 + total7, ((total5 + total6 + total7) / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "3_all", string.Format("{0}({1})", total8 + total9 + total10, ((total8 + total9 + total10) / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "4_all", string.Format("{0}({1})", total11 + total12 + total13, ((total11 + total12 + total13) / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "5_all", string.Format("{0}({1})", total14 + total15 + total16, ((total14 + total15 + total16) / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "6_all", string.Format("{0}({1})", total17 + total18 + total19, ((total17 + total18 + total9) / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "7_all", string.Format("{0}({1})", total20 + total21 + total22, ((total20 + total21 + total22) / ((double)checkInDays * totalStudentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);

                m_objSheet.get_Range(string.Format("A{0}", 7 + offset)).Value = string.Format("统计日期：{0}", date.ToString("yyyy.MM.dd"));

                m_objBook.SaveAs(string.Format("{0}\\全园体验({1}).xls", gradeDir, date.ToString("yyyy.MM.dd")), m_objOpt, m_objOpt,
                             m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
                             m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                m_objBook.Close(false, m_objOpt, m_objOpt);
                m_objExcel.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);

                notify();
            }
            catch (Exception ex)
            {
                Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
            }
            finally
            {
                m_objRange = null;
                m_objSheet = null;
                m_objSheets = null;
                m_objBook = null;
                m_objBooks = null;
                m_objExcel = null;

                GC.Collect();

                KillProcess();
            }
        }

        private void DoGenerateReportsPersonByPerson(
            string gardenName, string className, GrowUpReportDataAccess.ReportGroupByStudent grouping,
            Excel._Worksheet templateSheet, ReportTemplate reportTemplate, DateTime beginDate, DateTime endDate)
        {
            foreach (var groupByStudent in grouping.GetCollection())
            {
                var stuName = groupByStudent.Value.Key;
                var lastSheet = m_objSheets.get_Item(m_objSheets.Count);
                templateSheet.Copy(m_objOpt, lastSheet);
                m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(m_objSheets.Count);
                m_objSheet.Name = stuName;
                m_objRange = m_objSheet.get_Range("A1", m_objOpt);
                m_objRange.Value = string.Format("{0}（{1}）{2} {3} \"快乐成长\"记录情况汇总", gardenName, className, groupByStudent.Key, stuName);

                int offset = 0;
                foreach (var groupByCategory in groupByStudent.Value.Value.GetCollection())
                {
                    int k = 0;
                    var category = groupByCategory.Key;
                    var reportDateList = groupByCategory.Value.GetAllReports().ToList();
                    for (int i = 0; i < reportDateList.Count; i++)
                    {
                        var report = reportDateList[i];
                        if (!string.IsNullOrEmpty(report.Item))
                        {
                            if (k >= 1)
                            {
                                offset++;
                                //向上插入一行
                                m_objSheet.get_Range((Excel.Range)m_objSheet.Cells[m_objRange.Row + 1, m_objRange.Column], (Excel.Range)m_objSheet.Cells[m_objRange.Row + 1, m_objRange.Column]).EntireRow.Insert(Excel.XlDirection.xlDown);
                            }

                            string column = string.Empty;
                            string row = string.Empty;
                            var range = reportTemplate.GetPos(string.Format("{0}_Item", category), ReportTemplate.ReportType.Report1);
                            if (!string.IsNullOrEmpty(range))
                            {
                                column = range[0].ToString();
                                row = range.Substring(1);
                                m_objRange = m_objSheet.get_Range(string.Format("{0}{1}", column, Convert.ToInt32(row) + offset), m_objOpt);
                                m_objRange.Value = report.Item;
                            }
                            range = reportTemplate.GetPos(string.Format("{0}_Time", category), ReportTemplate.ReportType.Report1);
                            if (!string.IsNullOrEmpty(range))
                            {
                                column = range[0].ToString();
                                row = range.Substring(1);
                                m_objRange = m_objSheet.get_Range(string.Format("{0}{1}", column, Convert.ToInt32(row) + offset), m_objOpt);
                                m_objRange.Value = reportDateList[i].Date.ToString("yyyy年MM月");
                            }
                            range = reportTemplate.GetPos(string.Format("{0}_Desc", category), ReportTemplate.ReportType.Report1);
                            if (!string.IsNullOrEmpty(range))
                            {
                                column = range[0].ToString();
                                row = range.Substring(1);
                                m_objRange = m_objSheet.get_Range(string.Format("{0}{1}", column, Convert.ToInt32(row) + offset), m_objOpt);
                                m_objRange.Value = report.Content;
                            }
                            range = reportTemplate.GetPos(string.Format("{0}_Pic", category), ReportTemplate.ReportType.Report1);
                            if (!string.IsNullOrEmpty(range))
                            {
                                column = range[0].ToString();
                                row = range.Substring(1);
                                m_objRange = m_objSheet.get_Range(string.Format("{0}{1}", column, Convert.ToInt32(row) + offset), m_objOpt);

                                if (!string.IsNullOrEmpty(report.PicUrl) && !report.PicUrl.Contains("http"))
                                {
                                    m_objRange.Select();
                                    float PicLeft, PicTop;
                                    PicLeft = Convert.ToSingle(m_objRange.Left);
                                    PicTop = Convert.ToSingle(m_objRange.Top);

                                    var fileName = AppDomain.CurrentDomain.BaseDirectory + report.PicUrl;
                                    if (!File.Exists(fileName))
                                    {
                                        if (!string.IsNullOrEmpty(report.RawUrl) && report.RawUrl.Contains("http"))
                                        {
                                            var buffer = new WebClient().DownloadData(report.RawUrl);
                                            using (var stream = new MemoryStream(buffer))
                                            {
                                                using (var img = Image.FromStream(stream))
                                                {
                                                    img.Save(fileName);
                                                }
                                            }
                                        }
                                    }

                                    if (File.Exists(fileName))
                                    {
                                        m_objSheet.Shapes.AddPicture(fileName,
                                            Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, PicLeft, PicTop, (float)m_objRange.Width, (float)m_objRange.Height);
                                    }
                                }
                                else
                                    m_objRange.Value = report.PicUrl;
                            }

                            if (i == reportDateList.Count - 1)
                            {
                                if (k >= 1)
                                {
                                    //将各级别单元格合并
                                    var currentRow = m_objRange.Row;
                                    MergeLevel(currentRow, "C");
                                    MergeLevel(currentRow, "H");
                                    MergeLevel(currentRow, "B");
                                    MergeLevel(currentRow, "A");
                                }
                            }
                            k++;
                        }
                    }
                }
               
                m_objSheet.Range[string.Format("A2:H{0}", 38 + offset)].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                m_objSheet.get_Range(string.Format("A{0}", 39 + offset), m_objOpt).Value = string.Format("汇总周期：{0}---{1}", beginDate.ToString("yyyy.MM.dd"), endDate.ToString("yyyy.MM.dd"));
            }
            templateSheet.Delete();
        }

        private void DoGenerateReportsByClass(string gradeName, GrowUpReportDataAccess.ReportGroupByStudent grouping, ReportTemplate reportTemplate, DateTime date)
        {
            int offset = 1;
            foreach (var groupByStudent in grouping.GetCollection())
            {
                if (offset >= 2)
                    m_objSheet.get_Range((Excel.Range)m_objSheet.Cells[m_objRange.Row + 1, 1], (Excel.Range)m_objSheet.Cells[m_objRange.Row + 1, 1]).EntireRow.Insert(Excel.XlDirection.xlDown);

                var stuName = groupByStudent.Value.Key;
                var regex = new Regex(@"(?<col>\w+)(?<row>\d)");
                m_objRange = (Excel.Range)m_objSheet.get_Range(string.Format("A{0}", 5 + offset));
                m_objRange.Value = groupByStudent.Key;
                m_objSheet.get_Range(string.Format("B{0}", 5 + offset)).Value = stuName;
                int itemCount = 0;
                foreach (var groupByCategory in groupByStudent.Value.Value.GetCollection())
                {
                    var category = groupByCategory.Key;
                    var report = groupByCategory.Value.GetAllReports().FirstOrDefault();
                    if (report != null && !string.IsNullOrEmpty(report.Item))
                    {
                        var split = report.Item.Split(')');
                        for (int j = 0; j < split.Length; j++)
                        {
                            if (!string.IsNullOrEmpty(split[j]))
                            {
                                string column = string.Empty;
                                string row = string.Empty;
                                var range = reportTemplate.GetPos(string.Format("{0}_{1})", category, split[j]), ReportTemplate.ReportType.Report2);
                                if (!string.IsNullOrEmpty(range))
                                {
                                    var match = regex.Match(range);
                                    column = match.Groups["col"].Value;
                                    row = match.Groups["row"].Value;
                                    m_objRange = m_objSheet.get_Range(string.Format("{0}{1}", column, Convert.ToInt32(row) + offset), m_objOpt);
                                    m_objRange.Value = 1;
                                    itemCount++;
                                }
                            }
                        }
                    }

                }
                m_objSheet.get_Range(string.Format("C{0}", 5 + offset)).Value = itemCount;
                itemCount = 0;
                offset++;
            }
            //offset多加了一次，下面计算的时候，OFFSET都会减一
            var ignorePos = reportTemplate.GetIgnorePos(gradeName, ReportTemplate.IgnoreType.Ignore1);
            if (!string.IsNullOrEmpty(ignorePos))
            {
                var regex = new Regex(@"(?<col>\w+)(?<row>\d)");
                foreach (var split in ignorePos.Split(','))
                {
                    var match = regex.Match(split);
                    var column = match.Groups["col"].Value;
                    var row = match.Groups["row"].Value;
                    var range = m_objSheet.Range[string.Format("{0}6:{0}{1}", column, Convert.ToInt32(row) + offset)];
                    range.Value = "/";
                    range = m_objSheet.Range[string.Format("{0}5:{0}{1}", column, Convert.ToInt32(row) + offset)];
                    range.Interior.ColorIndex = 27; //http://dmcritchie.mvps.org/excel/colors.htm
                    range.EntireColumn.Hidden = true;
                }
            }
            m_objSheet.get_Range(string.Format("A{0}", 6 + offset)).Value = string.Format("统计日期：{0}", date.ToString("yyyy.MM"));
        }

        private int DoGenerateReportsByGrade(string className, GrowUpReportDataAccess.ReportGroupByStudent grouping, ReportTemplate reportTemplate, DateTime date, int offset)
        {
            int itemCount = 0;
            foreach (var groupByStudent in grouping.GetCollection())
            {
                var classNumber = groupByStudent.Key.ToString().Substring(0, 2);
                var regex = new Regex(@"(?<col>\w+)(?<row>\d)");
                m_objRange = (Excel.Range)m_objSheet.get_Range(string.Format("A{0}", 5 + offset));
                m_objRange.Value = classNumber;
                m_objSheet.get_Range(string.Format("B{0}", 5 + offset)).Value = className;
                foreach (var groupByCategory in groupByStudent.Value.Value.GetCollection())
                {
                    var category = groupByCategory.Key;
                    var report = groupByCategory.Value.GetAllReports().FirstOrDefault();
                    if (report != null && !string.IsNullOrEmpty(report.Item))
                    {
                        var split = report.Item.Split(')');
                        for (int j = 0; j < split.Length; j++)
                        {
                            if (!string.IsNullOrEmpty(split[j]))
                            {
                                string column = string.Empty;
                                string row = string.Empty;
                                var range = reportTemplate.GetPos(string.Format("{0}_{1})", category, split[j]), ReportTemplate.ReportType.Report2);
                                if (!string.IsNullOrEmpty(range))
                                {
                                    var match = regex.Match(range);
                                    column = match.Groups["col"].Value;
                                    row = match.Groups["row"].Value;
                                    m_objRange = m_objSheet.get_Range(string.Format("{0}{1}", column, Convert.ToInt32(row) + offset), m_objOpt);
                                    var val = m_objRange.Value;
                                    if (val == null)
                                        m_objRange.Value = 1;
                                    else
                                        m_objRange.Value = Convert.ToInt32(val) + 1;
                                    itemCount++;
                                }
                            }
                        }
                    }
                }
            }
            return itemCount;
        }

        private void DoGenerateStatsReports(
            string gardenName, string gradeName, string className, int studentCount, GrowUpReportDataAccess.ReportGroupByCategory grouping, ReportTemplate reportTemplate)
        {
            int offset = 0;
            foreach (var groupByCategory in grouping.GetCollection())
            {
                int k = 0;
                var list = groupByCategory.Value.GetStatsCollection().ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    var groupByDate = list[i];
                    if (k >= 1)
                    {
                        offset++;
                        //向上插入一行
                        m_objSheet.get_Range((Excel.Range)m_objSheet.Cells[m_objRange.Row + 1, m_objRange.Column], (Excel.Range)m_objSheet.Cells[m_objRange.Row + 1, m_objRange.Column]).EntireRow.Insert(Excel.XlDirection.xlDown);
                    }

                    WriteStatsCell(gradeName, reportTemplate, groupByCategory.Key, "(T)", groupByDate.Key, offset);
                    var report = groupByDate.Value;
                    var val = string.IsNullOrEmpty(report.Item1) ? "0" : studentCount == 0 ? "0" : string.Format("{0}({1})", report.Item1Count, (report.Item1Count/(double)studentCount).ToString("0.00%"));
                    WriteStatsCell(gradeName, reportTemplate, groupByCategory.Key, "(1)", val, offset);
                    val = string.IsNullOrEmpty(report.Item2) ? "0" : studentCount == 0 ? "0" : string.Format("{0}({1})", report.Item2Count, (report.Item2Count / (double)studentCount).ToString("0.00%"));
                    WriteStatsCell(gradeName, reportTemplate, groupByCategory.Key, "(2)", val, offset);
                    val = string.IsNullOrEmpty(report.Item3) ? "0" : studentCount == 0 ? "0" : string.Format("{0}({1})", report.Item3Count, (report.Item3Count / (double)studentCount).ToString("0.00%"));
                    WriteStatsCell(gradeName, reportTemplate, groupByCategory.Key, "(3)", val, offset);
                    val = string.IsNullOrEmpty(report.Item4) ? "0" : studentCount == 0 ? "0" : string.Format("{0}({1})", report.Item4Count, (report.Item4Count / (double)studentCount).ToString("0.00%"));
                    WriteStatsCell(gradeName, reportTemplate, groupByCategory.Key, "(4)", val, offset);
                    val = string.IsNullOrEmpty(report.Item5) ? "0" : studentCount == 0 ? "0" : string.Format("{0}({1})", report.Item5Count, (report.Item5Count / (double)studentCount).ToString("0.00%"));
                    WriteStatsCell(gradeName, reportTemplate, groupByCategory.Key, "(5)", val, offset);
                    val = string.IsNullOrEmpty(report.Item6) ? "0" : studentCount == 0 ? "0" : string.Format("{0}({1})", report.Item6Count, (report.Item6Count / (double)studentCount).ToString("0.00%"));
                    WriteStatsCell(gradeName, reportTemplate, groupByCategory.Key, "(6)", val, offset);

                    if (i == list.Count - 1)
                    {
                        if (k >= 1)
                        {
                            //将各级别单元格合并
                            var currentRow = m_objRange.Row;
                            MergeLevel(currentRow, "A");
                            MergeLevel(currentRow, "B");
                            MergeLevel(currentRow, "C", k);
                            MergeLevel(currentRow, "F", k);
                            MergeLevel(currentRow, "G", k);
                            MergeLevel(currentRow, "H", k);
                            MergeLevel(currentRow, "I", k);
                            MergeLevel(currentRow, "J", k);
                            MergeLevel(currentRow, "K", k);
                        }
                    }

                    k++;
                }
            }

            m_objSheet.Range[string.Format("A2:K{0}", 38 + offset)].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            m_objSheet.get_Range(string.Format("A{0}", 39 + offset)).Value = string.Format("统计时间：{0}", DateTime.Now.ToString("yyyy.MM.dd"));
        }

        private void DoGenerateCheckReportsPersonByPerson(string gardenName, string className, GrowUpReportDataAccess.CheckReportGroupByStudent grouping,
            Excel._Worksheet templateSheet, ReportTemplate reportTemplate, DateTime date, int checkInDays)
        {
            foreach (var groupByStudent in grouping.GetCollection())
            {
                var stuName = groupByStudent.Value.Key;
                var lastSheet = m_objSheets.get_Item(m_objSheets.Count);
                templateSheet.Copy(m_objOpt, lastSheet);
                m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(m_objSheets.Count);
                m_objSheet.Name = stuName;
                m_objRange = m_objSheet.get_Range("A1", m_objOpt);
                m_objRange.Value = string.Format("{0}{1}（{2}） {3} 在园体验汇总表          （{4}）应出勤{5}天", gardenName, className, groupByStudent.Key, stuName, date.ToString("yyyy-MM月"), checkInDays);

                int offset = 1;
                foreach (var report in groupByStudent.Value.Value.GetAllReports())
                {
                    if (offset >= 2)
                    {
                        m_objSheet.get_Range((Excel.Range)m_objSheet.Cells[m_objRange.Row + 1, m_objRange.Column], (Excel.Range)m_objSheet.Cells[m_objRange.Row + 1, m_objRange.Column]).EntireRow.Insert(Excel.XlDirection.xlDown);
                    }

                    WriteCheckReportCell(reportTemplate, "date", report.Date, offset, ReportTemplate.ReportType.Report4);
                    WriteCheckReportCell(reportTemplate, report.State1, "1", offset, ReportTemplate.ReportType.Report4);
                    WriteCheckReportCell(reportTemplate, report.State2, "1", offset, ReportTemplate.ReportType.Report4);
                    WriteCheckReportCell(reportTemplate, report.State3, "1", offset, ReportTemplate.ReportType.Report4);
                    WriteCheckReportCell(reportTemplate, report.State4, "1", offset, ReportTemplate.ReportType.Report4);
                    WriteCheckReportCell(reportTemplate, report.State5, "1", offset, ReportTemplate.ReportType.Report4);
                    WriteCheckReportCell(reportTemplate, report.State6, "1", offset, ReportTemplate.ReportType.Report4);
                    WriteCheckReportCell(reportTemplate, report.State7, "1", offset, ReportTemplate.ReportType.Report4);

                    offset++;
                }

                offset = offset - 2;
                var sum1 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("0"));
                var sum2 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("3"));
                var sum3 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("2"));
                var sum4 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("-1"));

                var sum5 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("1_1"));
                var sum6 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("1_2"));
                var sum7 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("1_3"));

                var sum8 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("2_1"));
                var sum9 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("2_2"));
                var sum10 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("2_3"));

                var sum11 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("3_1"));
                var sum12 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("3_2"));
                var sum13 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("3_3"));

                var sum14 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("4_1"));
                var sum15 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("4_2"));
                var sum16 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("4_3"));

                var sum17 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("5_1"));
                var sum18 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("5_2"));
                var sum19 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("5_3"));

                var sum20 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("6_1"));
                var sum21 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("6_2"));
                var sum22 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("6_3"));

                WriteCheckReportCell(reportTemplate, "0_sum", sum1.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "3_sum", sum2.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "2_sum", sum3.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "-1_sum", sum4.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "1_1_sum", sum5.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "1_2_sum", sum6.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "1_3_sum", sum7.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "2_1_sum", sum8.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "2_2_sum", sum9.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "2_3_sum", sum10.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "3_1_sum", sum11.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "3_2_sum", sum12.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "3_3_sum", sum13.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "4_1_sum", sum14.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "4_2_sum", sum15.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "4_3_sum", sum16.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "5_1_sum", sum17.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "5_2_sum", sum18.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "5_3_sum", sum19.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "6_1_sum", sum20.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "6_2_sum", sum21.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "6_3_sum", sum22.ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "1_total", (sum1 + sum2 + sum3 + sum4).ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "2_total", (sum5 + sum6 + sum7).ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "3_total", (sum8 + sum9 + sum10).ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "4_total", (sum11 + sum12 + sum13).ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "5_total", (sum14 + sum15 + sum16).ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "6_total", (sum17 + sum18 + sum19).ToString(), offset, ReportTemplate.ReportType.Report4);
                WriteCheckReportCell(reportTemplate, "7_total", (sum20 + sum21 + sum22).ToString(), offset, ReportTemplate.ReportType.Report4);
            }
            templateSheet.Delete();
        }

        private void DoGenerateCheckReportsClassByClass(string gardenName, string className, GrowUpReportDataAccess.CheckReportGroupByStudent grouping,
            Excel._Worksheet templateSheet, ReportTemplate reportTemplate, DateTime date, int checkInDays)
        {
            checkInDays = checkInDays == 0 ? 1 : checkInDays;
            int offset = 1;
            int total1 = 0; int total2 = 0;int total3 = 0; int total4 = 0; int total5 = 0; int total6 = 0; int total7 = 0; int total8 = 0; int total9 = 0; int total10 = 0;
            int total11 = 0; int total12 = 0; int total13 = 0; int total14 = 0; int total15 = 0; int total16 = 0; int total17 = 0; int total18 = 0; int total19 = 0; int total20 = 0;
            int total21 = 0; int total22 = 0;

            foreach (var groupByStudent in grouping.GetCollection())
            {
                if (offset >= 2)
                {
                    m_objSheet.get_Range((Excel.Range)m_objSheet.Cells[m_objRange.Row + 1, m_objRange.Column], (Excel.Range)m_objSheet.Cells[m_objRange.Row + 1, m_objRange.Column]).EntireRow.Insert(Excel.XlDirection.xlDown);
                }

                var sum1 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("0"));
                var sum2 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("3"));
                var sum3 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("2"));
                var sum4 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("-1"));

                var sum5 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("1_1"));
                var sum6 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("1_2"));
                var sum7 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("1_3"));

                var sum8 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("2_1"));
                var sum9 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("2_2"));
                var sum10 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("2_3"));

                var sum11 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("3_1"));
                var sum12 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("3_2"));
                var sum13 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("3_3"));

                var sum14 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("4_1"));
                var sum15 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("4_2"));
                var sum16 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("4_3"));

                var sum17 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("5_1"));
                var sum18 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("5_2"));
                var sum19 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("5_3"));

                var sum20 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("6_1"));
                var sum21 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("6_2"));
                var sum22 = groupByStudent.Value.Value.GetAllReports().Sum(p => p.GetCount("6_3"));

                total1 += sum1;
                total2 += sum2;
                total3 += sum3;
                total4 += sum4;
                total5 += sum5;
                total6 += sum6;
                total7 += sum7;
                total8 += sum8;
                total9 += sum9;
                total10 += sum10;
                total11 += sum11;
                total12 += sum12;
                total13 += sum13;
                total14 += sum14;
                total15 += sum15;
                total16 += sum16;
                total17 += sum17;
                total18 += sum18;
                total19 += sum19;
                total20 += sum20;
                total21 += sum21;
                total22 += sum22;

                WriteCheckReportCell(reportTemplate, "no", groupByStudent.Key.ToString(), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "name", groupByStudent.Value.Key, offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "0_sum", string.Format("{0}({1})", sum1, (sum1 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "3_sum", string.Format("{0}({1})", sum2, (sum2 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "2_sum", string.Format("{0}({1})", sum3, (sum3 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "-1_sum", string.Format("{0}({1})", sum4, (sum4 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "1_1_sum", string.Format("{0}({1})", sum5, (sum5 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "1_2_sum", string.Format("{0}({1})", sum6, (sum6 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "1_3_sum", string.Format("{0}({1})", sum7, (sum7 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "2_1_sum", string.Format("{0}({1})", sum8, (sum8 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "2_2_sum", string.Format("{0}({1})", sum9, (sum9 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "2_3_sum", string.Format("{0}({1})", sum10, (sum10 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "3_1_sum", string.Format("{0}({1})", sum11, (sum11 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "3_2_sum", string.Format("{0}({1})", sum12, (sum12 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "3_3_sum", string.Format("{0}({1})", sum13, (sum13 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "4_1_sum", string.Format("{0}({1})", sum14, (sum14 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "4_2_sum", string.Format("{0}({1})", sum15, (sum15 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "4_3_sum", string.Format("{0}({1})", sum16, (sum16 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "5_1_sum", string.Format("{0}({1})", sum17, (sum17 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "5_2_sum", string.Format("{0}({1})", sum18, (sum18 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "5_3_sum", string.Format("{0}({1})", sum19, (sum19 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "6_1_sum", string.Format("{0}({1})", sum20, (sum20 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "6_2_sum", string.Format("{0}({1})", sum21, (sum21 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
                WriteCheckReportCell(reportTemplate, "6_3_sum", string.Format("{0}({1})", sum22, (sum22 / (double)checkInDays).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);

                offset++;
            }

            offset = offset - 2;

            int studentCount = grouping.GetCollection().Count();
            WriteCheckReportCell(reportTemplate, "0_total", string.Format("{0}({1})", total1, (total1 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "3_total", string.Format("{0}({1})", total2, (total2 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "2_total", string.Format("{0}({1})", total3, (total3 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "-1_total", string.Format("{0}({1})", total4, ((checkInDays * studentCount - total1 - total2 - total3) / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "1_1_total", string.Format("{0}({1})", total5, (total5 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "1_2_total", string.Format("{0}({1})", total6, (total6 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "1_3_total", string.Format("{0}({1})", total7, (total7 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "2_1_total", string.Format("{0}({1})", total8, (total8 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "2_2_total", string.Format("{0}({1})", total9, (total9 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "2_3_total", string.Format("{0}({1})", total10, (total10 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "3_1_total", string.Format("{0}({1})", total11, (total11 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "3_2_total", string.Format("{0}({1})", total12, (total12 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "3_3_total", string.Format("{0}({1})", total13, (total13 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "4_1_total", string.Format("{0}({1})", total14, (total14 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "4_2_total", string.Format("{0}({1})", total15, (total15 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "4_3_total", string.Format("{0}({1})", total16, (total16 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "5_1_total", string.Format("{0}({1})", total17, (total17 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "5_2_total", string.Format("{0}({1})", total18, (total18 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "5_3_total", string.Format("{0}({1})", total19, (total19 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "6_1_total", string.Format("{0}({1})", total20, (total20 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "6_2_total", string.Format("{0}({1})", total21, (total21 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "6_3_total", string.Format("{0}({1})", total22, (total22 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);


            WriteCheckReportCell(reportTemplate, "0_all", string.Format("{0}({1})", total1 + total2 + total3, ((total1 + total2 + total3) / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "1_all", string.Format("{0}({1})", total4, ((checkInDays * studentCount - total1 - total2 - total3) / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "2_all", string.Format("{0}({1})", total5 + total6 + total7, ((total5 + total6 + total7) / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "3_all", string.Format("{0}({1})", total8 + total9 + total10, ((total8 + total9 + total10) / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "4_all", string.Format("{0}({1})", total11 + total12 + total13, ((total11 + total12 + total13) / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "5_all", string.Format("{0}({1})", total14 + total15 + total16, ((total14 + total15 + total16) / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "6_all", string.Format("{0}({1})", total17 + total18 + total19, ((total17 + total18 + total9) / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "7_all", string.Format("{0}({1})", total20 + total21 + total22, ((total20 + total21 + total22) / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);

            m_objSheet.get_Range(string.Format("A{0}", 7 + offset)).Value = string.Format("统计日期：{0}", date.ToString("yyyy.MM.dd"));
        }

        private void DoGenerateCheckReportsGradeByGrade(
            string className, GrowUpReportDataAccess.CheckReportGroupByStudent grouping, ReportTemplate reportTemplate, int checkInDays, int offset,
            ref int total1, ref int total2, ref int total3, ref int total4, ref int total5, ref int total6, ref int total7, ref int total8, ref int total9, ref int total10,
            ref int total11, ref int total12, ref int total13, ref int total14, ref int total15, ref int total16, ref int total17, ref int total18, ref int total19, ref int total20,
            ref int total21, ref int total22, ref int totalStudentCount)
        {
            checkInDays = checkInDays == 0 ? 1 : checkInDays;

            var sum1 = ComputeTotalByClass(grouping, "0");
            var sum2 = ComputeTotalByClass(grouping, "3");
            var sum3 = ComputeTotalByClass(grouping, "2");
            var sum4 = ComputeTotalByClass(grouping, "-1");
            var sum5 = ComputeTotalByClass(grouping, "1_1");
            var sum6 = ComputeTotalByClass(grouping, "1_2");
            var sum7 = ComputeTotalByClass(grouping, "1_3");
            var sum8 = ComputeTotalByClass(grouping, "2_1");
            var sum9 = ComputeTotalByClass(grouping, "2_2");
            var sum10 = ComputeTotalByClass(grouping, "2_3");
            var sum11 = ComputeTotalByClass(grouping, "3_1");
            var sum12 = ComputeTotalByClass(grouping, "3_2");
            var sum13 = ComputeTotalByClass(grouping, "3_3");
            var sum14 = ComputeTotalByClass(grouping, "4_1");
            var sum15 = ComputeTotalByClass(grouping, "4_2");
            var sum16 = ComputeTotalByClass(grouping, "4_3");
            var sum17 = ComputeTotalByClass(grouping, "5_1");
            var sum18 = ComputeTotalByClass(grouping, "5_2");
            var sum19 = ComputeTotalByClass(grouping, "5_3");
            var sum20 = ComputeTotalByClass(grouping, "6_1");
            var sum21 = ComputeTotalByClass(grouping, "6_2");
            var sum22 = ComputeTotalByClass(grouping, "6_3");

            total1 += sum1;
            total2 += sum2;
            total3 += sum3;
            total4 += sum4;
            total5 += sum5;
            total6 += sum6;
            total7 += sum7;
            total8 += sum8;
            total9 += sum9;
            total10 += sum10;
            total11 += sum11;
            total12 += sum12;
            total13 += sum13;
            total14 += sum14;
            total15 += sum15;
            total16 += sum16;
            total17 += sum17;
            total18 += sum18;
            total19 += sum19;
            total20 += sum20;
            total21 += sum21;
            total22 += sum22;

            int studentCount = grouping.GetCollection().Count();
            totalStudentCount += studentCount;
            WriteCheckReportCell(reportTemplate, "no", className, offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "name", studentCount.ToString(), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "0_sum", string.Format("{0}({1})", sum1, (sum1 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "3_sum", string.Format("{0}({1})", sum2, (sum2 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "2_sum", string.Format("{0}({1})", sum3, (sum3 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "-1_sum", string.Format("{0}({1})", sum4, (sum4 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "1_1_sum", string.Format("{0}({1})", sum5, (sum5 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "1_2_sum", string.Format("{0}({1})", sum6, (sum6 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "1_3_sum", string.Format("{0}({1})", sum7, (sum7 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "2_1_sum", string.Format("{0}({1})", sum8, (sum8 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "2_2_sum", string.Format("{0}({1})", sum9, (sum9 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "2_3_sum", string.Format("{0}({1})", sum10, (sum10 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "3_1_sum", string.Format("{0}({1})", sum11, (sum11 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "3_2_sum", string.Format("{0}({1})", sum12, (sum12 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "3_3_sum", string.Format("{0}({1})", sum13, (sum13 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "4_1_sum", string.Format("{0}({1})", sum14, (sum14 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "4_2_sum", string.Format("{0}({1})", sum15, (sum15 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "4_3_sum", string.Format("{0}({1})", sum16, (sum16 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "5_1_sum", string.Format("{0}({1})", sum17, (sum17 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "5_2_sum", string.Format("{0}({1})", sum18, (sum18 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "5_3_sum", string.Format("{0}({1})", sum19, (sum19 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "6_1_sum", string.Format("{0}({1})", sum20, (sum20 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "6_2_sum", string.Format("{0}({1})", sum21, (sum21 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
            WriteCheckReportCell(reportTemplate, "6_3_sum", string.Format("{0}({1})", sum22, (sum22 / ((double)checkInDays * studentCount)).ToString("0.00%")), offset, ReportTemplate.ReportType.Report5);
        }

        private void WriteStatsCell(string gradeName, ReportTemplate reportTemplate, string category, string item, string val, int offset)
        {
            string column = string.Empty;
            string row = string.Empty;
            var range = reportTemplate.GetPos(string.Format("{0}_{1}", category, item), ReportTemplate.ReportType.Report3);
            var ignorePos = reportTemplate.GetIgnorePos(gradeName, ReportTemplate.IgnoreType.Ignore2);
            if (!string.IsNullOrEmpty(range))
            {
                if (string.IsNullOrEmpty(ignorePos) || !ignorePos.Contains(range))
                {
                    column = range[0].ToString();
                    row = range.Substring(1);
                    m_objRange = m_objSheet.get_Range(string.Format("{0}{1}", column, Convert.ToInt32(row) + offset), m_objOpt);
                    m_objRange.Value = val;
                }
            }
        }

        private void WriteCheckReportCell(ReportTemplate reportTemplate, string state, string val, int offset, ReportTemplate.ReportType reportType)
        {
            if (!string.IsNullOrEmpty(state))
            {
                string column = string.Empty;
                string row = string.Empty;
                var range = reportTemplate.GetPos(state, reportType);
                if (!string.IsNullOrEmpty(range))
                {
                    column = range[0].ToString();
                    row = range.Substring(1);
                    m_objRange = m_objSheet.get_Range(string.Format("{0}{1}", column, Convert.ToInt32(row) + offset), m_objOpt);
                    m_objRange.Value = val;
                }
            }
        }

        private int ComputeTotalByClass(GrowUpReportDataAccess.CheckReportGroupByStudent groupByStudent, string state)
        {
            return groupByStudent.GetCollection().Sum(a => a.Value.Value.GetAllReports().Sum(p => p.GetCount(state)));
        }

        private void MergeLevel(int currentRow, string cell, int level = int.MaxValue)
        {
            //将第三级单元格合并
            int last = currentRow;
            int move = currentRow;
            int idx = 0;
            while (idx <= level)
            {
                var val = m_objSheet.get_Range(string.Format("{0}{1}", cell, move), m_objOpt).Value;
                if (val != null)
                {
                    m_objSheet.Range[string.Format("{0}{1}:{0}{2}", cell, move, last)].Merge();
                    break;
                }
                else
                    move--;

                idx++;
            }
        }

        private void KillProcess()
        {
            string processName = "Excel";
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();
            //得到所有打开的进程
            try
            {
                foreach (Process thisproc in Process.GetProcessesByName(processName))
                {
                    if (!thisproc.CloseMainWindow())
                    {
                        thisproc.Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
            }
        }

        private class ReportTemplate
        {
            private Dictionary<string, string> report1Map;
            private Dictionary<string, string> report2Map;
            private Dictionary<string, string> report3Map;
            private Dictionary<string, string> report4Map;
            private Dictionary<string, string> report5Map;
            private Dictionary<string, KeyValuePair<string, string>> ageRangeMap;
            private Dictionary<string, string> report2Ignore;
            private Dictionary<string, string> report3Ignore;

            public ReportTemplate()
            {
                #region report1
                report1Map = new Dictionary<string, string>
                {
                    { "1_1_1_Item", "D3" },
                    { "1_1_1_Time", "E3" },
                    { "1_1_1_Desc", "F3" },
                    { "1_1_1_Pic",  "G3" },

                    { "1_1_2_Item", "D4" },
                    { "1_1_2_Time", "E4" },
                    { "1_1_2_Desc", "F4" },
                    { "1_1_2_Pic",  "G4" },

                    { "1_1_3_Item", "D5" },
                    { "1_1_3_Time", "E5" },
                    { "1_1_3_Desc", "F5" },
                    { "1_1_3_Pic",  "G5" },

                    { "1_2_1_Item", "D6" },
                    { "1_2_1_Time", "E6" },
                    { "1_2_1_Desc", "F6" },
                    { "1_2_1_Pic",  "G6" },

                    { "1_2_2_Item", "D7" },
                    { "1_2_2_Time", "E7" },
                    { "1_2_2_Desc", "F7" },
                    { "1_2_2_Pic",  "G7" },

                    { "1_2_3_Item", "D8" },
                    { "1_2_3_Time", "E8" },
                    { "1_2_3_Desc", "F8" },
                    { "1_2_3_Pic",  "G8" },

                    { "1_3_1_Item", "D9" },
                    { "1_3_1_Time", "E9" },
                    { "1_3_1_Desc", "F9" },
                    { "1_3_1_Pic",  "G9" },

                    { "1_3_2_Item", "D10" },
                    { "1_3_2_Time", "E10" },
                    { "1_3_2_Desc", "F10" },
                    { "1_3_2_Pic",  "G10" },

                    { "1_3_3_Item", "D11" },
                    { "1_3_3_Time", "E11" },
                    { "1_3_3_Desc", "F11" },
                    { "1_3_3_Pic",  "G11" },

                    { "2_1_1_Item", "D13" },
                    { "2_1_1_Time", "E13" },
                    { "2_1_1_Desc", "F13" },
                    { "2_1_1_Pic",  "G13" },

                    { "2_1_2_Item", "D14" },
                    { "2_1_2_Time", "E14" },
                    { "2_1_2_Desc", "F14" },
                    { "2_1_2_Pic",  "G14" },

                    { "2_1_3_Item", "D15" },
                    { "2_1_3_Time", "E15" },
                    { "2_1_3_Desc", "F15" },
                    { "2_1_3_Pic",  "G15" },

                    { "2_2_1_Item", "D16" },
                    { "2_2_1_Time", "E16" },
                    { "2_2_1_Desc", "F16" },
                    { "2_2_1_Pic",  "G16" },

                    { "2_2_2_Item", "D17" },
                    { "2_2_2_Time", "E17" },
                    { "2_2_2_Desc", "F17" },
                    { "2_2_2_Pic",  "G17" },

                    { "2_2_3_Item", "D18" },
                    { "2_2_3_Time", "E18" },
                    { "2_2_3_Desc", "F18" },
                    { "2_2_3_Pic",  "G18" },

                    { "3_1_1_Item", "D20" },
                    { "3_1_1_Time", "E20" },
                    { "3_1_1_Desc", "F20" },
                    { "3_1_1_Pic",  "G20" },

                    { "3_1_2_Item", "D21" },
                    { "3_1_2_Time", "E21" },
                    { "3_1_2_Desc", "F21" },
                    { "3_1_2_Pic",  "G21" },

                    { "3_1_3_Item", "D22" },
                    { "3_1_3_Time", "E22" },
                    { "3_1_3_Desc", "F22" },
                    { "3_1_3_Pic",  "G22" },

                    { "3_1_4_Item", "D23" },
                    { "3_1_4_Time", "E23" },
                    { "3_1_4_Desc", "F23" },
                    { "3_1_4_Pic",  "G23" },

                    { "3_2_1_Item", "D24" },
                    { "3_2_1_Time", "E24" },
                    { "3_2_1_Desc", "F24" },
                    { "3_2_1_Pic",  "G24" },

                    { "3_2_2_Item", "D25" },
                    { "3_2_2_Time", "E25" },
                    { "3_2_2_Desc", "F25" },
                    { "3_2_2_Pic",  "G25" },

                    { "3_2_3_Item", "D26" },
                    { "3_2_3_Time", "E26" },
                    { "3_2_3_Desc", "F26" },
                    { "3_2_3_Pic",  "G26" },

                    { "4_1_1_Item", "D28" },
                    { "4_1_1_Time", "E28" },
                    { "4_1_1_Desc", "F28" },
                    { "4_1_1_Pic",  "G28" },

                    { "4_1_2_Item", "D29" },
                    { "4_1_2_Time", "E29" },
                    { "4_1_2_Desc", "F29" },
                    { "4_1_2_Pic",  "G29" },

                    { "4_1_3_Item", "D30" },
                    { "4_1_3_Time", "E30" },
                    { "4_1_3_Desc", "F30" },
                    { "4_1_3_Pic",  "G30" },

                    { "4_2_1_Item", "D31" },
                    { "4_2_1_Time", "E31" },
                    { "4_2_1_Desc", "F31" },
                    { "4_2_1_Pic",  "G31" },

                    { "4_2_2_Item", "D32" },
                    { "4_2_2_Time", "E32" },
                    { "4_2_2_Desc", "F32" },
                    { "4_2_2_Pic",  "G32" },

                    { "4_2_3_Item", "D33" },
                    { "4_2_3_Time", "E33" },
                    { "4_2_3_Desc", "F33" },
                    { "4_2_3_Pic",  "G33" },

                    { "5_1_1_Item", "D35" },
                    { "5_1_1_Time", "E35" },
                    { "5_1_1_Desc", "F35" },
                    { "5_1_1_Pic",  "G35" },

                    { "5_1_2_Item", "D36" },
                    { "5_1_2_Time", "E36" },
                    { "5_1_2_Desc", "F36" },
                    { "5_1_2_Pic",  "G36" },

                    { "5_2_1_Item", "D37" },
                    { "5_2_1_Time", "E37" },
                    { "5_2_1_Desc", "F37" },
                    { "5_2_1_Pic",  "G37" },

                    { "5_2_2_Item", "D38" },
                    { "5_2_2_Time", "E38" },
                    { "5_2_2_Desc", "F38" },
                    { "5_2_2_Pic",  "G38" },
                };
                #endregion

                #region report2
                report2Map = new Dictionary<string, string>
                {
                    { "1_1_1_(1)",  "D5"},
                    { "1_1_1_(2)",  "E5"},

                    { "1_1_2_(1)",  "F5"},
                    { "1_1_2_(2)",  "G5"},
                    { "1_1_2_(3)",  "H5"},

                    { "1_1_3_(1)",  "I5"},
                    { "1_1_3_(2)",  "J5"},
                    { "1_1_3_(3)",  "K5"},

                    { "1_2_1_(1)",  "L5"},
                    { "1_2_1_(2)",  "M5"},
                    { "1_2_1_(3)",  "N5"},
                    { "1_2_1_(4)",  "O5"},
                    { "1_2_1_(5)",  "P5"},

                    { "1_2_2_(1)",  "Q5"},
                    { "1_2_2_(2)",  "R5"},
                    { "1_2_2_(3)",  "S5"},
                    { "1_2_2_(4)",  "T5"},
                    { "1_2_2_(5)",  "U5"},

                    { "1_2_3_(1)",  "V5"},
                    { "1_2_3_(2)",  "W5"},
                    { "1_2_3_(3)",  "X5"},
                    { "1_2_3_(4)",  "Y5"},

                    { "1_3_1_(1)",  "Z5"},
                    { "1_3_1_(2)",  "AA5"},
                    { "1_3_1_(3)",  "AB5"},
                    { "1_3_1_(4)",  "AC5"},
                    { "1_3_1_(5)",  "AD5"},
                    { "1_3_1_(6)",  "AE5"},

                    { "1_3_2_(1)",  "AF5"},
                    { "1_3_2_(2)",  "AG5"},
                    { "1_3_2_(3)",  "AH5"},

                    { "1_3_3_(1)",  "AI5"},
                    { "1_3_3_(2)",  "AJ5"},
                    { "1_3_3_(3)",  "AK5"},
                    { "1_3_3_(4)",  "AL5"},

                    { "2_1_1_(1)",  "AM5"},
                    { "2_1_1_(2)",  "AN5"},
                    { "2_1_1_(3)",  "AO5"},

                    { "2_1_2_(1)",  "AP5"},
                    { "2_1_2_(2)",  "AQ5"},
                    { "2_1_2_(3)",  "AR5"},
                    { "2_1_2_(4)",  "AS5"},

                    { "2_1_3_(1)",  "AT5"},
                    { "2_1_3_(2)",  "AU5"},
                    { "2_1_3_(3)",  "AV5"},
                    { "2_1_3_(4)",  "AW5"},

                    { "2_2_1_(1)",  "AX5"},
                    { "2_2_1_(2)",  "AY5"},
                    { "2_2_1_(3)",  "AZ5"},

                    { "2_2_2_(1)",  "BA5"},
                    { "2_2_2_(2)",  "BB5"},
                    { "2_2_2_(3)",  "BC5"},
                    { "2_2_2_(4)",  "BD5"},

                    { "2_2_3_(1)",  "BE5"},
                    { "2_2_3_(2)",  "BF5"},
                    { "2_2_3_(3)",  "BG5"},

                    { "3_1_1_(1)",  "BH5"},
                    { "3_1_1_(2)",  "BI5"},
                    { "3_1_1_(3)",  "BJ5"},

                    { "3_1_2_(1)",  "BK5"},
                    { "3_1_2_(2)",  "BL5"},
                    { "3_1_2_(3)",  "BM5"},
                    { "3_1_2_(4)",  "BN5"},
                    { "3_1_2_(5)",  "BO5"},

                    { "3_1_3_(1)",  "BP5"},
                    { "3_1_3_(2)",  "BQ5"},
                    { "3_1_3_(3)",  "BR5"},
                    { "3_1_3_(4)",  "BS5"},
                    { "3_1_3_(5)",  "BT5"},

                    { "3_1_4_(1)",  "BU5"},
                    { "3_1_4_(2)",  "BV5"},
                    { "3_1_4_(3)",  "BW5"},
                    { "3_1_4_(4)",  "BX5"},

                    { "3_2_1_(1)",  "BY5"},
                    { "3_2_1_(2)",  "BZ5"},

                    { "3_2_2_(1)",  "CA5"},
                    { "3_2_2_(2)",  "CB5"},
                    { "3_2_2_(3)",  "CC5"},
                    { "3_2_2_(4)",  "CD5"},
                    { "3_2_2_(5)",  "CE5"},

                    { "3_2_3_(1)",  "CF5"},
                    { "3_2_3_(2)",  "CG5"},
                    { "3_2_3_(3)",  "CH5"},
                    { "3_2_3_(4)",  "CI5"},

                    { "4_1_1_(1)",  "CJ5"},
                    { "4_1_1_(2)",  "CK5"},
                    { "4_1_1_(3)",  "CL5"},

                    { "4_1_2_(1)",  "CM5"},
                    { "4_1_2_(2)",  "CN5"},
                    { "4_1_2_(3)",  "CO5"},
                    { "4_1_2_(4)",  "CP5"},
                    { "4_1_2_(5)",  "CQ5"},

                    { "4_1_3_(1)",  "CR5"},
                    { "4_1_3_(2)",  "CS5"},
                    { "4_1_3_(3)",  "CT5"},
                    { "4_1_3_(4)",  "CU5"},
                    { "4_1_3_(5)",  "CV5"},

                    { "4_2_1_(1)",  "CW5"},
                    { "4_2_1_(2)",  "CX5"},

                    { "4_2_2_(1)",  "CY5"},
                    { "4_2_2_(2)",  "CZ5"},
                    { "4_2_2_(3)",  "DA5"},
                    { "4_2_2_(4)",  "DB5"},

                    { "4_2_3_(1)",  "DC5"},
                    { "4_2_3_(2)",  "DD5"},
                    { "4_2_3_(3)",  "DE5"},

                    { "5_1_1_(1)",  "DF5"},
                    { "5_1_1_(2)",  "DG5"},

                    { "5_1_2_(1)",  "DH5"},
                    { "5_1_2_(2)",  "DI5"},

                    { "5_2_1_(1)",  "DJ5"},
                    { "5_2_1_(2)",  "DK5"},
                    { "5_2_1_(3)",  "DL5"},

                    { "5_2_2_(1)",  "DM5"},
                    { "5_2_2_(2)",  "DN5"},
                    { "5_2_2_(3)",  "DO5"},
                    { "5_2_2_(4)",  "DP5"},
                };
                #endregion

                //#region report2_ignore
                //report2Ignore = new Dictionary<string, string>
                //{
                //    { "小班", "G5,X5,AG5,AK5,AN5,AV5,BC5,BE5,BF5,BI5,BM5,BN5,BS5,BW5,CC5,CD5,CK5,CN5,CO5,CP5,CU5,DD5,DK5" },
                //    { "中班", "X5,AG5,AV5,BC5,BF5,BI5,BS5,BW5,CK5,CP5,DK5" }
                //};
                //#endregion

                #region report2_ignore
                report2Ignore = new Dictionary<string, string>
                {
                    { "小班", "H5,Y5,AH5,AL5,AO5,AW5,BD5,BF5,BG5,BJ5,BN5,BO5,BT5,BX5,CD5,CE5,CL5,CO5,CP5,CQ5,CV5,DE5,DL5" },
                    { "中班", "Y5,AH5,AW5,BD5,BG5,BJ5,BT5,BX5,CL5,CQ5,DL5" }
                };
                #endregion

                #region report3
                report3Map = new Dictionary<string, string>
                {
                    { "1_1_1_(T)",  "D3"},
                    { "1_1_1_(1)",  "E3"},
                    { "1_1_1_(2)",  "F3"},

                    { "1_1_2_(T)",  "D4"},
                    { "1_1_2_(1)",  "E4"},
                    { "1_1_2_(2)",  "F4"},
                    { "1_1_2_(3)",  "G4"},

                    { "1_1_3_(T)",  "D5"},
                    { "1_1_3_(1)",  "E5"},
                    { "1_1_3_(2)",  "F5"},
                    { "1_1_3_(3)",  "G5"},

                    { "1_2_1_(T)",  "D6"},
                    { "1_2_1_(1)",  "E6"},
                    { "1_2_1_(2)",  "F6"},
                    { "1_2_1_(3)",  "G6"},
                    { "1_2_1_(4)",  "H6"},
                    { "1_2_1_(5)",  "I6"},

                    { "1_2_2_(T)",  "D7"},
                    { "1_2_2_(1)",  "E7"},
                    { "1_2_2_(2)",  "F7"},
                    { "1_2_2_(3)",  "G7"},
                    { "1_2_2_(4)",  "H7"},
                    { "1_2_2_(5)",  "I7"},

                    { "1_2_3_(T)",  "D8"},
                    { "1_2_3_(1)",  "E8"},
                    { "1_2_3_(2)",  "F8"},
                    { "1_2_3_(3)",  "G8"},
                    { "1_2_3_(4)",  "H8"},

                    { "1_3_1_(T)",  "D9"},
                    { "1_3_1_(1)",  "E9"},
                    { "1_3_1_(2)",  "F9"},
                    { "1_3_1_(3)",  "G9"},
                    { "1_3_1_(4)",  "H9"},
                    { "1_3_1_(5)",  "I9"},
                    { "1_3_1_(6)",  "J9"},

                    { "1_3_2_(T)",  "D10"},
                    { "1_3_2_(1)",  "E10"},
                    { "1_3_2_(2)",  "F10"},
                    { "1_3_2_(3)",  "G10"},

                    { "1_3_3_(T)",  "D11"},
                    { "1_3_3_(1)",  "E11"},
                    { "1_3_3_(2)",  "F11"},
                    { "1_3_3_(3)",  "G11"},
                    { "1_3_3_(4)",  "H11"},

                    { "2_1_1_(T)",  "D13"},
                    { "2_1_1_(1)",  "E13"},
                    { "2_1_1_(2)",  "F13"},
                    { "2_1_1_(3)",  "G13"},

                    { "2_1_2_(T)",  "D14"},
                    { "2_1_2_(1)",  "E14"},
                    { "2_1_2_(2)",  "F14"},
                    { "2_1_2_(3)",  "G14"},
                    { "2_1_2_(4)",  "H14"},

                    { "2_1_3_(T)",  "D15"},
                    { "2_1_3_(1)",  "E15"},
                    { "2_1_3_(2)",  "F15"},
                    { "2_1_3_(3)",  "G15"},
                    { "2_1_3_(4)",  "H15"},

                    { "2_2_1_(T)",  "D16"},
                    { "2_2_1_(1)",  "E16"},
                    { "2_2_1_(2)",  "F16"},
                    { "2_2_1_(3)",  "G16"},

                    { "2_2_2_(T)",  "D17"},
                    { "2_2_2_(1)",  "E17"},
                    { "2_2_2_(2)",  "F17"},
                    { "2_2_2_(3)",  "G17"},
                    { "2_2_2_(4)",  "H17"},

                    { "2_2_3_(T)",  "D18"},
                    { "2_2_3_(1)",  "E18"},
                    { "2_2_3_(2)",  "F18"},
                    { "2_2_3_(3)",  "G18"},

                    { "3_1_1_(T)",  "D20"},
                    { "3_1_1_(1)",  "E20"},
                    { "3_1_1_(2)",  "F20"},
                    { "3_1_1_(3)",  "G20"},

                    { "3_1_2_(T)",  "D21"},
                    { "3_1_2_(1)",  "E21"},
                    { "3_1_2_(2)",  "F21"},
                    { "3_1_2_(3)",  "G21"},
                    { "3_1_2_(4)",  "H21"},
                    { "3_1_2_(5)",  "I21"},

                    { "3_1_3_(T)",  "D22"},
                    { "3_1_3_(1)",  "E22"},
                    { "3_1_3_(2)",  "F22"},
                    { "3_1_3_(3)",  "G22"},
                    { "3_1_3_(4)",  "H22"},
                    { "3_1_3_(5)",  "I22"},

                    { "3_1_4_(T)",  "D23"},
                    { "3_1_4_(1)",  "E23"},
                    { "3_1_4_(2)",  "F23"},
                    { "3_1_4_(3)",  "G23"},
                    { "3_1_4_(4)",  "H23"},

                    { "3_2_1_(T)",  "D24"},
                    { "3_2_1_(1)",  "E24"},
                    { "3_2_1_(2)",  "F24"},

                    { "3_2_2_(T)",  "D25"},
                    { "3_2_2_(1)",  "E25"},
                    { "3_2_2_(2)",  "F25"},
                    { "3_2_2_(3)",  "G25"},
                    { "3_2_2_(4)",  "H25"},
                    { "3_2_2_(5)",  "I25"},

                    { "3_2_3_(T)",  "D26"},
                    { "3_2_3_(1)",  "E26"},
                    { "3_2_3_(2)",  "F26"},
                    { "3_2_3_(3)",  "G26"},
                    { "3_2_3_(4)",  "H26"},

                    { "4_1_1_(T)",  "D28"},
                    { "4_1_1_(1)",  "E28"},
                    { "4_1_1_(2)",  "F28"},
                    { "4_1_1_(3)",  "G28"},

                    { "4_1_2_(T)",  "D29"},
                    { "4_1_2_(1)",  "E29"},
                    { "4_1_2_(2)",  "F29"},
                    { "4_1_2_(3)",  "G29"},
                    { "4_1_2_(4)",  "H29"},
                    { "4_1_2_(5)",  "I29"},

                    { "4_1_3_(T)",  "D30"},
                    { "4_1_3_(1)",  "E30"},
                    { "4_1_3_(2)",  "F30"},
                    { "4_1_3_(3)",  "G30"},
                    { "4_1_3_(4)",  "H30"},
                    { "4_1_3_(5)",  "I30"},

                    { "4_2_1_(T)",  "D31"},
                    { "4_2_1_(1)",  "E31"},
                    { "4_2_1_(2)",  "F31"},

                    { "4_2_2_(T)",  "D32"},
                    { "4_2_2_(1)",  "E32"},
                    { "4_2_2_(2)",  "F32"},
                    { "4_2_2_(3)",  "G32"},
                    { "4_2_2_(4)",  "H32"},

                    { "4_2_3_(T)",  "D33"},
                    { "4_2_3_(1)",  "E33"},
                    { "4_2_3_(2)",  "F33"},
                    { "4_2_3_(3)",  "G33"},

                    { "5_1_1_(T)",  "D35"},
                    { "5_1_1_(1)",  "E35"},
                    { "5_1_1_(2)",  "F35"},

                    { "5_1_2_(T)",  "D36"},
                    { "5_1_2_(1)",  "E36"},
                    { "5_1_2_(2)",  "F36"},

                    { "5_2_1_(T)",  "D37"},
                    { "5_2_1_(1)",  "E37"},
                    { "5_2_1_(2)",  "F37"},
                    { "5_2_1_(3)",  "G37"},

                    { "5_2_2_(T)",  "D38"},
                    { "5_2_2_(1)",  "E38"},
                    { "5_2_2_(2)",  "F38"},
                    { "5_2_2_(3)",  "G38"},
                    { "5_2_2_(4)",  "H38"}
                };
                #endregion

                #region report3_ignore
                report3Ignore = new Dictionary<string, string>
                {
                    { "小班", "G4,H8,G10,H11,G13,H15,H17,F18,G18,G20,H21,I21,I22,H23,H25,I25,G28,G29,H29,I29,I30,G33,G37" },
                    { "中班", "H8,G10,H15,H17,G18,G20,I22,H23,G28,I29,G37" }
                };
                #endregion

                #region report4
                report4Map = new Dictionary<string, string>
                {
                    {"date", "A3"},
                    { "0",  "B3"},
                    { "3",  "C3"},
                    { "2",  "D3"},
                    { "-1",  "E3"},
                    { "1_1",  "F3"},
                    { "1_2",  "G3"},
                    { "1_3",  "H3"},
                    { "2_1",  "I3"},
                    { "2_2",  "J3"},
                    { "2_3",  "K3"},
                    { "3_1",  "L3"},
                    { "3_2",  "M3"},
                    { "3_3",  "N3"},
                    { "4_1",  "O3"},
                    { "4_2",  "P3"},
                    { "4_3",  "Q3"},
                    { "5_1",  "R3"},
                    { "5_2",  "S3"},
                    { "5_3",  "T3"},
                    { "6_1",  "U3"},
                    { "6_2",  "V3"},
                    { "6_3",  "W3"},
                    { "0_sum", "B5"},
                    { "3_sum", "C5"},
                    { "2_sum", "D5"},
                    { "-1_sum", "E5"},
                    { "1_1_sum",  "F5"},
                    { "1_2_sum",  "G5"},
                    { "1_3_sum",  "H5"},
                    { "2_1_sum",  "I5"},
                    { "2_2_sum",  "J5"},
                    { "2_3_sum",  "K5"},
                    { "3_1_sum",  "L5"},
                    { "3_2_sum",  "M5"},
                    { "3_3_sum",  "N5"},
                    { "4_1_sum",  "O5"},
                    { "4_2_sum",  "P5"},
                    { "4_3_sum",  "Q5"},
                    { "5_1_sum",  "R5"},
                    { "5_2_sum",  "S5"},
                    { "5_3_sum",  "T5"},
                    { "6_1_sum",  "U5"},
                    { "6_2_sum",  "V5"},
                    { "6_3_sum",  "W5"},
                    { "1_total",  "B6"},
                    { "2_total",  "F6"},
                    { "3_total",  "I6"},
                    { "4_total",  "L6"},
                    { "5_total",  "O6"},
                    { "6_total",  "R6"},
                    { "7_total",  "U6"}
                };
                #endregion

                #region report5
                report5Map = new Dictionary<string, string>
                {
                    {"no", "A3"},
                    {"name", "B3"},
                    { "0_sum", "C3"},
                    { "3_sum", "D3"},
                    { "2_sum", "E3"},
                    { "-1_sum", "F3"},
                    { "1_1_sum",  "G3"},
                    { "1_2_sum",  "H3"},
                    { "1_3_sum",  "I3"},
                    { "2_1_sum",  "J3"},
                    { "2_2_sum",  "K3"},
                    { "2_3_sum",  "L3"},
                    { "3_1_sum",  "M3"},
                    { "3_2_sum",  "N3"},
                    { "3_3_sum",  "O3"},
                    { "4_1_sum",  "P3"},
                    { "4_2_sum",  "Q3"},
                    { "4_3_sum",  "R3"},
                    { "5_1_sum",  "S3"},
                    { "5_2_sum",  "T3"},
                    { "5_3_sum",  "U3"},
                    { "6_1_sum",  "V3"},
                    { "6_2_sum",  "W3"},
                    { "6_3_sum",  "X3"},
                    { "s_total",  "B5"},
                    { "0_total", "C5"},
                    { "3_total", "D5"},
                    { "2_total", "E5"},
                    { "-1_total", "F5"},
                    { "1_1_total",  "G5"},
                    { "1_2_total",  "H5"},
                    { "1_3_total",  "I5"},
                    { "2_1_total",  "J5"},
                    { "2_2_total",  "K5"},
                    { "2_3_total",  "L5"},
                    { "3_1_total",  "M5"},
                    { "3_2_total",  "N5"},
                    { "3_3_total",  "O5"},
                    { "4_1_total",  "P5"},
                    { "4_2_total",  "Q5"},
                    { "4_3_total",  "R5"},
                    { "5_1_total",  "S5"},
                    { "5_2_total",  "T5"},
                    { "5_3_total",  "U5"},
                    { "6_1_total",  "V5"},
                    { "6_2_total",  "W5"},
                    { "6_3_total",  "X5"},
                    { "0_all", "C6"},
                    { "1_all", "F6"},
                    { "2_all", "G6"},
                    { "3_all", "J6"},
                    { "4_all", "M6"},
                    { "5_all", "P6"},
                    { "6_all", "S6"},
                    { "7_all", "V6"},
                };
                #endregion


                ageRangeMap = new Dictionary<string, KeyValuePair<string, string>>();
                ageRangeMap.Add("report1_小班", new KeyValuePair<string, string>("3～4岁 典型表现", "H2,H12,H19,H27,H34"));
                ageRangeMap.Add("report1_中班", new KeyValuePair<string, string>("4～5岁 典型表现", "H2,H12,H19,H27,H34"));
                ageRangeMap.Add("report1_大班", new KeyValuePair<string, string>("5～6岁 典型表现", "H2,H12,H19,H27,H34"));
                ageRangeMap.Add("report3_小班", new KeyValuePair<string, string>("3～4岁 典型表现", "K2,K12,K19,K27,K34"));
                ageRangeMap.Add("report3_中班", new KeyValuePair<string, string>("4～5岁 典型表现", "K2,K12,K19,K27,K34"));
                ageRangeMap.Add("report3_大班", new KeyValuePair<string, string>("5～6岁 典型表现", "K2,K12,K19,K27,K34"));
            }

            public string GetPos(string key, ReportType type)
            {
                string pos = null;
                switch (type)
                {
                    case ReportType.Report1: report1Map.TryGetValue(key, out pos);
                        break;
                    case ReportType.Report2: report2Map.TryGetValue(key, out pos);
                        break;
                    case ReportType.Report3: report3Map.TryGetValue(key, out pos);
                        break;
                    case ReportType.Report4: report4Map.TryGetValue(key, out pos);
                        break;
                    case ReportType.Report5: report5Map.TryGetValue(key, out pos);
                        break;
                    default: break;
                }
                return pos;
            }

            public KeyValuePair<string, string> GetAgeDesc(string gradeName, string reportName)
            {
                KeyValuePair<string, string> kvp = default(KeyValuePair<string, string>);
                var remark = new GrowUpReportDataAccess().GetGradeRemark(gradeName);
                ageRangeMap.TryGetValue(string.Format("{0}_{1}", reportName, gradeName), out kvp);
                return kvp;
            }

            public string GetIgnorePos(string key, IgnoreType type)
            {
                string pos = null;
                switch (type)
                {
                    case IgnoreType.Ignore1: report2Ignore.TryGetValue(key, out pos);
                        break;
                    case IgnoreType.Ignore2: report3Ignore.TryGetValue(key, out pos);
                        break;
                    default: break;
                }
                return pos;
            }

            public enum ReportType
            {
                Report1,
                Report2,
                Report3,
                Report4,
                Report5
            }

            public enum IgnoreType
            {
                Ignore1,
                Ignore2
            }
        }
    }
}

