
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshPath)]
	[ActionDescription("Status of the path. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshPath-status.html")]
	public sealed class NavMeshPathGetStatus : BaseAction
	{
		
		[Tooltip("The NavMeshPath")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshPathRef _navMeshPath;
		
		[Tooltip("Get NavMeshPath Status")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.Actions.AI.NavMeshPathStatusRef _getStatus;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshPath, _getStatus);
		}
		
		public override void Execute()
		{
			this._getStatus.Value = this._navMeshPath.Value.status;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshPath} Status -> {_getStatus}";
		}
	}
}
