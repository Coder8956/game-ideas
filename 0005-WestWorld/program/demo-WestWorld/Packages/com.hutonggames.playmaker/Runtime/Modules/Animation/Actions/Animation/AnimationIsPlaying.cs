
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Is the animation named name playing?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation.IsPlaying.html")]
	public sealed class AnimationIsPlaying : BaseAction
	{
		
		[Tooltip("The Animation component.")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Name.")]
		[SerializeField]
		private StringVar _name;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute() => CheckParameters(_animation, _name);

		public override void Execute() => _result.Value = _animation.Value.IsPlaying(_name.Value);

		public override string GetSummary() => "{_animation} Is Playing {_name} -> {_result}";
	}
}
