
using System;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.ObstacleAvoidanceType))]
	public sealed partial class ObstacleAvoidanceTypeVariable : Variable<UnityEngine.AI.ObstacleAvoidanceType>
	{
		
		public ObstacleAvoidanceTypeVariable()
		{
		}
		
		public ObstacleAvoidanceTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.ObstacleAvoidanceType))]
	public sealed partial class ObstacleAvoidanceTypeListVariable : ListVariable<UnityEngine.AI.ObstacleAvoidanceType>
	{
		
		public ObstacleAvoidanceTypeListVariable()
		{
		}
		
		public ObstacleAvoidanceTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.ObstacleAvoidanceType))]
	public sealed partial class ObstacleAvoidanceTypeRef : VariableRef<UnityEngine.AI.ObstacleAvoidanceType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.ObstacleAvoidanceType))]
	public sealed partial class ObstacleAvoidanceTypeVar : VariableVar<UnityEngine.AI.ObstacleAvoidanceType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.ObstacleAvoidanceType))]
	public sealed partial class ObstacleAvoidanceTypeListRef : ListVariableRef<UnityEngine.AI.ObstacleAvoidanceType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.ObstacleAvoidanceType))]
	public sealed partial class ObstacleAvoidanceTypeListVar : ListVariableVar<UnityEngine.AI.ObstacleAvoidanceType>
	{
	}
}
