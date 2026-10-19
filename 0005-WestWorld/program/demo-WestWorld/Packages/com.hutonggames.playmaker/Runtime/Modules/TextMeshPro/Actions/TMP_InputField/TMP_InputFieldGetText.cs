
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Input field\'s current text value. This is not necessarily the same as what is vis" +
		"ible on screen.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetText : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Text")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getText);
		}
		
		public override void Execute()
		{
			_getText.Value = _tMP_InputField.Value.text;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} text -> {_getText}";
		}
	}
}
