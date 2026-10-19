
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Text)]
	[ActionDescription("FontStyle used by the text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Text.html")]
	public sealed class TextSetFontStyle : BaseAction
	{
		
		[Tooltip("The Text")]
		[SerializeField]
		private TextVar _text;
		
		[Tooltip("Set Text Font Style")]
		[SerializeField]
		private FontStyleVar _setFontStyle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_text, _setFontStyle);
		}
		
		public override void Execute()
		{
			_text.Value.fontStyle = _setFontStyle.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_text} font style to {_setFontStyle}";
		}
	}
}
