
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("Specifies the type of the input text content.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetContentType : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Content Type")]
		[SerializeField]
		private InputField_ContentTypeVar _setContentType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setContentType);
		}
		
		public override void Execute()
		{
			_inputField.Value.contentType = _setContentType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} content type to {_setContentType}";
		}
	}
}
