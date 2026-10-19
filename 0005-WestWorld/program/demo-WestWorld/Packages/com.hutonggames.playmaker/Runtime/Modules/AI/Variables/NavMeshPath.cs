
using System;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshPath))]
	public sealed partial class NavMeshPathVariable : Variable<UnityEngine.AI.NavMeshPath>
	{
		
		public NavMeshPathVariable()
		{
		}
		
		public NavMeshPathVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshPath))]
	public sealed partial class NavMeshPathListVariable : ListVariable<UnityEngine.AI.NavMeshPath>
	{
		
		public NavMeshPathListVariable()
		{
		}
		
		public NavMeshPathListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshPath))]
	public sealed partial class NavMeshPathRef : VariableRef<UnityEngine.AI.NavMeshPath>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshPath))]
	[Obsolete("NavMeshPathVar is not supported because NavMeshPath has no constant value field. Use NavMeshPathRef instead.", true)]
	public sealed partial class NavMeshPathVar : VariableVar<UnityEngine.AI.NavMeshPath>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshPath))]
	public sealed partial class NavMeshPathListRef : ListVariableRef<UnityEngine.AI.NavMeshPath>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshPath))]
	public sealed partial class NavMeshPathListVar : ListVariableVar<UnityEngine.AI.NavMeshPath>
	{
	}
}
