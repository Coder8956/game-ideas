
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshLinkData)]
	[ActionDescription("If positive, the link will be rectangle aligned along the line from start to end." +
		"")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkData-width.html")]
	public sealed class NavMeshLinkDataGetWidth : BaseAction
	{
		
		[Tooltip("The NavMeshLinkData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkDataRef _navMeshLinkData;
		
		[Tooltip("Get NavMeshLinkData Width")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.FloatRef _getWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshLinkData, _getWidth);
		}
		
		public override void Execute()
		{
			this._getWidth.Value = this._navMeshLinkData.Value.width;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshLinkData} Width -> {_getWidth}";
		}
	}
}
