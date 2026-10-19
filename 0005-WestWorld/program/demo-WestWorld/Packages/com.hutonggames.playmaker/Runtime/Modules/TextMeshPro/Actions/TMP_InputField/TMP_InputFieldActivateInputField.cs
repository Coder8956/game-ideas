
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ConvertibleGroup("InputFieldActivate")]
	[ActionDescription("Activate the InputField")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldActivateInputField : BaseAction
	{
		
		[Tooltip("The TMP_InputField.")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		public override bool CanExecute() => CheckParameters(_tMP_InputField);

		public override void Execute() => _tMP_InputField.Value.ActivateInputField();

		public override string GetSummary() => "Activate {_tMP_InputField}";
	}
}
