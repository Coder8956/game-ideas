
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Enables or Disables parsing of CTRL characters in input text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetParseCtrlCharacters : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Parse Ctrl Characters")]
		[SerializeField]
		private BoolVar _setParseCtrlCharacters;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setParseCtrlCharacters);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.parseCtrlCharacters = _setParseCtrlCharacters.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} parse ctrl characters to {_setParseCtrlCharacters}";
		}
	}
}
