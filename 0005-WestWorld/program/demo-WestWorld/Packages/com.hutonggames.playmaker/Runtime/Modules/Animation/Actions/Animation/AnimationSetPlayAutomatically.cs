
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
	public sealed class AnimationSetPlayAutomatically : BaseAction
	{
		
		[Tooltip("The Animation")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Set Animation Play Automatically")]
		[SerializeField]
		private BoolVar _setPlayAutomatically;
		
		public override bool CanExecute() => CheckParameters(_animation, _setPlayAutomatically);

		public override void Execute() => _animation.Value.playAutomatically = _setPlayAutomatically.Value;

		public override string GetSummary() => "Set {_animation} Play Automatically to {_setPlayAutomatically}";
	}
}
