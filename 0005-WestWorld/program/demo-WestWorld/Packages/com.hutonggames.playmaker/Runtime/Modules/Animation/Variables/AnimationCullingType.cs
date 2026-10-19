
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationCullingType))]
	public sealed partial class AnimationCullingTypeVariable : Variable<UnityEngine.AnimationCullingType>
	{
		
		public AnimationCullingTypeVariable()
		{
		}
		
		public AnimationCullingTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationCullingType))]
	public sealed partial class AnimationCullingTypeListVariable : ListVariable<UnityEngine.AnimationCullingType>
	{
		
		public AnimationCullingTypeListVariable()
		{
		}
		
		public AnimationCullingTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationCullingType))]
	public sealed partial class AnimationCullingTypeRef : VariableRef<UnityEngine.AnimationCullingType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationCullingType))]
	public sealed partial class AnimationCullingTypeVar : VariableVar<UnityEngine.AnimationCullingType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationCullingType))]
	public sealed partial class AnimationCullingTypeListRef : ListVariableRef<UnityEngine.AnimationCullingType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationCullingType))]
	public sealed partial class AnimationCullingTypeListVar : ListVariableVar<UnityEngine.AnimationCullingType>
	{
	}
}
