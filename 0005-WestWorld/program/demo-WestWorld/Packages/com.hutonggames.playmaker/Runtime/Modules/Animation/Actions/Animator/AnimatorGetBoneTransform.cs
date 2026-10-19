
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Retrieves the Transform mapped to a human bone based on its id.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.GetBoneTransform.html")]
	public sealed class AnimatorGetBoneTransform : BaseAction
	{
		
		[Tooltip("The Animator.")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("The human bone to be queried. See the HumanBodyBones enum for a list of possible " +
			"values.")]
		[SerializeField]
		private HumanBodyBones _humanBoneId;
		
		[Tooltip("Store the result in Transform variable.")]
		[SerializeField]
		[WriteOnly]
		private TransformRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _humanBoneId, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Animator.GetBoneTransform(UnityEngine.HumanBodyBones);
			_result.Value = _animator.Value.GetBoneTransform(_humanBoneId);
		}
		
		public override string GetSummary()
		{
			return "Get {_animator} bone {_humanBoneId} transform -> {_result}";
		}
	}
}
