
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Is Rich Text editing allowed?")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetIsRichTextEditingAllowed : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Is Rich Text Editing Allowed")]
		[SerializeField]
		private BoolVar _setIsRichTextEditingAllowed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setIsRichTextEditingAllowed);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.isRichTextEditingAllowed = _setIsRichTextEditingAllowed.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} is rich text editing allowed to {_setIsRichTextEditingAllowed}";
		}
	}
}
