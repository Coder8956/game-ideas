
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Adds extra padding around each character. This may be necessary when the displayed text is very small to prevent clipping.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetExtraPadding : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Extra Padding")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getExtraPadding;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getExtraPadding);
		}
		
		public override void Execute()
		{
			_getExtraPadding.Value = _tMP_Text.Value.extraPadding;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} extra padding -> {_getExtraPadding}";
		}
	}
}
