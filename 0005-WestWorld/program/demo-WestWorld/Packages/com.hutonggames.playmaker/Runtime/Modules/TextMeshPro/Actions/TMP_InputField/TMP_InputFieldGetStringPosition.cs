
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The current position in the input string.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetStringPosition : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField String Position")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getStringPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getStringPosition);
		}
		
		public override void Execute()
		{
			_getStringPosition.Value = _tMP_InputField.Value.stringPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} string position -> {_getStringPosition}";
		}
	}
}
