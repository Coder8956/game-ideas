
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationClip))]
	public sealed partial class AnimationClipVariable : Variable<UnityEngine.AnimationClip>
	{
		
		public AnimationClipVariable()
		{
		}
		
		public AnimationClipVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationClip))]
	public sealed partial class AnimationClipListVariable : ListVariable<UnityEngine.AnimationClip>
	{
		
		public AnimationClipListVariable()
		{
		}
		
		public AnimationClipListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationClip))]
	public sealed partial class AnimationClipRef : VariableRef<UnityEngine.AnimationClip>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationClip))]
	public sealed partial class AnimationClipVar : VariableVar<UnityEngine.AnimationClip>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationClip))]
	public sealed partial class AnimationClipListRef : ListVariableRef<UnityEngine.AnimationClip>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationClip))]
	public sealed partial class AnimationClipListVar : ListVariableVar<UnityEngine.AnimationClip>
	{
	}
}
