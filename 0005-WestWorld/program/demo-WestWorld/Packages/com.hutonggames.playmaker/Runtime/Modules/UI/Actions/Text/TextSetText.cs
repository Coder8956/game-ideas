
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Text)]
	[ActionDescription("The string value this text will display.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Text.html")]
	public sealed class TextSetText : BaseAction
	{
		
		[Tooltip("The Text")]
		[SerializeField]
		private TextVar _text;
		
		[Tooltip("Set Text Text." +
		         "\n<b>Tip</b>: Enable Use Variable Tokens to insert values with {VariableName}.")]
		[SerializeField, CanBeNullOrEmpty]
		private StringVar _setText;

		[Tooltip("Resolve {VariableName} and {VariableName.Property} tokens in the text.")]
		[SerializeField, DefaultValue(false)]
		private BoolVar _useVariableTokens;
		
		public override bool CanExecute()
		{
			return _text.HasValue(true) && CheckParameters(_setText);
		}
		
		public override void Execute()
		{
			_text.Value.text = _useVariableTokens.Value
				? DebugLogTextFormatter.Format(_setText.Value, Fsm?.Variables)
				: _setText.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_text} text to {_setText} {_useVariableTokens:option}";
		}
	}
}
