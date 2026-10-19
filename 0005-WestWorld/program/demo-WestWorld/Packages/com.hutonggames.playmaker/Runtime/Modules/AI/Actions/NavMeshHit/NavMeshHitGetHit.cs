
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshHit)]
	[ActionDescription("Flag set when hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshHit-hit.html")]
	public sealed class NavMeshHitGetHit : BaseAction
	{
		
		[Tooltip("The NavMeshHit")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshHitRef _navMeshHit;
		
		[Tooltip("Get NavMeshHit Hit")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.BoolRef _getHit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshHit, _getHit);
		}
		
		public override void Execute()
		{
			this._getHit.Value = this._navMeshHit.Value.hit;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshHit} Hit -> {_getHit}";
		}
	}
}
