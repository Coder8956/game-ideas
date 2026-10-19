
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField))]
	public sealed partial class TMP_InputFieldVariable : Variable<TMPro.TMP_InputField>
	{
		
		public TMP_InputFieldVariable()
		{
		}
		
		public TMP_InputFieldVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField))]
	public sealed partial class TMP_InputFieldListVariable : ListVariable<TMPro.TMP_InputField>
	{
		
		public TMP_InputFieldListVariable()
		{
		}
		
		public TMP_InputFieldListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField))]
	public sealed partial class TMP_InputFieldRef : BaseComponentRef<TMPro.TMP_InputField>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField))]
	public sealed partial class TMP_InputFieldVar : BaseComponentVar<TMPro.TMP_InputField>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField))]
	public sealed partial class TMP_InputFieldListRef : ListVariableRef<TMPro.TMP_InputField>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField))]
	public sealed partial class TMP_InputFieldListVar : ListVariableVar<TMPro.TMP_InputField>
	{
	}
}
