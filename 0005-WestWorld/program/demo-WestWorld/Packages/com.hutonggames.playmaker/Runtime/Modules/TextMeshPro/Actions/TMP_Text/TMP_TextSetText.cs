
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ConvertibleGroup("SetText")]
	[ActionDescription("Set the text to display.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetText : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Text." +
		         "\n<b>Tip</b>: Enable Use Variable Tokens to insert values with {VariableName}.")]
		[SerializeField, CanBeNullOrEmpty]
		private StringVar _setText;

		[Tooltip("Resolve {VariableName} and {VariableName.Property} tokens in the text.")]
		[SerializeField, DefaultValue(false)]
		private BoolVar _useVariableTokens;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setText);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.text = _useVariableTokens.Value
				? DebugLogTextFormatter.Format(_setText.Value, Fsm?.Variables)
				: _setText.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} text to {_setText}";
		}
	}
}
