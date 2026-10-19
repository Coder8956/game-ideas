
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit2D)]
	[ActionDescription("The distance from the ray origin to the impact point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit2D-distance.html")]
	public sealed class RaycastHit2DGetDistance : BaseAction
	{
		
		[Tooltip("The RaycastHit2D")]
		[SerializeField]
		private RaycastHit2DRef _raycastHit2D;
		
		[Tooltip("Get RaycastHit2D Distance")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit2D, _getDistance);
		}
		
		public override void Execute()
		{
			_getDistance.Value = _raycastHit2D.Value.distance;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit2D} distance -> {_getDistance}";
		}
	}
}
