
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshPath)]
	[ActionDescription("Corner points of the path. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshPath-corners.html")]
	public sealed class NavMeshPathGetCorners : BaseAction
	{
		
		[Tooltip("The NavMeshPath")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshPathRef _navMeshPath;
		
		[Tooltip("Get NavMeshPath Corners")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.Vector3ListRef _getCorners;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshPath, _getCorners);
		}
		
		public override void Execute()
		{
			this._getCorners.Values = this._navMeshPath.Value.corners;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshPath} Corners -> {_getCorners}";
		}
	}
}
