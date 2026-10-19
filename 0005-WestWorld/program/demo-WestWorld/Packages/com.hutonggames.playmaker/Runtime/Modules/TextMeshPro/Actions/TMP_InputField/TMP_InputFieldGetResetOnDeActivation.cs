
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Determines if the text and caret position as well as selection will be reset when" +
		" the Input Field is deactivated.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetResetOnDeActivation : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Reset On De Activation")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getResetOnDeActivation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getResetOnDeActivation);
		}
		
		public override void Execute()
		{
			_getResetOnDeActivation.Value = _tMP_InputField.Value.resetOnDeActivation;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} reset on de activation -> {_getResetOnDeActivation}";
		}
	}
}
