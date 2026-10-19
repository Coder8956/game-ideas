
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshLinkData)]
	[ActionDescription("If positive, overrides the pathfinder cost to traverse the link.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkData-costModifier.html")]
	public sealed class NavMeshLinkDataGetCostModifier : BaseAction
	{
		
		[Tooltip("The NavMeshLinkData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkDataRef _navMeshLinkData;
		
		[Tooltip("Get NavMeshLinkData Cost Modifier")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.FloatRef _getCostModifier;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshLinkData, _getCostModifier);
		}
		
		public override void Execute()
		{
			this._getCostModifier.Value = this._navMeshLinkData.Value.costModifier;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshLinkData} Cost Modifier -> {_getCostModifier}";
		}
	}
}
