
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.SubmitEvent))]
	public sealed partial class TMP_InputField_SubmitEventVariable : Variable<TMPro.TMP_InputField.SubmitEvent>
	{
		
		public TMP_InputField_SubmitEventVariable()
		{
		}
		
		public TMP_InputField_SubmitEventVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.SubmitEvent))]
	public sealed partial class TMP_InputField_SubmitEventRef : VariableRef<TMPro.TMP_InputField.SubmitEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.SubmitEvent))]
	public sealed partial class TMP_InputField_SubmitEventVar : VariableVar<TMPro.TMP_InputField.SubmitEvent>
	{
	}
	
	/*
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.SubmitEvent))]
	public sealed partial class TMP_InputField_SubmitEventListVariable : ListVariable<TMPro.TMP_InputField.SubmitEvent>
	{
		
		public TMP_InputField_SubmitEventListVariable()
		{
		}
		
		public TMP_InputField_SubmitEventListVariable(string name) : 
			base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.SubmitEvent))]
	public sealed partial class TMP_InputField_SubmitEventListRef : ListVariableRef<TMPro.TMP_InputField.SubmitEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.SubmitEvent))]
	public sealed partial class TMP_InputField_SubmitEventListVar : ListVariableVar<TMPro.TMP_InputField.SubmitEvent>
	{
	}
	*/
}
