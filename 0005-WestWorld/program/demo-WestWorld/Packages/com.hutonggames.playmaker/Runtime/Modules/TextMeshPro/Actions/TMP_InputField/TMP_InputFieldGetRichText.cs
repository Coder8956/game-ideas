
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Use rich text in the Input Field.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetRichText : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Rich Text")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getRichText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getRichText);
		}
		
		public override void Execute()
		{
			_getRichText.Value = _tMP_InputField.Value.richText;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} rich text -> {_getRichText}";
		}
	}
}
