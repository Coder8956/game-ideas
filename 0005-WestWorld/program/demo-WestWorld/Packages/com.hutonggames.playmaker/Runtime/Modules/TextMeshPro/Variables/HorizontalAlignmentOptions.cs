
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.HorizontalAlignmentOptions))]
	public sealed partial class HorizontalAlignmentOptionsVariable : Variable<TMPro.HorizontalAlignmentOptions>
	{
		
		public HorizontalAlignmentOptionsVariable()
		{
		}
		
		public HorizontalAlignmentOptionsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.HorizontalAlignmentOptions))]
	public sealed partial class HorizontalAlignmentOptionsListVariable : ListVariable<TMPro.HorizontalAlignmentOptions>
	{
		
		public HorizontalAlignmentOptionsListVariable()
		{
		}
		
		public HorizontalAlignmentOptionsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.HorizontalAlignmentOptions))]
	public sealed partial class HorizontalAlignmentOptionsRef : VariableRef<TMPro.HorizontalAlignmentOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.HorizontalAlignmentOptions))]
	public sealed partial class HorizontalAlignmentOptionsVar : VariableVar<TMPro.HorizontalAlignmentOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.HorizontalAlignmentOptions))]
	public sealed partial class HorizontalAlignmentOptionsListRef : ListVariableRef<TMPro.HorizontalAlignmentOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.HorizontalAlignmentOptions))]
	public sealed partial class HorizontalAlignmentOptionsListVar : ListVariableVar<TMPro.HorizontalAlignmentOptions>
	{
	}
}
