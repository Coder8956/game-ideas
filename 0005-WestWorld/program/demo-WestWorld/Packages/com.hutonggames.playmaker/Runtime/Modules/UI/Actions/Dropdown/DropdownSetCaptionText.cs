
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Dropdown)]
	[ActionDescription("The Text component to hold the text of the currently selected option.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Dropdown.html")]
	public sealed class DropdownSetCaptionText : BaseAction
	{
		
		[Tooltip("The Dropdown")]
		[SerializeField]
		private DropdownVar _dropdown;
		
		[Tooltip("Set Dropdown Caption Text")]
		[SerializeField, CanBeNullOrEmpty]
		private TextVar _setCaptionText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_dropdown);
		}
		
		public override void Execute()
		{
			_dropdown.Value.captionText = _setCaptionText.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_dropdown} caption text to {_setCaptionText}";
		}
	}
}
