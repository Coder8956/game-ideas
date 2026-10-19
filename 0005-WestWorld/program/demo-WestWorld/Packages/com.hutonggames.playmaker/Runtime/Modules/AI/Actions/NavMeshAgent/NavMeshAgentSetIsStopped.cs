
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Use this property to set, or get, whether the NavMesh agent stops or continues it" +
		"s movement along the current path.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-isStopped.html")]
	public sealed class NavMeshAgentSetIsStopped : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Is Stopped")]
		[SerializeField]
		private BoolVar _setIsStopped;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setIsStopped);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.isStopped = _setIsStopped.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} is stopped to {_setIsStopped}";
		}
	}
}
