
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("Get the options shown in the Dropdown.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownGetOptions : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Get TMP_Dropdown Options")]
		[SerializeField]
		[WriteOnly]
		private TMP_Dropdown_OptionDataListRef _getOptions;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _getOptions);
		}
		
		public override void Execute()
		{
			_getOptions.Value = _tMP_Dropdown.Value.options;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Dropdown} options -> {_getOptions}";
		}
	}
}
