
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The UnityEvent to call when text selection has ended.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldOnEndTextSelection__UnityEvent : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField On End Text Selection")]
		[SerializeField]
		private TMP_InputField_TextSelectionEventVar _setOnEndTextSelection;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setOnEndTextSelection);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.onEndTextSelection = _setOnEndTextSelection.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} on end text selection to {_setOnEndTextSelection}";
		}
	}
}
