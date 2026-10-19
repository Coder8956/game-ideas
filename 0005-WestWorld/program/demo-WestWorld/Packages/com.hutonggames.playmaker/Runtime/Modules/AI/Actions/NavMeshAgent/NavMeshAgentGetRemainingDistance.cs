
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("The distance between the agent\'s position and the destination on the current path" +
		". (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-remainingDistance.html")]
	public sealed class NavMeshAgentGetRemainingDistance : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Remaining Distance")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getRemainingDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getRemainingDistance);
		}
		
		public override void Execute()
		{
			_getRemainingDistance.Value = _navMeshAgent.Value.remainingDistance;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} remaining distance -> {_getRemainingDistance}";
		}
	}
}
