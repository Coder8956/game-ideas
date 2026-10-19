
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("Unity Event to call when the InputField is submitted.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldOnSubmit__UnityEvent : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField On Submit")]
		[SerializeField]
		private InputField_SubmitEventVar _setOnSubmit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setOnSubmit);
		}
		
		public override void Execute()
		{
			_inputField.Value.onSubmit = _setOnSubmit.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} on submit to {_setOnSubmit}";
		}
	}
}
