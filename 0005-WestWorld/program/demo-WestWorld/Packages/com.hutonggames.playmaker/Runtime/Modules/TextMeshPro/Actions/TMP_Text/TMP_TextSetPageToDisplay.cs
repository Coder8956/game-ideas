
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Controls which page of text is shown")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetPageToDisplay : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Page To Display")]
		[SerializeField]
		private IntegerVar _setPageToDisplay;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setPageToDisplay);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.pageToDisplay = _setPageToDisplay.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} page to display to {_setPageToDisplay}";
		}
	}
}
