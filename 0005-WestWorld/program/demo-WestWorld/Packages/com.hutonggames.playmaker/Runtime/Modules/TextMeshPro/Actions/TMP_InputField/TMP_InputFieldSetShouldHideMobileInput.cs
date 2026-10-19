
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Should the mobile keyboard input be hidden.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetShouldHideMobileInput : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Should Hide Mobile Input")]
		[SerializeField]
		private BoolVar _setShouldHideMobileInput;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setShouldHideMobileInput);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.shouldHideMobileInput = _setShouldHideMobileInput.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} should hide mobile input to {_setShouldHideMobileInput}";
		}
	}
}
