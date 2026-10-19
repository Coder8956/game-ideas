
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshLinkData)]
	[ActionDescription("Start position of the link.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkData-startPosition.html")]
	public sealed class NavMeshLinkDataSetStartPosition : BaseAction
	{
		
		[Tooltip("The NavMeshLinkData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkDataRef _navMeshLinkData;
		
		[Tooltip("Set NavMeshLinkData Start Position")]
		[SerializeField]
		private HutongGames.PlayMaker.Vector3Var _setStartPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshLinkData, _setStartPosition);
		}
		
		public override void Execute()
		{
			var value = this._navMeshLinkData.Value;
			value.startPosition = this._setStartPosition.Value;
			this._navMeshLinkData.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshLinkData} Start Position to {_setStartPosition}";
		}
	}
}
