
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("The avoidance radius for the agent.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-radius.html")]
	public sealed class NavMeshAgentGetRadius : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Radius")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getRadius);
		}
		
		public override void Execute()
		{
			_getRadius.Value = _navMeshAgent.Value.radius;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} radius -> {_getRadius}";
		}
	}
}
