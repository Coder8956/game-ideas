
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Dropdown)]
	[ActionDescription("Clear the list of options in the Dropdown.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Dropdown.html")]
	public sealed class DropdownClearOptions : BaseAction
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
			//UnityEngine.UI.Dropdown.ClearOptions();
			_dropdown.Value.ClearOptions();
		}
		
		public override string GetSummary()
		{
			return "{_dropdown} Clear Options ";
		}
	}
}
