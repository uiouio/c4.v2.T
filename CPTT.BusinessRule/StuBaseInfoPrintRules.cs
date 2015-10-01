using System;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using CPTT.SystemFramework;
using CPTT.DataAccess;
using System.Reflection;

namespace CPTT.BusinessRule
{
    using Excel = Microsoft.Office.Interop.Excel;
	/// <summary>
	/// StuBaseInfoPrintRules ��ժҪ˵����
	/// </summary>
	public class StuBaseInfoPrintRules :IDisposable
	{
		private Excel.Application m_objExcel = null;
		private Excel.Workbooks m_objBooks = null;
		private Excel._Workbook m_objBook = null;
		private Excel.Sheets m_objSheets = null;
		private Excel._Worksheet m_objSheet = null;
		private Excel.Range m_objRange = null;
		private Excel.Font m_objFont = null;
		private Excel.Pictures m_objPictures = null;
		private Excel.Picture m_objPicture = null; 
		private object m_objOpt = System.Reflection.Missing.Value;
		private string path = string.Empty;
		private string destPath = string.Empty;
		private string excelPath = AppDomain.CurrentDomain.BaseDirectory;
		private bool needPrintPicture;
		private DataView dv = null;
		public StuBaseInfoPrintRules()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public void StuBaseInfoPrint(Students students,string savePath)
		{
			try
			{
				//������ӡ����
				m_objExcel = new Excel.Application();
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\StudentBaseInfo.xls",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt);
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;

				//��ȡ��һ����ӡҳ
				m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

				if ( NPrintPicture() )
				{
					m_objPictures = (Excel.Pictures)m_objSheet.Pictures(m_objOpt);
					m_objPictures.Insert(@"c:\temp.jpg",m_objOpt);
					m_objPicture = (Excel.Picture)m_objPictures.Item(1);

					m_objRange = m_objSheet.get_Range("G8","H15");
					m_objPicture.Left = (double)m_objRange.Left;
					m_objPicture.Top = (double)m_objRange.Top;
					m_objPicture.Width = (double)m_objRange.Width;
					m_objPicture.Height = (double)m_objRange.Height;
				}

				//��ӡ԰������
				m_objRange = m_objSheet.get_Range("B4",m_objOpt);
				m_objRange.Value = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();

				//��ӡ����
				m_objRange = m_objSheet.get_Range("G40",m_objOpt);
				m_objRange.Value = DateTime.Now.ToString("yyyy-MM-dd");

				//��ӡѧ��
				m_objRange = m_objSheet.get_Range("B7",m_objOpt);
				m_objRange.Value = students.Number;

				//��ӡ����
				m_objRange = m_objSheet.get_Range("B8",m_objOpt);
				m_objRange.Value = students.Name;

				//��ӡ�Ա�
				m_objRange = m_objSheet.get_Range("D8",m_objOpt);
				m_objRange.Value = students.Gender;

				//��ӡ������
				m_objRange = m_objSheet.get_Range("F8",m_objOpt);
				m_objRange.Value = students.EntryDate;

				//��ӡ��Դ
				m_objRange = m_objSheet.get_Range("B10",m_objOpt);
				m_objRange.Value = students.Origin;

				//��ӡ���з�ʽ
				m_objRange = m_objSheet.get_Range("D10",m_objOpt);
				m_objRange.Value = students.EntryStatus;

				//��ӡ��԰����
				m_objRange = m_objSheet.get_Range("F10",m_objOpt);
				m_objRange.Value = students.EntryDate;

				//��ӡ��԰����
				m_objRange = m_objSheet.get_Range("B12",m_objOpt);
				if ( students.LeaveDate == DateTime.MinValue )
					m_objRange.Value = "";
				else
					m_objRange.Value = students.LeaveDate;

				//��ӡ����
				m_objRange = m_objSheet.get_Range("B18",m_objOpt);
				m_objRange.Value = students.Nationality;

				//��ӡ�ʱ�
				m_objRange = m_objSheet.get_Range("D18",m_objOpt);
				m_objRange.Value = students.ZipCode;

				//��ӡ�ֵ�
				m_objRange = m_objSheet.get_Range("F18",m_objOpt);
				m_objRange.Value = students.JieDao;

				//��ӡ��ί
				m_objRange = m_objSheet.get_Range("F20",m_objOpt);
				m_objRange.Value = students.LiWei;

				//��ӡ����
				m_objRange = m_objSheet.get_Range("B20",m_objOpt);
				m_objRange.Value = students.Native;

				//��ӡ��ͥסַ
				m_objRange = m_objSheet.get_Range("B22",m_objOpt);
				m_objRange.Value = students.FamilyAddr;

				//��ӡ���ڵ�ַ
				m_objRange = m_objSheet.get_Range("B24",m_objOpt);
				m_objRange.Value = students.HuKouAddr;

				//��ӡ��ʷ��¼
				m_objRange = m_objSheet.get_Range("B26",m_objOpt);
				m_objRange.Value = students.SickHistory;

				//��ӡ��������
				m_objRange = m_objSheet.get_Range("B31",m_objOpt);
				m_objRange.Value = students.FatherName;

				//��ӡ������ϵ�绰
				m_objRange = m_objSheet.get_Range("F31",m_objOpt);
				m_objRange.Value = students.FatherPhone;

				//��ӡ���׹�����ַ
				m_objRange = m_objSheet.get_Range("B33",m_objOpt);
				m_objRange.Value = students.FatherWorkPlace;

				//��ӡĸ������
				m_objRange = m_objSheet.get_Range("B35",m_objOpt);
				m_objRange.Value = students.MotherName;

				//��ӡĸ����ϵ�绰
				m_objRange = m_objSheet.get_Range("F35",m_objOpt);
				m_objRange.Value = students.MotherPhone;

				//��ӡĸ�׹�����ַ
				m_objRange = m_objSheet.get_Range("B37",m_objOpt);
				m_objRange.Value = students.MotherWorkPlace;

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

		public void AllStuInfoPrint(DataSet dsExportData,string savePath)
		{
			try
			{
				m_objExcel = new Excel.Application();
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\AllStuInfo.xls",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt);
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;

				dv = dsExportData.Tables[0].DefaultView;
	
				for (int row = 1; row < dsExportData.Tables[1].Rows.Count; row++)
				{
					m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
					
					m_objSheet.Copy(m_objOpt,m_objSheet);	
				}

				for (int row = 1; row <= dsExportData.Tables[1].Rows.Count; row++)
				{
					m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(row);
					m_objSheet.Name = Convert.ToString(dsExportData.Tables[1].Rows[row-1][0]);
					BindingData(m_objSheet.Name);
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

		private void BindingData(string className)
		{
			dv.RowFilter = @"info_className = '" + className + "'";

			object[,] objData = new object[dv.Count,9];
			ArrayList alMergeYPoint = new ArrayList();

			int pointer = -1;

			for (int i = 0; i < dv.Count; i++)
			{
				int compareTimes = 0;

				objData[i,0] = dv[i][0];
				objData[i,1] = dv[i][1];
				objData[i,2] = dv[i][3];
				objData[i,3] = dv[i][4];
				objData[i,4] = dv[i][5];
				objData[i,5] = dv[i][6];
				objData[i,6] = dv[i][7];
				objData[i,7] = dv[i][8];
				objData[i,8] = dv[i][9];

				if (i > pointer)
				{
					//innerPoint��EXCEL����ָ��
					for (int innerPointer = 1; innerPointer < dv.Count-i; innerPointer++)
					{
						if (Convert.ToInt32(objData[i,1]) == Convert.ToInt32(dv[i+innerPointer][1]))
						{
							compareTimes++;
							continue;
						}
						else 
						{
							if (compareTimes != 0)
							{
								object[,] objRange = new object[1,2];

								pointer = i + innerPointer - 1;
								objRange[0,0] = i;
								objRange[0,1] = pointer;
								alMergeYPoint.Add(objRange);
							}

							break;
						}	
					}
				}
			}

			m_objRange = m_objSheet.get_Range("A4",m_objOpt);
			m_objRange = m_objRange.get_Resize(dv.Count,9);

			MergeData(alMergeYPoint);

			m_objRange.Value = objData;

			m_objRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			m_objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			m_objRange.WrapText = true;
			m_objRange.Borders.LineStyle = BorderStyle.FixedSingle;
			m_objRange.Font.Size = 10;
			m_objFont = m_objRange.Font;
		}

		private void MergeData(ArrayList alMergeYPoint)
		{
			string[] columns = new string[]{"A","B","C","D","E","F","G","H"};

			for (int index = 0;index < alMergeYPoint.Count; index++)
			{
				int rangeStartPointer = Convert.ToInt32(((object[,])(alMergeYPoint[index]))[0,0]) + 1;
				int rangeEndPointer = Convert.ToInt32(((object[,])(alMergeYPoint[index]))[0,1]) + 1;

				foreach (string column in columns)
				{
					string startAddress = column + Convert.ToString(rangeStartPointer);
					string endAddress = column + Convert.ToString(rangeEndPointer);
					
					m_objRange.get_Range(startAddress,endAddress).Merge(m_objOpt);

				}
			}
		}

		public void SetNPrintPicture(bool needPrintPicture)
		{
			this.needPrintPicture = needPrintPicture;
		}

		private bool NPrintPicture()
		{
			return needPrintPicture;
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

		public void Dispose()
		{
			GC.SuppressFinalize(true);
		}
	}
}
