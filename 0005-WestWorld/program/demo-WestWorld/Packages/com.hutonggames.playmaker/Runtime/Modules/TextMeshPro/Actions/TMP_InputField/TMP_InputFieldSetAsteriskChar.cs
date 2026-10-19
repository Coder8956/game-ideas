
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The character used for password fields.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetAsteriskChar : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Asterisk Char")]
		[SerializeField]
		private CharVar _setAsteriskChar;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setAsteriskChar);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.asteriskChar = _setAsteriskChar.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} asterisk char to {_setAsteriskChar}";
		}
	}
}
