
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Returns data about the text object which includes information about each character, word, line, link, etc.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetTextInfo : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Text Info")]
		[SerializeField]
		[WriteOnly]
		private TMP_TextInfoRef _getTextInfo;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getTextInfo);
		}
		
		public override void Execute()
		{
			_getTextInfo.Value = _tMP_Text.Value.textInfo;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} text info -> {_getTextInfo}";
		}
	}
}
