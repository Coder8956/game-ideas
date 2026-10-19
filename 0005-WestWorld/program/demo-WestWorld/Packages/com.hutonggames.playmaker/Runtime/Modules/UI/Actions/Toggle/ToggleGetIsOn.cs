
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Toggle)]
	[ActionDescription("Is the toggle on.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Toggle.html")]
	public sealed class ToggleGetIsOn : BaseAction
	{
		
		[Tooltip("The Toggle")]
		[SerializeField]
		private ToggleVar _toggle;
		
		[Tooltip("Get Toggle Is On")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsOn;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggle, _getIsOn);
		}
		
		public override void Execute()
		{
			_getIsOn.Value = _toggle.Value.isOn;
		}
		
		public override string GetSummary()
		{
			return "Get {_toggle} is on -> {_getIsOn}";
		}
	}
}
