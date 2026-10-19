
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationBlendMode))]
	public sealed partial class AnimationBlendModeVariable : Variable<UnityEngine.AnimationBlendMode>
	{
		
		public AnimationBlendModeVariable()
		{
		}
		
		public AnimationBlendModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationBlendMode))]
	public sealed partial class AnimationBlendModeListVariable : ListVariable<UnityEngine.AnimationBlendMode>
	{
		
		public AnimationBlendModeListVariable()
		{
		}
		
		public AnimationBlendModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationBlendMode))]
	public sealed partial class AnimationBlendModeRef : VariableRef<UnityEngine.AnimationBlendMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationBlendMode))]
	public sealed partial class AnimationBlendModeVar : VariableVar<UnityEngine.AnimationBlendMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationBlendMode))]
	public sealed partial class AnimationBlendModeListRef : ListVariableRef<UnityEngine.AnimationBlendMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationBlendMode))]
	public sealed partial class AnimationBlendModeListVar : ListVariableVar<UnityEngine.AnimationBlendMode>
	{
	}
}
