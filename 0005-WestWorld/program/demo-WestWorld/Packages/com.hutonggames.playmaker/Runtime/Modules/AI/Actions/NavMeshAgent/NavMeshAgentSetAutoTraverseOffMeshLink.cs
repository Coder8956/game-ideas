
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Should the agent move across OffMeshLinks automatically?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-autoTraverseOffMeshLink." +
		"html")]
	public sealed class NavMeshAgentSetAutoTraverseOffMeshLink : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Auto Traverse Off Mesh Link")]
		[SerializeField]
		private BoolVar _setAutoTraverseOffMeshLink;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setAutoTraverseOffMeshLink);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.autoTraverseOffMeshLink = _setAutoTraverseOffMeshLink.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} auto traverse off mesh link to {_setAutoTraverseOffMeshLink}";
		}
	}
}
