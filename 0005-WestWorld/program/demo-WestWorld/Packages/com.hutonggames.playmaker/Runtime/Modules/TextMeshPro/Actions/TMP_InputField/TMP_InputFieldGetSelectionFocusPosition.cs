
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get: Returns the variable position of selection\nSet: If compositionString is 0 se" +
		"t the variable position")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetSelectionFocusPosition : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Selection Focus Position")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getSelectionFocusPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getSelectionFocusPosition);
		}
		
		public override void Execute()
		{
			_getSelectionFocusPosition.Value = _tMP_InputField.Value.selectionFocusPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} selection focus position -> {_getSelectionFocusPosition}";
		}
	}
}
