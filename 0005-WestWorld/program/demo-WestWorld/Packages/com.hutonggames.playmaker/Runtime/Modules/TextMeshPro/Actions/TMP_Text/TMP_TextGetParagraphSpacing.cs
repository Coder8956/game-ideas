
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The amount of additional spacing to add between each lines of text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetParagraphSpacing : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Paragraph Spacing")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getParagraphSpacing;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getParagraphSpacing);
		}
		
		public override void Execute()
		{
			_getParagraphSpacing.Value = _tMP_Text.Value.paragraphSpacing;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} paragraph spacing -> {_getParagraphSpacing}";
		}
	}
}
