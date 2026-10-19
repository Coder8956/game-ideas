
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Get the displayed with of all input characters.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetPreferredWidth : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Preferred Width")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getPreferredWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getPreferredWidth);
		}
		
		public override void Execute()
		{
			_getPreferredWidth.Value = _tMP_InputField.Value.preferredWidth;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} preferred width -> {_getPreferredWidth}";
		}
	}
}
