
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Locate the closest NavMesh edge from a point on the NavMesh.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.FindClosestEdge.html")]
	public sealed class NavMeshFindClosestEdge__Filter : BaseAction
	{
		
		[Tooltip("The origin of the distance query.")]
		[SerializeField]
		private Vector3Var _sourcePosition;
		
		[Tooltip("Holds the properties of the resulting location.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshHitRef _hit;
		
		[Tooltip("A filter specifying which NavMesh areas can be passed when finding the nearest ed" +
			"ge.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshQueryFilterRef _filter;
		
		[Tooltip("True if the nearest edge is found.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_sourcePosition, _hit, _filter, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.FindClosestEdge(UnityEngine.Vector3, UnityEngine.AI.NavMeshHit&, UnityEngine.AI.NavMeshQueryFilter);
			_result.Value = NavMesh.FindClosestEdge(_sourcePosition.Value, out var outhit, _filter.Value);
			_hit.Value = outhit;
		}
		
		public override string GetSummary()
		{
			return "Find closest NavMesh edge to {_sourcePosition} {_hit} {_filter} -> {_result}";
		}
	}
}
