
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Minimum point size of the font when text auto-sizing is enabled.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetFontSizeMin : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Font Size Min")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFontSizeMin;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getFontSizeMin);
		}
		
		public override void Execute()
		{
			_getFontSizeMin.Value = _tMP_Text.Value.fontSizeMin;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} font size min -> {_getFontSizeMin}";
		}
	}
}
