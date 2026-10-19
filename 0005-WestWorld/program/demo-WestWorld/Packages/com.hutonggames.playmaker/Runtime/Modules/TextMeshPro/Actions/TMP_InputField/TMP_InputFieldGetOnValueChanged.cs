/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get The UnityEvent to call when the value of the Input Field has changed.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetOnValueChanged : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField On Value Changed")]
		[SerializeField]
		[WriteOnly]
		private TMP_InputField_OnChangeEventRef _getOnValueChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getOnValueChanged);
		}
		
		public override void Execute()
		{
			_getOnValueChanged.Value = _tMP_InputField.Value.onValueChanged;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} on value changed -> {_getOnValueChanged}";
		}
	}
}
*/