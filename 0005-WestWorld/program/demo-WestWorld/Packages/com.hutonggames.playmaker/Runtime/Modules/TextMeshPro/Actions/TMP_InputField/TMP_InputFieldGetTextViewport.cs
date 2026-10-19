
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The RectTransform for the viewport showing the input text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetTextViewport : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Text Viewport")]
		[SerializeField]
		[WriteOnly]
		private RectTransformVar _getTextViewport;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getTextViewport);
		}
		
		public override void Execute()
		{
			_getTextViewport.Value = _tMP_InputField.Value.textViewport;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} text viewport -> {_getTextViewport}";
		}
	}
}
