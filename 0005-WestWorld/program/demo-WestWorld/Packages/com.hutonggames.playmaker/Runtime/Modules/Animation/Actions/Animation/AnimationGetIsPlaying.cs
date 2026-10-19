
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Is an animation currently being played?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation-isPlaying.html")]
	public sealed class AnimationGetIsPlaying : BaseAction
	{
		
		[Tooltip("The Animation")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Get Animation Is Playing")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsPlaying;
		
		public override bool CanExecute() => CheckParameters(_animation, _getIsPlaying);

		public override void Execute() => _getIsPlaying.Value = _animation.Value.isPlaying;

		public override string GetSummary() => "Get {_animation} isPlaying -> {_getIsPlaying}";
	}
}
