
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The fixed position of the selection in the raw string which may contains rich tex" +
		"t.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetSelectionStringAnchorPosition : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Selection String Anchor Position")]
		[SerializeField]
		private IntegerVar _setSelectionStringAnchorPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setSelectionStringAnchorPosition);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.selectionStringAnchorPosition = _setSelectionStringAnchorPosition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} selection string anchor position to {_setSelectionStringAnchorPosition}";
		}
	}
}
