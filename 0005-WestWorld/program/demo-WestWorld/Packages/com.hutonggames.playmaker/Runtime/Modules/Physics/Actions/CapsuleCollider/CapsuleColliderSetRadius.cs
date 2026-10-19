
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CapsuleCollider)]
	[ActionDescription("The radius of the sphere, measured in the object\'s local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CapsuleCollider-radius.html")]
	public sealed class CapsuleColliderSetRadius : BaseAction
	{
		
		[Tooltip("The CapsuleCollider")]
		[SerializeField]
		private CapsuleColliderVar _capsuleCollider;
		
		[Tooltip("Set CapsuleCollider Radius")]
		[SerializeField]
		private FloatVar _setRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_capsuleCollider, _setRadius);
		}
		
		public override void Execute()
		{
			_capsuleCollider.Value.radius = _setRadius.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_capsuleCollider} Radius to {_setRadius}";
		}
	}
}
