
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("The Image component to hold the image of the currently selected option.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownSetCaptionImage : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Set TMP_Dropdown Caption Image")]
		[SerializeField, CanBeNullOrEmpty]
		private UI.ImageVar _setCaptionImage;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown);
		}
		
		public override void Execute()
		{
			_tMP_Dropdown.Value.captionImage = _setCaptionImage.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Dropdown} caption image to {_setCaptionImage}";
		}
	}
}
