
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Determines if Vertex Color Gradient should be used")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetEnableVertexGradient : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Enable Vertex Gradient")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getEnableVertexGradient;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getEnableVertexGradient);
		}
		
		public override void Execute()
		{
			_getEnableVertexGradient.Value = _tMP_Text.Value.enableVertexGradient;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} enable vertex gradient -> {_getEnableVertexGradient}";
		}
	}
}
