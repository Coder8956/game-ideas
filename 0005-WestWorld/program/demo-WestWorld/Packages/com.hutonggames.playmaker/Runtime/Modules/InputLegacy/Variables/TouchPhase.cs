
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchPhase))]
	public sealed partial class TouchPhaseVariable : Variable<UnityEngine.TouchPhase>
	{
		
		public TouchPhaseVariable()
		{
		}
		
		public TouchPhaseVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchPhase))]
	public sealed partial class TouchPhaseListVariable : ListVariable<UnityEngine.TouchPhase>
	{
		
		public TouchPhaseListVariable()
		{
		}
		
		public TouchPhaseListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchPhase))]
	public sealed partial class TouchPhaseRef : VariableRef<UnityEngine.TouchPhase>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchPhase))]
	public sealed partial class TouchPhaseVar : VariableVar<UnityEngine.TouchPhase>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchPhase))]
	public sealed partial class TouchPhaseListRef : ListVariableRef<UnityEngine.TouchPhase>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchPhase))]
	public sealed partial class TouchPhaseListVar : ListVariableVar<UnityEngine.TouchPhase>
	{
	}
}
