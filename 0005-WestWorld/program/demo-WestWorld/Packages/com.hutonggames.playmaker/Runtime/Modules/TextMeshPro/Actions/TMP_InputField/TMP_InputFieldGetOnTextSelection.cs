/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get The UnityEvent to call when text is selected in the Input Field.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetOnTextSelection : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField On Text Selection")]
		[SerializeField]
		[WriteOnly]
		private TMP_InputField_TextSelectionEventRef _getOnTextSelection;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getOnTextSelection);
		}
		
		public override void Execute()
		{
			_getOnTextSelection.Value = _tMP_InputField.Value.onTextSelection;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} on text selection -> {_getOnTextSelection}";
		}
	}
}
*/