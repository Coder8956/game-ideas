
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Finds the nearest point based on the NavMesh within a specified range.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html")]
	public sealed class NavMeshSamplePosition : BaseAction
	{
		
		[Tooltip("The origin of the sample query.")]
		[SerializeField]
		private Vector3Var _sourcePosition;
		
		[Tooltip("Holds the properties of the resulting location. The value of hit.normal is never " +
			"computed. It is always (0,0,0).")]
		[SerializeField]
		[WriteOnly]
		private NavMeshHitRef _hit;
		
		[Tooltip("Sample within this distance from sourcePosition.")]
		[SerializeField]
		private FloatVar _maxDistance;
		
		[Tooltip("A mask that specifies the NavMesh areas allowed when finding the nearest point.")]
		[SerializeField]
		private IntegerVar _areaMask;
		
		[Tooltip("True if the nearest point is found.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_sourcePosition, _hit, _maxDistance, _areaMask, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.SamplePosition(UnityEngine.Vector3, UnityEngine.AI.NavMeshHit&, System.Single, System.Int32);
			_result.Value = NavMesh.SamplePosition(_sourcePosition.Value, out var outhit, _maxDistance.Value, _areaMask.Value);
			_hit.Value = outhit;
		}
		
		public override string GetSummary()
		{
			return "Sample NavMesh position {_sourcePosition} {_hit} {_maxDistance} {_areaMask} -> {_result}";
		}
	}
}
