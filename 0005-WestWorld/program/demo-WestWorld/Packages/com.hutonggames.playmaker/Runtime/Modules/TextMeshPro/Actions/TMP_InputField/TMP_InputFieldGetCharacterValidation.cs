
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The type of validation to perform on a character")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetCharacterValidation : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Character Validation")]
		[SerializeField]
		[WriteOnly]
		private TMP_InputField_CharacterValidationRef _getCharacterValidation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getCharacterValidation);
		}
		
		public override void Execute()
		{
			_getCharacterValidation.Value = _tMP_InputField.Value.characterValidation;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} character validation -> {_getCharacterValidation}";
		}
	}
}
