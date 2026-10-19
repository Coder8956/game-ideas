
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Is a path in the process of being computed but not yet ready? (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-pathPending.html")]
	public sealed class NavMeshAgentGetPathPending : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Path Pending")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getPathPending;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getPathPending);
		}
		
		public override void Execute()
		{
			_getPathPending.Value = _navMeshAgent.Value.pathPending;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} path pending -> {_getPathPending}";
		}
	}
}
