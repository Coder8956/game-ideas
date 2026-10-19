
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ToggleGroup)]
	[ActionDescription("Is it allowed that no toggle is switched on?")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ToggleGroup.html")]
	public sealed class ToggleGroupSetAllowSwitchOff : BaseAction
	{
		
		[Tooltip("The ToggleGroup")]
		[SerializeField]
		private ToggleGroupVar _toggleGroup;
		
		[Tooltip("Set ToggleGroup Allow Switch Off")]
		[SerializeField]
		private BoolVar _setAllowSwitchOff;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggleGroup, _setAllowSwitchOff);
		}
		
		public override void Execute()
		{
			_toggleGroup.Value.allowSwitchOff = _setAllowSwitchOff.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_toggleGroup} allow switch off to {_setAllowSwitchOff}";
		}
	}
}
