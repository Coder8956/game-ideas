
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription(@"This is an optional ‘empty’ graphic to show that the InputField text field is empty. Note that this ‘empty' graphic still displays even when the InputField is selected (that is; when there is focus on it). A placeholder graphic can be used to show subtle hints or make it more obvious that the control is an InputField.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetPlaceholder : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Placeholder")]
		[SerializeField, CanBeNullOrEmpty]
		private GraphicVar _setPlaceholder;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField);
		}
		
		public override void Execute()
		{
			_inputField.Value.placeholder = _setPlaceholder.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} placeholder to {_setPlaceholder}";
		}
	}
}
