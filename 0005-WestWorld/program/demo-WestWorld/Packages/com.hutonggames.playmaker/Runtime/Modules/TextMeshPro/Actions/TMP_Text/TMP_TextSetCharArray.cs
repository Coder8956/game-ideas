
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Set the text using a char array.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetCharArray : BaseAction
	{
		
		[Tooltip("The TMP_Text.")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Source char array containing the Unicode characters of the text.")]
		[SerializeField]
		private CharListVar _sourceText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _sourceText);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Text.SetCharArray(System.Char[]);
			_tMP_Text.Value.SetCharArray(_sourceText.Values);
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} char array {_sourceText}";
		}
	}
}
