
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Blends the animation named animation towards targetWeight over the next time seconds.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation.Blend.html")]
	public sealed class AnimationBlend : BaseAction
	{
		
		[Tooltip("The Animation component.")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("The Animation to blend to.")]
		[SerializeField]
		private StringVar _blendAnimation;
		
		[Tooltip("Target Weight.")]
		[SerializeField]
		[DefaultValue(1f)]
		private FloatVar _targetWeight;
		
		[Tooltip("Fade Length.")]
		[SerializeField]
		[DefaultValue(0.3f)]
		private FloatVar _fadeLength;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animation, _blendAnimation, _targetWeight, _fadeLength);
		}
		
		public override void Execute()
		{
			//UnityEngine.Animation.Blend(System.String, System.Single, System.Single);
			_animation.Value.Blend(_blendAnimation.Value, _targetWeight.Value, _fadeLength.Value);
		}
		
		public override string GetSummary()
		{
			return "{_animation} Blend {_blendAnimation} weight:{_targetWeight} time:{_fadeLength} ";
		}
	}
}
