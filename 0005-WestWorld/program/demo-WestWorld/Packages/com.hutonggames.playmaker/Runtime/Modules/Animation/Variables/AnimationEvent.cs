
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationEvent))]
	public sealed partial class AnimationEventVariable : Variable<UnityEngine.AnimationEvent>
	{
		
		public AnimationEventVariable()
		{
		}
		
		public AnimationEventVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationEvent))]
	public sealed partial class AnimationEventListVariable : ListVariable<UnityEngine.AnimationEvent>
	{
		
		public AnimationEventListVariable()
		{
		}
		
		public AnimationEventListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationEvent))]
	public sealed partial class AnimationEventRef : VariableRef<UnityEngine.AnimationEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationEvent))]
	public sealed partial class AnimationEventVar : VariableVar<UnityEngine.AnimationEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationEvent))]
	public sealed partial class AnimationEventListRef : ListVariableRef<UnityEngine.AnimationEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimationEvent))]
	public sealed partial class AnimationEventListVar : ListVariableVar<UnityEngine.AnimationEvent>
	{
	}
}
