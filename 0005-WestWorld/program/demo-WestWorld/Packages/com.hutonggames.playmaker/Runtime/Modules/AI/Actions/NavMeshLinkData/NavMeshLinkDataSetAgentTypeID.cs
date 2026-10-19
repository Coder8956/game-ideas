
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshLinkData)]
	[ActionDescription("Specifies which agent type this link is available for.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkData-agentTypeID.html")]
	public sealed class NavMeshLinkDataSetAgentTypeID : BaseAction
	{
		
		[Tooltip("The NavMeshLinkData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkDataRef _navMeshLinkData;
		
		[Tooltip("Set NavMeshLinkData Agent Type ID")]
		[SerializeField]
		private HutongGames.PlayMaker.IntegerVar _setAgentTypeID;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshLinkData, _setAgentTypeID);
		}
		
		public override void Execute()
		{
			var value = this._navMeshLinkData.Value;
			value.agentTypeID = this._setAgentTypeID.Value;
			this._navMeshLinkData.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshLinkData} Agent Type ID to {_setAgentTypeID}";
		}
	}
}
