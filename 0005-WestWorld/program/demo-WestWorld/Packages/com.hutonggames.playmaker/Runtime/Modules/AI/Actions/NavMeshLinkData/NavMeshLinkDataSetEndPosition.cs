
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshLinkData)]
	[ActionDescription("End position of the link.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkData-endPosition.html")]
	public sealed class NavMeshLinkDataSetEndPosition : BaseAction
	{
		
		[Tooltip("The NavMeshLinkData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkDataRef _navMeshLinkData;
		
		[Tooltip("Set NavMeshLinkData End Position")]
		[SerializeField]
		private HutongGames.PlayMaker.Vector3Var _setEndPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshLinkData, _setEndPosition);
		}
		
		public override void Execute()
		{
			var value = this._navMeshLinkData.Value;
			value.endPosition = this._setEndPosition.Value;
			this._navMeshLinkData.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshLinkData} End Position to {_setEndPosition}";
		}
	}
}
