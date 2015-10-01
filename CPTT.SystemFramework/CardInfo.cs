using System;

namespace CPTT.SystemFramework
{
	/// <summary>
	/// CardInfo 的摘要说明。
	/// </summary>
	public class CardInfo
	{
		private string stuID;
		private string cardNumber;
		private string cardHolder;
		private DateTime cardSendDate;
		private bool cardState;
		private Int16 cardSequence;

		public CardInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public string StuID
		{
			get{return this.stuID;}
			set{this.stuID = value;}
		}

		public string CardNumber
		{
			get{return this.cardNumber;}
			set{this.cardNumber = value;}
		}

		public string CardHolder
		{
			get{return this.cardHolder;}
			set{this.cardHolder = value;}
		}

		public DateTime CardSendDate
		{
			get{return this.cardSendDate;}
			set{this.cardSendDate = value;}
		}

		public bool CardState
		{
			get{return this.cardState;}
			set{this.cardState = value;}
		}

		public Int16 CardSequence
		{
			get{return this.cardSequence;}
			set{this.cardSequence = value;}
		}
	}
}
