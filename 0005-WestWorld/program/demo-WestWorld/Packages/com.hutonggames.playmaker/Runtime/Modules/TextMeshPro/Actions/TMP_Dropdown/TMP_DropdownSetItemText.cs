
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("The Text component to hold the text of the item.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownSetItemText : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Set TMP_Dropdown Item Text")]
		[SerializeField, CanBeNullOrEmpty]
		private TMP_TextVar _setItemText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown);
		}
		
		public override void Execute()
		{
			_tMP_Dropdown.Value.itemText = _setItemText.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Dropdown} item text to {_setItemText}";
		}
	}
}
