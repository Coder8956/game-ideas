
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("Set index number of the current selection in the Dropdown without invoking onValu" +
		"eChanged callback.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownSetValueWithoutNotify : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown.")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Input.")]
		[SerializeField]
		private IntegerVar _input;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _input);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Dropdown.SetValueWithoutNotify(System.Int32);
			_tMP_Dropdown.Value.SetValueWithoutNotify(_input.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Dropdown} value without notify to {_input}";
		}
	}
}
