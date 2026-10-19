
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The style of the text")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetFontStyle : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Font Style")]
		[SerializeField]
		[WriteOnly]
		private FontStylesRef _getFontStyle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getFontStyle);
		}
		
		public override void Execute()
		{
			_getFontStyle.Value = _tMP_Text.Value.fontStyle;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} font style -> {_getFontStyle}";
		}
	}
}
