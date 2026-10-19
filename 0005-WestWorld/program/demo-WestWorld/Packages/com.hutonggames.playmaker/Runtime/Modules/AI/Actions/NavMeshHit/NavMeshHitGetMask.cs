
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshHit)]
	[ActionDescription("Mask specifying NavMesh area at point of hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshHit-mask.html")]
	public sealed class NavMeshHitGetMask : BaseAction
	{
		
		[Tooltip("The NavMeshHit")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshHitRef _navMeshHit;
		
		[Tooltip("Get NavMeshHit Mask")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.IntegerRef _getMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshHit, _getMask);
		}
		
		public override void Execute()
		{
			this._getMask.Value = this._navMeshHit.Value.mask;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshHit} Mask -> {_getMask}";
		}
	}
}
