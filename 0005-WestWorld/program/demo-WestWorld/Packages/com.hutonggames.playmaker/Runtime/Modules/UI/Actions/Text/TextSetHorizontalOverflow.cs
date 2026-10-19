
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Text)]
	[ActionDescription("Horizontal overflow mode.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Text.html")]
	public sealed class TextSetHorizontalOverflow : BaseAction
	{
		
		[Tooltip("The Text")]
		[SerializeField]
		private TextVar _text;
		
		[Tooltip("Set Text Horizontal Overflow")]
		[SerializeField]
		private HorizontalWrapModeVar _setHorizontalOverflow;
		
		public override bool CanExecute()
		{
			return CheckParameters(_text, _setHorizontalOverflow);
		}
		
		public override void Execute()
		{
			_text.Value.horizontalOverflow = _setHorizontalOverflow.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_text} horizontal overflow to {_setHorizontalOverflow}";
		}
	}
}
