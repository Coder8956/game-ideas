
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.SubmitEvent))]
	public sealed partial class InputField_SubmitEventVariable : Variable<UnityEngine.UI.InputField.SubmitEvent>
	{
		
		public InputField_SubmitEventVariable()
		{
		}
		
		public InputField_SubmitEventVariable(string name) : 
				base(name)
		{
		}
	}
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.SubmitEvent))]
	public sealed partial class InputField_SubmitEventRef : VariableRef<UnityEngine.UI.InputField.SubmitEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.SubmitEvent))]
	public sealed partial class InputField_SubmitEventVar : VariableVar<UnityEngine.UI.InputField.SubmitEvent>
	{
	}
	
	/*
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.SubmitEvent))]
	public sealed partial class InputField_SubmitEventListVariable : ListVariable<UnityEngine.UI.InputField.SubmitEvent>
	{
		
		public InputField_SubmitEventListVariable()
		{
		}
		
		public InputField_SubmitEventListVariable(string name) : 
			base(name)
		{
		}
	}

	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.SubmitEvent))]
	public sealed partial class InputField_SubmitEventListRef : ListVariableRef<UnityEngine.UI.InputField.SubmitEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.SubmitEvent))]
	public sealed partial class InputField_SubmitEventListVar : ListVariableVar<UnityEngine.UI.InputField.SubmitEvent>
	{
	}
	*/
}
