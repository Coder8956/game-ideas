
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Enables or Disables Rich Text Tags")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetRichText : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Rich Text")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getRichText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getRichText);
		}
		
		public override void Execute()
		{
			_getRichText.Value = _tMP_Text.Value.richText;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} rich text -> {_getRichText}";
		}
	}
}
