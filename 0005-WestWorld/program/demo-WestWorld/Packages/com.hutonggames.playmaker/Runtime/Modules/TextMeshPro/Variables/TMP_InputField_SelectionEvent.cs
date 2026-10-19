
using System;


namespace HutongGames.PlayMaker.Actions
{
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.SelectionEvent))]
	public sealed partial class TMP_InputField_SelectionEventVariable : Variable<TMPro.TMP_InputField.SelectionEvent>
	{
		
		public TMP_InputField_SelectionEventVariable()
		{
		}
		
		public TMP_InputField_SelectionEventVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.SelectionEvent))]
	public sealed partial class TMP_InputField_SelectionEventRef : VariableRef<TMPro.TMP_InputField.SelectionEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.SelectionEvent))]
	public sealed partial class TMP_InputField_SelectionEventVar : VariableVar<TMPro.TMP_InputField.SelectionEvent>
	{
	}
	
	/*
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.SelectionEvent))]
	public sealed partial class TMP_InputField_SelectionEventListVariable : ListVariable<TMPro.TMP_InputField.SelectionEvent>
	{
		
		public TMP_InputField_SelectionEventListVariable()
		{
		}
		
		public TMP_InputField_SelectionEventListVariable(string name) : 
			base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.SelectionEvent))]
	public sealed partial class TMP_InputField_SelectionEventListRef : ListVariableRef<TMPro.TMP_InputField.SelectionEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.SelectionEvent))]
	public sealed partial class TMP_InputField_SelectionEventListVar : ListVariableVar<TMPro.TMP_InputField.SelectionEvent>
	{
	}
	*/
}
