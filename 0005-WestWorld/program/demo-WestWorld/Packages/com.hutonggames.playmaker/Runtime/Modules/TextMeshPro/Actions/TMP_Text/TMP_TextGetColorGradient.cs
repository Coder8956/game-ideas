
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sets the vertex colors for each of the 4 vertices of the character quads.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetColorGradient : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Color Gradient")]
		[SerializeField]
		[WriteOnly]
		private VertexGradientRef _getColorGradient;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getColorGradient);
		}
		
		public override void Execute()
		{
			_getColorGradient.Value = _tMP_Text.Value.colorGradient;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} color gradient -> {_getColorGradient}";
		}
	}
}
