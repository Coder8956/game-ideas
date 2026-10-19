
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Text)]
	[ActionDescription("The Font used by the text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Text.html")]
	public sealed class TextSetFont : BaseAction
	{
		
		[Tooltip("The Text")]
		[SerializeField]
		private TextVar _text;
		
		[Tooltip("Set Text Font")]
		[SerializeField, CanBeNullOrEmpty]
		private FontVar _setFont;
		
		public override bool CanExecute()
		{
			return CheckParameters(_text);
		}
		
		public override void Execute()
		{
			_text.Value.font = _setFont.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_text} font to {_setFont}";
		}
	}
}
