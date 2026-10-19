
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshLinkData)]
	[ActionDescription("Start position of the link.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkData-startPosition.html")]
	public sealed class NavMeshLinkDataGetStartPosition : BaseAction
	{
		
		[Tooltip("The NavMeshLinkData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkDataRef _navMeshLinkData;
		
		[Tooltip("Get NavMeshLinkData Start Position")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.Vector3Ref _getStartPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshLinkData, _getStartPosition);
		}
		
		public override void Execute()
		{
			this._getStartPosition.Value = this._navMeshLinkData.Value.startPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshLinkData} Start Position -> {_getStartPosition}";
		}
	}
}
