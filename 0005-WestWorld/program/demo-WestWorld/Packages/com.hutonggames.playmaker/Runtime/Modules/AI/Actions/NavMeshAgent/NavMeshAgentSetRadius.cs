
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("The avoidance radius for the agent.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-radius.html")]
	public sealed class NavMeshAgentSetRadius : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Radius")]
		[SerializeField]
		private FloatVar _setRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setRadius);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.radius = _setRadius.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} radius to {_setRadius}";
		}
	}
}
