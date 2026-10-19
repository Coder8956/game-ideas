
using System;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshLinkInstance))]
	public sealed partial class NavMeshLinkInstanceVariable : Variable<UnityEngine.AI.NavMeshLinkInstance>
	{
		
		public NavMeshLinkInstanceVariable()
		{
		}
		
		public NavMeshLinkInstanceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshLinkInstance))]
	public sealed partial class NavMeshLinkInstanceListVariable : ListVariable<UnityEngine.AI.NavMeshLinkInstance>
	{
		
		public NavMeshLinkInstanceListVariable()
		{
		}
		
		public NavMeshLinkInstanceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshLinkInstance))]
	public sealed partial class NavMeshLinkInstanceRef : VariableRef<UnityEngine.AI.NavMeshLinkInstance>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshLinkInstance))]
	public sealed partial class NavMeshLinkInstanceVar : VariableVar<UnityEngine.AI.NavMeshLinkInstance>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshLinkInstance))]
	public sealed partial class NavMeshLinkInstanceListRef : ListVariableRef<UnityEngine.AI.NavMeshLinkInstance>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshLinkInstance))]
	public sealed partial class NavMeshLinkInstanceListVar : ListVariableVar<UnityEngine.AI.NavMeshLinkInstance>
	{
	}
}
