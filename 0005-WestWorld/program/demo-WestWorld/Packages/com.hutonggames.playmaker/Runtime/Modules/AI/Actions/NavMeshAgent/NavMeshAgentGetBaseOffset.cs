
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("The relative vertical displacement of the owning GameObject.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-baseOffset.html")]
	public sealed class NavMeshAgentGetBaseOffset : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Base Offset")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getBaseOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getBaseOffset);
		}
		
		public override void Execute()
		{
			_getBaseOffset.Value = _navMeshAgent.Value.baseOffset;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} base offset -> {_getBaseOffset}";
		}
	}
}
