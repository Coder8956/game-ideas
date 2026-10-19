
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Get the end position of the current path.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html")]
	public sealed class NavMeshAgentGetPathEndPosition : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Path End Position")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getPathEndPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getPathEndPosition);
		}
		
		public override void Execute()
		{
			_getPathEndPosition.Value = _navMeshAgent.Value.pathEndPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} path end position -> {_getPathEndPosition}";
		}
	}
}


