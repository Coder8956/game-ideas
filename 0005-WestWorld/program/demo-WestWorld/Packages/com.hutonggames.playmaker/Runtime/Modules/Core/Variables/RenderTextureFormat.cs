
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderTextureFormat))]
	public sealed partial class RenderTextureFormatVariable : Variable<UnityEngine.RenderTextureFormat>
	{
		
		public RenderTextureFormatVariable()
		{
		}
		
		public RenderTextureFormatVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderTextureFormat))]
	public sealed partial class RenderTextureFormatListVariable : ListVariable<UnityEngine.RenderTextureFormat>
	{
		
		public RenderTextureFormatListVariable()
		{
		}
		
		public RenderTextureFormatListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderTextureFormat))]
	public sealed partial class RenderTextureFormatRef : VariableRef<UnityEngine.RenderTextureFormat>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderTextureFormat))]
	public sealed partial class RenderTextureFormatVar : VariableVar<UnityEngine.RenderTextureFormat>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderTextureFormat))]
	public sealed partial class RenderTextureFormatListRef : ListVariableRef<UnityEngine.RenderTextureFormat>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderTextureFormat))]
	public sealed partial class RenderTextureFormatListVar : ListVariableVar<UnityEngine.RenderTextureFormat>
	{
	}
}
