
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Should the agent attempt to acquire a new path if the existing path becomes inval" +
		"id?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-autoRepath.html")]
	public sealed class NavMeshAgentSetAutoRepath : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Auto Repath")]
		[SerializeField]
		private BoolVar _setAutoRepath;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setAutoRepath);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.autoRepath = _setAutoRepath.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} auto repath to {_setAutoRepath}";
		}
	}
}
