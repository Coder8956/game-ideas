
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("How should time beyond the playback range of the clip be treated?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation-wrapMode.html")]
	public sealed class AnimationGetWrapMode : BaseAction
	{
		
		[Tooltip("The Animation")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Get Animation Wrap Mode")]
		[SerializeField]
		[WriteOnly]
		private WrapModeRef _getWrapMode;
		
		public override bool CanExecute() => CheckParameters(_animation, _getWrapMode);

		public override void Execute() => _getWrapMode.Value = _animation.Value.wrapMode;

		public override string GetSummary() => "Get {_animation} wrapMode -> {_getWrapMode}";
	}
}
