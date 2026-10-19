
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshLinkData)]
	[ActionDescription("Area type of the link.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkData-area.html")]
	public sealed class NavMeshLinkDataSetArea : BaseAction
	{
		
		[Tooltip("The NavMeshLinkData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkDataRef _navMeshLinkData;
		
		[Tooltip("Set NavMeshLinkData Area")]
		[SerializeField]
		private HutongGames.PlayMaker.IntegerVar _setArea;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshLinkData, _setArea);
		}
		
		public override void Execute()
		{
			var value = this._navMeshLinkData.Value;
			value.area = this._setArea.Value;
			this._navMeshLinkData.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshLinkData} Area to {_setArea}";
		}
	}
}
