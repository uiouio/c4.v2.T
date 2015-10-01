using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using chuangzhiapi;
using chuangzhiapi.bean;

namespace CPTT.BusinessRule
{
    public class YlmfDataUploader
    {
        public class StudentInfoUpload
        {
            public static void UploadDataToYlmf(DataTable data)
            {
                if (data.Rows.Count > 0)
                {
                    Func<int, int> func = v =>
                    {
                        return new int[] { 2, 4 }.Contains(v) ? 1 : 0;
                    };

                    foreach (DataRow dr in data.Rows)
                    {
                        try
                        {
                            var isLeaving = false;
                            if (dr["flow_stuFlowBackState"] != null)
                            {
                                if (dr["flow_stuFlowBackState"].ToString().Trim() != "-2")
                                    isLeaving = true;
                            }

                            var cardNo = string.Empty;
                            if (!isLeaving)
                            {
                                cardNo = dr["flow_stuEnterCardNumber"] == null ? string.Empty : dr["flow_stuEnterCardNumber"].ToString();
                            }
                            else
                            {
                                cardNo = dr["flow_stuBackCardNumber"] == null ? string.Empty : dr["flow_stuBackCardNumber"].ToString();
                            }

                            var singinTime = string.Empty;
                            if (!isLeaving)
                            {
                                singinTime = dr["flow_stuFlowEnterDate"] == null ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                    : Convert.ToDateTime(dr["flow_stuFlowEnterDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else
                            {
                                singinTime = dr["flow_stuFlowEnterDate"] == null ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                    : Convert.ToDateTime(dr["flow_stuFlowBackDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                            }

                            var status = "健康";
                            if (!isLeaving)
                            {
                                status = dr["state_flowStateName"] == null ? "健康" : dr["state_flowStateName"].ToString();
                            }
                            else
                            {
                                status = "再见";
                            }


                            Singin.SingIn(new SinginBean
                            {
                                schoolNum = dr["gardenID"].ToString(),
                                serialNumber = dr["idx"].ToString(),
                                idNum = cardNo,
                                singinTime = singinTime,
                                status = status,
                                studentId = dr["info_stuNumber"].ToString(),
                                type = !isLeaving ? 2 : 1,  //和文档倒一下
                                fromtype = func(dr["flow_stuModify"] == null ? 0 : Convert.ToInt32(dr["flow_stuModify"]))
                            });
                        }
                        catch (Exception ex)
                        {
                            SystemFramework.Util.WriteLog(ex.ToString(), SystemFramework.Util.EXCEPTION_LOG_TITLE);
                        }
                    }
                }
            }
        }

        public class TeacherInfoUpload
        {
            public static void UploadDataToYlmf(DataTable data)
            {
                if (data.Rows.Count > 0)
                {
                    foreach (DataRow dr in data.Rows)
                    {
                        try
                        {
                            var isLeaving = false;
                            if (dr["teaflow_state"] != null)
                            {
                                if (dr["teaflow_state"].ToString().Trim() == "1")
                                    isLeaving = true;
                            }

                            TeacherSing.TeachSing(new TeacherSingBean
                            {
                                schoolNum = dr["gardenID"].ToString(),
                                serialNumber = dr["idx"].ToString(),
                                teacherNum = dr["T_Number"] == null ? string.Empty : dr["T_Number"].ToString(),
                                cardNum = dr["teaflow_cardnumber"] == null ? string.Empty : dr["teaflow_cardnumber"].ToString(),
                                singTime = dr["teaflow_date"] == null ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                    : Convert.ToDateTime(dr["teaflow_date"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"),
                                type = !isLeaving ? 2 : 1,
                                fromtype = 0
                            });
                        }
                        catch (Exception ex)
                        {
                            SystemFramework.Util.WriteLog(ex.ToString(), SystemFramework.Util.EXCEPTION_LOG_TITLE);
                        }
                    }
                }
            }

        }
    }
}
