
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshLinkData)]
	[ActionDescription("If positive, overrides the pathfinder cost to traverse the link.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkData-costModifier.html")]
	public sealed class NavMeshLinkDataSetCostModifier : BaseAction
	{
		
		[Tooltip("The NavMeshLinkData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkDataRef _navMeshLinkData;
		
		[Tooltip("Set NavMeshLinkData Cost Modifier")]
		[SerializeField]
		private HutongGames.PlayMaker.FloatVar _setCostModifier;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshLinkData, _setCostModifier);
		}
		
		public override void Execute()
		{
			var value = this._navMeshLinkData.Value;
			value.costModifier = this._setCostModifier.Value;
			this._navMeshLinkData.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshLinkData} Cost Modifier to {_setCostModifier}";
		}
	}
}
