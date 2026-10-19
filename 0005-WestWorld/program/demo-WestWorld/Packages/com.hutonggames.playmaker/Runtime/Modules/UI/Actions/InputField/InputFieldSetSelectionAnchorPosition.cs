
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("The beginning point of the selection.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetSelectionAnchorPosition : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Selection Anchor Position")]
		[SerializeField]
		private IntegerVar _setSelectionAnchorPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setSelectionAnchorPosition);
		}
		
		public override void Execute()
		{
			_inputField.Value.selectionAnchorPosition = _setSelectionAnchorPosition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} selection anchor position to {_setSelectionAnchorPosition}";
		}
	}
}
