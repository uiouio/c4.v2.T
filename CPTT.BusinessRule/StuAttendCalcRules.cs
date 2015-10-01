using System;
using CPTT.DataAccess;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// StuAttendCalcRules 的摘要说明。
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
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		//获取用户选定的起始时间
		public DateTime BegDate
		{
			get{ return this.getBegDate; }
			set{ this.getBegDate = value; }
		}

		//获取用户截止时间
		public DateTime EndDate
		{
			get{ return this.getEndDate; }
			set{ this.getEndDate = value; }
		}	

		//获取指定时间内的晨检状态数
		public int StateAmountInDays
		{
			get{ return this.getStateAmountInDays; }
			set{ this.getStateAmountInDays = value; }
		}

		//获取指定时间内学生总数
		public int StuAttendAmountInDays
		{
			get{ return this.getStuAttendAmountInDays; }
			set{ this.getStuAttendAmountInDays = value; }
		}

		//获取指定时间内所有状态的总和
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

		//设置指定时间内的出勤天数
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
				//休息日
				int restingDays = 0;

				//当月日数
				int dayNumbers = Convert.ToInt32(dateDiff.Substring(0,dateDiff.IndexOf(".",0)))+1;
 
				for ( int i=0; i<dayNumbers; i++ )
				{
					//五一和十一
					if (initBegDate.AddDays(i).Month == 10)
					{
						for( int dayOfMonth = 1;dayOfMonth <= 3;dayOfMonth ++ )
						{
							if ( initBegDate.AddDays(i).Day == dayOfMonth )
								restingDays ++;
						}
					}

					//5.1 元旦
					if ((initBegDate.AddDays(i).Month == 1 ||  initBegDate.AddDays(i).Month == 5) && initBegDate.AddDays(i).Day == 1)
						restingDays ++;

					//双修日
					if ( initBegDate.AddDays(i).DayOfWeek.ToString().Equals("Saturday") || 
						initBegDate.AddDays(i).DayOfWeek.ToString().Equals("Sunday") )
						restingDays ++;
				}
				return dayNumbers - restingDays;
			}*/
		}

		//返回健康总数及百分比
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

		//返回服药总数及百分比
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

		//返回观察总数及百分比
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

		//返回缺席总数及百分比
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

		//返回应出勤总数
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

		//返回用户选定的总天数
		public string SetDayAmount()
		{
			return SetAttendDays().ToString();
		}

		//返回已接走总数
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

		//返回未接走总数
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

		//返回应接走总数
		public string ShouldGo()
		{
			return AllStateAmountInDays.ToString();
		}

		//DataAccess的数据访问
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
