
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get the placeholder text to use in the Input Field.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetPlaceholder : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Placeholder")]
		[SerializeField]
		[WriteOnly]
		private UI.GraphicVar _getPlaceholder;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getPlaceholder);
		}
		
		public override void Execute()
		{
			_getPlaceholder.Value = _tMP_InputField.Value.placeholder;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} placeholder -> {_getPlaceholder}";
		}
	}
}
