
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Limits the number of lines of text in the Input Field.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetLineLimit : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Line Limit")]
		[SerializeField]
		private IntegerVar _setLineLimit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setLineLimit);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.lineLimit = _setLineLimit.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} line limit to {_setLineLimit}";
		}
	}
}
