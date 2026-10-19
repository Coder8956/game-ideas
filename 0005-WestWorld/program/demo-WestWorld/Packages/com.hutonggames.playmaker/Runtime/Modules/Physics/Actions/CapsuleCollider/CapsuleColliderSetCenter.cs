
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CapsuleCollider)]
	[ActionDescription("The center of the capsule, measured in the object\'s local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CapsuleCollider-center.html")]
	public sealed class CapsuleColliderSetCenter : BaseAction
	{
		
		[Tooltip("The CapsuleCollider")]
		[SerializeField]
		private CapsuleColliderVar _capsuleCollider;
		
		[Tooltip("Set CapsuleCollider Center")]
		[SerializeField]
		private Vector3Var _setCenter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_capsuleCollider, _setCenter);
		}
		
		public override void Execute()
		{
			_capsuleCollider.Value.center = _setCenter.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_capsuleCollider} Center to {_setCenter}";
		}
	}
}
