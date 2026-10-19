
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TextRenderFlags))]
	public sealed partial class TextRenderFlagsVariable : Variable<TMPro.TextRenderFlags>
	{
		
		public TextRenderFlagsVariable()
		{
		}
		
		public TextRenderFlagsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextRenderFlags))]
	public sealed partial class TextRenderFlagsListVariable : ListVariable<TMPro.TextRenderFlags>
	{
		
		public TextRenderFlagsListVariable()
		{
		}
		
		public TextRenderFlagsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextRenderFlags))]
	public sealed partial class TextRenderFlagsRef : VariableRef<TMPro.TextRenderFlags>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextRenderFlags))]
	public sealed partial class TextRenderFlagsVar : VariableVar<TMPro.TextRenderFlags>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextRenderFlags))]
	public sealed partial class TextRenderFlagsListRef : ListVariableRef<TMPro.TextRenderFlags>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextRenderFlags))]
	public sealed partial class TextRenderFlagsListVar : ListVariableVar<TMPro.TextRenderFlags>
	{
	}
}
