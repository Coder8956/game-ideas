
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Enables or Disables parsing of CTRL characters in input text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetParseCtrlCharacters : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Parse Ctrl Characters")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getParseCtrlCharacters;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getParseCtrlCharacters);
		}
		
		public override void Execute()
		{
			_getParseCtrlCharacters.Value = _tMP_Text.Value.parseCtrlCharacters;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} parse ctrl characters -> {_getParseCtrlCharacters}";
		}
	}
}
