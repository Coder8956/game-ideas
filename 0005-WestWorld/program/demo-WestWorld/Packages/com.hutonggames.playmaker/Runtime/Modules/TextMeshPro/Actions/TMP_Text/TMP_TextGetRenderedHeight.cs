
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Compute the rendered height of the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetRenderedHeight : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Rendered Height")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getRenderedHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getRenderedHeight);
		}
		
		public override void Execute()
		{
			_getRenderedHeight.Value = _tMP_Text.Value.renderedHeight;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} rendered height -> {_getRenderedHeight}";
		}
	}
}
