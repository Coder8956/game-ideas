
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("How should time beyond the playback range of the clip be treated?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation-wrapMode.html")]
	public sealed class AnimationSetWrapMode : BaseAction
	{
		
		[Tooltip("The Animation")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Set Animation Wrap Mode")]
		[SerializeField]
		private WrapModeVar _setWrapMode;
		
		public override bool CanExecute() => CheckParameters(_animation, _setWrapMode);

		public override void Execute() => _animation.Value.wrapMode = _setWrapMode.Value;

		public override string GetSummary() => "Set {_animation} Wrap Mode to {_setWrapMode}";
	}
}
