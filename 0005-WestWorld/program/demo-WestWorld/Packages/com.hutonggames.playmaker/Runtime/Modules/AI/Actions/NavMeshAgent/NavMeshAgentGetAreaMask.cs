
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Specifies which NavMesh areas are passable. Changing areaMask will make the path " +
		"stale (see isPathStale).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-areaMask.html")]
	public sealed class NavMeshAgentGetAreaMask : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Area Mask")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getAreaMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getAreaMask);
		}
		
		public override void Execute()
		{
			_getAreaMask.Value = _navMeshAgent.Value.areaMask;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} area mask -> {_getAreaMask}";
		}
	}
}
