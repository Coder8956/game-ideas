
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationState))]
	public sealed partial class AnimationStateVariable : Variable<UnityEngine.AnimationState>
	{
		
		public AnimationStateVariable()
		{
		}
		
		public AnimationStateVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationState))]
	public sealed partial class AnimationStateListVariable : ListVariable<UnityEngine.AnimationState>
	{
		
		public AnimationStateListVariable()
		{
		}
		
		public AnimationStateListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationState))]
	public sealed partial class AnimationStateRef : VariableRef<UnityEngine.AnimationState>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationState))]
	public sealed partial class AnimationStateVar : VariableVar<UnityEngine.AnimationState>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationState))]
	public sealed partial class AnimationStateListRef : ListVariableRef<UnityEngine.AnimationState>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationState))]
	public sealed partial class AnimationStateListVar : ListVariableVar<UnityEngine.AnimationState>
	{
	}
}
