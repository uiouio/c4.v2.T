using System;
using System.Data;
using System.Collections;
using CPTT.BusinessRule;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// OptionSystem 的摘要说明。
	/// </summary>
	public class OptionSystem
	{
		private Option option;
		private OptionRules optionRules;
		public OptionSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
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
				else if ( !option.StuEntryStatus.Replace(" ","").Equals("全托") && !option.StuEntryStatus.Replace(" ","").Equals("日托") )
					return -2;
				else if ( !option.StuGender.Trim().Equals("男") && !option.StuGender.Trim().Equals("女") )
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

					if ( e.Message.IndexOf("重复键") > 0 )
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
					return "年级编号只能在1-8范围内！";
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
				return "年级编号应该以数字表示！";
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
					return "班级编号只能在1-9范围内！";
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
				return "班级编号应该以数字表示！";
			}
		}

		public string CheckStuInfo_Name(string getName,ref bool isOk)
		{
			if ( getName.Replace(" ","").Equals(string.Empty) )
			{
				isOk = false;
				return "姓名不能为空！";
			}
			else
			{
				isOk = true;
				return "ok";
			}
		}

		public string CheckStuInfo_Gender(string getGender,ref bool isOk)
		{
			if ( !getGender.Trim().Equals("男") && !getGender.Trim().Equals("女") )
			{
				isOk = false;
				return "性别无法被识别！";
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
						return "生日不得大于入园日期！";
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
					return "输入的生日或入园日期不符合时间规范！";
				}
			}
			catch(Exception e)
			{
				isOk = false;
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				return "生日或入园日期不符合时间规范！";
			}
		}

		public string CheckStuInfo_Type(string getType,ref bool isOk)
		{
			if ( !getType.Replace(" ","").Equals("全托") && !getType.Replace(" ","").Equals("日托") )
			{
				isOk = false;
				return "入园类型不正确！";
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
				return "有卡号的情况下，持卡人不应该为空！";
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
					return "入园日期大于发卡日期！";
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
				return "发卡日期不符合时间规范！";
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
				return "请填写符合规范的数字！";
			}
		}

		public string CheckTeaInfo_Dept(string getDept,ref bool isOk)
		{
			if ( getDept.Replace(" ","").Equals(string.Empty) )
			{
				isOk = false;
				return "部门名称不能为空！";
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
				return "岗位名称不能为空！";
			}
			else
			{
				isOk = true;
				return "ok";
			}
		}

		public string CheckTeaInfo_Authority(string getAuthority,ref bool isOk)
		{
			if ( !getAuthority.Replace(" ","").Equals("班主任") && !getAuthority.Equals("保健老师") && !getAuthority.Equals("财务") && !getAuthority.Equals("园长") && !getAuthority.Equals("一般教师") )
			{
				isOk = false;
				return "教师权限只能在范围[班主任]，[保健老师]，[财务]，[园长]，[一般教师]内";
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
				return "制卡日期不符合时间规范！";
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
					return "学生学号只能在范围1101-8999";
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
				return "学生学号应该为数字！";
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
						return "年级不存在请重试！";
					}
				}
				catch(Exception e)
				{
					isOk = false;
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return "年级号码应该为数字！";
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
						return "班级不存在请重试！";
					}
				}
				catch(Exception e)
				{
					isOk = false;
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return "班级号码应该为数字！";
				}
			}
		}

		public string CheckType(string getType,ref bool isOk)
		{
			if ( !getType.Replace(" ","").Equals("全托") && !getType.Replace(" ","").Equals("日托") )
			{
				isOk = false;
				return "类型不存在，请指定全托或日托！";
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
				return "姓名不能为空！";
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
