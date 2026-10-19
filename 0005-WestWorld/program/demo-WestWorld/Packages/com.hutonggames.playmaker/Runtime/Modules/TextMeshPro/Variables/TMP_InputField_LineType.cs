
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.LineType))]
	public sealed partial class TMP_InputField_LineTypeVariable : Variable<TMPro.TMP_InputField.LineType>
	{
		
		public TMP_InputField_LineTypeVariable()
		{
		}
		
		public TMP_InputField_LineTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.LineType))]
	public sealed partial class TMP_InputField_LineTypeListVariable : ListVariable<TMPro.TMP_InputField.LineType>
	{
		
		public TMP_InputField_LineTypeListVariable()
		{
		}
		
		public TMP_InputField_LineTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.LineType))]
	public sealed partial class TMP_InputField_LineTypeRef : VariableRef<TMPro.TMP_InputField.LineType>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.LineType))]
	public sealed partial class TMP_InputField_LineTypeVar : VariableVar<TMPro.TMP_InputField.LineType>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.LineType))]
	public sealed partial class TMP_InputField_LineTypeListRef : ListVariableRef<TMPro.TMP_InputField.LineType>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.LineType))]
	public sealed partial class TMP_InputField_LineTypeListVar : ListVariableVar<TMPro.TMP_InputField.LineType>
	{
	}
}
