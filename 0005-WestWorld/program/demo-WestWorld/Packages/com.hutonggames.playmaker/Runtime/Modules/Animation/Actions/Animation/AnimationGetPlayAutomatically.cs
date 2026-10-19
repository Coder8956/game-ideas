
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Should the default animation clip (the Animation.clip property) automatically sta" +
		"rt playing on startup?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation-playAutomatically.html")]
	public sealed class AnimationGetPlayAutomatically : BaseAction
	{
		
		[Tooltip("The Animation")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Get Animation Play Automatically")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getPlayAutomatically;
		
		public override bool CanExecute() => CheckParameters(_animation, _getPlayAutomatically);

		public override void Execute() => _getPlayAutomatically.Value = _animation.Value.playAutomatically;

		public override string GetSummary() => "Get {_animation} playAutomatically -> {_getPlayAutomatically}";
	}
}
