
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("Force the label to update immediatly. This will recalculate the positioning of th" +
		"e caret and the visible text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldForceLabelUpdate : BaseAction
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
			//UnityEngine.UI.InputField.ForceLabelUpdate();
			_inputField.Value.ForceLabelUpdate();
		}
		
		public override string GetSummary()
		{
			return "Force {_inputField} label update";
		}
	}
}
