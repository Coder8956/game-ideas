
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("The maximum acceleration of an agent as it follows a path, given in units / sec^2" +
		".")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-acceleration.html")]
	public sealed class NavMeshAgentGetAcceleration : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Acceleration")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getAcceleration;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getAcceleration);
		}
		
		public override void Execute()
		{
			_getAcceleration.Value = _navMeshAgent.Value.acceleration;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} acceleration -> {_getAcceleration}";
		}
	}
}
