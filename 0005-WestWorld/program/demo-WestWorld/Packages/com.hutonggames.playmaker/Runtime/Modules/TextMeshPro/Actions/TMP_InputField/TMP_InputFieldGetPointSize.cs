
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Set the point size on both Placeholder and Input text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetPointSize : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Point Size")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getPointSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getPointSize);
		}
		
		public override void Execute()
		{
			_getPointSize.Value = _tMP_InputField.Value.pointSize;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} point size -> {_getPointSize}";
		}
	}
}
