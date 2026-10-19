
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get: Returns the fixed position of selection\nSet: If compositionString is 0 set t" +
		"he fixed position")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetSelectionAnchorPosition : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Selection Anchor Position")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getSelectionAnchorPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getSelectionAnchorPosition);
		}
		
		public override void Execute()
		{
			_getSelectionAnchorPosition.Value = _tMP_InputField.Value.selectionAnchorPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} selection anchor position -> {_getSelectionAnchorPosition}";
		}
	}
}
