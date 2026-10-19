
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get the Custom Caret Color of a TMP_InputField.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetCustomCaretColor : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Custom Caret Color")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getCustomCaretColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getCustomCaretColor);
		}
		
		public override void Execute()
		{
			_getCustomCaretColor.Value = _tMP_InputField.Value.customCaretColor;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} custom caret color -> {_getCustomCaretColor}";
		}
	}
}
