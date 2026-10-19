
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Function used to evaluate the length of a text string.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUIGetTextInfo : BaseAction
	{
		
		[Tooltip("The TextMeshProUGUI.")]
		[SerializeField]
		private TextMeshProUGUIVar _textMeshProUGUI;
		
		[Tooltip("Text.")]
		[SerializeField]
		private StringVar _text;
		
		[Tooltip("Store the result in TMP_TextInfo variable.")]
		[SerializeField]
		[WriteOnly]
		private TMP_TextInfoRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshProUGUI, _text, _result);
		}
		
		public override void Execute()
		{
			//TMPro.TextMeshProUGUI.GetTextInfo(System.String);
			_result.Value = _textMeshProUGUI.Value.GetTextInfo(_text.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_textMeshProUGUI} text info {_text} -> {_result}";
		}
	}
}
