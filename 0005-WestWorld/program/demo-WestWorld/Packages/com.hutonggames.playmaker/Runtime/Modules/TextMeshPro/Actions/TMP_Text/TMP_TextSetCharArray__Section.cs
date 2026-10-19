
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Set the text using a char array and specifying the starting character index and length.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetCharArray__Section : BaseAction
	{
		
		[Tooltip("The TMP_Text.")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Source char array containing the Unicode characters of the text.")]
		[SerializeField]
		private CharListVar _sourceText;
		
		[Tooltip("Index of the first character to read from in the array.")]
		[SerializeField]
		private IntegerVar _start;
		
		[Tooltip("The number of characters in the array to be read.")]
		[SerializeField]
		private IntegerVar _length;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _sourceText, _start, _length);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Text.SetCharArray(System.Char[], System.Int32, System.Int32);
			_tMP_Text.Value.SetCharArray(_sourceText.Values, _start.Value, _length.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} char array {_sourceText} {_start} {_length}";
		}
	}
}
