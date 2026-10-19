
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Text)]
	[ActionDescription("The minimum size the text is allowed to be.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Text.html")]
	public sealed class TextSetResizeTextMinSize : BaseAction
	{
		
		[Tooltip("The Text")]
		[SerializeField]
		private TextVar _text;
		
		[Tooltip("Set Text Resize Text Min Size")]
		[SerializeField]
		private IntegerVar _setResizeTextMinSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_text, _setResizeTextMinSize);
		}
		
		public override void Execute()
		{
			_text.Value.resizeTextMinSize = _setResizeTextMinSize.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_text} resize text min size to {_setResizeTextMinSize}";
		}
	}
}
