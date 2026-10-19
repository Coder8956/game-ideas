/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get the UnityEvent sent text selection has ended.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetOnEndTextSelection : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField On End Text Selection")]
		[SerializeField]
		[WriteOnly]
		private TMP_InputField_TextSelectionEventRef _getOnEndTextSelection;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getOnEndTextSelection);
		}
		
		public override void Execute()
		{
			_getOnEndTextSelection.Value = _tMP_InputField.Value.onEndTextSelection;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} on end text selection -> {_getOnEndTextSelection}";
		}
	}
}
*/