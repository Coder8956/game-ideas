
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Dropdown)]
	[ActionDescription("The index of the currently selected option. 0 is the first option, 1 is the secon" +
		"d, and so on.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Dropdown.html")]
	public sealed class DropdownGetValue : BaseAction
	{
		
		[Tooltip("The Dropdown")]
		[SerializeField]
		private DropdownVar _dropdown;
		
		[Tooltip("Get Dropdown Value")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_dropdown, _getValue);
		}
		
		public override void Execute()
		{
			_getValue.Value = _dropdown.Value.value;
		}
		
		public override string GetSummary()
		{
			return "Get {_dropdown} Value -> {_getValue}";
		}
	}
}
