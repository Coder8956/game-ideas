
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Set the maximum number of characters the user can type.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetCharacterLimit : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Character Limit")]
		[SerializeField]
		private IntegerVar _setCharacterLimit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setCharacterLimit);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.characterLimit = _setCharacterLimit.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} character limit to {_setCharacterLimit}";
		}
	}
}
