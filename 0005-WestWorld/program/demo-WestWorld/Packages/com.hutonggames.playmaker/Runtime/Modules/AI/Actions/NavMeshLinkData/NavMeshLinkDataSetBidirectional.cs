
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshLinkData)]
	[ActionDescription("If true, the link can be traversed in both directions, otherwise only from start " +
		"to end position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkData-bidirectional.html")]
	public sealed class NavMeshLinkDataSetBidirectional : BaseAction
	{
		
		[Tooltip("The NavMeshLinkData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkDataRef _navMeshLinkData;
		
		[Tooltip("Set NavMeshLinkData Bidirectional")]
		[SerializeField]
		private HutongGames.PlayMaker.BoolVar _setBidirectional;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshLinkData, _setBidirectional);
		}
		
		public override void Execute()
		{
			var value = this._navMeshLinkData.Value;
			value.bidirectional = this._setBidirectional.Value;
			this._navMeshLinkData.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshLinkData} Bidirectional to {_setBidirectional}";
		}
	}
}
