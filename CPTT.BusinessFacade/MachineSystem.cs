using System;
using System.Data;
using CPTT.SystemFramework;
using CPTT.BusinessRule;
using CPTT.DataAccess;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// MachineSystem 的摘要说明。
	/// </summary>
	public class MachineSystem
	{
		public MachineSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataSet GetMachineAddrList()
		{
			using(MachinesDA machineDA = new MachinesDA())
			{
				return machineDA.GetMachineAddrList();
			}
		}

		public int CreateClassMachine()
		{
			using(MachinesDA machineDA = new MachinesDA())
			{
				return machineDA.CreateClassMachine();
			}
		}

		public DataSet GetClassMachineAddrList()
		{
			using(MachinesDA machineDA = new MachinesDA())
			{
				return machineDA.GetClassMachineAddrList();
			}
		}

		public int DeleteMachine(int deleteMachineAddr)
		{
			using(MachinesDA machineDA = new MachinesDA())
			{
				return machineDA.DeleteMachine(deleteMachineAddr);
			}
		}

		public int InsertMachine(int machineAddr)
		{
			using(MachinesDA machineDA = new MachinesDA())
			{
				return machineDA.InsertMachine(machineAddr);
			}
		}

		public int InsertClassMachine(int machineAddr,int machineVolumn)
		{
			using(MachinesDA machineDA = new MachinesDA())
			{
				return machineDA.InsertClassMachine(machineAddr,machineVolumn);
			}
		}

		public int UpdateMachine(int deleteOldMachineAddr,int deleteNewMachineAddr)
		{
			using(MachinesDA machineDA = new MachinesDA())
			{
				return machineDA.UpdateMachine(deleteOldMachineAddr,deleteNewMachineAddr);
			}
		}
	}
}
