
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Sets the simulation position of the navmesh agent.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-nextPosition.html")]
	public sealed class NavMeshAgentSetNextPosition : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Next Position")]
		[SerializeField]
		private Vector3Var _setNextPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setNextPosition);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.nextPosition = _setNextPosition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} next position to {_setNextPosition}";
		}
	}
}
