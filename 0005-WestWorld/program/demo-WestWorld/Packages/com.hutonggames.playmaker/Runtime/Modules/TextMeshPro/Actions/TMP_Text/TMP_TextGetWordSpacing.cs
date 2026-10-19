
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Word spacing.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetWordSpacing : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Word Spacing")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getWordSpacing;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getWordSpacing);
		}
		
		public override void Execute()
		{
			_getWordSpacing.Value = _tMP_Text.Value.wordSpacing;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} word spacing -> {_getWordSpacing}";
		}
	}
}
