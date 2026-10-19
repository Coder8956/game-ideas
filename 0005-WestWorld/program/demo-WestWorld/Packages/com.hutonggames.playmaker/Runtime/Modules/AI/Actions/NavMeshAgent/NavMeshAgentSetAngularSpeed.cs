
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Maximum turning speed in (deg/s) while following a path.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-angularSpeed.html")]
	public sealed class NavMeshAgentSetAngularSpeed : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Angular Speed")]
		[SerializeField]
		private FloatVar _setAngularSpeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setAngularSpeed);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.angularSpeed = _setAngularSpeed.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} angular speed to {_setAngularSpeed}";
		}
	}
}
