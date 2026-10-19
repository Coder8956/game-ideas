
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The amount of potential line spacing adjustment before text auto sizing kicks in.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetLineSpacingAdjustment : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Line Spacing Adjustment")]
		[SerializeField]
		private FloatVar _setLineSpacingAdjustment;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setLineSpacingAdjustment);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.lineSpacingAdjustment = _setLineSpacingAdjustment.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} line spacing adjustment to {_setLineSpacingAdjustment}";
		}
	}
}
