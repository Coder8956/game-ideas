
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Sets or updates the destination thus triggering the calculation for a new path.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.SetDestination.html")]
	public sealed class NavMeshAgentSetDestination1 : BaseAction
	{
		
		[Tooltip("The NavMeshAgent.")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("The target point to navigate to.")]
		[SerializeField]
		private Vector3Var _target;
		
		[Tooltip("True if the destination was requested successfully, otherwise false.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _target, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMeshAgent.SetDestination(UnityEngine.Vector3);
			_result.Value = _navMeshAgent.Value.SetDestination(_target.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} destination to {_target} -> {_result}";
		}
	}
}
