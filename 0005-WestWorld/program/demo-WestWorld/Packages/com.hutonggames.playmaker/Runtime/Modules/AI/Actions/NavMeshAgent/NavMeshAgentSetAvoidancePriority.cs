
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("The avoidance priority level.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-avoidancePriority.html")]
	public sealed class NavMeshAgentSetAvoidancePriority : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Avoidance Priority")]
		[SerializeField]
		private IntegerVar _setAvoidancePriority;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setAvoidancePriority);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.avoidancePriority = _setAvoidancePriority.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} avoidance priority to {_setAvoidancePriority}";
		}
	}
}
