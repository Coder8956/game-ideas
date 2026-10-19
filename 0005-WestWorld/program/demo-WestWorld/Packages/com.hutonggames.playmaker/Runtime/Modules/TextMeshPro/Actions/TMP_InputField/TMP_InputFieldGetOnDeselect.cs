/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The Unity Event to call when the Input Field was deselected.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetOnDeselect : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField On Deselect")]
		[SerializeField]
		[WriteOnly]
		private TMP_InputField_SelectionEventRef _getOnDeselect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getOnDeselect);
		}
		
		public override void Execute()
		{
			_getOnDeselect.Value = _tMP_InputField.Value.onDeselect;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} on deselect -> {_getOnDeselect}";
		}
	}
}
*/