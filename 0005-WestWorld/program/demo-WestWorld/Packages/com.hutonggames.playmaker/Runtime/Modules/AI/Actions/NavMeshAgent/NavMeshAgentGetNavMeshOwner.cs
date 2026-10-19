
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Returns the owning object of the NavMesh the agent is currently placed on (Read O" +
		"nly).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-navMeshOwner.html")]
	public sealed class NavMeshAgentGetNavMeshOwner : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Nav Mesh Owner")]
		[SerializeField]
		[WriteOnly]
		private ObjectRef _getNavMeshOwner;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getNavMeshOwner);
		}
		
		public override void Execute()
		{
			_getNavMeshOwner.Value = _navMeshAgent.Value.navMeshOwner;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} NavMesh owner -> {_getNavMeshOwner}";
		}
	}
}
