
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Removes the specified NavMeshDataInstance from the game, making it unavailable fo" +
		"r agents and queries.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.RemoveNavMeshData.html")]
	public sealed class NavMeshRemoveNavMeshData : BaseAction
	{
		
		[Tooltip("The instance of a NavMesh to remove.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshDataInstanceRef _handle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_handle);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.RemoveNavMeshData(UnityEngine.AI.NavMeshDataInstance);
			NavMesh.RemoveNavMeshData(_handle.Value);
		}
		
		public override string GetSummary()
		{
			return "Remove NavMesh data {_handle}";
		}
	}
}
