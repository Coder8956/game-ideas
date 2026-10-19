
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The blink rate of the caret.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetCaretBlinkRate : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Caret Blink Rate")]
		[SerializeField]
		private FloatVar _setCaretBlinkRate;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setCaretBlinkRate);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.caretBlinkRate = _setCaretBlinkRate.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} caret blink rate to {_setCaretBlinkRate}";
		}
	}
}
