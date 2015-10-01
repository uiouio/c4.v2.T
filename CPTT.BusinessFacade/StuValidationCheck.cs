using System;
using System.Data;
using CPTT.SystemFramework;
using CPTT.DataAccess;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// StuValidationCheck ��ժҪ˵����
	/// </summary>
	public class StuValidationCheck
	{
		private Students students;
		private GetStuInfoByCondition getStuInfoByCondition;
		public StuValidationCheck()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			students = new Students();
			getStuInfoByCondition = new GetStuInfoByCondition();
		}

		#region ������û��ֶε���Ч�ԣ�������ѧ����������
		//���������Ƿ���Ч
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

		//�����Ա��Ƿ���Ч
		public bool isValidStuGender(string getStuGender)
		{
			if ( !getStuGender.Equals("") )
			{
				if( getStuGender.Equals("��") || getStuGender.Equals("Ů") )
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

		//��ѯ������ѧ��
		public void getSerialStuNumber(string getGrade,string getClass,ref bool overValidNumber)
		{
			//��ȡָ���༶ѧ��������ѧ��
			DataSet getSerialNumber = getStuInfoByCondition.GetStuInfo(getGrade,getClass,"","");

			//��ʼ����һ��ѧ��Ϊ00��
			int firNumber = (Convert.ToInt32(getGrade)*1000+Convert.ToInt32(getClass)*100);

			//��ǰѧ������Ϊ��
			if ( getSerialNumber.Tables[0].Rows.Count != 0 )
			{
				//��ǰѧ������Ϊ1���������
				if ( getSerialNumber.Tables[0].Rows.Count > 1 )
				{
					//ѭ����ѯ�ҳ�����ѧ�Ų����ڵ����
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
				//ֻ��һ��ѧ�������
				else
				{
					//���01��ѧ��û�б�ʹ�ã������ѧ��Ϊ01��
					if ( Convert.ToInt32(getSerialNumber.Tables[0].Rows[0][1]) - firNumber > 1 )
						students.Number = (firNumber+1).ToString();
					else
						students.Number = (Convert.ToInt32(getSerialNumber.Tables[0].Rows[0][1])+1).ToString();
				}
			}
			else
				students.Number = (firNumber + 1).ToString();

		}

		//��ѯ�û�ָ����ѧ���Ƿ��Ѿ�����
		public bool hasSameNumber(string getNumber,string getGuid,ref bool overValidNumber,ref bool isThisClass,string getClassNumber,string getGradeNumber)
		{
			if ( Convert.ToInt32(getNumber)/100%10 == Convert.ToInt32(getClassNumber) && Convert.ToInt32(getNumber)/1000 == Convert.ToInt32(getGradeNumber) )
			{
				if ( Convert.ToInt32(getNumber)%100 <= 70 )
				{
					DataSet getSameNumber = getStuInfoByCondition.GetStuInfo("","","",getNumber);
					if ( getSameNumber.Tables[0].Rows.Count>0 )	
					{
						//�����޸���������
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

		//������Ժ״̬�Ƿ���Ч
		public bool isValidEntryStatus(string getEntryStatus)
		{
			if ( !getEntryStatus.Equals("") )
			{
				if ( getEntryStatus.Equals("ȫ��") || getEntryStatus.Equals("����") )
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
	
		//�����Ƿ���Ч�ֻ�ע�����
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

		//�����Ƿ���ЧEMail��ַ
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

		//�����Ƿ���Ч�꼶
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

		//�����Ƿ���Ч�༶
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

		//����������ں���԰�����Ƿ�Ϊ�գ����Ƿ�����߼�
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

		#region ������������ѧ����������
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

		#region ѧ��������ݲ���
		//ѧ��������Ϣ����
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

		//ѧ��������Ϣ����
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

		//ѧ����ĸ��Ϣ����
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

		//ѧ��������Ϣ����
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

		//ѧ��������Ϣ����
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

		//ѧ����ĸ��Ϣ����
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

		//ѧ��������Ϣɾ��
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

		//ѧ��������Ϣɾ��
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

		//ѧ����ĸ��Ϣɾ��

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
