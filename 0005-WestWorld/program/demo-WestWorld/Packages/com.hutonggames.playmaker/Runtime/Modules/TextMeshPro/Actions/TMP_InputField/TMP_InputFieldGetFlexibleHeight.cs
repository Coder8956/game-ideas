
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The extra relative height this layout element should be allocated if there is additional available space.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetFlexibleHeight : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Flexible Height")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFlexibleHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getFlexibleHeight);
		}
		
		public override void Execute()
		{
			_getFlexibleHeight.Value = _tMP_InputField.Value.flexibleHeight;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} flexible height -> {_getFlexibleHeight}";
		}
	}
}
