
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Remove clip from the animation list.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation.RemoveClip.html")]
	public sealed class AnimationRemoveClip : BaseAction
	{
		
		[Tooltip("The Animation component.")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("The Clip to remove.")]
		[SerializeField]
		private AnimationClipVar _clip;
		
		public override bool CanExecute() => CheckParameters(_animation, _clip);

		public override void Execute() => _animation.Value.RemoveClip(_clip.Value);

		public override string GetSummary() => "{_animation} Remove Clip {_clip} ";
	}
}
