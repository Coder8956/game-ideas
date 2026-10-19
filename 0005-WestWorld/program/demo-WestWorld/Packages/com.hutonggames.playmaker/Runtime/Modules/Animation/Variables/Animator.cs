
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Animator))]
	public sealed partial class AnimatorVariable : Variable<UnityEngine.Animator>
	{
		
		public AnimatorVariable()
		{
		}
		
		public AnimatorVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Animator))]
	public sealed partial class AnimatorListVariable : ListVariable<UnityEngine.Animator>
	{
		
		public AnimatorListVariable()
		{
		}
		
		public AnimatorListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Animator))]
	public sealed partial class AnimatorRef : BaseComponentRef<UnityEngine.Animator>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Animator))]
	public sealed partial class AnimatorVar : BaseComponentVar<UnityEngine.Animator>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Animator))]
	public sealed partial class AnimatorListRef : ListVariableRef<UnityEngine.Animator>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Animator))]
	public sealed partial class AnimatorListVar : ListVariableVar<UnityEngine.Animator>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Animator))]
	public sealed partial class AnimatorOverride : VariableOverride<UnityEngine.Animator, AnimatorVariable, AnimatorVar>
	{
		public AnimatorOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Animator))]
	public sealed partial class AnimatorOutput : VariableOutput<UnityEngine.Animator, AnimatorVariable, AnimatorRef>
	{
		public AnimatorOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Animator))]
	public sealed partial class AnimatorListOverride : VariableOverride<System.Collections.Generic.List<UnityEngine.Animator>, AnimatorListVariable, AnimatorListVar>
	{
		public AnimatorListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Animator))]
	public sealed partial class AnimatorListOutput : VariableOutput<System.Collections.Generic.List<UnityEngine.Animator>, AnimatorListVariable, AnimatorListRef>
	{
		public AnimatorListOutput(IVariable variable) : base(variable)
		{
		}
	}
}
