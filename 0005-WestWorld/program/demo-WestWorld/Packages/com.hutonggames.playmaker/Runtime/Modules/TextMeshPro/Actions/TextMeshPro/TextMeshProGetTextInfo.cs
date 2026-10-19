
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Function used to evaluate the length of a text string.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProGetTextInfo : BaseAction
	{
		
		[Tooltip("The TextMeshPro.")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Text.")]
		[SerializeField]
		private StringVar _text;
		
		[Tooltip("Store the result in TMP_TextInfo variable.")]
		[SerializeField]
		[WriteOnly]
		private TMP_TextInfoRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _text, _result);
		}
		
		public override void Execute()
		{
			//TMPro.TextMeshPro.GetTextInfo(System.String);
			_result.Value = _textMeshPro.Value.GetTextInfo(_text.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_textMeshPro} text info {_text} -> {_result}";
		}
	}
}
