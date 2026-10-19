
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Text alignment options")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetAlignment : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Alignment")]
		[SerializeField]
		[WriteOnly]
		private TextAlignmentOptionsRef _getAlignment;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getAlignment);
		}
		
		public override void Execute()
		{
			_getAlignment.Value = _tMP_Text.Value.alignment;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} alignment -> {_getAlignment}";
		}
	}
}
