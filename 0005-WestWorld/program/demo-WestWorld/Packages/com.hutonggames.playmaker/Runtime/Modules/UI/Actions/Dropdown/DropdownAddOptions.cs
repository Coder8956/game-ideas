
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Dropdown)]
	[ActionDescription("Add multiple options to the options of the Dropdown based on a list of OptionData objects.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Dropdown.html")]
	public sealed class DropdownAddOptions : BaseAction
	{
		
		[Tooltip("The Dropdown.")]
		[SerializeField]
		private DropdownVar _dropdown;
		
		[Tooltip("Options.")]
		[SerializeField]
		private Dropdown_OptionDataListVar _options;
		
		public override bool CanExecute()
		{
			return CheckParameters(_dropdown, _options);
		}
		
		public override void Execute()
		{
			_dropdown.Value.AddOptions(_options.Value);
		}
		
		public override string GetSummary()
		{
			return "{_dropdown} Add Options {_options} ";
		}
	}
}
