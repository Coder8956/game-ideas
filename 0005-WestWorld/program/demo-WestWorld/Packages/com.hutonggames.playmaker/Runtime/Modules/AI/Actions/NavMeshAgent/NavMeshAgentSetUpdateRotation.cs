
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Should the agent update the transform orientation?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-updateRotation.html")]
	public sealed class NavMeshAgentSetUpdateRotation : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Update Rotation")]
		[SerializeField]
		private BoolVar _setUpdateRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setUpdateRotation);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.updateRotation = _setUpdateRotation.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} update rotation to {_setUpdateRotation}";
		}
	}
}
