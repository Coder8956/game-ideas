
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Dropdown)]
	[ActionDescription("A UnityEvent that is invoked when when a user has clicked one of the options in the dropdown list.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Dropdown.html")]
	public sealed class DropdownOnValueChanged__UnityEvent : BaseAction
	{
		
		[Tooltip("The Dropdown")]
		[SerializeField]
		private DropdownVar _dropdown;
		
		[Tooltip("Set Dropdown On Value Changed")]
		[SerializeField]
		private Dropdown_DropdownEventVar _setOnValueChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_dropdown, _setOnValueChanged);
		}
		
		public override void Execute()
		{
			_dropdown.Value.onValueChanged = _setOnValueChanged.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_dropdown} on value changed to {_setOnValueChanged}";
		}
	}
}
