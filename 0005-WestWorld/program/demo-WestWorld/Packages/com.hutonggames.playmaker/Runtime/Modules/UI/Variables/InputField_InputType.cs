
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.InputType))]
	public sealed partial class InputField_InputTypeVariable : Variable<UnityEngine.UI.InputField.InputType>
	{
		
		public InputField_InputTypeVariable()
		{
		}
		
		public InputField_InputTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.InputType))]
	public sealed partial class InputField_InputTypeListVariable : ListVariable<UnityEngine.UI.InputField.InputType>
	{
		
		public InputField_InputTypeListVariable()
		{
		}
		
		public InputField_InputTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.InputType))]
	public sealed partial class InputField_InputTypeRef : VariableRef<UnityEngine.UI.InputField.InputType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.InputType))]
	public sealed partial class InputField_InputTypeVar : VariableVar<UnityEngine.UI.InputField.InputType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.InputType))]
	public sealed partial class InputField_InputTypeListRef : ListVariableRef<UnityEngine.UI.InputField.InputType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.InputType))]
	public sealed partial class InputField_InputTypeListVar : ListVariableVar<UnityEngine.UI.InputField.InputType>
	{
	}
}
