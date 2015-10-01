using System;
using System.Data;

using CPTT.DataAccess;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// FlowStateSystem 的摘要说明。
	/// </summary>
	public class FlowStateSystem
	{
		public FlowStateSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataSet GetStuState()
		{
			using(FlowStatesDataAccess flowStatesDA = new FlowStatesDataAccess())
			{
				return flowStatesDA.GetStuState();
			}
		}

		public void UpdateStuState(Int16 stateID,string stateName)
		{
			using(FlowStatesDataAccess flowStatesDA = new FlowStatesDataAccess())
			{
				flowStatesDA.UpdateStuState(stateID,stateName);
			}
		}

		public DataSet GetTeaState()
		{
			using(FlowStatesDataAccess flowStatesDA = new FlowStatesDataAccess())
			{
				return flowStatesDA.GetTeaState();
			}
		}

		public void UpdateTeaState(Int16 stateID,string stateName)
		{
			using(FlowStatesDataAccess flowStatesDA = new FlowStatesDataAccess())
			{
				flowStatesDA.UpdateTeaState(stateID,stateName);
			}
		}

		public void ClearFlowState(int type)
		{
			using(FlowStatesDataAccess flowStatesDA = new FlowStatesDataAccess())
			{
				flowStatesDA.ClearFlowState(type);
			}
		}
	}
}
