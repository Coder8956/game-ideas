
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("The height of the agent for purposes of passing under obstacles, etc.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-height.html")]
	public sealed class NavMeshAgentSetHeight : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Height")]
		[SerializeField]
		private FloatVar _setHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setHeight);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.height = _setHeight.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} height to {_setHeight}";
		}
	}
}
