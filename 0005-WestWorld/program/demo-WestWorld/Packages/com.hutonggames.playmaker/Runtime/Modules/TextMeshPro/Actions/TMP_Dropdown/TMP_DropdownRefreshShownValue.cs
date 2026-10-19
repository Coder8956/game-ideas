
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("Refreshes the text and image (if available) of the currently selected option.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownRefreshShownValue : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown.")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Dropdown.RefreshShownValue();
			_tMP_Dropdown.Value.RefreshShownValue();
		}
		
		public override string GetSummary()
		{
			return "Refresh {_tMP_Dropdown} shown value";
		}
	}
}
