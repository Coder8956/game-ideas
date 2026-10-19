
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Access the current velocity of the NavMeshAgent component, or set a velocity to c" +
		"ontrol the agent manually.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-velocity.html")]
	public sealed class NavMeshAgentSetVelocity : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Velocity")]
		[SerializeField]
		private Vector3Var _setVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setVelocity);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.velocity = _setVelocity.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} velocity to {_setVelocity}";
		}
	}
}
