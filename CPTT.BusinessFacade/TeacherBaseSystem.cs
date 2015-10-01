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

using CPTT.BusinessRule;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// TeacherBaseSystem ��ժҪ˵����
	/// </summary>
	public class TeacherBaseSystem
	{
		public TeacherBaseSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
