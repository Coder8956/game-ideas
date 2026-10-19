
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The scroll sensitivity of the Input Field when using a scroll wheel to scroll.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetScrollSensitivity : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Scroll Sensitivity")]
		[SerializeField]
		private FloatVar _setScrollSensitivity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setScrollSensitivity);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.scrollSensitivity = _setScrollSensitivity.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} scroll sensitivity to {_setScrollSensitivity}";
		}
	}
}
