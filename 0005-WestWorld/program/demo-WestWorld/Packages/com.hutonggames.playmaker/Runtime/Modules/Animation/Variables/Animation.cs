
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Animation))]
	public sealed partial class AnimationVariable : Variable<UnityEngine.Animation>
	{
		
		public AnimationVariable()
		{
		}
		
		public AnimationVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Animation))]
	public sealed partial class AnimationListVariable : ListVariable<UnityEngine.Animation>
	{
		
		public AnimationListVariable()
		{
		}
		
		public AnimationListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Animation))]
	public sealed partial class AnimationRef : BaseComponentRef<UnityEngine.Animation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Animation))]
	public sealed partial class AnimationVar : BaseComponentVar<UnityEngine.Animation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Animation))]
	public sealed partial class AnimationListRef : ListVariableRef<UnityEngine.Animation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Animation))]
	public sealed partial class AnimationListVar : ListVariableVar<UnityEngine.Animation>
	{
	}
}
