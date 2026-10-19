
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Should the mobile keyboard input be hidden.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetShouldHideMobileInput : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Should Hide Mobile Input")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getShouldHideMobileInput;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getShouldHideMobileInput);
		}
		
		public override void Execute()
		{
			_getShouldHideMobileInput.Value = _tMP_InputField.Value.shouldHideMobileInput;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} should hide mobile input -> {_getShouldHideMobileInput}";
		}
	}
}
