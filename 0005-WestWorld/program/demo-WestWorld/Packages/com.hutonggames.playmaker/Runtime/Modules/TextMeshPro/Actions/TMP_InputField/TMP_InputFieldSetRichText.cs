
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Use rich text in the Input Field.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetRichText : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Rich Text")]
		[SerializeField]
		private BoolVar _setRichText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setRichText);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.richText = _setRichText.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} rich text to {_setRichText}";
		}
	}
}
