
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("AABB of this Animation animation component in local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation-localBounds.html")]
	public sealed class AnimationGetLocalBounds : BaseAction
	{
		
		[Tooltip("The Animation")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Get Animation Local Bounds")]
		[SerializeField]
		[WriteOnly]
		private BoundsRef _getLocalBounds;
		
		public override bool CanExecute() => CheckParameters(_animation, _getLocalBounds);

		public override void Execute() => _getLocalBounds.Value = _animation.Value.localBounds;

		public override string GetSummary() => "Get {_animation} localBounds -> {_getLocalBounds}";
	}
}
