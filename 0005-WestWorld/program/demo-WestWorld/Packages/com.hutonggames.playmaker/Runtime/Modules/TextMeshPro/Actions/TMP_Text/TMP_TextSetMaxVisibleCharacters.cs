
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Allows to control how many characters are visible from the input.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetMaxVisibleCharacters : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Max Visible Characters")]
		[SerializeField]
		private IntegerVar _setMaxVisibleCharacters;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setMaxVisibleCharacters);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.maxVisibleCharacters = _setMaxVisibleCharacters.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} max visible characters to {_setMaxVisibleCharacters}";
		}
	}
}
