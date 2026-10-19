
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The amount of potential line spacing adjustment before text auto sizing kicks in.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetLineSpacingAdjustment : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Line Spacing Adjustment")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getLineSpacingAdjustment;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getLineSpacingAdjustment);
		}
		
		public override void Execute()
		{
			_getLineSpacingAdjustment.Value = _tMP_Text.Value.lineSpacingAdjustment;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} line spacing adjustment -> {_getLineSpacingAdjustment}";
		}
	}
}
