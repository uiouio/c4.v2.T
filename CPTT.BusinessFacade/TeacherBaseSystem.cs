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

using CPTT.BusinessRule;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// TeacherBaseSystem 的摘要说明。
	/// </summary>
	public class TeacherBaseSystem
	{
		public TeacherBaseSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataSet GetTcBaseList()
		{
			DataSet tcBaseInfoList;

			using (TeacherBaseDataAccess tcBaseDA = new TeacherBaseDataAccess())
			{
				tcBaseInfoList = tcBaseDA.GetTcBaseList();
			}
			
			return tcBaseInfoList;
		}

		public DataSet GetTcBase(string tID)
		{
			DataSet tcBaseInfoList;

			using (TeacherBaseDataAccess tcBaseDA = new TeacherBaseDataAccess())
			{
				tcBaseInfoList = tcBaseDA.GetTcBaseInfo(tID);
			}
			
			return tcBaseInfoList;
		}

		public DataSet SearchTcBaseInfoByCondition(string gradeName,string className,string tcName,string tcNumber)
		{
			DataSet tcBaseInfoList;
			
			tcBaseInfoList = new TeacherBaseRule().SearchTcBaseInfoByCondition(gradeName,className,tcName,tcNumber);

			return tcBaseInfoList;
		}

		public int InsertTcBaseInfo(TeacherBase tcBase)
		{
			return new TeacherBaseRule().InsertTcBaseInfo(tcBase);
		}

		public int UpdateTcBaseInfo(TeacherBase tcBase)
		{
			return new TeacherBaseRule().UpdateTcBaseInfo(tcBase);
		}

		public int DeleteTcBaseInfo(string tID)
		{
			return new TeacherBaseRule().DeleteTcBaseInfo(tID);
		}
	}
}
