
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Apply relative movement to current position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.Move.html")]
	public sealed class NavMeshAgentMove : BaseAction
	{
		
		[Tooltip("The NavMeshAgent.")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("The relative movement vector.")]
		[SerializeField]
		private Vector3Var _offset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _offset);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMeshAgent.Move(UnityEngine.Vector3);
			_navMeshAgent.Value.Move(_offset.Value);
		}
		
		public override string GetSummary()
		{
			return "Move {_navMeshAgent} by {_offset}";
		}
	}
}
