
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The type of input expected: AutoCorrect, Password, Standard.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetInputType : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Input Type")]
		[SerializeField]
		private TMP_InputField_InputTypeVar _setInputType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setInputType);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.inputType = _setInputType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} input type to {_setInputType}";
		}
	}
}
