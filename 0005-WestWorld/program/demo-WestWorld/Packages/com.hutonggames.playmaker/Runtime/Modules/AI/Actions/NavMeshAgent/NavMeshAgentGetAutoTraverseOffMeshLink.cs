
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Should the agent move across OffMeshLinks automatically?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-autoTraverseOffMeshLink." +
		"html")]
	public sealed class NavMeshAgentGetAutoTraverseOffMeshLink : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Auto Traverse Off Mesh Link")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAutoTraverseOffMeshLink;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getAutoTraverseOffMeshLink);
		}
		
		public override void Execute()
		{
			_getAutoTraverseOffMeshLink.Value = _navMeshAgent.Value.autoTraverseOffMeshLink;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} auto traverse off mesh link -> {_getAutoTraverseOffMeshLink}";
		}
	}
}
