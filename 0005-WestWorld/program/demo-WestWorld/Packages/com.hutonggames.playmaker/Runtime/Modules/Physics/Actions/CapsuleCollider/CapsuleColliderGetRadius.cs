
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
	public sealed class CapsuleColliderGetRadius : BaseAction
	{
		
		[Tooltip("The CapsuleCollider")]
		[SerializeField]
		private CapsuleColliderVar _capsuleCollider;
		
		[Tooltip("Get CapsuleCollider Radius")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_capsuleCollider, _getRadius);
		}
		
		public override void Execute()
		{
			_getRadius.Value = _capsuleCollider.Value.radius;
		}
		
		public override string GetSummary()
		{
			return "Get {_capsuleCollider} radius -> {_getRadius}";
		}
	}
}
