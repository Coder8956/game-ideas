
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("Set the InputField to be read only.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetReadOnly : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Read Only")]
		[SerializeField]
		private BoolVar _setReadOnly;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setReadOnly);
		}
		
		public override void Execute()
		{
			_inputField.Value.readOnly = _setReadOnly.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} read only to {_setReadOnly}";
		}
	}
}
