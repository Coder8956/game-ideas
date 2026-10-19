
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.CharacterValidation))]
	public sealed partial class InputField_CharacterValidationVariable : Variable<UnityEngine.UI.InputField.CharacterValidation>
	{
		
		public InputField_CharacterValidationVariable()
		{
		}
		
		public InputField_CharacterValidationVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.CharacterValidation))]
	public sealed partial class InputField_CharacterValidationListVariable : ListVariable<UnityEngine.UI.InputField.CharacterValidation>
	{
		
		public InputField_CharacterValidationListVariable()
		{
		}
		
		public InputField_CharacterValidationListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.CharacterValidation))]
	public sealed partial class InputField_CharacterValidationRef : VariableRef<UnityEngine.UI.InputField.CharacterValidation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.CharacterValidation))]
	public sealed partial class InputField_CharacterValidationVar : VariableVar<UnityEngine.UI.InputField.CharacterValidation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.CharacterValidation))]
	public sealed partial class InputField_CharacterValidationListRef : ListVariableRef<UnityEngine.UI.InputField.CharacterValidation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.CharacterValidation))]
	public sealed partial class InputField_CharacterValidationListVar : ListVariableVar<UnityEngine.UI.InputField.CharacterValidation>
	{
	}
}
