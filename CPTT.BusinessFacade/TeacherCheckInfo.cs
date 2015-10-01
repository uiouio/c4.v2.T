//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

using System;
using System.Data;
using CPTT.SystemFramework;
using CPTT.DataAccess;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// TeacherCheckInfo 的摘要说明。
	/// </summary>
	public class TeacherCheckInfo
	{		
		TeacherBaseDataAccess teacherBaseDA = new TeacherBaseDataAccess();
		private TeacherBase tchBase;
		private bool isNextRanger = false;
		public TeacherCheckInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
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

		//查询连续的工号
		//9570 is the max number allowed
		public string getSerialTcNumber()
		{
			//获取所有工号
			DataSet getSerialNumber = teacherBaseDA.GetTcBaseList();
			
			//初始化第一个工号为00号
			int firNumber = 9100;

			//当前教师数不为零
			if ( getSerialNumber.Tables[0].Rows.Count != 0)
			{
				//当前教师数量为1名以上情况
				if ( getSerialNumber.Tables[0].Rows.Count > 1 )
				{
					//循环查询找出两个工号不相邻的情况
					for(int i = 0; i < getSerialNumber.Tables[0].Rows.Count; i++)
					{
						int teacherNumber = Convert.ToInt32(getSerialNumber.Tables[0].Rows[i][1]);
						//已经是最后一个，当前值+1，10位数和个位数相加最多只能70
						if (i == getSerialNumber.Tables[0].Rows.Count - 1)
						{
							if ((++teacherNumber - 70) % 100 == 1)
								teacherNumber = teacherNumber + 30; //跳到下一轮
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
				//只有一名教师的情况
				else
				{
					//如果01号教师没有被使用，则赋予该教师为01号
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

		//查询用户指定的工号是否已经存在
		public bool hasSameNumber(string tcNumber,string tcID)
		{
			DataSet getSameNumber = teacherBaseDA.GetTcBaseInfo("","","",tcNumber);
			if ( getSameNumber.Tables[0].Rows.Count>0 )	
			{
				//允许修改自身数据
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
