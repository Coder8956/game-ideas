
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Sets whether the Animator sends events of type AnimationEvent.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator-fireEvents.html")]
	public sealed class AnimatorSetFireEvents : BaseAction
	{
		
		[Tooltip("The Animator")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("Set Animator Fire Events")]
		[SerializeField]
		private BoolVar _setFireEvents;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _setFireEvents);
		}
		
		public override void Execute()
		{
			_animator.Value.fireEvents = _setFireEvents.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_animator} fire events to {_setFireEvents}";
		}
	}
}
