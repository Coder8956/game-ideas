/*
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshHit)]
	[ActionDescription("Distance to the point of hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshHit-distance.html")]
	public sealed class NavMeshHitSetDistance : BaseAction
	{
		
		[Tooltip("The NavMeshHit")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshHitRef _navMeshHit;
		
		[Tooltip("Set NavMeshHit Distance")]
		[SerializeField]
		private HutongGames.PlayMaker.FloatVar _setDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshHit, _setDistance);
		}
		
		public override void Execute()
		{
			var value = this._navMeshHit.Value;
			value.distance = this._setDistance.Value;
			this._navMeshHit.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshHit} Distance to {_setDistance}";
		}
	}
}
*/