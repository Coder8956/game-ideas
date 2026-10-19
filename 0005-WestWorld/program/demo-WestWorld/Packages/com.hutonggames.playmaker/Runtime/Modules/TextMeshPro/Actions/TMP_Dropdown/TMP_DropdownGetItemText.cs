
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("The Text component to hold the text of the item.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownGetItemText : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Get TMP_Dropdown Item Text")]
		[SerializeField]
		[WriteOnly]
		private TMP_TextRef _getItemText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _getItemText);
		}
		
		public override void Execute()
		{
			_getItemText.Value = _tMP_Dropdown.Value.itemText;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Dropdown} item text -> {_getItemText}";
		}
	}
}
