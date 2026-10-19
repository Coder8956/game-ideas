
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sets the vertex colors for each of the 4 vertices of the character quads.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetColorGradient : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Color Gradient")]
		[SerializeField]
		private VertexGradientVar _setColorGradient;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setColorGradient);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.colorGradient = _setColorGradient.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} color gradient to {_setColorGradient}";
		}
	}
}
