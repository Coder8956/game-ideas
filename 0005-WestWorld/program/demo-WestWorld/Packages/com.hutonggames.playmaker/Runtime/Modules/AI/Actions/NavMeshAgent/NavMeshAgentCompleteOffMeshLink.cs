
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Completes the movement on the current OffMeshLink.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.CompleteOffMeshLink.html" +
		"")]
	public sealed class NavMeshAgentCompleteOffMeshLink : BaseAction
	{
		
		[Tooltip("The NavMeshAgent.")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMeshAgent.CompleteOffMeshLink();
			_navMeshAgent.Value.CompleteOffMeshLink();
		}
		
		public override string GetSummary()
		{
			return "Complete {_navMeshAgent} off mesh link";
		}
	}
}
