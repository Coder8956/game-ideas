
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.LineAlignment))]
	public sealed partial class LineAlignmentVariable : Variable<UnityEngine.LineAlignment>
	{
		
		public LineAlignmentVariable()
		{
		}
		
		public LineAlignmentVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LineAlignment))]
	public sealed partial class LineAlignmentListVariable : ListVariable<UnityEngine.LineAlignment>
	{
		
		public LineAlignmentListVariable()
		{
		}
		
		public LineAlignmentListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LineAlignment))]
	public sealed partial class LineAlignmentRef : VariableRef<UnityEngine.LineAlignment>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LineAlignment))]
	public sealed partial class LineAlignmentVar : VariableVar<UnityEngine.LineAlignment>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LineAlignment))]
	public sealed partial class LineAlignmentListRef : ListVariableRef<UnityEngine.LineAlignment>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LineAlignment))]
	public sealed partial class LineAlignmentListVar : ListVariableVar<UnityEngine.LineAlignment>
	{
	}
}
