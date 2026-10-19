
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Stop within this distance from the target position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-stoppingDistance.html")]
	public sealed class NavMeshAgentGetStoppingDistance : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Stopping Distance")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getStoppingDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getStoppingDistance);
		}
		
		public override void Execute()
		{
			_getStoppingDistance.Value = _navMeshAgent.Value.stoppingDistance;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} stopping distance -> {_getStoppingDistance}";
		}
	}
}
