
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The Font Asset to be assigned to this text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetFont : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Font")]
		[SerializeField]
		[WriteOnly]
		private TMP_FontAssetRef _getFont;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getFont);
		}
		
		public override void Execute()
		{
			_getFont.Value = _tMP_Text.Value.font;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} font -> {_getFont}";
		}
	}
}
