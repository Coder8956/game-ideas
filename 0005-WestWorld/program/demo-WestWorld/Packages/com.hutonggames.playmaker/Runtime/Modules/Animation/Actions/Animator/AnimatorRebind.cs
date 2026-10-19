
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Rebind all the animated properties and mesh data with the Animator.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.Rebind.html")]
	public sealed class AnimatorRebind : BaseAction
	{
		
		[Tooltip("The Animator.")]
		[SerializeField]
		private AnimatorVar _animator;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator);
		}
		
		public override void Execute()
		{
			//UnityEngine.Animator.Rebind();
			_animator.Value.Rebind();
		}
		
		public override string GetSummary()
		{
			return "Rebind {_animator}";
		}
	}
}
