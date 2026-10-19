
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("The width of the caret in pixels.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetCaretWidth : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Caret Width")]
		[SerializeField]
		private IntegerVar _setCaretWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setCaretWidth);
		}
		
		public override void Execute()
		{
			_inputField.Value.caretWidth = _setCaretWidth.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} caret width to {_setCaretWidth}";
		}
	}
}
