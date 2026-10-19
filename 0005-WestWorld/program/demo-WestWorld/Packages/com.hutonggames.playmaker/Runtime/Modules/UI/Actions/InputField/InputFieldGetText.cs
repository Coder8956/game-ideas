
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("The current value of the input field.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldGetText : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Get InputField Text")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _getText);
		}
		
		public override void Execute()
		{
			_getText.Value = _inputField.Value.text;
		}
		
		public override string GetSummary()
		{
			return "Get {_inputField} text -> {_getText}";
		}
	}
}
