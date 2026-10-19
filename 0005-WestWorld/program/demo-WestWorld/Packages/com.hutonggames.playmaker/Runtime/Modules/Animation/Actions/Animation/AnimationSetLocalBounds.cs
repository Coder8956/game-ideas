
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("AABB of this Animation animation component in local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation-localBounds.html")]
	public sealed class AnimationSetLocalBounds : BaseAction
	{
		
		[Tooltip("The Animation")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Set Animation Local Bounds")]
		[SerializeField]
		private BoundsVar _setLocalBounds;
		
		public override bool CanExecute() => CheckParameters(_animation, _setLocalBounds);

		public override void Execute() => _animation.Value.localBounds = _setLocalBounds.Value;

		public override string GetSummary() => "Set {_animation} Local Bounds to {_setLocalBounds}";
	}
}
