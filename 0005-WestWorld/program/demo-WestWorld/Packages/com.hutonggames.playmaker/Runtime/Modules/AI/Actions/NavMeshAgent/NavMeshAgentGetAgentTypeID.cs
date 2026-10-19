
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("The type ID for the agent.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-agentTypeID.html")]
	public sealed class NavMeshAgentGetAgentTypeID : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Agent Type ID")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getAgentTypeID;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getAgentTypeID);
		}
		
		public override void Execute()
		{
			_getAgentTypeID.Value = _navMeshAgent.Value.agentTypeID;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} agent type ID -> {_getAgentTypeID}";
		}
	}
}
