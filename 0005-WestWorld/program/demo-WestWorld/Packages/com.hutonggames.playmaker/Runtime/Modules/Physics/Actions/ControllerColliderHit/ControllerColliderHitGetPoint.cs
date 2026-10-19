
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ControllerColliderHit)]
	[ActionDescription("The impact point in world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ControllerColliderHit-point.html")]
	public sealed class ControllerColliderHitGetPoint : BaseAction
	{
		
		[Tooltip("The ControllerColliderHit")]
		[SerializeField]
		private ControllerColliderHitRef _controllerColliderHit;
		
		[Tooltip("Get ControllerColliderHit Point")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getPoint;
		
		public override bool CanExecute()
		{
			return CheckParameters(_controllerColliderHit, _getPoint);
		}
		
		public override void Execute()
		{
			_getPoint.Value = _controllerColliderHit.Value.point;
		}
		
		public override string GetSummary()
		{
			return "Get {_controllerColliderHit} point -> {_getPoint}";
		}
	}
}
