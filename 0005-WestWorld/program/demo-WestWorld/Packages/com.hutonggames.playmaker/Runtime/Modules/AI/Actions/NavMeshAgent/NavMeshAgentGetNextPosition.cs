
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Gets the simulation position of the navmesh agent.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-nextPosition.html")]
	public sealed class NavMeshAgentGetNextPosition : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Next Position")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getNextPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getNextPosition);
		}
		
		public override void Execute()
		{
			_getNextPosition.Value = _navMeshAgent.Value.nextPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} next position -> {_getNextPosition}";
		}
	}
}
