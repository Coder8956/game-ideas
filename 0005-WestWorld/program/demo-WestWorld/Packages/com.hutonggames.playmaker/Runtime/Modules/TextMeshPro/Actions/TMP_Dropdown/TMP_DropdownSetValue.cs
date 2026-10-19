
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("Set the index number of the current selection in the Dropdown.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownSetValue : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Set TMP_Dropdown Value")]
		[SerializeField]
		private IntegerVar _setValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _setValue);
		}
		
		public override void Execute()
		{
			_tMP_Dropdown.Value.value = _setValue.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Dropdown} value to {_setValue}";
		}
	}
}
