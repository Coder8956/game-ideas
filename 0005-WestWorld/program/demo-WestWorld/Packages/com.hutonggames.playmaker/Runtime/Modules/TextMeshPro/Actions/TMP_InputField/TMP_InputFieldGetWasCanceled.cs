
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Was the Input Field cancelled.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetWasCanceled : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Was Canceled")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getWasCanceled;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getWasCanceled);
		}
		
		public override void Execute()
		{
			_getWasCanceled.Value = _tMP_InputField.Value.wasCanceled;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} was canceled -> {_getWasCanceled}";
		}
	}
}
