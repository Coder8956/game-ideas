
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Text)]
	[ActionDescription("The size that the Font should render at.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Text.html")]
	public sealed class TextSetFontSize : BaseAction
	{
		
		[Tooltip("The Text")]
		[SerializeField]
		private TextVar _text;
		
		[Tooltip("Set Text Font Size")]
		[SerializeField]
		private IntegerVar _setFontSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_text, _setFontSize);
		}
		
		public override void Execute()
		{
			_text.Value.fontSize = _setFontSize.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_text} font size to {_setFontSize}";
		}
	}
}
