
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("The type of input expected. See InputField.InputType.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetInputType : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Input Type")]
		[SerializeField]
		private InputField_InputTypeVar _setInputType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setInputType);
		}
		
		public override void Execute()
		{
			_inputField.Value.inputType = _setInputType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} input type to {_setInputType}";
		}
	}
}
