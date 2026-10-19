
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Text)]
	[ActionDescription("Vertical overflow mode.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Text.html")]
	public sealed class TextSetVerticalOverflow : BaseAction
	{
		
		[Tooltip("The Text")]
		[SerializeField]
		private TextVar _text;
		
		[Tooltip("Set Text Vertical Overflow")]
		[SerializeField]
		private VerticalWrapModeVar _setVerticalOverflow;
		
		public override bool CanExecute()
		{
			return CheckParameters(_text, _setVerticalOverflow);
		}
		
		public override void Execute()
		{
			_text.Value.verticalOverflow = _setVerticalOverflow.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_text} vertical overflow to {_setVerticalOverflow}";
		}
	}
}
