
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Removes all NavMesh surfaces and links from the game.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.RemoveAllNavMeshData.html")]
	public sealed class NavMeshRemoveAllNavMeshData : BaseAction
	{
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.RemoveAllNavMeshData();
			UnityEngine.AI.NavMesh.RemoveAllNavMeshData();
		}
		
		public override string GetSummary()
		{
			return "Remove all NavMesh data";
		}
	}
}
