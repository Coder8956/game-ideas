
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.RawImage))]
	public sealed partial class RawImageVariable : Variable<UnityEngine.UI.RawImage>
	{
		
		public RawImageVariable()
		{
		}
		
		public RawImageVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.RawImage))]
	public sealed partial class RawImageListVariable : ListVariable<UnityEngine.UI.RawImage>
	{
		
		public RawImageListVariable()
		{
		}
		
		public RawImageListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.RawImage))]
	public sealed partial class RawImageRef : BaseComponentRef<UnityEngine.UI.RawImage>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.RawImage))]
	public sealed partial class RawImageVar : BaseComponentVar<UnityEngine.UI.RawImage>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.RawImage))]
	public sealed partial class RawImageListRef : ListVariableRef<UnityEngine.UI.RawImage>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.RawImage))]
	public sealed partial class RawImageListVar : ListVariableVar<UnityEngine.UI.RawImage>
	{
	}
}
