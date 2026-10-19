
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("Unity Event called when the InputField value changes.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldOnValueChanged__UnityEvent : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField On Value Changed")]
		[SerializeField]
		private InputField_OnChangeEventVar _setOnValueChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setOnValueChanged);
		}
		
		public override void Execute()
		{
			_inputField.Value.onValueChanged = _setOnValueChanged.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} on value changed to {_setOnValueChanged}";
		}
	}
}
