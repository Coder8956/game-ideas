/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The impact point in world space where the ray hit the collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-point.html")]
	public sealed class RaycastHitSetPoint : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Set RaycastHit Point")]
		[SerializeField]
		private Vector3Var _setPoint;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _setPoint);
		}
		
		public override void Execute()
		{
			var value = _raycastHit.Value;
			value.point = _setPoint.Value;
			_raycastHit.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_raycastHit} Point to {_setPoint}";
		}
	}
}
*/