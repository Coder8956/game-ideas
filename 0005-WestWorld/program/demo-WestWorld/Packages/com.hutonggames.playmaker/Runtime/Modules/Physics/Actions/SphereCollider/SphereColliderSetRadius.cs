
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
	public sealed class SphereColliderSetRadius : BaseAction
	{
		
		[Tooltip("The SphereCollider")]
		[SerializeField]
		private SphereColliderVar _sphereCollider;
		
		[Tooltip("Set SphereCollider Radius")]
		[SerializeField]
		private FloatVar _setRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_sphereCollider, _setRadius);
		}
		
		public override void Execute()
		{
			_sphereCollider.Value.radius = _setRadius.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_sphereCollider} Radius to {_setRadius}";
		}
	}
}
