using System;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Data;
using CPTT.SystemFramework;
using CPTT.DataAccess;
using System.Reflection;

namespace CPTT.BusinessRule
{
    using Excel = Microsoft.Office.Interop.Excel;
	/// <summary>
	/// TeaBaseInfoPrintRules ��ժҪ˵����
	/// </summary>
	public class TeaBaseInfoPrintRules
	{
		private Excel.Application m_objExcel = null;
		private Excel.Workbooks m_objBooks = null;
		private Excel._Workbook m_objBook = null;
		private Excel.Sheets m_objSheets = null;
		private Excel._Worksheet m_objSheet = null;
		private Excel.Range m_objRange = null;
		private Excel.Pictures m_objPictures = null;
		private Excel.Picture m_objPicture = null; 
		private object m_objOpt = System.Reflection.Missing.Value;
		private string excelPath = AppDomain.CurrentDomain.BaseDirectory;
		
		private bool needPrintPicture;

		public TeaBaseInfoPrintRules()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public void PrintTeaBaseInfo(TeacherBase tBase,string savePath)
		{
			try
			{
				m_objExcel = new Excel.Application(); 
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;				
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\TeacherBaseInfo.xls",
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

					m_objRange = m_objSheet.get_Range("H8","I15");
					m_objPicture.Left = (double)m_objRange.Left;
					m_objPicture.Top = (double)m_objRange.Top;
					m_objPicture.Width = (double)m_objRange.Width;
					m_objPicture.Height = (double)m_objRange.Height;
				}
			
				//԰����
				m_objRange = m_objSheet.get_Range("C6",m_objOpt);
				m_objRange.Value = new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString();

				//��ӡ����
				m_objRange = m_objSheet.get_Range("H32",m_objOpt);
				m_objRange.Value = DateTime.Now.Date.ToString("yyyy.MM.dd");

				//����
				m_objRange = m_objSheet.get_Range("C8",m_objOpt);
				m_objRange.Value = tBase.TName;

				//�Ա�
				m_objRange = m_objSheet.get_Range("E8",m_objOpt);
				m_objRange.Value = tBase.TSex;

				//ѧ��
				m_objRange = m_objSheet.get_Range("G8",m_objOpt);
				m_objRange.Value = tBase.TCareer;

				//��ͥ�绰
				m_objRange = m_objSheet.get_Range("C12",m_objOpt);
				m_objRange.Value = tBase.THomeTel;

				//�ֻ�����
				m_objRange = m_objSheet.get_Range("E12",m_objOpt);
				m_objRange.Value = tBase.TPhone;

				//�칫�绰
				m_objRange = m_objSheet.get_Range("G12",m_objOpt);
				m_objRange.Value = tBase.TWorkTel;

				//���
				m_objRange = m_objSheet.get_Range("C16",m_objOpt);
				m_objRange.Value = tBase.TMerrige;

				//��ͥסַ
				m_objRange = m_objSheet.get_Range("F16",m_objOpt);
				m_objRange.Value = tBase.TAddr;

				//��������
				m_objRange = m_objSheet.get_Range("C20",m_objOpt);
				m_objRange.Value = tBase.TDepart;

				//ְ��
				m_objRange = m_objSheet.get_Range("F20",m_objOpt);
				m_objRange.Value = tBase.TDuty;

				//ְ��
				m_objRange = m_objSheet.get_Range("H20",m_objOpt);
				m_objRange.Value = tBase.TTechnicalPost;

				//��ʦ�ȼ�
				m_objRange = m_objSheet.get_Range("C24",m_objOpt);
				m_objRange.Value = tBase.TLevel;

				//�μӹ���ʱ��
				m_objRange = m_objSheet.get_Range("G24",m_objOpt);
				m_objRange.Value = tBase.TWorkTime.ToString("yyyy-MM-dd");
			
				//��԰ʱ��
				m_objRange = m_objSheet.get_Range("C28",m_objOpt);
				m_objRange.Value = tBase.TEnterTime.ToString("yyyy-MM-dd");

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
