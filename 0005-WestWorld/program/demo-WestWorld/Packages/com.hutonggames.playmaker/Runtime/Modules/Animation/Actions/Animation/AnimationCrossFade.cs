
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Fades in the animation with the name animation over a period of time defined by fadeLength.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation.CrossFade.html")]
	public sealed class AnimationCrossFade : BaseAction
	{
		
		[Tooltip("The Animation component.")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Animation.")]
		[SerializeField]
		private StringVar _crossFadeAnimation;
		
		[Tooltip("Fade Length.")]
		[SerializeField]
		[DefaultValue(0.3f)]
		private FloatVar _fadeLength;
		
		[Tooltip("Mode.")]
		[SerializeField]
		private PlayModeVar _mode;
		
		public override bool CanExecute() => CheckParameters(_animation, _crossFadeAnimation, _fadeLength, _mode);

		public override void Execute() => 
			_animation.Value.CrossFade(_crossFadeAnimation.Value, _fadeLength.Value, _mode.Value);

		public override string GetSummary() => "{_animation} Cross Fade {_crossFadeAnimation} time:{_fadeLength} mode:{_mode} ";
	}
}
