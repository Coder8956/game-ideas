
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshHit)]
	[ActionDescription("Position of hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshHit-position.html")]
	public sealed class NavMeshHitGetPosition : BaseAction
	{
		
		[Tooltip("The NavMeshHit")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshHitRef _navMeshHit;
		
		[Tooltip("Get NavMeshHit Position")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.Vector3Ref _getPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshHit, _getPosition);
		}
		
		public override void Execute()
		{
			this._getPosition.Value = this._navMeshHit.Value.position;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshHit} Position -> {_getPosition}";
		}
	}
}
