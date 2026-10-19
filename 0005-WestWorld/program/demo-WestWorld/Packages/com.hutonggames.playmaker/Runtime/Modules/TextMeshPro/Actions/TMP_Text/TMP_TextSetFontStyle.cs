
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The style of the text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetFontStyle : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Font Style")]
		[SerializeField]
		private FontStylesVar _setFontStyle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setFontStyle);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.fontStyle = _setFontStyle.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} font style to {_setFontStyle}";
		}
	}
}
