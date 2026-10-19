
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Events.UnityEvent))]
	public sealed partial class UnityEventVariable : Variable<UnityEngine.Events.UnityEvent>
	{
		
		public UnityEventVariable()
		{
		}
		
		public UnityEventVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Events.UnityEvent))]
	public sealed partial class UnityEventListVariable : ListVariable<UnityEngine.Events.UnityEvent>
	{
		
		public UnityEventListVariable()
		{
		}
		
		public UnityEventListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Events.UnityEvent))]
	public sealed partial class UnityEventRef : VariableRef<UnityEngine.Events.UnityEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Events.UnityEvent))]
	public sealed partial class UnityEventVar : VariableVar<UnityEngine.Events.UnityEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Events.UnityEvent))]
	public sealed partial class UnityEventListRef : ListVariableRef<UnityEngine.Events.UnityEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Events.UnityEvent))]
	public sealed partial class UnityEventListVar : ListVariableVar<UnityEngine.Events.UnityEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Events.UnityEvent))]
	public sealed partial class UnityEventOverride : VariableOverride<UnityEngine.Events.UnityEvent,UnityEventVariable,UnityEventVar>
	{
		
		public UnityEventOverride(IVariable variable) : 
			base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Events.UnityEvent))]
	public sealed partial class UnityEventOutput : VariableOutput<UnityEngine.Events.UnityEvent,UnityEventVariable,UnityEventRef>
	{
		
		public UnityEventOutput(IVariable variable) : 
			base(variable)
		{
		}
	}
}
