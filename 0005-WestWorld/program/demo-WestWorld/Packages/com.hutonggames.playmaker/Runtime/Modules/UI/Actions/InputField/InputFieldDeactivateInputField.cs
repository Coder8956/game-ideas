
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ConvertibleGroup("InputFieldActivate")]
	[ActionDescription("Function to deactivate the InputField to stop the processing of Events and send O" +
		"nSubmit if not canceled.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldDeactivateInputField : BaseAction
	{
		
		[Tooltip("The InputField.")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.InputField.DeactivateInputField();
			_inputField.Value.DeactivateInputField();
		}
		
		public override string GetSummary()
		{
			return "Deactivate {_inputField}";
		}
	}
}
