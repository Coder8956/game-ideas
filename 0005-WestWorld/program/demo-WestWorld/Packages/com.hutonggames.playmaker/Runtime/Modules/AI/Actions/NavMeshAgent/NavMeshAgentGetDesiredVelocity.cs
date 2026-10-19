
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("The desired velocity of the agent including any potential contribution from avoid" +
		"ance. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-desiredVelocity.html")]
	public sealed class NavMeshAgentGetDesiredVelocity : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Desired Velocity")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getDesiredVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getDesiredVelocity);
		}
		
		public override void Execute()
		{
			_getDesiredVelocity.Value = _navMeshAgent.Value.desiredVelocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} desired velocity -> {_getDesiredVelocity}";
		}
	}
}
