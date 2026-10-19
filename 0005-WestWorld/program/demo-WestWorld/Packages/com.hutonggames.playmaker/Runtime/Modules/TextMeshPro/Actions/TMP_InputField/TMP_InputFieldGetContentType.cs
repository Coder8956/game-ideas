
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The type of content shown in the Input Field: Name, EmailAddress, Password...")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetContentType : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Content Type")]
		[SerializeField]
		[WriteOnly]
		private TMP_InputField_ContentTypeRef _getContentType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getContentType);
		}
		
		public override void Execute()
		{
			_getContentType.Value = _tMP_InputField.Value.contentType;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} content type -> {_getContentType}";
		}
	}
}
