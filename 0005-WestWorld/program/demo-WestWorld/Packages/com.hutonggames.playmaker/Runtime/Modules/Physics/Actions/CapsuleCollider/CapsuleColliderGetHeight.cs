
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CapsuleCollider)]
	[ActionDescription("The height of the capsule measured in the object\'s local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CapsuleCollider-height.html")]
	public sealed class CapsuleColliderGetHeight : BaseAction
	{
		
		[Tooltip("The CapsuleCollider")]
		[SerializeField]
		private CapsuleColliderVar _capsuleCollider;
		
		[Tooltip("Get CapsuleCollider Height")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_capsuleCollider, _getHeight);
		}
		
		public override void Execute()
		{
			_getHeight.Value = _capsuleCollider.Value.height;
		}
		
		public override string GetSummary()
		{
			return "Get {_capsuleCollider} height -> {_getHeight}";
		}
	}
}
