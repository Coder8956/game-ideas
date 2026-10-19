
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SphereCollider)]
	[ActionDescription("The center of the sphere in the object\'s local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SphereCollider-center.html")]
	public sealed class SphereColliderGetCenter : BaseAction
	{
		
		[Tooltip("The SphereCollider")]
		[SerializeField]
		private SphereColliderVar _sphereCollider;
		
		[Tooltip("Get SphereCollider Center")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getCenter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_sphereCollider, _getCenter);
		}
		
		public override void Execute()
		{
			_getCenter.Value = _sphereCollider.Value.center;
		}
		
		public override string GetSummary()
		{
			return "Get {_sphereCollider} center -> {_getCenter}";
		}
	}
}
