
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Get the current steering target along the path. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-steeringTarget.html")]
	public sealed class NavMeshAgentGetSteeringTarget : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Steering Target")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getSteeringTarget;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getSteeringTarget);
		}
		
		public override void Execute()
		{
			_getSteeringTarget.Value = _navMeshAgent.Value.steeringTarget;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} steering target -> {_getSteeringTarget}";
		}
	}
}
