
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("The level of quality of avoidance.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-obstacleAvoidanceType.ht" +
		"ml")]
	public sealed class NavMeshAgentSetObstacleAvoidanceType : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Obstacle Avoidance Type")]
		[SerializeField]
		private ObstacleAvoidanceTypeVar _setObstacleAvoidanceType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setObstacleAvoidanceType);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.obstacleAvoidanceType = _setObstacleAvoidanceType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} obstacle avoidance type to {_setObstacleAvoidanceType}";
		}
	}
}
