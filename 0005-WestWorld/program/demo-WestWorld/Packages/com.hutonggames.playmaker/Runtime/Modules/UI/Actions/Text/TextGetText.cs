
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Text)]
	[ActionDescription("The string value this text will display.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Text.html")]
	public sealed class TextGetText : BaseAction
	{
		
		[Tooltip("The Text")]
		[SerializeField]
		private TextVar _text;
		
		[Tooltip("Get Text Text")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_text, _getText);
		}
		
		public override void Execute()
		{
			_getText.Value = _text.Value.text;
		}
		
		public override string GetSummary()
		{
			return "Get {_text} text -> {_getText}";
		}
	}
}
