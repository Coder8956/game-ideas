
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Stop within this distance from the target position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-stoppingDistance.html")]
	public sealed class NavMeshAgentSetStoppingDistance : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Stopping Distance")]
		[SerializeField]
		private FloatVar _setStoppingDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setStoppingDistance);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.stoppingDistance = _setStoppingDistance.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} stopping distance to {_setStoppingDistance}";
		}
	}
}
