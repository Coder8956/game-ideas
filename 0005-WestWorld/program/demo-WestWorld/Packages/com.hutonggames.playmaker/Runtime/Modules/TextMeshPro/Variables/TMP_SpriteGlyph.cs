
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteGlyph))]
	public sealed partial class TMP_SpriteGlyphVariable : Variable<TMPro.TMP_SpriteGlyph>
	{
		
		public TMP_SpriteGlyphVariable()
		{
		}
		
		public TMP_SpriteGlyphVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteGlyph))]
	public sealed partial class TMP_SpriteGlyphListVariable : ListVariable<TMPro.TMP_SpriteGlyph>
	{
		
		public TMP_SpriteGlyphListVariable()
		{
		}
		
		public TMP_SpriteGlyphListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteGlyph))]
	public sealed partial class TMP_SpriteGlyphRef : VariableRef<TMPro.TMP_SpriteGlyph>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteGlyph))]
	public sealed partial class TMP_SpriteGlyphVar : VariableVar<TMPro.TMP_SpriteGlyph>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteGlyph))]
	public sealed partial class TMP_SpriteGlyphListRef : ListVariableRef<TMPro.TMP_SpriteGlyph>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteGlyph))]
	public sealed partial class TMP_SpriteGlyphListVar : ListVariableVar<TMPro.TMP_SpriteGlyph>
	{
	}
}
