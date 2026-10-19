
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Set the vertex colors of the 4 vertices of each character quads.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetColorGradientPreset : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Color Gradient Preset")]
		[SerializeField]
		[WriteOnly]
		private TMP_ColorGradientRef _getColorGradientPreset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getColorGradientPreset);
		}
		
		public override void Execute()
		{
			_getColorGradientPreset.Value = _tMP_Text.Value.colorGradientPreset;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} color gradient preset -> {_getColorGradientPreset}";
		}
	}
}
