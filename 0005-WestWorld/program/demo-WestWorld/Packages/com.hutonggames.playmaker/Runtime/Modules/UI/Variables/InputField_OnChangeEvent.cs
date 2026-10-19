
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.OnChangeEvent))]
	public sealed partial class InputField_OnChangeEventVariable : Variable<UnityEngine.UI.InputField.OnChangeEvent>
	{
		
		public InputField_OnChangeEventVariable()
		{
		}
		
		public InputField_OnChangeEventVariable(string name) : 
				base(name)
		{
		}
	}
	

	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.OnChangeEvent))]
	public sealed partial class InputField_OnChangeEventRef : VariableRef<UnityEngine.UI.InputField.OnChangeEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.OnChangeEvent))]
	public sealed partial class InputField_OnChangeEventVar : VariableVar<UnityEngine.UI.InputField.OnChangeEvent>
	{
	}
	
	/*
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.OnChangeEvent))]
	public sealed partial class InputField_OnChangeEventListVariable : ListVariable<UnityEngine.UI.InputField.OnChangeEvent>
	{
		
		public InputField_OnChangeEventListVariable()
		{
		}
		
		public InputField_OnChangeEventListVariable(string name) : 
			base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.OnChangeEvent))]
	public sealed partial class InputField_OnChangeEventListRef : ListVariableRef<UnityEngine.UI.InputField.OnChangeEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.OnChangeEvent))]
	public sealed partial class InputField_OnChangeEventListVar : ListVariableVar<UnityEngine.UI.InputField.OnChangeEvent>
	{
	}
	*/
}
