
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Toggle)]
	[ActionDescription("Is the toggle on.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Toggle.html")]
	public sealed class ToggleSetIsOn : BaseAction
	{
		
		[Tooltip("The Toggle")]
		[SerializeField]
		private ToggleVar _toggle;
		
		[Tooltip("Set Toggle Is On")]
		[SerializeField]
		private BoolVar _setIsOn;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggle, _setIsOn);
		}
		
		public override void Execute()
		{
			_toggle.Value.isOn = _setIsOn.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_toggle} is on to {_setIsOn}";
		}
	}
}
