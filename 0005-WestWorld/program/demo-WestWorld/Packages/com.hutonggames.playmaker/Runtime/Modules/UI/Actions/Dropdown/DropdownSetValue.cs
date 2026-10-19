
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Dropdown)]
	[ActionDescription("The index of the currently selected option. 0 is the first option, 1 is the second, and so on.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Dropdown.html")]
	public sealed class DropdownSetValue : BaseAction
	{
		
		[Tooltip("The Dropdown")]
		[SerializeField]
		private DropdownVar _dropdown;
		
		[Tooltip("Set Dropdown Value")]
		[SerializeField]
		private IntegerVar _setValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_dropdown, _setValue);
		}
		
		public override void Execute()
		{
			_dropdown.Value.value = _setValue.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_dropdown} Value to {_setValue}";
		}
	}
}
