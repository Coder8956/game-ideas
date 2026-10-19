
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Adds extra padding around each character. This may be necessary when the displayed text is very small to prevent clipping.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetExtraPadding : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Extra Padding")]
		[SerializeField]
		private BoolVar _setExtraPadding;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setExtraPadding);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.extraPadding = _setExtraPadding.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} extra padding to {_setExtraPadding}";
		}
	}
}
