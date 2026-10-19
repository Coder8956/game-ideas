
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sets the RenderQueue along with Ztest to force the text to be drawn last and on top of scene elements.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetIsOverlay : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Is Overlay")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsOverlay;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getIsOverlay);
		}
		
		public override void Execute()
		{
			_getIsOverlay.Value = _tMP_Text.Value.isOverlay;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} is overlay -> {_getIsOverlay}";
		}
	}
}
