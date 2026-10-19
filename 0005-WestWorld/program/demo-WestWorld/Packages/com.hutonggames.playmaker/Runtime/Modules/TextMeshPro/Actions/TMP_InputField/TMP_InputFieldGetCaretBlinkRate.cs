
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get the Caret Blink Rate of a TMP_InputField.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetCaretBlinkRate : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Caret Blink Rate")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getCaretBlinkRate;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getCaretBlinkRate);
		}
		
		public override void Execute()
		{
			_getCaretBlinkRate.Value = _tMP_InputField.Value.caretBlinkRate;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} caret blink rate -> {_getCaretBlinkRate}";
		}
	}
}
