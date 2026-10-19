
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
	public sealed class DropdownSetOptions : BaseAction
	{
		
		[Tooltip("The Dropdown")]
		[SerializeField]
		private DropdownVar _dropdown;
		
		[Tooltip("Set Dropdown Options")]
		[SerializeField]
		private Dropdown_OptionDataListVar _setOptions;
		
		public override bool CanExecute()
		{
			return CheckParameters(_dropdown, _setOptions);
		}
		
		public override void Execute()
		{
			_dropdown.Value.options = _setOptions.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_dropdown} Options to {_setOptions}";
		}
	}
}
