
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The type of content shown in the Input Field: Name, EmailAddress, Password...")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetContentType : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Content Type")]
		[SerializeField]
		private TMP_InputField_ContentTypeVar _setContentType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setContentType);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.contentType = _setContentType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} content type to {_setContentType}";
		}
	}
}
