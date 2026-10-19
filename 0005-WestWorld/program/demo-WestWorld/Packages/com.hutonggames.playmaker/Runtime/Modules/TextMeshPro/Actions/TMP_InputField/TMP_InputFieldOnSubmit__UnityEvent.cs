
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The UnityEvent to call when the Input Field is submitted.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldOnSubmit__UnityEvent : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField On Submit")]
		[SerializeField]
		private TMP_InputField_SubmitEventVar _setOnSubmit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setOnSubmit);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.onSubmit = _setOnSubmit.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} on submit to {_setOnSubmit}";
		}
	}
}
