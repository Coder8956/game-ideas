
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Compute the rendered width of the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetRenderedWidth : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Rendered Width")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getRenderedWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getRenderedWidth);
		}
		
		public override void Execute()
		{
			_getRenderedWidth.Value = _tMP_Text.Value.renderedWidth;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} rendered width -> {_getRenderedWidth}";
		}
	}
}
