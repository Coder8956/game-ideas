
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The UnityEvent to call when the touch screen keyboard status changes.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldOnTouchScreenKeyboardStatusChanged__UnityEvent : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField On Touch Screen Keyboard Status Changed")]
		[SerializeField]
		private TMP_InputField_TouchScreenKeyboardEventVar _setOnTouchScreenKeyboardStatusChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setOnTouchScreenKeyboardStatusChanged);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.onTouchScreenKeyboardStatusChanged = _setOnTouchScreenKeyboardStatusChanged.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} on touch screen keyboard status changed to {_setOnTouchScreenKeyboardStatusChanged}";
		}
	}
}
