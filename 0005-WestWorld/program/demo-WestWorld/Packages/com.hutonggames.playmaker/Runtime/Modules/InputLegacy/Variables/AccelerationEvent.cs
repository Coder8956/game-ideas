
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AccelerationEvent))]
	public sealed partial class AccelerationEventVariable : Variable<UnityEngine.AccelerationEvent>
	{
		
		public AccelerationEventVariable()
		{
		}
		
		public AccelerationEventVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AccelerationEvent))]
	public sealed partial class AccelerationEventListVariable : ListVariable<UnityEngine.AccelerationEvent>
	{
		
		public AccelerationEventListVariable()
		{
		}
		
		public AccelerationEventListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AccelerationEvent))]
	public sealed partial class AccelerationEventRef : VariableRef<UnityEngine.AccelerationEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AccelerationEvent))]
	public sealed partial class AccelerationEventVar : VariableVar<UnityEngine.AccelerationEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AccelerationEvent))]
	public sealed partial class AccelerationEventListRef : ListVariableRef<UnityEngine.AccelerationEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AccelerationEvent))]
	public sealed partial class AccelerationEventListVar : ListVariableVar<UnityEngine.AccelerationEvent>
	{
	}
}
