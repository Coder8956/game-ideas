
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("Get the index number of the current selection in the Dropdown.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownGetValue : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Get TMP_Dropdown Value")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _getValue);
		}
		
		public override void Execute()
		{
			_getValue.Value = _tMP_Dropdown.Value.value;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Dropdown} value -> {_getValue}";
		}
	}
}
