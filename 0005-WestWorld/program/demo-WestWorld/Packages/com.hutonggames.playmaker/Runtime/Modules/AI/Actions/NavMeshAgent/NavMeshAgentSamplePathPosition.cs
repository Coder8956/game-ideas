
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Sample a position along the current path.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.SamplePathPosition.html")]
	public sealed class NavMeshAgentSamplePathPosition : BaseAction
	{
		
		[Tooltip("The NavMeshAgent.")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("A bitfield mask specifying which NavMesh areas can be passed when tracing the pat" +
			"h.")]
		[SerializeField]
		private IntegerVar _areaMask;
		
		[Tooltip("Terminate scanning the path at this distance.")]
		[SerializeField]
		private FloatVar _maxDistance;
		
		[Tooltip("Holds the properties of the resulting location.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshHitRef _hit;
		
		[Tooltip("True if terminated before reaching the position at maxDistance, false otherwise.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _areaMask, _maxDistance, _hit, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMeshAgent.SamplePathPosition(System.Int32, System.Single, UnityEngine.AI.NavMeshHit&);
			_result.Value = _navMeshAgent.Value.SamplePathPosition(_areaMask.Value, _maxDistance.Value, out var outhit);
			_hit.Value = outhit;
		}
		
		public override string GetSummary()
		{
			return "Sample {_navMeshAgent} path position {_areaMask} {_maxDistance} {_hit} -> {_result}";
		}
	}
}
