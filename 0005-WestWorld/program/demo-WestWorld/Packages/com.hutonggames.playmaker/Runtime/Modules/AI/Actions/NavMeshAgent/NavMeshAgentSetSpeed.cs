
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Maximum movement speed when following a path.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-speed.html")]
	public sealed class NavMeshAgentSetSpeed : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Speed")]
		[SerializeField]
		private FloatVar _setSpeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setSpeed);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.speed = _setSpeed.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} speed to {_setSpeed}";
		}
	}
}
