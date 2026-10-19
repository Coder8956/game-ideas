
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
	public sealed class InputFieldGetTextComponent : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Get InputField Text Component")]
		[SerializeField]
		[WriteOnly]
		private TextVar _getTextComponent;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _getTextComponent);
		}
		
		public override void Execute()
		{
			_getTextComponent.Value = _inputField.Value.textComponent;
		}
		
		public override string GetSummary()
		{
			return "Get {_inputField} text component -> {_getTextComponent}";
		}
	}
}
