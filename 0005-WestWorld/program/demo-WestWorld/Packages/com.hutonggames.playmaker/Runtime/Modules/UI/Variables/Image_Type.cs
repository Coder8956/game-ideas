
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image.Type))]
	public sealed partial class Image_TypeVariable : Variable<UnityEngine.UI.Image.Type>
	{
		
		public Image_TypeVariable()
		{
		}
		
		public Image_TypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image.Type))]
	public sealed partial class Image_TypeListVariable : ListVariable<UnityEngine.UI.Image.Type>
	{
		
		public Image_TypeListVariable()
		{
		}
		
		public Image_TypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image.Type))]
	public sealed partial class Image_TypeRef : VariableRef<UnityEngine.UI.Image.Type>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image.Type))]
	public sealed partial class Image_TypeVar : VariableVar<UnityEngine.UI.Image.Type>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image.Type))]
	public sealed partial class Image_TypeListRef : ListVariableRef<UnityEngine.UI.Image.Type>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image.Type))]
	public sealed partial class Image_TypeListVar : ListVariableVar<UnityEngine.UI.Image.Type>
	{
	}
}
