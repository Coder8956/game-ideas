
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SphereCollider)]
	[ActionDescription("The radius of the sphere measured in the object\'s local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SphereCollider-radius.html")]
	public sealed class SphereColliderGetRadius : BaseAction
	{
		
		[Tooltip("The SphereCollider")]
		[SerializeField]
		private SphereColliderVar _sphereCollider;
		
		[Tooltip("Get SphereCollider Radius")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_sphereCollider, _getRadius);
		}
		
		public override void Execute()
		{
			_getRadius.Value = _sphereCollider.Value.radius;
		}
		
		public override string GetSummary()
		{
			return "Get {_sphereCollider} radius -> {_getRadius}";
		}
	}
}
