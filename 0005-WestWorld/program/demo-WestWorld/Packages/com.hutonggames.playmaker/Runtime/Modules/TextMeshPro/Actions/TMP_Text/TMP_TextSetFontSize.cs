
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The point size of the font.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetFontSize : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Font Size")]
		[SerializeField]
		private FloatVar _setFontSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setFontSize);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.fontSize = _setFontSize.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} font size to {_setFontSize}";
		}
	}
}
