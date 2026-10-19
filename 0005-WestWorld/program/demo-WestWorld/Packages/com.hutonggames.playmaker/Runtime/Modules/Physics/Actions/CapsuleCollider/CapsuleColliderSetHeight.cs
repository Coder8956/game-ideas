
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
	public sealed class CapsuleColliderSetHeight : BaseAction
	{
		
		[Tooltip("The CapsuleCollider")]
		[SerializeField]
		private CapsuleColliderVar _capsuleCollider;
		
		[Tooltip("Set CapsuleCollider Height")]
		[SerializeField]
		private FloatVar _setHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_capsuleCollider, _setHeight);
		}
		
		public override void Execute()
		{
			_capsuleCollider.Value.height = _setHeight.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_capsuleCollider} Height to {_setHeight}";
		}
	}
}
