
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("How many characters the input field is limited to. 0 = infinite.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetCharacterLimit : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Character Limit")]
		[SerializeField]
		private IntegerVar _setCharacterLimit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setCharacterLimit);
		}
		
		public override void Execute()
		{
			_inputField.Value.characterLimit = _setCharacterLimit.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} character limit to {_setCharacterLimit}";
		}
	}
}
