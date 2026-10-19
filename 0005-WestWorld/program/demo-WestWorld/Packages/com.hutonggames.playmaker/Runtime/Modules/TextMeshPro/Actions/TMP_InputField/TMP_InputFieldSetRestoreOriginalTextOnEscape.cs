
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Controls whether the original text is restored when pressing \"ESC\".")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetRestoreOriginalTextOnEscape : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Restore Original Text On Escape")]
		[SerializeField]
		private BoolVar _setRestoreOriginalTextOnEscape;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setRestoreOriginalTextOnEscape);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.restoreOriginalTextOnEscape = _setRestoreOriginalTextOnEscape.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} restore original text on escape to {_setRestoreOriginalTextOnEscape}";
		}
	}
}
