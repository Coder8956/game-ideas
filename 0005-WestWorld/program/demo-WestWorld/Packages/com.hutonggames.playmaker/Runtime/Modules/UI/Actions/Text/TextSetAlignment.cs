
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Text)]
	[ActionDescription("The positioning of the text reliative to its RectTransform.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Text.html")]
	public sealed class TextSetAlignment : BaseAction
	{
		
		[Tooltip("The Text")]
		[SerializeField]
		private TextVar _text;
		
		[Tooltip("Set Text Alignment")]
		[SerializeField]
		private TextAnchorVar _setAlignment;
		
		public override bool CanExecute()
		{
			return CheckParameters(_text, _setAlignment);
		}
		
		public override void Execute()
		{
			_text.Value.alignment = _setAlignment.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_text} alignment to {_setAlignment}";
		}
	}
}
