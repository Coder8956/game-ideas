
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Function to Calculate the Preferred Width and Height of the text object given a certain string.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetPreferredValues__String : BaseAction
	{
		
		[Tooltip("The TMP_Text.")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Text.")]
		[SerializeField]
		private StringVar _text;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _text, _result);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Text.GetPreferredValues(System.String);
			_result.Value = _tMP_Text.Value.GetPreferredValues(_text.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} preferred values {_text} -> {_result}";
		}
	}
}
