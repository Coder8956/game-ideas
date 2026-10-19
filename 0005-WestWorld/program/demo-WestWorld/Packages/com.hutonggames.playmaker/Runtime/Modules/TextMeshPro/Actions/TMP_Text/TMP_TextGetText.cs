
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("A string containing the text to be displayed.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetText : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Text")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getText);
		}
		
		public override void Execute()
		{
			_getText.Value = _tMP_Text.Value.text;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} text -> {_getText}";
		}
	}
}
