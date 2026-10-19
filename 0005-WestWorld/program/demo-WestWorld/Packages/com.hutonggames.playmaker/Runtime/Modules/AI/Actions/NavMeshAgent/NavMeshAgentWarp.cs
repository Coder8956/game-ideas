
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Warps agent to the provided position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.Warp.html")]
	public sealed class NavMeshAgentWarp : BaseAction
	{
		
		[Tooltip("The NavMeshAgent.")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("New position to warp the agent to.")]
		[SerializeField]
		private Vector3Var _newPosition;
		
		[Tooltip("True if agent is successfully warped, otherwise false.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _newPosition, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMeshAgent.Warp(UnityEngine.Vector3);
			_result.Value = _navMeshAgent.Value.Warp(_newPosition.Value);
		}
		
		public override string GetSummary()
		{
			return "Warp {_navMeshAgent} to {_newPosition} -> {_result}";
		}
	}
}
