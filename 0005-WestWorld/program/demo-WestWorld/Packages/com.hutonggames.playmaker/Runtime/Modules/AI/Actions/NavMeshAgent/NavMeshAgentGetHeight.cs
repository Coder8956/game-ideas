
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("The height of the agent for purposes of passing under obstacles, etc.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-height.html")]
	public sealed class NavMeshAgentGetHeight : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Height")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getHeight);
		}
		
		public override void Execute()
		{
			_getHeight.Value = _navMeshAgent.Value.height;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} height -> {_getHeight}";
		}
	}
}
