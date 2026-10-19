
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("The maximum acceleration of an agent as it follows a path, given in units / sec^2" +
		".")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-acceleration.html")]
	public sealed class NavMeshAgentSetAcceleration : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Acceleration")]
		[SerializeField]
		private FloatVar _setAcceleration;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setAcceleration);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.acceleration = _setAcceleration.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} acceleration to {_setAcceleration}";
		}
	}
}
