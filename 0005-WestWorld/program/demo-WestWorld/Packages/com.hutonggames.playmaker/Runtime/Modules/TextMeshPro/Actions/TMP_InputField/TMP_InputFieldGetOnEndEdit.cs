/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get the UnityEvent called when editing has ended.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetOnEndEdit : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField On End Edit")]
		[SerializeField]
		[WriteOnly]
		private TMP_InputField_SubmitEventRef _getOnEndEdit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getOnEndEdit);
		}
		
		public override void Execute()
		{
			_getOnEndEdit.Value = _tMP_InputField.Value.onEndEdit;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} on end edit -> {_getOnEndEdit}";
		}
	}
}
*/