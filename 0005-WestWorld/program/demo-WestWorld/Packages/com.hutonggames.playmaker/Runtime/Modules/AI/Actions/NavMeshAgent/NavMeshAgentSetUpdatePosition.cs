
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Sets whether the transform position is synchronized with the simulated ag" +
		"ent position. The default value is true.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-updatePosition.html")]
	public sealed class NavMeshAgentSetUpdatePosition : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Update Position")]
		[SerializeField]
		private BoolVar _setUpdatePosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setUpdatePosition);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.updatePosition = _setUpdatePosition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} update position to {_setUpdatePosition}";
		}
	}
}
