
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Input field\'s current text value. This is not necessarily the same as what is visible on screen.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetText : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Text." +
		         "\n<b>Tip</b>: Enable Use Variable Tokens to insert values with {VariableName}.")]
		[SerializeField, CanBeNullOrEmpty]
		private StringVar _setText;

		[Tooltip("Resolve {VariableName} and {VariableName.Property} tokens in the text.")]
		[SerializeField, DefaultValue(false)]
		private BoolVar _useVariableTokens;
		
		public override bool CanExecute() => CheckParameters(_tMP_InputField);

		public override void Execute() => _tMP_InputField.Value.text = _useVariableTokens.Value
			? DebugLogTextFormatter.Format(_setText.Value, Fsm?.Variables)
			: _setText.Value;

		public override string GetSummary() => "Set {_tMP_InputField} Text to {_setText}";
	}
}
