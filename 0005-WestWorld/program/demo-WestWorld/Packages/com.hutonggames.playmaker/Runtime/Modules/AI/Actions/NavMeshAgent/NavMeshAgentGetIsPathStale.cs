
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Is the current path stale. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-isPathStale.html")]
	public sealed class NavMeshAgentGetIsPathStale : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Is Path Stale")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsPathStale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getIsPathStale);
		}
		
		public override void Execute()
		{
			_getIsPathStale.Value = _navMeshAgent.Value.isPathStale;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} is path stale -> {_getIsPathStale}";
		}
	}
}
