
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("The playback speed of the Animator. 1 is normal playback speed.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator-speed.html")]
	public sealed class AnimatorSetSpeed : BaseAction
	{
		
		[Tooltip("The Animator")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("Set Animator Speed")]
		[SerializeField]
		private FloatVar _setSpeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _setSpeed);
		}
		
		public override void Execute()
		{
			_animator.Value.speed = _setSpeed.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_animator} speed to {_setSpeed}";
		}
	}
}
