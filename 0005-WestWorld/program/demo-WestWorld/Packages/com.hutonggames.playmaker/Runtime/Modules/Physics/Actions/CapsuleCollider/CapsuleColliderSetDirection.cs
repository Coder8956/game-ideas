
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
	public sealed class CapsuleColliderSetDirection : BaseAction
	{
		
		[Tooltip("The CapsuleCollider")]
		[SerializeField]
		private CapsuleColliderVar _capsuleCollider;
		
		[Tooltip("Set CapsuleCollider Direction")]
		[SerializeField]
		private IntegerVar _setDirection;
		
		public override bool CanExecute()
		{
			return CheckParameters(_capsuleCollider, _setDirection);
		}
		
		public override void Execute()
		{
			_capsuleCollider.Value.direction = _setDirection.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_capsuleCollider} Direction to {_setDirection}";
		}
	}
}
