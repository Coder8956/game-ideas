
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Controls whether the original text is restored when pressing \"ESC\".")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetRestoreOriginalTextOnEscape : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Restore Original Text On Escape")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getRestoreOriginalTextOnEscape;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getRestoreOriginalTextOnEscape);
		}
		
		public override void Execute()
		{
			_getRestoreOriginalTextOnEscape.Value = _tMP_InputField.Value.restoreOriginalTextOnEscape;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} restore original text on escape -> {_getRestoreOriginalTextOnEscape}";
		}
	}
}
