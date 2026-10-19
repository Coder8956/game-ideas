
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Move to the end of the current line of text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldMoveToEndOfLine : BaseAction
	{
		
		[Tooltip("The TMP_InputField.")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Shift.")]
		[SerializeField]
		private BoolVar _shift;
		
		[Tooltip("Ctrl.")]
		[SerializeField]
		private BoolVar _ctrl;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _shift, _ctrl);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_InputField.MoveToEndOfLine(System.Boolean, System.Boolean);
			_tMP_InputField.Value.MoveToEndOfLine(_shift.Value, _ctrl.Value);
		}
		
		public override string GetSummary()
		{
			return "Move {_tMP_InputField} to end of line {_shift} {_ctrl}";
		}
	}
}
