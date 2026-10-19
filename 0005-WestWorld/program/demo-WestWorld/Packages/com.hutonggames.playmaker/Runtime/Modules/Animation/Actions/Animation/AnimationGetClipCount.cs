
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Get the number of clips currently assigned to this animation.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation.GetClipCount.html")]
	public sealed class AnimationGetClipCount : BaseAction
	{
		
		[Tooltip("The Animation component.")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getClipCount;
		
		public override bool CanExecute() => CheckParameters(_animation, _getClipCount);

		public override void Execute() => _getClipCount.Value = _animation.Value.GetClipCount();

		public override string GetSummary() => "Get {_animation} Clip Count -> {_getClipCount}";
	}
}
