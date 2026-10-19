
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("The end point of the selection.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetSelectionFocusPosition : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Selection Focus Position")]
		[SerializeField]
		private IntegerVar _setSelectionFocusPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setSelectionFocusPosition);
		}
		
		public override void Execute()
		{
			_inputField.Value.selectionFocusPosition = _setSelectionFocusPosition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} selection focus position to {_setSelectionFocusPosition}";
		}
	}
}
