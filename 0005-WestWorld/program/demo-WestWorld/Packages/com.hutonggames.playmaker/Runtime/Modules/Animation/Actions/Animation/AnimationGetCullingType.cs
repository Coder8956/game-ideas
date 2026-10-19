
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Controls culling of this Animation component.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation-cullingType.html")]
	public sealed class AnimationGetCullingType : BaseAction
	{
		
		[Tooltip("The Animation")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Get Animation Culling Type")]
		[SerializeField]
		[WriteOnly]
		private AnimationCullingTypeRef _getCullingType;
		
		public override bool CanExecute() => CheckParameters(_animation, _getCullingType);

		public override void Execute() => _getCullingType.Value = _animation.Value.cullingType;

		public override string GetSummary() => "Get {_animation} cullingType -> {_getCullingType}";
	}
}
