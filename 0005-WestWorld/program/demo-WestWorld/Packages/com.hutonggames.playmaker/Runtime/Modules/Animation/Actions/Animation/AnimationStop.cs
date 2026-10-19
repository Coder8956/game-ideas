
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Stops all playing animations that were started with this Animation component.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation.Stop.html")]
	public sealed class AnimationStop : BaseAction
	{
		
		[Tooltip("The Animation component.")]
		[SerializeField]
		private AnimationVar _animation;
		
		public override bool CanExecute() => CheckParameters(_animation);

		public override void Execute() => _animation.Value.Stop();

		public override string GetSummary() => "{_animation} Stop";
	}
}
