
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.ContentType))]
	public sealed partial class InputField_ContentTypeVariable : Variable<UnityEngine.UI.InputField.ContentType>
	{
		
		public InputField_ContentTypeVariable()
		{
		}
		
		public InputField_ContentTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.ContentType))]
	public sealed partial class InputField_ContentTypeListVariable : ListVariable<UnityEngine.UI.InputField.ContentType>
	{
		
		public InputField_ContentTypeListVariable()
		{
		}
		
		public InputField_ContentTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.ContentType))]
	public sealed partial class InputField_ContentTypeRef : VariableRef<UnityEngine.UI.InputField.ContentType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.ContentType))]
	public sealed partial class InputField_ContentTypeVar : VariableVar<UnityEngine.UI.InputField.ContentType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.ContentType))]
	public sealed partial class InputField_ContentTypeListRef : ListVariableRef<UnityEngine.UI.InputField.ContentType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.InputField.ContentType))]
	public sealed partial class InputField_ContentTypeListVar : ListVariableVar<UnityEngine.UI.InputField.ContentType>
	{
	}
}
