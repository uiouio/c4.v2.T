using System;
using System.Data;
using System.Collections;
using CPTT.BusinessRule;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// OptionSystem ��ժҪ˵����
	/// </summary>
	public class OptionSystem
	{
		private Option option;
		private OptionRules optionRules;
		public OptionSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			option = new Option();
			optionRules = new OptionRules();
		}

		public DataSet getGradeInfo(string gradeName,string gradeNumber,bool isForStu)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.GetGradeList(gradeName,gradeNumber,isForStu);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet getClassInfo(string className,string classNumber,string gradeNumber,bool isForStu)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.GetClassList(className,classNumber,gradeNumber,isForStu);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet getStuBasicInfo(string getGrade,string getClass,string getName,string getNumber)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.GetStuBasicInfo(getGrade,getClass,getName,getNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetStuCard(string getGrade,string getClass,string getName,string getNumber,string getCardNumber)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.GetStuCard(getGrade,getClass,getName,getNumber,getCardNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetTeaBasicInfo(string getDept,string getDuty,string getName,string getNumber)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.GetTeaBasicInfo(getDept,getDuty,getName,getNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetTeaCard(string getDept,string getDuty,string getName,string getNumber,string getCardNumber)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.GetTeaCard(getDept,getDuty,getName,getNumber,getCardNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}	

		public DataSet GetMachine()
		{	
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.GetMachine();
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}	

		public int UpdateGradeInfo(string getOriNumber,string getChNumber,string getChName,string getChRemark)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.UpdateGradeInfo(getOriNumber,getChNumber,getChName,getChRemark);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}	

		public int DeleteGradeInfo(string getOriNumber)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.DeleteGradeInfo(getOriNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public int UpdateClassInfo(string getOriClassNumber,string getOriGradeNumber,string getChClassNumber,string getChGradeNumber,
			string getChClassName,string getChRemark)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.UpdateClassInfo(getOriClassNumber,getOriGradeNumber,getChClassNumber,getChGradeNumber
						,getChClassName,getChRemark);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public int DeleteClassInfo(string getOriClassNumber,string getOriGradeNumber)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.DeleteClassInfo(getOriClassNumber,getOriGradeNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public int CheckStuValidation(Option option)
		{
			try
			{
				if ( Convert.ToInt32(option.StuNumber) <= 1100 || Convert.ToInt32(option.StuNumber) > 8999  || Convert.ToInt32(option.StuNumber)%100 > 70 )
					return -2;
				else if ( option.StuBirthday > option.StuEnterDate )
					return -2;
				else if ( !option.StuEntryStatus.Replace(" ","").Equals("ȫ��") && !option.StuEntryStatus.Replace(" ","").Equals("����") )
					return -2;
				else if ( !option.StuGender.Trim().Equals("��") && !option.StuGender.Trim().Equals("Ů") )
					return -2;
				else
					return UpdateStudentInfo(option);
			}
			catch
			{
				return -3;
			}
		}



		private int UpdateStudentInfo(Option option)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.UpdateStudentInfo(option);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public int DeleteStudentInfo(string getID)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.DeleteStudentInfo(getID);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public int UpdateStuCardInfo(string getID,string getNumber,string getHolder,int getSeq,DateTime getDate)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.UpdateStuCardInfo(getID,getNumber,getHolder,getSeq,getDate);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public int DeleteStuCardInfo(string getID,int getSeq)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.DeleteStuCardInfo(getID,getSeq);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public int CheckTeaValidation(string getID,string getName,string getNumber,string getDept,string getDuty,string getGender)
		{
			try
			{
				if ( Convert.ToInt32(getNumber) <= 9100 || Convert.ToInt32(getNumber) % 100 == 0 || Convert.ToInt32(getNumber) > 9999)
					return -2;
				else
					return UpdateTeaInfo(getID,getName,getNumber,getDept,getDuty,getGender);
			}
			catch
			{
				return -3;
			}
		}

		public int UpdateTeaInfo(string getID,string getName,string getNumber,string getDept,string getDuty,string getGender)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.UpdateTeaInfo(getID,getName,getNumber,getDept,getDuty,getGender);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public int DeleteTeaInfo(string getID,string getNumber)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.DeleteTeaInfo(getID,getNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}
		
		public int UpdateTeaCardInfo(string getID,string getNumber,int getSeq,DateTime getDate)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.UpdateTeaCardInfo(getID,getNumber,getSeq,getDate);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public int DeleteTeaCardInfo(string getID,int getSeq)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.DeleteTeaCardInfo(getID,getSeq);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public int UpdateMachineInfo(int getOriMachineAddr,int getOriMachineType,int getChMachineAddr,int getChMachineType,int getChMachineVol)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.UpdateMachineInfo(getOriMachineAddr,getOriMachineType,getChMachineAddr,getChMachineType,getChMachineVol);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);

					if ( e.Message.IndexOf("�ظ���") > 0 )
						return -1;
					else
						return 0;
				}
			}
		}

		public int DeleteMachineInfo(int getMachineAddr,int getMachineType)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.DeleteMachineInfo(getMachineAddr,getMachineType);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public DataTable GetGradeNumberList()
		{
			using ( OptionDataAccess optionDataAccess = new OptionDataAccess() )
			{
				try
				{
					return optionDataAccess.GetGradeNumberList();
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataTable GetGradeNameByNumber(string getGradeNumber)
		{
			using ( OptionDataAccess optionDataAccess = new OptionDataAccess() )
			{
				try
				{
					return optionDataAccess.GetGradeNameByNumber(getGradeNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public int UpdateGradeNameByNumber(string getGradeNumber,string getGradeName)
		{
			using ( OptionDataAccess optionDataAccess = new OptionDataAccess() )
			{
				try
				{
					return optionDataAccess.UpdateGradeNameByNumber(getGradeNumber,getGradeName);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public DataTable GetClassNumberList(string getGradeNumber)
		{
			using ( OptionDataAccess optionDataAccess = new OptionDataAccess() )
			{
				try
				{
					return optionDataAccess.GetClassNumberList(getGradeNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataTable GetClassNameByNumber(string getGradeNumber,string getClassNumber)
		{
			using ( OptionDataAccess optionDataAccess = new OptionDataAccess() )
			{
				try
				{
					return optionDataAccess.GetClassNameByNumber(getGradeNumber,getClassNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public int UpdateClassNameByNumber(string getGradeNumber,string getClassNumber,string getClassName)
		{
			using ( OptionDataAccess optionDataAccess = new OptionDataAccess() )
			{
				try
				{
					return optionDataAccess.UpdateClassNameByNumber(getGradeNumber,getClassNumber,getClassName);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public bool UpdateStudentForGradeChange(string getName,int getGrade,int getClass,string getType)
		{
			using ( OptionDataAccess optionDataAccess = new OptionDataAccess()  )
			{
				bool rtnValue = false;
				try
				{
					int isStudentExisits = optionDataAccess.UpdateStudentForGradeChange(getName,getGrade,getClass,getType);

					if ( isStudentExisits != 0 ) rtnValue = true;
					else rtnValue = false;
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					rtnValue = false;
				}

				return rtnValue;
			}
		}

		public int InsertNewStudentForGradeChange(string stuName,int stuGrade,int stuClass,string stuType)
		{
			using ( OptionDataAccess optionDataAccess = new OptionDataAccess()  )
			{
				try
				{
					return optionDataAccess.InsertNewStudentForGradeChange(stuName,stuGrade,stuClass,stuType);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}	
			}
		}

		public DataTable GetStuNameByNumber(string stuNumber)
		{
			using ( OptionDataAccess optionDataAccess = new OptionDataAccess()  )
			{
				try
				{
					return optionDataAccess.GetStuNameByNumber(stuNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}	
			}
		}

		public void ReadStuInfoXLS(ref DataSet dsStuInfoXls,string getPath,int classNumbers,ref Hashtable className)
		{
			optionRules.ReadStuInfoXLS(ref dsStuInfoXls,getPath,classNumbers,ref className);
		}

		public string CheckStuInfo_Grade(string getGrade,ref bool isOk)
		{
			try
			{
				int gradeNumber = Convert.ToInt32(getGrade.Replace(" ",""));
				if ( gradeNumber < 1 || gradeNumber > 8 )
				{
					isOk = false;
					return "�꼶���ֻ����1-8��Χ�ڣ�";
				}
				else
				{
					isOk = true;
					return "ok";
				}
			}
			catch(Exception e)
			{
				isOk = false;
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				return "�꼶���Ӧ�������ֱ�ʾ��";
			}
		}

		public string CheckStuInfo_Class(string getClass,ref bool isOk)
		{
			try
			{
				int classNumber = Convert.ToInt32(getClass.Replace(" ",""));
				if ( classNumber < 1 || classNumber > 9 )
				{
					isOk = false;
					return "�༶���ֻ����1-9��Χ�ڣ�";
				}
				else
				{
					isOk = true;
					return "ok";
				}
			}
			catch(Exception e)
			{
				isOk = false;
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				return "�༶���Ӧ�������ֱ�ʾ��";
			}
		}

		public string CheckStuInfo_Name(string getName,ref bool isOk)
		{
			if ( getName.Replace(" ","").Equals(string.Empty) )
			{
				isOk = false;
				return "��������Ϊ�գ�";
			}
			else
			{
				isOk = true;
				return "ok";
			}
		}

		public string CheckStuInfo_Gender(string getGender,ref bool isOk)
		{
			if ( !getGender.Trim().Equals("��") && !getGender.Trim().Equals("Ů") )
			{
				isOk = false;
				return "�Ա��޷���ʶ��";
			}
			else
			{
				isOk = true;
				return "ok";
			}
		}

		public string CheckStuInfo_Birthday(string getBirthday,string getEnterDate,ref bool isOk)
		{
			try
			{
				DateTime birthday = Convert.ToDateTime(getBirthday);
				DateTime enterDate = Convert.ToDateTime(getEnterDate);
				if ( birthday.Year > 1990 && enterDate.Year > 1990 )
				{
					isOk = true;
					if ( birthday > enterDate )
					{
						isOk = false;
						return "���ղ��ô�����԰���ڣ�";
					}
					else
					{
						isOk = true;
						return "ok";
					}
				}
				else
				{
					isOk = false;
					return "��������ջ���԰���ڲ�����ʱ��淶��";
				}
			}
			catch(Exception e)
			{
				isOk = false;
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				return "���ջ���԰���ڲ�����ʱ��淶��";
			}
		}

		public string CheckStuInfo_Type(string getType,ref bool isOk)
		{
			if ( !getType.Replace(" ","").Equals("ȫ��") && !getType.Replace(" ","").Equals("����") )
			{
				isOk = false;
				return "��԰���Ͳ���ȷ��";
			}
			else
			{
				isOk = true;
				return "ok";
			}
		}

		public string CheckStuCardInfo_Holder(string getHolder,ref bool isOk)
		{
			if ( getHolder.Replace(" ","").Equals(string.Empty) )
			{
				isOk = false;
				return "�п��ŵ�����£��ֿ��˲�Ӧ��Ϊ�գ�";
			}
			else
			{
				isOk = true;
				return "ok";
			}
		}

		public string CheckStuCardInfo_SendDate(string getDate,string getEnterDate,ref bool isOk)
		{
			try
			{
				DateTime sendDate = Convert.ToDateTime(getDate);
				DateTime enterDate = Convert.ToDateTime(getEnterDate);
				if ( enterDate > sendDate )
				{
					isOk = false;
					return "��԰���ڴ��ڷ������ڣ�";
				}
				else
				{
					isOk = true;
					return "ok";
				}
			}
			catch(Exception e)
			{
				isOk = false;
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				return "�������ڲ�����ʱ��淶��";
			}
		}

		public string CheckMachine(string getMachineAddr,string getMachineType,string getMachineVol,ref bool isOk)
		{
			try
			{
				int getAddr = Convert.ToInt32(getMachineAddr);
				int getType = Convert.ToInt32(getMachineType);
				int getVol = Convert.ToInt32(getMachineVol);
				isOk = true;
				return "ok";
			}
			catch(Exception e)
			{
				isOk = false;
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				return "����д���Ϲ淶�����֣�";
			}
		}

		public string CheckTeaInfo_Dept(string getDept,ref bool isOk)
		{
			if ( getDept.Replace(" ","").Equals(string.Empty) )
			{
				isOk = false;
				return "�������Ʋ���Ϊ�գ�";
			}
			else
			{
				isOk = true;
				return "ok";
			}
		}

		public string CheckTeaInfo_Duty(string getDuty,ref bool isOk)
		{
			if ( getDuty.Replace(" ","").Equals(string.Empty) )
			{
				isOk = false;
				return "��λ���Ʋ���Ϊ�գ�";
			}
			else
			{
				isOk = true;
				return "ok";
			}
		}

		public string CheckTeaInfo_Authority(string getAuthority,ref bool isOk)
		{
			if ( !getAuthority.Replace(" ","").Equals("������") && !getAuthority.Equals("������ʦ") && !getAuthority.Equals("����") && !getAuthority.Equals("԰��") && !getAuthority.Equals("һ���ʦ") )
			{
				isOk = false;
				return "��ʦȨ��ֻ���ڷ�Χ[������]��[������ʦ]��[����]��[԰��]��[һ���ʦ]��";
			}
			else
			{
				isOk = true;
				return "ok";
			}
		}

		public string CheckTeaInfo_CardSendDate(string getSendDate,ref bool isOk)
		{
			try
			{
				DateTime sendDate = Convert.ToDateTime(getSendDate);
				isOk = true;
				return "ok";
			}
			catch(Exception e)
			{
				isOk = false;
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				return "�ƿ����ڲ�����ʱ��淶��";
			}
		}

		public int InsertStuInfo(Option option)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.InsertStuInfo(option);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

        public void InsertStuParentInfo(Option option)
        {
            using (OptionDataAccess optionDataAccess = new OptionDataAccess())
            {
                try
                {
                    optionDataAccess.InsertStuParentInfo(option);
                }
                catch (Exception e)
                {
                    Util.WriteLog(e.Message, Util.EXCEPTION_LOG_TITLE);
                }
            }
        }

		public int InsertStuCardInfo(string getID,string getCardNumber,string getHolder,DateTime getDate,int getSeq)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.InsertStuCardInfo(getID,getCardNumber,getHolder,getDate,getSeq);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public void InsertMachine(string terminalNumbers,string machineVol)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					optionDataAccess.InsertMachine(terminalNumbers,machineVol);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		public int InsertMachine(string getAddr,string getType,string getVol)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.InsertMachine(getAddr,getType,getVol);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public void InsertTeaInfo(Option option)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					optionDataAccess.InsertTeaInfo(option);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		public int InsertTeaCardInfo(string getID,string getCardNumber,DateTime getCardSendDate,int getCardSeq)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					return optionDataAccess.InsertTeaCardInfo(getID,getCardNumber,getCardSendDate,getCardSeq);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public void ReadTeaInfoXLS(ref DataSet dsTeaInfoXls,string getPath)
		{
			optionRules.ReadTeaInfoXLS(ref dsTeaInfoXls,getPath);
		}

		public void ReadStuCardInfoXLS(ref DataSet dsReadStuCardInfo,string getPath)
		{
			optionRules.ReadStuCardInfoXLS(ref dsReadStuCardInfo,getPath);
		}

		public DataTable ReadUpdateGradeInfo(string getPath)
		{
			DataTable dtUpdateGradeInfo = new DataTable();
			optionRules.ReadUpdateGradeInfo(ref dtUpdateGradeInfo,getPath);

			dtUpdateGradeInfo.Columns[0].ColumnName = "info_stuName";
			dtUpdateGradeInfo.Columns[1].ColumnName = "info_stuGrade";
			dtUpdateGradeInfo.Columns[2].ColumnName = "info_stuClass";
			dtUpdateGradeInfo.Columns[3].ColumnName = "info_type";

			DataColumn dc = new DataColumn("info_checkType");
			dc.DataType = System.Type.GetType("System.Boolean");
			dtUpdateGradeInfo.Columns.Add(dc);

			for ( int i=dtUpdateGradeInfo.Rows.Count; i>0 ; i--  )
			{
				dtUpdateGradeInfo.Rows[i-1][4] = false;

				if ( dtUpdateGradeInfo.Rows[i-1].IsNull(0) || dtUpdateGradeInfo.Rows[i-1].IsNull(1)
					|| dtUpdateGradeInfo.Rows[i-1].IsNull(2) || dtUpdateGradeInfo.Rows[i-1].IsNull(3) )
				{
					dtUpdateGradeInfo.Rows[i-1].Delete();
					dtUpdateGradeInfo.Rows[i-1].AcceptChanges();		
				}
			}

			return dtUpdateGradeInfo;
		}

		public void WriteStuCardInfoXLS(string getPath)
		{
			using ( OptionDataAccess optionDataAccess = new OptionDataAccess() )
			{
				try
				{
					optionRules.WriteStuCardInfoXLS(optionDataAccess.GetStuInfo(),getPath);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		public void CreateStudentBaseSimpleTable()
		{
			optionRules.CreateStudentBaseSimpleTable();
		}

		public string CheckStuInfo_Number(string getNumber,ref bool isOk)
		{
			try
			{
				int stuNumber = Convert.ToInt32(getNumber.Replace(" ",""));
				if ( stuNumber < 1101 || stuNumber > 8999 )
				{
					isOk = false;
					return "ѧ��ѧ��ֻ���ڷ�Χ1101-8999";
				}
				else
				{
					isOk = true;
					return "ok";
				}
			}
			catch(Exception e)
			{
				isOk = false;
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				return "ѧ��ѧ��Ӧ��Ϊ���֣�";
			}
		}

		public int InsertNewAddCardInfo(string getNumber,string getCardNumber,string getHolder,DateTime getSendDate)
		{
			using ( OptionDataAccess optionDataAccess = new OptionDataAccess() )
			{
				try
				{
					return optionDataAccess.InsertNewAddCardInfo(getNumber,getCardNumber,getHolder,getSendDate);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public string CheckIsGradeExists(string getGrade,ref bool isOk)
		{
			using ( OptionDataAccess optionDataAccess = new OptionDataAccess() )
			{
				try
				{
				
					int gradeNumber = Convert.ToInt32(getGrade.Replace(" ",""));

					DataTable dtGrade = optionDataAccess.IsExistGrade(gradeNumber);
					
					if ( dtGrade.Rows.Count > 0 )
					{
						isOk = true;
						return "ok";
					}
					else
					{
						isOk = false;
						return "�꼶�����������ԣ�";
					}
				}
				catch(Exception e)
				{
					isOk = false;
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return "�꼶����Ӧ��Ϊ���֣�";
				}
			}
		}

		public string CheckIsClassExists(string getGrade,string getClass,ref bool isOk)
		{
			using ( OptionDataAccess optionDataAccess = new OptionDataAccess() )
			{
				try
				{
				
					int gradeNumber = Convert.ToInt32(getGrade.Replace(" ",""));
					int classNumber = Convert.ToInt32(getClass.Replace(" ",""));

					DataTable dtClass = optionDataAccess.IsExistClass(gradeNumber,classNumber);
					
					if ( dtClass.Rows.Count > 0 )
					{
						isOk = true;
						return "ok";
					}
					else
					{
						isOk = false;
						return "�༶�����������ԣ�";
					}
				}
				catch(Exception e)
				{
					isOk = false;
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return "�༶����Ӧ��Ϊ���֣�";
				}
			}
		}

		public string CheckType(string getType,ref bool isOk)
		{
			if ( !getType.Replace(" ","").Equals("ȫ��") && !getType.Replace(" ","").Equals("����") )
			{
				isOk = false;
				return "���Ͳ����ڣ���ָ��ȫ�л����У�";
			}
			else
			{
				isOk = true;
				return "ok";
			}
		}

		public string CheckName(string getName,ref bool isOk)
		{
			if ( getName.Equals(string.Empty) ) 
			{
				isOk = false;
				return "��������Ϊ�գ�";
				}
			else
			{
				isOk = true;
				return "ok";
			}
		}

		public bool ExecuteBackupFully(string root)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					optionDataAccess.ExecuteBackupFully(root);
					return true;
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return false;
				}
			}
		}

		public bool ExecuteBackupDiff(string root)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					optionDataAccess.ExecuteBackupDiff(root);
					return true;
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return false;
				}
			}
		}

        public void AddOrUpdateBackupPath(string path)
        {
            using (OptionDataAccess optionDataAccess = new OptionDataAccess())
            {
                try
                {
                    optionDataAccess.AddOrUpdateBackupPath(path);
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
                }
            }
        }

        public string GetBackupPath()
        {
            var backupPath = string.Empty;
            using (OptionDataAccess optionDataAccess = new OptionDataAccess())
            {
                try
                {
                    backupPath = optionDataAccess.GetBackupPath();
                }
                catch (Exception ex)
                {
                    Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
                }
                return backupPath;
            }
        }

		public bool AddBackupJob(int type,string root)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					optionDataAccess.AddBackupJob(type,root);
					return true;
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return false;
				}
			}
		}

		public bool ExecuteRestoreFully(string root)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					optionDataAccess.ExecuteRestoreFully(root);
					return true;
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return false;
				}
			}
		}

		public bool ExecuteRestoreDiff(string root)
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					optionDataAccess.ExecuteRestoreDiff(root);
					return true;
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return false;
				}
			}
		}

		public bool ExecuteKillSysdbProcesses()
		{
			using (OptionDataAccess optionDataAccess = new OptionDataAccess())
			{
				try
				{
					optionDataAccess.KillSysdbProcesses();
					return true;
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return false;
				}
			}
		}
	}
}
