
using JetBrains.Annotations;
using TMPro;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Text Style.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetTextStyle : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Text Style")]
		[SerializeField]
		private TMP_Style _setTextStyle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setTextStyle);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.textStyle = _setTextStyle;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} text style to {_setTextStyle}";
		}
	}
}
