
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The UnityEvent to call when the Input Field value is changed.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldOnValueChanged__UnityEvent : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField On Value Changed")]
		[SerializeField]
		private TMP_InputField_OnChangeEventVar _setOnValueChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setOnValueChanged);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.onValueChanged = _setOnValueChanged.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} on value changed to {_setOnValueChanged}";
		}
	}
}
