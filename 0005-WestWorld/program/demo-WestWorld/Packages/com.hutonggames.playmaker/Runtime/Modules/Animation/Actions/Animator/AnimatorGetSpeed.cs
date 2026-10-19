
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
	public sealed class AnimatorGetSpeed : BaseAction
	{
		
		[Tooltip("The Animator")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("Get Animator Speed")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getSpeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _getSpeed);
		}
		
		public override void Execute()
		{
			_getSpeed.Value = _animator.Value.speed;
		}
		
		public override string GetSummary()
		{
			return "Get {_animator} speed -> {_getSpeed}";
		}
	}
}
