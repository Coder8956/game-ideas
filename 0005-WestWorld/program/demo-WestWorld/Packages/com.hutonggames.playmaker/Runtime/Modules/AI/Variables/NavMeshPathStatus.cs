
using System;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshPathStatus))]
	public sealed partial class NavMeshPathStatusVariable : Variable<UnityEngine.AI.NavMeshPathStatus>
	{
		
		public NavMeshPathStatusVariable()
		{
		}
		
		public NavMeshPathStatusVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshPathStatus))]
	public sealed partial class NavMeshPathStatusListVariable : ListVariable<UnityEngine.AI.NavMeshPathStatus>
	{
		
		public NavMeshPathStatusListVariable()
		{
		}
		
		public NavMeshPathStatusListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshPathStatus))]
	public sealed partial class NavMeshPathStatusRef : VariableRef<UnityEngine.AI.NavMeshPathStatus>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshPathStatus))]
	public sealed partial class NavMeshPathStatusVar : VariableVar<UnityEngine.AI.NavMeshPathStatus>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshPathStatus))]
	public sealed partial class NavMeshPathStatusListRef : ListVariableRef<UnityEngine.AI.NavMeshPathStatus>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshPathStatus))]
	public sealed partial class NavMeshPathStatusListVar : ListVariableVar<UnityEngine.AI.NavMeshPathStatus>
	{
	}
}
