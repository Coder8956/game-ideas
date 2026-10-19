
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("The Image component to hold the image of the currently selected option.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownGetCaptionImage : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Get TMP_Dropdown Caption Image")]
		[SerializeField]
		[WriteOnly]
		private UI.ImageRef _getCaptionImage;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _getCaptionImage);
		}
		
		public override void Execute()
		{
			_getCaptionImage.Value = _tMP_Dropdown.Value.captionImage;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Dropdown} caption image -> {_getCaptionImage}";
		}
	}
}
