
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("Should the mobile keyboard input be hidden.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetShouldHideMobileInput : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Should Hide Mobile Input")]
		[SerializeField]
		private BoolVar _setShouldHideMobileInput;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setShouldHideMobileInput);
		}
		
		public override void Execute()
		{
			_inputField.Value.shouldHideMobileInput = _setShouldHideMobileInput.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} should hide mobile input to {_setShouldHideMobileInput}";
		}
	}
}
