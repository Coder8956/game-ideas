
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("Clear the list of options in the Dropdown.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownClearOptions : BaseAction
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
			//TMPro.TMP_Dropdown.ClearOptions();
			_tMP_Dropdown.Value.ClearOptions();
		}
		
		public override string GetSummary()
		{
			return "Clear {_tMP_Dropdown} options";
		}
	}
}
