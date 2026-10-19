
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Is the agent currently positioned on an OffMeshLink? (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-isOnOffMeshLink.html")]
	public sealed class NavMeshAgentGetIsOnOffMeshLink : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Is On Off Mesh Link")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsOnOffMeshLink;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getIsOnOffMeshLink);
		}
		
		public override void Execute()
		{
			_getIsOnOffMeshLink.Value = _navMeshAgent.Value.isOnOffMeshLink;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} is on off mesh link -> {_getIsOnOffMeshLink}";
		}
	}
}
