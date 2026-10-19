
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Use this property to set, or get, whether the NavMesh agent stops or continues it" +
		"s movement along the current path.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-isStopped.html")]
	public sealed class NavMeshAgentGetIsStopped : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Is Stopped")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsStopped;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getIsStopped);
		}
		
		public override void Execute()
		{
			_getIsStopped.Value = _navMeshAgent.Value.isStopped;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} is stopped -> {_getIsStopped}";
		}
	}
}
