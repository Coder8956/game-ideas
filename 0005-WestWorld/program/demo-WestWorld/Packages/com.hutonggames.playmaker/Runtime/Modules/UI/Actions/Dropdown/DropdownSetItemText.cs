
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Dropdown)]
	[ActionDescription("The Text component to hold the text of the item.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Dropdown.html")]
	public sealed class DropdownSetItemText : BaseAction
	{
		
		[Tooltip("The Dropdown")]
		[SerializeField]
		private DropdownVar _dropdown;
		
		[Tooltip("Set Dropdown Item Text")]
		[SerializeField, CanBeNullOrEmpty]
		private TextVar _setItemText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_dropdown);
		}
		
		public override void Execute()
		{
			_dropdown.Value.itemText = _setItemText.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_dropdown} Item Text to {_setItemText}";
		}
	}
}
