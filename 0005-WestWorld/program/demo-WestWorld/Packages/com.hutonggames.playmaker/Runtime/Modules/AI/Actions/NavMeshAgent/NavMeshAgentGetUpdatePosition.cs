
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Gets whether the transform position is synchronized with the simulated ag" +
		"ent position. The default value is true.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-updatePosition.html")]
	public sealed class NavMeshAgentGetUpdatePosition : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Update Position")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUpdatePosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getUpdatePosition);
		}
		
		public override void Execute()
		{
			_getUpdatePosition.Value = _navMeshAgent.Value.updatePosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} update position -> {_getUpdatePosition}";
		}
	}
}
