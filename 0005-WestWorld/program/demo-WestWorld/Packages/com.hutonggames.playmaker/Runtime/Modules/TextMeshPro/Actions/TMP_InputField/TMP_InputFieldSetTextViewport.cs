
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The RectTransform to use for the input text viewport.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetTextViewport : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Text Viewport")]
		[SerializeField, CanBeNullOrEmpty]
		private RectTransformVar _setTextViewport;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.textViewport = _setTextViewport.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} text viewport to {_setTextViewport}";
		}
	}
}
