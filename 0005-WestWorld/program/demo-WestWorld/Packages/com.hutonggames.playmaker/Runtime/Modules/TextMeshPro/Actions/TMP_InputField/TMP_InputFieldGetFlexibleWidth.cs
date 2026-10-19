
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The extra relative width this layout element should be allocated if there is additional available space.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetFlexibleWidth : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Flexible Width")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFlexibleWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getFlexibleWidth);
		}
		
		public override void Execute()
		{
			_getFlexibleWidth.Value = _tMP_InputField.Value.flexibleWidth;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} flexible width -> {_getFlexibleWidth}";
		}
	}
}
