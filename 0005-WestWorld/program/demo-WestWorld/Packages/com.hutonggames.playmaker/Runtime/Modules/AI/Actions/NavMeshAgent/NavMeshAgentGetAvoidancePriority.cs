
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("The avoidance priority level.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-avoidancePriority.html")]
	public sealed class NavMeshAgentGetAvoidancePriority : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Avoidance Priority")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getAvoidancePriority;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getAvoidancePriority);
		}
		
		public override void Execute()
		{
			_getAvoidancePriority.Value = _navMeshAgent.Value.avoidancePriority;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} avoidance priority -> {_getAvoidancePriority}";
		}
	}
}
