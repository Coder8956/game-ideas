
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextureWrapMode))]
	public sealed partial class TextureWrapModeVariable : Variable<UnityEngine.TextureWrapMode>
	{
		
		public TextureWrapModeVariable()
		{
		}
		
		public TextureWrapModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextureWrapMode))]
	public sealed partial class TextureWrapModeListVariable : ListVariable<UnityEngine.TextureWrapMode>
	{
		
		public TextureWrapModeListVariable()
		{
		}
		
		public TextureWrapModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextureWrapMode))]
	public sealed partial class TextureWrapModeRef : VariableRef<UnityEngine.TextureWrapMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextureWrapMode))]
	public sealed partial class TextureWrapModeVar : VariableVar<UnityEngine.TextureWrapMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextureWrapMode))]
	public sealed partial class TextureWrapModeListRef : ListVariableRef<UnityEngine.TextureWrapMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextureWrapMode))]
	public sealed partial class TextureWrapModeListVar : ListVariableVar<UnityEngine.TextureWrapMode>
	{
	}
}
