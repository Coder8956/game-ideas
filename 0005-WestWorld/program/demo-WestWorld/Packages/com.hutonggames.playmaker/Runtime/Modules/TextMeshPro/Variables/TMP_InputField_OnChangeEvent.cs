
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.OnChangeEvent))]
	public sealed partial class TMP_InputField_OnChangeEventVariable : Variable<TMPro.TMP_InputField.OnChangeEvent>
	{
		
		public TMP_InputField_OnChangeEventVariable()
		{
		}
		
		public TMP_InputField_OnChangeEventVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.OnChangeEvent))]
	public sealed partial class TMP_InputField_OnChangeEventRef : VariableRef<TMPro.TMP_InputField.OnChangeEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.OnChangeEvent))]
	public sealed partial class TMP_InputField_OnChangeEventVar : VariableVar<TMPro.TMP_InputField.OnChangeEvent>
	{
	}
	
	/*
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.OnChangeEvent))]
	public sealed partial class TMP_InputField_OnChangeEventListVariable : ListVariable<TMPro.TMP_InputField.OnChangeEvent>
	{
		
		public TMP_InputField_OnChangeEventListVariable()
		{
		}
		
		public TMP_InputField_OnChangeEventListVariable(string name) : 
			base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.OnChangeEvent))]
	public sealed partial class TMP_InputField_OnChangeEventListRef : ListVariableRef<TMPro.TMP_InputField.OnChangeEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.OnChangeEvent))]
	public sealed partial class TMP_InputField_OnChangeEventListVar : ListVariableVar<TMPro.TMP_InputField.OnChangeEvent>
	{
	}
	*/
}
