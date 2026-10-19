
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Dropdown)]
	[ActionDescription("The list of possible options. A text string and an image can be specified for eac" +
		"h option.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Dropdown.html")]
	public sealed class DropdownGetOptions : BaseAction
	{
		
		[Tooltip("The Dropdown")]
		[SerializeField]
		private DropdownVar _dropdown;
		
		[Tooltip("Get Dropdown Options")]
		[SerializeField]
		[WriteOnly]
		private Dropdown_OptionDataListRef _getOptions;
		
		public override bool CanExecute()
		{
			return CheckParameters(_dropdown, _getOptions);
		}
		
		public override void Execute()
		{
			_getOptions.Value = _dropdown.Value.options;
		}
		
		public override string GetSummary()
		{
			return "Get {_dropdown} Options -> {_getOptions}";
		}
	}
}
