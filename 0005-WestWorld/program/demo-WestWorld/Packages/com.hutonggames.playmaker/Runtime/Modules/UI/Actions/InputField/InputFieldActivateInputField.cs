
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ConvertibleGroup("InputFieldActivate")]
	[ActionDescription("Function to activate the InputField to begin processing Events.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldActivateInputField : BaseAction
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
			//UnityEngine.UI.InputField.ActivateInputField();
			_inputField.Value.ActivateInputField();
		}
		
		public override string GetSummary()
		{
			return "Activate {_inputField}";
		}
	}
}
