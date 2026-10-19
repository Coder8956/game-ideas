
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Calculate a path between two points and optionally store the resulting path and success flag.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.CalculatePath.html")]
	public sealed class NavMeshCalculatePath__Filter : BaseAction
	{
		
		[Tooltip("The initial position of the path requested.")]
		[SerializeField]
		private Vector3Var _sourcePosition;
		
		[Tooltip("The final position of the path requested.")]
		[SerializeField]
		private Vector3Var _targetPosition;
		
		[Tooltip("A filter specifying the cost of NavMesh areas that can be passed when calculating" +
			" a path.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshQueryFilterRef _filter;
		
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
			return CheckParameters(_sourcePosition, _targetPosition, _filter);
		}
		
		public override void Execute()
		{
			var path = GetOrCreatePath();

			//UnityEngine.AI.NavMesh.CalculatePath(UnityEngine.Vector3, UnityEngine.Vector3, UnityEngine.AI.NavMeshQueryFilter, UnityEngine.AI.NavMeshPath);
			var result = NavMesh.CalculatePath(_sourcePosition.Value, _targetPosition.Value, _filter.Value, path);
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
			return "Calculate NavMesh path from {_sourcePosition} to {_targetPosition} {_filter} {_path:output} {_result:output}";
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
