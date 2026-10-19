
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.LineType))]
	public sealed partial class InputField_LineTypeVariable : Variable<UnityEngine.UI.InputField.LineType>
	{
		
		public InputField_LineTypeVariable()
		{
		}
		
		public InputField_LineTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.LineType))]
	public sealed partial class InputField_LineTypeListVariable : ListVariable<UnityEngine.UI.InputField.LineType>
	{
		
		public InputField_LineTypeListVariable()
		{
		}
		
		public InputField_LineTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.LineType))]
	public sealed partial class InputField_LineTypeRef : VariableRef<UnityEngine.UI.InputField.LineType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.LineType))]
	public sealed partial class InputField_LineTypeVar : VariableVar<UnityEngine.UI.InputField.LineType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.LineType))]
	public sealed partial class InputField_LineTypeListRef : ListVariableRef<UnityEngine.UI.InputField.LineType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.LineType))]
	public sealed partial class InputField_LineTypeListVar : ListVariableVar<UnityEngine.UI.InputField.LineType>
	{
	}
}
