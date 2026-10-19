/*
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("Sets Text Without Notify on Input Field.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetTextWithoutNotify : BaseAction
	{
		
		[Tooltip("The InputField.")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Input.")]
		[SerializeField]
		private StringVar _input;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _input);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.InputField.SetTextWithoutNotify(System.String);
			_inputField.Value.SetTextWithoutNotify(_input.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} text without notify to {_input}";
		}
	}
}
*/
