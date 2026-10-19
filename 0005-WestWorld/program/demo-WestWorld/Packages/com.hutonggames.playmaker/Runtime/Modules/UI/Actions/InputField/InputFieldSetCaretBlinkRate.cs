
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("The blinking rate of the input caret, defined as the number of times the blink cy" +
		"cle occurs per second.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetCaretBlinkRate : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Caret Blink Rate")]
		[SerializeField]
		private FloatVar _setCaretBlinkRate;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setCaretBlinkRate);
		}
		
		public override void Execute()
		{
			_inputField.Value.caretBlinkRate = _setCaretBlinkRate.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} caret blink rate to {_setCaretBlinkRate}";
		}
	}
}
