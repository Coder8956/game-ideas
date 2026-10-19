
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Adds the specified NavMeshData to the game.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.AddNavMeshData.html")]
	public sealed class NavMeshAddNavMeshData : BaseAction
	{
		
		[Tooltip("Contains the data for the navmesh.")]
		[SerializeField]
		private NavMeshDataVar _navMeshData;
		
		[Tooltip("Representing the added navmesh.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshDataInstanceRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshData, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.AddNavMeshData(UnityEngine.AI.NavMeshData);
			_result.Value = NavMesh.AddNavMeshData(_navMeshData.Value);
		}
		
		public override string GetSummary()
		{
			return "Add NavMesh data {_navMeshData} -> {_result}";
		}
	}
}
