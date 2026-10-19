
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("The Text component that is going to be used to render the text to screen.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetTextComponent : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Text Component")]
		[SerializeField, CanBeNullOrEmpty]
		private TextVar _setTextComponent;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField);
		}
		
		public override void Execute()
		{
			_inputField.Value.textComponent = _setTextComponent.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} text component to {_setTextComponent}";
		}
	}
}
