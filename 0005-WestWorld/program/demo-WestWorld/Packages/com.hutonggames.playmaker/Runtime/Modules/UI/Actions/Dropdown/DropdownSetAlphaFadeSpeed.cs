
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Dropdown)]
	[ActionDescription("The time interval at which a drop down will appear and disappear")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Dropdown.html")]
	public sealed class DropdownSetAlphaFadeSpeed : BaseAction
	{
		
		[Tooltip("The Dropdown")]
		[SerializeField]
		private DropdownVar _dropdown;
		
		[Tooltip("Set Dropdown Alpha Fade Speed")]
		[SerializeField]
		private FloatVar _setAlphaFadeSpeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_dropdown, _setAlphaFadeSpeed);
		}
		
		public override void Execute()
		{
			_dropdown.Value.alphaFadeSpeed = _setAlphaFadeSpeed.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_dropdown} Alpha Fade Speed to {_setAlphaFadeSpeed}";
		}
	}
}
