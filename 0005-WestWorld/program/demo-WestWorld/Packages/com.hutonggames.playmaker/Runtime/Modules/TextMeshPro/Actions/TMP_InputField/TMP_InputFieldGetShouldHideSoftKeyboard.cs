
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Should Hide Soft Keyboard.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetShouldHideSoftKeyboard : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Should Hide Soft Keyboard")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getShouldHideSoftKeyboard;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getShouldHideSoftKeyboard);
		}
		
		public override void Execute()
		{
			_getShouldHideSoftKeyboard.Value = _tMP_InputField.Value.shouldHideSoftKeyboard;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} should hide soft keyboard -> {_getShouldHideSoftKeyboard}";
		}
	}
}
