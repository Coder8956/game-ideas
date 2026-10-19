
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshLinkData)]
	[ActionDescription("Specifies which agent type this link is available for.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkData-agentTypeID.html")]
	public sealed class NavMeshLinkDataGetAgentTypeID : BaseAction
	{
		
		[Tooltip("The NavMeshLinkData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkDataRef _navMeshLinkData;
		
		[Tooltip("Get NavMeshLinkData Agent Type ID")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.IntegerRef _getAgentTypeID;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshLinkData, _getAgentTypeID);
		}
		
		public override void Execute()
		{
			this._getAgentTypeID.Value = this._navMeshLinkData.Value.agentTypeID;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshLinkData} Agent Type ID -> {_getAgentTypeID}";
		}
	}
}
