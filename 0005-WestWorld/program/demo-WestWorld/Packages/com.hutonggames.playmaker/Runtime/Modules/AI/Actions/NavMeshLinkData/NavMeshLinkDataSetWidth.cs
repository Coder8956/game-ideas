
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshLinkData)]
	[ActionDescription("If positive, the link will be rectangle aligned along the line from start to end." +
		"")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkData-width.html")]
	public sealed class NavMeshLinkDataSetWidth : BaseAction
	{
		
		[Tooltip("The NavMeshLinkData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkDataRef _navMeshLinkData;
		
		[Tooltip("Set NavMeshLinkData Width")]
		[SerializeField]
		private HutongGames.PlayMaker.FloatVar _setWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshLinkData, _setWidth);
		}
		
		public override void Execute()
		{
			var value = this._navMeshLinkData.Value;
			value.width = this._setWidth.Value;
			this._navMeshLinkData.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshLinkData} Width to {_setWidth}";
		}
	}
}
