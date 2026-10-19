
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Checks if an animation state is playing.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.Play.html")]
	public sealed class AnimatorCheckIsPlaying : BaseTrueFalseAction
	{
		
		[Tooltip("The Animator.")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("The state name.")]
		[SerializeField]
		private StringVar _stateName;
		
		[Tooltip("The layer index.")]
		[SerializeField]
		private IntegerVar _layer;
		
		public override bool CanExecute() => CheckParameters(_animator, _stateName, _layer);

		protected override bool Test() => AnimatorUtils.IsPlaying(_animator.Value, _layer.Value, _stateName.Value);

		protected override string TrueSummary => "{_animator} {_stateName} is playing";
		protected override string FalseSummary => "{_animator} {_stateName} is not playing";
	}
}
