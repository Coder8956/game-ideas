
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.TextSelectionEvent))]
	public sealed partial class TMP_InputField_TextSelectionEventVariable : Variable<TMPro.TMP_InputField.TextSelectionEvent>
	{
		
		public TMP_InputField_TextSelectionEventVariable()
		{
		}
		
		public TMP_InputField_TextSelectionEventVariable(string name) : 
				base(name)
		{
		}
	}

	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.TextSelectionEvent))]
	public sealed partial class TMP_InputField_TextSelectionEventRef : VariableRef<TMPro.TMP_InputField.TextSelectionEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.TextSelectionEvent))]
	public sealed partial class TMP_InputField_TextSelectionEventVar : VariableVar<TMPro.TMP_InputField.TextSelectionEvent>
	{
	}
	
	/*
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.TextSelectionEvent))]
	public sealed partial class TMP_InputField_TextSelectionEventListVariable : ListVariable<TMPro.TMP_InputField.TextSelectionEvent>
	{
		
		public TMP_InputField_TextSelectionEventListVariable()
		{
		}
		
		public TMP_InputField_TextSelectionEventListVariable(string name) : 
			base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.TextSelectionEvent))]
	public sealed partial class TMP_InputField_TextSelectionEventListRef : ListVariableRef<TMPro.TMP_InputField.TextSelectionEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.TextSelectionEvent))]
	public sealed partial class TMP_InputField_TextSelectionEventListVar : ListVariableVar<TMPro.TMP_InputField.TextSelectionEvent>
	{
	}
	*/
}
