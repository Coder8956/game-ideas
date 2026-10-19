
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The type of validation to perform on a character")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetCharacterValidation : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Character Validation")]
		[SerializeField]
		private TMP_InputField_CharacterValidationVar _setCharacterValidation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setCharacterValidation);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.characterValidation = _setCharacterValidation.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} character validation to {_setCharacterValidation}";
		}
	}
}
