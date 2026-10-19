
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
	public sealed class NavMeshSetPathfindingIterationsPerFrame : BaseAction
	{
		
		[Tooltip("Set NavMesh Pathfinding Iterations Per Frame")]
		[SerializeField]
		private IntegerVar _setPathfindingIterationsPerFrame;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setPathfindingIterationsPerFrame);
		}
		
		public override void Execute()
		{
			UnityEngine.AI.NavMesh.pathfindingIterationsPerFrame = _setPathfindingIterationsPerFrame.Value;
		}
		
		public override string GetSummary()
		{
			return "Set NavMesh pathfinding iterations per frame to {_setPathfindingIterationsPerFrame}";
		}
	}
}
