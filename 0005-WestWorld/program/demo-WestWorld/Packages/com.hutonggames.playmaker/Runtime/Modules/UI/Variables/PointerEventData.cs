
using System;
using UnityEngine.EventSystems;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[Serializable]
	[DataType(typeof(PointerEventData))]
	public sealed partial class PointerEventDataVariable : Variable<PointerEventData>
	{
		public override PointerEventData Value
		{
			get => _value;
			set
			{
				_value = value;
				
#if UNITY_EDITOR				
				// Assume it's always changing,
				// but only to debug in editor
				NotifyValueChanged();
#endif				
			}
		}
		
		
		public PointerEventDataVariable()
		{
		}
		
		public PointerEventDataVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(PointerEventData))]
	public sealed partial class PointerEventDataListVariable : ListVariable<PointerEventData>
	{
		
		public PointerEventDataListVariable()
		{
		}
		
		public PointerEventDataListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(PointerEventData))]
	public sealed partial class PointerEventDataRef : VariableRef<PointerEventData>
	{
		/*
		public override bool HasValue(bool valueCanBeNullOrEmpty = false)
		{
			return base.HasValue(valueCanBeNullOrEmpty) && Value != null;
		}*/
	}
	
	[Serializable]
	[DataType(typeof(PointerEventData))]
	public sealed partial class PointerEventDataVar : VariableVar<PointerEventData>
	{
	}
	
	[Serializable]
	[DataType(typeof(PointerEventData))]
	public sealed partial class PointerEventDataListRef : ListVariableRef<PointerEventData>
	{
	}
	
	[Serializable]
	[DataType(typeof(PointerEventData))]
	public sealed partial class PointerEventDataListVar : ListVariableVar<PointerEventData>
	{
	}
}
