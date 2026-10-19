
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("Is the Dropdown expanded?")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownGetIsExpanded : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Get TMP_Dropdown Is Expanded")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsExpanded;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _getIsExpanded);
		}
		
		public override void Execute()
		{
			_getIsExpanded.Value = _tMP_Dropdown.Value.IsExpanded;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Dropdown} is expanded -> {_getIsExpanded}";
		}
	}
}
