
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("The ColorBlock for this selectable object.\nRemarks:\nModifications will not be visible if transition is not ColorTint.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableGetColors : BaseAction
	{
		
		[Tooltip("The Selectable")]
		[SerializeField]
		private SelectableVar _selectable;
		
		[Tooltip("Get Selectable Colors")]
		[SerializeField]
		[WriteOnly]
		private ColorBlockRef _getColors;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable, _getColors);
		}
		
		public override void Execute()
		{
			_getColors.Value = _selectable.Value.colors;
		}
		
		public override string GetSummary()
		{
			return "Get {_selectable} colors -> {_getColors}";
		}
	}
}
