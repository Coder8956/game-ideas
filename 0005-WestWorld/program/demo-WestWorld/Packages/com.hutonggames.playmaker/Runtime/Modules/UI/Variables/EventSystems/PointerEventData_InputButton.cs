
using System;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.PointerEventData.InputButton))]
	public sealed partial class PointerEventData_InputButtonVariable : Variable<UnityEngine.EventSystems.PointerEventData.InputButton>
	{
		
		public PointerEventData_InputButtonVariable()
		{
		}
		
		public PointerEventData_InputButtonVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.PointerEventData.InputButton))]
	public sealed partial class PointerEventData_InputButtonListVariable : ListVariable<UnityEngine.EventSystems.PointerEventData.InputButton>
	{
		
		public PointerEventData_InputButtonListVariable()
		{
		}
		
		public PointerEventData_InputButtonListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.PointerEventData.InputButton))]
	public sealed partial class PointerEventData_InputButtonRef : VariableRef<UnityEngine.EventSystems.PointerEventData.InputButton>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.PointerEventData.InputButton))]
	public sealed partial class PointerEventData_InputButtonVar : VariableVar<UnityEngine.EventSystems.PointerEventData.InputButton>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.PointerEventData.InputButton))]
	public sealed partial class PointerEventData_InputButtonListRef : ListVariableRef<UnityEngine.EventSystems.PointerEventData.InputButton>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.PointerEventData.InputButton))]
	public sealed partial class PointerEventData_InputButtonListVar : ListVariableVar<UnityEngine.EventSystems.PointerEventData.InputButton>
	{
	}
}
