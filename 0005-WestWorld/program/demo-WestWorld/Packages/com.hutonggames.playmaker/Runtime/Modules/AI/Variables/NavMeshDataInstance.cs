
using System;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshDataInstance))]
	public sealed partial class NavMeshDataInstanceVariable : Variable<UnityEngine.AI.NavMeshDataInstance>
	{
		
		public NavMeshDataInstanceVariable()
		{
		}
		
		public NavMeshDataInstanceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshDataInstance))]
	public sealed partial class NavMeshDataInstanceListVariable : ListVariable<UnityEngine.AI.NavMeshDataInstance>
	{
		
		public NavMeshDataInstanceListVariable()
		{
		}
		
		public NavMeshDataInstanceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshDataInstance))]
	public sealed partial class NavMeshDataInstanceRef : VariableRef<UnityEngine.AI.NavMeshDataInstance>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshDataInstance))]
	public sealed partial class NavMeshDataInstanceVar : VariableVar<UnityEngine.AI.NavMeshDataInstance>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshDataInstance))]
	public sealed partial class NavMeshDataInstanceListRef : ListVariableRef<UnityEngine.AI.NavMeshDataInstance>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshDataInstance))]
	public sealed partial class NavMeshDataInstanceListVar : ListVariableVar<UnityEngine.AI.NavMeshDataInstance>
	{
	}
}
