
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Should the agent update the transform orientation?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-updateRotation.html")]
	public sealed class NavMeshAgentGetUpdateRotation : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Update Rotation")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUpdateRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getUpdateRotation);
		}
		
		public override void Execute()
		{
			_getUpdateRotation.Value = _navMeshAgent.Value.updateRotation;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} update rotation -> {_getUpdateRotation}";
		}
	}
}
