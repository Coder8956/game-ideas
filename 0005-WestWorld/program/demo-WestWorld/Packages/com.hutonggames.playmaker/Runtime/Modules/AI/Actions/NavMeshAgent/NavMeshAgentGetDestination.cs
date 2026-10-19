
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Gets or attempts to set the destination of the agent in world-space units.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-destination.html")]
	public sealed class NavMeshAgentGetDestination : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Destination")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getDestination;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getDestination);
		}
		
		public override void Execute()
		{
			_getDestination.Value = _navMeshAgent.Value.destination;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} destination -> {_getDestination}";
		}
	}
}
