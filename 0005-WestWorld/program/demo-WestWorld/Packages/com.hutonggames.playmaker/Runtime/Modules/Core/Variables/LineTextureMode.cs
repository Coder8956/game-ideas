
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.LineTextureMode))]
	public sealed partial class LineTextureModeVariable : Variable<UnityEngine.LineTextureMode>
	{
		
		public LineTextureModeVariable()
		{
		}
		
		public LineTextureModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LineTextureMode))]
	public sealed partial class LineTextureModeListVariable : ListVariable<UnityEngine.LineTextureMode>
	{
		
		public LineTextureModeListVariable()
		{
		}
		
		public LineTextureModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LineTextureMode))]
	public sealed partial class LineTextureModeRef : VariableRef<UnityEngine.LineTextureMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LineTextureMode))]
	public sealed partial class LineTextureModeVar : VariableVar<UnityEngine.LineTextureMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LineTextureMode))]
	public sealed partial class LineTextureModeListRef : ListVariableRef<UnityEngine.LineTextureMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LineTextureMode))]
	public sealed partial class LineTextureModeListVar : ListVariableVar<UnityEngine.LineTextureMode>
	{
	}
}
