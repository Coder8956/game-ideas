
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Assign a new path to this agent.")]
	[ConvertibleGroup("NavMeshAgentSetPath")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.SetPath.html")]
	public sealed class NavMeshAgentSetPath__Result : BaseAction
	{
		
		[Tooltip("The NavMeshAgent.")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("New path to follow.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshPathRef _path;
		
		[Tooltip("True if the path is successfully assigned.")]
		[SerializeField]
		[WriteOnly,OptionalField]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _path);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMeshAgent.SetPath(UnityEngine.AI.NavMeshPath);
			var result = _navMeshAgent.Value.SetPath(_path.Value);
			if (_result.IsAssigned) _result.Value = result;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} path {_path} -> {_result}";
		}
	}
}
