
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Is the Input Field focused?")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetIsFocused : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Is Focused")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsFocused;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getIsFocused);
		}
		
		public override void Execute()
		{
			_getIsFocused.Value = _tMP_InputField.Value.isFocused;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} is focused -> {_getIsFocused}";
		}
	}
}
