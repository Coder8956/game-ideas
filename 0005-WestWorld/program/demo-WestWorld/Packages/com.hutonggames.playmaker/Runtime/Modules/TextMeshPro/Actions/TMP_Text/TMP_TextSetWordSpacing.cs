
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The amount of additional spacing between words.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetWordSpacing : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Word Spacing")]
		[SerializeField]
		private FloatVar _setWordSpacing;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setWordSpacing);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.wordSpacing = _setWordSpacing.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} word spacing to {_setWordSpacing}";
		}
	}
}
