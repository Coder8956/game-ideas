
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.ContentType))]
	public sealed partial class TMP_InputField_ContentTypeVariable : Variable<TMPro.TMP_InputField.ContentType>
	{
		
		public TMP_InputField_ContentTypeVariable()
		{
		}
		
		public TMP_InputField_ContentTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.ContentType))]
	public sealed partial class TMP_InputField_ContentTypeListVariable : ListVariable<TMPro.TMP_InputField.ContentType>
	{
		
		public TMP_InputField_ContentTypeListVariable()
		{
		}
		
		public TMP_InputField_ContentTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.ContentType))]
	public sealed partial class TMP_InputField_ContentTypeRef : VariableRef<TMPro.TMP_InputField.ContentType>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.ContentType))]
	public sealed partial class TMP_InputField_ContentTypeVar : VariableVar<TMPro.TMP_InputField.ContentType>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.ContentType))]
	public sealed partial class TMP_InputField_ContentTypeListRef : ListVariableRef<TMPro.TMP_InputField.ContentType>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_InputField.ContentType))]
	public sealed partial class TMP_InputField_ContentTypeListVar : ListVariableVar<TMPro.TMP_InputField.ContentType>
	{
	}
}
