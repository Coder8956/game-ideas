
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ConvertibleGroup("InputFieldActivate")]
	[ActionDescription("Deactivate the InputField")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldDeactivateInputField : BaseAction
	{
		
		[Tooltip("The TMP_InputField.")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Clear Selection.")]
		[SerializeField]
		private BoolVar _clearSelection;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _clearSelection);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_InputField.DeactivateInputField(System.Boolean);
			_tMP_InputField.Value.DeactivateInputField(_clearSelection.Value);
		}
		
		public override string GetSummary()
		{
			return "Deactivate {_tMP_InputField} {_clearSelection}";
		}
	}
}
