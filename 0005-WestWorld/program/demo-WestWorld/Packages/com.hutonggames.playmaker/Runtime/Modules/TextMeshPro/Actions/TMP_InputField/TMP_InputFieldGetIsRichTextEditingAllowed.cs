
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Is Rich Text editing allowed?")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetIsRichTextEditingAllowed : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Is Rich Text Editing Allowed")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsRichTextEditingAllowed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getIsRichTextEditingAllowed);
		}
		
		public override void Execute()
		{
			_getIsRichTextEditingAllowed.Value = _tMP_InputField.Value.isRichTextEditingAllowed;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} is rich text editing allowed -> {_getIsRichTextEditingAllowed}";
		}
	}
}
