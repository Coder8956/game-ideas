
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Word Wrapping Ratios")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetWordWrappingRatios : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Word Wrapping Ratios")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getWordWrappingRatios;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getWordWrappingRatios);
		}
		
		public override void Execute()
		{
			_getWordWrappingRatios.Value = _tMP_Text.Value.wordWrappingRatios;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} word wrapping ratios -> {_getWordWrappingRatios}";
		}
	}
}
