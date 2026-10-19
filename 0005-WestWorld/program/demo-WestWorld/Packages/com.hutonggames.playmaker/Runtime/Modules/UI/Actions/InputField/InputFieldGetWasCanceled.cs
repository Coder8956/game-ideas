
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("If the UI.InputField was canceled and will revert back to the original text upon " +
		"DeactivateInputField.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldGetWasCanceled : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Get InputField Was Canceled")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getWasCanceled;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _getWasCanceled);
		}
		
		public override void Execute()
		{
			_getWasCanceled.Value = _inputField.Value.wasCanceled;
		}
		
		public override string GetSummary()
		{
			return "Get {_inputField} was canceled -> {_getWasCanceled}";
		}
	}
}
