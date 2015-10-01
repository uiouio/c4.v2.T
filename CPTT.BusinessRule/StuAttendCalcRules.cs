using System;
using CPTT.DataAccess;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// StuAttendCalcRules ��ժҪ˵����
	/// </summary>
	public class StuAttendCalcRules
	{
		private int getStateAmountInDays;
		private int getStuAttendAmountInDays;
		private int getAllStateAmountInDays;
		private DateTime getBegDate;
		private DateTime getEndDate;
		private int getHasGone;
		private int getHasnotGone;

		public StuAttendCalcRules()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		
		//��ȡ�û�ѡ������ʼʱ��
		public DateTime BegDate
		{
			get{ return this.getBegDate; }
			set{ this.getBegDate = value; }
		}

		//��ȡ�û���ֹʱ��
		public DateTime EndDate
		{
			get{ return this.getEndDate; }
			set{ this.getEndDate = value; }
		}	

		//��ȡָ��ʱ���ڵĳ���״̬��
		public int StateAmountInDays
		{
			get{ return this.getStateAmountInDays; }
			set{ this.getStateAmountInDays = value; }
		}

		//��ȡָ��ʱ����ѧ������
		public int StuAttendAmountInDays
		{
			get{ return this.getStuAttendAmountInDays; }
			set{ this.getStuAttendAmountInDays = value; }
		}

		//��ȡָ��ʱ��������״̬���ܺ�
		public int AllStateAmountInDays
		{
			get{ return this.getAllStateAmountInDays; }
			set{ this.getAllStateAmountInDays = value; }
		}

		public int HasGoneNumber
		{
			get { return this.getHasGone; }
			set { this.getHasGone = value; }
		}

		public int HasnotGoneNumber
		{
			get { return this.getHasnotGone; }
			set { this.getHasnotGone = value; }
		}

		//����ָ��ʱ���ڵĳ�������
		private int SetAttendDays()
		{
			return new UtilDataAccess().GetAttendDays(BegDate, EndDate);

			/*
			string dateDiff = (EndDate.Date - BegDate.Date).ToString();
			DateTime initBegDate = BegDate;
			
			if( EndDate.Date == BegDate.Date )
				return 1;
			else
			{
				//��Ϣ��
				int restingDays = 0;

				//��������
				int dayNumbers = Convert.ToInt32(dateDiff.Substring(0,dateDiff.IndexOf(".",0)))+1;
 
				for ( int i=0; i<dayNumbers; i++ )
				{
					//��һ��ʮһ
					if (initBegDate.AddDays(i).Month == 10)
					{
						for( int dayOfMonth = 1;dayOfMonth <= 3;dayOfMonth ++ )
						{
							if ( initBegDate.AddDays(i).Day == dayOfMonth )
								restingDays ++;
						}
					}

					//5.1 Ԫ��
					if ((initBegDate.AddDays(i).Month == 1 ||  initBegDate.AddDays(i).Month == 5) && initBegDate.AddDays(i).Day == 1)
						restingDays ++;

					//˫����
					if ( initBegDate.AddDays(i).DayOfWeek.ToString().Equals("Saturday") || 
						initBegDate.AddDays(i).DayOfWeek.ToString().Equals("Sunday") )
						restingDays ++;
				}
				return dayNumbers - restingDays;
			}*/
		}

		//���ؽ����������ٷֱ�
		public string SetHealthAttend(bool isForClass)
		{
			string retval = "0";
			if (StuAttendAmountInDays > 0)
			{
				if ( isForClass )
				{
					retval = StateAmountInDays.ToString()+"  ("+
						((float)StateAmountInDays/(float)StuAttendAmountInDays).ToString("0.00%")+")";
				}
				else
				{

					retval = StateAmountInDays.ToString()+"  ("+
						((float)StateAmountInDays/(float)StuAttendAmountInDays).ToString("0.00%")+")";
				}
			}
			return retval;
		}

		//���ط�ҩ�������ٷֱ�
		public string SetIllAttend(bool isForClass)
		{
			string retval = "0";
			if (StuAttendAmountInDays > 0)
			{
				if ( isForClass )
				{
					retval = StateAmountInDays.ToString()+"  ("+
						((float)StateAmountInDays/(float)StuAttendAmountInDays).ToString("0.00%")+")";
				}
				else
				{
					retval = StateAmountInDays.ToString()+"  ("+
						((float)StateAmountInDays/(float)StuAttendAmountInDays).ToString("0.00%")+")";
				}
			}
			return retval;
		}

		//���ع۲��������ٷֱ�
		public string SetWatchAttend(bool isForClass)
		{
			string retval = "0";
			if (StuAttendAmountInDays > 0)
			{
				if ( isForClass )
				{
					retval =  StateAmountInDays.ToString()+"  ("+
						((float)StateAmountInDays/(float)StuAttendAmountInDays).ToString("0.00%")+")";
				}
				else
				{
					retval = StateAmountInDays.ToString()+"  ("+
						((float)StateAmountInDays/(float)StuAttendAmountInDays).ToString("0.00%")+")";
				}
			}
			return retval;
		}

		public string SetHaveAttended(bool isForClass)
		{
			string retval = "0";
			if (StuAttendAmountInDays > 0)
			{
				if ( isForClass )
					retval = AllStateAmountInDays.ToString()+ "  ("+
						((float)AllStateAmountInDays/(float)StuAttendAmountInDays).ToString("0.00%")+")";
				else
					retval = AllStateAmountInDays.ToString()+ "  ("+
						((float)AllStateAmountInDays/(float)StuAttendAmountInDays).ToString("0.00%")+")";
			}
			return retval;
		}

		//����ȱϯ�������ٷֱ�
		public string SetAbsence(bool isForClass)
		{
			string retval = "0";
			if (StuAttendAmountInDays > 0)
			{
				if ( isForClass )
				{
					retval = (StuAttendAmountInDays-AllStateAmountInDays).
						ToString()+"  ("+(1-(float)AllStateAmountInDays/(float)StuAttendAmountInDays).ToString("0.00%")+")";
				}
				else
				{
					retval = (StuAttendAmountInDays-AllStateAmountInDays).ToString()+"  ("+
						(1-(float)AllStateAmountInDays/(float)StuAttendAmountInDays).ToString("0.00%")+")";
				}
			}
			return retval;
		}

		//����Ӧ��������
		public string SetShouldAttend(bool isForClass)
		{
			if ( isForClass )
			{
				return StuAttendAmountInDays.ToString();
			}
			else
			{
				return StuAttendAmountInDays.ToString();
			}
		}

		//�����û�ѡ����������
		public string SetDayAmount()
		{
			return SetAttendDays().ToString();
		}

		//�����ѽ�������
		public string HasGone()
		{
			string retval = "0";
			if (AllStateAmountInDays > 0)
			{
				retval = HasGoneNumber.ToString() + "  (" +
					((float)HasGoneNumber/(float)AllStateAmountInDays).ToString("0.00%") + ")";
			}
			return retval;
		}

		//����δ��������
		public string HasnotGone()
		{
			string retval = "0";
			if (AllStateAmountInDays > 0)
			{
				retval = HasnotGoneNumber.ToString() + "  (" +
					((float)HasnotGoneNumber/(float)AllStateAmountInDays).ToString("0.00%") + ")";
			}
			return retval;
		}

		//����Ӧ��������
		public string ShouldGo()
		{
			return AllStateAmountInDays.ToString();
		}

		//DataAccess�����ݷ���
		public void SetStuAttendCalcForClass(string getGrade,string getClass,string getBegTime,
			string getEndTime,string getState)
		{
			BegDate = Convert.ToDateTime(getBegTime);
			EndDate = Convert.ToDateTime(getEndTime);
			using (StudentAttendCalcDataAccess stuAttendCalcDataAccess = new StudentAttendCalcDataAccess())
			{
				stuAttendCalcDataAccess.DoAttendCalcForClass(getGrade,getClass,getBegTime,getEndTime,getState);
				StateAmountInDays = stuAttendCalcDataAccess.StateAmount;
				AllStateAmountInDays = stuAttendCalcDataAccess.AllStateAmount;
				StuAttendAmountInDays = stuAttendCalcDataAccess.StuAmount * SetAttendDays();
			}
		}

		public void SetStuAttendCalcForSolo(string getName,string getNumber,string getBegTime,
			string getEndTime,string getState)
		{
			BegDate = Convert.ToDateTime(getBegTime);
			EndDate = Convert.ToDateTime(getEndTime);
			using (StudentAttendCalcDataAccess stuAttendCalcDataAccess = new StudentAttendCalcDataAccess())
			{
				stuAttendCalcDataAccess.DoAttendCalcForSolo(getName,getNumber,getBegTime,getEndTime,getState);
				StateAmountInDays = stuAttendCalcDataAccess.StateAmount;
				AllStateAmountInDays = stuAttendCalcDataAccess.AllStateAmount;
				StuAttendAmountInDays = stuAttendCalcDataAccess.StuAmount * SetAttendDays();
			}
		}

		public void SetStuBackCalc(string getGrade,string getClass,string getName,string getNumber,string getBegTime,
			string getEndTime)
		{
			BegDate = Convert.ToDateTime(getBegTime);
			EndDate = Convert.ToDateTime(getEndTime);
			using ( StudentAttendCalcDataAccess stuAttendCalcDataAccess = new StudentAttendCalcDataAccess() )
			{
				stuAttendCalcDataAccess.DoBackCalc(getGrade,getClass,getName,getNumber,getBegTime,getEndTime);
				HasGoneNumber = stuAttendCalcDataAccess.HasGone;
				HasnotGoneNumber = stuAttendCalcDataAccess.HasnotGone;
				AllStateAmountInDays = stuAttendCalcDataAccess.AllStateAmount;
			}
		}

	}
}
