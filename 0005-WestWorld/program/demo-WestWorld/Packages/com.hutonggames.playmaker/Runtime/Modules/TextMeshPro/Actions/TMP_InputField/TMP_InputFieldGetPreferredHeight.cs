
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get the height of all the text if constrained to the height of the RectTransform." +
		"")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetPreferredHeight : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Preferred Height")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getPreferredHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getPreferredHeight);
		}
		
		public override void Execute()
		{
			_getPreferredHeight.Value = _tMP_InputField.Value.preferredHeight;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} preferred height -> {_getPreferredHeight}";
		}
	}
}
