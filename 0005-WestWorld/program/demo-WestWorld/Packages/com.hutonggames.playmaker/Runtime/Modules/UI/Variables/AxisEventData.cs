
using System;
using UnityEngine.EventSystems;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[Serializable]
	[DataType(typeof(AxisEventData))]
	public sealed partial class AxisEventDataVariable : Variable<AxisEventData>
	{
		
		public AxisEventDataVariable()
		{
		}
		
		public AxisEventDataVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(AxisEventData))]
	public sealed partial class AxisEventDataListVariable : ListVariable<AxisEventData>
	{
		
		public AxisEventDataListVariable()
		{
		}
		
		public AxisEventDataListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(AxisEventData))]
	public sealed partial class AxisEventDataRef : VariableRef<AxisEventData>
	{
		/*
		public override bool HasValue(bool valueCanBeNullOrEmpty = false)
		{
			return base.HasValue(valueCanBeNullOrEmpty) && Value != null;
		}*/
	}
	
	[Serializable]
	[DataType(typeof(AxisEventData))]
	public sealed partial class AxisEventDataVar : VariableVar<AxisEventData>
	{
	}
	
	[Serializable]
	[DataType(typeof(AxisEventData))]
	public sealed partial class AxisEventDataListRef : ListVariableRef<AxisEventData>
	{
	}
	
	[Serializable]
	[DataType(typeof(AxisEventData))]
	public sealed partial class AxisEventDataListVar : ListVariableVar<AxisEventData>
	{
	}
}
