using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CPTT.SystemFramework;
using CPTT.DataAccess;
using DevExpress.XtraEditors;
using ZedGraph;

namespace CPTT.BusinessRule
{
    using Excel = Microsoft.Office.Interop.Excel;
	/// <summary>
	/// RealtimeInfoStat_TeacherPrintRules 的摘要说明。
	/// </summary>
	public class RealtimeInfoStat_TeacherPrintRules
	{
		private Excel.Application m_objExcel = null;
		private Excel.Workbooks m_objBooks = null;
		private Excel._Workbook m_objBook = null;
		private Excel.Sheets m_objSheets = null;
		private Excel._Worksheet m_objSheet = null;
		private Excel.Range m_objRange = null;
		private object m_objOpt = System.Reflection.Missing.Value;
		private string excelPath = AppDomain.CurrentDomain.BaseDirectory;
		private ZedGraphControl zedGraph_RealtimeMorningInfoStatTeacher;

		public RealtimeInfoStat_TeacherPrintRules()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void RealtimeMorningPrint(DataSet dsRealtimeInfoStat_Teacher,string savePath)
		{
			KillProcess();
			try
			{
				m_objExcel = new Excel.Application();
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\RealtimeMorningInfoStat_Teacher.xls",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt);
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;

				//获取第一个打印页
				m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

				object[,] objData = null;
					
				if ( dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count > 0 )
				{
					objData = new object[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count,7];
 
					for ( int i=0; i<dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count; i++ )
					{
						objData[i,0] = dsRealtimeInfoStat_Teacher.Tables[0].Rows[i][0].ToString();
						objData[i,1] = dsRealtimeInfoStat_Teacher.Tables[0].Rows[i][1].ToString();
						objData[i,2] = dsRealtimeInfoStat_Teacher.Tables[0].Rows[i][2].ToString();
						objData[i,3] = dsRealtimeInfoStat_Teacher.Tables[0].Rows[i][3].ToString();
						objData[i,4] = dsRealtimeInfoStat_Teacher.Tables[0].Rows[i][4].ToString();
						objData[i,5] = dsRealtimeInfoStat_Teacher.Tables[0].Rows[i][5].ToString();
						objData[i,6] = dsRealtimeInfoStat_Teacher.Tables[0].Rows[i][6].ToString();
					}
				}

				m_objRange = m_objSheet.get_Range("A7",m_objOpt);
				m_objRange = m_objRange.get_Resize(dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count,7);

				m_objRange.Value = objData;

				m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
				m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
				m_objRange.WrapText = true;
				m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				m_objRange.Font.Size = 10;

				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count+8,1],m_objSheet.Cells[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count+8,1]);
				m_objRange.Value = "园所信息:";
				m_objRange.Font.Bold = true;
				m_objRange.Font.Size = 12;
				m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
				m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count+8,2],m_objSheet.Cells[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count+8,3]);
				m_objRange.MergeCells = true;;
				m_objRange.Value = " "+new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
				m_objRange.Font.Size = 12;
				m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
				m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count+9,1],m_objSheet.Cells[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count+9,1]);
				m_objRange.Value = "统计日期:";
				m_objRange.Font.Bold = true;
				m_objRange.Font.Size = 12;
				m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
				m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count+9,2],m_objSheet.Cells[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count+9,3]);
				m_objRange.MergeCells = true;
				m_objRange.Value = " "+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				m_objRange.Font.Size = 12;
				m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
				m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

				m_objBook.SaveAs(savePath, m_objOpt, m_objOpt,
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
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
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
	
		public void RealtimeBackPrint(DataSet dsRealtimeInfoStat_Teacher,string savePath)
		{
			KillProcess();
			try
			{
				m_objExcel = new Excel.Application();
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\RealtimeBackInfoStat_Teacher.xls",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt);
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;

				//获取第一个打印页
				m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

				object[,] objData = null;
					
				if ( dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count > 0 )
				{
					objData = new object[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count,6];
 
					for ( int i=0; i<dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count; i++ )
					{
						objData[i,0] = dsRealtimeInfoStat_Teacher.Tables[0].Rows[i][0].ToString();
						objData[i,1] = dsRealtimeInfoStat_Teacher.Tables[0].Rows[i][1].ToString();
						objData[i,2] = dsRealtimeInfoStat_Teacher.Tables[0].Rows[i][2].ToString();
						objData[i,3] = dsRealtimeInfoStat_Teacher.Tables[0].Rows[i][3].ToString();
						objData[i,4] = dsRealtimeInfoStat_Teacher.Tables[0].Rows[i][4].ToString();
						objData[i,5] = dsRealtimeInfoStat_Teacher.Tables[0].Rows[i][5].ToString();
					}
				}

				m_objRange = m_objSheet.get_Range("A7",m_objOpt);
				m_objRange = m_objRange.get_Resize(dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count,6);

				m_objRange.Value = objData;

				m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
				m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
				m_objRange.WrapText = true;
				m_objRange.Borders.LineStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				m_objRange.Font.Size = 10;

				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count+8,1],m_objSheet.Cells[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count+8,1]);
				m_objRange.Value = "园所信息:";
				m_objRange.Font.Bold = true;
				m_objRange.Font.Size = 12;
				m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
				m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count+8,2],m_objSheet.Cells[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count+8,3]);
				m_objRange.MergeCells = true;;
				m_objRange.Value = " "+new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
				m_objRange.Font.Size = 12;
				m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
				m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count+9,1],m_objSheet.Cells[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count+9,1]);
				m_objRange.Value = "统计日期:";
				m_objRange.Font.Bold = true;
				m_objRange.Font.Size = 12;
				m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
				m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count+9,2],m_objSheet.Cells[dsRealtimeInfoStat_Teacher.Tables[0].Rows.Count+9,3]);
				m_objRange.MergeCells = true;
				m_objRange.Value = " "+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				m_objRange.Font.Size = 12;
				m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
				m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

				m_objBook.SaveAs(savePath, m_objOpt, m_objOpt,
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
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
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

		public Bitmap RealtimeMorningInfoStat_TeacherGraphPrint(string getDept,PanelControl pControl)
		{
			using ( RealtimeInfo_TeacherDataAccess realTimeInfo_TeacherDataAccess = new RealtimeInfo_TeacherDataAccess() )
			{
				try
				{
					DataSet dsDutyID = realTimeInfo_TeacherDataAccess.GetDutyID(DateTime.Now.ToString("HH:mm:ss"));
					int teaAttOnTimeNumbersInDuty = 0;
					int teaAttNotOnTimeNumbersInDuty = 0;
					int teaAttNumbersInDuty = 0;

					if ( dsDutyID.Tables[0] != null && dsDutyID.Tables[0].Rows.Count > 0 )
					{
						foreach ( DataRow dutyRow in dsDutyID.Tables[0].Rows )
						{
							teaAttNumbersInDuty += realTimeInfo_TeacherDataAccess.GetTeaNumbers(DateTime.Now.DayOfWeek.ToString(),dutyRow[0].ToString(),getDept);
							realTimeInfo_TeacherDataAccess.GetTeaWorkingNumbers(dutyRow[0].ToString(),ref teaAttOnTimeNumbersInDuty,ref teaAttNotOnTimeNumbersInDuty,getDept,DateTime.Now.Date);
						}
					}

					int noDutyTotal = 0;
					int noDutyAttend = 0;	
					int noDutyLeave = 0;

					realTimeInfo_TeacherDataAccess.GetTeacherRealTimeInfoWithNoDuty(getDept,DateTime.Now.DayOfWeek.ToString(), ref noDutyTotal, ref noDutyAttend,ref noDutyLeave);

					teaAttNumbersInDuty += noDutyTotal;
					teaAttOnTimeNumbersInDuty += noDutyAttend;
					
					double onTimePer = (double)teaAttOnTimeNumbersInDuty/(double)teaAttNumbersInDuty;
					double notOnTimePer = (double)teaAttNotOnTimeNumbersInDuty/(double)teaAttNumbersInDuty;
					double absPer = 1-(((double)teaAttOnTimeNumbersInDuty+(double)teaAttNotOnTimeNumbersInDuty)/(double)teaAttNumbersInDuty);

					zedGraph_RealtimeMorningInfoStatTeacher = new ZedGraphControl();
					pControl.Controls.Clear();
					pControl.Controls.Add(zedGraph_RealtimeMorningInfoStatTeacher);
					zedGraph_RealtimeMorningInfoStatTeacher.Dock = DockStyle.Fill;

					GraphPane myPane = zedGraph_RealtimeMorningInfoStatTeacher.GraphPane;

					if ( getDept.Equals("") )
						myPane.Title = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
							+ "全体教职工上班情况实时统计图\n"+"统计日期: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
					else
						myPane.Title = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
							+ getDept+ "部教师上班情况实时统计图\n"+"统计日期: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

					double[] statusVal = { onTimePer, notOnTimePer,absPer };
					string[] statusLabel = { "准时", "迟到" , "缺席" };

					myPane.PaneFill = new Fill( Color.Cornsilk );
					myPane.AxisFill = new Fill( Color.Cornsilk );
					myPane.Legend.Position = LegendPos.Right ;
					myPane.Legend.FontSpec.Size = 12;

					PieItem [] slices = new PieItem[statusVal.Length] ;
					slices = myPane.AddPieSlices ( statusVal, statusLabel );
					
					((PieItem)slices[0]).LabelType = PieLabelType.Percent ;
					((PieItem)slices[0]).LabelDetail.FontSpec.Size = 14;
					((PieItem)slices[1]).LabelType = PieLabelType.Percent ;
					((PieItem)slices[1]).LabelDetail.FontSpec.Size = 14;
					((PieItem)slices[2]).LabelType = PieLabelType.Percent ;
					((PieItem)slices[2]).LabelDetail.FontSpec.Size = 14;
					((PieItem)slices[2]).Displacement = .1 ;

					BoxItem box = new BoxItem( new RectangleF( 0F, 0F, 1F, 1F ),
						Color.Empty, Color.PeachPuff );
					box.Location.CoordinateFrame = CoordType.AxisFraction;
					box.Border.IsVisible = false;
					box.Location.AlignH = AlignH.Left;
					box.Location.AlignV = AlignV.Top;
					box.ZOrder = ZOrder.E_BehindAxis;

					myPane.GraphItemList.Add( box );

					zedGraph_RealtimeMorningInfoStatTeacher.IsShowContextMenu = false;
					zedGraph_RealtimeMorningInfoStatTeacher.IsEnableZoom = false;
					zedGraph_RealtimeMorningInfoStatTeacher.AxisChange();

					return myPane.Image;
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public Bitmap RealtimeBackInfoStat_TeacherGraphPrint(string getDept,PanelControl pControl)
		{
			using ( RealtimeInfo_TeacherDataAccess realTimeInfo_TeacherDataAccess = new RealtimeInfo_TeacherDataAccess() )
			{
				try
				{
					DataSet dsDutyID = realTimeInfo_TeacherDataAccess.GetDutyID(DateTime.Now.ToString("HH:mm:ss"));
					int teaAttOnTimeNumbersInDuty = 0;
					int teaAttNotOnTimeNumbersInDuty = 0;
					int teaLeaveOnTimeNumbersInDuty = 0;
					int teaLeaveNotOnTimeNumbersInDuty = 0;
					int teaShouldLeaveInDuty = 0;

					if ( dsDutyID.Tables[0].Rows.Count > 0 )
					{
						foreach ( DataRow dutyRow in dsDutyID.Tables[0].Rows )
						{
							//teaAttNumbersInDuty += realTimeInfo_TeacherDataAccess.GetTeaNumbers(DateTime.Now.DayOfWeek.ToString(),dutyRow[0].ToString(),getDept);
							realTimeInfo_TeacherDataAccess.GetTeaWorkingNumbers(dutyRow[0].ToString(),ref teaAttOnTimeNumbersInDuty,ref teaAttNotOnTimeNumbersInDuty,getDept,DateTime.Now.Date);
							realTimeInfo_TeacherDataAccess.GetTeaLeaveNumbers(dutyRow[0].ToString(),ref teaLeaveOnTimeNumbersInDuty,ref teaLeaveNotOnTimeNumbersInDuty,getDept,DateTime.Now.Date);
						}
					}

					int noDutyTotal = 0;
					int noDutyAttend = 0;
					int noDutyLeave = 0;

					realTimeInfo_TeacherDataAccess.GetTeacherRealTimeInfoWithNoDuty(getDept,DateTime.Now.DayOfWeek.ToString(), ref noDutyTotal, ref noDutyAttend,ref noDutyLeave);

					teaLeaveOnTimeNumbersInDuty += noDutyLeave;
					teaShouldLeaveInDuty = teaAttOnTimeNumbersInDuty + teaAttNotOnTimeNumbersInDuty + noDutyAttend;

					
					double onTimePer = (double)teaLeaveOnTimeNumbersInDuty/(double)teaShouldLeaveInDuty;
					double notOnTimePer = (double)teaLeaveNotOnTimeNumbersInDuty/(double)teaShouldLeaveInDuty;
					double remainPer = 1-(((double)teaLeaveOnTimeNumbersInDuty+(double)teaLeaveNotOnTimeNumbersInDuty)/(double)teaShouldLeaveInDuty);

					zedGraph_RealtimeMorningInfoStatTeacher = new ZedGraphControl();
					pControl.Controls.Clear();
					pControl.Controls.Add(zedGraph_RealtimeMorningInfoStatTeacher);
					zedGraph_RealtimeMorningInfoStatTeacher.Dock = DockStyle.Fill;

					GraphPane myPane = zedGraph_RealtimeMorningInfoStatTeacher.GraphPane;

					if ( getDept.Equals("") )
						myPane.Title = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
							+ "全体教职工下班情况实时统计图\n"+"统计日期: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
					else
						myPane.Title = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
							+ getDept+ "部教师下班情况实时统计图\n"+"统计日期: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

					double[] statusVal = { onTimePer, notOnTimePer,remainPer };
					string[] statusLabel = { "离开", "早退" , "剩余" };

					myPane.PaneFill = new Fill( Color.Cornsilk );
					myPane.AxisFill = new Fill( Color.Cornsilk );
					myPane.Legend.Position = LegendPos.Right ;
					myPane.Legend.FontSpec.Size = 12;

					PieItem [] slices = new PieItem[statusVal.Length] ;
					slices = myPane.AddPieSlices ( statusVal, statusLabel );
					
					((PieItem)slices[0]).LabelType = PieLabelType.Percent ;
					((PieItem)slices[0]).LabelDetail.FontSpec.Size = 14;
					((PieItem)slices[1]).LabelType = PieLabelType.Percent ;
					((PieItem)slices[1]).LabelDetail.FontSpec.Size = 14;
					((PieItem)slices[2]).LabelType = PieLabelType.Percent ;
					((PieItem)slices[2]).LabelDetail.FontSpec.Size = 14;
					((PieItem)slices[1]).Displacement = .1 ;

					BoxItem box = new BoxItem( new RectangleF( 0F, 0F, 1F, 1F ),
						Color.Empty, Color.PeachPuff );
					box.Location.CoordinateFrame = CoordType.AxisFraction;
					box.Border.IsVisible = false;
					box.Location.AlignH = AlignH.Left;
					box.Location.AlignV = AlignV.Top;
					box.ZOrder = ZOrder.E_BehindAxis;

					myPane.GraphItemList.Add( box );

					zedGraph_RealtimeMorningInfoStatTeacher.IsShowContextMenu = false;
					zedGraph_RealtimeMorningInfoStatTeacher.IsEnableZoom = false;
					zedGraph_RealtimeMorningInfoStatTeacher.AxisChange();

					return myPane.Image;
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		private void KillProcess()
		{
			string processName = "Excel";
			System.Diagnostics.Process myproc= new System.Diagnostics.Process();
			//得到所有打开的进程
			try
			{
				foreach (Process thisproc in Process.GetProcessesByName(processName)) 
				{
					if(!thisproc.CloseMainWindow())
					{
						thisproc.Kill();
					}
				}
			}
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
			}
		}
	}
}
