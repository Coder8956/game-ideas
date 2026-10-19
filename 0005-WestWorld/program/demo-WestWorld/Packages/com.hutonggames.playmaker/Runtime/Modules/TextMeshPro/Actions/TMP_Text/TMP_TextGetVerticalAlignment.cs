
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("VerticalAlignment options.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetVerticalAlignment : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Vertical Alignment")]
		[SerializeField]
		[WriteOnly]
		private VerticalAlignmentOptionsRef _getVerticalAlignment;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getVerticalAlignment);
		}
		
		public override void Execute()
		{
			_getVerticalAlignment.Value = _tMP_Text.Value.verticalAlignment;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} vertical alignment -> {_getVerticalAlignment}";
		}
	}
}
