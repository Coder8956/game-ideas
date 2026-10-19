
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ConvertibleGroup("NavMeshAgentSetPath")]
	[ActionDescription("Property to get and set the current path.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-path.html")]
	public sealed class NavMeshAgentSetPath : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Path")]
		[SerializeField]
		private NavMeshPathRef _setPath;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setPath);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.path = _setPath.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} path to {_setPath}";
		}
	}
}
