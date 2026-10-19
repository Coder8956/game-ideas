
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("Set the options to show in the Dropdown.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownSetOptions : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Set TMP_Dropdown Options")]
		[SerializeField]
		private TMP_Dropdown_OptionDataListVar _setOptions;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _setOptions);
		}
		
		public override void Execute()
		{
			_tMP_Dropdown.Value.options = _setOptions.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Dropdown} options to {_setOptions}";
		}
	}
}
