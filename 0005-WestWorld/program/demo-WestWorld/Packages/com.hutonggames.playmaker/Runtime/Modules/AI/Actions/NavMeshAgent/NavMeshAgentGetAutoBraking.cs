
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Should the agent brake automatically to avoid overshooting the destination point?" +
		"")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-autoBraking.html")]
	public sealed class NavMeshAgentGetAutoBraking : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Auto Braking")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAutoBraking;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getAutoBraking);
		}
		
		public override void Execute()
		{
			_getAutoBraking.Value = _navMeshAgent.Value.autoBraking;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} auto braking -> {_getAutoBraking}";
		}
	}
}
