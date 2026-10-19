
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image.FillMethod))]
	public sealed partial class Image_FillMethodVariable : Variable<UnityEngine.UI.Image.FillMethod>
	{
		
		public Image_FillMethodVariable()
		{
		}
		
		public Image_FillMethodVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image.FillMethod))]
	public sealed partial class Image_FillMethodListVariable : ListVariable<UnityEngine.UI.Image.FillMethod>
	{
		
		public Image_FillMethodListVariable()
		{
		}
		
		public Image_FillMethodListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image.FillMethod))]
	public sealed partial class Image_FillMethodRef : VariableRef<UnityEngine.UI.Image.FillMethod>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image.FillMethod))]
	public sealed partial class Image_FillMethodVar : VariableVar<UnityEngine.UI.Image.FillMethod>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image.FillMethod))]
	public sealed partial class Image_FillMethodListRef : ListVariableRef<UnityEngine.UI.Image.FillMethod>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image.FillMethod))]
	public sealed partial class Image_FillMethodListVar : ListVariableVar<UnityEngine.UI.Image.FillMethod>
	{
	}
}
