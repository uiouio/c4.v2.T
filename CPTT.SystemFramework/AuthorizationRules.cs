//==================================================================================
// �������ܳ����������ϵͳ4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//������������ܰ�Ȩ���͹�����Լ����.
// ��δ����Ȩ�����Ը��ƻ򴫲�������(�������κβ���),���ܵ����������¼������Ʋ�,
//�����ڷ�����ɵķ�Χ���ܵ����̶ȵ�����!
//==================================================================================

using System;

namespace CPTT.SystemFramework
{
	/// <summary>
	/// AuthorizationRules ��ժҪ˵����
	/// </summary>
	public class AuthorizationRules
	{
		public const string GardenInfo = "GardenInfo Management";//԰����Ϣ����

		public const string TeacherBaseInfo = "TeacherBaseInfo Management";//��ʦ������Ϣ����
		public const string TeacherDutyInfo = "TeacherDutyInfo Management";//��ʦ������Ϣ����

		public const string StudentBaseInfo = "StudentBaseInfo Management";//ѧ��������Ϣ����
		public const string StudentMorningCheck = "StudentMorningCheckInfo Management";//ѧ��������Ϣ����
		public const string StudentInTimeReport = "StudentInTimeReport Management";//ѧ��ʵʱͳ����Ϣ
		public const string StudentHealthInfo = "StudentHealthInfo Management";//ѧ��������������
		public const string StudentParentVisitInfo = "StudentParentVisitInfo Management";//ѧ���ҷ���Ϣ����

		public const string CardInfo = "CardInfo Management";//���쿨����
		public const string SimpleFinanceInfo = "SimpleFinanceInfo Management";//�򵥲�����
		public const string SMSInfo = "SMSInfo Management";//���Ź���
		public const string TransactionReminder = "Transaction Reminder";//�������ѹ���

		public AuthorizationRules()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
	}
}
