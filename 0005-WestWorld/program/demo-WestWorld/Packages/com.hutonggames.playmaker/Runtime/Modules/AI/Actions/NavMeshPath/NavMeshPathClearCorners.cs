
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshPath)]
	[ActionDescription("Erase all corner points from path.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshPath.ClearCorners.html")]
	public sealed class NavMeshPathClearCorners : BaseAction
	{
		
		[Tooltip("The NavMeshPath.")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshPathRef _navMeshPath;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshPath);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMeshPath.ClearCorners();
			_navMeshPath.Value.ClearCorners();
		}
		
		public override string GetSummary()
		{
			return "{_navMeshPath} clear corners ";
		}
	}
}
