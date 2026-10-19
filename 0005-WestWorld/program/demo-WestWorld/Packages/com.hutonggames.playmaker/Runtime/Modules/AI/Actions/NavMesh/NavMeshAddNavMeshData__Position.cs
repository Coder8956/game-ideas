
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Adds the specified NavMeshData to the game.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.AddNavMeshData.html")]
	public sealed class NavMeshAddNavMeshData__Position : BaseAction
	{
		
		[Tooltip("Contains the data for the navmesh.")]
		[SerializeField]
		private NavMeshDataVar _navMeshData;
		
		[Tooltip("Translate the navmesh to this position.")]
		[SerializeField]
		private Vector3Var _position;
		
		[Tooltip("Rotate the navmesh to this orientation.")]
		[SerializeField]
		private QuaternionVar _rotation;
		
		[Tooltip("Representing the added navmesh.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshDataInstanceRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshData, _position, _rotation, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.AddNavMeshData(UnityEngine.AI.NavMeshData, UnityEngine.Vector3, UnityEngine.Quaternion);
			_result.Value = NavMesh.AddNavMeshData(_navMeshData.Value, _position.Value, _rotation.Value);
		}
		
		public override string GetSummary()
		{
			return "Add NavMesh data {_navMeshData} at {_position} {_rotation} -> {_result}";
		}
	}
}
