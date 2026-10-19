
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshQueryFilter)]
	[ActionDescription("The agent type ID, specifying which navigation meshes to consider for the query f" +
		"unctions.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshQueryFilter-agentTypeID.html")]
	public sealed class NavMeshQueryFilterGetAgentTypeID : BaseAction
	{
		
		[Tooltip("The NavMeshQueryFilter")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshQueryFilterRef _navMeshQueryFilter;
		
		[Tooltip("Get NavMeshQueryFilter Agent Type ID")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.IntegerRef _getAgentTypeID;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshQueryFilter, _getAgentTypeID);
		}
		
		public override void Execute()
		{
			this._getAgentTypeID.Value = this._navMeshQueryFilter.Value.agentTypeID;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshQueryFilter} Agent Type ID -> {_getAgentTypeID}";
		}
	}
}
