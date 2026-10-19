
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Text)]
	[ActionDescription("Line spacing, specified as a factor of font line height. A value of 1 will produc" +
		"e normal line spacing.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Text.html")]
	public sealed class TextSetLineSpacing : BaseAction
	{
		
		[Tooltip("The Text")]
		[SerializeField]
		private TextVar _text;
		
		[Tooltip("Set Text Line Spacing")]
		[SerializeField]
		private FloatVar _setLineSpacing;
		
		public override bool CanExecute()
		{
			return CheckParameters(_text, _setLineSpacing);
		}
		
		public override void Execute()
		{
			_text.Value.lineSpacing = _setLineSpacing.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_text} line spacing to {_setLineSpacing}";
		}
	}
}
