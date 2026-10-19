
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Trace a straight path towards a target position in the NavMesh without moving the" +
		" agent.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.Raycast.html")]
	public sealed class NavMeshAgentRaycast : BaseAction
	{
		
		[Tooltip("The NavMeshAgent.")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("The desired end position of movement.")]
		[SerializeField]
		private Vector3Var _targetPosition;
		
		[Tooltip("Properties of the obstacle detected by the ray (if any).")]
		[SerializeField]
		[WriteOnly]
		private NavMeshHitRef _hit;
		
		[Tooltip("True if there is an obstacle between the agent and the target position, otherwise" +
			" false.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _targetPosition, _hit, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMeshAgent.Raycast(UnityEngine.Vector3, UnityEngine.AI.NavMeshHit&);
			_result.Value = _navMeshAgent.Value.Raycast(_targetPosition.Value, out var outhit);
			_hit.Value = outhit;
		}
		
		public override string GetSummary()
		{
			return "Raycast {_navMeshAgent} to {_targetPosition} {_hit} -> {_result}";
		}
	}
}
