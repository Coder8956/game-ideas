
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Maximum movement speed when following a path.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-speed.html")]
	public sealed class NavMeshAgentGetSpeed : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Get NavMeshAgent Speed")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getSpeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _getSpeed);
		}
		
		public override void Execute()
		{
			_getSpeed.Value = _navMeshAgent.Value.speed;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} speed -> {_getSpeed}";
		}
	}
}
