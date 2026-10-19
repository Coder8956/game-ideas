
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("SingleLine, MultiLineSubmit, or MultiLineNewline")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetLineType : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Line Type")]
		[SerializeField]
		private TMP_InputField_LineTypeVar _setLineType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setLineType);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.lineType = _setLineType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} line type to {_setLineType}";
		}
	}
}
