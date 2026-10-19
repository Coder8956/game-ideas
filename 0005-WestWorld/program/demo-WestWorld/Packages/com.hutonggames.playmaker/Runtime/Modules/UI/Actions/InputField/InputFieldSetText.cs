
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("The current value of the input field.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetText : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Text." +
		         "\n<b>Tip</b>: Enable Use Variable Tokens to insert values with {VariableName}.")]
		[SerializeField, CanBeNullOrEmpty]
		private StringVar _setText;

		[Tooltip("Resolve {VariableName} and {VariableName.Property} tokens in the text.")]
		[SerializeField, DefaultValue(false)]
		private BoolVar _useVariableTokens;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setText);
		}
		
		public override void Execute()
		{
			_inputField.Value.text = _useVariableTokens.Value
				? DebugLogTextFormatter.Format(_setText.Value, Fsm?.Variables)
				: _setText.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} text to {_setText}";
		}
	}
}
