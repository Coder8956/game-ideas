
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("They type of mobile keyboard that will be used.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetKeyboardType : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Keyboard Type")]
		[SerializeField]
		private TouchScreenKeyboardTypeVar _setKeyboardType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setKeyboardType);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.keyboardType = _setKeyboardType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} keyboard type to {_setKeyboardType}";
		}
	}
}
