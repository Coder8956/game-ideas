
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Get an animation clip by name.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation.html")]
	public sealed class AnimationGetClipByName : BaseAction
	{
		
		[Tooltip("The Animation component.")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("The name of the clip.")]
		[SerializeField]
		private StringVar _name;
		
		[Tooltip("Store the result in AnimationClip variable.")]
		[SerializeField]
		[WriteOnly]
		private AnimationClipRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animation, _name, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Animation.GetClip(System.String);
			_result.Value = _animation.Value.GetClip(_name.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_animation} clip {_name} -> {_result}";
		}
	}
}

