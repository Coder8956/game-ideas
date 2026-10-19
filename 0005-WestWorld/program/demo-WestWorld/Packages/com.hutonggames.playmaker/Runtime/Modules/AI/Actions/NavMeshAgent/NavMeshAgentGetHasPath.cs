
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Does the agent currently have a path? (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-hasPath.html")]
	public sealed class NavMeshAgentGetHasPath : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Has Path")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getHasPath;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getHasPath);
		}
		
		public override void Execute()
		{
			_getHasPath.Value = _navMeshAgent.Value.hasPath;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} has path -> {_getHasPath}";
		}
	}
}
