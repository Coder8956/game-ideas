
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Rewinds all animations.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation.Rewind.html")]
	public sealed class AnimationRewind : BaseAction
	{
		
		[Tooltip("The Animation component.")]
		[SerializeField]
		private AnimationVar _animation;
		
		public override bool CanExecute() => CheckParameters(_animation);

		public override void Execute() => _animation.Value.Rewind();

		public override string GetSummary() => "{_animation} Rewind ";
	}
}
