
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CapsuleCollider)]
	[ActionDescription("The direction of the capsule.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CapsuleCollider-direction.html")]
	public sealed class CapsuleColliderGetDirection : BaseAction
	{
		
		[Tooltip("The CapsuleCollider")]
		[SerializeField]
		private CapsuleColliderVar _capsuleCollider;
		
		[Tooltip("Get CapsuleCollider Direction")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getDirection;
		
		public override bool CanExecute()
		{
			return CheckParameters(_capsuleCollider, _getDirection);
		}
		
		public override void Execute()
		{
			_getDirection.Value = _capsuleCollider.Value.direction;
		}
		
		public override string GetSummary()
		{
			return "Get {_capsuleCollider} direction -> {_getDirection}";
		}
	}
}
