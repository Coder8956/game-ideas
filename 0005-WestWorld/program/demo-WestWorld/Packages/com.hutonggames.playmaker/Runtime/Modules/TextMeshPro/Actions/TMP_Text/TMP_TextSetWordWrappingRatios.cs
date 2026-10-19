
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Controls the blending between using character and word spacing to fill-in the space for justified text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetWordWrappingRatios : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Word Wrapping Ratios")]
		[SerializeField]
		private FloatVar _setWordWrappingRatios;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setWordWrappingRatios);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.wordWrappingRatios = _setWordWrappingRatios.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} word wrapping ratios to {_setWordWrappingRatios}";
		}
	}
}
