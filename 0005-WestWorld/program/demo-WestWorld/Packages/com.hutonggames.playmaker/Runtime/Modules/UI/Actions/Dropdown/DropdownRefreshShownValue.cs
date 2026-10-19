
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Dropdown)]
	[ActionDescription("Refreshes the text and image (if available) of the currently selected option. If " +
		"you have modified the list of options, you should call this method afterwards to" +
		" ensure that the visual state of the dropdown corresponds to the updated options" +
		".")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Dropdown.html")]
	public sealed class DropdownRefreshShownValue : BaseAction
	{
		
		[Tooltip("The Dropdown.")]
		[SerializeField]
		private DropdownVar _dropdown;
		
		public override bool CanExecute()
		{
			return CheckParameters(_dropdown);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Dropdown.RefreshShownValue();
			_dropdown.Value.RefreshShownValue();
		}
		
		public override string GetSummary()
		{
			return "Refresh {_dropdown} shown value";
		}
	}
}
