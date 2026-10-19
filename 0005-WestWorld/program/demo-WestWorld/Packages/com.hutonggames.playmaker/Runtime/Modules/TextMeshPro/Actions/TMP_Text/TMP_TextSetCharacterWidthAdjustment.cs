
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Percentage the width of characters can be adjusted before text auto-sizing begins to reduce the point size.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetCharacterWidthAdjustment : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Character Width Adjustment")]
		[SerializeField]
		private FloatVar _setCharacterWidthAdjustment;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setCharacterWidthAdjustment);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.characterWidthAdjustment = _setCharacterWidthAdjustment.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} character width adjustment to {_setCharacterWidthAdjustment}";
		}
	}
}
