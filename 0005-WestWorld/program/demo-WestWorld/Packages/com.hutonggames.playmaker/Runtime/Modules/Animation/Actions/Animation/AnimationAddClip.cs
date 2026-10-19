
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Adds a clip to the animation.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation.AddClip.html")]
	public sealed class AnimationAddClip : BaseAction
	{
		
		[Tooltip("The Animation component.")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("The Clip to add.")]
		[SerializeField]
		private AnimationClipVar _clip;
		
		[OptionalField]
		[Tooltip("New Name. Uses clip name if empty.")]
		[SerializeField]
		private StringVar _newName;
		
		public override bool CanExecute() => CheckParameters(_animation, _clip);

		public override void Execute()
		{
			var name = _newName.HasValue() ? _newName.Value : _clip.Value.name;
			_animation.Value.AddClip(_clip.Value, name);
		}
		
		public override string GetSummary() => "{_animation} Add Clip {_clip} {_newName} ";
	}
}
