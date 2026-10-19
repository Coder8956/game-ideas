
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.VerticalAlignmentOptions))]
	public sealed partial class VerticalAlignmentOptionsVariable : Variable<TMPro.VerticalAlignmentOptions>
	{
		
		public VerticalAlignmentOptionsVariable()
		{
		}
		
		public VerticalAlignmentOptionsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.VerticalAlignmentOptions))]
	public sealed partial class VerticalAlignmentOptionsListVariable : ListVariable<TMPro.VerticalAlignmentOptions>
	{
		
		public VerticalAlignmentOptionsListVariable()
		{
		}
		
		public VerticalAlignmentOptionsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.VerticalAlignmentOptions))]
	public sealed partial class VerticalAlignmentOptionsRef : VariableRef<TMPro.VerticalAlignmentOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.VerticalAlignmentOptions))]
	public sealed partial class VerticalAlignmentOptionsVar : VariableVar<TMPro.VerticalAlignmentOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.VerticalAlignmentOptions))]
	public sealed partial class VerticalAlignmentOptionsListRef : ListVariableRef<TMPro.VerticalAlignmentOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.VerticalAlignmentOptions))]
	public sealed partial class VerticalAlignmentOptionsListVar : ListVariableVar<TMPro.VerticalAlignmentOptions>
	{
	}
}
