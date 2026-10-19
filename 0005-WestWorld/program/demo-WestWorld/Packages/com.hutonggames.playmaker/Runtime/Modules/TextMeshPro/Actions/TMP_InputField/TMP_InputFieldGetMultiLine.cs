
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Is the Input Field multi-line?")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetMultiLine : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Multi Line")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getMultiLine;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getMultiLine);
		}
		
		public override void Execute()
		{
			_getMultiLine.Value = _tMP_InputField.Value.multiLine;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} multi line -> {_getMultiLine}";
		}
	}
}
