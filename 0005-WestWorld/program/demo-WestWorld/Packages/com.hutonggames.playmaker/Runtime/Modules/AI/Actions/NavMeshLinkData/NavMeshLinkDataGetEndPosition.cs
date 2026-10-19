
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshLinkData)]
	[ActionDescription("End position of the link.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkData-endPosition.html")]
	public sealed class NavMeshLinkDataGetEndPosition : BaseAction
	{
		
		[Tooltip("The NavMeshLinkData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkDataRef _navMeshLinkData;
		
		[Tooltip("Get NavMeshLinkData End Position")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.Vector3Ref _getEndPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshLinkData, _getEndPosition);
		}
		
		public override void Execute()
		{
			this._getEndPosition.Value = this._navMeshLinkData.Value.endPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshLinkData} End Position -> {_getEndPosition}";
		}
	}
}
