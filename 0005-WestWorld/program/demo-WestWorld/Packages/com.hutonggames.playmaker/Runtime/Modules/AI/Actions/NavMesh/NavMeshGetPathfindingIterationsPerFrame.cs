
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("The maximum number of nodes processed for each frame during the asynchronous path" +
		"finding process.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh-pathfindingIterationsPerFrame" +
		".html")]
	public sealed class NavMeshGetPathfindingIterationsPerFrame : BaseAction
	{
		
		[Tooltip("Get NavMesh Pathfinding Iterations Per Frame")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getPathfindingIterationsPerFrame;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getPathfindingIterationsPerFrame);
		}
		
		public override void Execute()
		{
			_getPathfindingIterationsPerFrame.Value = UnityEngine.AI.NavMesh.pathfindingIterationsPerFrame;
		}
		
		public override string GetSummary()
		{
			return "Get NavMesh pathfinding iterations per frame -> {_getPathfindingIterationsPerFrame}";
		}
	}
}
