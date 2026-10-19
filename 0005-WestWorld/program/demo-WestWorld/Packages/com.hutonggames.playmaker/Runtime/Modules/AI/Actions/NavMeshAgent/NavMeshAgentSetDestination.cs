
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Gets or attempts to set the destination of the agent in world-space units.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-destination.html")]
	public sealed class NavMeshAgentSetDestination : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Destination")]
		[SerializeField]
		private Vector3Var _setDestination;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setDestination);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.destination = _setDestination.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} destination to {_setDestination}";
		}
	}
}
