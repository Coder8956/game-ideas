
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The color of the custom caret.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetCustomCaretColor : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Custom Caret Color")]
		[SerializeField]
		private BoolVar _setCustomCaretColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setCustomCaretColor);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.customCaretColor = _setCustomCaretColor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} custom caret color to {_setCustomCaretColor}";
		}
	}
}
