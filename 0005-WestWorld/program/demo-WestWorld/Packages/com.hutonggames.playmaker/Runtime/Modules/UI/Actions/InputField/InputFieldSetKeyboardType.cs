
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("They type of mobile keyboard that will be used.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetKeyboardType : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Keyboard Type")]
		[SerializeField]
		private TouchScreenKeyboardTypeVar _setKeyboardType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setKeyboardType);
		}
		
		public override void Execute()
		{
			_inputField.Value.keyboardType = _setKeyboardType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} keyboard type to {_setKeyboardType}";
		}
	}
}
