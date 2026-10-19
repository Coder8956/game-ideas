
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Automatic stabilization of feet during transition and blending.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator-stabilizeFeet.html")]
	public sealed class AnimatorSetStabilizeFeet : BaseAction
	{
		
		[Tooltip("The Animator")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("Set Animator Stabilize Feet")]
		[SerializeField]
		private BoolVar _setStabilizeFeet;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _setStabilizeFeet);
		}
		
		public override void Execute()
		{
			_animator.Value.stabilizeFeet = _setStabilizeFeet.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_animator} stabilize feet to {_setStabilizeFeet}";
		}
	}
}
