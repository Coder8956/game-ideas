// Reference:
// https://www.youtube.com/watch?v=I3_i-x9nCjs

using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Changes the animator's animation state. Does not do anything if the state is already playing." +
	                   "\n\nUse this action to play animations without a lot of complex transitions in the animator. " +
	                   "For example, when entering an FSM state you can play the corresponding animation in the Animator. ")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.Play.html")]
	public sealed class AnimatorChangeAnimation : BaseAction
	{
		
		[Tooltip("The Animator.")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("The state name.")]
		[SerializeField]
		private StringVar _stateName;
		
		[Tooltip("The layer index. If layer is -1, it plays the first state with the given state name or hash.")]
		[SerializeField, DefaultValue(-1)]
		private IntegerVar _layer;
		
		[Tooltip("Cross fade to new animation.")]
		[SerializeField, DefaultValue(0.2f)]
		private FloatVar _crossFadeTime;
		
		public override bool CanExecute() => CheckParameters(_animator, _stateName, _layer, _crossFadeTime);

		public override void Execute()
		{
			if (AnimatorUtils.IsPlaying(_animator.Value, _layer.Value, _stateName.Value)) return;
			_animator.Value.CrossFade(_stateName.Value, _crossFadeTime.Value, _layer.Value);
		}
		
		public override string GetSummary() =>
			"Change {_animator} animation to {_stateName} " +
			(_layer.Value == -1 ? "" : "on layer {_layer}") +
			(_crossFadeTime.Value > 0 ? " in {_crossFadeTime:seconds}" : "");
	}
}
