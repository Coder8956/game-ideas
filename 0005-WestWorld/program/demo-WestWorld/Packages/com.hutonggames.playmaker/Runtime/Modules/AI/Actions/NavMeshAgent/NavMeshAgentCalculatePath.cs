
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Calculate a path to a specified point and optionally store the resulting path and success flag.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.CalculatePath.html")]
	public sealed class NavMeshAgentCalculatePath : BaseAction
	{
		
		[Tooltip("The NavMeshAgent.")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("The final position of the path requested.")]
		[SerializeField]
		private Vector3Var _targetPosition;
		
		[Tooltip("The resulting path.")]
		[SerializeField]
		[OptionalField]
		[WriteOnly]
		private NavMeshPathRef _path;
		
		[Tooltip("True if either a complete or partial path is found. False otherwise.")]
		[SerializeField]
		[OptionalField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _targetPosition);
		}
		
		public override void Execute()
		{
			var path = GetOrCreatePath();

			//UnityEngine.AI.NavMeshAgent.CalculatePath(UnityEngine.Vector3, UnityEngine.AI.NavMeshPath);
			var result = _navMeshAgent.Value.CalculatePath(_targetPosition.Value, path);
			if (_result.IsAssigned)
			{
				_result.Value = result;
			}
		}

		public override string ErrorCheck() => !_path.IsAssigned && !_result.IsAssigned
			? "Action does not store the path or result!"
			: null;
		
		public override string GetSummary()
		{
			return "Calculate {_navMeshAgent} path to {_targetPosition} {_path:output} {_result:output}";
		}

		private NavMeshPath GetOrCreatePath()
		{
			if (!_path.IsAssigned)
			{
				return new NavMeshPath();
			}

			var path = _path.Value ?? new NavMeshPath();
			_path.Value = path;
			return path;
		}
	}
}
