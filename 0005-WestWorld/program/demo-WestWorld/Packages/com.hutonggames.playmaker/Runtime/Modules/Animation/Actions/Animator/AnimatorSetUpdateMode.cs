
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Specifies the update mode of the Animator.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator-updateMode.html")]
	public sealed class AnimatorSetUpdateMode : BaseAction
	{
		
		[Tooltip("The Animator")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("Set Animator Update Mode")]
		[SerializeField]
		private AnimatorUpdateModeVar _setUpdateMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _setUpdateMode);
		}
		
		public override void Execute()
		{
			_animator.Value.updateMode = _setUpdateMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_animator} update mode to {_setUpdateMode}";
		}
	}
}
