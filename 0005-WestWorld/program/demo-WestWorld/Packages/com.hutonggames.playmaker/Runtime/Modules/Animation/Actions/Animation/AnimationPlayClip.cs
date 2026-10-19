
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Plays an animation without blending.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation.Play.html")]
	public sealed class AnimationPlayClip : BaseAction
	{
		
		[Tooltip("The Animation component.")]
		[SerializeField]
		private AnimationVar _animation;
		
		[OptionalField]
		[Tooltip("The name of the animation to play. If no name is supplied then the default animation plays.")]
		[SerializeField]
		private StringVar _playAnimation;
		
		[Tooltip("Play Mode.")]
		[SerializeField]
		private PlayModeVar _mode;
		
		[OptionalField]
		[Tooltip("If no name is supplied and there is no default animation, then this method returns false. Otherwise, it returns true.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute() => CheckParameters(_animation, _mode);

		public override void Execute() => _result.Value = _animation.Value.Play(_playAnimation.Value, _mode.Value);

		public override string GetSummary() => "{_animation} Play {_playAnimation} mode:{_mode}";
	}
}
