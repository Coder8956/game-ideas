
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Set the width of the caret in the Input Field. Caret is the vertical bar that shows where text will be inserted.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetCaretWidth : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Caret Width")]
		[SerializeField]
		private IntegerVar _setCaretWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setCaretWidth);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.caretWidth = _setCaretWidth.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} caret width to {_setCaretWidth}";
		}
	}
}
