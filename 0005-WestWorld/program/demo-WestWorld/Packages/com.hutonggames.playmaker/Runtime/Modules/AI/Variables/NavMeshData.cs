
using System;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshData))]
	public sealed partial class NavMeshDataVariable : Variable<UnityEngine.AI.NavMeshData>
	{
		
		public NavMeshDataVariable()
		{
		}
		
		public NavMeshDataVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshData))]
	public sealed partial class NavMeshDataListVariable : ListVariable<UnityEngine.AI.NavMeshData>
	{
		
		public NavMeshDataListVariable()
		{
		}
		
		public NavMeshDataListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshData))]
	public sealed partial class NavMeshDataRef : VariableRef<UnityEngine.AI.NavMeshData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshData))]
	public sealed partial class NavMeshDataVar : VariableVar<UnityEngine.AI.NavMeshData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshData))]
	public sealed partial class NavMeshDataListRef : ListVariableRef<UnityEngine.AI.NavMeshData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshData))]
	public sealed partial class NavMeshDataListVar : ListVariableVar<UnityEngine.AI.NavMeshData>
	{
	}
}
