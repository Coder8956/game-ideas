
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CapsuleCollider)]
	[ActionDescription("The center of the capsule, measured in the object\'s local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CapsuleCollider-center.html")]
	public sealed class CapsuleColliderGetCenter : BaseAction
	{
		
		[Tooltip("The CapsuleCollider")]
		[SerializeField]
		private CapsuleColliderVar _capsuleCollider;
		
		[Tooltip("Get CapsuleCollider Center")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getCenter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_capsuleCollider, _getCenter);
		}
		
		public override void Execute()
		{
			_getCenter.Value = _capsuleCollider.Value.center;
		}
		
		public override string GetSummary()
		{
			return "Get {_capsuleCollider} center -> {_getCenter}";
		}
	}
}
