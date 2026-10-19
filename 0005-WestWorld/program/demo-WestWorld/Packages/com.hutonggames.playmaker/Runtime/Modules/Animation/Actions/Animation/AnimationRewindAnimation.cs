
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Rewinds the animation named name.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation.Rewind.html")]
	public sealed class AnimationRewindAnimation : BaseAction
	{
		
		[Tooltip("The Animation component.")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("The name of the animation to rewind.")]
		[SerializeField]
		private StringVar _name;
		
		public override bool CanExecute() => CheckParameters(_animation, _name);

		public override void Execute() => _animation.Value.Rewind(_name.Value);

		public override string GetSummary() => "{_animation} Rewind {_name} ";
	}
}
