
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("The type ID for the agent.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-agentTypeID.html")]
	public sealed class NavMeshAgentSetAgentTypeID : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Agent Type ID")]
		[SerializeField]
		private IntegerVar _setAgentTypeID;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setAgentTypeID);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.agentTypeID = _setAgentTypeID.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} agent type ID to {_setAgentTypeID}";
		}
	}
}
