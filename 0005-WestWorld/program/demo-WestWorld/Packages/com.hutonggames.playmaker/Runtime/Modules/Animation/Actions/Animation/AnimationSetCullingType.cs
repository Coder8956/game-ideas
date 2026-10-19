
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Controls culling of this Animation component.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation-cullingType.html")]
	public sealed class AnimationSetCullingType : BaseAction
	{
		
		[Tooltip("The Animation")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Set Animation Culling Type")]
		[SerializeField]
		private AnimationCullingTypeVar _setCullingType;
		
		public override bool CanExecute() => CheckParameters(_animation, _setCullingType);

		public override void Execute() => _animation.Value.cullingType = _setCullingType.Value;

		public override string GetSummary() => "Set {_animation} Culling Type to {_setCullingType}";
	}
}
