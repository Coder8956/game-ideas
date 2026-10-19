/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sets Text Chars on TMP Text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetText__Chars : BaseAction
	{
		
		[Tooltip("The TMP_Text.")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Source Text.")]
		[SerializeField]
		private CharListVar _sourceText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _sourceText);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Text.SetText(System.Char[]);
			_tMP_Text.Value.SetText(_sourceText.Values);
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} text {_sourceText}";
		}
	}
}
*/
