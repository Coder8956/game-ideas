
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Stops an animation named name.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation.Stop.html")]
	public sealed class AnimationStopAnimation : BaseAction
	{
		
		[Tooltip("The Animation component.")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("The name of the animation to stop.")]
		[SerializeField]
		private StringVar _name;
		
		public override bool CanExecute() => CheckParameters(_animation, _name);

		public override void Execute() => _animation.Value.Stop(_name.Value);

		public override string GetSummary() => "{_animation} Stop {_name} ";
	}
}
