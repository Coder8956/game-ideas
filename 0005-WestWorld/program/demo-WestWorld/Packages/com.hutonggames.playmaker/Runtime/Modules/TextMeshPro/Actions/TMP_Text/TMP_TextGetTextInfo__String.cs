
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Returns data about the text object which includes information about each character, word, line, link, etc.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetTextInfo__String : BaseAction
	{
		
		[Tooltip("The TMP_Text.")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Text.")]
		[SerializeField]
		private StringVar _text;
		
		[Tooltip("Store the result in TMP_TextInfo variable.")]
		[SerializeField]
		[WriteOnly]
		private TMP_TextInfoRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _text, _result);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Text.GetTextInfo(System.String);
			_result.Value = _tMP_Text.Value.GetTextInfo(_text.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} text info {_text} -> {_result}";
		}
	}
}
