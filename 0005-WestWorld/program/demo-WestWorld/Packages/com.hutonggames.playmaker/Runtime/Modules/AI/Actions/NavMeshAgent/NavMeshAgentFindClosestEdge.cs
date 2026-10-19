
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Locate the closest NavMesh edge.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.FindClosestEdge.html")]
	public sealed class NavMeshAgentFindClosestEdge : BaseAction
	{
		
		[Tooltip("The NavMeshAgent.")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Holds the properties of the resulting location.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshHitRef _hit;
		
		[Tooltip("True if a nearest edge is found.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _hit, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMeshAgent.FindClosestEdge(UnityEngine.AI.NavMeshHit&);
			_result.Value = _navMeshAgent.Value.FindClosestEdge(out var outhit);
			_hit.Value = outhit;
		}
		
		public override string GetSummary()
		{
			return "Find {_navMeshAgent} closest edge {_hit} -> {_result}";
		}
	}
}
