
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshLinkData)]
	[ActionDescription("If true, the link can be traversed in both directions, otherwise only from start " +
		"to end position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkData-bidirectional.html")]
	public sealed class NavMeshLinkDataGetBidirectional : BaseAction
	{
		
		[Tooltip("The NavMeshLinkData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkDataRef _navMeshLinkData;
		
		[Tooltip("Get NavMeshLinkData Bidirectional")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.BoolRef _getBidirectional;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshLinkData, _getBidirectional);
		}
		
		public override void Execute()
		{
			this._getBidirectional.Value = this._navMeshLinkData.Value.bidirectional;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshLinkData} Bidirectional -> {_getBidirectional}";
		}
	}
}
