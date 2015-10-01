using System;
using System.Data;
using CPTT.SystemFramework;
using CPTT.BusinessRule;
using CPTT.DataAccess;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// CardInfoSystem 的摘要说明。
	/// </summary>
	public class CardInfoSystem
	{
		public CardInfoSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public int InsertCardInfo(CardInfo card)
		{
			int rowAffected = 0;

			using(CardInfoDA cardInfoDA = new CardInfoDA())
			{
				rowAffected = cardInfoDA.InsertCardInfo(card);
			}

			return rowAffected;
		}

		public int InsertTeaCardInfo(CardInfo card)
		{
			int rowAffected = 0;

			using(CardInfoDA cardInfoDA = new CardInfoDA())
			{
				rowAffected = cardInfoDA.InsertTeaCardInfo(card);
			}

			return rowAffected;
		}

		public int DeleteCardInfo(string cardNumber)
		{
			int rowAffected = 0;

			using(CardInfoDA cardInfoDA = new CardInfoDA())
			{
				rowAffected = cardInfoDA.DeleteCardInfo(cardNumber);
			}

			return rowAffected;
		}

		public int DeleteTeaCardInfo(string cardNumber)
		{
			int rowAffected = 0;

			using(CardInfoDA cardInfoDA = new CardInfoDA())
			{
				rowAffected = cardInfoDA.DeleteTeaCardInfo(cardNumber);
			}

			return rowAffected;
		}

		public int UpdateCardState(string cardNumber)
		{
			int rowAffected = 0;

			using(CardInfoDA cardInfoDA = new CardInfoDA())
			{
				rowAffected = cardInfoDA.UpdateCardState(cardNumber);
			}

			return rowAffected;
		}

		public int UpdateTeaCardState(string cardNumber)
		{
			int rowAffected = 0;

			using(CardInfoDA cardInfoDA = new CardInfoDA())
			{
				rowAffected = cardInfoDA.UpdateTeaCardState(cardNumber);
			}

			return rowAffected;
		}

		//退学
		public int StuLeaveSchool(string id)
		{
			int rowAffected = 0;

			using(CardInfoDA cardInfoDA = new CardInfoDA())
			{
				rowAffected = cardInfoDA.StuLeaveSchool(id);
			}

			return rowAffected;
		}

		public int TeaLeaveSchool(string id)
		{
			int rowAffected = 0;

			using(CardInfoDA cardInfoDA = new CardInfoDA())
			{
				rowAffected = cardInfoDA.TeaLeaveSchool(id);
			}

			return rowAffected;
		}

		public int GetCardCount(string cardNumber)
		{
			int rowAffected = 0;

			using(CardInfoDA cardInfoDA = new CardInfoDA())
			{
				rowAffected = cardInfoDA.GetCardCount(cardNumber);
			}

			return rowAffected;
		}

		public DataSet GetStuCardInfoList()
		{
			DataSet CardInfoList = null;

			using(CardInfoDA cardInfoDA = new CardInfoDA())
			{
				CardInfoList = cardInfoDA.GetStuCardInfoList();
			}

			return CardInfoList;
		}

		public DataSet GetTeaCardInfoList()
		{
			DataSet CardInfoList = null;

			using(CardInfoDA cardInfoDA = new CardInfoDA())
			{
				CardInfoList = cardInfoDA.GetTeaCardInfoList();
			}

			return CardInfoList;
		}

		public DataSet GetBatchCardInfo()
		{
			DataSet batchCardInfoList = null;

			using(CardInfoDA cardInfoDA = new CardInfoDA())
			{
				batchCardInfoList = cardInfoDA.GetBatchCardInfo();
			}

			return batchCardInfoList;
		}

		public DataSet GetNoCardStudents()
		{
			DataSet noCardStudents = null;

			using ( CardInfoDA cardInfoDA = new CardInfoDA() )
			{
				noCardStudents = cardInfoDA.GetNoCardStudents();
			}

			return noCardStudents;
		}

		public DataSet GetNoCardTeachers()
		{
			DataSet noCardTeachers = null;

			using ( CardInfoDA cardInfoDA = new CardInfoDA() )
			{
				noCardTeachers = cardInfoDA.GetNoCardTeachers();
			}

			return noCardTeachers;
		}

		public DataSet GetTeaBatchCardInfo()
		{
			DataSet batchCardInfoList = null;

			using(CardInfoDA cardInfoDA = new CardInfoDA())
			{
				batchCardInfoList = cardInfoDA.GetTeaBatchCardInfo();
			}

			return batchCardInfoList;
		}

		public DataSet GetStuCardByID(string stuID)
		{
			DataSet CardInfoList = null;

			using(CardInfoDA cardInfoDA = new CardInfoDA())
			{
				CardInfoList = cardInfoDA.GetStuCardByID(stuID);
			}

			return CardInfoList;
		}

		public DataSet GetTeaCardByID(string teaID)
		{
			DataSet CardInfoList = null;

			using(CardInfoDA cardInfoDA = new CardInfoDA())
			{
				CardInfoList = cardInfoDA.GetTeaCardByID(teaID);
			}

			return CardInfoList;
		}

		public void ImportCardExcelFile(string name,string id,string grade,
			string atClass,bool isStu,string savePath)
		{
			new CardInfoRule().ImportCardExcelFile(name,id,grade,atClass,isStu,savePath);
		}

		public void DeleteCardInfo(bool isForStudent,string id)
		{
			using ( CardInfoDA cardInfoDA = new CardInfoDA() )
			{
				cardInfoDA.DeleteCardInfo(isForStudent,id);
			}
		}

		public void WriteCardInfoExcel(string savePath)
		{
			using ( CardInfoDA cardInfoDA = new CardInfoDA() )
			{
				new CardInfoRule().WriteCardInfoExcel(cardInfoDA.GetExportCard(),savePath);
//				new CardInfoRule().WriteCardInfoExcel(cardInfoDA.GetAllCardInfo(),savePath);
			}
		}

		public string GetNumberByCard(string card)
		{
			return new CardInfoDA().GetNumberByCard(card);
		}
	}
}
