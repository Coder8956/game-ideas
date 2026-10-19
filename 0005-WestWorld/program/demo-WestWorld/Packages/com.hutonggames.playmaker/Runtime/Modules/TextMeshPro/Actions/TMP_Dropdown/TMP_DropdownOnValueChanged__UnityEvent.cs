
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("Set the UnityEvent called when the value changes.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownOnValueChanged__UnityEvent : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Set TMP_Dropdown On Value Changed")]
		[SerializeField]
		private TMP_Dropdown_DropdownEventVar _onValueChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _onValueChanged);
		}
		
		public override void Execute()
		{
			_tMP_Dropdown.Value.onValueChanged = _onValueChanged.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Dropdown} on value changed to {_onValueChanged}";
		}
	}
}
