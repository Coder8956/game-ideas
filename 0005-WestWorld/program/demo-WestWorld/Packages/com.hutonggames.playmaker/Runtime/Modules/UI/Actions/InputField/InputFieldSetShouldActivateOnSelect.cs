
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("Should the inputfield be automatically activated upon selection.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetShouldActivateOnSelect : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Should Activate On Select")]
		[SerializeField]
		private BoolVar _setShouldActivateOnSelect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setShouldActivateOnSelect);
		}
		
		public override void Execute()
		{
			_inputField.Value.shouldActivateOnSelect = _setShouldActivateOnSelect.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} should activate on select to {_setShouldActivateOnSelect}";
		}
	}
}
