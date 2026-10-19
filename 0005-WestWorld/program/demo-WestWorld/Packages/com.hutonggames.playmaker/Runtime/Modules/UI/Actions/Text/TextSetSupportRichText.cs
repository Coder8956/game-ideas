
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Text)]
	[ActionDescription("Whether this Text will support rich text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Text.html")]
	public sealed class TextSetSupportRichText : BaseAction
	{
		
		[Tooltip("The Text")]
		[SerializeField]
		private TextVar _text;
		
		[Tooltip("Set Text Support Rich Text")]
		[SerializeField]
		private BoolVar _setSupportRichText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_text, _setSupportRichText);
		}
		
		public override void Execute()
		{
			_text.Value.supportRichText = _setSupportRichText.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_text} support rich text to {_setSupportRichText}";
		}
	}
}
