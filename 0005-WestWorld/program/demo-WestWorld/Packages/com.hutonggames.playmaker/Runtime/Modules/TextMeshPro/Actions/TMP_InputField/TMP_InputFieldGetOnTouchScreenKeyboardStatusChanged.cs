/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get The UnityEvent to call when the touch screen keyboard status changes.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetOnTouchScreenKeyboardStatusChanged : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField On Touch Screen Keyboard Status Changed")]
		[SerializeField]
		[WriteOnly]
		private TMP_InputField_TouchScreenKeyboardEventRef _getOnTouchScreenKeyboardStatusChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getOnTouchScreenKeyboardStatusChanged);
		}
		
		public override void Execute()
		{
			_getOnTouchScreenKeyboardStatusChanged.Value = _tMP_InputField.Value.onTouchScreenKeyboardStatusChanged;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} on touch screen keyboard status changed -> {_getOnTouchScreenKeyboardStatusChanged}";
		}
	}
}
*/