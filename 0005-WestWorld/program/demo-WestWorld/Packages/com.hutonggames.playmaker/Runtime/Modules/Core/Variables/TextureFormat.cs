
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextureFormat))]
	public sealed partial class TextureFormatVariable : Variable<UnityEngine.TextureFormat>
	{
		
		public TextureFormatVariable()
		{
		}
		
		public TextureFormatVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextureFormat))]
	public sealed partial class TextureFormatListVariable : ListVariable<UnityEngine.TextureFormat>
	{
		
		public TextureFormatListVariable()
		{
		}
		
		public TextureFormatListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextureFormat))]
	public sealed partial class TextureFormatRef : VariableRef<UnityEngine.TextureFormat>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextureFormat))]
	public sealed partial class TextureFormatVar : VariableVar<UnityEngine.TextureFormat>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextureFormat))]
	public sealed partial class TextureFormatListRef : ListVariableRef<UnityEngine.TextureFormat>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextureFormat))]
	public sealed partial class TextureFormatListVar : ListVariableVar<UnityEngine.TextureFormat>
	{
	}
}
