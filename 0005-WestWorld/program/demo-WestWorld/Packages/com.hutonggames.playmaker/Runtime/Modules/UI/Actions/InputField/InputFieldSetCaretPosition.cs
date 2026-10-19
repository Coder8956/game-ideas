
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("Current InputField caret position (also selection tail).")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetCaretPosition : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Caret Position")]
		[SerializeField]
		private IntegerVar _setCaretPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setCaretPosition);
		}
		
		public override void Execute()
		{
			_inputField.Value.caretPosition = _setCaretPosition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} caret position to {_setCaretPosition}";
		}
	}
}
