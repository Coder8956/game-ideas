
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Maximum point size of the font when text auto-sizing is enabled.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetFontSizeMax : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Font Size Max")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFontSizeMax;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getFontSizeMax);
		}
		
		public override void Execute()
		{
			_getFontSizeMax.Value = _tMP_Text.Value.fontSizeMax;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} font size max -> {_getFontSizeMax}";
		}
	}
}
