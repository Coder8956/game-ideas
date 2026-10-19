
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Enables or Disables Rich Text Tags")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetRichText : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Rich Text")]
		[SerializeField]
		private BoolVar _setRichText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setRichText);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.richText = _setRichText.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} rich text to {_setRichText}";
		}
	}
}
