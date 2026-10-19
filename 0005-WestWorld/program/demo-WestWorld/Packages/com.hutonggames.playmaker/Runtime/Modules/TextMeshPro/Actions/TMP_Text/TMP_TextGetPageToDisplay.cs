
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Controls which page of text is shown")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetPageToDisplay : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Page To Display")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getPageToDisplay;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getPageToDisplay);
		}
		
		public override void Execute()
		{
			_getPageToDisplay.Value = _tMP_Text.Value.pageToDisplay;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} page to display -> {_getPageToDisplay}";
		}
	}
}
