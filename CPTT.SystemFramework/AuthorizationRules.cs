//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

using System;

namespace CPTT.SystemFramework
{
	/// <summary>
	/// AuthorizationRules 的摘要说明。
	/// </summary>
	public class AuthorizationRules
	{
		public const string GardenInfo = "GardenInfo Management";//园所信息管理

		public const string TeacherBaseInfo = "TeacherBaseInfo Management";//教师基本信息管理
		public const string TeacherDutyInfo = "TeacherDutyInfo Management";//教师出勤信息管理

		public const string StudentBaseInfo = "StudentBaseInfo Management";//学生基本信息管理
		public const string StudentMorningCheck = "StudentMorningCheckInfo Management";//学生晨检信息管理
		public const string StudentInTimeReport = "StudentInTimeReport Management";//学生实时统计信息
		public const string StudentHealthInfo = "StudentHealthInfo Management";//学生健康保健管理
		public const string StudentParentVisitInfo = "StudentParentVisitInfo Management";//学生家访信息管理

		public const string CardInfo = "CardInfo Management";//晨检卡管理
		public const string SimpleFinanceInfo = "SimpleFinanceInfo Management";//简单财务功能
		public const string SMSInfo = "SMSInfo Management";//短信功能
		public const string TransactionReminder = "Transaction Reminder";//事务提醒功能

		public AuthorizationRules()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
	}
}
