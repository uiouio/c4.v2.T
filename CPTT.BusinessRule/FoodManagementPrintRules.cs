using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using CPTT.DataAccess;
using CPTT.SystemFramework;
namespace CPTT.BusinessRule
{
    using Excel = Microsoft.Office.Interop.Excel;
	/// <summary>
	/// FoodManagementPrintRules ��ժҪ˵����
	/// </summary>
	public class FoodManagementPrintRules
	{
		private DateTime getBegDate;
		private DateTime getEndDate;
		private Excel.Application m_objExcel = null;
		private Excel.Workbooks m_objBooks = null;
		private Excel._Workbook m_objBook = null;
		private Excel.Sheets m_objSheets = null;
		private Excel._Worksheet m_objSheet = null;
		private Excel.Range m_objRange = null;
		private object m_objOpt = System.Reflection.Missing.Value;
		private string excelPath = AppDomain.CurrentDomain.BaseDirectory;

		private int setACCRow;
		private bool hasACCRowChanged = false;
		private int setElementRow;
		private bool hasVegChanged = false;
		private bool hasElRowChanged = false;

		public FoodManagementPrintRules()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public void NutritionPrint(string savePath)
		{
			try
			{
				m_objExcel = new Excel.Application(); 
				m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;				
				m_objBook = (Excel._Workbook)m_objBooks.Open(excelPath+@"report\nutrition.xls",
					m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,
					m_objOpt,m_objOpt,m_objOpt); 
  
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;  	
				int number = m_objSheets.Count;	

				writeCover();
				writeStuAmount(); 
	            writeStuConvert();
		        writeACC1(); 
				writeACC2();
				writeElement();	
	
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
			catch(Exception ex)
			{
				Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
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

		private void writeCover()                     //����
		{
			try
			{
				m_objSheets = (Excel.Sheets)m_objBook.Worksheets;  
				m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));  
				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[17,6],m_objSheet.Cells[17,6]);
				m_objRange.set_Item(1,1,new GardenInfoDataAccess().GetGardenInfo().Tables[0].Rows[0][1].ToString());
				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[18,6],m_objSheet.Cells[18,6]);
				m_objRange.set_Item(1,1,BegDate.Date.ToString("yyyy��MM��"));
				
			}
			catch (Exception ex)
			{
				Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
			}
		}


		private void writeStuAmount()                 //����
		{
			try
			{
				int endTime = Convert.ToInt32(EndDate.Date.ToString("dd"));
				int begTime;
				int rangeRow = 6;
				m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(2));  
				foreach(DataRow row in new GradesDataAccess().GetGradeInfoList(0).Tables[0].Rows)
				{
					int countTotal = 0;
					if(Convert.ToInt32(row[0])>0)
					{

						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rangeRow,1],m_objSheet.Cells[rangeRow,1]);
						m_objRange.set_Item(1,1,row[1].ToString());
						for( begTime = Convert.ToInt32(BegDate.Date.ToString("dd")); begTime <= endTime; begTime++ )
						{
							try
							{
								using ( FoodManagementDataAccess foodManagementDataAccess = new FoodManagementDataAccess() )
								{
									int getAmount = foodManagementDataAccess.GetStuAmountForNut(BegDate,EndDate,Convert.ToInt32(BegDate.Date.ToString("MM")),
										begTime,Convert.ToInt32(row[0]));
									m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rangeRow,1],m_objSheet.Cells[rangeRow,1]);
									m_objRange.set_Item(1,begTime+1,getAmount.ToString());
									countTotal += Convert.ToInt32(getAmount);
								}
							}
							catch(Exception e)
							{
								Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
							}
						}
						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[rangeRow,17],m_objSheet.Cells[rangeRow,17]);
						m_objRange.set_Item(1,17,countTotal.ToString());
						rangeRow++;
					}
				}
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
			}	
		}


		private void writeStuConvert()             //�ۺ�������
		{
			try
			{
				string getTotal = string.Empty;
				m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(3));
				foreach(DataRow row in new GradesDataAccess().GetGradeInfoList(0).Tables[0].Rows)
				{
					if(Convert.ToInt32(row[0])>0)
					{
						if(row[1].ToString().Equals("�а�"))
						{
							m_objRange = m_objSheet.get_Range(m_objSheet.Cells[3,8],m_objSheet.Cells[3,8]);
							m_objRange.set_Item(1,7,row[1].ToString());
							m_objRange = m_objSheet.get_Range(m_objSheet.Cells[4,8],m_objSheet.Cells[4,8]);
							m_objRange.set_Item(1,7,"2����(������)");
						}
						if(row[1].ToString().Equals("С��"))
						{
							m_objRange = m_objSheet.get_Range(m_objSheet.Cells[3,2],m_objSheet.Cells[3,2]);
							m_objRange.set_Item(1,1,row[1].ToString());
							m_objRange = m_objSheet.get_Range(m_objSheet.Cells[4,2],m_objSheet.Cells[4,2]);
							m_objRange.set_Item(1,1,"3����");
						}
						if(row[1].ToString().Equals("�а�"))
						{
							m_objRange = m_objSheet.get_Range(m_objSheet.Cells[3,4],m_objSheet.Cells[3,4]);
							m_objRange.set_Item(1,3,row[1].ToString());
							m_objRange = m_objSheet.get_Range(m_objSheet.Cells[4,4],m_objSheet.Cells[4,4]);
							m_objRange.set_Item(1,3,"4����");
						}
						if(row[1].ToString().Equals("���"))
						{
							m_objRange = m_objSheet.get_Range(m_objSheet.Cells[3,6],m_objSheet.Cells[3,6]);
							m_objRange.set_Item(1,5,row[1].ToString());
							m_objRange = m_objSheet.get_Range(m_objSheet.Cells[4,6],m_objSheet.Cells[4,6]);
							m_objRange.set_Item(1,5,"5����(������)");
						}
						if(row[1].ToString().Equals("��ɫ��"))
						{
							m_objRange = m_objSheet.get_Range(m_objSheet.Cells[3,10],m_objSheet.Cells[3,10]);
							m_objRange.set_Item(1,9,row[1].ToString());
							m_objRange = m_objSheet.get_Range(m_objSheet.Cells[4,10],m_objSheet.Cells[4,10]);
							m_objRange.set_Item(1,9,"3������");
						}
					}
				}

				foreach(DataRow row in new FoodManagementDataAccess().GetMealForGrade().Tables[0].Rows)
				{
					string getSuitGrade = row[3].ToString();
					int count = 0;
					for ( int k=0; k<getSuitGrade.Length; k++ )
						if(getSuitGrade.Substring(k,1).Equals(","))
							count ++;
					string delimStr = ",";
					char [] delimiter = delimStr.ToCharArray();
					string[] spilt = null;
					int j = 0;
					for ( int i=1; i<=count+1; i++ )   //ȷ��ָ����ʶ�и������
					{
						spilt = getSuitGrade.Split(delimiter,i+1);   
						if ( Convert.ToInt32(row[5]) == 1 )
						{
							string s = spilt[j];
							compareClass(spilt[j],5);
						}
						if ( Convert.ToInt32(row[6]) == 1 )
						{
							string s = spilt[j];
							compareClass(spilt[j],6);
						}
						if ( Convert.ToInt32(row[7]) == 1 )
						{
							string s = spilt[j];
							compareClass(spilt[j],7);
						}
						if ( Convert.ToInt32(row[8]) == 1 )
						{
							string s = spilt[j];
							compareClass(spilt[j],8);
						}
						j += 1;					 //��ȡ��Ҫ���ַ���
					}  
				}
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
			}
		}


		private void writeACC1()  //��ʳ��Ӫ����ȡ��1
		{
			m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(5));
			for(int cateID=1;cateID<=10;cateID++)
			{
				DataSet dsGetFoodAmount = new FoodManagementDataAccess().GetAcc1(BegDate.Date.ToString("yyyy-MM-dd"),EndDate.Date.ToString("yyyy-MM-dd"),
					Convert.ToInt32(BegDate.Date.ToString("MM")),cateID);
				switch(cateID)
				{
					case 1: setACCRow = 9;       //����
						hasACCRowChanged = false;
						foreach ( DataRow row in dsGetFoodAmount.Tables[0].Rows )
						{
							if ( setACCRow > 51 && !hasACCRowChanged )
							{
								hasACCRowChanged = true;
								setACCRow = 63;
							}
							if ( setACCRow > 88 )
								break;
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,1,true);
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,2,false);
							setACCRow ++;
						}
						break;	

					case 2: setACCRow = 63;      //ˮ��
						hasACCRowChanged = false;
						foreach ( DataRow row in dsGetFoodAmount.Tables[0].Rows )
						{
							if ( setACCRow > 87 )
								break;
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,4,true);
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,5,false);
							setACCRow ++;
						}
						break;

					case 3: setACCRow = 9;       //�߲�
						hasACCRowChanged = false;
						foreach ( DataRow row in dsGetFoodAmount.Tables[0].Rows )
						{
							if ( setACCRow > 36 && !hasACCRowChanged )
							{
								hasACCRowChanged = true;
								setACCRow = 116;
							}
							if ( setACCRow > 159 )
								break;
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,4,true);
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,5,false);
							setACCRow ++;
						}
						break;

					case 4: setACCRow = 89;    //��ʳ
						hasACCRowChanged = false;
						foreach ( DataRow row in dsGetFoodAmount.Tables[0].Rows )
						{
							if ( setACCRow > 106 )
								break;
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,1,true);
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,2,false);
							setACCRow ++;
						}
						break;

					case 5: setACCRow = 37;    //��ζƷ
						hasACCRowChanged = false;
						foreach ( DataRow row in dsGetFoodAmount.Tables[0].Rows )
						{
							if ( setACCRow > 53 )
								break;
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,4,true);
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,5,false);
							setACCRow ++;
						}
						break;

					case 6: setACCRow = 88;    //���
						hasACCRowChanged = false;
						foreach ( DataRow row in dsGetFoodAmount.Tables[0].Rows )
						{
							if ( setACCRow > 105)
								break;
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,4,true);
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,5,false);
							setACCRow ++;
						}
						break;

					case 7: setACCRow = 116;     //����Ʒ
						hasACCRowChanged = false;
						foreach ( DataRow row in dsGetFoodAmount.Tables[0].Rows )
						{
							if ( setACCRow > 148 )
								break;
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,1,true);
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,2,false);
							setACCRow ++;
				
						}
						break;

					case 8: hasACCRowChanged = false;  //����
						foreach ( DataRow row in dsGetFoodAmount.Tables[0].Rows )
						{
							if ( setACCRow > 148 )
								break;
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,1,true);
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,2,false);
							setACCRow ++;
						}
						break;

					case 9: setACCRow = 149;    //������
						hasACCRowChanged = false;
						foreach ( DataRow row in dsGetFoodAmount.Tables[0].Rows )
						{
							if ( setACCRow > 159 )
								break;
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,1,true);
							setACC1(new FoodManagementDataAccess().GetAcc1FoodName(Convert.ToInt32(row[0])),Convert.ToDouble(row[1]),setACCRow,2,false);
							setACCRow ++;
						}
						break;

				}
			}
		}


		private void writeACC2()     //��ʳ��Ӫ����ȡ��2
		{
			m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(6));
			int setRow = 6;
			int setColumn = 1;
			int endTime = Convert.ToInt32(EndDate.Date.ToString("dd"));
			int begTime;

			DataSet dsGetConsumption = new FoodManagementDataAccess().GetAcc2(BegDate.Date.ToString("yyyy-MM-dd"),EndDate.Date.ToString("yyyy-MM-dd"),
				Convert.ToInt32(BegDate.Date.ToString("MM")));
			DataSet dsGetEachDayConsum = null;

			foreach(DataRow row in dsGetConsumption.Tables[0].Rows)
			{
				setColumn = 1;
				double countTotal = 0;
				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[setRow,setColumn],m_objSheet.Cells[setRow,setColumn]);
				m_objRange.set_Item(1,1,row[2].ToString());
				for ( begTime=Convert.ToInt32(BegDate.Date.ToString("dd")); begTime<=endTime; begTime++ )
				{
					dsGetEachDayConsum = new FoodManagementDataAccess().GetAcc2EachDay(BegDate.Date.ToString("yyyy-MM-dd"),EndDate.Date.ToString("yyyy-MM-dd"),
						Convert.ToInt32(BegDate.Date.ToString("MM")),begTime,Convert.ToInt32(row[0]));
					if ( dsGetEachDayConsum.Tables[0].Rows.Count > 0 )
					{
						setColumn ++;
						m_objRange = m_objSheet.get_Range(m_objSheet.Cells[setRow,setColumn],m_objSheet.Cells[setRow,setColumn]);
						m_objRange.set_Item(1,1,dsGetEachDayConsum.Tables[0].Rows[0][0].ToString());	
						countTotal += Convert.ToDouble(dsGetEachDayConsum.Tables[0].Rows[0][0]);
					}
					else
						setColumn++;
				}
				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[setRow,33],m_objSheet.Cells[setRow,33]);
				m_objRange.set_Item(1,1,countTotal);	
				setRow ++;
			}
		}


		private void writeElement()    //�ɷ�
		{
			m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(7));
			for ( int cateID=1; cateID<=9; cateID++ )
			{
				DataSet dsFoodNutPar = new FoodManagementDataAccess().GetFoodNut(BegDate.Date.ToString("yyyy-MM-dd"),EndDate.Date.ToString("yyyy-MM-dd"),
					Convert.ToInt32(BegDate.Date.ToString("MM")),cateID);
				if ( dsFoodNutPar.Tables[0].Rows.Count > 0 )
				{
					switch(cateID)
					{
						case 1: setElementRow = 6;       //����
							hasElRowChanged = false;
							foreach(DataRow row in dsFoodNutPar.Tables[0].Rows)
							{
								if ( setElementRow > 83 )
									break;
								if( setElementRow > 67 && !hasElRowChanged )
								{
									hasElRowChanged = true;
									setElementRow = 77;
								}
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,4);
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,6);
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,8);
								setElementRow ++;
							}
							break;	

						case 2: setElementRow = 199;      //ˮ��
							hasElRowChanged = false;
							foreach(DataRow row in dsFoodNutPar.Tables[0].Rows)
							{
								if ( setElementRow > 231 )
									break;
								if ( setElementRow > 208 && !hasElRowChanged )
								{
									hasElRowChanged = true;
									setElementRow = 217;
								}
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,4);
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,6);
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,8);
								setElementRow ++;
							}
							break;

						case 3: setElementRow = 170;       //�߲�
							hasElRowChanged = false;
							foreach(DataRow row in dsFoodNutPar.Tables[0].Rows)    //
							{
								if ( setElementRow >= 170 && hasVegChanged )     //����Ҫ�����ĵ�Ԫ��
									break;
								if ( setElementRow > 197 )
								{
									setElementRow = 119;
									hasVegChanged = true;
								}
								if ( setElementRow > 138 && !hasElRowChanged && hasVegChanged )
								{
									hasElRowChanged = true;
									setElementRow = 147;
								}
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,4);
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,6);
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,8);
								setElementRow ++;
							}
							break;

						case 4: setElementRow = 233;    //��ʳ
							hasElRowChanged = false;
							foreach(DataRow row in dsFoodNutPar.Tables[0].Rows)
							{
								if ( setElementRow > 250 )
									break;
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,4);
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,6);
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,8);
								setElementRow ++;
							}
							break;

						case 5: setElementRow = 291;    //��ζƷ
							hasElRowChanged = false;
							foreach(DataRow row in dsFoodNutPar.Tables[0].Rows)
							{
								if ( setElementRow > 307 )
									break;
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,4);
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,6);
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,8);
								setElementRow ++;
							}
							break;

						case 6: setElementRow = 264;    //���
							hasElRowChanged = false;
							foreach(DataRow row in dsFoodNutPar.Tables[0].Rows)
							{
								if ( setElementRow > 289 )
									break;
								if ( setElementRow > 278 && !hasElRowChanged )
								{
									hasElRowChanged = true;
									setElementRow = 287;
								}
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,4);
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,6);
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,8);
								setElementRow ++;
							}
							break;

						case 7: setElementRow = 85;     //����Ʒ
							foreach(DataRow row in dsFoodNutPar.Tables[0].Rows)
							{
								if ( setElementRow > 117 )
									break;
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,4);
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,6);
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,8);
								setElementRow ++;
							}
							break;

						case 8: foreach(DataRow row in dsFoodNutPar.Tables[0].Rows)
								{
									if ( setElementRow > 117 )
										break;
									setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,4);
									setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,6);
									setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,8);
									setElementRow ++;
								}
							break;

						case 9: setElementRow = 252;    //������
							foreach(DataRow row in dsFoodNutPar.Tables[0].Rows)
							{
								if ( setElementRow > 262 )
									break;
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,4);
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,6);
								setElement(Convert.ToDouble(row[1]),Convert.ToDouble(row[2]),Convert.ToDouble(row[3]),setElementRow,8);
								setElementRow ++;
							}
							break;
					}
				}
			}
			getDairy();
		}

		private void compareClass(string getGradeName,int getColumn)   //��ѯ����ʳ���������еİ༶
		{
			int gradeNumber = Convert.ToInt32(new GradesDataAccess().GetGradeNumber(getGradeName,"").Tables[0].Rows[0][0]);
			if(getGradeName.Equals("С��"))
			{
				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[6,getColumn-3],m_objSheet.Cells[6,getColumn-3]);
				m_objRange.set_Item(1,1,new FoodManagementDataAccess().GetAllStuAmountForNut(BegDate,EndDate,Convert.ToInt32(BegDate.Date.ToString("MM")),gradeNumber));
			}
			if(getGradeName.Equals("�а�"))
			{
				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[6,getColumn+1],m_objSheet.Cells[6,getColumn+1]);
				m_objRange.set_Item(1,1,new FoodManagementDataAccess().GetAllStuAmountForNut(BegDate,EndDate,Convert.ToInt32(BegDate.Date.ToString("MM")),gradeNumber));
			}
			if(getGradeName.Equals("���"))
			{
				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[6,getColumn+5],m_objSheet.Cells[6,getColumn+5]);
				m_objRange.set_Item(1,1,new FoodManagementDataAccess().GetAllStuAmountForNut(BegDate,EndDate,Convert.ToInt32(BegDate.Date.ToString("MM")),gradeNumber));
			}
			if(getGradeName.Equals("�а�"))
			{
				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[6,getColumn+9],m_objSheet.Cells[6,getColumn+9]);
				m_objRange.set_Item(1,1,new FoodManagementDataAccess().GetAllStuAmountForNut(BegDate,EndDate,Convert.ToInt32(BegDate.Date.ToString("MM")),gradeNumber));
			}
			if(getGradeName.Equals("��ɫ��"))
			{
				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[6,getColumn+13],m_objSheet.Cells[6,getColumn+13]);
				m_objRange.set_Item(1,1,new FoodManagementDataAccess().GetAllStuAmountForNut(BegDate,EndDate,Convert.ToInt32(BegDate.Date.ToString("MM")),gradeNumber));
			}
		}

		private void setACC1(string getFoodName,double getFoodAmount,int getRow,int getColumn,bool isFirRow)
		{
			if ( isFirRow )
			{
				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[getRow,getColumn],m_objSheet.Cells[getRow,getColumn]);
				m_objRange.set_Item(1,1,getFoodName);
			}
			else
			{
				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[getRow,getColumn],m_objSheet.Cells[getRow,getColumn]);
				m_objRange.set_Item(1,1,getFoodAmount);
			}
		}

		private void setElement(double getProtein,double getFat,double getCarbohydrate,int getRow,int getColumn)
		{
			switch(getColumn)
			{
				case 4:  m_objRange = m_objSheet.get_Range(m_objSheet.Cells[getRow,getColumn],m_objSheet.Cells[getRow,getColumn]);
					m_objRange.set_Item(1,1,getProtein);
					break;

				case 6:  m_objRange = m_objSheet.get_Range(m_objSheet.Cells[getRow,getColumn],m_objSheet.Cells[getRow,getColumn]);
					m_objRange.set_Item(1,1,getFat);
					break;

				case 8:  m_objRange = m_objSheet.get_Range(m_objSheet.Cells[getRow,getColumn],m_objSheet.Cells[getRow,getColumn]);
					m_objRange.set_Item(1,1,getCarbohydrate);
					break;
			}
		}

		private void getDairy()    //������������
		{
			DataSet dsGetDairy = new FoodManagementDataAccess().GetDairy(BegDate.Date.ToString("yyyy-MM-dd"),EndDate.Date.ToString("yyyy-MM-dd"),
				Convert.ToInt32(BegDate.Date.ToString("MM")));
			if ( dsGetDairy.Tables[0].Rows[0][0] is DBNull )
			{
				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[140,2],m_objSheet.Cells[140,2]);
				m_objRange.set_Item(1,1,0);
				
			}
			else
			{
				m_objRange = m_objSheet.get_Range(m_objSheet.Cells[140,2],m_objSheet.Cells[140,2]);
				m_objRange.set_Item(1,1,Convert.ToDouble(dsGetDairy.Tables[0].Rows[0][0]));
			}
		}

		public DateTime BegDate
		{
			get { return this.getBegDate; }
			set { this.getBegDate = value; }
		}

		public DateTime EndDate
		{
			get { return this.getEndDate; }
			set { this.getEndDate = value; }
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
