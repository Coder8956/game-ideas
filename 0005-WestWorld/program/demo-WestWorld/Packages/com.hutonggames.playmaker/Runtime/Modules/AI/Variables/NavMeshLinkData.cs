
using System;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshLinkData))]
	public sealed partial class NavMeshLinkDataVariable : Variable<UnityEngine.AI.NavMeshLinkData>
	{
		
		public NavMeshLinkDataVariable()
		{
		}
		
		public NavMeshLinkDataVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshLinkData))]
	public sealed partial class NavMeshLinkDataListVariable : ListVariable<UnityEngine.AI.NavMeshLinkData>
	{
		
		public NavMeshLinkDataListVariable()
		{
		}
		
		public NavMeshLinkDataListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshLinkData))]
	public sealed partial class NavMeshLinkDataRef : VariableRef<UnityEngine.AI.NavMeshLinkData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshLinkData))]
	public sealed partial class NavMeshLinkDataVar : VariableVar<UnityEngine.AI.NavMeshLinkData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshLinkData))]
	public sealed partial class NavMeshLinkDataListRef : ListVariableRef<UnityEngine.AI.NavMeshLinkData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshLinkData))]
	public sealed partial class NavMeshLinkDataListVar : ListVariableVar<UnityEngine.AI.NavMeshLinkData>
	{
	}
}
