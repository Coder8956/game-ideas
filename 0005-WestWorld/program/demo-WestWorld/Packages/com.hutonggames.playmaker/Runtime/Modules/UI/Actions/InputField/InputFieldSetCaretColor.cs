
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("The custom caret color used if customCaretColor is set.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetCaretColor : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Caret Color")]
		[SerializeField]
		private ColorVar _setCaretColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setCaretColor);
		}
		
		public override void Execute()
		{
			_inputField.Value.caretColor = _setCaretColor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} caret color to {_setCaretColor}";
		}
	}
}
