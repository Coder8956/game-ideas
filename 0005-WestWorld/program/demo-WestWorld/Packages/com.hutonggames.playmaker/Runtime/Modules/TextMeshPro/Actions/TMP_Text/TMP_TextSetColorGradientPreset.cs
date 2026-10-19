
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Set the vertex colors of the 4 vertices of each character quads.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetColorGradientPreset : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Color Gradient Preset")]
		[SerializeField, CanBeNullOrEmpty]
		private TMP_ColorGradientVar _setColorGradientPreset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.colorGradientPreset = _setColorGradientPreset.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} color gradient preset to {_setColorGradientPreset}";
		}
	}
}
