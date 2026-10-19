
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Specifies which NavMesh areas are passable. Changing areaMask will make the path " +
		"stale (see isPathStale).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-areaMask.html")]
	public sealed class NavMeshAgentSetAreaMask : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Area Mask")]
		[SerializeField]
		private IntegerVar _setAreaMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setAreaMask);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.areaMask = _setAreaMask.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} area mask to {_setAreaMask}";
		}
	}
}
