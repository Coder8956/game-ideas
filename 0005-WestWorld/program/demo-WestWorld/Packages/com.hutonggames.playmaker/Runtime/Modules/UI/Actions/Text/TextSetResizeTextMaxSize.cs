
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Text)]
	[ActionDescription("The maximum size the text is allowed to be. 1 = infinitly large.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Text.html")]
	public sealed class TextSetResizeTextMaxSize : BaseAction
	{
		
		[Tooltip("The Text")]
		[SerializeField]
		private TextVar _text;
		
		[Tooltip("Set Text Resize Text Max Size")]
		[SerializeField]
		private IntegerVar _setResizeTextMaxSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_text, _setResizeTextMaxSize);
		}
		
		public override void Execute()
		{
			_text.Value.resizeTextMaxSize = _setResizeTextMaxSize.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_text} resize text max size to {_setResizeTextMaxSize}";
		}
	}
}
