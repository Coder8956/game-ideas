
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The scroll sensitivity of the Input Field when using a scroll wheel to scroll.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetScrollSensitivity : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Scroll Sensitivity")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getScrollSensitivity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getScrollSensitivity);
		}
		
		public override void Execute()
		{
			_getScrollSensitivity.Value = _tMP_InputField.Value.scrollSensitivity;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} scroll sensitivity -> {_getScrollSensitivity}";
		}
	}
}
