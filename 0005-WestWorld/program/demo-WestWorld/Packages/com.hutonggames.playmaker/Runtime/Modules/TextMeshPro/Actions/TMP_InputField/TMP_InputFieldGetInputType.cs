
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The type of input expected: AutoCorrect, Password, Standard.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetInputType : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Input Type")]
		[SerializeField]
		[WriteOnly]
		private TMP_InputField_InputTypeRef _getInputType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getInputType);
		}
		
		public override void Execute()
		{
			_getInputType.Value = _tMP_InputField.Value.inputType;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} input type -> {_getInputType}";
		}
	}
}
