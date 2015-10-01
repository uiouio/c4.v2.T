using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CPTT.SystemFramework;
using CPTT.DataAccess;
using ZedGraph;

namespace CPTT.BusinessRule
{
    using Excel = Microsoft.Office.Interop.Excel;
	/// <summary>
	/// RealtimeInfoPrintRules ��ժҪ˵����
	/// </summary>
	public class RealtimeInfoPrintRules
	{
		private Excel.Application m_objExcel = null;
		private Excel.Workbooks m_objBooks = null;
		private Excel._Workbook m_objBook = null;
		private Excel.Sheets m_objSheets = null;
		private Excel._Worksheet m_objSheet = null;
		private Excel.Range m_objRange = null;
		private object m_objOpt = System.Reflection.Missing.Value;
		private string excelPath = AppDomain.CurrentDomain.BaseDirectory;
		private ZedGraphControl zedGraph_RealTimeInfoStatStudent;

		public RealtimeInfoPrintRules()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		
		public void RealtimeMorningPrint(DataSet dsRealtimeMorning,string savePath)
		{
			KillProcess();
			try
			{
				m_objExcel = new Excel.Application();
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\RealtimeMorningInfo.xls",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt);
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;

				//��ȡ��һ����ӡҳ
				m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
				for ( int row = 0; row < dsRealtimeMorning.Tables[0].Rows.Count; row ++ )
				{
					m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+7,1],m_objSheet.Cells[row+7,1]);
					m_objRange.Value = dsRealtimeMorning.Tables[0].Rows[row][1].ToString();
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
					m_objRange.Font.Size = 10;
					for ( int column = 3;column < dsRealtimeMorning.Tables[0].Columns.Count; column ++)
					{
						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+7,column-1],m_objSheet.Cells[row+7,column-1]);
						m_objRange.set_Item(1,1,dsRealtimeMorning.Tables[0].Rows[row][column].ToString());
						m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
						m_objRange.Font.Size = 10;
					}

					if ( row == dsRealtimeMorning.Tables[0].Rows.Count - 1 )
					{
						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+9,1],m_objSheet.Cells[row+9,1]);
						m_objRange.Value = "԰����Ϣ��";
						m_objRange.Font.Bold = true;
						m_objRange.Font.Size = 12;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+9,2],m_objSheet.Cells[row+9,2]);
						m_objRange.Value = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();
						m_objRange.Font.Size = 12;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+10,1],m_objSheet.Cells[row+10,1]);
						m_objRange.Value = "ͳ�����ڣ�";
						m_objRange.Font.Bold = true;
						m_objRange.Font.Size = 12;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+10,2],m_objSheet.Cells[row+10,2]);
						m_objRange.Value = DateTime.Now.ToString("yyyy-MM-dd");
						m_objRange.Font.Size = 12;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

					}
				}

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

		public void RealtimeBackPrint(DataSet dsRealtimeBack,string savePath)
		{
			KillProcess();
			try
			{
				m_objExcel = new Excel.Application();
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\RealtimeBackInfo.xls",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt);
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;

				//��ȡ��һ����ӡҳ
				m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
				for ( int row = 0; row < dsRealtimeBack.Tables[0].Rows.Count; row ++ )
				{
					m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+7,2],m_objSheet.Cells[row+7,2]);
					m_objRange.Value = dsRealtimeBack.Tables[0].Rows[row][1].ToString();
					m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					for ( int column = 3;column < dsRealtimeBack.Tables[0].Columns.Count; column ++)
					{
						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+7,column],m_objSheet.Cells[row+7,column]);
						m_objRange.set_Item(1,1,dsRealtimeBack.Tables[0].Rows[row][column].ToString());
						m_objRange.Font.Size = 13;
						m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
					}

					if ( row == dsRealtimeBack.Tables[0].Rows.Count - 1 )
					{
						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+9,2],m_objSheet.Cells[row+9,2]);
						m_objRange.Value = "԰����Ϣ��";
						m_objRange.Font.Bold = true;
						m_objRange.Font.Size = 12;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+9,3],m_objSheet.Cells[row+9,3]);
						m_objRange.Value = new GradesDataAccess().GetGradeInfoList(0).Tables[0].Rows[0][0].ToString();
						m_objRange.Font.Size = 12;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+10,2],m_objSheet.Cells[row+10,2]);
						m_objRange.Value = "ͳ�����ڣ�";
						m_objRange.Font.Bold = true;
						m_objRange.Font.Size = 12;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[row+10,3],m_objSheet.Cells[row+10,3]);
						m_objRange.Value = DateTime.Now.ToString("yyyy-MM-dd");
						m_objRange.Font.Size = 12;
						m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
						m_objRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

					}
				}

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

		public Bitmap Pie_MorningInfoStat(string getGrade,string getClass,DateTime getDate,PanelControl pControl)
		{
			using ( RealtimeInfoDataAccess realTimeInfoDataAccess = new RealtimeInfoDataAccess() )
			{
				try
				{
					int getHealth = 0;
					int getWatch = 0;
					int getSick = 0;
					int getAbsence = 0;
					int getStuNumbers = 0;
					
					realTimeInfoDataAccess.GetRealtimeMorningInfo_Graphic(getGrade,getClass,getDate,ref getHealth,ref getWatch,
						ref getSick,ref getAbsence,ref getStuNumbers);
					
					double healthPer = (double)getHealth/(double)getStuNumbers;
					double watchPer = (double)getWatch/(double)getStuNumbers;
					double illPer = (double)getSick/(double)getStuNumbers;
					double absPer = (double)getAbsence/(double)getStuNumbers;

					zedGraph_RealTimeInfoStatStudent = new ZedGraphControl();
					pControl.Controls.Clear();
					pControl.Controls.Add(zedGraph_RealTimeInfoStatStudent);
					zedGraph_RealTimeInfoStatStudent.Dock = DockStyle.Fill;

					GraphPane myPane = zedGraph_RealTimeInfoStatStudent.GraphPane;

					if ( getGrade.Equals("") )
						myPane.Title = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
							+ "ȫ�꼶������Ϣͳ��ͼ\n"+"ͳ������: " + getDate.ToString("yyyy-MM-dd");

					else if ( getClass.Equals("") )
						myPane.Title = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
							+ new StuInfoDataAccess().GetGradeList("",getGrade).Tables[0].Rows[0][1].ToString()
							+ "������Ϣͳ��ͼ\n"+"ͳ������: " + getDate.ToString("yyyy-MM-dd");
					else
						myPane.Title = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
							+ new RealtimeInfoDataAccess().setClassList("",getClass,getGrade).Tables[0].Rows[0][1].ToString()
							+ "������Ϣͳ��ͼ\n"+"ͳ������: " + getDate.ToString("yyyy-MM-dd");

					double[] statusVal = { healthPer, watchPer,absPer,illPer };
					string[] statusLabel = { "����", "�۲�" , "ȱϯ" , "��ҩ"};

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
					((PieItem)slices[3]).LabelType = PieLabelType.Percent ;
					((PieItem)slices[3]).LabelDetail.FontSpec.Size = 14;
					((PieItem)slices[1]).Displacement = .1 ;
					((PieItem)slices[3]).Displacement = .1;

					BoxItem box = new BoxItem( new RectangleF( 0F, 0F, 1F, 1F ),
						Color.Empty, Color.PeachPuff );
					box.Location.CoordinateFrame = CoordType.AxisFraction;
					box.Border.IsVisible = false;
					box.Location.AlignH = AlignH.Left;
					box.Location.AlignV = AlignV.Top;
					box.ZOrder = ZOrder.E_BehindAxis;

					myPane.GraphItemList.Add( box );

					zedGraph_RealTimeInfoStatStudent.IsShowContextMenu = false;
					zedGraph_RealTimeInfoStatStudent.IsEnableZoom = false;
					zedGraph_RealTimeInfoStatStudent.AxisChange();

					return myPane.Image;
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public Bitmap Pie_BackInfoStat(string getGrade,string getClass,DateTime getDate,PanelControl pControl)
		{
			using ( RealtimeInfoDataAccess realTimeInfoDataAccess = new RealtimeInfoDataAccess() )
			{
				try
				{
					int getHasGone = 0;
					int getHasnotGone = 0;
					int getStuNumbers = 0;
					
					realTimeInfoDataAccess.GetRealtimeBackInfo_Graphic(getGrade,getClass,getDate,ref getHasGone,ref getHasnotGone,ref getStuNumbers);

					double hasGonePer = (double)getHasGone/(double)getStuNumbers;
					double hasnotGonePer = (double)getHasnotGone/(double)getStuNumbers;

					zedGraph_RealTimeInfoStatStudent = new ZedGraphControl();
					pControl.Controls.Clear();
					pControl.Controls.Add(zedGraph_RealTimeInfoStatStudent);
					zedGraph_RealTimeInfoStatStudent.Dock = DockStyle.Fill;

					GraphPane myPane = zedGraph_RealTimeInfoStatStudent.GraphPane;

					if ( getGrade.Equals("") )
						myPane.Title = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
							+ "ȫ�꼶�����Ϣͳ��ͼ\n"+"ͳ������: " + getDate.ToString("yyyy-MM-dd");

					else if ( getClass.Equals("") )
						myPane.Title = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
							+ new StuInfoDataAccess().GetGradeList("",getGrade).Tables[0].Rows[0][1].ToString()
							+ "�����Ϣͳ��ͼ\n"+"ͳ������: " + getDate.ToString("yyyy-MM-dd");
					else
						myPane.Title = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString()
							+ new RealtimeInfoDataAccess().setClassList("",getClass,getGrade).Tables[0].Rows[0][1].ToString()
							+ "�����Ϣͳ��ͼ\n"+"ͳ������: " + getDate.ToString("yyyy-MM-dd");

					double[] statusVal = { hasGonePer, hasnotGonePer };
					string[] statusLabel = { "�ѽ���", "δ����"};

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
					((PieItem)slices[1]).Displacement = .1 ;

					BoxItem box = new BoxItem( new RectangleF( 0F, 0F, 1F, 1F ),
						Color.Empty, Color.PeachPuff );
					box.Location.CoordinateFrame = CoordType.AxisFraction;
					box.Border.IsVisible = false;
					box.Location.AlignH = AlignH.Left;
					box.Location.AlignV = AlignV.Top;
					box.ZOrder = ZOrder.E_BehindAxis;

					myPane.GraphItemList.Add( box );

					zedGraph_RealTimeInfoStatStudent.IsShowContextMenu = false;
					zedGraph_RealTimeInfoStatStudent.IsEnableZoom = false;
					zedGraph_RealTimeInfoStatStudent.AxisChange();

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
			//�õ����д򿪵Ľ���
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
