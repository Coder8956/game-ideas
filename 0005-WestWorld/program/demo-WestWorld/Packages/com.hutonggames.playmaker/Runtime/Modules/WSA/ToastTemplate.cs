
using System;


namespace HutongGames.PlayMaker.Actions.WSA
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.ToastTemplate))]
	public sealed partial class ToastTemplateVariable : Variable<UnityEngine.WSA.ToastTemplate>
	{
		
		public ToastTemplateVariable()
		{
		}
		
		public ToastTemplateVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.ToastTemplate))]
	public sealed partial class ToastTemplateListVariable : ListVariable<UnityEngine.WSA.ToastTemplate>
	{
		
		public ToastTemplateListVariable()
		{
		}
		
		public ToastTemplateListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.ToastTemplate))]
	public sealed partial class ToastTemplateRef : VariableRef<UnityEngine.WSA.ToastTemplate>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.ToastTemplate))]
	public sealed partial class ToastTemplateVar : VariableVar<UnityEngine.WSA.ToastTemplate>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.ToastTemplate))]
	public sealed partial class ToastTemplateListRef : ListVariableRef<UnityEngine.WSA.ToastTemplate>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.ToastTemplate))]
	public sealed partial class ToastTemplateListVar : ListVariableVar<UnityEngine.WSA.ToastTemplate>
	{
	}
}
