
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Maximum turning speed in (deg/s) while following a path.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-angularSpeed.html")]
	public sealed class NavMeshAgentGetAngularSpeed : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Angular Speed")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getAngularSpeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getAngularSpeed);
		}
		
		public override void Execute()
		{
			_getAngularSpeed.Value = _navMeshAgent.Value.angularSpeed;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} angular speed -> {_getAngularSpeed}";
		}
	}
}
