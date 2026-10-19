
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Limits the number of lines of text in the Input Field.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetLineLimit : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Line Limit")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getLineLimit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getLineLimit);
		}
		
		public override void Execute()
		{
			_getLineLimit.Value = _tMP_InputField.Value.lineLimit;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} line limit -> {_getLineLimit}";
		}
	}
}
