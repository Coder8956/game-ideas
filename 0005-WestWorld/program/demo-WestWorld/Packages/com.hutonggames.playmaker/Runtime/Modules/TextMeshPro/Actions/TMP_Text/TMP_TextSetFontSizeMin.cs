
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Minimum point size of the font when text auto-sizing is enabled.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetFontSizeMin : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Font Size Min")]
		[SerializeField]
		private FloatVar _setFontSizeMin;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setFontSizeMin);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.fontSizeMin = _setFontSizeMin.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} font size min to {_setFontSizeMin}";
		}
	}
}
