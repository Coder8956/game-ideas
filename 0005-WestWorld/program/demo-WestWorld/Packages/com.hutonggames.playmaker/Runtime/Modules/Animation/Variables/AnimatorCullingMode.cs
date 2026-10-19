
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorCullingMode))]
	public sealed partial class AnimatorCullingModeVariable : Variable<UnityEngine.AnimatorCullingMode>
	{
		
		public AnimatorCullingModeVariable()
		{
		}
		
		public AnimatorCullingModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorCullingMode))]
	public sealed partial class AnimatorCullingModeListVariable : ListVariable<UnityEngine.AnimatorCullingMode>
	{
		
		public AnimatorCullingModeListVariable()
		{
		}
		
		public AnimatorCullingModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorCullingMode))]
	public sealed partial class AnimatorCullingModeRef : VariableRef<UnityEngine.AnimatorCullingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorCullingMode))]
	public sealed partial class AnimatorCullingModeVar : VariableVar<UnityEngine.AnimatorCullingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorCullingMode))]
	public sealed partial class AnimatorCullingModeListRef : ListVariableRef<UnityEngine.AnimatorCullingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorCullingMode))]
	public sealed partial class AnimatorCullingModeListVar : ListVariableVar<UnityEngine.AnimatorCullingMode>
	{
	}
}
