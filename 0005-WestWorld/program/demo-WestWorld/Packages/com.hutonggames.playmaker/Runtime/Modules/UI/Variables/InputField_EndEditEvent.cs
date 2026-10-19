
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.EndEditEvent))]
	public sealed partial class InputField_EndEditEventVariable : Variable<UnityEngine.UI.InputField.EndEditEvent>
	{
		
		public InputField_EndEditEventVariable()
		{
		}
		
		public InputField_EndEditEventVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.EndEditEvent))]
	public sealed partial class InputField_EndEditEventRef : VariableRef<UnityEngine.UI.InputField.EndEditEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.EndEditEvent))]
	public sealed partial class InputField_EndEditEventVar : VariableVar<UnityEngine.UI.InputField.EndEditEvent>
	{
	}
	
	/*
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.EndEditEvent))]
	public sealed partial class InputField_EndEditEventListVariable : ListVariable<UnityEngine.UI.InputField.EndEditEvent>
	{
		
		public InputField_EndEditEventListVariable()
		{
		}
		
		public InputField_EndEditEventListVariable(string name) : 
			base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.EndEditEvent))]
	public sealed partial class InputField_EndEditEventListRef : ListVariableRef<UnityEngine.UI.InputField.EndEditEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.EndEditEvent))]
	public sealed partial class InputField_EndEditEventListVar : ListVariableVar<UnityEngine.UI.InputField.EndEditEvent>
	{
	}
	*/
}
