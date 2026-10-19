
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
	public sealed class NavMeshAgentGetObstacleAvoidanceType : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Obstacle Avoidance Type")]
		[SerializeField]
		[WriteOnly]
		private ObstacleAvoidanceTypeRef _getObstacleAvoidanceType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getObstacleAvoidanceType);
		}
		
		public override void Execute()
		{
			_getObstacleAvoidanceType.Value = _navMeshAgent.Value.obstacleAvoidanceType;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} obstacle avoidance type -> {_getObstacleAvoidanceType}";
		}
	}
}
