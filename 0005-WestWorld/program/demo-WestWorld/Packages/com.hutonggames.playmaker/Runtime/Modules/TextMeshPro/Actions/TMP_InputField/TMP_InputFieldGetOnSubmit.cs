/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get The UnityEvent to call when the Input Field is submitted.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetOnSubmit : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField On Submit")]
		[SerializeField]
		[WriteOnly]
		private TMP_InputField_SubmitEventRef _getOnSubmit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getOnSubmit);
		}
		
		public override void Execute()
		{
			_getOnSubmit.Value = _tMP_InputField.Value.onSubmit;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} on submit -> {_getOnSubmit}";
		}
	}
}
*/