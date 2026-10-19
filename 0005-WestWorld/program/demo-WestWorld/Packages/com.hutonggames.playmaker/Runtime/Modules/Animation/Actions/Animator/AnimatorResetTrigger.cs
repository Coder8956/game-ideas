
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Resets the value of the given trigger parameter.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.ResetTrigger.html")]
	public sealed class AnimatorResetTrigger : BaseAction
	{
		
		[Tooltip("The Animator.")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("The parameter name.")]
		[AnimatorParameter(AnimatorControllerParameterType.Trigger)]
		[SerializeField]
		private StringVar _name;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _name);
		}
		
		public override void Execute()
		{
			//UnityEngine.Animator.ResetTrigger(System.String);
			_animator.Value.ResetTrigger(_name.Value);
		}
		
		public override string GetSummary()
		{
			return "Reset {_animator} trigger {_name}";
		}
	}
}
