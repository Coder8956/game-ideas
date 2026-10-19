
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshQueryFilter)]
	[ActionDescription("The agent type ID, specifying which navigation meshes to consider for the query f" +
		"unctions.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshQueryFilter-agentTypeID.html")]
	public sealed class NavMeshQueryFilterSetAgentTypeID : BaseAction
	{
		
		[Tooltip("The NavMeshQueryFilter")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshQueryFilterRef _navMeshQueryFilter;
		
		[Tooltip("Set NavMeshQueryFilter Agent Type ID")]
		[SerializeField]
		private HutongGames.PlayMaker.IntegerVar _setAgentTypeID;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshQueryFilter, _setAgentTypeID);
		}
		
		public override void Execute()
		{
			var value = this._navMeshQueryFilter.Value;
			value.agentTypeID = this._setAgentTypeID.Value;
			this._navMeshQueryFilter.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshQueryFilter} Agent Type ID to {_setAgentTypeID}";
		}
	}
}
