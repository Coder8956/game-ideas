
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.InputType))]
	public sealed partial class TMP_InputField_InputTypeVariable : Variable<TMPro.TMP_InputField.InputType>
	{
		
		public TMP_InputField_InputTypeVariable()
		{
		}
		
		public TMP_InputField_InputTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.InputType))]
	public sealed partial class TMP_InputField_InputTypeListVariable : ListVariable<TMPro.TMP_InputField.InputType>
	{
		
		public TMP_InputField_InputTypeListVariable()
		{
		}
		
		public TMP_InputField_InputTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.InputType))]
	public sealed partial class TMP_InputField_InputTypeRef : VariableRef<TMPro.TMP_InputField.InputType>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.InputType))]
	public sealed partial class TMP_InputField_InputTypeVar : VariableVar<TMPro.TMP_InputField.InputType>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.InputType))]
	public sealed partial class TMP_InputField_InputTypeListRef : ListVariableRef<TMPro.TMP_InputField.InputType>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.InputType))]
	public sealed partial class TMP_InputField_InputTypeListVar : ListVariableVar<TMPro.TMP_InputField.InputType>
	{
	}
}
