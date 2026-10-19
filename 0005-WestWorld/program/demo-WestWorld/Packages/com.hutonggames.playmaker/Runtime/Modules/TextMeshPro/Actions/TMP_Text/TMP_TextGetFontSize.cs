
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The point size of the font.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetFontSize : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Font Size")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFontSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getFontSize);
		}
		
		public override void Execute()
		{
			_getFontSize.Value = _tMP_Text.Value.fontSize;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} font size -> {_getFontSize}";
		}
	}
}
