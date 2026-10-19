
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The Scrollbar used for the vertical scrollbar.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetVerticalScrollbar : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Vertical Scrollbar")]
		[SerializeField]
		[WriteOnly]
		private UI.ScrollbarVar _getVerticalScrollbar;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getVerticalScrollbar);
		}
		
		public override void Execute()
		{
			_getVerticalScrollbar.Value = _tMP_InputField.Value.verticalScrollbar;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} vertical scrollbar -> {_getVerticalScrollbar}";
		}
	}
}
