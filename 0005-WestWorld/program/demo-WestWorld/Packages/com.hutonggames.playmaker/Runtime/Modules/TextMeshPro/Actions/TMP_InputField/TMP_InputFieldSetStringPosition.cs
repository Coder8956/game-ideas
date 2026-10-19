
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The current position in the input string.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetStringPosition : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField String Position")]
		[SerializeField]
		private IntegerVar _setStringPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setStringPosition);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.stringPosition = _setStringPosition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} string position to {_setStringPosition}";
		}
	}
}
