
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Horizontal alignment options")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetHorizontalAlignment : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Horizontal Alignment")]
		[SerializeField]
		private HorizontalAlignmentOptionsVar _setHorizontalAlignment;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setHorizontalAlignment);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.horizontalAlignment = _setHorizontalAlignment.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} horizontal alignment to {_setHorizontalAlignment}";
		}
	}
}
