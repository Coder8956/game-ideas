
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The normal of the surface the ray hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-normal.html")]
	public sealed class RaycastHitGetNormal : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Get RaycastHit Normal")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getNormal;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _getNormal);
		}
		
		public override void Execute()
		{
			_getNormal.Value = _raycastHit.Value.normal;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit} Normal -> {_getNormal}";
		}
	}
}
