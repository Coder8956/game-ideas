
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Allows you to specify whether the agent should be aligned to the up-axis of the N" +
		"avMesh or link that it is placed on.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-updateUpAxis.html")]
	public sealed class NavMeshAgentSetUpdateUpAxis : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Update Up Axis")]
		[SerializeField]
		private BoolVar _setUpdateUpAxis;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setUpdateUpAxis);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.updateUpAxis = _setUpdateUpAxis.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} update up axis to {_setUpdateUpAxis}";
		}
	}
}
