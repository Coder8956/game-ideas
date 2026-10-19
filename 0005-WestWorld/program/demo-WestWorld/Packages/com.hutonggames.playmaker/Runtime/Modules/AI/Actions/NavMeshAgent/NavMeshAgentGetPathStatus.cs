
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("The status of the current path (complete, partial or invalid).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-pathStatus.html")]
	public sealed class NavMeshAgentGetPathStatus : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Path Status")]
		[SerializeField]
		[WriteOnly]
		private NavMeshPathStatusRef _getPathStatus;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getPathStatus);
		}
		
		public override void Execute()
		{
			_getPathStatus.Value = _navMeshAgent.Value.pathStatus;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} path status -> {_getPathStatus}";
		}
	}
}
