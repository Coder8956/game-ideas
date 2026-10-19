
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("The color of the highlight to show which characters are selected.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetSelectionColor : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Selection Color")]
		[SerializeField]
		private ColorVar _setSelectionColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setSelectionColor);
		}
		
		public override void Execute()
		{
			_inputField.Value.selectionColor = _setSelectionColor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} selection color to {_setSelectionColor}";
		}
	}
}
