
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorRecorderMode))]
	public sealed partial class AnimatorRecorderModeVariable : Variable<UnityEngine.AnimatorRecorderMode>
	{
		
		public AnimatorRecorderModeVariable()
		{
		}
		
		public AnimatorRecorderModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorRecorderMode))]
	public sealed partial class AnimatorRecorderModeListVariable : ListVariable<UnityEngine.AnimatorRecorderMode>
	{
		
		public AnimatorRecorderModeListVariable()
		{
		}
		
		public AnimatorRecorderModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorRecorderMode))]
	public sealed partial class AnimatorRecorderModeRef : VariableRef<UnityEngine.AnimatorRecorderMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorRecorderMode))]
	public sealed partial class AnimatorRecorderModeVar : VariableVar<UnityEngine.AnimatorRecorderMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorRecorderMode))]
	public sealed partial class AnimatorRecorderModeListRef : ListVariableRef<UnityEngine.AnimatorRecorderMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorRecorderMode))]
	public sealed partial class AnimatorRecorderModeListVar : ListVariableVar<UnityEngine.AnimatorRecorderMode>
	{
	}
}
