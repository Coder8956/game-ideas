
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("The Text component to hold the text of the currently selected option.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownGetCaptionText : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Get TMP_Dropdown Caption Text")]
		[SerializeField]
		[WriteOnly]
		private TMP_TextRef _getCaptionText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _getCaptionText);
		}
		
		public override void Execute()
		{
			_getCaptionText.Value = _tMP_Dropdown.Value.captionText;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Dropdown} caption text -> {_getCaptionText}";
		}
	}
}
