
using System;


namespace HutongGames.PlayMaker.Actions.TextCore
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextCore.Glyph))]
	public sealed partial class GlyphVariable : Variable<UnityEngine.TextCore.Glyph>
	{
		
		public GlyphVariable()
		{
		}
		
		public GlyphVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextCore.Glyph))]
	public sealed partial class GlyphListVariable : ListVariable<UnityEngine.TextCore.Glyph>
	{
		
		public GlyphListVariable()
		{
		}
		
		public GlyphListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextCore.Glyph))]
	public sealed partial class GlyphRef : VariableRef<UnityEngine.TextCore.Glyph>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextCore.Glyph))]
	public sealed partial class GlyphVar : VariableVar<UnityEngine.TextCore.Glyph>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextCore.Glyph))]
	public sealed partial class GlyphListRef : ListVariableRef<UnityEngine.TextCore.Glyph>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextCore.Glyph))]
	public sealed partial class GlyphListVar : ListVariableVar<UnityEngine.TextCore.Glyph>
	{
	}
}
