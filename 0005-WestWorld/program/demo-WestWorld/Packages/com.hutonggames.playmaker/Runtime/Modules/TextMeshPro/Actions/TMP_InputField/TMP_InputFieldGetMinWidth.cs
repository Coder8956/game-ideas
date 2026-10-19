
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The minimum width this layout element should have.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetMinWidth : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Min Width")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMinWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getMinWidth);
		}
		
		public override void Execute()
		{
			_getMinWidth.Value = _tMP_InputField.Value.minWidth;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} min width -> {_getMinWidth}";
		}
	}
}
