
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Forces a write of the default values stored in the animator.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.WriteDefaultValues.html")]
	public sealed class AnimatorWriteDefaultValues : BaseAction
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
			//UnityEngine.Animator.WriteDefaultValues();
			_animator.Value.WriteDefaultValues();
		}
		
		public override string GetSummary()
		{
			return "Write {_animator} default values";
		}
	}
}
