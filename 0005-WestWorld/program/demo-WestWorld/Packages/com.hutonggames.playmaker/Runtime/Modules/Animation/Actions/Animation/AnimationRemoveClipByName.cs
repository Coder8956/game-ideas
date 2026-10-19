
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Remove clip from the animation list.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation.RemoveClip.html")]
	public sealed class AnimationRemoveClipByName : BaseAction
	{
		
		[Tooltip("The Animation component.")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Clip Name.")]
		[SerializeField]
		private StringVar _clipName;
		
		public override bool CanExecute() => CheckParameters(_animation, _clipName);

		public override void Execute() => _animation.Value.RemoveClip(_clipName.Value);

		public override string GetSummary() => "{_animation} Remove Clip {_clipName} ";
	}
}
