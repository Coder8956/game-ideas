
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The selection color for the Input Field.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetSelectionColor : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Selection Color")]
		[SerializeField]
		private ColorVar _setSelectionColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setSelectionColor);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.selectionColor = _setSelectionColor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} selection color to {_setSelectionColor}";
		}
	}
}
