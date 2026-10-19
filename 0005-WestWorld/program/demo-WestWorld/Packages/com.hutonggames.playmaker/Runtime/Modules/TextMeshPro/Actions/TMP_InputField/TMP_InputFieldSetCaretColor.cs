
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Set the Input Field's Caret Color. Caret is the vertical bar that shows where text will be inserted.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetCaretColor : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Caret Color")]
		[SerializeField]
		private ColorVar _setCaretColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setCaretColor);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.caretColor = _setCaretColor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} caret color to {_setCaretColor}";
		}
	}
}
