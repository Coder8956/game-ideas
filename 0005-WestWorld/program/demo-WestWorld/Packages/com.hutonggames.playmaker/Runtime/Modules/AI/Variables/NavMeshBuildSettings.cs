
using System;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshBuildSettings))]
	public sealed partial class NavMeshBuildSettingsVariable : Variable<UnityEngine.AI.NavMeshBuildSettings>
	{
		
		public NavMeshBuildSettingsVariable()
		{
		}
		
		public NavMeshBuildSettingsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshBuildSettings))]
	public sealed partial class NavMeshBuildSettingsListVariable : ListVariable<UnityEngine.AI.NavMeshBuildSettings>
	{
		
		public NavMeshBuildSettingsListVariable()
		{
		}
		
		public NavMeshBuildSettingsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshBuildSettings))]
	public sealed partial class NavMeshBuildSettingsRef : VariableRef<UnityEngine.AI.NavMeshBuildSettings>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshBuildSettings))]
	public sealed partial class NavMeshBuildSettingsVar : VariableVar<UnityEngine.AI.NavMeshBuildSettings>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshBuildSettings))]
	public sealed partial class NavMeshBuildSettingsListRef : ListVariableRef<UnityEngine.AI.NavMeshBuildSettings>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshBuildSettings))]
	public sealed partial class NavMeshBuildSettingsListVar : ListVariableVar<UnityEngine.AI.NavMeshBuildSettings>
	{
	}
}
