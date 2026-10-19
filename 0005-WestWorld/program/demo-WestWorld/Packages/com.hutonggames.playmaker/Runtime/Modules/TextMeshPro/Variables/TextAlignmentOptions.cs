
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TextAlignmentOptions))]
	public sealed partial class TextAlignmentOptionsVariable : Variable<TMPro.TextAlignmentOptions>
	{
		
		public TextAlignmentOptionsVariable()
		{
		}
		
		public TextAlignmentOptionsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextAlignmentOptions))]
	public sealed partial class TextAlignmentOptionsListVariable : ListVariable<TMPro.TextAlignmentOptions>
	{
		
		public TextAlignmentOptionsListVariable()
		{
		}
		
		public TextAlignmentOptionsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextAlignmentOptions))]
	public sealed partial class TextAlignmentOptionsRef : VariableRef<TMPro.TextAlignmentOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextAlignmentOptions))]
	public sealed partial class TextAlignmentOptionsVar : VariableVar<TMPro.TextAlignmentOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextAlignmentOptions))]
	public sealed partial class TextAlignmentOptionsListRef : ListVariableRef<TMPro.TextAlignmentOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextAlignmentOptions))]
	public sealed partial class TextAlignmentOptionsListVar : ListVariableVar<TMPro.TextAlignmentOptions>
	{
	}
}
