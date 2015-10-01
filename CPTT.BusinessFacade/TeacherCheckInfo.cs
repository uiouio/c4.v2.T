//==================================================================================
// �������ܳ����������ϵͳ4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//������������ܰ�Ȩ���͹�����Լ����.
// ��δ����Ȩ�����Ը��ƻ򴫲�������(�������κβ���),���ܵ����������¼������Ʋ�,
//�����ڷ�����ɵķ�Χ���ܵ����̶ȵ�����!
//==================================================================================

using System;
using System.Data;
using CPTT.SystemFramework;
using CPTT.DataAccess;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// TeacherCheckInfo ��ժҪ˵����
	/// </summary>
	public class TeacherCheckInfo
	{		
		TeacherBaseDataAccess teacherBaseDA = new TeacherBaseDataAccess();
		private TeacherBase tchBase;
		private bool isNextRanger = false;
		public TeacherCheckInfo()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		tchBase = new TeacherBase();
		}

		public bool isValidTcName(string tcName)
		{
			if ( !(tcName.Equals("") || tcName.Length < 1) )
			{
				tchBase.TName = tcName;
				return true;
			}
			else
			{
				return false;
			}
		}

		//��ѯ�����Ĺ���
		//9570 is the max number allowed
		public string getSerialTcNumber()
		{
			//��ȡ���й���
			DataSet getSerialNumber = teacherBaseDA.GetTcBaseList();
			
			//��ʼ����һ������Ϊ00��
			int firNumber = 9100;

			//��ǰ��ʦ����Ϊ��
			if ( getSerialNumber.Tables[0].Rows.Count != 0)
			{
				//��ǰ��ʦ����Ϊ1���������
				if ( getSerialNumber.Tables[0].Rows.Count > 1 )
				{
					//ѭ����ѯ�ҳ��������Ų����ڵ����
					for(int i = 0; i < getSerialNumber.Tables[0].Rows.Count; i++)
					{
						int teacherNumber = Convert.ToInt32(getSerialNumber.Tables[0].Rows[i][1]);
						//�Ѿ������һ������ǰֵ+1��10λ���͸�λ��������ֻ��70
						if (i == getSerialNumber.Tables[0].Rows.Count - 1)
						{
							if ((++teacherNumber - 70) % 100 == 1)
								teacherNumber = teacherNumber + 30; //������һ��
							tchBase.TNumber = teacherNumber.ToString();
							break;
						}
						else
						{
							int next = Convert.ToInt32(getSerialNumber.Tables[0].Rows[i + 1][1]);
							if (next - teacherNumber > 1)
							{
								if((next - 1) % 100 != 0)
								{
									if ((++teacherNumber - 70) % 100 == 1)
										teacherNumber = teacherNumber + 30;
									tchBase.TNumber = teacherNumber.ToString();
									break;
								}
								else
								{
									if ((++teacherNumber - 70) % 100 != 1)
									{
										teacherNumber = teacherNumber++;
										tchBase.TNumber = teacherNumber.ToString();
										break;
									}
								}
							}
						}
					}
				}
				//ֻ��һ����ʦ�����
				else
				{
					//���01�Ž�ʦû�б�ʹ�ã�����ý�ʦΪ01��
					if ( Convert.ToInt32(getSerialNumber.Tables[0].Rows[0][1]) - firNumber > 1 )
						tchBase.TNumber = Convert.ToString(firNumber+1);
					else
					{
						int teacherNumber = Convert.ToInt32(getSerialNumber.Tables[0].Rows[0][1]);
						if ((++teacherNumber - 70) % 100 == 1)
							teacherNumber = teacherNumber + 30;
						tchBase.TNumber = teacherNumber.ToString();
					}
				}
			}
			else
				tchBase.TNumber = (firNumber + 1).ToString();

			if (Convert.ToInt32(tchBase.TNumber) > 9999)
				tchBase.TNumber = "-1";

			return tchBase.TNumber;
		}

		//��ѯ�û�ָ���Ĺ����Ƿ��Ѿ�����
		public bool hasSameNumber(string tcNumber,string tcID)
		{
			DataSet getSameNumber = teacherBaseDA.GetTcBaseInfo("","","",tcNumber);
			if ( getSameNumber.Tables[0].Rows.Count>0 )	
			{
				//�����޸���������
				if( getSameNumber.Tables[0].Rows[0][0].ToString().Equals(tcID) )
				{
					tchBase.TNumber = tcNumber;
					return true;
				}
				else
					return false;
			}
			else
			{
				tchBase.TNumber = tcNumber;
				return true;
			}
		}

		//changed version for ranging the teacher numbers from 01-69
		//9269 is the max number allowed
		public bool isValidTcNumber(string tcNumber)
		{
			string validNumberString = "0123456789";

			for( int i = 0;i < tcNumber.Length;i ++ )
			{
				if ( validNumberString.IndexOf(tcNumber.Substring(i,1)) < 0 )
					return false;
			}
			return true;
		}

		public bool hasCard(string tID,string tNumber)
		{
			if ( teacherBaseDA.HasCard(tID,tNumber) )
				return true;
			else
				return false;
		}

		public bool isValidTcPhone(string tcPhone)
		{
			string validNumberString = "0123456789";
			string regPhone = tcPhone;

			if(tcPhone.Equals(""))
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
					tchBase.TPhone = tcPhone;
					return true;			
				}		
			}
		}

		public bool isValidTcSex(string tcSex)
		{
			if ( !tcSex.Equals("") )
			{
				tchBase.TSex = tcSex;
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool isValidTcHomePhone(string tcHomePhone)
		{
			string validNumberString = "0123456789";

			if(tcHomePhone.Replace(" ","").Equals(""))
				return true;
			else
			{
				for( int i = 0;i < tcHomePhone.Length;i ++ )
				{
					if ( validNumberString.IndexOf(tcHomePhone.Substring(i,1)) < 0 )
						return false;
				}
				tchBase.THomeTel = tcHomePhone;
				return true;
			}
		}

		public bool isValidTcWorkPhone(string tcWorkPhone)
		{
			string validNumberString = "0123456789";
			bool validResult = true;

			if ( tcWorkPhone.Equals("") )
				return true;
			else
			{
				for( int i = 0;i < tcWorkPhone.Length;i ++ )
				{
					if ( validNumberString.IndexOf(tcWorkPhone.Substring(i,1)) < 0 )
						validResult = false;
				}
				if(validResult)
				{
					tchBase.TWorkTel = tcWorkPhone;
				}
				return validResult;
			}
		}


		public bool isValidTcTime(DateTime enterTime,DateTime joinTime)
		{
			if( !(enterTime.Date.ToString().Equals("") || joinTime.Date.ToString().Equals("")) )
			{
				if( enterTime < joinTime )
					return false;
				else
				{
					tchBase.TWorkTime = joinTime;
					tchBase.TEnterTime = enterTime;
					return true;
				}
			}
			else
				return false;
		}

		public bool isValidTcDeptDuty(string tcDept,string tcDuty)
		{
			if(tcDept.Replace(" ","").Equals("")||tcDuty.Replace(" ","").Equals(""))
			{
				return false;
			}
			else
			{
				tchBase.TDepart = tcDept;
				tchBase.TDuty = tcDuty;
				return true;
			}
		}
	}
}
