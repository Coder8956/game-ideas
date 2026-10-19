
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Trace a line between two points on the NavMesh.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.Raycast.html")]
	public sealed class NavMeshRaycast : BaseAction
	{
		
		[Tooltip("The origin of the ray.")]
		[SerializeField]
		private Vector3Var _sourcePosition;
		
		[Tooltip("The end of the ray.")]
		[SerializeField]
		private Vector3Var _targetPosition;
		
		[Tooltip("Holds the properties of the ray cast resulting location.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshHitRef _hit;
		
		[Tooltip("A bitfield mask specifying which NavMesh areas can be passed when tracing the ray" +
			".")]
		[SerializeField]
		private IntegerVar _areaMask;
		
		[Tooltip("True if the ray is terminated before reaching target position. Otherwise returns " +
			"false.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_sourcePosition, _targetPosition, _hit, _areaMask, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.Raycast(UnityEngine.Vector3, UnityEngine.Vector3, UnityEngine.AI.NavMeshHit&, System.Int32);
			_result.Value = NavMesh.Raycast(_sourcePosition.Value, _targetPosition.Value, out var outhit, _areaMask.Value);
			_hit.Value = outhit;
		}
		
		public override string GetSummary()
		{
			return "Raycast NavMesh from {_sourcePosition} to {_targetPosition} {_hit} {_areaMask} -> {_result}";
		}
	}
}
