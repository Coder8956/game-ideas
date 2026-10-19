
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Set the default animation.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation-clip.html")]
	public sealed class AnimationSetClip : BaseAction
	{
		
		[Tooltip("The Animation")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Set Animation Clip")]
		[SerializeField, CanBeNullOrEmpty]
		private AnimationClipVar _setClip;
		
		public override bool CanExecute() => CheckParameters(_animation);

		public override void Execute() => _animation.Value.clip = _setClip.Value;

		public override string GetSummary() => "Set {_animation} Clip to {_setClip}";
	}
}
