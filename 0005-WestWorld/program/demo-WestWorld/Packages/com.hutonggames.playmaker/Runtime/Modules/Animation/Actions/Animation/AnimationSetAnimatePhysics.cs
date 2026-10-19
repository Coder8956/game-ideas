
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
	public sealed class AnimationSetAnimatePhysics : BaseAction
	{
		
		[Tooltip("The Animation")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Set Animation Animate Physics")]
		[SerializeField]
		private BoolVar _setAnimatePhysics;
		
		public override bool CanExecute() => CheckParameters(_animation, _setAnimatePhysics);

		public override void Execute() => _animation.Value.animatePhysics = _setAnimatePhysics.Value;

		public override string GetSummary() => "Set {_animation} Animate Physics to {_setAnimatePhysics}";
	}
}
