
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The character used for password fields.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetAsteriskChar : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Asterisk Char")]
		[SerializeField]
		[WriteOnly]
		private CharRef _getAsteriskChar;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getAsteriskChar);
		}
		
		public override void Execute()
		{
			_getAsteriskChar.Value = _tMP_InputField.Value.asteriskChar;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} asterisk char -> {_getAsteriskChar}";
		}
	}
}
