
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("When turned on, animations will be executed in the physics loop. This is only useful " +
		"in conjunction with kinematic rigidbodies.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation-animatePhysics.html")]
	public sealed class AnimationGetAnimatePhysics : BaseAction
	{
		
		[Tooltip("The Animation")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Get Animation Animate Physics")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAnimatePhysics;
		
		public override bool CanExecute() => CheckParameters(_animation, _getAnimatePhysics);

		public override void Execute() => _getAnimatePhysics.Value = _animation.Value.animatePhysics;

		public override string GetSummary() => "Get {_animation} animatePhysics -> {_getAnimatePhysics}";
	}
}
