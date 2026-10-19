
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The variable position of the selection in the raw string which may contains rich " +
		"text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetSelectionStringFocusPosition : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Selection String Focus Position")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getSelectionStringFocusPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getSelectionStringFocusPosition);
		}
		
		public override void Execute()
		{
			_getSelectionStringFocusPosition.Value = _tMP_InputField.Value.selectionStringFocusPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} selection string focus position -> {_getSelectionStringFocusPosition}";
		}
	}
}
