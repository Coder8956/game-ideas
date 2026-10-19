
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("How many selectable elements are currently active.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableGetAllSelectableCount : BaseAction
	{
		
		[Tooltip("Get Selectable All Selectable Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getAllSelectableCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getAllSelectableCount);
		}
		
		public override void Execute()
		{
			_getAllSelectableCount.Value = UnityEngine.UI.Selectable.allSelectableCount;
		}
		
		public override string GetSummary()
		{
			return "Get selectable count -> {_getAllSelectableCount}";
		}
	}
}
