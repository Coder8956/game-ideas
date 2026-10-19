
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Function which returns the text after it has been parsed and rich text tags removed.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetParsedText : BaseAction
	{
		
		[Tooltip("The TMP_Text.")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _result);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Text.GetParsedText();
			_result.Value = _tMP_Text.Value.GetParsedText();
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} parsed text -> {_result}";
		}
	}
}
