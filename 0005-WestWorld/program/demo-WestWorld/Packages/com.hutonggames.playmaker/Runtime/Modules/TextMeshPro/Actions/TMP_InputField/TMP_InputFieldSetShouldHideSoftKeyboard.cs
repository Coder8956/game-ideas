
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Hide the soft keyboard.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetShouldHideSoftKeyboard : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Should Hide Soft Keyboard")]
		[SerializeField]
		private BoolVar _setShouldHideSoftKeyboard;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setShouldHideSoftKeyboard);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.shouldHideSoftKeyboard = _setShouldHideSoftKeyboard.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} should hide soft keyboard to {_setShouldHideSoftKeyboard}";
		}
	}
}
