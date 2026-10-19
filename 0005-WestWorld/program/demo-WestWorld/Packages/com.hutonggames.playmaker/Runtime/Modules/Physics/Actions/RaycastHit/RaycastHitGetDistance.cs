
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The distance from the ray\'s origin to the impact point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-distance.html")]
	public sealed class RaycastHitGetDistance : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Get RaycastHit Distance")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _getDistance);
		}
		
		public override void Execute()
		{
			_getDistance.Value = _raycastHit.Value.distance;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit} Distance -> {_getDistance}";
		}
	}
}
