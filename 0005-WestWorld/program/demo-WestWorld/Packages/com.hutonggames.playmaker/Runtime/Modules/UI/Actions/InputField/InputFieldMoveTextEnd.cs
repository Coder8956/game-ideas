
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("Move the caret index to end of text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldMoveTextEnd : BaseAction
	{
		
		[Tooltip("The InputField.")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Only move the selectionPosition.")]
		[SerializeField]
		private BoolVar _shift;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _shift);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.InputField.MoveTextEnd(System.Boolean);
			_inputField.Value.MoveTextEnd(_shift.Value);
		}
		
		public override string GetSummary()
		{
			return "Move {_inputField} text end {_shift}";
		}
	}
}
