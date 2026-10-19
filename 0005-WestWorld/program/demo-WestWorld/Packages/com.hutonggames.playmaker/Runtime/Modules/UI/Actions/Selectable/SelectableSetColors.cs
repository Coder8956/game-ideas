
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
	public sealed class SelectableSetColors : BaseAction
	{
		
		[Tooltip("The Selectable")]
		[SerializeField]
		private SelectableVar _selectable;
		
		[Tooltip("Set Selectable Colors")]
		[SerializeField]
		private ColorBlockVar _setColors;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable, _setColors);
		}
		
		public override void Execute()
		{
			_selectable.Value.colors = _setColors.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_selectable} colors to {_setColors}";
		}
	}
}
