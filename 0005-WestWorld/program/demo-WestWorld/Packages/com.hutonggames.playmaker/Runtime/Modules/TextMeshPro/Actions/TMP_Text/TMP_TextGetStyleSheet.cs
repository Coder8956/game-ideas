
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Style sheet used by the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetStyleSheet : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Style Sheet")]
		[SerializeField]
		[WriteOnly]
		private TMP_StyleSheetRef _getStyleSheet;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getStyleSheet);
		}
		
		public override void Execute()
		{
			_getStyleSheet.Value = _tMP_Text.Value.styleSheet;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} style sheet -> {_getStyleSheet}";
		}
	}
}
