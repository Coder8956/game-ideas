
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The TMP_Text component used by the Input Field.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetTextComponent : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Text Component")]
		[SerializeField]
		[WriteOnly]
		private TMP_TextRef _getTextComponent;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getTextComponent);
		}
		
		public override void Execute()
		{
			_getTextComponent.Value = _tMP_InputField.Value.textComponent;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} text component -> {_getTextComponent}";
		}
	}
}
