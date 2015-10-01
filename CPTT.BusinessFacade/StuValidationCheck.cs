using System;
using System.Data;
using CPTT.SystemFramework;
using CPTT.DataAccess;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// StuValidationCheck 的摘要说明。
	/// </summary>
	public class StuValidationCheck
	{
		private Students students;
		private GetStuInfoByCondition getStuInfoByCondition;
		public StuValidationCheck()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			students = new Students();
			getStuInfoByCondition = new GetStuInfoByCondition();
		}

		#region 检验各用户字段的有效性，并设置学生各项属性
		//检验名字是否有效
		public bool isValidStuName(string getStuName)
		{
			if ( !(getStuName.Equals("") || getStuName.Length < 1) )
			{
				students.Name = getStuName;
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool isValidStuNumber(string getNumber)
		{
			string validNumberString = "0123456789";
			for( int i = 0;i < getNumber.Length;i ++ )
			{
				if ( validNumberString.IndexOf(getNumber.Substring(i,1)) < 0 )
					return false;
			}
			if ( Convert.ToInt32(getNumber) < 1101 || Convert.ToInt32(getNumber) > 8999 )
				return false;
			else
				return true;
		}

		//检验性别是否有效
		public bool isValidStuGender(string getStuGender)
		{
			if ( !getStuGender.Equals("") )
			{
				if( getStuGender.Equals("男") || getStuGender.Equals("女") )
				{
					students.Gender = getStuGender;
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		//查询连续的学号
		public void getSerialStuNumber(string getGrade,string getClass,ref bool overValidNumber)
		{
			//获取指定班级学生的所有学号
			DataSet getSerialNumber = getStuInfoByCondition.GetStuInfo(getGrade,getClass,"","");

			//初始化第一个学号为00号
			int firNumber = (Convert.ToInt32(getGrade)*1000+Convert.ToInt32(getClass)*100);

			//当前学生数不为零
			if ( getSerialNumber.Tables[0].Rows.Count != 0 )
			{
				//当前学生数量为1名以上情况
				if ( getSerialNumber.Tables[0].Rows.Count > 1 )
				{
					//循环查询找出两个学号不相邻的情况
					for(int i=0;i<getSerialNumber.Tables[0].Rows.Count; i++)
					{
						int secNumber = Convert.ToInt32(getSerialNumber.Tables[0].Rows[i][1]);
						if ( secNumber - firNumber > 1 )
						{
							if ((firNumber + 1) % 100 == 99 || (firNumber + 1 ) >= 9999)
							//if ( (firNumber+1)%100 > 70 )
							{
								overValidNumber = true;
								break;
							}
							else
							{
								students.Number = (firNumber+1).ToString();
								break;
							}
						}
						
						if ( i == getSerialNumber.Tables[0].Rows.Count - 1 )
						{
							if ((firNumber + 1) % 100 == 99 || (firNumber + 1 ) >= 9999)
							//if ( (secNumber+1)%100 > 70 )
							{
								overValidNumber = true;
								break;
							}
							else
								students.Number = (secNumber + 1).ToString();
						}

						 firNumber = Convert.ToInt32(getSerialNumber.Tables[0].Rows[i][1]);
					}
				}
				//只有一名学生的情况
				else
				{
					//如果01号学生没有被使用，则赋予该学生为01号
					if ( Convert.ToInt32(getSerialNumber.Tables[0].Rows[0][1]) - firNumber > 1 )
						students.Number = (firNumber+1).ToString();
					else
						students.Number = (Convert.ToInt32(getSerialNumber.Tables[0].Rows[0][1])+1).ToString();
				}
			}
			else
				students.Number = (firNumber + 1).ToString();

		}

		//查询用户指定的学号是否已经存在
		public bool hasSameNumber(string getNumber,string getGuid,ref bool overValidNumber,ref bool isThisClass,string getClassNumber,string getGradeNumber)
		{
			if ( Convert.ToInt32(getNumber)/100%10 == Convert.ToInt32(getClassNumber) && Convert.ToInt32(getNumber)/1000 == Convert.ToInt32(getGradeNumber) )
			{
				if ( Convert.ToInt32(getNumber)%100 <= 70 )
				{
					DataSet getSameNumber = getStuInfoByCondition.GetStuInfo("","","",getNumber);
					if ( getSameNumber.Tables[0].Rows.Count>0 )	
					{
						//允许修改自身数据
						if( getSameNumber.Tables[0].Rows[0][0].ToString().Equals(getGuid) )
						{
							students.Number = getNumber;
							return true;
						}
						else
							return false;
					}
					else
					{
						students.Number = getNumber;
						return true;
					}
				}
				else
				{
					overValidNumber = true;
					return false;
				}
			}
			else
			{
				isThisClass = false;
				return false;
			}
		}

		public bool HasCard(string stuID,string stuNumber)
		{
			using ( StuInfoDataAccess stuInfoDataAccess = new StuInfoDataAccess() )
			{
				if ( stuInfoDataAccess.HasCard(stuID,stuNumber) )
					return true;
				else
					return false;
			}
		}

		//检验入院状态是否有效
		public bool isValidEntryStatus(string getEntryStatus)
		{
			if ( !getEntryStatus.Equals("") )
			{
				if ( getEntryStatus.Equals("全托") || getEntryStatus.Equals("日托") )
				{
					students.EntryStatus = getEntryStatus;
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}
	
		//检验是否有效手机注册号码
		public bool isValidRegNote(string getRegNote)
		{
			string validNumberString = "0123456789";
			string regPhone = getRegNote;
			if(getRegNote.Equals(""))
				return true;
			else
			{
				if ( regPhone.Length !=11 )
					return false;
				else
				{
					for( int i=0;i<regPhone.Length;i++ )
					{
						if ( validNumberString.IndexOf(regPhone.Substring(i,1))<0 )
							return false;
					}
					students.RegNote = getRegNote;
					return true;			
				}		
			}
		}

		//检验是否有效EMail地址
		public bool isValidEmail(string getEMail)
		{
			if(getEMail.Equals(""))
				return true;
			else
			{
				if ( getEMail.IndexOf("@")<0 )
					return false;
				else 
				{
					students.EMail = getEMail;
					return true;
				}
			}
		}

		//检验是否有效年级
		public bool isValidGrade(string getGrade)
		{
			if ( !getGrade.Equals("0") )
			{
				students.Grade = getGrade;
				return true;
			}
			else
				return false;
		}

		//检验是否有效班级
		public bool isValidClass(string getClass)
		{
			if ( !getClass.Equals("0"))
			{
				students.Class = getClass;
				return true;
			}
			else
				return false;
		}

		//检验出生日期和入园日期是否为空，或是否符合逻辑
		public bool isValidDate(DateTime getBirthday,DateTime getEntryDate)
		{
			if( !(getBirthday.Date.ToString().Equals("") || getEntryDate.Date.ToString().Equals("")) )
			{
				if( getBirthday > getEntryDate )
					return false;
				else
				{
					if ( getBirthday > DateTime.Now || getEntryDate > DateTime.Now )
						return false;
					else
					{
						students.Birthday = getBirthday;
						students.EntryDate = getEntryDate;
						return true;
					}
				}
			}
			else
				return false;
		}
		#endregion

		#region 设置无须检验的学生各项属性
		public void getStuGuid(string getGuid)
		{
			students.StuGuid = getGuid;
		}
		
		public void getStuOrigin(string getOrigin)
		{
			students.Origin = getOrigin;
		}

		public void getStuNationality(string getNationality)
		{
			students.Nationality = getNationality;
		}

		public void getStuNative(string getNative)
		{
			students.Native = getNative;
		}

		public void getStuJieDao(string getJieDao)
		{
			students.JieDao = getJieDao;
		}

		public void getStuLiWei(string getLiWei)
		{
			students.LiWei = getLiWei;
		}

		public void getStuFamilyAddr(string getFamilyAddr)
		{
			students.FamilyAddr = getFamilyAddr;
		}

		public void getStuHuKouAddr(string getHuKouAddr)
		{
			students.HuKouAddr = getHuKouAddr;
		}

		public void getStuZipCode(string getZipCode)
		{
			students.ZipCode = getZipCode;
		}

		public void getStuSickHistory(string getSickHistory)
		{
			students.SickHistory = getSickHistory;
		}

		public void getStuBankID(string getBankID)
		{
			students.BankID = getBankID;
		}

		public void getStuGraphLocation(byte[] getGraphLocation)
		{
			students.GraphLocation = getGraphLocation;
		}

		public void getStuFatherName(string getFatherName)
		{
			students.FatherName = getFatherName;
		}

		public void getStuFatherLinkPhone(string getFatherLinkPhone)
		{
			students.FatherPhone = getFatherLinkPhone;
		}

		public void getStuFatherWorkPlace(string getFatherWorkPlace)
		{
			students.FatherWorkPlace = getFatherWorkPlace;
		}

		public void getStuMotherName(string getMotherName)
		{
			students.MotherName = getMotherName;
		}

		public void getStuMotherLinkPhone(string getMotherLinkPhone)
		{
			students.MotherPhone = getMotherLinkPhone;
		}

		public void getStuMotherWorkPlace(string getMotherWorkPlace)
		{
			students.MotherWorkPlace = getMotherWorkPlace;
		}
		#endregion

		#region 学生相关数据操作
		//学生基本信息插入
		public void doStuBasicInfoInsert()
		{
			using (StuInfoDataAccess stuInfoDataAccess = new StuInfoDataAccess())
			{
				try
				{
					stuInfoDataAccess.InsertStuBasicInfo(students);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		//学生附加信息插入
		public void doStuDetailInfoInsert()
		{
			using (StuInfoDataAccess stuInfoDataAccess = new StuInfoDataAccess())
			{
				try
				{
					stuInfoDataAccess.InsertStuDetailInfo(students);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		//学生父母信息插入
		public void doStuParentInfoInsert()
		{
			using (StuInfoDataAccess stuInfoDataAccess = new StuInfoDataAccess())
			{
				try
				{
					stuInfoDataAccess.InsertStuParentInfo(students);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		//学生基本信息更新
		public void doStuBasicInfoUpdate()
		{
			try
			{
				using (StuInfoDataAccess stuInfoDataAccess = new StuInfoDataAccess())
				{
					stuInfoDataAccess.UpdateStuBasicInfo(students);
				}
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
			}
		}

		//学生额外信息更新
		public void doStuDetailInfoUpdate()
		{
			using (StuInfoDataAccess stuInfoDataAccess = new StuInfoDataAccess())
			{
				try
				{
					stuInfoDataAccess.UpdateStuDetailInfo(students);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		//学生父母信息更新
		public void doStuParentInfoUpdate()
		{
			using(StuInfoDataAccess stuInfoDataAccess = new StuInfoDataAccess())
			{
				try
				{
					stuInfoDataAccess.UpdateStuParentInfo(students);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		//学生基本信息删除
		public void doStuBasicInfoDelete()
		{
			using (StuInfoDataAccess stuInfoDataAccess = new StuInfoDataAccess())
			{
				try
				{
					stuInfoDataAccess.DeleteStuBasicInfo(students);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		//学生额外信息删除
		public void doStuDetailInfoDelete()
		{
			using (StuInfoDataAccess stuInfoDataAccess = new StuInfoDataAccess())
			{
				try
				{
					stuInfoDataAccess.DeleteStuDetailInfo(students);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}

		//学生父母信息删除

		public void doStuParentInfoDelete()
		{
			using (StuInfoDataAccess stuInfoDataAccess = new StuInfoDataAccess())
			{
				try
				{
					stuInfoDataAccess.DeleteStuParentInfo(students);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				}
			}
		}
		#endregion
	}
}
