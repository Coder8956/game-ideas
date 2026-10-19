
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Samples animations at the current state.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation.Sample.html")]
	public sealed class AnimationSample : BaseAction
	{
		
		[Tooltip("The Animation component.")]
		[SerializeField]
		private AnimationVar _animation;
		
		public override bool CanExecute() => CheckParameters(_animation);

		public override void Execute() => _animation.Value.Sample();

		public override string GetSummary() => "{_animation} Sample ";
	}
}
