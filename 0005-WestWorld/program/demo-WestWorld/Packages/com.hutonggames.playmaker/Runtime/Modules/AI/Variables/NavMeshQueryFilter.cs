
using System;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshQueryFilter))]
	public sealed partial class NavMeshQueryFilterVariable : Variable<UnityEngine.AI.NavMeshQueryFilter>
	{
		
		public NavMeshQueryFilterVariable()
		{
		}
		
		public NavMeshQueryFilterVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshQueryFilter))]
	public sealed partial class NavMeshQueryFilterListVariable : ListVariable<UnityEngine.AI.NavMeshQueryFilter>
	{
		
		public NavMeshQueryFilterListVariable()
		{
		}
		
		public NavMeshQueryFilterListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshQueryFilter))]
	public sealed partial class NavMeshQueryFilterRef : VariableRef<UnityEngine.AI.NavMeshQueryFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshQueryFilter))]
	public sealed partial class NavMeshQueryFilterVar : VariableVar<UnityEngine.AI.NavMeshQueryFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshQueryFilter))]
	public sealed partial class NavMeshQueryFilterListRef : ListVariableRef<UnityEngine.AI.NavMeshQueryFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshQueryFilter))]
	public sealed partial class NavMeshQueryFilterListVar : ListVariableVar<UnityEngine.AI.NavMeshQueryFilter>
	{
	}
}
