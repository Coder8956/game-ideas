
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.TouchScreenKeyboardEvent))]
	public sealed partial class TMP_InputField_TouchScreenKeyboardEventVariable : Variable<TMPro.TMP_InputField.TouchScreenKeyboardEvent>
	{
		
		public TMP_InputField_TouchScreenKeyboardEventVariable()
		{
		}
		
		public TMP_InputField_TouchScreenKeyboardEventVariable(string name) : 
				base(name)
		{
		}
	}
	

	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.TouchScreenKeyboardEvent))]
	public sealed partial class TMP_InputField_TouchScreenKeyboardEventRef : VariableRef<TMPro.TMP_InputField.TouchScreenKeyboardEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.TouchScreenKeyboardEvent))]
	public sealed partial class TMP_InputField_TouchScreenKeyboardEventVar : VariableVar<TMPro.TMP_InputField.TouchScreenKeyboardEvent>
	{
	}
	
	/*
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.TouchScreenKeyboardEvent))]
	public sealed partial class TMP_InputField_TouchScreenKeyboardEventListVariable : ListVariable<TMPro.TMP_InputField.TouchScreenKeyboardEvent>
	{
		
		public TMP_InputField_TouchScreenKeyboardEventListVariable()
		{
		}
		
		public TMP_InputField_TouchScreenKeyboardEventListVariable(string name) : 
			base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.TouchScreenKeyboardEvent))]
	public sealed partial class TMP_InputField_TouchScreenKeyboardEventListRef : ListVariableRef<TMPro.TMP_InputField.TouchScreenKeyboardEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.TouchScreenKeyboardEvent))]
	public sealed partial class TMP_InputField_TouchScreenKeyboardEventListVar : ListVariableVar<TMPro.TMP_InputField.TouchScreenKeyboardEvent>
	{
	}
	*/
}
