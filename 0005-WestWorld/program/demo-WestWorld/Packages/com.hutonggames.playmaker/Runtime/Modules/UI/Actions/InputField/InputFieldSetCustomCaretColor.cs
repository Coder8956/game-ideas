
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("Should a custom caret color be used or should the textComponent.color be used.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetCustomCaretColor : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Custom Caret Color")]
		[SerializeField]
		private BoolVar _setCustomCaretColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setCustomCaretColor);
		}
		
		public override void Execute()
		{
			_inputField.Value.customCaretColor = _setCustomCaretColor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} custom caret color to {_setCustomCaretColor}";
		}
	}
}
