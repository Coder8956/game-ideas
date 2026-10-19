
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Plays the default animation without blending.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation.Play.html")]
	public sealed class AnimationPlay : BaseAction
	{
		
		[Tooltip("The Animation component.")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Play Mode.")]
		[SerializeField]
		private PlayModeVar _mode;
		
		[OptionalField]
		[Tooltip("If there is no default animation, then this method returns false. Otherwise, it returns true..")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _succeeded;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animation, _mode);
		}
		
		public override void Execute()
		{
			//UnityEngine.Animation.Play(UnityEngine.PlayMode);
			_succeeded.Value = _animation.Value.Play(_mode.Value);
		}
		
		public override string GetSummary()
		{
			return " {_animation} Play mode:{_mode} ";
		}
	}
}
