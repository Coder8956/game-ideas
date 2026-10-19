
using System;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.EventSystem))]
	public sealed partial class EventSystemVariable : Variable<UnityEngine.EventSystems.EventSystem>
	{
		
		public EventSystemVariable()
		{
		}
		
		public EventSystemVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.EventSystem))]
	public sealed partial class EventSystemListVariable : ListVariable<UnityEngine.EventSystems.EventSystem>
	{
		
		public EventSystemListVariable()
		{
		}
		
		public EventSystemListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.EventSystem))]
	public sealed partial class EventSystemRef : BaseComponentRef<UnityEngine.EventSystems.EventSystem>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.EventSystem))]
	public sealed partial class EventSystemVar : BaseComponentVar<UnityEngine.EventSystems.EventSystem>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.EventSystem))]
	public sealed partial class EventSystemListRef : ListVariableRef<UnityEngine.EventSystems.EventSystem>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.EventSystem))]
	public sealed partial class EventSystemListVar : ListVariableVar<UnityEngine.EventSystems.EventSystem>
	{
	}
}
