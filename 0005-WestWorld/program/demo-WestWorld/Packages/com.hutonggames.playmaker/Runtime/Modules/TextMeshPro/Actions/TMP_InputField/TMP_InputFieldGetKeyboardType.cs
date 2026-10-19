
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("They type of mobile keyboard that will be used.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetKeyboardType : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Keyboard Type")]
		[SerializeField]
		[WriteOnly]
		private TouchScreenKeyboardTypeRef _getKeyboardType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getKeyboardType);
		}
		
		public override void Execute()
		{
			_getKeyboardType.Value = _tMP_InputField.Value.keyboardType;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} keyboard type -> {_getKeyboardType}";
		}
	}
}
