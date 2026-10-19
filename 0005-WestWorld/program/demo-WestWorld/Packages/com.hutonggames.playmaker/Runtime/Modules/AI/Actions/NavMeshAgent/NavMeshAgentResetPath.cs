
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Clears the current path.")]
	[ConvertibleGroup("NavMeshAgentSetPath")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.ResetPath.html")]
	public sealed class NavMeshAgentResetPath : BaseAction
	{
		
		[Tooltip("The NavMeshAgent.")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMeshAgent.ResetPath();
			_navMeshAgent.Value.ResetPath();
		}
		
		public override string GetSummary()
		{
			return "Reset {_navMeshAgent} path";
		}
	}
}
