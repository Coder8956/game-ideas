/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("Get the UnityEvent called when value changed.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownGetOnValueChanged : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Get TMP_Dropdown On Value Changed")]
		[SerializeField]
		[WriteOnly]
		private TMP_Dropdown_DropdownEventRef _getOnValueChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _getOnValueChanged);
		}
		
		public override void Execute()
		{
			_getOnValueChanged.Value = _tMP_Dropdown.Value.onValueChanged;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Dropdown} on value changed -> {_getOnValueChanged}";
		}
	}
}
*/
