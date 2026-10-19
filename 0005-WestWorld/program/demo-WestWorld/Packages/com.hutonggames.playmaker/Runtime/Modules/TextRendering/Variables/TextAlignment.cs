
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAlignment))]
	public sealed partial class TextAlignmentVariable : Variable<UnityEngine.TextAlignment>
	{
		
		public TextAlignmentVariable()
		{
		}
		
		public TextAlignmentVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAlignment))]
	public sealed partial class TextAlignmentListVariable : ListVariable<UnityEngine.TextAlignment>
	{
		
		public TextAlignmentListVariable()
		{
		}
		
		public TextAlignmentListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAlignment))]
	public sealed partial class TextAlignmentRef : VariableRef<UnityEngine.TextAlignment>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAlignment))]
	public sealed partial class TextAlignmentVar : VariableVar<UnityEngine.TextAlignment>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAlignment))]
	public sealed partial class TextAlignmentListRef : ListVariableRef<UnityEngine.TextAlignment>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAlignment))]
	public sealed partial class TextAlignmentListVar : ListVariableVar<UnityEngine.TextAlignment>
	{
	}
}
