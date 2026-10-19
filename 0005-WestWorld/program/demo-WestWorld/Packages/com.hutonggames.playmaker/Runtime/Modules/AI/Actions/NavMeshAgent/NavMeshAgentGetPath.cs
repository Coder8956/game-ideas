
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Property to get and set the current path.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-path.html")]
	public sealed class NavMeshAgentGetPath : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Path")]
		[SerializeField]
		[WriteOnly]
		private NavMeshPathRef _getPath;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getPath);
		}
		
		public override void Execute()
		{
			_getPath.Value = _navMeshAgent.Value.path;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} path -> {_getPath}";
		}
	}
}
