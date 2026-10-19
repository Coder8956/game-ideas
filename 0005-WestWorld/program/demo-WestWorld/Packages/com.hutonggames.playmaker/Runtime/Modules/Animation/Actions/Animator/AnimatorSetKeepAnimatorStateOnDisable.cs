
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Controls the behaviour of the Animator component when a GameObject is inactive.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator-keepAnimatorStateOnDisable.html" +
		"")]
	public sealed class AnimatorSetKeepAnimatorStateOnDisable : BaseAction
	{
		
		[Tooltip("The Animator")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("Set Animator Keep Animator State On Disable")]
		[SerializeField]
		private BoolVar _setKeepAnimatorStateOnDisable;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _setKeepAnimatorStateOnDisable);
		}
		
		public override void Execute()
		{
			_animator.Value.keepAnimatorStateOnDisable = _setKeepAnimatorStateOnDisable.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_animator} keep animator state on disable to {_setKeepAnimatorStateOnDisable}";
		}
	}
}
