/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sets Text Chars Index on TMP Text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetText__CharsIndex : BaseAction
	{
		
		[Tooltip("The TMP_Text.")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Source Text.")]
		[SerializeField]
		private CharListVar _sourceText;
		
		[Tooltip("Start.")]
		[SerializeField]
		private IntegerVar _start;
		
		[Tooltip("Length.")]
		[SerializeField]
		private IntegerVar _length;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _sourceText, _start, _length);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Text.SetText(System.Char[], System.Int32, System.Int32);
			_tMP_Text.Value.SetText(_sourceText.Values, _start.Value, _length.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} text {_sourceText} {_start} {_length}";
		}
	}
}
*/