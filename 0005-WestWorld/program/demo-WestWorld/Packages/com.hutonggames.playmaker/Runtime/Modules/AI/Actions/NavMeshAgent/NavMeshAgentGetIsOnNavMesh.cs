
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Is the agent currently bound to the navmesh? (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-isOnNavMesh.html")]
	public sealed class NavMeshAgentGetIsOnNavMesh : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Is On Nav Mesh")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsOnNavMesh;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getIsOnNavMesh);
		}
		
		public override void Execute()
		{
			_getIsOnNavMesh.Value = _navMeshAgent.Value.isOnNavMesh;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} is on NavMesh -> {_getIsOnNavMesh}";
		}
	}
}
