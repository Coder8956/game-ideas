
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The selection color for the Input Field.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetSelectionColor : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Selection Color")]
		[SerializeField]
		[WriteOnly]
		private ColorRef _getSelectionColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getSelectionColor);
		}
		
		public override void Execute()
		{
			_getSelectionColor.Value = _tMP_InputField.Value.selectionColor;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} selection color -> {_getSelectionColor}";
		}
	}
}
