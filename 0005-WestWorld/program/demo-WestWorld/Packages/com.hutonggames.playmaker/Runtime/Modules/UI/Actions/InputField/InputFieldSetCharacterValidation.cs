
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("The type of validation to perform on a character.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetCharacterValidation : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Character Validation")]
		[SerializeField]
		private InputField_CharacterValidationVar _setCharacterValidation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setCharacterValidation);
		}
		
		public override void Execute()
		{
			_inputField.Value.characterValidation = _setCharacterValidation.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} character validation to {_setCharacterValidation}";
		}
	}
}
