
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Access the current velocity of the NavMeshAgent component, or set a velocity to c" +
		"ontrol the agent manually.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-velocity.html")]
	public sealed class NavMeshAgentGetVelocity : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Velocity")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getVelocity);
		}
		
		public override void Execute()
		{
			_getVelocity.Value = _navMeshAgent.Value.velocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} velocity -> {_getVelocity}";
		}
	}
}
