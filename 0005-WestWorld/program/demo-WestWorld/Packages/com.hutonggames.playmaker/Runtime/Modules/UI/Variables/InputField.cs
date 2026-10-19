
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField))]
	public sealed partial class InputFieldVariable : Variable<UnityEngine.UI.InputField>
	{
		
		public InputFieldVariable()
		{
		}
		
		public InputFieldVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField))]
	public sealed partial class InputFieldListVariable : ListVariable<UnityEngine.UI.InputField>
	{
		
		public InputFieldListVariable()
		{
		}
		
		public InputFieldListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField))]
	public sealed partial class InputFieldRef : BaseComponentRef<UnityEngine.UI.InputField>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField))]
	public sealed partial class InputFieldVar : BaseComponentVar<UnityEngine.UI.InputField>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField))]
	public sealed partial class InputFieldListRef : ListVariableRef<UnityEngine.UI.InputField>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField))]
	public sealed partial class InputFieldListVar : ListVariableVar<UnityEngine.UI.InputField>
	{
	}
}
