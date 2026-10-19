
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription(@"Show the dropdown.
Plan for dropdown scrolling to ensure dropdown is contained within screen.
We assume the Canvas is the screen that the dropdown must be kept inside.
This is always valid for screen space canvas modes.
For world space canvases we don't know how it's used, but it could be e.g. for an in-game monitor.
We consider it a fair constraint that the canvas must be big enough to contain dropdowns.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownShow : BaseAction
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
			//TMPro.TMP_Dropdown.Show();
			_tMP_Dropdown.Value.Show();
		}
		
		public override string GetSummary()
		{
			return "Show {_tMP_Dropdown}";
		}
	}
}
