/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Determines if the whole text will be selected when focused.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetOnFocusSelectAll : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField On Focus Select All")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getOnFocusSelectAll;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getOnFocusSelectAll);
		}
		
		public override void Execute()
		{
			_getOnFocusSelectAll.Value = _tMP_InputField.Value.onFocusSelectAll;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} on focus select all -> {_getOnFocusSelectAll}";
		}
	}
}
*/