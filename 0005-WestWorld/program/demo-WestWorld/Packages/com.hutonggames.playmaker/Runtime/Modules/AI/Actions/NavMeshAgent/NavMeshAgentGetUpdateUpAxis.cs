
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Allows you to specify whether the agent should be aligned to the up-axis of the N" +
		"avMesh or link that it is placed on.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-updateUpAxis.html")]
	public sealed class NavMeshAgentGetUpdateUpAxis : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Update Up Axis")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUpdateUpAxis;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getUpdateUpAxis);
		}
		
		public override void Execute()
		{
			_getUpdateUpAxis.Value = _navMeshAgent.Value.updateUpAxis;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} update up axis -> {_getUpdateUpAxis}";
		}
	}
}
