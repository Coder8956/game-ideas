
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The Scrollbar used for the vertical scrollbar.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetVerticalScrollbar : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Vertical Scrollbar")]
		[SerializeField, CanBeNullOrEmpty]
		private UI.ScrollbarVar _setVerticalScrollbar;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.verticalScrollbar = _setVerticalScrollbar.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} vertical scrollbar to {_setVerticalScrollbar}";
		}
	}
}
