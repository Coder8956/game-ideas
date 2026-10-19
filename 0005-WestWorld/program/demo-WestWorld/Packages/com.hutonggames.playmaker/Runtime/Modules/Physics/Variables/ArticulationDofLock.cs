
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDofLock))]
	public sealed partial class ArticulationDofLockVariable : Variable<UnityEngine.ArticulationDofLock>
	{
		
		public ArticulationDofLockVariable()
		{
		}
		
		public ArticulationDofLockVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDofLock))]
	public sealed partial class ArticulationDofLockListVariable : ListVariable<UnityEngine.ArticulationDofLock>
	{
		
		public ArticulationDofLockListVariable()
		{
		}
		
		public ArticulationDofLockListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDofLock))]
	public sealed partial class ArticulationDofLockRef : VariableRef<UnityEngine.ArticulationDofLock>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDofLock))]
	public sealed partial class ArticulationDofLockVar : VariableVar<UnityEngine.ArticulationDofLock>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDofLock))]
	public sealed partial class ArticulationDofLockListRef : ListVariableRef<UnityEngine.ArticulationDofLock>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDofLock))]
	public sealed partial class ArticulationDofLockListVar : ListVariableVar<UnityEngine.ArticulationDofLock>
	{
	}
}
