
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Enables or disables the current off-mesh link.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.ActivateCurrentOffMeshLi" +
		"nk.html")]
	public sealed class NavMeshAgentActivateCurrentOffMeshLink : BaseAction
	{
		
		[Tooltip("The NavMeshAgent.")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Is the link activated?")]
		[SerializeField]
		private BoolVar _activated;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _activated);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMeshAgent.ActivateCurrentOffMeshLink(System.Boolean);
			_navMeshAgent.Value.ActivateCurrentOffMeshLink(_activated.Value);
		}
		
		public override string GetSummary()
		{
			return "Activate {_navMeshAgent} current off mesh link {_activated}";
		}
	}
}
