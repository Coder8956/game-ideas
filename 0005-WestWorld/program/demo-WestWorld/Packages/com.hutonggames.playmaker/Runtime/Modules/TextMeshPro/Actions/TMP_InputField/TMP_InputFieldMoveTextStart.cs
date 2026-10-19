
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Move to the start of the text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldMoveTextStart : BaseAction
	{
		
		[Tooltip("The TMP_InputField.")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Shift.")]
		[SerializeField]
		private BoolVar _shift;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _shift);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_InputField.MoveTextStart(System.Boolean);
			_tMP_InputField.Value.MoveTextStart(_shift.Value);
		}
		
		public override string GetSummary()
		{
			return "Move {_tMP_InputField} text start {_shift}";
		}
	}
}
