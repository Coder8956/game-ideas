
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Get the default animation.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation-clip.html")]
	public sealed class AnimationGetClip : BaseAction
	{
		
		[Tooltip("The Animation")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Store the Animation Clip")]
		[SerializeField]
		[WriteOnly]
		private AnimationClipRef _getClip;
		
		public override bool CanExecute() => CheckParameters(_animation, _getClip);

		public override void Execute() => _getClip.Value = _animation.Value.clip;

		public override string GetSummary() => "Get {_animation} clip -> {_getClip}";
	}
}
