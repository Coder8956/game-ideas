
using System;
using UnityEngine.EventSystems;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[Serializable]
	[DataType(typeof(BaseEventData))]
	public sealed partial class BaseEventDataVariable : Variable<BaseEventData>
	{
		
		public BaseEventDataVariable()
		{
		}
		
		public BaseEventDataVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(BaseEventData))]
	public sealed partial class BaseEventDataListVariable : ListVariable<BaseEventData>
	{
		
		public BaseEventDataListVariable()
		{
		}
		
		public BaseEventDataListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(BaseEventData))]
	public sealed partial class BaseEventDataRef : VariableRef<BaseEventData>
	{
		/*
		public override bool HasValue(bool valueCanBeNullOrEmpty = false)
		{
			return base.HasValue(valueCanBeNullOrEmpty) && Value != null;
		}*/
	}
	
	[Serializable]
	[DataType(typeof(BaseEventData))]
	public sealed partial class BaseEventDataVar : VariableVar<BaseEventData>
	{
	}
	
	[Serializable]
	[DataType(typeof(BaseEventData))]
	public sealed partial class BaseEventDataListRef : ListVariableRef<BaseEventData>
	{
	}
	
	[Serializable]
	[DataType(typeof(BaseEventData))]
	public sealed partial class BaseEventDataListVar : ListVariableVar<BaseEventData>
	{
	}
}
