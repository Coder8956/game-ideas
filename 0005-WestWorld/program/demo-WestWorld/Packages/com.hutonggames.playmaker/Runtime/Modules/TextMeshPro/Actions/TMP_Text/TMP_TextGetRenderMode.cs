
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Determines if the Mesh will be rendered.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetRenderMode : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Render Mode")]
		[SerializeField]
		[WriteOnly]
		private TextRenderFlagsRef _getRenderMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getRenderMode);
		}
		
		public override void Execute()
		{
			_getRenderMode.Value = _tMP_Text.Value.renderMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} render mode -> {_getRenderMode}";
		}
	}
}
