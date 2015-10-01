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
using System.Data.SqlClient;

using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// TeacherBaseRule 的摘要说明。
	/// </summary>
	public class TeacherBaseRule
	{
		DataSet ds = new DataSet();
		public TeacherBaseRule()
		{			
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public int InsertTcBaseInfo(TeacherBase tcBase)
		{
			int rowsAffected = 0;

			using(TeacherBaseDataAccess tcBaseDA = new TeacherBaseDataAccess())
			{
				rowsAffected = tcBaseDA.InsertTcBaseInfo(tcBase);
			}
			
			return rowsAffected;
		}

		public int UpdateTcBaseInfo(TeacherBase tcBase)
		{
			int rowsAffected = 0;

			using(TeacherBaseDataAccess tcBaseDA = new TeacherBaseDataAccess())
			{
				rowsAffected = tcBaseDA.UpdateTcBaseInfo(tcBase);
			}

			return rowsAffected;
		}

		public int DeleteTcBaseInfo(string tID)
		{
			int rowsAffected = 0;

			using(TeacherBaseDataAccess tcBaseDA = new TeacherBaseDataAccess())
			{
				rowsAffected = tcBaseDA.DeleteTcBaseInfo(tID);
			}

			return rowsAffected;
		}

		public DataSet SearchTcBaseInfoByCondition(string gradeName,string className,string tcName,string tcNumber)
		{
			DataSet tcBaseList = null;
			if(gradeName.Equals("全部")){gradeName = "";}
			if(className.Equals("全部")){className = "";}

			if(tcNumber == "")
			{
				if(tcName == "")
				{
					tcBaseList = new TeacherBaseDataAccess().GetTcBaseInfo(gradeName,className,"","");
				}
				else
				{
					tcBaseList = new TeacherBaseDataAccess().GetTcBaseInfo("","",tcName,"");
				}
			}
			else
			{
				tcBaseList = new TeacherBaseDataAccess().GetTcBaseInfo("","","",tcNumber);
			}

			return tcBaseList;
		}
	}
}
