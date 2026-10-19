
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get the character limit of a TMP_InputField.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetCharacterLimit : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Character Limit")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getCharacterLimit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getCharacterLimit);
		}
		
		public override void Execute()
		{
			_getCharacterLimit.Value = _tMP_InputField.Value.characterLimit;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} character limit -> {_getCharacterLimit}";
		}
	}
}
