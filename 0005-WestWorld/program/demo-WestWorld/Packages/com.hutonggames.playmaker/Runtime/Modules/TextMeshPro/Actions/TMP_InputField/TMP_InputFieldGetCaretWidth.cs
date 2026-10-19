
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get the Caret Width of a TMP_InputField.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetCaretWidth : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Caret Width")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getCaretWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getCaretWidth);
		}
		
		public override void Execute()
		{
			_getCaretWidth.Value = _tMP_InputField.Value.caretWidth;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} caret width -> {_getCaretWidth}";
		}
	}
}
