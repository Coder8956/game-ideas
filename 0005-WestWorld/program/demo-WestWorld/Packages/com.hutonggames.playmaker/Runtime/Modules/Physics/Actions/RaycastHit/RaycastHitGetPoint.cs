
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The impact point in world space where the ray hit the collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-point.html")]
	public sealed class RaycastHitGetPoint : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Get RaycastHit Point")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getPoint;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _getPoint);
		}
		
		public override void Execute()
		{
			_getPoint.Value = _raycastHit.Value.point;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit} Point -> {_getPoint}";
		}
	}
}
