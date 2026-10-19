
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get: Returns the focus position as thats the position that moves around even duri" +
		"ng selection.\nSet: Set both the anchor and focus position such that a selection " +
		"doesn\'t happen")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetCaretPosition : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Caret Position")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getCaretPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getCaretPosition);
		}
		
		public override void Execute()
		{
			_getCaretPosition.Value = _tMP_InputField.Value.caretPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} caret position -> {_getCaretPosition}";
		}
	}
}
