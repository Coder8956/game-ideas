
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SphereCollider)]
	[ActionDescription("The center of the sphere in the object\'s local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SphereCollider-center.html")]
	public sealed class SphereColliderSetCenter : BaseAction
	{
		
		[Tooltip("The SphereCollider")]
		[SerializeField]
		private SphereColliderVar _sphereCollider;
		
		[Tooltip("Set SphereCollider Center")]
		[SerializeField]
		private Vector3Var _setCenter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_sphereCollider, _setCenter);
		}
		
		public override void Execute()
		{
			_sphereCollider.Value.center = _setCenter.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_sphereCollider} Center to {_setCenter}";
		}
	}
}
