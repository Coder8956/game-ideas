/*
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[PublicAPI]
	[ActionCategory(Category.UGUI_Dropdown)]
	[ActionDescription("Sets Value Without Notify on Dropdown.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Dropdown.html")]
	public sealed class DropdownSetValueWithoutNotify : BaseAction
	{
		
		[Tooltip("The Dropdown.")]
		[SerializeField]
		private UI.DropdownVar _dropdown;
		
		[Tooltip("Input.")]
		[SerializeField]
		private IntegerVar _input;
		
		public override bool CanExecute()
		{
			return CheckParameters(_dropdown, _input);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Dropdown.SetValueWithoutNotify(System.Int32);
			_dropdown.Value.SetValueWithoutNotify(_input.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_dropdown} value without notify to {_input}";
		}
	}
}
*/
