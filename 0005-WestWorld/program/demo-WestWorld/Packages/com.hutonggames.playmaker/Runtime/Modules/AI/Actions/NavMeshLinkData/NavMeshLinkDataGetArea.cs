
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshLinkData)]
	[ActionDescription("Area type of the link.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkData-area.html")]
	public sealed class NavMeshLinkDataGetArea : BaseAction
	{
		
		[Tooltip("The NavMeshLinkData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkDataRef _navMeshLinkData;
		
		[Tooltip("Get NavMeshLinkData Area")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.IntegerRef _getArea;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshLinkData, _getArea);
		}
		
		public override void Execute()
		{
			this._getArea.Value = this._navMeshLinkData.Value.area;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshLinkData} Area -> {_getArea}";
		}
	}
}
