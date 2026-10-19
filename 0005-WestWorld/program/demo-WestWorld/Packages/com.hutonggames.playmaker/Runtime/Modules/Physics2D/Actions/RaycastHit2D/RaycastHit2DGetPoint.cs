
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit2D)]
	[ActionDescription("The point in world space where the ray hit the collider\'s surface.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit2D-point.html")]
	public sealed class RaycastHit2DGetPoint : BaseAction
	{
		
		[Tooltip("The RaycastHit2D")]
		[SerializeField]
		private RaycastHit2DRef _raycastHit2D;
		
		[Tooltip("Get RaycastHit2D Point")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getPoint;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit2D, _getPoint);
		}
		
		public override void Execute()
		{
			_getPoint.Value = _raycastHit2D.Value.point;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit2D} point -> {_getPoint}";
		}
	}
}
