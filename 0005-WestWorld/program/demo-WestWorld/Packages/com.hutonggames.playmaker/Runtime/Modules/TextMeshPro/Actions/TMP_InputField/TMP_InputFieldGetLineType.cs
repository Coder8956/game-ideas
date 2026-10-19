
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("SingleLine, MultiLineSubmit, or MultiLineNewline")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetLineType : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Line Type")]
		[SerializeField]
		[WriteOnly]
		private TMP_InputField_LineTypeRef _getLineType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getLineType);
		}
		
		public override void Execute()
		{
			_getLineType.Value = _tMP_InputField.Value.lineType;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} line type -> {_getLineType}";
		}
	}
}
