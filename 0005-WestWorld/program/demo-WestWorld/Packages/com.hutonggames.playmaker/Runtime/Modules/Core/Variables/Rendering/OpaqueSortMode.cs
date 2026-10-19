
using System;


namespace HutongGames.PlayMaker.Actions.Rendering
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.OpaqueSortMode))]
	public sealed partial class OpaqueSortModeVariable : Variable<UnityEngine.Rendering.OpaqueSortMode>
	{
		
		public OpaqueSortModeVariable()
		{
		}
		
		public OpaqueSortModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.OpaqueSortMode))]
	public sealed partial class OpaqueSortModeListVariable : ListVariable<UnityEngine.Rendering.OpaqueSortMode>
	{
		
		public OpaqueSortModeListVariable()
		{
		}
		
		public OpaqueSortModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.OpaqueSortMode))]
	public sealed partial class OpaqueSortModeRef : VariableRef<UnityEngine.Rendering.OpaqueSortMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.OpaqueSortMode))]
	public sealed partial class OpaqueSortModeVar : VariableVar<UnityEngine.Rendering.OpaqueSortMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.OpaqueSortMode))]
	public sealed partial class OpaqueSortModeListRef : ListVariableRef<UnityEngine.Rendering.OpaqueSortMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.OpaqueSortMode))]
	public sealed partial class OpaqueSortModeListVar : ListVariableVar<UnityEngine.Rendering.OpaqueSortMode>
	{
	}
}
