
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get the Caret Color of a TMP_InputField.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetCaretColor : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Caret Color")]
		[SerializeField]
		[WriteOnly]
		private ColorRef _getCaretColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getCaretColor);
		}
		
		public override void Execute()
		{
			_getCaretColor.Value = _tMP_InputField.Value.caretColor;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} caret color -> {_getCaretColor}";
		}
	}
}
