
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Determines if Vertex Color Gradient should be used")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetEnableVertexGradient : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Enable Vertex Gradient")]
		[SerializeField]
		private BoolVar _setEnableVertexGradient;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setEnableVertexGradient);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.enableVertexGradient = _setEnableVertexGradient.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} enable vertex gradient to {_setEnableVertexGradient}";
		}
	}
}
