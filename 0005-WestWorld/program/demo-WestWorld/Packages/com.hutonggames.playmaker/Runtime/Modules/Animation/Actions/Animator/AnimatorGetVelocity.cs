
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Gets the avatar velocity  for the last evaluated frame.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator-velocity.html")]
	public sealed class AnimatorGetVelocity : BaseAction
	{
		
		[Tooltip("The Animator")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("Get Animator Velocity")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _getVelocity);
		}
		
		public override void Execute()
		{
			_getVelocity.Value = _animator.Value.velocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_animator} velocity -> {_getVelocity}";
		}
	}
}
