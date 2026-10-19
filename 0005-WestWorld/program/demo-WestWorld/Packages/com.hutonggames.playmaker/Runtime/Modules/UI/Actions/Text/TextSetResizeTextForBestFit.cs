
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Text)]
	[ActionDescription("Should the text be allowed to auto resized.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Text.html")]
	public sealed class TextSetResizeTextForBestFit : BaseAction
	{
		
		[Tooltip("The Text")]
		[SerializeField]
		private TextVar _text;
		
		[Tooltip("Set Text Resize Text For Best Fit")]
		[SerializeField]
		private BoolVar _setResizeTextForBestFit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_text, _setResizeTextForBestFit);
		}
		
		public override void Execute()
		{
			_text.Value.resizeTextForBestFit = _setResizeTextForBestFit.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_text} resize text for best fit to {_setResizeTextForBestFit}";
		}
	}
}
