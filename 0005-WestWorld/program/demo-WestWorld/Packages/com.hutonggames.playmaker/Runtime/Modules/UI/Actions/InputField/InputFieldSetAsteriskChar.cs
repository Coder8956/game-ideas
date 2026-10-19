
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("The character used for password fields.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetAsteriskChar : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Asterisk Char")]
		[SerializeField]
		private CharVar _setAsteriskChar;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setAsteriskChar);
		}
		
		public override void Execute()
		{
			_inputField.Value.asteriskChar = _setAsteriskChar.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} asterisk char to {_setAsteriskChar}";
		}
	}
}
