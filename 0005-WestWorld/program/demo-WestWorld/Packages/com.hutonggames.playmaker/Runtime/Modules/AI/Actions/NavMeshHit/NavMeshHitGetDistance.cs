
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshHit)]
	[ActionDescription("Distance to the point of hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshHit-distance.html")]
	public sealed class NavMeshHitGetDistance : BaseAction
	{
		
		[Tooltip("The NavMeshHit")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshHitRef _navMeshHit;
		
		[Tooltip("Get NavMeshHit Distance")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.FloatRef _getDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshHit, _getDistance);
		}
		
		public override void Execute()
		{
			this._getDistance.Value = this._navMeshHit.Value.distance;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshHit} Distance -> {_getDistance}";
		}
	}
}
