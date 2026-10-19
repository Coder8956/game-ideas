
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Should the agent attempt to acquire a new path if the existing path becomes inval" +
		"id?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-autoRepath.html")]
	public sealed class NavMeshAgentGetAutoRepath : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Auto Repath")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAutoRepath;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getAutoRepath);
		}
		
		public override void Execute()
		{
			_getAutoRepath.Value = _navMeshAgent.Value.autoRepath;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} auto repath -> {_getAutoRepath}";
		}
	}
}
