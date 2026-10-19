
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Set Input Field\'s current text value without invoke onValueChanged. " +
	                   "This is not necessarily the same as what is visible on screen.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetTextWithoutNotify : BaseAction
	{
		
		[Tooltip("The TMP_InputField.")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Input." +
		         "\n<b>Tip</b>: Enable Use Variable Tokens to insert values with {VariableName}.")]
		[SerializeField]
		private StringVar _input;

		[Tooltip("Resolve {VariableName} and {VariableName.Property} tokens in the text.")]
		[SerializeField, DefaultValue(false)]
		private BoolVar _useVariableTokens;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _input);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_InputField.SetTextWithoutNotify(System.String);
			_tMP_InputField.Value.SetTextWithoutNotify(_useVariableTokens.Value
				? DebugLogTextFormatter.Format(_input.Value, Fsm?.Variables)
				: _input.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} text without notify to {_input}";
		}
	}
}
