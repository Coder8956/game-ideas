
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Should the agent brake automatically to avoid overshooting the destination point?" +
		"")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-autoBraking.html")]
	public sealed class NavMeshAgentSetAutoBraking : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Auto Braking")]
		[SerializeField]
		private BoolVar _setAutoBraking;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setAutoBraking);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.autoBraking = _setAutoBraking.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} auto braking to {_setAutoBraking}";
		}
	}
}
