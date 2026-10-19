
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("See ILayoutElement.minHeight.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetMinHeight : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Min Height")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMinHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getMinHeight);
		}
		
		public override void Execute()
		{
			_getMinHeight.Value = _tMP_InputField.Value.minHeight;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} min height -> {_getMinHeight}";
		}
	}
}
