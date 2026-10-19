
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Use Max Visible Descender.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetUseMaxVisibleDescender : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Use Max Visible Descender")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseMaxVisibleDescender;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getUseMaxVisibleDescender);
		}
		
		public override void Execute()
		{
			_getUseMaxVisibleDescender.Value = _tMP_Text.Value.useMaxVisibleDescender;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} use max visible descender -> {_getUseMaxVisibleDescender}";
		}
	}
}
